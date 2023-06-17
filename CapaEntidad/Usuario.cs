using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuario
    {
        //Nombres, Apelldios, Correo, Clave, Reestablecer, Activo, Fecharegistro

        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apelldios { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public bool Reestablecer { get; set; }
        public bool Activo { get; set; }
        public string Fecharegistro { get; set; }
        public int IdRol { get; set; }
    }
}
