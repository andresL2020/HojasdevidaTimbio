using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class S_Ex_Laboral
    {
        public int IdExperienciaLaboral { get; set; }
        public String EmpresaEntidad { get; set; }
        public String Pais { get; set; }
        public String Departamento { get; set; }
        public String Ciudad { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public String CorreoElectronico { get; set; }
        public String SectorEmpresa { get; set; }
        public String CargoContratoActual { get; set; }
        public String Dependencia { get; set; }
        public String FechaIngreso { get; set; }
        public String FechaEgreso { get; set; }
        public byte[] AdjuntarSoporte { get; set; } 
        public string AdjuntarSoporteNombre { get; set; }
        public string IdPersona { get; set; } 
    }
}
