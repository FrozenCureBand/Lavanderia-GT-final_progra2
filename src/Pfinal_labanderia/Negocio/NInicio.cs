using System;
using System.Collections.Generic;
using System.Globalization;      // CultureInfo: nombres de los meses en español
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Reglas de la pantalla de Inicio: decide QUÉ periodo se consulta (mes actual, últimos meses)
    /// y prepara los datos para las gráficas. La Presentación solo los muestra.
    /// </summary>
    public class NInicio
    {
        // Objeto de la capa Datos (encapsulado: solo se usa dentro de esta clase).
        private readonly DInicio datos = new DInicio();

        /// <summary>Solicita a Datos la cantidad de clientes activos.</summary>
        public int ObtenerClientesActivos()
        {
            return datos.ObtenerClientesActivos();
        }

        /// <summary>Primer día del mes actual a las 00:00 (por ejemplo, 01/10/2026).</summary>
        private static DateTime InicioMesActual()
        {
            DateTime hoy = DateTime.Today;
            return new DateTime(hoy.Year, hoy.Month, 1);
        }

        /// <summary>Indicadores de las tarjetas; los del periodo corresponden al mes actual.</summary>
        public ResumenInicio ObtenerResumen()
        {
            DateTime inicio = InicioMesActual();
            return datos.ObtenerResumen(inicio, inicio.AddMonths(1));
        }

        /// <summary>Ingresos de cada sucursal en el mes actual.</summary>
        public List<DatoGrafica> IngresosPorSucursal()
        {
            DateTime inicio = InicioMesActual();
            return datos.IngresosPorSucursal(inicio, inicio.AddMonths(1));
        }

        /// <summary>
        /// Recepciones de los últimos 'cantidadMeses' meses (incluido el actual).
        /// Los meses sin recepciones se agregan con valor 0 para que la gráfica no tenga huecos.
        /// </summary>
        public List<DatoGrafica> RecepcionesUltimosMeses(int cantidadMeses)
        {
            DateTime inicioPeriodo = InicioMesActual().AddMonths(-(cantidadMeses - 1));
            DateTime finPeriodo = InicioMesActual().AddMonths(1);
            List<DatoGrafica> encontrados = datos.RecepcionesPorMes(inicioPeriodo, finPeriodo);

            CultureInfo espanol = new CultureInfo("es-GT");
            List<DatoGrafica> resultado = new List<DatoGrafica>();

            for (int i = 0; i < cantidadMeses; i++)
            {
                DateTime mes = inicioPeriodo.AddMonths(i);

                // Se busca el mes con el mismo formato que devuelve la capa Datos (AAAA-MM).
                string clave = mes.ToString("yyyy-MM", CultureInfo.InvariantCulture);
                decimal valor = 0;
                foreach (DatoGrafica dato in encontrados)
                {
                    if (dato.Etiqueta == clave)
                    {
                        valor = dato.Valor;
                        break;
                    }
                }

                // Etiqueta para mostrar: mes abreviado en español con mayúscula inicial ("Oct").
                string nombreMes = mes.ToString("MMM", espanol).TrimEnd('.');
                nombreMes = char.ToUpper(nombreMes[0]) + nombreMes.Substring(1);
                resultado.Add(new DatoGrafica(nombreMes, valor));
            }

            return resultado;
        }

        /// <summary>Recepciones según su estado de proceso actual.</summary>
        public List<DatoGrafica> RecepcionesPorEstadoProceso()
        {
            return datos.RecepcionesPorEstadoProceso();
        }

        /// <summary>Servicios con más prendas registradas.</summary>
        public List<DatoGrafica> ServiciosMasSolicitados()
        {
            return datos.ServiciosMasSolicitados();
        }
    }
}
