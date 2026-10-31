namespace Entidad
{
    /// <summary>Representa una opción del menú asignada a un rol.</summary>
    public class Acceso
    {
        public int IdAcceso { get; set; }
        public string NombreAcceso { get; set; }
        public string CodigoMenu { get; set; }
        public bool Permitido { get; set; }
        public override string ToString() { return NombreAcceso; }
    }
}
