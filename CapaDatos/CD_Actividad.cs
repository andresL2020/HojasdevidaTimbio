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
    public class CD_Actividad
    {
        public List<Actividad> Listar()
        {
            List<Actividad> lista = new List<Actividad>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select * from ACTIVIDAD";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Actividad()
                                {
                                    IdActividad = Convert.ToInt32(dr["IdActividad"]),
                                    NombreActividad = dr["NombreActividad"].ToString(),
                                    TipoActividad = dr["TipoActividad"].ToString(),
                                }
                            );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Actividad>();
            }


            return lista;
        }

        public List<Actividad> ListarActividad_Sindicato(string tActividad)
        {
            List<Actividad> lista = new List<Actividad>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarActividadSindicato", oconexion);
                    cmd.Parameters.AddWithValue("@tipoActividad", tActividad);

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Actividad()
                                {
                                    IdActividad = Convert.ToInt32(dr["IdActividad"]),
                                    NombreActividad = dr["NombreActividad"].ToString(),
                                    TipoActividad = dr["TipoActividad"].ToString(),
                                }
                            );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Actividad>();
            }


            return lista;
        }

        public int Registrar(Actividad obj, out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarActividad", oconexion);
                    cmd.Parameters.AddWithValue("NombreActividad", obj.NombreActividad);
                    cmd.Parameters.AddWithValue("TipoActividad", obj.TipoActividad);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    //Ejecutamo todo nuestro comando
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


        public bool Editar(Actividad obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarActividad", oconexion);
                    cmd.Parameters.AddWithValue("IdActividad", obj.IdActividad);
                    cmd.Parameters.AddWithValue("NombreActividad", obj.NombreActividad);
                    cmd.Parameters.AddWithValue("TipoActividad", obj.TipoActividad);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    //Ejecutamo todo nuestro comando
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

        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("delete top (1) from ACTIVIDAD where IdActividad = @id", oconexion);
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
