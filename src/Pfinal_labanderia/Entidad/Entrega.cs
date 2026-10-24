using System;

namespace Entidad
{
    /// <summary>
    /// Entidad Entrega: representa UNA fila de dbo.Tbl_Entregas (la entrega de una recepción al cliente).
    /// Módulo integrado desde el proyecto LavanderiasMultinegocio y adaptado a este proyecto.
    /// </summary>
    public class Entrega
    {
        public int IdEntrega { get; set; }
        public int IdRecepcion { get; set; }              // Llave foránea a Tbl_Recepciones
        public string NombreCliente { get; set; }         // Cliente de la recepción (viene de un JOIN)
        public DateTime? FechaEntrega { get; set; }       // El "?" permite NULL
        public string NombreRecibe { get; set; }          // Persona que retira la ropa
        public string Observaciones { get; set; }
        public string Estado { get; set; }                // Texto: "Entregado"
    }
}
