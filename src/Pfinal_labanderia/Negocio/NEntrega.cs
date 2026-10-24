using System.Collections.Generic;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Reglas de negocio de Entregas (integrado desde LavanderiasMultinegocio).
    /// Los métodos que modifican datos devuelven "OK" (constante Correcto) o el mensaje para el usuario.
    /// </summary>
    public class NEntrega
    {
        public const string Correcto = "OK";

        // Estado con el que se registra toda entrega nueva.
        public const string EstadoEntregado = "Entregado";

        // Largos máximos: iguales a los de las columnas de dbo.Tbl_Entregas.
        private const int MaxNombreRecibe = 150;
        private const int MaxObservaciones = 500;

        // Objeto de la capa Datos (encapsulado: solo se usa dentro de esta clase).
        private readonly DEntrega datos = new DEntrega();

        /// <summary>CONSULTAR: todas las entregas.</summary>
        public List<Entrega> Consultar()
        {
            return datos.Consultar();
        }

        /// <summary>BUSCAR: entregas por cliente o persona que recibe. Texto vacío = todas.</summary>
        public List<Entrega> Buscar(string texto)
        {
            texto = NCliente.Limpiar(texto);
            if (texto == "")
            {
                return datos.Consultar();
            }
            return datos.Buscar(texto);
        }

        /// <summary>Valida y guarda una entrega nueva (queda con estado 'Entregado').</summary>
        public string Insertar(Entrega entrega)
        {
            entrega.Estado = EstadoEntregado;

            string error = Validar(entrega);
            if (error != "")
            {
                return error;
            }

            entrega.IdEntrega = datos.Insertar(entrega);
            return Correcto;
        }

        /// <summary>Valida y actualiza una entrega existente.</summary>
        public string Actualizar(Entrega entrega)
        {
            if (entrega.IdEntrega <= 0)
            {
                return "Primero seleccione una entrega.";
            }

            string error = Validar(entrega);
            if (error != "")
            {
                return error;
            }

            if (!datos.Actualizar(entrega))
            {
                return "La entrega ya no existe en la base de datos.";
            }
            return Correcto;
        }

        /// <summary>Elimina una entrega por su código.</summary>
        public string Eliminar(int idEntrega)
        {
            if (idEntrega <= 0)
            {
                return "Primero seleccione una entrega.";
            }

            if (!datos.Eliminar(idEntrega))
            {
                return "La entrega ya no existe en la base de datos.";
            }
            return Correcto;
        }

        /// <summary>Revisa los datos. Devuelve "" si son válidos o el mensaje del primer error.</summary>
        private string Validar(Entrega entrega)
        {
            entrega.NombreRecibe = NCliente.Limpiar(entrega.NombreRecibe);
            entrega.Observaciones = NCliente.Limpiar(entrega.Observaciones);

            if (entrega.IdRecepcion <= 0)
            {
                return "Seleccione la recepción que se entrega.";
            }
            if (!entrega.FechaEntrega.HasValue)
            {
                return "Indique la fecha de entrega.";
            }
            if (entrega.NombreRecibe == "")
            {
                return "Escriba el nombre de la persona que recibe.";
            }
            if (entrega.NombreRecibe.Length > MaxNombreRecibe)
            {
                return "El nombre de quien recibe admite como máximo " + MaxNombreRecibe + " caracteres.";
            }
            if (entrega.Observaciones.Length > MaxObservaciones)
            {
                return "Las observaciones admiten como máximo " + MaxObservaciones + " caracteres.";
            }

            // Regla de negocio (del proyecto del compañero): una recepción solo puede tener una entrega.
            if (datos.ExisteEntregaDeRecepcion(entrega.IdRecepcion, entrega.IdEntrega))
            {
                return "Esta recepción ya tiene una entrega registrada.";
            }

            return "";
        }
    }
}
