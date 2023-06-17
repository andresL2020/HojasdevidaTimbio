using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_RpGeneral
    {
        private CD_RpGeneral objCapaDato = new CD_RpGeneral();

        public List<RpGeneral> Listar(string exLaboral)
        {
            return objCapaDato.Listar(exLaboral);
        }
    }
}
