namespace Entidad
{
    /// <summary>
    /// Entidad Usuario: representa UNA fila de dbo.Tbl_Usuarios.
    /// IMPORTANTE: no tiene la propiedad Clave. La contraseña no se consulta ni se muestra
    /// en pantalla por seguridad (se trabajará en el documento de Login y roles).
    /// </summary>
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }              // Nombre para iniciar sesión
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public int IdSucursal { get; set; }                    // Llave foránea a Tbl_Sucursales
        public string NombreSucursal { get; set; }             // Tbl_Sucursales.Nombre (viene de un JOIN)
        public bool Estado { get; set; }                       // true = Activo
    }
}
