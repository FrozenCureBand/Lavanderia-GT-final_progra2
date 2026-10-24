namespace Datos
{
    /// <summary>
    /// Ayuda para las búsquedas con LIKE de la capa Datos.
    /// </summary>
    internal static class Busqueda
    {
        /// <summary>
        /// Convierte el texto escrito por el usuario en un patrón para LIKE: '%texto%'
        /// (el texto puede estar en cualquier parte). Los caracteres especiales de LIKE
        /// (%, _ y [) se encierran entre corchetes para que se busquen tal cual se escribieron.
        /// </summary>
        public static string Patron(string texto)
        {
            // Primero el corchete, porque los reemplazos siguientes agregan corchetes.
            string seguro = texto.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]");
            return "%" + seguro + "%";
        }
    }
}
