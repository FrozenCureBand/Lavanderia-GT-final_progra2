using System;
using System.Collections.Generic;
using System.Data;               // SqlDbType: tipo de cada parámetro
using System.Data.SqlClient;     // ADO.NET: SqlConnection, SqlCommand, SqlDataReader
using Entidad;

namespace Datos
{
    /// <summary>
    /// Consultas de SOLO LECTURA para la pantalla de Inicio (dashboard).
    /// Usan COUNT, SUM y GROUP BY. Las fechas son datos de entrada,
    /// por eso viajan como parámetros (@Inicio, @Fin).
    /// </summary>
    public class DInicio
    {
        /// <summary>
        /// Cuenta los clientes que tienen Estado activo (1).
        /// COUNT devuelve un único número, que se lee con ExecuteScalar.
        /// </summary>
        public int ObtenerClientesActivos()
        {
            string sql = "SELECT COUNT(*) FROM dbo.Tbl_Clientes WHERE Estado = 1;";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudieron consultar los clientes activos. " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Indicadores de las tarjetas. El periodo va desde 'inicio' (incluido) hasta 'fin' (excluido).
        /// </summary>
        public ResumenInicio ObtenerResumen(DateTime inicio, DateTime fin)
        {
            // Cada subconsulta devuelve un solo número: así se obtienen los 5 indicadores en una consulta.
            string sql =
                "SELECT " +
                " (SELECT COUNT(*) FROM dbo.Tbl_Sucursales WHERE Estado = 1) AS SucursalesActivas, " +
                " (SELECT COUNT(*) FROM dbo.Tbl_Recepciones " +
                "    WHERE FechaRecepcion >= @Inicio AND FechaRecepcion < @Fin) AS RecepcionesMes, " +
                " (SELECT ISNULL(SUM(Total), 0) FROM dbo.Tbl_Recepciones " +
                "    WHERE FechaRecepcion >= @Inicio AND FechaRecepcion < @Fin) AS IngresosMes, " +
                " (SELECT COUNT(*) FROM dbo.Tbl_Entregas " +
                "    WHERE FechaEntrega >= @Inicio AND FechaEntrega < @Fin) AS EntregasMes;";

            ResumenInicio resumen = new ResumenInicio();
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@Inicio", SqlDbType.DateTime).Value = inicio;
                    cmd.Parameters.Add("@Fin", SqlDbType.DateTime).Value = fin;
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            resumen.SucursalesActivas = Convert.ToInt32(dr["SucursalesActivas"]);
                            resumen.RecepcionesMes = Convert.ToInt32(dr["RecepcionesMes"]);
                            resumen.IngresosMes = Convert.ToDecimal(dr["IngresosMes"]);
                            resumen.EntregasMes = Convert.ToInt32(dr["EntregasMes"]);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudieron consultar los indicadores de Inicio. " + ex.Message, ex);
            }

            return resumen;
        }

        /// <summary>
        /// Suma del Total de las recepciones de cada sucursal activa en el periodo.
        /// </summary>
        public List<DatoGrafica> IngresosPorSucursal(DateTime inicio, DateTime fin)
        {
            // LEFT JOIN: aparecen todas las sucursales activas, aunque no tengan recepciones (valor 0).
            string sql =
                "SELECT s.Nombre AS Etiqueta, ISNULL(SUM(r.Total), 0) AS Valor " +
                "FROM dbo.Tbl_Sucursales s " +
                "LEFT JOIN dbo.Tbl_Recepciones r ON r.IdSucursal = s.IdSucursal " +
                "  AND r.FechaRecepcion >= @Inicio AND r.FechaRecepcion < @Fin " +
                "WHERE s.Estado = 1 " +
                "GROUP BY s.Nombre " +
                "ORDER BY Valor DESC;";
            return ConsultarGrafica(sql, inicio, fin, "los ingresos por sucursal");
        }

