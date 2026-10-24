using System;
using System.Globalization;   // CultureInfo y NumberStyles: reglas para leer números y fechas

namespace Pfinal_labanderia
{
    /// <summary>
    /// Ayudas de la capa Presentación para convertir lo que el usuario escribe en un TextBox (texto)
    /// a números y fechas, y para mostrar números y fechas en los TextBox.
    /// Es una clase "static": no se crean objetos, se usa directamente (Formato.LeerEntero(...)).
    /// </summary>
    public static class Formato
    {
        // Formatos de fecha aceptados al escribir, por ejemplo: 25/10/2026 14:30  o  25/10/2026
        private static readonly string[] FormatosFecha =
        {
            "dd/MM/yyyy HH:mm", "d/M/yyyy H:mm", "dd/MM/yyyy", "d/M/yyyy"
        };

        /// <summary>Convierte un texto a número entero. Devuelve false si no es un número válido.</summary>
        public static bool LeerEntero(string texto, out int valor)
        {
            return int.TryParse(texto.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out valor);
        }

        /// <summary>
        /// Convierte un texto a decimal. Acepta "35.50", "Q 35.50" y también "35,50".
        /// El punto es el separador decimal (como se usa en Guatemala).
        /// </summary>
        public static bool LeerDecimal(string texto, out decimal valor)
        {
            string limpio = texto.Replace("Q", "").Replace("q", "").Trim();

            if (limpio.Contains(",") && !limpio.Contains("."))
            {
                limpio = limpio.Replace(",", ".");   // "35,50" -> "35.50"
            }
            else
            {
                limpio = limpio.Replace(",", "");    // "1,250.00" -> "1250.00" (separador de miles)
            }

            return decimal.TryParse(limpio, NumberStyles.Number, CultureInfo.InvariantCulture, out valor);
        }

        /// <summary>
        /// Convierte un texto a fecha. Un texto vacío es válido y devuelve null (sin fecha).
        /// Devuelve false si el texto no tiene un formato de fecha aceptado.
        /// </summary>
        public static bool LeerFecha(string texto, out DateTime? fecha)
        {
            fecha = null;
            string limpio = texto.Trim();
            if (limpio == "")
            {
                return true;
            }

            DateTime valor;
            if (DateTime.TryParseExact(limpio, FormatosFecha, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out valor))
            {
                fecha = valor;
                return true;
            }
            return false;
        }

        /// <summary>Texto de una fecha para un TextBox ("" si no hay fecha).</summary>
        public static string MostrarFecha(DateTime? fecha, bool conHora)
        {
            if (!fecha.HasValue)
            {
                return "";
            }
            return fecha.Value.ToString(conHora ? "dd/MM/yyyy HH:mm" : "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        /// <summary>Texto de un monto para un TextBox, con punto decimal (ejemplo: 35.50).</summary>
        public static string MostrarDecimal(decimal valor)
        {
            return valor.ToString("0.00", CultureInfo.InvariantCulture);
        }
    }
}
