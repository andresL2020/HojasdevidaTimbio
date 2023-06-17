using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class S_CN_Persona
    {
        private S_CD_Persona objCapaDato = new S_CD_Persona();
        public List<S_Persona> Listar()
        {
            return objCapaDato.Listar();
        }

        private CD_nombreCompleto objCapaDato1 = new CD_nombreCompleto();
        public List<NombreCompleto> obtener()
        {
            return objCapaDato1.Listar();

        }
        public int RegistrarPerson(S_Persona obj, NombreCompleto obj2, out string Mensaje)
        {
            Mensaje = string.Empty;
            string numeroDocumento = obj.NumeroDocumento.ToString();


            if (string.IsNullOrEmpty(obj.TipoIdentificacion) || string.IsNullOrWhiteSpace(obj.TipoIdentificacion))
            {
                Mensaje = "Este campo identificacion es obligatorio";
            }
            else if (string.IsNullOrEmpty(numeroDocumento) || string.IsNullOrWhiteSpace(numeroDocumento))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Genero) || string.IsNullOrWhiteSpace(obj.Genero))
            {
                Mensaje = "Este campo genero es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Pais) || string.IsNullOrWhiteSpace(obj.Pais))
            {
                Mensaje = "Este campo pais es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.LugarExpedicion) || string.IsNullOrWhiteSpace(obj.LugarExpedicion))
            {
                Mensaje = "Este campo lugar expedicion es obligatorio";
            }
          
            else if (string.IsNullOrEmpty(obj.EstadoCivil) || string.IsNullOrWhiteSpace(obj.EstadoCivil))
            {
                Mensaje = "Este campo estado civil es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.PrimerNombre) || string.IsNullOrWhiteSpace(obj.PrimerNombre))
            {
                Mensaje = "Este campo primer nombre es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.SegundoNombre) || string.IsNullOrWhiteSpace(obj.SegundoNombre))
            {
                Mensaje = "Este campo segundo nombre es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.PrimerApellido) || string.IsNullOrWhiteSpace(obj.PrimerApellido))
            {
                Mensaje = "Este campo primer apellido es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.SegundoApellido) || string.IsNullOrWhiteSpace(obj.SegundoApellido))
            {
                Mensaje = "Este campo segundo apellido es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.LibretaMilitar) || string.IsNullOrWhiteSpace(obj.LibretaMilitar))
            {
                Mensaje = "Este campo libreta militar es obligatorio";
            }      
            else if (string.IsNullOrEmpty(obj.PaisNacimiento) || string.IsNullOrWhiteSpace(obj.PaisNacimiento))
            {
                Mensaje = "Este campo pais nacimiento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.DeapartamentoNacimiento) || string.IsNullOrWhiteSpace(obj.DeapartamentoNacimiento))
            {
                Mensaje = "Este campo departamento nacimiento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.CiudadNacimiento) || string.IsNullOrWhiteSpace(obj.CiudadNacimiento))
            {
                Mensaje = "Este campo ciudad nacimiento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
            {
                Mensaje = "Este campo direccion es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.PaisDireccion) || string.IsNullOrWhiteSpace(obj.PaisDireccion))
            {
                Mensaje = "Este campo pais direccion es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.DepartamentoResidencia) || string.IsNullOrWhiteSpace(obj.DepartamentoResidencia))
            {
                Mensaje = "Este campodepartamento residencia es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.CiudadDireccion) || string.IsNullOrWhiteSpace(obj.CiudadDireccion))
            {
                Mensaje = "Este campo ciudad direccion es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
            {
                Mensaje = "Este campo telefono es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.CorreoElectronico) || string.IsNullOrWhiteSpace(obj.CorreoElectronico))
            {
                Mensaje = "Este campo correo electronico es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Profesion) || string.IsNullOrWhiteSpace(obj.Profesion))
            {
                Mensaje = "Este campo profesion es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Eps) || string.IsNullOrWhiteSpace(obj.Eps))
            {
                Mensaje = "Este campo eps es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.FondoPensiones) || string.IsNullOrWhiteSpace(obj.FondoPensiones))
            {
                Mensaje = "Este campo fondo pensiones es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Arl) || string.IsNullOrWhiteSpace(obj.Arl))
            {
                Mensaje = "Este campo arl es obligatorio";
            }



            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.RegistrarPerson(obj, out Mensaje);

            }
            else
            {
                return 0;
            }
        }

        public bool EditarPerson(S_Persona obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            string numeroDocumento = obj.NumeroDocumento.ToString();
          

            if (string.IsNullOrEmpty(obj.TipoIdentificacion) || string.IsNullOrWhiteSpace(obj.TipoIdentificacion))
            {
                Mensaje = "Este campo identificacion es obligatorio";
            }
            else if (string.IsNullOrEmpty(numeroDocumento) || string.IsNullOrWhiteSpace(numeroDocumento))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Genero) || string.IsNullOrWhiteSpace(obj.Genero))
            {
                Mensaje = "Este campo genero es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Pais) || string.IsNullOrWhiteSpace(obj.Pais))
            {
                Mensaje = "Este campo pais es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.LugarExpedicion) || string.IsNullOrWhiteSpace(obj.LugarExpedicion))
            {
                Mensaje = "Este campo lugar expedicion es obligatorio";
            }

            else if (string.IsNullOrEmpty(obj.EstadoCivil) || string.IsNullOrWhiteSpace(obj.EstadoCivil))
            {
                Mensaje = "Este campo estado civil es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.PrimerNombre) || string.IsNullOrWhiteSpace(obj.PrimerNombre))
            {
                Mensaje = "Este campo primer nombre es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.SegundoNombre) || string.IsNullOrWhiteSpace(obj.SegundoNombre))
            {
                Mensaje = "Este campo segundo nombre es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.PrimerApellido) || string.IsNullOrWhiteSpace(obj.PrimerApellido))
            {
                Mensaje = "Este campo primer apellido es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.SegundoApellido) || string.IsNullOrWhiteSpace(obj.SegundoApellido))
            {
                Mensaje = "Este campo segundo apellido es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.LibretaMilitar) || string.IsNullOrWhiteSpace(obj.LibretaMilitar))
            {
                Mensaje = "Este campo libreta militar es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.PaisNacimiento) || string.IsNullOrWhiteSpace(obj.PaisNacimiento))
            {
                Mensaje = "Este campo pais nacimiento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.DeapartamentoNacimiento) || string.IsNullOrWhiteSpace(obj.DeapartamentoNacimiento))
            {
                Mensaje = "Este campo departamento nacimiento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.CiudadNacimiento) || string.IsNullOrWhiteSpace(obj.CiudadNacimiento))
            {
                Mensaje = "Este campo ciudad nacimiento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
            {
                Mensaje = "Este campo direccion es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.PaisDireccion) || string.IsNullOrWhiteSpace(obj.PaisDireccion))
            {
                Mensaje = "Este campo pais direccion es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.DepartamentoResidencia) || string.IsNullOrWhiteSpace(obj.DepartamentoResidencia))
            {
                Mensaje = "Este campodepartamento residencia es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.CiudadDireccion) || string.IsNullOrWhiteSpace(obj.CiudadDireccion))
            {
                Mensaje = "Este campo ciudad direccion es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
            {
                Mensaje = "Este campo telefono es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.CorreoElectronico) || string.IsNullOrWhiteSpace(obj.CorreoElectronico))
            {
                Mensaje = "Este campo correo electronico es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Profesion) || string.IsNullOrWhiteSpace(obj.Profesion))
            {
                Mensaje = "Este campo profesion es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Eps) || string.IsNullOrWhiteSpace(obj.Eps))
            {
                Mensaje = "Este campo eps es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.FondoPensiones) || string.IsNullOrWhiteSpace(obj.FondoPensiones))
            {
                Mensaje = "Este campo fondo pensiones es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Arl) || string.IsNullOrWhiteSpace(obj.Arl))
            {
                Mensaje = "Este campo arl es obligatorio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.EditarPerson(obj, out Mensaje);
            }
            else
            {
                return false;
            }


        }

        public bool EliminarPersona(int id, out string Mensaje)
        {

            return objCapaDato.EliminarPersona(id, out Mensaje);

        }

       


    }
}
