using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Procesos
    {
        private CD_Procesos objCapaDato = new CD_Procesos();

        public List<Procesos> Listar()
        {
            return objCapaDato.Listar();
        }


        public int Registrar(Procesos obj, out string Mensaje)
        {
            Mensaje= string.Empty;

            if(string.IsNullOrEmpty(obj.NombreProceso) || string.IsNullOrWhiteSpace(obj.NombreProceso))
            {
                Mensaje = "El proceso no puede ser vacio";
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


        public bool Editar(Procesos obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreProceso) || string.IsNullOrWhiteSpace(obj.NombreProceso))
            {
                Mensaje = "El proceso no puede ser vacio";
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
