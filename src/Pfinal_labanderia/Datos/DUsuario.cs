using System;
using System.Collections.Generic;
using System.Data;               // SqlDbType: tipo de cada parámetro
using System.Data.SqlClient;     // ADO.NET: SqlConnection, SqlCommand, SqlDataReader
using Entidad;

namespace Datos
{
    /// <summary>
    /// Acceso a datos de dbo.Tbl_Usuarios: consultar, insertar, actualizar y eliminar.
    /// La clave llega YA CIFRADA desde la capa Negocio; aquí nunca se lee ni se muestra.
    /// Los valores escritos por el usuario viajan como PARÁMETROS para evitar inyección SQL.
    /// </summary>
    public class DUsuario
    {
        // Número de error de SQL Server cuando una llave foránea impide la operación.
        private const int ErrorLlaveForanea = 547;

        /// <summary>
        /// CONSULTAR: devuelve todos los usuarios con el nombre de su sucursal.
        /// La columna Clave (contraseña) NO se selecciona: nunca debe mostrarse en pantalla.
        /// </summary>
        public List<Usuario> Consultar()
        {
            return ConsultarConFiltro(null);
        }

        /// <summary>
        /// BUSCAR: usuarios cuyo nombre de usuario o nombre completo contienen el texto
        /// (sin distinguir mayúsculas ni tildes). Tampoco aquí se lee la clave.
        /// </summary>
        public List<Usuario> Buscar(string texto)
        {
            return ConsultarConFiltro(texto);
        }

        /// <summary>
        /// Consulta los usuarios. Si 'texto' es null trae todos; si no, agrega el filtro de búsqueda.
        /// El texto viaja como PARÁMETRO (@Patron), nunca pegado dentro del SQL.
        /// </summary>
        private List<Usuario> ConsultarConFiltro(string texto)
        {
            List<Usuario> lista = new List<Usuario>();

            string sql =
                "SELECT u.IdUsuario, u.NombreUsuario, u.NombreCompleto, u.Correo, " +
                "       u.IdSucursal, s.Nombre AS NombreSucursal, u.Estado " +
                "FROM dbo.Tbl_Usuarios u " +
                "JOIN dbo.Tbl_Sucursales s ON s.IdSucursal = u.IdSucursal ";
            if (texto != null)
            {
                // COLLATE ..._CI_AI: no distingue mayúsculas (CI) ni tildes (AI).
                sql += "WHERE u.NombreUsuario COLLATE Latin1_General_CI_AI LIKE @Patron " +
                       "   OR u.NombreCompleto COLLATE Latin1_General_CI_AI LIKE @Patron ";
            }
            sql += "ORDER BY u.IdUsuario;";

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
                            Usuario usuario = new Usuario();
                            usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                            usuario.NombreUsuario = dr["NombreUsuario"].ToString();
                            usuario.NombreCompleto = dr["NombreCompleto"].ToString();
                            usuario.Correo = dr["Correo"].ToString();     // NULL -> ""
                            usuario.IdSucursal = Convert.ToInt32(dr["IdSucursal"]);
                            usuario.NombreSucursal = dr["NombreSucursal"].ToString();
                            usuario.Estado = dr["Estado"] != DBNull.Value && Convert.ToBoolean(dr["Estado"]);
                            lista.Add(usuario);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo consultar la lista de usuarios. " + ex.Message, ex);
            }

            return lista;
        }

        /// <summary>
        /// Indica si ya existe OTRO usuario con ese nombre de usuario.
        /// 'idExcluir' es el usuario que se está editando (0 cuando es un usuario nuevo).
        /// </summary>
        public bool ExisteNombreUsuario(string nombreUsuario, int idExcluir)
        {
            string sql = "SELECT COUNT(*) FROM dbo.Tbl_Usuarios " +
                         "WHERE NombreUsuario = @NombreUsuario AND IdUsuario <> @IdUsuario;";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@NombreUsuario", SqlDbType.VarChar, 100).Value = nombreUsuario;
                    cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idExcluir;
                    cn.Open();
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo revisar el nombre de usuario. " + ex.Message, ex);
            }
        }

        /// <summary>INSERTAR: guarda un usuario nuevo con su clave cifrada y devuelve el IdUsuario generado.</summary>
        public int Insertar(Usuario usuario, string claveCifrada)
        {
            string sql =
                "INSERT INTO dbo.Tbl_Usuarios (IdSucursal, NombreUsuario, Clave, NombreCompleto, Correo, Estado) " +
                "VALUES (@IdSucursal, @NombreUsuario, @Clave, @NombreCompleto, @Correo, @Estado); " +
                "SELECT CAST(SCOPE_IDENTITY() AS int);";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    AgregarParametros(cmd, usuario);
                    cmd.Parameters.Add("@Clave", SqlDbType.VarChar, 255).Value = claveCifrada;
                    cn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex) when (ex.Number == ErrorLlaveForanea)
            {
                throw new Exception("La sucursal indicada no existe. Revise el código.", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo guardar el usuario. " + ex.Message, ex);
            }
        }

        /// <summary>
        /// ACTUALIZAR: modifica un usuario. Si 'claveCifrada' es null, la clave NO se cambia.
        /// Devuelve false si el usuario ya no existe.
        /// </summary>
        public bool Actualizar(Usuario usuario, string claveCifrada)
        {
            // Si no hay clave nueva, la consulta no toca la columna Clave.
            string sql = "UPDATE dbo.Tbl_Usuarios SET IdSucursal = @IdSucursal, NombreUsuario = @NombreUsuario, " +
                         "NombreCompleto = @NombreCompleto, Correo = @Correo, Estado = @Estado" +
                         (claveCifrada != null ? ", Clave = @Clave" : "") +
                         " WHERE IdUsuario = @IdUsuario;";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    AgregarParametros(cmd, usuario);
                    cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = usuario.IdUsuario;
                    if (claveCifrada != null)
                    {
                        cmd.Parameters.Add("@Clave", SqlDbType.VarChar, 255).Value = claveCifrada;
                    }
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex) when (ex.Number == ErrorLlaveForanea)
            {
                throw new Exception("La sucursal indicada no existe. Revise el código.", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo actualizar el usuario. " + ex.Message, ex);
            }
        }

        /// <summary>ELIMINAR: borra un usuario. Devuelve false si ya no existe.</summary>
        public bool Eliminar(int idUsuario)
        {
            string sql = "DELETE FROM dbo.Tbl_Usuarios WHERE IdUsuario = @IdUsuario;";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario;
                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el usuario. " + ex.Message, ex);
            }
        }

        /// <summary>Parámetros comunes de INSERT y UPDATE (tipo y tamaño iguales a la tabla).</summary>
        private static void AgregarParametros(SqlCommand cmd, Usuario usuario)
        {
            cmd.Parameters.Add("@IdSucursal", SqlDbType.Int).Value = usuario.IdSucursal;
            cmd.Parameters.Add("@NombreUsuario", SqlDbType.VarChar, 100).Value = usuario.NombreUsuario;
            cmd.Parameters.Add("@NombreCompleto", SqlDbType.VarChar, 150).Value = usuario.NombreCompleto;
            cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value =
                string.IsNullOrWhiteSpace(usuario.Correo) ? (object)DBNull.Value : usuario.Correo;
            cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = usuario.Estado;
        }
    }
}
