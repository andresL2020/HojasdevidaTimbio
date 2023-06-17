using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Reporte
    {
        private CD_Reporte objCapaDato = new CD_Reporte();

        public bool Editar(string numDocumento, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(numDocumento) || numDocumento == "0")
            {
                Mensaje = "Caduco la session, vuelve a consultar la persona";

            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(numDocumento, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public List<Reporte> Listar(string numero)
            {
            List<Reporte> lista = new List<Reporte>();
            lista = objCapaDato.ListarFormacionAcademicaEduBasic(numero);
            return lista;
        }

        public List<Reporte> ListarGenerarPdf(string numero)
        {
            return objCapaDato.ListarGenerarPdf(numero);
        }

    }
}
