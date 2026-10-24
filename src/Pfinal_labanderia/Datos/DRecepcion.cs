using System;
using System.Collections.Generic;
using System.Data;               // SqlDbType: tipo de cada parámetro
using System.Data.SqlClient;     // ADO.NET: SqlConnection, SqlCommand, SqlDataReader
using Entidad;

namespace Datos
{
    /// <summary>
    /// Acceso a datos de dbo.Tbl_Recepciones: consultar, insertar, actualizar y eliminar.
    /// Los valores escritos por el usuario viajan como PARÁMETROS para evitar inyección SQL.
    /// </summary>
    public class DRecepcion
    {
        // Número de error de SQL Server cuando una llave foránea impide la operación.
        private const int ErrorLlaveForanea = 547;

        /// <summary>
        /// CONSULTAR: devuelve todas las recepciones con el nombre del cliente y de la sucursal.
        /// No recibe valores del usuario, por eso no lleva parámetros.
        /// </summary>
        public List<Recepcion> Consultar()
        {
            return ConsultarConFiltro(null);
        }

        /// <summary>
        /// BUSCAR: recepciones cuyo cliente o sucursal contienen el texto (sin distinguir mayúsculas ni tildes).
        /// </summary>
        public List<Recepcion> Buscar(string texto)
        {
            return ConsultarConFiltro(texto);
        }

        /// <summary>
        /// Consulta las recepciones. Si 'texto' es null trae todas; si no, agrega el filtro de búsqueda.
        /// El texto viaja como PARÁMETRO (@Patron), nunca pegado dentro del SQL.
        /// </summary>
        private List<Recepcion> ConsultarConFiltro(string texto)
        {
            List<Recepcion> lista = new List<Recepcion>();

            // JOIN: une cada recepción con su cliente y su sucursal para obtener sus nombres.
            string sql =
                "SELECT r.IdRecepcion, r.IdCliente, c.NombreCompleto AS NombreCliente, " +
                "       r.IdSucursal, s.Nombre AS NombreSucursal, r.FechaRecepcion, " +
                "       r.FechaEntregaEstimada, r.Total, r.Estado, r.Observaciones " +
                "FROM dbo.Tbl_Recepciones r " +
                "JOIN dbo.Tbl_Clientes c ON c.IdCliente = r.IdCliente " +
                "JOIN dbo.Tbl_Sucursales s ON s.IdSucursal = r.IdSucursal ";
            if (texto != null)
            {
                // COLLATE ..._CI_AI: no distingue mayúsculas (CI) ni tildes (AI).
                sql += "WHERE c.NombreCompleto COLLATE Latin1_General_CI_AI LIKE @Patron " +
                       "   OR s.Nombre COLLATE Latin1_General_CI_AI LIKE @Patron ";
            }
            sql += "ORDER BY r.IdRecepcion;";

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
                            Recepcion recepcion = new Recepcion();
                            recepcion.IdRecepcion = Convert.ToInt32(dr["IdRecepcion"]);
                            recepcion.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                            recepcion.NombreCliente = dr["NombreCliente"].ToString();
                            recepcion.IdSucursal = Convert.ToInt32(dr["IdSucursal"]);
                            recepcion.NombreSucursal = dr["NombreSucursal"].ToString();

                            // Las columnas que permiten NULL se revisan antes de convertir.
                            if (dr["FechaRecepcion"] != DBNull.Value)
                            {
                                recepcion.FechaRecepcion = Convert.ToDateTime(dr["FechaRecepcion"]);
                            }
                            if (dr["FechaEntregaEstimada"] != DBNull.Value)
                            {
                                recepcion.FechaEntregaEstimada = Convert.ToDateTime(dr["FechaEntregaEstimada"]);
                            }
                            if (dr["Total"] != DBNull.Value)
                            {
                                recepcion.Total = Convert.ToDecimal(dr["Total"]);
                            }

                            // Si la columna es NULL, ToString() devuelve "" (texto vacío).
                            recepcion.Estado = dr["Estado"].ToString();
                            recepcion.Observaciones = dr["Observaciones"].ToString();
                            lista.Add(recepcion);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo consultar la lista de recepciones. " + ex.Message, ex);
            }

            return lista;
        }

