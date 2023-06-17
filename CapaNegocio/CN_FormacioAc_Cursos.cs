using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_FormacioAc_Cursos
    {
        private CD_FormacioAc_Cursos objCapaDato = new CD_FormacioAc_Cursos();

        public List<FormacionAcademica> ListarFormacion(string numero)
        {
            return objCapaDato.ListarFormacion(numero);
        }

        public List<CapacitacionesCursos> ListarCuros(string numero)
        {
            return objCapaDato.ListarCuros(numero);
        }

        public bool Editar(int IdPersona, int IdFAcademica, string Numero, string Cumple, string Observacion, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(Cumple) || Cumple == "Sin Seleccionar")
            {
                Mensaje = "Selecciona otra opcion diferente a (SIN SELECCIONAR)";

            }
            else if (string.IsNullOrEmpty(Observacion) || Observacion == "Agrega un Comentario")
            {
                Mensaje = "Debes agregar un comentario diferente";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(IdPersona, IdFAcademica, Numero, Cumple, Observacion, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool EditarCurso(int IdPersona, int IdCurso, string Cumple, string Observacion, out string Mensaje)
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
                return objCapaDato.EditarCurso(IdPersona, IdCurso, Cumple, Observacion, out Mensaje);
            }
            else
            {
                return false;
            }
        }
    }
}
