using System;

namespace Entidad
{
    /// <summary>
    /// Entidad Tarifa: representa UNA fila de dbo.Tbl_Tarifas (precio de un servicio para un tipo de prenda).
    /// Guarda también los NOMBRES del tipo de prenda y del servicio (vienen de un JOIN).
    /// </summary>
    public class Tarifa
    {
        public int IdTarifa { get; set; }
        public int IdTipoPrenda { get; set; }                  // Llave foránea a Tbl_TiposPrenda
        public string NombreTipoPrenda { get; set; }           // Tbl_TiposPrenda.Nombre
        public int IdServicio { get; set; }                    // Llave foránea a Tbl_Servicios
        public string NombreServicio { get; set; }             // Tbl_Servicios.Nombre
        public decimal Precio { get; set; }
        public DateTime? FechaInicio { get; set; }             // Desde cuándo rige el precio
        public bool Estado { get; set; }                       // true = Activa
    }
}
