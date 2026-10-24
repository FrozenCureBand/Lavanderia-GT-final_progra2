using System;
using System.Collections.Generic;
using System.Data;               // SqlDbType: tipo de cada parámetro
using System.Data.SqlClient;     // ADO.NET: SqlConnection, SqlCommand, SqlDataReader
using Entidad;

namespace Datos
{
    /// <summary>
    /// Acceso a datos de dbo.Tbl_Servicios: consultar, buscar, insertar, actualizar y eliminar.
    /// Integrado desde el proyecto LavanderiasMultinegocio y adaptado a la estructura de este proyecto.
    /// </summary>
    public class DServicio
    {
        // Número de error de SQL Server cuando una llave foránea impide la operación.
        private const int ErrorLlaveForanea = 547;

        /// <summary>CONSULTAR: todos los servicios.</summary>
        public List<Servicio> Consultar()
        {
            return ConsultarConFiltro(null);
        }

        /// <summary>BUSCAR: servicios cuyo nombre o descripción contienen el texto (sin distinguir mayúsculas ni tildes).</summary>
        public List<Servicio> Buscar(string texto)
        {
            return ConsultarConFiltro(texto);
        }

        /// <summary>Consulta los servicios. Si 'texto' es null trae todos; si no, agrega el filtro.</summary>
        private List<Servicio> ConsultarConFiltro(string texto)
        {
            List<Servicio> lista = new List<Servicio>();
            string sql = "SELECT IdServicio, Nombre, Descripcion, Estado FROM dbo.Tbl_Servicios ";
            if (texto != null)
            {
                sql += "WHERE Nombre COLLATE Latin1_General_CI_AI LIKE @Patron " +
                       "   OR Descripcion COLLATE Latin1_General_CI_AI LIKE @Patron ";
            }
            sql += "ORDER BY IdServicio;";

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
                            Servicio servicio = new Servicio();
                            servicio.IdServicio = Convert.ToInt32(dr["IdServicio"]);
                            servicio.Nombre = dr["Nombre"].ToString();
                            servicio.Descripcion = dr["Descripcion"].ToString();
                            servicio.Estado = dr["Estado"] != DBNull.Value && Convert.ToBoolean(dr["Estado"]);
                            lista.Add(servicio);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo consultar la lista de servicios. " + ex.Message, ex);
            }

            return lista;
        }

        /// <summary>INSERTAR: guarda un servicio nuevo y devuelve el IdServicio generado.</summary>
        public int Insertar(Servicio servicio)
        {
            string sql = "INSERT INTO dbo.Tbl_Servicios (Nombre, Descripcion, Estado) " +
                         "VALUES (@Nombre, @Descripcion, @Estado); " +
                         "SELECT CAST(SCOPE_IDENTITY() AS int);";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    AgregarParametros(cmd, servicio);
                    cn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo guardar el servicio. " + ex.Message, ex);
            }
        }

        /// <summary>ACTUALIZAR: modifica un servicio. Devuelve false si ya no existe.</summary>
        public bool Actualizar(Servicio servicio)
        {
            string sql = "UPDATE dbo.Tbl_Servicios SET Nombre = @Nombre, Descripcion = @Descripcion, Estado = @Estado " +
                         "WHERE IdServicio = @IdServicio;";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    AgregarParametros(cmd, servicio);
                    cmd.Parameters.Add("@IdServicio", SqlDbType.Int).Value = servicio.IdServicio;
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo actualizar el servicio. " + ex.Message, ex);
            }
        }

        /// <summary>ELIMINAR: borra un servicio. Devuelve false si ya no existe.</summary>
        public bool Eliminar(int idServicio)
        {
            string sql = "DELETE FROM dbo.Tbl_Servicios WHERE IdServicio = @IdServicio;";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@IdServicio", SqlDbType.Int).Value = idServicio;
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex) when (ex.Number == ErrorLlaveForanea)
            {
                // Tbl_Tarifas tiene una llave foránea hacia Tbl_Servicios.
                throw new Exception("No se puede eliminar el servicio porque tiene tarifas registradas. " +
                                    "Si ya no se ofrece, márquelo como Inactivo y guarde con Editar.", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el servicio. " + ex.Message, ex);
            }
        }

        /// <summary>Parámetros comunes de INSERT y UPDATE.</summary>
        private static void AgregarParametros(SqlCommand cmd, Servicio servicio)
        {
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = servicio.Nombre;
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value =
                string.IsNullOrWhiteSpace(servicio.Descripcion) ? (object)DBNull.Value : servicio.Descripcion;
            cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = servicio.Estado;
        }
    }
}
