using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Idiomas
    {
        private CD_Idiomas objCapaDato = new CD_Idiomas();

        public List<Idiomas> Listar(string numero)
        {
            return objCapaDato.Listar(numero);
        }
    }
}
