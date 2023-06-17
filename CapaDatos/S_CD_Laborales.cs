using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class S_CD_Laborales
    {
        public List<S_Datos_Laborales> Listar(string numero)
        {
            List<S_Datos_Laborales> lista = new List<S_Datos_Laborales>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "select * from DATOS_LABORALES where IdPersona = @numero";


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
                                new S_Datos_Laborales()
                                {
                                    IdDatosLaborales = Convert.ToInt32(dr["IdDatosLaborales"]),
                                    Area = dr["Area"].ToString(),
                                    NombreArea = dr["NombreArea"].ToString(),
                                    TipoActividad = dr["TipoActividad"].ToString(),
                                    FechaIngreso = dr["FechaIngreso"].ToString(),
                                    FechaRetiro = dr["FechaRetiro"].ToString(),
                                    HorasContratadas = dr["HorasContratadas"].ToString(),
                                    IdActividad = Convert.ToInt32(dr["IdActividad"]),
                                    IdProceso = Convert.ToInt32(dr["IdProceso"]),

                                }

                            );
                        }
                    }
                }

            }
            catch
            {
                lista = new List<S_Datos_Laborales>();
            }


            return lista;
        }

        public int RegistrarDatosLaborales(S_Datos_Laborales obj, out string Mensaje)
        {

            int idautogenerado = 0;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("insertdatoslaborales", oconexion);

                    cmd.Parameters.AddWithValue("Area", obj.Area);
                    cmd.Parameters.AddWithValue("NombreArea", obj.NombreArea);
                    cmd.Parameters.AddWithValue("TipoActividad", obj.TipoActividad);
                    cmd.Parameters.AddWithValue("FechaIngreso", obj.FechaIngreso);
                    cmd.Parameters.AddWithValue("FechaRetiro", obj.FechaRetiro);
                    cmd.Parameters.AddWithValue("HorasContratadas", obj.HorasContratadas);
                    cmd.Parameters.AddWithValue("IdActividad", obj.IdActividad);
                    cmd.Parameters.AddWithValue("IdProceso", obj.IdProceso);
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

        public bool EditarDatosLaborales(S_Datos_Laborales obj, out String Mensaje)
        {

            bool resultado = false;
            Mensaje = String.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ActualizarDatosL", oconexion);

                    cmd.Parameters.AddWithValue("IdDatosLaborales", obj.IdDatosLaborales);
                    cmd.Parameters.AddWithValue("Area", obj.Area);
                    cmd.Parameters.AddWithValue("NombreArea", obj.NombreArea);
                    cmd.Parameters.AddWithValue("TipoActividad", obj.TipoActividad);
                    cmd.Parameters.AddWithValue("IdActividad", obj.IdActividad);
                    cmd.Parameters.AddWithValue("IdProceso", obj.IdProceso);
                    cmd.Parameters.AddWithValue("FechaIngreso", obj.FechaIngreso);
                    cmd.Parameters.AddWithValue("FechaRetiro", obj.FechaRetiro);
                    cmd.Parameters.AddWithValue("HorasContratadas", obj.HorasContratadas);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;

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

        public bool EliminarDLaborales(int id, out string Mensaje)
        {

            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("delete top (1) from DATOS_LABORALES where IdDatosLaborales = @id", oconexion);
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