        /// <summary>
        /// Recepciones para una lista desplegable: "Recepción #1 - Carlos Méndez" (las más recientes primero).
        /// La usan los módulos Entregas y Procesos.
        /// </summary>
        public List<OpcionLista> ListarOpciones()
        {
            List<OpcionLista> lista = new List<OpcionLista>();
            string sql = "SELECT r.IdRecepcion, c.NombreCompleto " +
                         "FROM dbo.Tbl_Recepciones r " +
                         "JOIN dbo.Tbl_Clientes c ON c.IdCliente = r.IdCliente " +
                         "ORDER BY r.IdRecepcion DESC;";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int id = Convert.ToInt32(dr["IdRecepcion"]);
                            lista.Add(new OpcionLista(id, "Recepción #" + id + " - " + dr["NombreCompleto"]));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo consultar la lista de recepciones. " + ex.Message, ex);
            }

            return lista;
        }

        /// <summary>INSERTAR: guarda una recepción nueva y devuelve el IdRecepcion generado.</summary>
        public int Insertar(Recepcion recepcion)
        {
            // Estado no se envía: SQL Server pone 'Recibido' (valor por defecto de la columna).
            string sql =
                "INSERT INTO dbo.Tbl_Recepciones (IdCliente, IdSucursal, FechaRecepcion, FechaEntregaEstimada, Total, Observaciones) " +
                "VALUES (@IdCliente, @IdSucursal, @FechaRecepcion, @FechaEntregaEstimada, @Total, @Observaciones); " +
                "SELECT CAST(SCOPE_IDENTITY() AS int);";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    AgregarParametros(cmd, recepcion);
                    cn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex) when (ex.Number == ErrorLlaveForanea)
            {
                throw new Exception("El cliente o la sucursal indicados no existen. Revise los códigos.", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo guardar la recepción. " + ex.Message, ex);
            }
        }

        /// <summary>
        /// ACTUALIZAR: modifica una recepción. El Estado NO se cambia aquí (lo cambian los procesos y entregas).
        /// Devuelve false si la recepción ya no existe.
        /// </summary>
        public bool Actualizar(Recepcion recepcion)
        {
            // ISNULL: si no se escribió fecha de recepción, se conserva la que ya tenía.
            string sql =
                "UPDATE dbo.Tbl_Recepciones SET IdCliente = @IdCliente, IdSucursal = @IdSucursal, " +
                "FechaRecepcion = ISNULL(@FechaRecepcion, FechaRecepcion), " +
                "FechaEntregaEstimada = @FechaEntregaEstimada, Total = @Total, Observaciones = @Observaciones " +
                "WHERE IdRecepcion = @IdRecepcion;";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    AgregarParametros(cmd, recepcion);
                    cmd.Parameters.Add("@IdRecepcion", SqlDbType.Int).Value = recepcion.IdRecepcion;
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex) when (ex.Number == ErrorLlaveForanea)
            {
                throw new Exception("El cliente o la sucursal indicados no existen. Revise los códigos.", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo actualizar la recepción. " + ex.Message, ex);
            }
        }

        /// <summary>ELIMINAR: borra una recepción. Devuelve false si ya no existe.</summary>
        public bool Eliminar(int idRecepcion)
        {
            string sql = "DELETE FROM dbo.Tbl_Recepciones WHERE IdRecepcion = @IdRecepcion;";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@IdRecepcion", SqlDbType.Int).Value = idRecepcion;
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex) when (ex.Number == ErrorLlaveForanea)
            {
                // Detalle, procesos y entregas tienen llaves foráneas hacia Tbl_Recepciones.
                throw new Exception("No se puede eliminar la recepción porque tiene detalle, procesos " +
                                    "o entregas registradas.", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar la recepción. " + ex.Message, ex);
            }
        }

        /// <summary>Parámetros comunes de INSERT y UPDATE (tipo y tamaño iguales a la tabla).</summary>
        private static void AgregarParametros(SqlCommand cmd, Recepcion recepcion)
        {
            cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = recepcion.IdCliente;
            cmd.Parameters.Add("@IdSucursal", SqlDbType.Int).Value = recepcion.IdSucursal;

            // Una fecha vacía (null) se envía como NULL de SQL Server (DBNull.Value).
            cmd.Parameters.Add("@FechaRecepcion", SqlDbType.DateTime).Value =
                (object)recepcion.FechaRecepcion ?? DBNull.Value;
            cmd.Parameters.Add("@FechaEntregaEstimada", SqlDbType.DateTime).Value =
                (object)recepcion.FechaEntregaEstimada ?? DBNull.Value;

            SqlParameter total = cmd.Parameters.Add("@Total", SqlDbType.Decimal);
            total.Precision = 10;   // decimal(10,2), igual que la columna
            total.Scale = 2;
            total.Value = recepcion.Total;

            cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 500).Value =
                string.IsNullOrWhiteSpace(recepcion.Observaciones) ? (object)DBNull.Value : recepcion.Observaciones;
        }
    }
}
