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
    public class CD_Reporte
    {
        public bool Editar(string numDocumento, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            DateTime thisDay = DateTime.Today;
            string FechaResumen = thisDay.ToString();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ComfirmarVerificacion", oconexion);
                    cmd.Parameters.AddWithValue("Documento", numDocumento);
                    cmd.Parameters.AddWithValue("FechaResumen", FechaResumen);
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

        //listar para generar pdf
        public List<Reporte> ListarGenerarPdf(string numero)
        {
            List<Reporte> lista = new List<Reporte>();


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    //solo me permite hacer saltos de linea 
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("select p.NumeroDocumento,");
                    sb.AppendLine("CONCAT(P.PrimerNombre,' ',P.SegundoNombre,' ',P.PrimerApellido,' ',P.SegundoApellido)[NombreCompleto],");
                    sb.AppendLine("p.Genero,CONVERT(char(10),p.FechaNacimiente,103)[atFechaNacimiento],");
                    sb.AppendLine("p.CorreoElectronico,dl.NombreArea,");
                    sb.AppendLine("a.NombreActividad,pro.NombreProceso,");
                    sb.AppendLine("CONVERT(char(10),dl.FechaIngreso,103)[atFechaIngreso],");
                    sb.AppendLine("CONVERT(char(10),dl.FechaRetiro,103)[atFechaRetiro]");
                    sb.AppendLine("from PERSONA p inner join DATOS_LABORALES dl on p.IdPersona = dl.IdPersona");
                    sb.AppendLine("inner join ACTIVIDAD a on dl.IdActividad = a.IdActividad");
                    sb.AppendLine("inner join PROCESOS pro on dl.IdProceso = pro.IdProceso");
                    sb.AppendLine("where p.NumeroDocumento = @numero");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("numero", numero);

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {                            
                            lista.Add(
                                new Reporte()
                                {
                                    objPersona = new S_Persona() { 
                                        NumeroDocumento = Convert.ToInt32(dr["NumeroDocumento"]),
                                        PrimerNombre = dr["NombreCompleto"].ToString(),
                                        Genero = dr["Genero"].ToString(),
                                        FechaNacimiente = dr["atFechaNacimiento"].ToString(),
                                        CorreoElectronico = dr["CorreoElectronico"].ToString(),
                                    },
                                    objLaborale = new S_Datos_Laborales()
                                    {
                                        NombreArea = dr["NombreArea"].ToString(),
                                        NombreActividad = dr["NombreActividad"].ToString(),
                                        NombreProceso = dr["NombreProceso"].ToString(),
                                        FechaIngreso = dr["atFechaIngreso"].ToString(),
                                        FechaRetiro = dr["atFechaRetiro"].ToString(),
                                    },
                                }
                            );
                        }
                        lista.AddRange(ListarFormacionAcademicaEduBasic(numero));

                    }
                }
            }
            catch
            {
                lista = new List<Reporte>();
            }
            if(lista.FirstOrDefault() == null)
            {
                lista.Add(new Reporte()
                {
                    objPersona = new S_Persona(),
                    objLaborale = new S_Datos_Laborales(),
                });
            }

            return lista;
        }



        public List<Reporte> ListarFormacionAcademicaEduBasic(string numero)
        {
            List<Reporte> lista = new List<Reporte>();

            int contador = 0;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    //solo me permite hacer saltos de linea 
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("select fa.IdFormacionAcademica, fa.CumpleBasica, fa.ObservacionBasica,");
                    sb.AppendLine("CONVERT(char(10),p.EstadoFecha,103)[atEstadoFecha],");
                    sb.AppendLine("CONVERT(char(10),p.FechaResumen,103)[atFechaResumen]");
                    sb.AppendLine("from PERSONA p inner join FORMACION_ACADEMICA fa on p.IdPersona = fa.IdPersona");
                    sb.AppendLine("where p.NumeroDocumento = @numero");


                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("numero", numero);

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            contador++;
                            lista.Add(
                                new Reporte()
                                {
                                    oid = Convert.ToInt32(dr["IdFormacionAcademica"]),
                                    Item = "Educacion - Basica",
                                    Cumple = dr["CumpleBasica"].ToString(),
                                    Observacion = dr["ObservacionBasica"].ToString(),
                                    FechaVerificacion = dr["atEstadoFecha"].ToString(),
                                    FechaResumen = dr["atFechaResumen"].ToString(),
                                    Numero = contador,
                                }
                            );
                        }
                        lista.AddRange(ListarFormacionAcademicaEduSuperior(numero, contador));
                        
                    }
                }
            }
            catch
            {
                lista = new List<Reporte>();
            }
            return lista;
        }

        public List<Reporte> ListarFormacionAcademicaEduSuperior(string numero, int contador)
        {
            List<Reporte> lista = new List<Reporte>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    //solo me permite hacer saltos de linea 
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("select fa.IdFormacionAcademica, fa.NombreTitulo, fa.CumpleSuperior, fa.ObservacionSuperior,");
                    sb.AppendLine("CONVERT(char(10),p.EstadoFecha,103)[atEstadoFecha],");
                    sb.AppendLine("CONVERT(char(10),p.FechaResumen,103)[atFechaResumen]");
                    sb.AppendLine("from PERSONA p inner join FORMACION_ACADEMICA fa on p.IdPersona = fa.IdPersona");
                    sb.AppendLine("where p.NumeroDocumento = @numero");


                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("numero", numero);

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            contador++;
                            lista.Add(
                                new Reporte()
                                {
                                    oid = Convert.ToInt32(dr["IdFormacionAcademica"]),
                                    Item = "Educacion - Universitaria "+ dr["NombreTitulo"].ToString(),
                                    Cumple = dr["CumpleSuperior"].ToString(),
                                    Observacion = dr["ObservacionSuperior"].ToString(),
                                    FechaVerificacion = dr["atEstadoFecha"].ToString(),
                                    FechaResumen = dr["atFechaResumen"].ToString(),
                                    Numero = contador,
                                }
                            );
                        }
                        List<Reporte> listCursos = new List<Reporte>();
                        listCursos = ListarCursos(numero, contador);

                        if (listCursos.FirstOrDefault() == null)
                        {
                            List<Reporte> listExpL = new List<Reporte>();
                            listExpL = ListarExpLaboral(numero, contador);

                            if (listExpL.FirstOrDefault() == null)
                            {
                                List<Reporte> listarReq = new List<Reporte>();
                                listarReq = ListarRequisitos(numero, contador);

                                lista.AddRange(listarReq);
                            }
                            else
                            {
                                lista.AddRange(listExpL);
                            }

                        }
                        else
                        {
                            lista.AddRange(listCursos);
                        }

                       

                        

                    }
                }
            }
            catch
            {
                lista = new List<Reporte>();
            }
            return lista;
        }


        public List<Reporte> ListarCursos(string numero, int contador)
        {
            List<Reporte> lista = new List<Reporte>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    //solo me permite hacer saltos de linea 
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("select c.idCapacitacionesCursos, c.TipoFormacion, c.Nombre, c.Cumple, c.Observacion,");
                    sb.AppendLine("CONVERT(char(10),p.EstadoFecha,103)[atEstadoFecha],");
                    sb.AppendLine("CONVERT(char(10),p.FechaResumen,103)[atFechaResumen]");
                    sb.AppendLine("from PERSONA p inner join CAPACITACIONE_CURSOS c on p.IdPersona = c.IdPersona");
                    sb.AppendLine("where p.NumeroDocumento = @numero");


                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("numero", numero);

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            contador++;
                            lista.Add(
                                new Reporte()
                                {
                                    oid = Convert.ToInt32(dr["idCapacitacionesCursos"]),
                                    Item = dr["TipoFormacion"].ToString() +" - "+ dr["Nombre"].ToString(),
                                    Cumple = dr["Cumple"].ToString(),
                                    Observacion = dr["Observacion"].ToString(),
                                    FechaVerificacion = dr["atEstadoFecha"].ToString(),
                                    FechaResumen = dr["atFechaResumen"].ToString(),
                                    Numero = contador,
                                }
                            );
                        }

                        List<Reporte> listExpL = new List<Reporte>();
                        listExpL = ListarExpLaboral(numero, contador);

                        if (listExpL.FirstOrDefault() == null)
                        {
                            List<Reporte> listarReq = new List<Reporte>();
                            listarReq = ListarRequisitos(numero, contador);

                            lista.AddRange(listarReq);
                        }
                        else
                        {
                            lista.AddRange(listExpL);
                        }
                        


                    }
                }
            }
            catch
            {
                lista = new List<Reporte>();
            }
            return lista;
        }

        public List<Reporte> ListarExpLaboral(string numero, int contador)
        {
            List<Reporte> lista = new List<Reporte>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    //solo me permite hacer saltos de linea 
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("select e.IdExperienciaLaboral, e.EmpresaEntidad, e.Cumple, e.Observacion,");
                    sb.AppendLine("CONVERT(char(10),p.EstadoFecha,103)[atEstadoFecha],");
                    sb.AppendLine("CONVERT(char(10),p.FechaResumen,103)[atFechaResumen]");
                    sb.AppendLine("from PERSONA p inner join EXPERIENCIA_LABORAL e on p.IdPersona = e.IdPersona");
                    sb.AppendLine("where p.NumeroDocumento = @numero");


                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("numero", numero);

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            contador++;
                            lista.Add(
                                new Reporte()
                                {
                                    oid = Convert.ToInt32(dr["IdExperienciaLaboral"]),
                                    Item = "Experiencia Laboral - "+dr["EmpresaEntidad"].ToString(),
                                    Cumple = dr["Cumple"].ToString(),
                                    Observacion = dr["Observacion"].ToString(),
                                    FechaVerificacion = dr["atEstadoFecha"].ToString(),
                                    FechaResumen = dr["atFechaResumen"].ToString(),
                                    Numero = contador,
                                }
                            );
                        }
                        lista.AddRange(ListarRequisitos(numero, contador));
                    }
                }
            }
            catch
            {
                lista = new List<Reporte>();
            }
            return lista;
        }

        public List<Reporte> ListarRequisitos(string numero, int contador)
        {
            List<Reporte> lista = new List<Reporte>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    //solo me permite hacer saltos de linea 
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("select r.IdRequisitosLegales, cr.NombreRequisito, r.Cumple, r.Observacion,");
                    sb.AppendLine("CONVERT(char(10),p.EstadoFecha,103)[atEstadoFecha],");
                    sb.AppendLine("CONVERT(char(10),p.FechaResumen,103)[atFechaResumen]");
                    sb.AppendLine("from PERSONA p inner join REQUISITOS_LEGALES r on p.IdPersona = r.IdPersona");
                    sb.AppendLine("inner join CREAR_REQUISITOLEGAL cr on r.IdCrearRequisitoLegal = cr.IdCrearRequisitoLegal");
                    sb.AppendLine("where p.NumeroDocumento = @numero");


                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("numero", numero);

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            contador++;
                            lista.Add(
                                new Reporte()
                                {
                                    oid = Convert.ToInt32(dr["IdRequisitosLegales"]),
                                    Item = "Requisito - " + dr["NombreRequisito"].ToString(),
                                    Cumple = dr["Cumple"].ToString(),
                                    Observacion = dr["Observacion"].ToString(),
                                    FechaVerificacion = dr["atEstadoFecha"].ToString(),
                                    FechaResumen = dr["atFechaResumen"].ToString(),
                                    Numero = contador,
                                }
                            );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Reporte>();
            }
            return lista;
        }
    }
}
