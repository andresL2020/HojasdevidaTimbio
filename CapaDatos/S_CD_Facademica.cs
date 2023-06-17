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
    public class S_CD_Facademica
    {
        public List<S_Formacion_academica> Listar(string numero)
        {
            List<S_Formacion_academica> lista = new List<S_Formacion_academica>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "select * from FORMACION_ACADEMICA where IdPersona = @numero ";
                    

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
                                new S_Formacion_academica()
                                {
                                    IdFormacionAcademica = Convert.ToInt32(dr["IdFormacionAcademica"]),
                                    CargoAspira = dr["CargoAspira"].ToString(),
                                    EducacionBasica = dr["EducacionBasica"].ToString(),
                                    TituloObtenido = dr["TituloObtenido"].ToString(),
                                    MesGrado = dr["MesGrado"].ToString(),
                                    AnoGrado = dr["AnoGrado"].ToString(),
                                    InstituEducativa = dr["InstituEducativa"].ToString(),
                                    ModalidadAcademica = dr["ModalidadAcademica"].ToString(),
                                    SemestresAprobados = Convert.ToInt32(dr["SemestresAprobados"]),
                                    Graduado = dr["Graduado"].ToString(),
                                    NombreTitulo = dr["NombreTitulo"].ToString(),
                                    MesTermino = dr["MesTermino"].ToString(),
                                    Ano = dr["Ano"].ToString(),                     
                                    NTarjetaProfecional = dr["NTarjetaProfecional"].ToString(),
                                    NombreInstitucion = dr["NombreInstitucion"].ToString(),                                  
                                }
                            );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<S_Formacion_academica>();
            }
            return lista;
        }

        public List<S_Formacion_academica> ListarArchivo()
        {
            List<S_Formacion_academica> lista = new List<S_Formacion_academica>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "select * from FORMACION_ACADEMICA";


                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new S_Formacion_academica()
                                {
                                    IdFormacionAcademica = Convert.ToInt32(dr["IdFormacionAcademica"]),
                                    CargoAspira = dr["CargoAspira"].ToString(),
                                    EducacionBasica = dr["EducacionBasica"].ToString(),
                                    TituloObtenido = dr["TituloObtenido"].ToString(),
                                    MesGrado = dr["MesGrado"].ToString(),
                                    AnoGrado = dr["AnoGrado"].ToString(),
                                    InstituEducativa = dr["InstituEducativa"].ToString(),
                                    ModalidadAcademica = dr["ModalidadAcademica"].ToString(),
                                    SemestresAprobados = Convert.ToInt32(dr["SemestresAprobados"]),
                                    Graduado = dr["Graduado"].ToString(),
                                    NombreTitulo = dr["NombreTitulo"].ToString(),
                                    MesTermino = dr["MesTermino"].ToString(),
                                    Ano = dr["Ano"].ToString(),
                                    NTarjetaProfecional = dr["NTarjetaProfecional"].ToString(),
                                    NombreInstitucion = dr["NombreInstitucion"].ToString(),
                                    ActaColegio = dr["ActaColegio"] as byte[],
                                    DiplomaColegio = dr["DiplomaColegio"] as byte[],
                                    ActaUniversitaria = dr["ActaUniversitaria"] as byte[],
                                    DiplomaUniversitario = dr["DiplomaUniversitario"] as byte[],
                                }
                            );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<S_Formacion_academica>();
            }
            return lista;
        }


        public int RegistrarFormacion(S_Formacion_academica obj, out string Mensaje)
        {

            int idautogenerado = 0;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("insertformacionacademica", oconexion);

                    cmd.Parameters.AddWithValue("CargoAspira", obj.CargoAspira);
                    cmd.Parameters.AddWithValue("EducacionBasica", obj.EducacionBasica);
                    cmd.Parameters.AddWithValue("TituloObtenido", obj.TituloObtenido);
                    cmd.Parameters.AddWithValue("MesGrado", obj.MesGrado);
                    cmd.Parameters.AddWithValue("AnoGrado", obj.AnoGrado);
                    cmd.Parameters.AddWithValue("ActaColegio", obj.ActaColegio);
                    cmd.Parameters.AddWithValue("DiplomaColegio", obj.DiplomaColegio);
                    cmd.Parameters.AddWithValue("InstituEducativa", obj.InstituEducativa);
                    cmd.Parameters.AddWithValue("ModalidadAcademica", obj.ModalidadAcademica);
                    cmd.Parameters.AddWithValue("SemestresAprobados", obj.SemestresAprobados);
                    cmd.Parameters.AddWithValue("Graduado", obj.Graduado);
                    cmd.Parameters.AddWithValue("NombreTitulo", obj.NombreTitulo);
                    cmd.Parameters.AddWithValue("MesTermino", obj.MesTermino);
                    cmd.Parameters.AddWithValue("Ano", obj.Ano);
                    cmd.Parameters.AddWithValue("NTarjetaProfecional", obj.NTarjetaProfecional);
                    cmd.Parameters.AddWithValue("NombreInstitucion", obj.NombreInstitucion);
                    cmd.Parameters.AddWithValue("ActaUniversitaria", obj.ActaUniversitaria);
                    cmd.Parameters.AddWithValue("DiplomaUniversitario", obj.DiplomaUniversitario);

                    cmd.Parameters.AddWithValue("NombreActaColegio", obj.ActaColegioNombre);
                    cmd.Parameters.AddWithValue("NombreDiplomaColegio", obj.DiplomaColegioNombre);
                    cmd.Parameters.AddWithValue("NombreActaUniversitaria", obj.ActaUniversitariaNombre);
                    cmd.Parameters.AddWithValue("NombreDiplomaUniversitario", obj.DiplomaUniversitarioNombre);
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

        public bool EditarFormacion(S_Formacion_academica obj , out String Mensaje)
        {

            bool resultado = false;
            Mensaje = String.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ActualizarF_Academica", oconexion);

                    cmd.Parameters.AddWithValue("IdFormacionAcademica", obj.IdFormacionAcademica);
                    cmd.Parameters.AddWithValue("CargoAspira", obj.CargoAspira);
                    cmd.Parameters.AddWithValue("EducacionBasica", obj.EducacionBasica);
                    cmd.Parameters.AddWithValue("TituloObtenido", obj.TituloObtenido);
                    cmd.Parameters.AddWithValue("MesGrado", obj.MesGrado);
                    cmd.Parameters.AddWithValue("AnoGrado", obj.AnoGrado);
                    cmd.Parameters.AddWithValue("ActaColegio", obj.ActaColegio);
                    cmd.Parameters.AddWithValue("DiplomaColegio", obj.DiplomaColegio);
                    cmd.Parameters.AddWithValue("InstituEducativa", obj.InstituEducativa);
                    cmd.Parameters.AddWithValue("ModalidadAcademica", obj.ModalidadAcademica);
                    cmd.Parameters.AddWithValue("SemestresAprobados", obj.SemestresAprobados);
                    cmd.Parameters.AddWithValue("Graduado", obj.Graduado);
                    cmd.Parameters.AddWithValue("NombreTitulo", obj.NombreTitulo);
                    cmd.Parameters.AddWithValue("MesTermino", obj.MesTermino);
                    cmd.Parameters.AddWithValue("Ano", obj.Ano);
                    cmd.Parameters.AddWithValue("NTarjetaProfecional", obj.NTarjetaProfecional);
                    cmd.Parameters.AddWithValue("NombreInstitucion", obj.NombreInstitucion);
                    cmd.Parameters.AddWithValue("ActaUniversitaria", obj.ActaUniversitaria);
                    cmd.Parameters.AddWithValue("DiplomaUniversitario", obj.DiplomaUniversitario);
                    cmd.Parameters.AddWithValue("NombreActaColegio", obj.ActaColegioNombre);
                    cmd.Parameters.AddWithValue("NombreDiplomaColegio", obj.DiplomaColegioNombre);
                    cmd.Parameters.AddWithValue("NombreActaUniversitaria", obj.ActaUniversitariaNombre);
                    cmd.Parameters.AddWithValue("NombreDiplomaUniversitario", obj.DiplomaUniversitarioNombre);
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

        public bool EliminarFormacion(int id, out string Mensaje)
        {

            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("delete top (1) FORMACION_ACADEMICA where IdFormacionAcademica = @id", oconexion);
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
