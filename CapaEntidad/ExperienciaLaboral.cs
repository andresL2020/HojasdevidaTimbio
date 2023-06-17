using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ExperienciaLaboral
    {
        //EXPERIENCIA LABORAL
        public int IdExperienciaLaboral { get; set; }
        public string EmpresaEntidad { get; set; }
        public string Pais { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string SectorEmpresa { get; set; }
        public string CargoContratoActual { get; set; }
        public string Dependencia { get; set; }
        public string FechaIngreso { get; set; }
        public string FechaEgreso { get; set; }
        public byte[] AdjuntarSoporte { get; set; }
        public string Cumple { get; set; }
        public string Observacion { get; set; }
        public int IdPersona { get; set; }
    }
}
