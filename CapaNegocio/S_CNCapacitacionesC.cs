using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class S_CNCapacitacionesC
    {
        private S_CD_CapacitacionesC objCapaDato = new S_CD_CapacitacionesC();

        public List<S_CapacitacionesC> Listar(string numero)
        {
            return objCapaDato.Listar(numero);
        }
        
        public List<S_CapacitacionesC> ListarArchivo()
        {
            return objCapaDato.ListarArchivo();
        }
        public int RegistrarCursos(S_CapacitacionesC obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.TipoFormacion) || string.IsNullOrWhiteSpace(obj.TipoFormacion))
            {
                Mensaje = "El Tipo de formacion  no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El campo Nombre  es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.EstadoFormacion) || string.IsNullOrWhiteSpace(obj.EstadoFormacion))
            {
                Mensaje = "El campo Estado de formacion es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.FechaInicio) || string.IsNullOrWhiteSpace(obj.FechaInicio))
            {
                Mensaje = "El campo Fecha inicio es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.FechaFinalizacion) || string.IsNullOrWhiteSpace(obj.FechaFinalizacion))
            {
                Mensaje = "El campo fecha de finalizacion  es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.ArchivoNombre) || string.IsNullOrWhiteSpace(obj.ArchivoNombre))
            {
                Mensaje = "El campo adjuntar  es obligatorio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.RegistrarCursos(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }
        public bool EditarCursos(S_CapacitacionesC obj, out String Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.TipoFormacion) || string.IsNullOrWhiteSpace(obj.TipoFormacion))
            {
                Mensaje = "El Tipo de formacion  no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El campo Nombre  es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.EstadoFormacion) || string.IsNullOrWhiteSpace(obj.EstadoFormacion))
            {
                Mensaje = "El campo Estado de formacion es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.FechaInicio) || string.IsNullOrWhiteSpace(obj.FechaInicio))
            {
                Mensaje = "El campo Fecha inicio es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.FechaFinalizacion) || string.IsNullOrWhiteSpace(obj.FechaFinalizacion))
            {
                Mensaje = "El campo fecha de finalizacion  es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.ArchivoNombre) || string.IsNullOrWhiteSpace(obj.ArchivoNombre))
            {
                Mensaje = "El campo adjuntar  es obligatorio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.EditarCursos(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool EliminarCapacitacion(int id, out string Mensaje)
        {
            return objCapaDato.EliminarCapacitacion(id, out Mensaje);
        }
    }
}
