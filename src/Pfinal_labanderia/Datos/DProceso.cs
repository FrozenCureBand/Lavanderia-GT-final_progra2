using System;
using System.Collections.Generic;
using System.Data;               // SqlDbType: tipo de cada parámetro
using System.Data.SqlClient;     // ADO.NET: SqlConnection, SqlCommand, SqlDataReader
using Entidad;

namespace Datos
{
    /// <summary>
    /// Acceso a datos de dbo.Tbl_Procesos: consultar, buscar, insertar, actualizar y eliminar.
    /// Integrado desde el proyecto LavanderiasMultinegocio y adaptado a la estructura de este proyecto.
    /// </summary>
    public class DProceso
    {
        // Número de error de SQL Server cuando una llave foránea impide la operación.
        private const int ErrorLlaveForanea = 547;

        /// <summary>CONSULTAR: todos los procesos con el cliente de la recepción y el nombre del estado.</summary>
        public List<Proceso> Consultar()
        {
            return ConsultarConFiltro(null);
        }

        /// <summary>BUSCAR: procesos cuyo cliente o estado contienen el texto (sin distinguir mayúsculas ni tildes).</summary>
        public List<Proceso> Buscar(string texto)
        {
            return ConsultarConFiltro(texto);
        }

        /// <summary>Consulta los procesos. Si 'texto' es null trae todos; si no, agrega el filtro de búsqueda.</summary>
        private List<Proceso> ConsultarConFiltro(string texto)
        {
            List<Proceso> lista = new List<Proceso>();

            // JOIN: proceso -> recepción -> cliente, y proceso -> estado, para mostrar nombres.
            string sql =
                "SELECT p.IdProceso, p.IdRecepcion, c.NombreCompleto AS NombreCliente, p.IdEstadoProceso, " +
                "       e.Nombre AS NombreEstado, p.FechaInicio, p.FechaFin, p.Observaciones " +
                "FROM dbo.Tbl_Procesos p " +
                "JOIN dbo.Tbl_Recepciones r ON r.IdRecepcion = p.IdRecepcion " +
                "JOIN dbo.Tbl_Clientes c ON c.IdCliente = r.IdCliente " +
                "JOIN dbo.Tbl_EstadosProceso e ON e.IdEstadoProceso = p.IdEstadoProceso ";
            if (texto != null)
            {
                sql += "WHERE c.NombreCompleto COLLATE Latin1_General_CI_AI LIKE @Patron " +
                       "   OR e.Nombre COLLATE Latin1_General_CI_AI LIKE @Patron ";
            }
            sql += "ORDER BY p.IdProceso;";

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
                            Proceso proceso = new Proceso();
                            proceso.IdProceso = Convert.ToInt32(dr["IdProceso"]);
                            proceso.IdRecepcion = Convert.ToInt32(dr["IdRecepcion"]);
                            proceso.NombreCliente = dr["NombreCliente"].ToString();
                            proceso.IdEstadoProceso = Convert.ToInt32(dr["IdEstadoProceso"]);
                            proceso.NombreEstado = dr["NombreEstado"].ToString();
                            if (dr["FechaInicio"] != DBNull.Value)
                            {
                                proceso.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]);
                            }
                            if (dr["FechaFin"] != DBNull.Value)
                            {
                                proceso.FechaFin = Convert.ToDateTime(dr["FechaFin"]);
                            }
                            proceso.Observaciones = dr["Observaciones"].ToString();
                            lista.Add(proceso);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo consultar la lista de procesos. " + ex.Message, ex);
            }

            return lista;
        }

        /// <summary>Estados de proceso activos para la lista desplegable (Recibido, Lavando, ...).</summary>
        public List<OpcionLista> ListarEstados()
        {
            List<OpcionLista> lista = new List<OpcionLista>();
            string sql = "SELECT IdEstadoProceso, Nombre FROM dbo.Tbl_EstadosProceso " +
                         "WHERE Estado = 1 ORDER BY IdEstadoProceso;";

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
                            lista.Add(new OpcionLista(Convert.ToInt32(dr["IdEstadoProceso"]), dr["Nombre"].ToString()));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo consultar la lista de estados de proceso. " + ex.Message, ex);
            }

            return lista;
        }

        /// <summary>INSERTAR: guarda un proceso nuevo y devuelve el IdProceso generado.</summary>
        public int Insertar(Proceso proceso)
        {
            string sql =
                "INSERT INTO dbo.Tbl_Procesos (IdRecepcion, IdEstadoProceso, FechaInicio, FechaFin, Observaciones) " +
                "VALUES (@IdRecepcion, @IdEstadoProceso, @FechaInicio, @FechaFin, @Observaciones); " +
                "SELECT CAST(SCOPE_IDENTITY() AS int);";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    AgregarParametros(cmd, proceso);
                    cn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex) when (ex.Number == ErrorLlaveForanea)
            {
                throw new Exception("La recepción o el estado indicados no existen.", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo guardar el proceso. " + ex.Message, ex);
            }
        }

        /// <summary>ACTUALIZAR: modifica un proceso. Devuelve false si ya no existe.</summary>
        public bool Actualizar(Proceso proceso)
        {
            string sql =
                "UPDATE dbo.Tbl_Procesos SET IdRecepcion = @IdRecepcion, IdEstadoProceso = @IdEstadoProceso, " +
                "FechaInicio = @FechaInicio, FechaFin = @FechaFin, Observaciones = @Observaciones " +
                "WHERE IdProceso = @IdProceso;";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    AgregarParametros(cmd, proceso);
                    cmd.Parameters.Add("@IdProceso", SqlDbType.Int).Value = proceso.IdProceso;
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex) when (ex.Number == ErrorLlaveForanea)
            {
                throw new Exception("La recepción o el estado indicados no existen.", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo actualizar el proceso. " + ex.Message, ex);
            }
        }

        /// <summary>ELIMINAR: borra un proceso. Devuelve false si ya no existe.</summary>
        public bool Eliminar(int idProceso)
        {
            string sql = "DELETE FROM dbo.Tbl_Procesos WHERE IdProceso = @IdProceso;";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@IdProceso", SqlDbType.Int).Value = idProceso;
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el proceso. " + ex.Message, ex);
            }
        }

        /// <summary>Parámetros comunes de INSERT y UPDATE. Las fechas vacías (null) se guardan como NULL.</summary>
        private static void AgregarParametros(SqlCommand cmd, Proceso proceso)
        {
            cmd.Parameters.Add("@IdRecepcion", SqlDbType.Int).Value = proceso.IdRecepcion;
            cmd.Parameters.Add("@IdEstadoProceso", SqlDbType.Int).Value = proceso.IdEstadoProceso;
            cmd.Parameters.Add("@FechaInicio", SqlDbType.DateTime).Value = (object)proceso.FechaInicio ?? DBNull.Value;
            cmd.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = (object)proceso.FechaFin ?? DBNull.Value;
            cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value =
                string.IsNullOrWhiteSpace(proceso.Observaciones) ? (object)DBNull.Value : proceso.Observaciones;
        }
    }
}
