using System.Collections.Generic;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Reglas de negocio de Servicios (integrado desde LavanderiasMultinegocio).
    /// Los métodos que modifican datos devuelven "OK" (constante Correcto) o el mensaje para el usuario.
    /// </summary>
    public class NServicio
    {
        public const string Correcto = "OK";

        // Largos máximos: iguales a los de las columnas de dbo.Tbl_Servicios.
        private const int MaxNombre = 100;
        private const int MaxDescripcion = 250;

        // Objeto de la capa Datos (encapsulado: solo se usa dentro de esta clase).
        private readonly DServicio datos = new DServicio();

        /// <summary>CONSULTAR: todos los servicios.</summary>
        public List<Servicio> Consultar()
        {
            return datos.Consultar();
        }

        /// <summary>BUSCAR: servicios por nombre o descripción. Texto vacío = todos.</summary>
        public List<Servicio> Buscar(string texto)
        {
            texto = NCliente.Limpiar(texto);
            if (texto == "")
            {
                return datos.Consultar();
            }
            return datos.Buscar(texto);
        }

        /// <summary>Valida y guarda un servicio nuevo.</summary>
        public string Insertar(Servicio servicio)
        {
            string error = Validar(servicio);
            if (error != "")
            {
                return error;
            }

            servicio.IdServicio = datos.Insertar(servicio);
            return Correcto;
        }

        /// <summary>Valida y actualiza un servicio existente.</summary>
        public string Actualizar(Servicio servicio)
        {
            if (servicio.IdServicio <= 0)
            {
                return "Primero seleccione un servicio.";
            }

            string error = Validar(servicio);
            if (error != "")
            {
                return error;
            }

            if (!datos.Actualizar(servicio))
            {
                return "El servicio ya no existe en la base de datos.";
            }
            return Correcto;
        }

        /// <summary>Elimina un servicio por su código.</summary>
        public string Eliminar(int idServicio)
        {
            if (idServicio <= 0)
            {
                return "Primero seleccione un servicio.";
            }

            if (!datos.Eliminar(idServicio))
            {
                return "El servicio ya no existe en la base de datos.";
            }
            return Correcto;
        }

        /// <summary>Revisa los datos. Devuelve "" si son válidos o el mensaje del primer error.</summary>
        private string Validar(Servicio servicio)
        {
            servicio.Nombre = NCliente.Limpiar(servicio.Nombre);
            servicio.Descripcion = NCliente.Limpiar(servicio.Descripcion);

            if (servicio.Nombre == "")
            {
                return "El nombre es obligatorio.";
            }
            if (servicio.Nombre.Length > MaxNombre)
            {
                return "El nombre admite como máximo " + MaxNombre + " caracteres.";
            }
            if (servicio.Descripcion.Length > MaxDescripcion)
            {
                return "La descripción admite como máximo " + MaxDescripcion + " caracteres.";
            }

            return "";
        }
    }
}
