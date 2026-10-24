namespace Entidad
{
    /// <summary>
    /// Un punto de una gráfica: un texto (Etiqueta) y su valor.
    /// Ejemplo: Etiqueta = "Lavandería Zona 1", Valor = 35.00
    /// </summary>
    public class DatoGrafica
    {
        public string Etiqueta { get; set; }
        public decimal Valor { get; set; }

        /// <summary>Constructor vacío.</summary>
        public DatoGrafica()
        {
        }

        /// <summary>Constructor que recibe la etiqueta y el valor del punto.</summary>
        public DatoGrafica(string etiqueta, decimal valor)
        {
            Etiqueta = etiqueta;
            Valor = valor;
        }
    }
}
