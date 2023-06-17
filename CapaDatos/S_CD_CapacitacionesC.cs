using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class S_CD_CapacitacionesC
    {
        public List<S_CapacitacionesC> Listar(string numero)
        {
            List<S_CapacitacionesC> lista = new List<S_CapacitacionesC>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "select * from CAPACITACIONE_CURSOS where IdPersona = @numero";


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
                                new S_CapacitacionesC()
                                {
                                    idCapacitacionesCursos = Convert.ToInt32(dr["idCapacitacionesCursos"]),
                                    TipoFormacion = dr["TipoFormacion"].ToString(),
                                    Nombre = dr["Nombre"].ToString(),
                                    
                                    EstadoFormacion = dr["EstadoFormacion"].ToString(),
                                    FechaInicio = dr["FechaInicio"].ToString(),
                                    FechaFinalizacion = dr["FechaFinalizacion"].ToString(),
                                }

                            );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<S_CapacitacionesC>();
            }


            return lista;
        }


        public List<S_CapacitacionesC> ListarArchivo()
        {
            List<S_CapacitacionesC> lista = new List<S_CapacitacionesC>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "select * from CAPACITACIONE_CURSOS";


                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new S_CapacitacionesC()
                                {
                                    idCapacitacionesCursos = Convert.ToInt32(dr["idCapacitacionesCursos"]),
                                    TipoFormacion = dr["TipoFormacion"].ToString(),
                                    Nombre = dr["Nombre"].ToString(),
                                    EstadoFormacion = dr["EstadoFormacion"].ToString(),
                                    FechaInicio = dr["FechaInicio"].ToString(),
                                    Archivo = dr["Archivo"] as byte[],
                                    FechaFinalizacion = dr["FechaFinalizacion"].ToString(),
                                }

                            );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<S_CapacitacionesC>();
            }


            return lista;
        }

        public int RegistrarCursos(S_CapacitacionesC obj, out string Mensaje)
        {

            int idautogenerado = 0;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("insertcapacitacionesocursos ", oconexion);

                    cmd.Parameters.AddWithValue("TipoFormacion", obj.TipoFormacion);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("EstadoFormacion", obj.EstadoFormacion);
                    cmd.Parameters.AddWithValue("FechaInicio", obj.FechaInicio);
                    cmd.Parameters.AddWithValue("FechaFinalizacion", obj.FechaFinalizacion);
                    cmd.Parameters.AddWithValue("Archivo", obj.Archivo);
                    cmd.Parameters.AddWithValue("NombreArchivo", obj.ArchivoNombre);
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

        public bool EditarCursos(S_CapacitacionesC obj, out String Mensaje)
        {

            bool resultado = false;
            Mensaje = String.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ActualizarCapacitacionesC", oconexion);

                    cmd.Parameters.AddWithValue("idCapacitacionesCursos", obj.idCapacitacionesCursos);
                    cmd.Parameters.AddWithValue("TipoFormacion", obj.TipoFormacion);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("EstadoFormacion", obj.EstadoFormacion);
                    cmd.Parameters.AddWithValue("FechaInicio", obj.FechaInicio);
                    cmd.Parameters.AddWithValue("FechaFinalizacion", obj.FechaFinalizacion);
                    cmd.Parameters.AddWithValue("Archivo", obj.Archivo);
                    cmd.Parameters.AddWithValue("NombreArchivo", obj.ArchivoNombre);
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

        public bool EliminarCapacitacion(int id, out string Mensaje)
        {

            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("delete top (1) CAPACITACIONE_CURSOS where idCapacitacionesCursos = @id", oconexion);
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
