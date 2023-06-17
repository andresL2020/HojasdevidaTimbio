using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class RpGeneral
    {
        public int IdPersona { get; set; }
        public string TipoIdentificacion { get; set; }
        public int NumeroDocumento { get; set; } 
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string CargoAspira { get; set; }
        public string EducacionSuperior { get; set; }
        public string Cursos { get; set; }
        public string exp_laboral { get; set; }
    }
}
