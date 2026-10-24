using System;
using System.Collections.Generic;
using System.Data;               // SqlDbType: tipo de cada parámetro
using System.Data.SqlClient;     // ADO.NET: SqlConnection, SqlCommand, SqlDataReader
using Entidad;

namespace Datos
{
    /// <summary>
    /// Acceso a datos de dbo.Tbl_TiposPrenda: consultar, buscar, insertar, actualizar y eliminar.
    /// Integrado desde el proyecto LavanderiasMultinegocio ("Prendas") y adaptado a la estructura de este proyecto.
    /// </summary>
    public class DTipoPrenda
    {
        // Número de error de SQL Server cuando una llave foránea impide la operación.
        private const int ErrorLlaveForanea = 547;

        /// <summary>CONSULTAR: todos los tipos de prenda.</summary>
        public List<TipoPrenda> Consultar()
        {
            return ConsultarConFiltro(null);
        }

        /// <summary>BUSCAR: tipos de prenda cuyo nombre o descripción contienen el texto (sin distinguir mayúsculas ni tildes).</summary>
        public List<TipoPrenda> Buscar(string texto)
        {
            return ConsultarConFiltro(texto);
        }

        /// <summary>Consulta los tipos de prenda. Si 'texto' es null trae todos; si no, agrega el filtro.</summary>
        private List<TipoPrenda> ConsultarConFiltro(string texto)
        {
            List<TipoPrenda> lista = new List<TipoPrenda>();
            string sql = "SELECT IdTipoPrenda, Nombre, Descripcion, Estado FROM dbo.Tbl_TiposPrenda ";
            if (texto != null)
            {
                sql += "WHERE Nombre COLLATE Latin1_General_CI_AI LIKE @Patron " +
                       "   OR Descripcion COLLATE Latin1_General_CI_AI LIKE @Patron ";
            }
            sql += "ORDER BY IdTipoPrenda;";

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
                            TipoPrenda prenda = new TipoPrenda();
                            prenda.IdTipoPrenda = Convert.ToInt32(dr["IdTipoPrenda"]);
                            prenda.Nombre = dr["Nombre"].ToString();
                            prenda.Descripcion = dr["Descripcion"].ToString();
                            prenda.Estado = dr["Estado"] != DBNull.Value && Convert.ToBoolean(dr["Estado"]);
                            lista.Add(prenda);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo consultar la lista de tipos de prenda. " + ex.Message, ex);
            }

            return lista;
        }

        /// <summary>INSERTAR: guarda un tipo de prenda nuevo y devuelve el IdTipoPrenda generado.</summary>
        public int Insertar(TipoPrenda prenda)
        {
            string sql = "INSERT INTO dbo.Tbl_TiposPrenda (Nombre, Descripcion, Estado) " +
                         "VALUES (@Nombre, @Descripcion, @Estado); " +
                         "SELECT CAST(SCOPE_IDENTITY() AS int);";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    AgregarParametros(cmd, prenda);
                    cn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo guardar el tipo de prenda. " + ex.Message, ex);
            }
        }

        /// <summary>ACTUALIZAR: modifica un tipo de prenda. Devuelve false si ya no existe.</summary>
        public bool Actualizar(TipoPrenda prenda)
        {
            string sql = "UPDATE dbo.Tbl_TiposPrenda SET Nombre = @Nombre, Descripcion = @Descripcion, Estado = @Estado " +
                         "WHERE IdTipoPrenda = @IdTipoPrenda;";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    AgregarParametros(cmd, prenda);
                    cmd.Parameters.Add("@IdTipoPrenda", SqlDbType.Int).Value = prenda.IdTipoPrenda;
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo actualizar el tipo de prenda. " + ex.Message, ex);
            }
        }

        /// <summary>ELIMINAR: borra un tipo de prenda. Devuelve false si ya no existe.</summary>
        public bool Eliminar(int idTipoPrenda)
        {
            string sql = "DELETE FROM dbo.Tbl_TiposPrenda WHERE IdTipoPrenda = @IdTipoPrenda;";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@IdTipoPrenda", SqlDbType.Int).Value = idTipoPrenda;
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex) when (ex.Number == ErrorLlaveForanea)
            {
                // Tbl_Tarifas tiene una llave foránea hacia Tbl_TiposPrenda.
                throw new Exception("No se puede eliminar el tipo de prenda porque tiene tarifas registradas. " +
                                    "Si ya no se usa, márquelo como Inactivo y guarde con Editar.", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el tipo de prenda. " + ex.Message, ex);
            }
        }

        /// <summary>Parámetros comunes de INSERT y UPDATE.</summary>
        private static void AgregarParametros(SqlCommand cmd, TipoPrenda prenda)
        {
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = prenda.Nombre;
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value =
                string.IsNullOrWhiteSpace(prenda.Descripcion) ? (object)DBNull.Value : prenda.Descripcion;
            cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = prenda.Estado;
        }
    }
}
