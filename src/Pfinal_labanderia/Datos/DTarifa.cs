using System;
using System.Collections.Generic;
using System.Data;               // SqlDbType: tipo de cada parámetro
using System.Data.SqlClient;     // ADO.NET: SqlConnection, SqlCommand, SqlDataReader
using Entidad;

namespace Datos
{
    /// <summary>
    /// Acceso a datos de dbo.Tbl_Tarifas: consultar, insertar, actualizar y eliminar.
    /// Los valores escritos por el usuario viajan como PARÁMETROS para evitar inyección SQL.
    /// </summary>
    public class DTarifa
    {
        // Número de error de SQL Server cuando una llave foránea impide la operación.
        private const int ErrorLlaveForanea = 547;

        /// <summary>
        /// CONSULTAR: devuelve todas las tarifas con el nombre del tipo de prenda y del servicio.
        /// No recibe valores del usuario, por eso no lleva parámetros.
        /// </summary>
        public List<Tarifa> Consultar()
        {
            return ConsultarConFiltro(null);
        }

        /// <summary>
        /// BUSCAR: tarifas cuyo tipo de prenda o servicio contienen el texto (sin distinguir mayúsculas ni tildes).
        /// </summary>
        public List<Tarifa> Buscar(string texto)
        {
            return ConsultarConFiltro(texto);
        }

        /// <summary>
        /// Consulta las tarifas. Si 'texto' es null trae todas; si no, agrega el filtro de búsqueda.
        /// El texto viaja como PARÁMETRO (@Patron), nunca pegado dentro del SQL.
        /// </summary>
        private List<Tarifa> ConsultarConFiltro(string texto)
        {
            List<Tarifa> lista = new List<Tarifa>();

            // JOIN: une cada tarifa con su tipo de prenda y su servicio para obtener sus nombres.
            string sql =
                "SELECT t.IdTarifa, t.IdTipoPrenda, tp.Nombre AS NombreTipoPrenda, " +
                "       t.IdServicio, sv.Nombre AS NombreServicio, t.Precio, t.FechaInicio, t.Estado " +
                "FROM dbo.Tbl_Tarifas t " +
                "JOIN dbo.Tbl_TiposPrenda tp ON tp.IdTipoPrenda = t.IdTipoPrenda " +
                "JOIN dbo.Tbl_Servicios sv ON sv.IdServicio = t.IdServicio ";
            if (texto != null)
            {
                // COLLATE ..._CI_AI: no distingue mayúsculas (CI) ni tildes (AI).
                sql += "WHERE tp.Nombre COLLATE Latin1_General_CI_AI LIKE @Patron " +
                       "   OR sv.Nombre COLLATE Latin1_General_CI_AI LIKE @Patron ";
            }
            sql += "ORDER BY t.IdTarifa;";

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
                            Tarifa tarifa = new Tarifa();
                            tarifa.IdTarifa = Convert.ToInt32(dr["IdTarifa"]);
                            tarifa.IdTipoPrenda = Convert.ToInt32(dr["IdTipoPrenda"]);
                            tarifa.NombreTipoPrenda = dr["NombreTipoPrenda"].ToString();
                            tarifa.IdServicio = Convert.ToInt32(dr["IdServicio"]);
                            tarifa.NombreServicio = dr["NombreServicio"].ToString();
                            tarifa.Precio = Convert.ToDecimal(dr["Precio"]);

                            // Las columnas que permiten NULL se revisan antes de convertir.
                            if (dr["FechaInicio"] != DBNull.Value)
                            {
                                tarifa.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]);
                            }
                            tarifa.Estado = dr["Estado"] != DBNull.Value && Convert.ToBoolean(dr["Estado"]);
                            lista.Add(tarifa);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo consultar la lista de tarifas. " + ex.Message, ex);
            }

            return lista;
        }

        /// <summary>INSERTAR: guarda una tarifa nueva y devuelve el IdTarifa generado.</summary>
        public int Insertar(Tarifa tarifa)
        {
            string sql =
                "INSERT INTO dbo.Tbl_Tarifas (IdTipoPrenda, IdServicio, Precio, FechaInicio, Estado) " +
                "VALUES (@IdTipoPrenda, @IdServicio, @Precio, @FechaInicio, @Estado); " +
                "SELECT CAST(SCOPE_IDENTITY() AS int);";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    AgregarParametros(cmd, tarifa);
                    cn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex) when (ex.Number == ErrorLlaveForanea)
            {
                throw new Exception("El tipo de prenda o el servicio indicados no existen. Revise los códigos.", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo guardar la tarifa. " + ex.Message, ex);
            }
        }

        /// <summary>ACTUALIZAR: modifica una tarifa. Devuelve false si la tarifa ya no existe.</summary>
        public bool Actualizar(Tarifa tarifa)
        {
            // ISNULL: si no se escribió la fecha de inicio, se conserva la que ya tenía.
            string sql =
                "UPDATE dbo.Tbl_Tarifas SET IdTipoPrenda = @IdTipoPrenda, IdServicio = @IdServicio, " +
                "Precio = @Precio, FechaInicio = ISNULL(@FechaInicio, FechaInicio), Estado = @Estado " +
                "WHERE IdTarifa = @IdTarifa;";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    AgregarParametros(cmd, tarifa);
                    cmd.Parameters.Add("@IdTarifa", SqlDbType.Int).Value = tarifa.IdTarifa;
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex) when (ex.Number == ErrorLlaveForanea)
            {
                throw new Exception("El tipo de prenda o el servicio indicados no existen. Revise los códigos.", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo actualizar la tarifa. " + ex.Message, ex);
            }
        }

        /// <summary>ELIMINAR: borra una tarifa. Devuelve false si ya no existe.</summary>
        public bool Eliminar(int idTarifa)
        {
            string sql = "DELETE FROM dbo.Tbl_Tarifas WHERE IdTarifa = @IdTarifa;";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@IdTarifa", SqlDbType.Int).Value = idTarifa;
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex) when (ex.Number == ErrorLlaveForanea)
            {
                // Tbl_DetalleRecepciones tiene una llave foránea hacia Tbl_Tarifas.
                throw new Exception("No se puede eliminar la tarifa porque se usa en el detalle de recepciones. " +
                                    "Si ya no se aplica, márquela como Inactiva y guarde con Editar.", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar la tarifa. " + ex.Message, ex);
            }
        }

        /// <summary>Parámetros comunes de INSERT y UPDATE (tipo y tamaño iguales a la tabla).</summary>
        private static void AgregarParametros(SqlCommand cmd, Tarifa tarifa)
        {
            cmd.Parameters.Add("@IdTipoPrenda", SqlDbType.Int).Value = tarifa.IdTipoPrenda;
            cmd.Parameters.Add("@IdServicio", SqlDbType.Int).Value = tarifa.IdServicio;

            SqlParameter precio = cmd.Parameters.Add("@Precio", SqlDbType.Decimal);
            precio.Precision = 10;   // decimal(10,2), igual que la columna
            precio.Scale = 2;
            precio.Value = tarifa.Precio;

            // La columna FechaInicio es de tipo date (sin hora). null se envía como NULL.
            cmd.Parameters.Add("@FechaInicio", SqlDbType.Date).Value =
                tarifa.FechaInicio.HasValue ? (object)tarifa.FechaInicio.Value.Date : DBNull.Value;
            cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = tarifa.Estado;
        }
    }
}
