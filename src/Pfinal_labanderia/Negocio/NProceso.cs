using System.Collections.Generic;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Reglas de negocio de Procesos (integrado desde LavanderiasMultinegocio).
    /// Los métodos que modifican datos devuelven "OK" (constante Correcto) o el mensaje para el usuario.
    /// </summary>
    public class NProceso
    {
        public const string Correcto = "OK";

        // Largo máximo: igual al de la columna dbo.Tbl_Procesos.Observaciones.
        private const int MaxObservaciones = 500;

        // Objeto de la capa Datos (encapsulado: solo se usa dentro de esta clase).
        private readonly DProceso datos = new DProceso();

        /// <summary>CONSULTAR: todos los procesos.</summary>
        public List<Proceso> Consultar()
        {
            return datos.Consultar();
        }

        /// <summary>BUSCAR: procesos por cliente o estado. Texto vacío = todos.</summary>
        public List<Proceso> Buscar(string texto)
        {
            texto = NCliente.Limpiar(texto);
            if (texto == "")
            {
                return datos.Consultar();
            }
            return datos.Buscar(texto);
        }

        /// <summary>Estados de proceso activos para la lista desplegable.</summary>
        public List<OpcionLista> ListarEstados()
        {
            return datos.ListarEstados();
        }

        /// <summary>Valida y guarda un proceso nuevo.</summary>
        public string Insertar(Proceso proceso)
        {
            string error = Validar(proceso);
            if (error != "")
            {
                return error;
            }

            proceso.IdProceso = datos.Insertar(proceso);
            return Correcto;
        }

        /// <summary>Valida y actualiza un proceso existente.</summary>
        public string Actualizar(Proceso proceso)
        {
            if (proceso.IdProceso <= 0)
            {
                return "Primero seleccione un proceso.";
            }

            string error = Validar(proceso);
            if (error != "")
            {
                return error;
            }

            if (!datos.Actualizar(proceso))
            {
                return "El proceso ya no existe en la base de datos.";
            }
            return Correcto;
        }

        /// <summary>Elimina un proceso por su código.</summary>
        public string Eliminar(int idProceso)
        {
            if (idProceso <= 0)
            {
                return "Primero seleccione un proceso.";
            }

            if (!datos.Eliminar(idProceso))
            {
                return "El proceso ya no existe en la base de datos.";
            }
            return Correcto;
        }

        /// <summary>Revisa los datos. Devuelve "" si son válidos o el mensaje del primer error.</summary>
        private string Validar(Proceso proceso)
        {
            proceso.Observaciones = NCliente.Limpiar(proceso.Observaciones);

            if (proceso.IdRecepcion <= 0)
            {
                return "Seleccione la recepción.";
            }
            if (proceso.IdEstadoProceso <= 0)
            {
                return "Seleccione el estado del proceso.";
            }
            if (!proceso.FechaInicio.HasValue)
            {
                return "Indique la fecha de inicio.";
            }

            // Regla de negocio (del proyecto del compañero): la fecha fin no puede ser antes del inicio.
            if (proceso.FechaFin.HasValue && proceso.FechaFin.Value < proceso.FechaInicio.Value)
            {
                return "La fecha de fin no puede ser anterior a la fecha de inicio.";
            }
            if (proceso.Observaciones.Length > MaxObservaciones)
            {
                return "Las observaciones admiten como máximo " + MaxObservaciones + " caracteres.";
            }

            return "";
        }
    }
}
