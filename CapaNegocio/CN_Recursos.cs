using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

//nos permiten utilizar todoas las clases correspondientes a enviar un email
using System.Net.Mail;
using System.Net;
using System.IO;


namespace CapaNegocio
{
    public class CN_Recursos
    {
        //devuelve una clave aleatoria
        public static string GenerarClave()
        {
            string clave = Guid.NewGuid().ToString("N").Substring(0, 8);
            return clave;
        }

        //encriptacion de texto en SHA256
        public static string ConvertirSha256(string texto)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }

        public static bool EnviarCorreo(string correo, string asunto, string mensaje)
        {
            bool resultado = false;

            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(correo);
                mail.From = new MailAddress("sebastiangutierrez1103@gmail.com");
                mail.Subject = asunto;
                mail.Body = mensaje;
                mail.IsBodyHtml = true;

                //configuramos el servido que se va a encargar de enviar el mensage
                var smtp = new SmtpClient()
                {
                    Credentials = new NetworkCredential("sebastiangutierrez1103@gmail.com", "pdfkrtnueezvxdgj"),
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                };

                smtp.Send(mail);
                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
            }

            return resultado;
        }
    }
}
