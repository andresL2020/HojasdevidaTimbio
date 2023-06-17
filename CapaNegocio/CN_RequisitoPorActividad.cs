using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_RequisitoPorActividad

    {
        private CD_RequisitoPorActividad objCapaDato = new CD_RequisitoPorActividad();

        public List<RequisitoPorActividad> Listar()
        {
            return objCapaDato.Listar();
        }

        public List<RequisitoPorActividad> ListarParaSindicato(int idActivdad)
        {
            return objCapaDato.ListarParaSindicato(idActivdad);
        }

        public int Registrar(int idActividad, int idRequisitoL, out string Mensaje)
        {
            Mensaje = string.Empty;

            return objCapaDato.Registrar(idActividad,idRequisitoL, out Mensaje);

        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }
    }
}
