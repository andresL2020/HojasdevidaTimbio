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
    public class CD_FormacioAc_Cursos
    {

        //USE ESTE PARA DESARROLLAR TRES APARTADOS: D_PERSONALES,FACADEMICA Y CURSOS
        public List<FormacionAcademica> ListarFormacion(string numero)
        {
            List<FormacionAcademica> lista = new List<FormacionAcademica>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    //solo me permite hacer saltos de linea 
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("SELECT *,CONVERT(char(10),p.FechaExpedicion,103)[atFechaExpedicion],CONVERT(char(10),p.FechaNacimiente,103)[atFechaNacimiento],");
                    sb.AppendLine("CONCAT(P.PrimerNombre,' ',P.SegundoNombre,' ',P.PrimerApellido,' ',P.SegundoApellido)[NombreCompleto] FROM PERSONA p ");
                    sb.AppendLine("left join  FORMACION_ACADEMICA fa on fa.IdPersona = p.IdPersona");                   
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
                                new FormacionAcademica()
                                {
                                    IdPersona = Convert.ToInt32(dr["IdPersona"]),
                                    TipoIdentificacion = dr["TipoIdentificacion"].ToString(),
                                    NumeroDocumento = Convert.ToInt32(dr["NumeroDocumento"]),
                                    Genero = dr["Genero"].ToString(),
                                    //Nacionalidad = dr["TipoActividad"].ToString(),
                                    Pais = dr["Pais"].ToString(),
                                    LugarExpedicion = dr["LugarExpedicion"].ToString(),
                                    FechaExpedicion = dr["atFechaExpedicion"].ToString(),
                                    EstadoCivil = dr["EstadoCivil"].ToString(),
                                    NumeroHijos = Convert.ToInt32(dr["NumeroHijos"]),
                                    PrimerNombre = dr["PrimerNombre"].ToString(),
                                    SegundoNombre = dr["SegundoNombre"].ToString(),
                                    PrimerApellido = dr["PrimerApellido"].ToString(),
                                    SegundoApellido = dr["SegundoApellido"].ToString(),
                                    LibretaMilitar = dr["LibretaMilitar"].ToString(),
                                    NumeroLibreta = Convert.ToInt32(dr["NumeroLibreta"]),
                                    DistritoMilitar = Convert.ToInt32(dr["DistritoMilitar"]),
                                    FechaNacimiente = dr["atFechaNacimiento"].ToString(),
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
                                    FechaRevision = dr["FechaResumen"].ToString(),
                                    Estado = Convert.ToInt32(dr["Estado"]),
                                    EstadoFecha = dr["EstadoFecha"].ToString(),
                                    Verificado = dr["Verificado"].ToString(),
                                    NombreCompleto = dr["NombreCompleto"].ToString(),

                                    //FORMACION ACADEMICA
                                    IdFormacionAcademica = Convert.ToInt32(dr["IdFormacionAcademica"]),
                                    CargoAspira = dr["CargoAspira"].ToString(),
                                    EducacionBasica = dr["EducacionBasica"].ToString(),
                                    TituloObtenido = dr["TituloObtenido"].ToString(),
                                    MesGrado = dr["MesGrado"].ToString(),
                                    AñoGrado = dr["AnoGrado"].ToString(),
                                    InstituEducativa = dr["InstituEducativa"].ToString(),
                                    ModalidadAcademica = dr["ModalidadAcademica"].ToString(),
                                    SemestresAprobados = Convert.ToInt32(dr["SemestresAprobados"]),
                                    Graduado = dr["Graduado"].ToString(),
                                    NombreTitulo = dr["NombreTitulo"].ToString(),
                                    MesTermino = dr["MesTermino"].ToString(),
                                    Año = dr["Ano"].ToString(),
                                    NTarjetaProfecional = dr["NTarjetaProfecional"].ToString(),
                                    NombreInstitucion = dr["NombreInstitucion"].ToString(),
                                    CumpleBasica = dr["CumpleBasica"].ToString(),
                                    ObservacionBasica = dr["ObservacionBasica"].ToString(),
                                    CumpleSuperior = dr["CumpleSuperior"].ToString(),
                                    ObservacionSuperior = dr["ObservacionSuperior"].ToString(),
                                    IdPersonaFAcademica = Convert.ToInt32(dr["IdPersona"]),                                    
                                }
                            );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<FormacionAcademica>();
            }


            return lista;
        }


        public List<CapacitacionesCursos> ListarCuros(string numero)
        {
            List<CapacitacionesCursos> lista = new List<CapacitacionesCursos>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    //solo me permite hacer saltos de linea 
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("SELECT *,CONVERT(char(10),p.FechaExpedicion,103)[atFechaExpedicion],CONVERT(char(10),p.FechaNacimiente,103)[atFechaNacimiento],");
                    sb.AppendLine("CONVERT(char(10),cap.FechaInicio,103)[atFechaInicio], CONVERT(char(10),cap.FechaFinalizacion,103)[atFechaFinalizacion],");
                    sb.AppendLine("CONCAT(P.PrimerNombre,' ',P.SegundoNombre,' ',P.PrimerApellido,' ',P.SegundoApellido)[NombreCompleto] FROM PERSONA p ");
                    sb.AppendLine("left join CAPACITACIONE_CURSOS cap  on p.IdPersona = cap.IdPersona");
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
                                new CapacitacionesCursos()
                                {
                                    IdPersona = Convert.ToInt32(dr["IdPersona"]),
                                    TipoIdentificacion = dr["TipoIdentificacion"].ToString(),
                                    NumeroDocumento = Convert.ToInt32(dr["NumeroDocumento"]),
                                    Genero = dr["Genero"].ToString(),
                                    //Nacionalidad = dr["TipoActividad"].ToString(),
                                    Pais = dr["Pais"].ToString(),
                                    LugarExpedicion = dr["LugarExpedicion"].ToString(),
                                    FechaExpedicion = dr["atFechaExpedicion"].ToString(),
                                    EstadoCivil = dr["EstadoCivil"].ToString(),
                                    NumeroHijos = Convert.ToInt32(dr["NumeroHijos"]),
                                    PrimerNombre = dr["PrimerNombre"].ToString(),
                                    SegundoNombre = dr["SegundoNombre"].ToString(),
                                    PrimerApellido = dr["PrimerApellido"].ToString(),
                                    SegundoApellido = dr["SegundoApellido"].ToString(),
                                    LibretaMilitar = dr["LibretaMilitar"].ToString(),
                                    NumeroLibreta = Convert.ToInt32(dr["NumeroLibreta"]),
                                    DistritoMilitar = Convert.ToInt32(dr["DistritoMilitar"]),
                                    FechaNacimiente = dr["atFechaNacimiento"].ToString(),
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
                                    FechaRevision = dr["FechaResumen"].ToString(),
                                    Estado = Convert.ToInt32(dr["Estado"]),
                                    EstadoFecha = dr["EstadoFecha"].ToString(),
                                    Verificado = dr["Verificado"].ToString(),
                                    NombreCompleto = dr["NombreCompleto"].ToString(),

                                    //CAPACITACIONE_CURSOS
                                    idCapacitacionesCursos = Convert.ToInt32(dr["idCapacitacionesCursos"]),
                                    TipoFormacion = dr["TipoFormacion"].ToString(),
                                    Nombre = dr["Nombre"].ToString(),
                                    EstadoFormacion = dr["EstadoFormacion"].ToString(),
                                    FechaInicio = dr["atFechaInicio"].ToString(),
                                    FechaFinalizacion = dr["atFechaFinalizacion"].ToString(),
                                    Cumple = dr["Cumple"].ToString(),
                                    Observacion = dr["Observacion"].ToString(),
                                    IdPersonaCursos = Convert.ToInt32(dr["IdPersona"]),
                                }
                            );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<CapacitacionesCursos>();
            }


            return lista;
        }


        //EDITAR FORAMACION ACADEMICA
        public bool Editar(int IdPersona, int IdFAcademica, string Numero, string Cumple, string Observacion, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarFAcademica", oconexion);
                    cmd.Parameters.AddWithValue("IdPersona", IdPersona);
                    cmd.Parameters.AddWithValue("IdFAcademica", IdFAcademica);
                    cmd.Parameters.AddWithValue("Numero", Numero);
                    cmd.Parameters.AddWithValue("Cumple", Cumple);
                    cmd.Parameters.AddWithValue("Observacion", Observacion);
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


        //EDITAR CAPACITACIONES CURSOS
        public bool EditarCurso(int IdPersona, int IdCurso, string Cumple, string Observacion, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarCursos", oconexion);
                    cmd.Parameters.AddWithValue("IdPersona", IdPersona);
                    cmd.Parameters.AddWithValue("IdCurso", IdCurso);
                    cmd.Parameters.AddWithValue("Cumple", Cumple);
                    cmd.Parameters.AddWithValue("Observacion", Observacion);
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

    }

}
