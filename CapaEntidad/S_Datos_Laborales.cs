using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class S_Datos_Laborales
    {
        public int IdDatosLaborales { get; set; }
        public String Area { get; set; }
        public String NombreArea { get; set; }
        public String TipoActividad { get; set; }
        public int IdActividad { get; set; }
        public int IdProceso { get; set; }
        public String FechaIngreso { get; set; }
        public String FechaRetiro { get; set; }
        public String HorasContratadas { get; set; }

        public String IdPersona { get; set; }
        public String NombreActividad { get; set; }
        public String NombreProceso{ get; set; }


    }
}
