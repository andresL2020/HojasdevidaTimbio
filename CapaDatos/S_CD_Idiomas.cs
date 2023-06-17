using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CapaDatos
{
    public class S_CD_Idiomas
    {
        public List<S_Idiomas> Listar(string numero)
        {
            List<S_Idiomas> lista = new List<S_Idiomas>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    
                    string query = "select * from IDIOMAS where IdPersona = @numero";

                  
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@numero ", numero);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new S_Idiomas()
                                {
                                    IdIdiomas = Convert.ToInt32(dr["IdIdiomas"]),
                                    Idioma = dr["Idioma"].ToString(),
                                    LoHabla = dr["LoHabla"].ToString(),
                                    LoLee = dr["LoLee"].ToString(),
                                    LoEscribe = dr["LoEscribe"].ToString(),
                                    
                                   

                                }
                        
                            );
                        }
                    }
                }



            }
            catch
            {
                lista = new List<S_Idiomas>();
            }


            return lista;
        }

        public int RegistrarIdioma(S_Idiomas obj, out string Mensaje)
        {

            int idautogenerado = 0;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("insertidioma", oconexion);

                    cmd.Parameters.AddWithValue("Idioma", obj.Idioma);
                    cmd.Parameters.AddWithValue("LoHabla", obj.LoHabla);
                    cmd.Parameters.AddWithValue("LoLee", obj.LoLee);
                    cmd.Parameters.AddWithValue("LoEscribe", obj.LoEscribe);
                    cmd.Parameters.AddWithValue("IdPersona", obj.IdPersona);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                    

                }

            }
            catch (Exception ex)
            {
                idautogenerado = 0;
                Mensaje = ex.Message;


            }
            return idautogenerado;


        }

        public bool EditarIdiomas(S_Idiomas obj, out String Mensaje)
        {

            bool resultado = false;
            Mensaje = String.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ActualizarIdioma", oconexion);

                    cmd.Parameters.AddWithValue("IdIdiomas", obj.IdIdiomas);
                    cmd.Parameters.AddWithValue("Idioma", obj.Idioma);
                    cmd.Parameters.AddWithValue("LoHabla", obj.LoHabla);
                    cmd.Parameters.AddWithValue("LoLee", obj.LoLee);
                    cmd.Parameters.AddWithValue("LoEscribe", obj.LoEscribe);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;

            }
            return resultado;

        }

        public bool EliminarIdioma(int id, out string Mensaje)
        {

            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("delete top (1) from IDIOMAS where IdIdiomas = @id", oconexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }


            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;

            }
            return resultado;
        }

    }
}
