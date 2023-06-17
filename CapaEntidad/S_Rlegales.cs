using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class S_Rlegales
    {
        public int IdRequisitosLegales { get; set; }
        public string FechaExpedicion { get; set; }
        public byte[] Archivo { get; set; }
        public string archivoNombre { get; set; }

        public int IdCrearRequisitoLegal { get; set; }
        public string IdPersona { get; set; }
    }
}
 