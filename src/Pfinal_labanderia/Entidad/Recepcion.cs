using System;

namespace Entidad
{
    /// <summary>
    /// Entidad Recepcion: representa UNA fila de dbo.Tbl_Recepciones.
    /// Además del código del cliente y de la sucursal, guarda sus NOMBRES (vienen de un JOIN)
    /// para mostrarlos en la tabla en lugar de solo números.
    /// </summary>
    public class Recepcion
    {
        public int IdRecepcion { get; set; }
        public int IdCliente { get; set; }                     // Llave foránea a Tbl_Clientes
        public string NombreCliente { get; set; }              // Tbl_Clientes.NombreCompleto
        public int IdSucursal { get; set; }                    // Llave foránea a Tbl_Sucursales
        public string NombreSucursal { get; set; }             // Tbl_Sucursales.Nombre
        public DateTime? FechaRecepcion { get; set; }          // El "?" permite NULL
        public DateTime? FechaEntregaEstimada { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }                     // Texto: "Recibido", "En proceso", ...
        public string Observaciones { get; set; }
    }
}
