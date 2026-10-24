using System.Collections.Generic;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>
    /// Reglas de negocio de Tipos de prenda (integrado desde LavanderiasMultinegocio, módulo "Prendas").
    /// Los métodos que modifican datos devuelven "OK" (constante Correcto) o el mensaje para el usuario.
    /// </summary>
    public class NTipoPrenda
    {
        public const string Correcto = "OK";

        // Largos máximos: iguales a los de las columnas de dbo.Tbl_TiposPrenda.
        private const int MaxNombre = 100;
        private const int MaxDescripcion = 250;

        // Objeto de la capa Datos (encapsulado: solo se usa dentro de esta clase).
        private readonly DTipoPrenda datos = new DTipoPrenda();

        /// <summary>CONSULTAR: todos los tipos de prenda.</summary>
        public List<TipoPrenda> Consultar()
        {
            return datos.Consultar();
        }

        /// <summary>BUSCAR: tipos de prenda por nombre o descripción. Texto vacío = todos.</summary>
        public List<TipoPrenda> Buscar(string texto)
        {
            texto = NCliente.Limpiar(texto);
            if (texto == "")
            {
                return datos.Consultar();
            }
            return datos.Buscar(texto);
        }

        /// <summary>Valida y guarda un tipo de prenda nuevo.</summary>
        public string Insertar(TipoPrenda prenda)
        {
            string error = Validar(prenda);
            if (error != "")
            {
                return error;
            }

            prenda.IdTipoPrenda = datos.Insertar(prenda);
            return Correcto;
        }

        /// <summary>Valida y actualiza un tipo de prenda existente.</summary>
        public string Actualizar(TipoPrenda prenda)
        {
            if (prenda.IdTipoPrenda <= 0)
            {
                return "Primero seleccione un tipo de prenda.";
            }

            string error = Validar(prenda);
            if (error != "")
            {
                return error;
            }

            if (!datos.Actualizar(prenda))
            {
                return "El tipo de prenda ya no existe en la base de datos.";
            }
            return Correcto;
        }

        /// <summary>Elimina un tipo de prenda por su código.</summary>
        public string Eliminar(int idTipoPrenda)
        {
            if (idTipoPrenda <= 0)
            {
                return "Primero seleccione un tipo de prenda.";
            }

            if (!datos.Eliminar(idTipoPrenda))
            {
                return "El tipo de prenda ya no existe en la base de datos.";
            }
            return Correcto;
        }

        /// <summary>Revisa los datos. Devuelve "" si son válidos o el mensaje del primer error.</summary>
        private string Validar(TipoPrenda prenda)
        {
            prenda.Nombre = NCliente.Limpiar(prenda.Nombre);
            prenda.Descripcion = NCliente.Limpiar(prenda.Descripcion);

            if (prenda.Nombre == "")
            {
                return "El nombre es obligatorio.";
            }
            if (prenda.Nombre.Length > MaxNombre)
            {
                return "El nombre admite como máximo " + MaxNombre + " caracteres.";
            }
            if (prenda.Descripcion.Length > MaxDescripcion)
            {
                return "La descripción admite como máximo " + MaxDescripcion + " caracteres.";
            }

            return "";
        }
    }
}
