using CapaEntidad;

using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class S_CD_Persona
    {
        public List<S_Persona> Listar()
        {

            List<S_Persona> lista = new List<S_Persona>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select * from PERSONA";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new S_Persona()
                                {
                                    IdPersona = Convert.ToInt32(dr["IdPersona"]),
                                    TipoIdentificacion = dr["TipoIdentificacion"].ToString(),
                                    NumeroDocumento = Convert.ToInt32(dr["NumeroDocumento"]),
                                    Genero = dr["Genero"].ToString(),
                                    Pais = dr["Pais"].ToString(),
                                    LugarExpedicion = dr["LugarExpedicion"].ToString(),

                                    FechaExpedicion = dr["FechaExpedicion"].ToString(),
                                    EstadoCivil = dr["EstadoCivil"].ToString(),
                                    NumeroHijos = Convert.ToInt32(dr["NumeroHijos"]),
                                    PrimerNombre = dr["PrimerNombre"].ToString(),
                                    SegundoNombre = dr["SegundoNombre"].ToString(),
                                    PrimerApellido = dr["PrimerApellido"].ToString(),
                                    SegundoApellido = dr["SegundoApellido"].ToString(),
                                    LibretaMilitar = dr["LibretaMilitar"].ToString(),
                                    NumeroLibreta = Convert.ToInt32(dr["NumeroLibreta"]),
                                    DistritoMilitar = Convert.ToInt32(dr["DistritoMilitar"]),

                                    FechaNacimiente = dr["FechaNacimiente"].ToString(),

                                    PaisNacimiento = dr["PaisNacimiento"].ToString(),
                                    DeapartamentoNacimiento = dr["DeapartamentoNacimiento"].ToString(),
                                    CiudadNacimiento = dr["CiudadNacimiento"].ToString(),
                                    Direccion = dr["Direccion"].ToString(),
                                    PaisDireccion = dr["PaisDireccion"].ToString(),
                                    DepartamentoResidencia = dr["DepartamentoResidencia"].ToString(),
                                    CiudadDireccion = dr["CiudadDireccion"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    CorreoElectronico = dr["CorreoElectronico"].ToString(),
                                    GrupoSanguineo = dr["GrupoSanguineo"].ToString(),
                                    GrupoEtnico = dr["GrupoEtnico"].ToString(),
                                    Profesion = dr["Profesion"].ToString(),
                                    Eps = dr["Eps"].ToString(),
                                    FondoPensiones = dr["FondoPensiones"].ToString(),
                                    Arl = dr["Arl"].ToString(),
                                   // PersonaPerId = Convert.ToInt32(dr["PersonaPerId"]),
                                    Estado = Convert.ToBoolean(dr["Estado"]),
                                    Estadofecha = dr["Estadofecha"].ToString(),
                                }
                            );
                        }
                    }

                }
            }
            catch 
            {
                lista = new List<S_Persona>();
                


            }

            return lista;

        }

        public int RegistrarPerson(S_Persona obj, out string Mensaje) {

            int idautogenerado = 0;
            Mensaje = string.Empty;

            DateTime thisDay = DateTime.Today;
            //obj.FechaRevision = thisDay.ToString();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("insertpersona", oconexion);

                    cmd.Parameters.AddWithValue("TipoIdentificacion", obj.TipoIdentificacion);
                    cmd.Parameters.AddWithValue("NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("Genero", obj.Genero);
                    cmd.Parameters.AddWithValue("Pais", obj.Pais);
                    cmd.Parameters.AddWithValue("LugarExpedicion", obj.LugarExpedicion);
                    cmd.Parameters.AddWithValue("FechaExpedicion", obj.FechaExpedicion);
                    cmd.Parameters.AddWithValue("EstadoCivil", obj.EstadoCivil);
                    cmd.Parameters.AddWithValue("NumeroHijos", obj.NumeroHijos);
                    cmd.Parameters.AddWithValue("PrimerNombre", obj.PrimerNombre);
                    cmd.Parameters.AddWithValue("SegundoNombre", obj.SegundoNombre);
                    cmd.Parameters.AddWithValue("PrimerApellido", obj.PrimerApellido);
                    cmd.Parameters.AddWithValue("SegundoApellido", obj.SegundoApellido);
                    cmd.Parameters.AddWithValue("LibretaMilitar", obj.LibretaMilitar);
                    cmd.Parameters.AddWithValue("NumeroLibreta", obj.NumeroLibreta);
                    cmd.Parameters.AddWithValue("DistritoMilitar", obj.DistritoMilitar);
                    cmd.Parameters.AddWithValue("FechaNacimiente", obj.FechaNacimiente);
                    cmd.Parameters.AddWithValue("PaisNacimiento", obj.PaisNacimiento);
                    cmd.Parameters.AddWithValue("DeapartamentoNacimiento", obj.DeapartamentoNacimiento);
                    cmd.Parameters.AddWithValue("CiudadNacimiento", obj.CiudadNacimiento);
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("PaisDireccion", obj.PaisDireccion);
                    cmd.Parameters.AddWithValue("DepartamentoResidencia", obj.DepartamentoResidencia);
                    cmd.Parameters.AddWithValue("CiudadDireccion", obj.CiudadDireccion);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("CorreoElectronico", obj.CorreoElectronico);
                    cmd.Parameters.AddWithValue("GrupoSanguineo", obj.GrupoSanguineo);
                    cmd.Parameters.AddWithValue("GrupoEtnico", obj.GrupoEtnico);
                    cmd.Parameters.AddWithValue("Profesion", obj.Profesion);
                    cmd.Parameters.AddWithValue("Eps", obj.Eps);
                    cmd.Parameters.AddWithValue("FondoPensiones", obj.FondoPensiones);
                    cmd.Parameters.AddWithValue("Arl", obj.Arl);
                    //fecha de resumen
                    cmd.Parameters.AddWithValue("FechaResumen", obj.Estadofecha);


                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("Estadofecha", obj.Estadofecha);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex){
                idautogenerado = 0;
                Mensaje = ex.Message;

            }
            return idautogenerado;

        
        }
        
        public bool EditarPerson(S_Persona obj, out String Mensaje)
        {

            bool resultado = false;
            Mensaje = String.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("editarpersona", oconexion);

                    cmd.Parameters.AddWithValue("IdPersona", obj.IdPersona);
                    cmd.Parameters.AddWithValue("TipoIdentificacion", obj.TipoIdentificacion);
                    cmd.Parameters.AddWithValue("NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("Genero", obj.Genero);
                    cmd.Parameters.AddWithValue("Pais", obj.Pais);
                    cmd.Parameters.AddWithValue("LugarExpedicion", obj.LugarExpedicion);
                    cmd.Parameters.AddWithValue("FechaExpedicion", obj.FechaExpedicion);
                    cmd.Parameters.AddWithValue("EstadoCivil", obj.EstadoCivil);
                    cmd.Parameters.AddWithValue("NumeroHijos", obj.NumeroHijos);
                    cmd.Parameters.AddWithValue("PrimerNombre", obj.PrimerNombre);
                    cmd.Parameters.AddWithValue("SegundoNombre", obj.SegundoNombre);
                    cmd.Parameters.AddWithValue("PrimerApellido", obj.PrimerApellido);
                    cmd.Parameters.AddWithValue("SegundoApellido", obj.SegundoApellido);
                    cmd.Parameters.AddWithValue("LibretaMilitar", obj.LibretaMilitar);
                    cmd.Parameters.AddWithValue("NumeroLibreta", obj.NumeroLibreta);
                    cmd.Parameters.AddWithValue("DistritoMilitar", obj.DistritoMilitar);
                    cmd.Parameters.AddWithValue("FechaNacimiente", obj.FechaNacimiente);
                    cmd.Parameters.AddWithValue("PaisNacimiento", obj.PaisNacimiento);
                    cmd.Parameters.AddWithValue("DeapartamentoNacimiento", obj.DeapartamentoNacimiento);
                    cmd.Parameters.AddWithValue("CiudadNacimiento", obj.CiudadNacimiento);
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("PaisDireccion", obj.PaisDireccion);
                    cmd.Parameters.AddWithValue("DepartamentoResidencia", obj.DepartamentoResidencia);
                    cmd.Parameters.AddWithValue("CiudadDireccion", obj.CiudadDireccion);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("CorreoElectronico", obj.CorreoElectronico);
                    cmd.Parameters.AddWithValue("GrupoSanguineo", obj.GrupoSanguineo);
                    cmd.Parameters.AddWithValue("GrupoEtnico", obj.GrupoEtnico);
                    cmd.Parameters.AddWithValue("Profesion", obj.Profesion);
                    cmd.Parameters.AddWithValue("Eps", obj.Eps);
                    cmd.Parameters.AddWithValue("FondoPensiones", obj.FondoPensiones);
                    cmd.Parameters.AddWithValue("Arl", obj.Arl);
                    //cmd.Parameters.AddWithValue("PersonaPerId", obj.PersonaPerId);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("Estadofecha", obj.Estadofecha);
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

     
        public bool EliminarPersona(int id, out string Mensaje)
        {

            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("delete top (1) from PERSONA where IdPersona = @id", oconexion);
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
