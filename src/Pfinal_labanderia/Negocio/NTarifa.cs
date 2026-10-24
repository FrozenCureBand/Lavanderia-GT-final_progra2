using System;
using System.Collections.Generic;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Reglas de negocio de Tarifas: valida los datos ANTES de enviarlos a la capa Datos.
    /// Los métodos que modifican datos devuelven "OK" (constante Correcto) o el mensaje para el usuario.
    /// </summary>
    public class NTarifa
    {
        public const string Correcto = "OK";

        // Valor máximo de una columna decimal(10,2): 8 dígitos enteros y 2 decimales.
        private const decimal MontoMaximo = 99999999.99m;

        // Objeto de la capa Datos (encapsulado: solo se usa dentro de esta clase).
        private readonly DTarifa datos = new DTarifa();

        /// <summary>CONSULTAR: devuelve todas las tarifas.</summary>
        public List<Tarifa> Consultar()
        {
            return datos.Consultar();
        }

        /// <summary>
        /// BUSCAR: tarifas cuyo tipo de prenda o servicio contienen el texto.
        /// Si el texto está vacío, devuelve todas las tarifas.
        /// </summary>
        public List<Tarifa> Buscar(string texto)
        {
            texto = NCliente.Limpiar(texto);
            if (texto == "")
            {
                return datos.Consultar();
            }
            return datos.Buscar(texto);
        }

        /// <summary>Valida y guarda una tarifa nueva. Sin fecha de inicio, rige desde hoy.</summary>
        public string Insertar(Tarifa tarifa)
        {
            if (!tarifa.FechaInicio.HasValue)
            {
                tarifa.FechaInicio = DateTime.Today;
            }

            string error = Validar(tarifa);
            if (error != "")
            {
                return error;
            }

            tarifa.IdTarifa = datos.Insertar(tarifa);
            return Correcto;
        }

        /// <summary>Valida y actualiza una tarifa existente.</summary>
        public string Actualizar(Tarifa tarifa)
        {
            if (tarifa.IdTarifa <= 0)
            {
                return "Primero seleccione una tarifa.";
            }

            string error = Validar(tarifa);
            if (error != "")
            {
                return error;
            }

            if (!datos.Actualizar(tarifa))
            {
                return "La tarifa ya no existe en la base de datos.";
            }
            return Correcto;
        }

        /// <summary>Elimina una tarifa por su código.</summary>
        public string Eliminar(int idTarifa)
        {
            if (idTarifa <= 0)
            {
                return "Primero seleccione una tarifa.";
            }

            if (!datos.Eliminar(idTarifa))
            {
                return "La tarifa ya no existe en la base de datos.";
            }
            return Correcto;
        }

        /// <summary>Revisa los datos. Devuelve "" si son válidos o el mensaje del primer error.</summary>
        private string Validar(Tarifa tarifa)
        {
            if (tarifa.IdTipoPrenda <= 0)
            {
                return "Escriba el ID del tipo de prenda (un número mayor que 0).";
            }
            if (tarifa.IdServicio <= 0)
            {
                return "Escriba el ID del servicio (un número mayor que 0).";
            }
            if (tarifa.Precio <= 0)
            {
                return "El precio debe ser mayor que 0.";
            }
            if (tarifa.Precio > MontoMaximo)
            {
                return "El precio es demasiado grande.";
            }

            return "";
        }
    }
}
