using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
//IdActividad int primary key identity,
//NombreActividad varchar(80),
//TipoActividad varchar(45),
    public class Actividad
    {
        public int IdActividad { get; set; }
        public string NombreActividad { get; set; }
        public string TipoActividad { get; set; }
    }
}
