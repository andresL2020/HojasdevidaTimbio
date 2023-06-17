using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_ExperienciaLaboral
    {
        private CD_ExperienciaLaboral objCapaDato = new CD_ExperienciaLaboral();

        public List<ExperienciaLaboral> Listar(string numero)
        {
            return objCapaDato.Listar(numero);
        }


        public bool EditarExpLaboral(int IdPersona, int IdExperienciaL, string Cumple, string Observacion, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(Cumple))
            {
                Mensaje = "Selecciona una opcion";

            }
            else if (string.IsNullOrEmpty(Observacion))
            {
                Mensaje = "Debes agregar un comentario";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.EditarExpLaboral(IdPersona, IdExperienciaL, Cumple, Observacion, out Mensaje);
            }
            else
            {
                return false;
            }
        }

    }
}
