using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Idiomas
    {
        public List<Idiomas> Listar(string numero)
        {
            List<Idiomas> lista = new List<Idiomas>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    //solo me permite hacer saltos de linea 
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("SELECT * FROM PERSONA p");
                    sb.AppendLine("inner join IDIOMAS id on id.IdPersona = p.IdPersona");
                    sb.AppendLine("where p.NumeroDocumento = @numero");



                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Idiomas()
                                {
                                    IdIdiomas = Convert.ToInt32(dr["IdIdiomas"]),
                                    Idioma = dr["Idioma"].ToString(),
                                    LoHabla = dr["LoHabla"].ToString(),
                                    LoLee = dr["LoLee"].ToString(),
                                    LoEscribe = dr["LoEscribe"].ToString(),
                                    IdPersona = Convert.ToInt32(dr["IdPersona"]),
                                }
                            );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Idiomas>();
            }


            return lista;
        }
    }
}
