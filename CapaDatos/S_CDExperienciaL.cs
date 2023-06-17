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
    public class CD_ExLaboral
    {
        public List<S_Ex_Laboral> Listar(string numero)
        {
            List<S_Ex_Laboral> lista = new List<S_Ex_Laboral>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "select * from EXPERIENCIA_LABORAL where IdPersona = @numero";


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
                                new S_Ex_Laboral()
                                {
                                    IdExperienciaLaboral = Convert.ToInt32(dr["IdExperienciaLaboral"]),
                                    EmpresaEntidad = dr["EmpresaEntidad"].ToString(),
                                    Pais = dr["Pais"].ToString(),
                                    Departamento = dr["Departamento"].ToString(),
                                    Ciudad = dr["Ciudad"].ToString(),
                                    Direccion = dr["Direccion"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    CorreoElectronico = dr["CorreoElectronico"].ToString(),
                                    SectorEmpresa = dr["SectorEmpresa"].ToString(),
                                    CargoContratoActual = dr["CargoContratoActual"].ToString(),
                                    Dependencia = dr["Dependencia"].ToString(),
                                    FechaIngreso = dr["FechaIngreso"].ToString(),
                                    FechaEgreso = dr["FechaEgreso"].ToString(),
                                   
                                }
                            );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<S_Ex_Laboral>();
            }


            return lista;
        }


        public List<S_Ex_Laboral> ListarArchivo()
        {
            List<S_Ex_Laboral> lista = new List<S_Ex_Laboral>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "select * from EXPERIENCIA_LABORAL";


                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new S_Ex_Laboral()
                                {
                                    IdExperienciaLaboral = Convert.ToInt32(dr["IdExperienciaLaboral"]),
                                    EmpresaEntidad = dr["EmpresaEntidad"].ToString(),
                                    Pais = dr["Pais"].ToString(),
                                    Departamento = dr["Departamento"].ToString(),
                                    Ciudad = dr["Ciudad"].ToString(),
                                    Direccion = dr["Direccion"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    CorreoElectronico = dr["CorreoElectronico"].ToString(),
                                    SectorEmpresa = dr["SectorEmpresa"].ToString(),
                                    CargoContratoActual = dr["CargoContratoActual"].ToString(),
                                    Dependencia = dr["Dependencia"].ToString(),
                                    FechaIngreso = dr["FechaIngreso"].ToString(),
                                    FechaEgreso = dr["FechaEgreso"].ToString(),
                                    AdjuntarSoporte = dr["AdjuntarSoporte"] as byte[],

                                }
                            );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<S_Ex_Laboral>();
            }


            return lista;
        }

        public int RegistrarExpLaboral(S_Ex_Laboral obj, out string Mensaje)
        {

            int idautogenerado = 0;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("insertexperiencialaboral", oconexion);

                    cmd.Parameters.AddWithValue("EmpresaEntidad", obj.EmpresaEntidad);
                    cmd.Parameters.AddWithValue("Pais", obj.Pais);
                    cmd.Parameters.AddWithValue("Departamento", obj.Departamento);
                    cmd.Parameters.AddWithValue("Ciudad", obj.Ciudad);
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("CorreoElectronico", obj.CorreoElectronico);
                    cmd.Parameters.AddWithValue("SectorEmpresa", obj.SectorEmpresa);
                    cmd.Parameters.AddWithValue("CargoContratoActual", obj.CargoContratoActual);
                    cmd.Parameters.AddWithValue("Dependencia", obj.Dependencia);
                    cmd.Parameters.AddWithValue("FechaIngreso", obj.FechaIngreso);
                    cmd.Parameters.AddWithValue("FechaEgreso", obj.FechaEgreso);
                    cmd.Parameters.AddWithValue("AdjuntarSoporte", obj.AdjuntarSoporte);
                    cmd.Parameters.AddWithValue("NombreSoporte", obj.AdjuntarSoporteNombre);
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

        public bool ActualizarExpLaboral(S_Ex_Laboral obj, out String Mensaje)
        {

            bool resultado = false;
            Mensaje = String.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("ActualizarExpLaboral", oconexion);

                    cmd.Parameters.AddWithValue("IdExperienciaLaboral", obj.IdExperienciaLaboral);
                    cmd.Parameters.AddWithValue("EmpresaEntidad", obj.EmpresaEntidad);
                    cmd.Parameters.AddWithValue("Pais", obj.Pais);
                    cmd.Parameters.AddWithValue("Departamento", obj.Departamento);
                    cmd.Parameters.AddWithValue("Ciudad", obj.Ciudad);
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("CorreoElectronico", obj.CorreoElectronico);
                    cmd.Parameters.AddWithValue("SectorEmpresa", obj.SectorEmpresa);
                    cmd.Parameters.AddWithValue("CargoContratoActual", obj.CargoContratoActual);
                    cmd.Parameters.AddWithValue("Dependencia", obj.Dependencia);
                    cmd.Parameters.AddWithValue("FechaIngreso", obj.FechaIngreso);
                    cmd.Parameters.AddWithValue("FechaEgreso", obj.FechaEgreso);
                    cmd.Parameters.AddWithValue("AdjuntarSoporte", obj.AdjuntarSoporte);
                    cmd.Parameters.AddWithValue("NombreSoporte", obj.AdjuntarSoporteNombre);
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

        public bool EliminarExlaboral(int id, out string Mensaje)
        {

            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("delete top (1) EXPERIENCIA_LABORAL where IdExperienciaLaboral = @id", oconexion);
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
