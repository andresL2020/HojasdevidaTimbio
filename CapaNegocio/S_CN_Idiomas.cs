using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class S_CN_Idiomas
    {
        private S_CD_Idiomas objCapaDato = new S_CD_Idiomas();

        public List<S_Idiomas> Listar(string numero)
        {
            return objCapaDato.Listar(numero);
        }

        public int RegistrarIdioma(S_Idiomas obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Idioma) || string.IsNullOrWhiteSpace(obj.Idioma))
            {
                Mensaje = "El proceso no puede ser vacio";
            }
            //else if (string.IsNullOrEmpty(obj.LoHabla) || string.IsNullOrWhiteSpace(obj.LoHabla))
            //{
            //    Mensaje = "Este campo numero documento es obligatorio";
            //}
            else if (string.IsNullOrEmpty(obj.LoLee) || string.IsNullOrWhiteSpace(obj.LoLee))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.LoEscribe) || string.IsNullOrWhiteSpace(obj.LoEscribe))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.RegistrarIdioma(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }
             public bool EditarIdiomas(S_Idiomas obj, out String Mensaje){
            
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Idioma) || string.IsNullOrWhiteSpace(obj.Idioma))
            {
                Mensaje = "El proceso no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.LoHabla) || string.IsNullOrWhiteSpace(obj.LoHabla))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.LoLee) || string.IsNullOrWhiteSpace(obj.LoLee))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.LoEscribe) || string.IsNullOrWhiteSpace(obj.LoEscribe))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.EditarIdiomas(obj, out Mensaje);
            }
            else
            {
                return false;
            }
            }

            public bool EliminarIdioma(int id, out string Mensaje)
            {
                return objCapaDato.EliminarIdioma(id, out Mensaje);
            }
    }

    
}
