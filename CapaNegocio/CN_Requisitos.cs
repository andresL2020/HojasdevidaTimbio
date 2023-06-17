using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{

    public class CN_Requisitos
    {
        private CD_Requisitos objCapaDato = new CD_Requisitos();

        public List<Requisitos> Listar(string numero)
        {
            return objCapaDato.Listar(numero);
        }

        public bool EditarRequisito(int IdPersona, int IdRequisito, string Cumple, string Observacion, out string Mensaje)
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
                return objCapaDato.EditarRequisito(IdPersona, IdRequisito, Cumple, Observacion, out Mensaje);
            }
            else
            {
                return false;
            }
        }
    }
}
