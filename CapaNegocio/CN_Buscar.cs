using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Buscar
    {
        private CD_Buscar objCapaDato = new CD_Buscar();

        public List<Buscar> Listar(string documento)
        {
            return objCapaDato.Listar(documento);
        }
    }
}
