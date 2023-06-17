using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DatosLaborales
    {
        //DATOS LABORALES
        public int IdDatosLaborales { get; set; }
        public string Area { get; set; }
        public string NombreArea { get; set; }
        public string NombreActividad { get; set; }
        public string TipoActividad { get; set; }
        public string NombreProceso { get; set; }
        public string HorasContratadas { get; set; }
        public string FechaIngreso { get; set; }
        public string FechaRetiro { get; set; }
        public string Cumple { get; set; }
        public string Observacion { get; set; }
        public int IdPersona { get; set; }
    }
}
