using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class S_Persona
    {
        public int IdPersona { get; set; }
        public string TipoIdentificacion { get; set; }
        public int NumeroDocumento { get; set; }
        public string Genero { get; set; }
        
        public string Pais { get; set; }
        public string LugarExpedicion { get; set; }
        public String FechaExpedicion { get; set; }
        public string EstadoCivil { get; set; }
        public int NumeroHijos { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string LibretaMilitar { get; set; }
        public int NumeroLibreta { get; set; }
        public int DistritoMilitar { get; set; }
        public string FechaNacimiente { get; set; }
        public string PaisNacimiento { get; set; }
        public string DeapartamentoNacimiento { get; set; }
        public string CiudadNacimiento { get; set; }
        public string Direccion { get; set; }
        public string PaisDireccion { get; set; }
        public string DepartamentoResidencia { get; set; }
        public string CiudadDireccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string GrupoSanguineo { get; set; }
        public string GrupoEtnico { get; set; }
        public string Profesion { get; set; }
        public string Eps { get; set; }
        public string FondoPensiones { get; set; }
        public string Arl { get; set; }
        public Boolean Estado { get; set; }
        public String Estadofecha { get; set; }

        // public String  NombreCompleto  { get; set; }

        // public int PersonaPerId { get; set; }
    }
}
