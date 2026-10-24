using System;
using System.Collections.Generic;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Reglas de negocio de Clientes: valida los datos ANTES de enviarlos a la capa Datos.
    /// La Presentación habla con esta clase, nunca directamente con Datos.
    /// Los métodos que modifican datos devuelven "OK" (constante Correcto) o el mensaje para el usuario.
    /// </summary>
    public class NCliente
    {
        // Texto que devuelven los métodos cuando la operación fue correcta.
        public const string Correcto = "OK";

        // Objeto de la capa Datos (encapsulado: solo se usa dentro de esta clase).
        private readonly DCliente datos = new DCliente();

        /// <summary>CONSULTAR: devuelve todos los clientes.</summary>
        public List<Cliente> Consultar()
        {
            return datos.Consultar();
        }

        /// <summary>
        /// BUSCAR: clientes cuyo nombre o teléfono contienen el texto.
        /// Si el texto está vacío, devuelve todos los clientes.
        /// </summary>
        public List<Cliente> Buscar(string texto)
        {
            texto = Limpiar(texto);
            if (texto == "")
            {
                return datos.Consultar();
            }
            return datos.Buscar(texto);
        }

        /// <summary>Valida y guarda un cliente nuevo. Si se guarda, cliente.IdCliente queda con el código generado.</summary>
        public string Insertar(Cliente cliente)
        {
            string error = Validar(cliente);
            if (error != "")
            {
                return error;
            }

            // La fecha de registro es la hora local del equipo
            // (el SQL Server de Docker trabaja en hora UTC, 6 horas adelante de Guatemala).
            cliente.FechaRegistro = DateTime.Now;
            cliente.IdCliente = datos.Insertar(cliente);
            return Correcto;
        }

        /// <summary>Valida y actualiza un cliente existente.</summary>
        public string Actualizar(Cliente cliente)
        {
            if (cliente.IdCliente <= 0)
            {
                return "Primero seleccione un cliente.";
            }

            string error = Validar(cliente);
            if (error != "")
            {
                return error;
            }

            if (!datos.Actualizar(cliente))
            {
                return "El cliente ya no existe en la base de datos.";
            }
            return Correcto;
        }

        /// <summary>Elimina un cliente por su código.</summary>
        public string Eliminar(int idCliente)
        {
            if (idCliente <= 0)
            {
                return "Primero seleccione un cliente.";
            }

            if (!datos.Eliminar(idCliente))
            {
                return "El cliente ya no existe en la base de datos.";
            }
            return Correcto;
        }

        /// <summary>
        /// Revisa los datos. Devuelve "" si son válidos o el mensaje del primer error.
        /// Los límites de tamaño son los de las columnas de la tabla.
        /// </summary>
        private string Validar(Cliente cliente)
        {
            // Se quitan los espacios sobrantes al inicio y al final de cada texto.
            cliente.NombreCompleto = Limpiar(cliente.NombreCompleto);
            cliente.Telefono = Limpiar(cliente.Telefono);
            cliente.Correo = Limpiar(cliente.Correo);
            cliente.Direccion = Limpiar(cliente.Direccion);

            if (cliente.NombreCompleto == "")
            {
                return "El nombre completo es obligatorio.";
            }
            if (cliente.NombreCompleto.Length > 150)
            {
                return "El nombre completo admite como máximo 150 caracteres.";
            }
            if (cliente.Telefono.Length > 20)
            {
                return "El teléfono admite como máximo 20 caracteres.";
            }
            if (cliente.Correo.Length > 100)
            {
                return "El correo admite como máximo 100 caracteres.";
            }
            if (cliente.Correo != "" && !CorreoValido(cliente.Correo))
            {
                return "El correo no tiene un formato válido (ejemplo: nombre@correo.com).";
            }
            if (cliente.Direccion.Length > 250)
            {
                return "La dirección admite como máximo 250 caracteres.";
            }

            return "";
        }

        /// <summary>Revisión sencilla de correo: debe tener una @ y un punto después de ella.</summary>
        internal static bool CorreoValido(string correo)
        {
            int arroba = correo.IndexOf('@');
            return arroba > 0 && correo.IndexOf('.', arroba) > arroba + 1 && !correo.EndsWith(".");
        }

        /// <summary>Convierte null en "" y quita espacios sobrantes.</summary>
        internal static string Limpiar(string texto)
        {
            return (texto ?? "").Trim();
        }
    }
}
