using System;

namespace Entidad
{
    /// <summary>
    /// Entidad Cliente: representa UNA fila de la tabla dbo.Tbl_Clientes.
    /// Solo guarda datos (propiedades); no sabe nada de SQL ni de formularios.
    /// </summary>
    public class Cliente
    {
        // Cada propiedad corresponde a una columna de la tabla.
        public int IdCliente { get; set; }            // int IDENTITY: lo genera SQL Server
        public string NombreCompleto { get; set; }    // varchar(150), obligatorio
        public string Telefono { get; set; }          // varchar(20), opcional
        public string Correo { get; set; }            // varchar(100), opcional
        public string Direccion { get; set; }         // varchar(250), opcional
        public DateTime? FechaRegistro { get; set; }  // datetime, la pone SQL Server; el "?" permite NULL
        public bool Estado { get; set; }              // bit: true = Activo, false = Inactivo

        /// <summary>
        /// Constructor: un cliente nuevo empieza como Activo,
        /// igual que el valor por defecto de la columna Estado en la tabla.
        /// </summary>
        public Cliente()
        {
            Estado = true;
        }
    }
}
