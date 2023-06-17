using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class S_Formacion_academica
    {


        public int IdFormacionAcademica { get; set; }
        public String CargoAspira { get; set; }
        public String EducacionBasica { get; set; }
        public String TituloObtenido { get; set; }
        public String MesGrado { get; set; }
        public String AnoGrado { get; set; } 
        public byte[] ActaColegio { get; set; }
        public String ActaColegioNombre { get; set; }
        public byte[] DiplomaColegio { get; set; }
        public String DiplomaColegioNombre { get; set; }
        public String InstituEducativa { get; set; }
        public String ModalidadAcademica { get; set; }
        public int SemestresAprobados { get; set; }
        public String Graduado { get; set; }
        public String NombreTitulo { get; set; }
        public string MesTermino { get; set; }
        public String Ano { get; set; }      
        public String NTarjetaProfecional { get; set; }
        public String NombreInstitucion { get; set; }
        public byte[] ActaUniversitaria { get; set; }
        public String ActaUniversitariaNombre { get; set; }
        public byte[] DiplomaUniversitario { get; set; }
        public String DiplomaUniversitarioNombre { get; set; }
        public String IdPersona { get; set; }

        
    }
}
