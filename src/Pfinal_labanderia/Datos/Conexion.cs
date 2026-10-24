using System;
using System.Configuration;      // ConfigurationManager: lee App.config (y Conexion.config)
using System.Data.SqlClient;     // SqlConnection, SqlException: conexión con SQL Server

namespace Datos
{
    /// <summary>
    /// Centraliza la conexión a SQL Server.
    /// Todas las clases de la capa Datos piden aquí su conexión; así la cadena
    /// está en un solo lugar (Conexion.config) y no se repite ni se escribe en el código.
    /// Solo la capa Datos abre conexiones: Presentación y Negocio nunca usan SqlConnection.
    /// </summary>
    public class Conexion
    {
        // Nombre de la cadena dentro de <connectionStrings> (archivo Conexion.config).
        private const string NombreCadena = "ConexionSQLServer";

        /// <summary>
        /// Lee la cadena de conexión.
        /// App.config pertenece al proyecto de Presentación porque es el programa que se ejecuta.
        /// App.config no tiene la cadena: la toma de Conexion.config (configSource), un archivo que
        /// no se sube a GitHub para que la contraseña no quede publicada.
        /// </summary>
        public static string ObtenerCadena()
        {
            ConnectionStringSettings config = ConfigurationManager.ConnectionStrings[NombreCadena];

            // Si la cadena no existe, se avisa con un mensaje claro en lugar de un error confuso.
            if (config == null)
            {
                throw new ConfigurationErrorsException(
                    "No existe la cadena '" + NombreCadena + "' en Conexion.config.");
            }

            return config.ConnectionString;
        }

        /// <summary>
        /// Devuelve una conexión NUEVA y CERRADA.
        /// Quien la use debe abrirla dentro de un bloque using, que la cierra al terminar.
        /// </summary>
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(ObtenerCadena());
        }

        /// <summary>
        /// Prueba la conexión: abre y cierra una conexión con SQL Server.
        /// Devuelve true si funciona. En 'mensaje' deja un texto claro para mostrar al usuario,
        /// tanto si la conexión funcionó como si falló.
        /// </summary>
        public static bool ProbarConexion(out string mensaje)
        {
            try
            {
                // using garantiza que la conexión se cierre aunque ocurra un error.
                using (SqlConnection cn = ObtenerConexion())
                {
                    // Si el servidor, el usuario o la base están mal, el error ocurre aquí.
                    cn.Open();

                    mensaje = "Conexión exitosa con SQL Server.\n" +
                              "Servidor: " + cn.DataSource + "\n" +
                              "Base de datos: " + cn.Database;
                    return true;
                }
            }
            catch (ConfigurationErrorsException ex)
            {
                // Falta la cadena, falta el archivo Conexion.config o tiene un error de formato.
                // Es lo que verá quien clone el repositorio sin crear antes su Conexion.config.
                mensaje = "Problema con la configuración de la conexión: " + ex.Message + "\n\n" +
                          "Si falta Conexion.config, créelo copiando Conexion.config.ejemplo " +
                          "y escriba en él la contraseña real.";
                return false;
            }
            catch (ArgumentException ex)
            {
                // SqlConnection rechaza cadenas mal escritas (por ejemplo, una palabra desconocida).
                mensaje = "La cadena de conexión de Conexion.config está mal escrita.\n\n" +
                          "Detalle técnico: " + ex.Message;
                return false;
            }
            catch (SqlException ex)
            {
                // Errores propios de SQL Server: se traducen a un mensaje comprensible.
                mensaje = ExplicarErrorSql(ex);
                return false;
            }
            catch (Exception ex)
            {
                // Cualquier otro error que no se esperaba.
                mensaje = "Error inesperado al conectar: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Convierte los errores más comunes de SQL Server en una explicación sencilla.
        /// Cada SqlException trae un número (ex.Number) que indica la causa.
        /// </summary>
        private static string ExplicarErrorSql(SqlException ex)
        {
            string explicacion;

            switch (ex.Number)
            {
                case 18456:
                    explicacion = "SQL Server rechazó el inicio de sesión. " +
                                  "Revise el usuario y la contraseña en Conexion.config.";
                    break;

                case 4060:
                    explicacion = "La base de datos indicada en Conexion.config no existe " +
                                  "o el usuario no tiene permiso para abrirla.";
                    break;

                // Errores de red: el programa no pudo llegar al servidor.
                case -1:
                case 2:
                case 26:
                case 40:
                case 53:
                case 1225:   // El equipo rechazó la conexión (no hay SQL Server en ese puerto).
                case 10060:
                case 10061:
                case 11001:
                    explicacion = "No se pudo llegar al servidor SQL Server. Revise que esté encendido " +
                                  "(en este equipo corre en Docker) y que el servidor y el puerto de Conexion.config sean correctos.";
                    break;

                default:
                    explicacion = "SQL Server devolvió un error al intentar conectar.";
                    break;
            }

            // Se agrega el número y el detalle técnico por si hace falta buscar la causa.
            return explicacion + "\n\nDetalle técnico (error " + ex.Number + "): " + ex.Message;
        }
    }
}
