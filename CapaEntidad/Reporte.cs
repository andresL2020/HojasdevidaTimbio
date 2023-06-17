using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Reporte
    {
        public int oid{ get; set; }
        public string Item { get; set; }
        public string Cumple { get; set; }
        public string Observacion { get; set; }
        public string FechaVerificacion{ get; set; }        
        public string FechaResumen{ get; set; }
        public int Numero { get; set; }
        public S_Persona objPersona { get; set; }        
        public S_Datos_Laborales objLaborale { get; set; }

    }
}
