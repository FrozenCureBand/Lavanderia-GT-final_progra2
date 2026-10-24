using System;
using System.Collections.Generic;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Reglas de negocio de Recepciones: valida los datos ANTES de enviarlos a la capa Datos.
    /// Los métodos que modifican datos devuelven "OK" (constante Correcto) o el mensaje para el usuario.
    /// </summary>
    public class NRecepcion
    {
        public const string Correcto = "OK";

        // Valor máximo de una columna decimal(10,2): 8 dígitos enteros y 2 decimales.
        private const decimal MontoMaximo = 99999999.99m;

        // Objeto de la capa Datos (encapsulado: solo se usa dentro de esta clase).
        private readonly DRecepcion datos = new DRecepcion();

        /// <summary>CONSULTAR: devuelve todas las recepciones.</summary>
        public List<Recepcion> Consultar()
        {
            return datos.Consultar();
        }

        /// <summary>Recepciones para una lista desplegable ("Recepción #1 - Carlos Méndez").</summary>
        public List<OpcionLista> ListarOpciones()
        {
            return datos.ListarOpciones();
        }

        /// <summary>
        /// BUSCAR: recepciones cuyo cliente o sucursal contienen el texto.
        /// Si el texto está vacío, devuelve todas las recepciones.
        /// </summary>
        public List<Recepcion> Buscar(string texto)
        {
            texto = NCliente.Limpiar(texto);
            if (texto == "")
            {
                return datos.Consultar();
            }
            return datos.Buscar(texto);
        }

        /// <summary>
        /// Valida y guarda una recepción nueva. Su estado inicial es 'Recibido' (lo pone la base de datos).
        /// Si no se indicó la fecha de recepción, se usa la fecha y hora actual del equipo.
        /// </summary>
        public string Insertar(Recepcion recepcion)
        {
            if (!recepcion.FechaRecepcion.HasValue)
            {
                recepcion.FechaRecepcion = DateTime.Now;
            }

            string error = Validar(recepcion);
            if (error != "")
            {
                return error;
            }

            recepcion.IdRecepcion = datos.Insertar(recepcion);
            return Correcto;
        }

        /// <summary>Valida y actualiza una recepción (su Estado no se modifica).</summary>
        public string Actualizar(Recepcion recepcion)
        {
            if (recepcion.IdRecepcion <= 0)
            {
                return "Primero seleccione una recepción.";
            }

            string error = Validar(recepcion);
            if (error != "")
            {
                return error;
            }

            if (!datos.Actualizar(recepcion))
            {
                return "La recepción ya no existe en la base de datos.";
            }
            return Correcto;
        }

        /// <summary>Elimina una recepción por su código.</summary>
        public string Eliminar(int idRecepcion)
        {
            if (idRecepcion <= 0)
            {
                return "Primero seleccione una recepción.";
            }

            if (!datos.Eliminar(idRecepcion))
            {
                return "La recepción ya no existe en la base de datos.";
            }
            return Correcto;
        }

        /// <summary>Revisa los datos. Devuelve "" si son válidos o el mensaje del primer error.</summary>
        private string Validar(Recepcion recepcion)
        {
            recepcion.Observaciones = NCliente.Limpiar(recepcion.Observaciones);

            if (recepcion.IdCliente <= 0)
            {
                return "Escriba el ID del cliente (un número mayor que 0).";
            }
            if (recepcion.IdSucursal <= 0)
            {
                return "Escriba el ID de la sucursal (un número mayor que 0).";
            }
            if (recepcion.Total < 0)
            {
                return "El total no puede ser negativo.";
            }
            if (recepcion.Total > MontoMaximo)
            {
                return "El total es demasiado grande.";
            }
            if (recepcion.Observaciones.Length > 500)
            {
                return "Las observaciones admiten como máximo 500 caracteres.";
            }

            // La entrega no puede ser antes de la recepción.
            if (recepcion.FechaRecepcion.HasValue && recepcion.FechaEntregaEstimada.HasValue &&
                recepcion.FechaEntregaEstimada.Value < recepcion.FechaRecepcion.Value)
            {
                return "La fecha de entrega estimada no puede ser anterior a la fecha de recepción.";
            }

            return "";
        }
    }
}
