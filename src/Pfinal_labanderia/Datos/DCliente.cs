using System;
using System.Collections.Generic;
using System.Data;               // SqlDbType: tipo de cada parámetro
using System.Data.SqlClient;     // ADO.NET: SqlConnection, SqlCommand, SqlDataReader
using Entidad;

namespace Datos
{
    /// <summary>
    /// Acceso a datos de dbo.Tbl_Clientes: consultar, insertar, actualizar y eliminar.
    /// Aquí solo va el SQL; las validaciones están en la capa Negocio.
    /// Los valores escritos por el usuario viajan como PARÁMETROS (@Nombre) para evitar inyección SQL.
    /// </summary>
    public class DCliente
    {
        // Número de error de SQL Server cuando una llave foránea impide la operación.
        private const int ErrorLlaveForanea = 547;

        /// <summary>CONSULTAR: devuelve todos los clientes ordenados por código.</summary>
        public List<Cliente> Consultar()
        {
            return ConsultarConFiltro(null);
        }

        /// <summary>
        /// BUSCAR: devuelve los clientes cuyo nombre o teléfono contienen el texto
        /// (sin distinguir mayúsculas ni tildes).
        /// </summary>
        public List<Cliente> Buscar(string texto)
        {
            return ConsultarConFiltro(texto);
        }

        /// <summary>
        /// Consulta los clientes. Si 'texto' es null trae todos; si no, agrega el filtro de búsqueda.
        /// El texto viaja como PARÁMETRO (@Patron), nunca pegado dentro del SQL.
        /// </summary>
        private List<Cliente> ConsultarConFiltro(string texto)
        {
            List<Cliente> lista = new List<Cliente>();
            string sql = "SELECT IdCliente, NombreCompleto, Telefono, Correo, Direccion, FechaRegistro, Estado " +
                         "FROM dbo.Tbl_Clientes ";
            if (texto != null)
            {
                // COLLATE ..._CI_AI: no distingue mayúsculas (CI) ni tildes (AI): "mendez" encuentra "Méndez".
                sql += "WHERE NombreCompleto COLLATE Latin1_General_CI_AI LIKE @Patron " +
                       "   OR Telefono COLLATE Latin1_General_CI_AI LIKE @Patron ";
            }
            sql += "ORDER BY IdCliente;";

            try
            {
                // using cierra la conexión, el comando y el lector aunque ocurra un error.
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
                            lista.Add(LeerCliente(dr));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo consultar la lista de clientes. " + ex.Message, ex);
            }

            return lista;
        }

        /// <summary>INSERTAR: guarda un cliente nuevo y devuelve el IdCliente que generó SQL Server.</summary>
        public int Insertar(Cliente cliente)
        {
            // SCOPE_IDENTITY() devuelve el código recién creado en esta misma operación.
            string sql = "INSERT INTO dbo.Tbl_Clientes (NombreCompleto, Telefono, Correo, Direccion, FechaRegistro, Estado) " +
                         "VALUES (@NombreCompleto, @Telefono, @Correo, @Direccion, @FechaRegistro, @Estado); " +
                         "SELECT CAST(SCOPE_IDENTITY() AS int);";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    AgregarParametros(cmd, cliente);
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = cliente.FechaRegistro ?? DateTime.Now;
                    cn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo guardar el cliente. " + ex.Message, ex);
            }
        }

        /// <summary>ACTUALIZAR: modifica un cliente. Devuelve false si el cliente ya no existe.</summary>
        public bool Actualizar(Cliente cliente)
        {
            // FechaRegistro no se modifica: es la fecha en que se registró el cliente.
            string sql = "UPDATE dbo.Tbl_Clientes SET NombreCompleto = @NombreCompleto, Telefono = @Telefono, " +
                         "Correo = @Correo, Direccion = @Direccion, Estado = @Estado " +
                         "WHERE IdCliente = @IdCliente;";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    AgregarParametros(cmd, cliente);
                    cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = cliente.IdCliente;
                    cn.Open();

                    // ExecuteNonQuery devuelve cuántas filas cambiaron.
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo actualizar el cliente. " + ex.Message, ex);
            }
        }

        /// <summary>ELIMINAR: borra un cliente. Devuelve false si el cliente ya no existe.</summary>
        public bool Eliminar(int idCliente)
        {
            string sql = "DELETE FROM dbo.Tbl_Clientes WHERE IdCliente = @IdCliente;";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex) when (ex.Number == ErrorLlaveForanea)
            {
                // Tbl_Recepciones tiene una llave foránea hacia Tbl_Clientes.
                throw new Exception("No se puede eliminar el cliente porque tiene recepciones registradas. " +
                                    "Si ya no se atiende, márquelo como Inactivo y guarde con Editar.", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el cliente. " + ex.Message, ex);
            }
        }

        /// <summary>Parámetros comunes de INSERT y UPDATE (tipo y tamaño iguales a la tabla).</summary>
        private static void AgregarParametros(SqlCommand cmd, Cliente cliente)
        {
            cmd.Parameters.Add("@NombreCompleto", SqlDbType.VarChar, 150).Value = cliente.NombreCompleto;
            cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 20).Value = TextoONulo(cliente.Telefono);
            cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = TextoONulo(cliente.Correo);
            cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = TextoONulo(cliente.Direccion);
            cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = cliente.Estado;
        }

        /// <summary>Si el texto viene vacío se guarda NULL (la columna lo permite).</summary>
        private static object TextoONulo(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return DBNull.Value;
            }
            return texto;
        }

        /// <summary>Convierte la fila actual del lector en un objeto Cliente.</summary>
        private static Cliente LeerCliente(SqlDataReader dr)
        {
            Cliente cliente = new Cliente();
            cliente.IdCliente = Convert.ToInt32(dr["IdCliente"]);

            // Si la columna es NULL, ToString() devuelve "" (texto vacío).
            cliente.NombreCompleto = dr["NombreCompleto"].ToString();
            cliente.Telefono = dr["Telefono"].ToString();
            cliente.Correo = dr["Correo"].ToString();
            cliente.Direccion = dr["Direccion"].ToString();

            // Las columnas que permiten NULL se revisan antes de convertir.
            if (dr["FechaRegistro"] != DBNull.Value)
            {
                cliente.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
            }
            cliente.Estado = dr["Estado"] != DBNull.Value && Convert.ToBoolean(dr["Estado"]);

            return cliente;
        }
    }
}
