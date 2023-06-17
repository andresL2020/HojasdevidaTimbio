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
    public class CD_DatosLaborales
    {
        public List<DatosLaborales> Listar(string numero)
        {
            List<DatosLaborales> lista = new List<DatosLaborales>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    //solo me permite hacer saltos de linea 
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("SELECT p.IdPersona, dl.IdDatosLaborales, dl.Area, dl.NombreArea, a.NombreActividad, a.TipoActividad,");
                    sb.AppendLine("pr.NombreProceso, dl.HorasContratadas,CONVERT(char(10),dl.FechaIngreso,103)[atFechaIngreso],");
                    sb.AppendLine("CONVERT(char(10),dl.FechaRetiro,103)[atFechaRetiro], dl.Cumple, dl.Observacion FROM PERSONA p ");
                    sb.AppendLine("inner join  DATOS_LABORALES dl on dl.IdPersona = p.IdPersona");
                    sb.AppendLine("left join ACTIVIDAD a on a.IdActividad = dl.IdActividad");
                    sb.AppendLine("left join PROCESOS Pr on Pr.IdProceso = dl.IdProceso where p.NumeroDocumento = @numero");


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
                                new DatosLaborales()
                                {
                                    IdDatosLaborales = Convert.ToInt32(dr["IdDatosLaborales"]),
                                    Area = dr["Area"].ToString(),
                                    NombreArea = dr["NombreArea"].ToString(),
                                    NombreActividad = dr["NombreActividad"].ToString(),
                                    TipoActividad = dr["TipoActividad"].ToString(),
                                    NombreProceso = dr["NombreProceso"].ToString(),
                                    HorasContratadas = dr["HorasContratadas"].ToString(),
                                    FechaIngreso = dr["atFechaIngreso"].ToString(),
                                    FechaRetiro = dr["atFechaRetiro"].ToString(),
                                    Cumple = dr["Cumple"].ToString(),
                                    Observacion = dr["Observacion"].ToString(),
                                    IdPersona = Convert.ToInt32(dr["IdPersona"]),
                                }
                            );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<DatosLaborales>();
            }


            return lista;
        }

        //EDITAR DATOS LABORALES
        public bool EditarDatoLaboral(int IdPersona, int IdDlaboral, string Cumple, string Observacion, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarDatLaborales", oconexion);
                    cmd.Parameters.AddWithValue("IdPersona", IdPersona);
                    cmd.Parameters.AddWithValue("IdDatosLaborales", IdDlaboral);
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
