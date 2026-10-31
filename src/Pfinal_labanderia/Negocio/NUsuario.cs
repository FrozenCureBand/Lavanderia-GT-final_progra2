using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Reglas de negocio de Usuarios: valida los datos y mantiene el formato SHA-256 existente.
    /// Los métodos que modifican datos devuelven "OK" (constante Correcto) o el mensaje para el usuario.
    /// </summary>
    public class NUsuario
    {
        public const string Correcto = "OK";

        // Largo mínimo de una clave nueva.
        private const int LargoMinimoClave = 6;

        // Objeto de la capa Datos (encapsulado: solo se usa dentro de esta clase).
        private readonly DUsuario datos = new DUsuario();

        /// <summary>CONSULTAR: devuelve todos los usuarios (sin claves).</summary>
        public List<Usuario> Consultar()
        {
            return datos.Consultar();
        }

        /// <summary>
        /// BUSCAR: usuarios cuyo nombre de usuario o nombre completo contienen el texto (sin claves).
        /// Si el texto está vacío, devuelve todos los usuarios.
        /// </summary>
        public List<Usuario> Buscar(string texto)
        {
            texto = NCliente.Limpiar(texto);
            if (texto == "")
            {
                return datos.Consultar();
            }
            return datos.Buscar(texto);
        }

        /// <summary>Valida y guarda un usuario usando el mismo SHA-256 que ya utilizaba el CRUD.</summary>
        public string Insertar(Usuario usuario, string clave)
        {
            string error = Validar(usuario);
            if (error != "")
            {
                return error;
            }

            clave = clave ?? "";
            if (clave.Length < LargoMinimoClave)
            {
                return "La clave debe tener al menos " + LargoMinimoClave + " caracteres.";
            }

            usuario.IdUsuario = datos.Insertar(usuario, CifrarClave(clave));
            return Correcto;
        }

        /// <summary>
        /// Valida y actualiza un usuario. Si la clave viene vacía, se conserva la clave actual.
        /// </summary>
        public string Actualizar(Usuario usuario, string clave)
        {
            if (usuario.IdUsuario <= 0)
            {
                return "Primero seleccione un usuario.";
            }

            string error = Validar(usuario);
            if (error != "")
            {
                return error;
            }

            // null le indica a la capa Datos que conserve la clave guardada.
            string claveNueva = null;
            clave = clave ?? "";
            if (clave != "")
            {
                if (clave.Length < LargoMinimoClave)
                {
                    return "La clave debe tener al menos " + LargoMinimoClave + " caracteres.";
                }
                claveNueva = CifrarClave(clave);
            }

            if (!datos.Actualizar(usuario, claveNueva))
            {
                return "El usuario ya no existe en la base de datos.";
            }
            return Correcto;
        }

        /// <summary>Elimina un usuario por su código.</summary>
        public string Eliminar(int idUsuario)
        {
            if (idUsuario <= 0)
            {
                return "Primero seleccione un usuario.";
            }

            if (!datos.Eliminar(idUsuario))
            {
                return "El usuario ya no existe en la base de datos.";
            }
            return Correcto;
        }

        /// <summary>Convierte la clave al formato SHA-256 existente, que no es cifrado reversible.</summary>
        public static string CifrarClave(string clave)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(clave));
                StringBuilder resultado = new StringBuilder();
                foreach (byte valor in bytes) resultado.Append(valor.ToString("x2"));
                return resultado.ToString();
            }
        }

        /// <summary>Revisa los datos. Devuelve "" si son válidos o el mensaje del primer error.</summary>
        private string Validar(Usuario usuario)
        {
            usuario.NombreUsuario = NCliente.Limpiar(usuario.NombreUsuario);
            usuario.NombreCompleto = NCliente.Limpiar(usuario.NombreCompleto);
            usuario.Correo = NCliente.Limpiar(usuario.Correo);

            if (usuario.IdSucursal <= 0)
            {
                return "Escriba el ID de la sucursal (un número mayor que 0).";
            }
            if (!usuario.IdRol.HasValue || usuario.IdRol.Value <= 0)
            {
                return "Seleccione un rol para el usuario.";
            }
            if (usuario.NombreUsuario == "")
            {
                return "El nombre de usuario es obligatorio.";
            }
            if (usuario.NombreUsuario.Contains(" "))
            {
                return "El nombre de usuario no puede tener espacios.";
            }
            if (usuario.NombreUsuario.Length > 100)
            {
                return "El nombre de usuario admite como máximo 100 caracteres.";
            }
            if (usuario.NombreCompleto == "")
            {
                return "El nombre completo es obligatorio.";
            }
            if (usuario.NombreCompleto.Length > 150)
            {
                return "El nombre completo admite como máximo 150 caracteres.";
            }
            if (usuario.Correo.Length > 100)
            {
                return "El correo admite como máximo 100 caracteres.";
            }
            if (usuario.Correo != "" && !NCliente.CorreoValido(usuario.Correo))
            {
                return "El correo no tiene un formato válido (ejemplo: nombre@correo.com).";
            }

            // Regla de negocio: no puede haber dos usuarios con el mismo nombre de usuario.
            if (datos.ExisteNombreUsuario(usuario.NombreUsuario, usuario.IdUsuario))
            {
                return "Ya existe otro usuario con el nombre '" + usuario.NombreUsuario + "'.";
            }

            return "";
        }
    }
}
