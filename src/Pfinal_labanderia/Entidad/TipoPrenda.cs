namespace Entidad
{
    /// <summary>
    /// Entidad TipoPrenda: representa UNA fila de dbo.Tbl_TiposPrenda (camisa, pantalón, vestido, ...).
    /// Módulo integrado desde el proyecto LavanderiasMultinegocio ("Prendas") y adaptado a este proyecto.
    /// </summary>
    public class TipoPrenda
    {
        public int IdTipoPrenda { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }                  // true = Activo

        /// <summary>Constructor: un tipo de prenda nuevo empieza como Activo.</summary>
        public TipoPrenda()
        {
            Estado = true;
        }
    }
}
