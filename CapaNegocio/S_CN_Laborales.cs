using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class S_CN_Laborales
    {
        private S_CD_Laborales objCapaDato = new S_CD_Laborales();

        public List<S_Datos_Laborales> Listar(string numero)
        {
            return objCapaDato.Listar(numero);
        }
        public int RegistrarDatosLaborales(S_Datos_Laborales obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Area) || string.IsNullOrWhiteSpace(obj.Area))
            {
                Mensaje = "El campo area es obligatorio";
            }
            
            else if (string.IsNullOrEmpty(obj.NombreArea) || string.IsNullOrWhiteSpace(obj.NombreArea))
            {
                Mensaje = "El campo Nombre area es obligatorio";
            }
            //else if (string.IsNullOrEmpty(obj.TipoActividad) || string.IsNullOrWhiteSpace(obj.TipoActividad))
            //{
            //    Mensaje = "El campo es obligatorio";
            //}
            else if (string.IsNullOrEmpty(obj.FechaIngreso) || string.IsNullOrWhiteSpace(obj.FechaIngreso))
            {
                Mensaje = "El campo Fecha ingreso es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.HorasContratadas) || string.IsNullOrWhiteSpace(obj.HorasContratadas))
            {
                Mensaje = "El campo Horas contratadas  es obligatorio";
            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.RegistrarDatosLaborales(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }
        public bool EditarDatosLaborales(S_Datos_Laborales obj, out String Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Area) || string.IsNullOrWhiteSpace(obj.Area))
            {
                Mensaje = "El campo area no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.NombreArea) || string.IsNullOrWhiteSpace(obj.NombreArea))
            {
                Mensaje = "El campo  Nombre area es obligatorio";
            }
            //else if (string.IsNullOrEmpty(obj.TipoActividad) || string.IsNullOrWhiteSpace(obj.TipoActividad))
            //{
            //    Mensaje = "Este campo numero documento es obligatorio";
            //}
            else if (string.IsNullOrEmpty(obj.FechaIngreso) || string.IsNullOrWhiteSpace(obj.FechaIngreso))
            {
                Mensaje = "El campo fecha ingreso  es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.HorasContratadas) || string.IsNullOrWhiteSpace(obj.HorasContratadas))
            {
                Mensaje = "El campo Horas contratadas  es obligatorio";
            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.EditarDatosLaborales(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool EliminarDLaborales(int id, out string Mensaje)
        {
            return objCapaDato.EliminarDLaborales(id, out Mensaje);
        }
    }
}
