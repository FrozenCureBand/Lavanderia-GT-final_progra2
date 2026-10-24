using System;

namespace Entidad
{
    /// <summary>
    /// Entidad Proceso: representa UNA fila de dbo.Tbl_Procesos (una etapa del lavado de una recepción:
    /// Recibido, Lavando, Secando, Planchando, Listo).
    /// Módulo integrado desde el proyecto LavanderiasMultinegocio y adaptado a este proyecto.
    /// </summary>
    public class Proceso
    {
        public int IdProceso { get; set; }
        public int IdRecepcion { get; set; }              // Llave foránea a Tbl_Recepciones
        public string NombreCliente { get; set; }         // Cliente de la recepción (viene de un JOIN)
        public int IdEstadoProceso { get; set; }          // Llave foránea a Tbl_EstadosProceso
        public string NombreEstado { get; set; }          // Nombre del estado (viene de un JOIN)
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }           // null = el proceso todavía no termina
        public string Observaciones { get; set; }
    }
}
