using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_DatosLaborales
    {
        private CD_DatosLaborales objCapaDato = new CD_DatosLaborales();

        public List<DatosLaborales> Listar(string numero)
        {
            return objCapaDato.Listar(numero);
        }


        public bool EditarDatoLaboral(int IdPersona, int IdDlaboral, string Cumple, string Observacion, out string Mensaje)
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
                return objCapaDato.EditarDatoLaboral(IdPersona, IdDlaboral, Cumple, Observacion, out Mensaje);
            }
            else
            {
                return false;
            }
        }
    }
}
