using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    /// <summary>Consulta y guarda roles y sus opciones del menú.</summary>
    public class DRol
    {
        public List<Rol> Consultar()
        {
            List<Rol> lista = new List<Rol>();
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("SELECT IdRol, NombreRol, Descripcion, Estado FROM dbo.Tbl_Roles ORDER BY NombreRol;", cn))
                {
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                        while (dr.Read()) lista.Add(new Rol { IdRol = Convert.ToInt32(dr["IdRol"]), NombreRol = dr["NombreRol"].ToString(), Descripcion = dr["Descripcion"].ToString(), Estado = Convert.ToBoolean(dr["Estado"]) });
                }
                return lista;
            }
            catch (SqlException ex) { throw new Exception("No se pudieron consultar los roles. " + ex.Message, ex); }
        }

        public List<Acceso> ConsultarAccesos(int idRol)
        {
            List<Acceso> lista = new List<Acceso>();
            const string sql = @"SELECT a.IdAcceso, a.NombreAcceso, a.CodigoMenu,
CASE WHEN ra.Permitido = 1 THEN 1 ELSE 0 END AS Permitido
FROM dbo.Tbl_Accesos a LEFT JOIN dbo.Tbl_RolesAccesos ra
ON ra.IdAcceso = a.IdAcceso AND ra.IdRol = @IdRol ORDER BY a.IdAcceso;";
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@IdRol", SqlDbType.Int).Value = idRol;
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                        while (dr.Read()) lista.Add(new Acceso { IdAcceso = Convert.ToInt32(dr["IdAcceso"]), NombreAcceso = dr["NombreAcceso"].ToString(), CodigoMenu = dr["CodigoMenu"].ToString(), Permitido = Convert.ToBoolean(dr["Permitido"]) });
                }
                return lista;
            }
            catch (SqlException ex) { throw new Exception("No se pudieron consultar los accesos. " + ex.Message, ex); }
        }

        public void Guardar(Rol rol, List<Acceso> accesos)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();
                SqlTransaction transaccion = cn.BeginTransaction();
                try
                {
                    string sql = rol.IdRol == 0
                        ? "INSERT dbo.Tbl_Roles (NombreRol, Descripcion, Estado) VALUES (@NombreRol,@Descripcion,@Estado); SELECT CAST(SCOPE_IDENTITY() AS int);"
                        : "UPDATE dbo.Tbl_Roles SET NombreRol=@NombreRol, Descripcion=@Descripcion, Estado=@Estado WHERE IdRol=@IdRol; SELECT @IdRol;";
                    using (SqlCommand cmd = new SqlCommand(sql, cn, transaccion))
                    {
                        cmd.Parameters.Add("@NombreRol", SqlDbType.VarChar, 50).Value = rol.NombreRol;
                        cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 150).Value = (object)rol.Descripcion ?? DBNull.Value;
                        cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = rol.Estado;
                        cmd.Parameters.Add("@IdRol", SqlDbType.Int).Value = rol.IdRol;
                        rol.IdRol = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    foreach (Acceso acceso in accesos)
                    {
                        const string permiso = @"IF EXISTS (SELECT 1 FROM dbo.Tbl_RolesAccesos WHERE IdRol=@IdRol AND IdAcceso=@IdAcceso)
UPDATE dbo.Tbl_RolesAccesos SET Permitido=@Permitido WHERE IdRol=@IdRol AND IdAcceso=@IdAcceso;
ELSE INSERT dbo.Tbl_RolesAccesos (IdRol,IdAcceso,Permitido) VALUES (@IdRol,@IdAcceso,@Permitido);";
                        using (SqlCommand cmd = new SqlCommand(permiso, cn, transaccion))
                        {
                            cmd.Parameters.Add("@IdRol", SqlDbType.Int).Value = rol.IdRol;
                            cmd.Parameters.Add("@IdAcceso", SqlDbType.Int).Value = acceso.IdAcceso;
                            cmd.Parameters.Add("@Permitido", SqlDbType.Bit).Value = acceso.Permitido;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    transaccion.Commit();
                }
                catch (SqlException ex)
                {
                    transaccion.Rollback();
                    throw new Exception("No se pudo guardar el rol y sus accesos. " + ex.Message, ex);
                }
            }
        }

        public void Eliminar(int idRol)
        {
            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                {
                    cn.Open();
                    using (SqlCommand verificar = new SqlCommand("SELECT COUNT(*) FROM dbo.Tbl_Usuarios WHERE IdRol=@IdRol;", cn))
                    {
                        verificar.Parameters.Add("@IdRol", SqlDbType.Int).Value = idRol;
                        if (Convert.ToInt32(verificar.ExecuteScalar()) > 0)
                            throw new InvalidOperationException("No se puede eliminar un rol asignado a usuarios.");
                    }
                    using (SqlTransaction transaccion = cn.BeginTransaction())
                    using (SqlCommand cmd = new SqlCommand("DELETE dbo.Tbl_RolesAccesos WHERE IdRol=@IdRol; DELETE dbo.Tbl_Roles WHERE IdRol=@IdRol;", cn, transaccion))
                    {
                        cmd.Parameters.Add("@IdRol", SqlDbType.Int).Value = idRol;
                        cmd.ExecuteNonQuery();
                        transaccion.Commit();
                    }
                }
            }
            catch (InvalidOperationException ex) { throw new Exception(ex.Message, ex); }
            catch (SqlException ex) { throw new Exception("No se pudo eliminar el rol. Compruebe que ningún usuario lo tenga asignado. " + ex.Message, ex); }
        }
    }
}
