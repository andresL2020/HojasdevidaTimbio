using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CapaDatos
{
    public class S_CD_Rlegales
    {
        public List<S_Rlegales> Listar(string numero)
        {
            List<S_Rlegales> lista = new List<S_Rlegales>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "select * from REQUISITOS_LEGALES where IdPersona = @numero";


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
                                new S_Rlegales()
                                {
                                    IdRequisitosLegales = Convert.ToInt32(dr["IdRequisitosLegales"]),
                                    FechaExpedicion = dr["FechaExpedicion"].ToString(),
                                    //Archivo = dr["Archivo"] as byte[],
                                    IdCrearRequisitoLegal = Convert.ToInt32(dr["IdCrearRequisitoLegal"]),
                                }

                            );
                        }
                    }
                }



            }
            catch
            {
                lista = new List<S_Rlegales>();
            }


            return lista;
        }

        public List<S_Rlegales> ListarArchivo()
        {
            List<S_Rlegales> lista = new List<S_Rlegales>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "select * from REQUISITOS_LEGALES";


                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new S_Rlegales()
                                {
                                    IdRequisitosLegales = Convert.ToInt32(dr["IdRequisitosLegales"]),
                                    FechaExpedicion = dr["FechaExpedicion"].ToString(),
                                    Archivo = dr["Archivo"] as byte[],
                                    IdCrearRequisitoLegal = Convert.ToInt32(dr["IdCrearRequisitoLegal"]),
                                }

                            );
                        }
                    }
                }



            }
            catch
            {
                lista = new List<S_Rlegales>();
            }


            return lista;
        }

        //REGISTRAR REQUISITOS LEGALES

        public int RegistrarRlegales(S_Rlegales obj, out string Mensaje)
        {

            int idautogenerado = 0;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("insertrequisitoslegales", oconexion);

                   
                    cmd.Parameters.AddWithValue("FechaExpedicion", obj.FechaExpedicion);
                    cmd.Parameters.AddWithValue("Archivo", obj.Archivo);
                    cmd.Parameters.AddWithValue("NombreArchivo", obj.archivoNombre);
                    cmd.Parameters.AddWithValue("IdCrearRequisitoLegal", obj.IdCrearRequisitoLegal);
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
        //Editar Requisitos legales
        public bool EditarRlegales(S_Rlegales obj, out String Mensaje)
        {

            bool resultado = false;
            Mensaje = String.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ActualizarRlegales", oconexion);

                    cmd.Parameters.AddWithValue("IdRequisitosLegales", obj.IdRequisitosLegales);
                    cmd.Parameters.AddWithValue("FechaExpedicion", obj.FechaExpedicion);
                    cmd.Parameters.AddWithValue("Archivo", obj.Archivo);
                    cmd.Parameters.AddWithValue("NombreArchivo", obj.archivoNombre);
                    cmd.Parameters.AddWithValue("IdCrearRequisitoLegal", obj.IdCrearRequisitoLegal);
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

        public bool TerminarRevision(int idpersona, out String Mensaje)
        {

            bool resultado = false;
            Mensaje = String.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("TerminarRevisionS", oconexion);

                    cmd.Parameters.AddWithValue("IdPersona", idpersona);

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
        public bool EliminarRequisito(int id, out string Mensaje)
        {

            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("delete top (1) REQUISITOS_LEGALES where IdRequisitosLegales = @id", oconexion);
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
