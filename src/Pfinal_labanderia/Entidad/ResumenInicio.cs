namespace Entidad
{
    /// <summary>
    /// Indicadores (tarjetas) de la pantalla de Inicio.
    /// Cada propiedad es un número que se muestra en una tarjeta.
    /// </summary>
    public class ResumenInicio
    {
        public int ClientesActivos { get; set; }     // Clientes con Estado = 1
        public int SucursalesActivas { get; set; }   // Sucursales con Estado = 1
        public int RecepcionesMes { get; set; }      // Recepciones del mes actual
        public decimal IngresosMes { get; set; }     // Suma del Total de las recepciones del mes
        public int EntregasMes { get; set; }         // Entregas del mes actual
    }
}
