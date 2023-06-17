using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Requisitos
    {
        //REQUISITOS_LEGALES
        public int IdRequisitosLegales { get; set; }
        public string NombreRequisito { get; set; }
        public string FechaExpedicion { get; set; }
        public byte[] Archivo { get; set; }
        public string Cumple { get; set; }
        public string Observacion { get; set; }
        public int IdPersona { get; set; }
    }
}
