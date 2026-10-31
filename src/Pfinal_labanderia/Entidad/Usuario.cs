namespace Entidad
{
    /// <summary>
    /// Entidad Usuario: representa UNA fila de dbo.Tbl_Usuarios.
    /// No tiene la propiedad Clave para no cargar la contraseña en las consultas de lista.
    /// </summary>
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }              // Nombre para iniciar sesión
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public int IdSucursal { get; set; }                    // Llave foránea a Tbl_Sucursales
        public string NombreSucursal { get; set; }             // Tbl_Sucursales.Nombre (viene de un JOIN)
        public int? IdRol { get; set; }                        // Rol asociado al usuario
        public string NombreRol { get; set; }                   // Nombre del rol para mostrarlo
        public bool Estado { get; set; }                       // true = Activo
    }
}
