using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CapacitacionesCursos
    {
        //PERSONA
        public int IdPersona { get; set; }
        public string TipoIdentificacion { get; set; }
        public int NumeroDocumento { get; set; }
        public string Genero { get; set; }
        public string Nacionalidad { get; set; } //no la an registrado en la BBDD
        public string Pais { get; set; }
        public string LugarExpedicion { get; set; }
        public string FechaExpedicion { get; set; }
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
        public int PersonaPerId { get; set; }
        public string FechaRevision { get; set; }
        public int Estado { get; set; }
        public string EstadoFecha { get; set; }
        public string Verificado { get; set; }
        public string NombreCompleto { get; set; }

        //CAPACITACIONE_CURSOS
        public int idCapacitacionesCursos { get; set; }
        public string TipoFormacion { get; set; }
        public string Nombre { get; set; }
        public string EstadoFormacion { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFinalizacion { get; set; }
        //public byte[] Archivo { get; set; }
        public string Archivo { get; set; }
        public string Cumple { get; set; }
        public string Observacion { get; set; }
        public int IdPersonaCursos { get; set; }
    }
}
