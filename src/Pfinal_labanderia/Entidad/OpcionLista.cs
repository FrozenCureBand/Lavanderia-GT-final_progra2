namespace Entidad
{
    /// <summary>
    /// Una opción de una lista desplegable (ComboBox):
    /// el código que se guarda en la base (Id) y el texto que ve el usuario (Texto).
    /// Ejemplo: Id = 1, Texto = "Recepción #1 - Carlos Méndez".
    /// </summary>
    public class OpcionLista
    {
        public int Id { get; set; }
        public string Texto { get; set; }

        /// <summary>Constructor vacío.</summary>
        public OpcionLista()
        {
        }

        /// <summary>Constructor que recibe el código y el texto de la opción.</summary>
        public OpcionLista(int id, string texto)
        {
            Id = id;
            Texto = texto;
        }

        /// <summary>Lo que se muestra si el objeto se convierte a texto.</summary>
        public override string ToString()
        {
            return Texto;
        }
    }
}
