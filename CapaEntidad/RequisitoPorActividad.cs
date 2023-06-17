using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{

    public class RequisitoPorActividad
    {
        public int IdRequisitoActividad { get; set; }
        public Actividad oActividad { get; set; }
        public CrearRequisitoLegal oRequisitoLegal { get; set; }
    }
}
