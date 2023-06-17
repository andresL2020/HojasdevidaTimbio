using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Actividad
    {
        private CD_Actividad objCapaDato = new CD_Actividad();

        public List<Actividad> Listar()
        {
            return objCapaDato.Listar();
        }

        public List<Actividad> ListarActividad_Sindicato(string tActividad)
        {
            return objCapaDato.ListarActividad_Sindicato(tActividad);
        }

        public int Registrar(Actividad obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreActividad) || string.IsNullOrWhiteSpace(obj.NombreActividad))
            {
                Mensaje = "La actividad no puede ser vacio";

            }else if (string.IsNullOrEmpty(obj.TipoActividad) || string.IsNullOrWhiteSpace(obj.TipoActividad))
            {
                Mensaje = "El tipo de  actividad no puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }


        public bool Editar(Actividad obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreActividad) || string.IsNullOrWhiteSpace(obj.NombreActividad))
            {
                Mensaje = "La actividad no puede ser vacio";

            }
            else if (string.IsNullOrEmpty(obj.TipoActividad) || string.IsNullOrWhiteSpace(obj.TipoActividad))
            {
                Mensaje = "El tipo de  actividad no puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }


        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }
    }
}
