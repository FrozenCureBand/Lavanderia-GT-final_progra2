using System;
using System.Collections.Generic;
using System.Data;               // SqlDbType: tipo de cada parámetro
using System.Data.SqlClient;     // ADO.NET: SqlConnection, SqlCommand, SqlDataReader
using Entidad;

namespace Datos
{
    /// <summary>
    /// Acceso a datos de dbo.Tbl_Entregas: consultar, buscar, insertar, actualizar y eliminar.
    /// Integrado desde el proyecto LavanderiasMultinegocio y adaptado a la estructura de este proyecto
    /// (clase Conexion, parámetros con tipo, try-catch con mensajes claros).
    /// </summary>
    public class DEntrega
    {
        // Número de error de SQL Server cuando una llave foránea impide la operación.
        private const int ErrorLlaveForanea = 547;

        /// <summary>CONSULTAR: todas las entregas con el nombre del cliente de la recepción.</summary>
        public List<Entrega> Consultar()
        {
            return ConsultarConFiltro(null);
        }

        /// <summary>BUSCAR: entregas cuyo cliente o persona que recibe contienen el texto (sin distinguir mayúsculas ni tildes).</summary>
        public List<Entrega> Buscar(string texto)
        {
            return ConsultarConFiltro(texto);
        }

        /// <summary>Consulta las entregas. Si 'texto' es null trae todas; si no, agrega el filtro de búsqueda.</summary>
        private List<Entrega> ConsultarConFiltro(string texto)
        {
            List<Entrega> lista = new List<Entrega>();

            // JOIN: la entrega se une con su recepción y la recepción con su cliente para obtener el nombre.
            string sql =
                "SELECT en.IdEntrega, en.IdRecepcion, c.NombreCompleto AS NombreCliente, en.FechaEntrega, " +
                "       en.NombreRecibe, en.Observaciones, en.Estado " +
                "FROM dbo.Tbl_Entregas en " +
                "JOIN dbo.Tbl_Recepciones r ON r.IdRecepcion = en.IdRecepcion " +
                "JOIN dbo.Tbl_Clientes c ON c.IdCliente = r.IdCliente ";
            if (texto != null)
            {
                sql += "WHERE c.NombreCompleto COLLATE Latin1_General_CI_AI LIKE @Patron " +
                       "   OR en.NombreRecibe COLLATE Latin1_General_CI_AI LIKE @Patron ";
            }
            sql += "ORDER BY en.IdEntrega;";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    if (texto != null)
                    {
                        cmd.Parameters.Add("@Patron", SqlDbType.VarChar, 300).Value = Busqueda.Patron(texto);
                    }
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Entrega entrega = new Entrega();
                            entrega.IdEntrega = Convert.ToInt32(dr["IdEntrega"]);
                            entrega.IdRecepcion = Convert.ToInt32(dr["IdRecepcion"]);
                            entrega.NombreCliente = dr["NombreCliente"].ToString();
                            if (dr["FechaEntrega"] != DBNull.Value)
                            {
                                entrega.FechaEntrega = Convert.ToDateTime(dr["FechaEntrega"]);
                            }
                            // Si la columna es NULL, ToString() devuelve "" (texto vacío).
                            entrega.NombreRecibe = dr["NombreRecibe"].ToString();
                            entrega.Observaciones = dr["Observaciones"].ToString();
                            entrega.Estado = dr["Estado"].ToString();
                            lista.Add(entrega);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo consultar la lista de entregas. " + ex.Message, ex);
            }

            return lista;
        }

        /// <summary>
        /// Indica si la recepción ya tiene OTRA entrega registrada.
        /// 'idExcluir' es la entrega que se está editando (0 cuando es una entrega nueva).
        /// </summary>
        public bool ExisteEntregaDeRecepcion(int idRecepcion, int idExcluir)
        {
            string sql = "SELECT COUNT(*) FROM dbo.Tbl_Entregas WHERE IdRecepcion = @IdRecepcion AND IdEntrega <> @IdEntrega;";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@IdRecepcion", SqlDbType.Int).Value = idRecepcion;
                    cmd.Parameters.Add("@IdEntrega", SqlDbType.Int).Value = idExcluir;
                    cn.Open();
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo revisar las entregas de la recepción. " + ex.Message, ex);
            }
        }

        /// <summary>INSERTAR: guarda una entrega nueva y devuelve el IdEntrega generado.</summary>
        public int Insertar(Entrega entrega)
        {
            string sql =
                "INSERT INTO dbo.Tbl_Entregas (IdRecepcion, FechaEntrega, NombreRecibe, Observaciones, Estado) " +
                "VALUES (@IdRecepcion, @FechaEntrega, @NombreRecibe, @Observaciones, @Estado); " +
                "SELECT CAST(SCOPE_IDENTITY() AS int);";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    AgregarParametros(cmd, entrega);
                    cmd.Parameters.Add("@Estado", SqlDbType.VarChar).Value = entrega.Estado;
                    cn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex) when (ex.Number == ErrorLlaveForanea)
            {
                throw new Exception("La recepción indicada no existe.", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo guardar la entrega. " + ex.Message, ex);
            }
        }

        /// <summary>ACTUALIZAR: modifica una entrega (su Estado no cambia). Devuelve false si ya no existe.</summary>
        public bool Actualizar(Entrega entrega)
        {
            string sql =
                "UPDATE dbo.Tbl_Entregas SET IdRecepcion = @IdRecepcion, FechaEntrega = @FechaEntrega, " +
                "NombreRecibe = @NombreRecibe, Observaciones = @Observaciones " +
                "WHERE IdEntrega = @IdEntrega;";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    AgregarParametros(cmd, entrega);
                    cmd.Parameters.Add("@IdEntrega", SqlDbType.Int).Value = entrega.IdEntrega;
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex) when (ex.Number == ErrorLlaveForanea)
            {
                throw new Exception("La recepción indicada no existe.", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo actualizar la entrega. " + ex.Message, ex);
            }
        }

        /// <summary>ELIMINAR: borra una entrega. Devuelve false si ya no existe.</summary>
        public bool Eliminar(int idEntrega)
        {
            string sql = "DELETE FROM dbo.Tbl_Entregas WHERE IdEntrega = @IdEntrega;";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@IdEntrega", SqlDbType.Int).Value = idEntrega;
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar la entrega. " + ex.Message, ex);
            }
        }

        /// <summary>Parámetros comunes de INSERT y UPDATE.</summary>
        private static void AgregarParametros(SqlCommand cmd, Entrega entrega)
        {
            cmd.Parameters.Add("@IdRecepcion", SqlDbType.Int).Value = entrega.IdRecepcion;
            cmd.Parameters.Add("@FechaEntrega", SqlDbType.DateTime).Value = (object)entrega.FechaEntrega ?? DBNull.Value;
            cmd.Parameters.Add("@NombreRecibe", SqlDbType.VarChar).Value = entrega.NombreRecibe;
            cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value =
                string.IsNullOrWhiteSpace(entrega.Observaciones) ? (object)DBNull.Value : entrega.Observaciones;
        }
    }
}
