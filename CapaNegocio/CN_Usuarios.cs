using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Usuarios
    {

        private CD_Usuarios objCapaDato = new CD_Usuarios();

        public List<Usuario> Listar()
        {
            return objCapaDato.Listar();
        }
        //Nombres, Apelldios, Correo, Clave, Reestablecer, Activo, Fecharegistro

        public int RegistrarUsuarios(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                Mensaje = "El proceso no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apelldios) || string.IsNullOrWhiteSpace(obj.Apelldios))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }

            else if (string.IsNullOrEmpty(obj.Fecharegistro) || string.IsNullOrWhiteSpace(obj.Fecharegistro))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {

                string clave = CN_Recursos.GenerarClave();
                string asunto = "Creacion de cuenta";
                string mensaje_correo = "<h3>Su cuenta fue creada correctamente</h3></br><p>Su contraseña para acceder es: !clave!</p>";
                mensaje_correo = mensaje_correo.Replace("!clave!", clave);

                bool respuesta = CN_Recursos.EnviarCorreo(obj.Correo, asunto, mensaje_correo);

                if (respuesta)
                {
                    obj.Clave = CN_Recursos.ConvertirSha256(clave);
                    return objCapaDato.RegistrarUsuarios(obj, out Mensaje);

                }
                else
                {
                    Mensaje = "No se puede enviar el correo";
                    return 0;

                }

            }
            else
            {
                return 0;
            }
        }
        //Nombres, Apelldios, Correo, Clave, Reestablecer, Activo, Fecharegistro

        public bool EditarUsuarios(Usuario obj, out String Mensaje)
        {
            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                Mensaje = "El proceso no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Apelldios) || string.IsNullOrWhiteSpace(obj.Apelldios))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }
            //else if (string.IsNullOrEmpty(obj.Clave) || string.IsNullOrWhiteSpace(obj.Clave))
            //{
            //    Mensaje = "Este campo numero documento es obligatorio";
            //}
            //else if (bool.IsNullOrEmpty(obj.Reestablecer.HasValue) || bool.IsNullOrWhiteSpace(obj.Reestablecer))
            //{
            //    Mensaje = "Este campo numero documento es obligatorio";
            //}
            //else if (bool.IsNullOrEmpty(obj.Activo) || bool.IsNullOrWhiteSpace(obj.Activo))
            //{
            //    Mensaje = "Este campo numero documento es obligatorio";
            //}
            else if (string.IsNullOrEmpty(obj.Fecharegistro) || string.IsNullOrWhiteSpace(obj.Fecharegistro))
            {
                Mensaje = "Este campo numero documento es obligatorio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.EditarUsuarios(obj, out Mensaje);
            }
            else
            {
                return false;
            }

        }

        public bool EliminarUsuario(int id, out string Mensaje)
        {
            return objCapaDato.EliminarUsuario(id, out Mensaje);
        }

        public bool cambiarClave(int IdUsuario, string nuevaclave, out string Mensaje)
        {
            return objCapaDato.cambiarClave(IdUsuario, nuevaclave, out Mensaje);
        }
        public bool RestablecerClave(int IdUsuario, string Correo, out string Mensaje)
        {
            Mensaje = string.Empty;
            string nuevaclave = CN_Recursos.GenerarClave();
            bool resultado = objCapaDato.RestablecerClave(IdUsuario, CN_Recursos.ConvertirSha256(nuevaclave), out Mensaje);

            if (resultado)
            {
                string asunto = "Contraseña Reestablecida";
                string mensaje_correo = "<h3>Su cuenta fue Reestablecida correctamente</h3></br><p>Su contraseña para acceder  ahora es: !clave!</p>";
                mensaje_correo = mensaje_correo.Replace("!clave!", nuevaclave);

                bool respuesta = CN_Recursos.EnviarCorreo(Correo, asunto, mensaje_correo);

                if (respuesta)
                {

                    return true;

                }
                else
                {
                    Mensaje = "No se pudo enviar el correo";
                    return false;

                }
            }
            else
            {
                Mensaje = "No se pudo Reestablecer la contraseña";
                return false;
            }


        }

    }
}
