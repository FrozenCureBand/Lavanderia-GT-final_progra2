using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    /// <summary>Consulta los datos de acceso usando los valores que escribió la persona.</summary>
    public class DLogin
    {
        public Usuario Validar(string nombreUsuario, string claveActual, string claveSha256)
        {
            const string sql = @"SELECT u.IdUsuario, u.NombreUsuario, u.NombreCompleto,
       u.IdSucursal, u.IdRol, r.NombreRol
FROM dbo.Tbl_Usuarios u
INNER JOIN dbo.Tbl_Roles r ON r.IdRol = u.IdRol AND r.Estado = 1
WHERE u.NombreUsuario = @NombreUsuario
  AND (u.Clave = @ClaveActual OR u.Clave = @ClaveSha256)
  AND u.Estado = 1;";

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    // Los valores se envían como parámetros, nunca concatenados al SQL.
                    cmd.Parameters.Add("@NombreUsuario", SqlDbType.VarChar, 100).Value = nombreUsuario;
                    cmd.Parameters.Add("@ClaveActual", SqlDbType.VarChar, 255).Value = claveActual;
                    cmd.Parameters.Add("@ClaveSha256", SqlDbType.VarChar, 255).Value = claveSha256;
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (!dr.Read()) return null;
                        return new Usuario
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            NombreUsuario = dr["NombreUsuario"].ToString(),
                            NombreCompleto = dr["NombreCompleto"].ToString(),
                            IdSucursal = Convert.ToInt32(dr["IdSucursal"]),
                            IdRol = Convert.ToInt32(dr["IdRol"]),
                            NombreRol = dr["NombreRol"].ToString(),
                            Estado = true
                        };
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo validar el inicio de sesión. " + ex.Message, ex);
            }
        }

        public List<string> ObtenerAccesos(int idRol)
        {
            List<string> accesos = new List<string>();
            const string sql = @"SELECT a.CodigoMenu FROM dbo.Tbl_Accesos a
INNER JOIN dbo.Tbl_RolesAccesos ra ON ra.IdAcceso = a.IdAcceso
WHERE ra.IdRol = @IdRol AND ra.Permitido = 1 AND a.Estado = 1;";
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@IdRol", SqlDbType.Int).Value = idRol;
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                        while (dr.Read()) accesos.Add(dr["CodigoMenu"].ToString());
                }
                return accesos;
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudieron consultar los accesos del rol. " + ex.Message, ex);
            }
        }
    }
}
