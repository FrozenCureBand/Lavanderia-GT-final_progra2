using System;
using System.Collections.Generic;
using Datos;
using Entidad;

namespace Negocio
{
    /// <summary>Valida los datos básicos del rol antes de guardarlo.</summary>
    public class NRol
    {
        private readonly DRol datos = new DRol();
        public List<Rol> Consultar() { return datos.Consultar(); }
        public List<Acceso> ConsultarAccesos(int idRol) { return datos.ConsultarAccesos(idRol); }
        public void Guardar(Rol rol, List<Acceso> accesos)
        {
            rol.NombreRol = (rol.NombreRol ?? "").Trim();
            rol.Descripcion = (rol.Descripcion ?? "").Trim();
            if (rol.NombreRol == "") throw new Exception("Escriba el nombre del rol.");
            if (rol.NombreRol.Length > 50) throw new Exception("El nombre admite hasta 50 caracteres.");
            datos.Guardar(rol, accesos);
        }
        public void Eliminar(int idRol)
        {
            if (idRol <= 0) throw new Exception("Seleccione un rol.");
            datos.Eliminar(idRol);
        }
    }
}