        /// <summary>
        /// Cantidad de recepciones por mes en el periodo. La etiqueta tiene el formato AAAA-MM (ej. 2026-10).
        /// Solo devuelve los meses que tienen recepciones; la capa Negocio completa los demás con 0.
        /// </summary>
        public List<DatoGrafica> RecepcionesPorMes(DateTime inicio, DateTime fin)
        {
            // CONVERT(char(7), fecha, 120) convierte la fecha a 'AAAA-MM'.
            string sql =
                "SELECT CONVERT(char(7), FechaRecepcion, 120) AS Etiqueta, COUNT(*) AS Valor " +
                "FROM dbo.Tbl_Recepciones " +
                "WHERE FechaRecepcion >= @Inicio AND FechaRecepcion < @Fin " +
                "GROUP BY CONVERT(char(7), FechaRecepcion, 120) " +
                "ORDER BY Etiqueta;";
            return ConsultarGrafica(sql, inicio, fin, "las recepciones por mes");
        }

        /// <summary>
        /// Cantidad de recepciones según su estado de proceso ACTUAL (Recibido, Lavando, ...).
        /// </summary>
        public List<DatoGrafica> RecepcionesPorEstadoProceso()
        {
            // Una recepción puede tener varios procesos (su historial):
            // la subconsulta "Ultimo" toma el proceso más reciente de cada recepción.
            string sql =
                "WITH Ultimo AS (" +
                "  SELECT IdRecepcion, MAX(IdProceso) AS IdProceso FROM dbo.Tbl_Procesos GROUP BY IdRecepcion) " +
                "SELECT e.Nombre AS Etiqueta, COUNT(p.IdProceso) AS Valor " +
                "FROM dbo.Tbl_EstadosProceso e " +
                "LEFT JOIN dbo.Tbl_Procesos p ON p.IdEstadoProceso = e.IdEstadoProceso " +
                "  AND p.IdProceso IN (SELECT IdProceso FROM Ultimo) " +
                "WHERE e.Estado = 1 " +
                "GROUP BY e.IdEstadoProceso, e.Nombre " +
                "ORDER BY e.IdEstadoProceso;";
            return ConsultarGrafica(sql, null, null, "el estado de las recepciones");
        }

        /// <summary>
        /// Los 5 servicios con más prendas registradas (Detalle -> Tarifa -> Servicio).
        /// </summary>
        public List<DatoGrafica> ServiciosMasSolicitados()
        {
            string sql =
                "SELECT TOP 5 sv.Nombre AS Etiqueta, ISNULL(SUM(d.Cantidad), 0) AS Valor " +
                "FROM dbo.Tbl_DetalleRecepciones d " +
                "JOIN dbo.Tbl_Tarifas t ON t.IdTarifa = d.IdTarifa " +
                "JOIN dbo.Tbl_Servicios sv ON sv.IdServicio = t.IdServicio " +
                "GROUP BY sv.Nombre " +
                "ORDER BY Valor DESC;";
            return ConsultarGrafica(sql, null, null, "los servicios más solicitados");
        }

        /// <summary>
        /// Ejecuta una consulta que devuelve las columnas Etiqueta y Valor y la convierte en una lista.
        /// Si la consulta usa @Inicio y @Fin, se envían como parámetros (null = la consulta no los usa).
        /// </summary>
        private List<DatoGrafica> ConsultarGrafica(string sql, DateTime? inicio, DateTime? fin, string descripcion)
        {
            List<DatoGrafica> lista = new List<DatoGrafica>();
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    if (inicio.HasValue)
                    {
                        cmd.Parameters.Add("@Inicio", SqlDbType.DateTime).Value = inicio.Value;
                    }
                    if (fin.HasValue)
                    {
                        cmd.Parameters.Add("@Fin", SqlDbType.DateTime).Value = fin.Value;
                    }
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DatoGrafica(dr["Etiqueta"].ToString(), Convert.ToDecimal(dr["Valor"])));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudieron consultar " + descripcion + ". " + ex.Message, ex);
            }

            return lista;
        }
    }
}
