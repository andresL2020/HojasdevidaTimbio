using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class S_CNF_Academica
    {
        private S_CD_Facademica objCapaDato = new S_CD_Facademica();

        public List<S_Formacion_academica> Listar(string numero)
        {
            return objCapaDato.Listar(numero);
        }

        public List<S_Formacion_academica> ListarArchivo()
        {
            return objCapaDato.ListarArchivo();
        }

        public int RegistrarFormacion(S_Formacion_academica obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            

            if (string.IsNullOrEmpty(obj.CargoAspira) || string.IsNullOrWhiteSpace(obj.CargoAspira))
            {
                Mensaje = "El proceso no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.EducacionBasica) || string.IsNullOrWhiteSpace(obj.EducacionBasica))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.TituloObtenido) || string.IsNullOrWhiteSpace(obj.TituloObtenido))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.MesGrado) || string.IsNullOrWhiteSpace(obj.MesGrado))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.AnoGrado) || string.IsNullOrWhiteSpace(obj.AnoGrado))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.InstituEducativa) || string.IsNullOrWhiteSpace(obj.InstituEducativa))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.ModalidadAcademica) || string.IsNullOrWhiteSpace(obj.ModalidadAcademica))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
           
            else if (string.IsNullOrEmpty(obj.Graduado) || string.IsNullOrWhiteSpace(obj.Graduado))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.NombreTitulo) || string.IsNullOrWhiteSpace(obj.NombreTitulo))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.MesTermino) || string.IsNullOrWhiteSpace(obj.MesTermino))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Ano) || string.IsNullOrWhiteSpace(obj.Ano))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.NTarjetaProfecional) || string.IsNullOrWhiteSpace(obj.NTarjetaProfecional))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.NombreInstitucion) || string.IsNullOrWhiteSpace(obj.NombreInstitucion))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.RegistrarFormacion(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        public bool EditarFormacion(S_Formacion_academica obj, out String Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.CargoAspira) || string.IsNullOrWhiteSpace(obj.CargoAspira))
            {
                Mensaje = "El proceso no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.EducacionBasica) || string.IsNullOrWhiteSpace(obj.EducacionBasica))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.TituloObtenido) || string.IsNullOrWhiteSpace(obj.TituloObtenido))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.MesGrado) || string.IsNullOrWhiteSpace(obj.MesGrado))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.AnoGrado) || string.IsNullOrWhiteSpace(obj.AnoGrado))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.InstituEducativa) || string.IsNullOrWhiteSpace(obj.InstituEducativa))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.ModalidadAcademica) || string.IsNullOrWhiteSpace(obj.ModalidadAcademica))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
           
            else if (string.IsNullOrEmpty(obj.Graduado) || string.IsNullOrWhiteSpace(obj.Graduado))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.NombreTitulo) || string.IsNullOrWhiteSpace(obj.NombreTitulo))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.MesTermino) || string.IsNullOrWhiteSpace(obj.MesTermino))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Ano) || string.IsNullOrWhiteSpace(obj.Ano))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.NTarjetaProfecional) || string.IsNullOrWhiteSpace(obj.NTarjetaProfecional))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.NombreInstitucion) || string.IsNullOrWhiteSpace(obj.NombreInstitucion))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.EditarFormacion(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool EliminarFormacion(int id, out string Mensaje)
        {
            return objCapaDato.EliminarFormacion(id, out Mensaje);
        }
    }
}
