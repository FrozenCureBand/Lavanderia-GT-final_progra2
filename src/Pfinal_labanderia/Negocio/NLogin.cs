using System.Collections.Generic;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>Aplica las comprobaciones básicas antes de pedir a Datos el usuario y sus permisos.</summary>
    public class NLogin
    {
        private readonly DLogin datos = new DLogin();

        public Usuario IniciarSesion(string nombreUsuario, string clave)
        {
            nombreUsuario = (nombreUsuario ?? "").Trim();
            clave = clave ?? "";
            if (nombreUsuario == "" || clave == "") return null;
            // Comprueba la clave actual y el SHA-256 usado por el CRUD para claves nuevas.
            return datos.Validar(nombreUsuario, clave, NUsuario.CifrarClave(clave));
        }

        public List<string> ObtenerAccesos(int idRol)
        {
            return datos.ObtenerAccesos(idRol);
        }
    }
}
