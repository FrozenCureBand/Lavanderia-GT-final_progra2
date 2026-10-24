namespace Entidad
{
    /// <summary>
    /// Entidad Servicio: representa UNA fila de dbo.Tbl_Servicios (lavado, lavado en seco, planchado, ...).
    /// Módulo integrado desde el proyecto LavanderiasMultinegocio y adaptado a este proyecto.
    /// </summary>
    public class Servicio
    {
        public int IdServicio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }                  // true = Activo

        /// <summary>Constructor: un servicio nuevo empieza como Activo.</summary>
        public Servicio()
        {
            Estado = true;
        }
    }
}
