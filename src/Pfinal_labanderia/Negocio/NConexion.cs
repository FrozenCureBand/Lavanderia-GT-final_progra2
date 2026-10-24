namespace Negocio
{
    /// <summary>
    /// Puente entre la Presentación y la capa Datos para probar la conexión.
    /// La Presentación nunca usa Datos ni SQL Server directamente: siempre pasa por Negocio.
    /// </summary>
    public class NConexion
    {
        /// <summary>
        /// Devuelve true si la conexión funciona.
        /// En 'mensaje' queda el texto que la Presentación debe mostrar al usuario.
        /// </summary>
        public static bool ProbarConexion(out string mensaje)
        {
            return Datos.Conexion.ProbarConexion(out mensaje);
        }
    }
}
