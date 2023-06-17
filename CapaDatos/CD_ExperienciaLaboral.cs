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
    public class CD_ExperienciaLaboral
    {

        public List<ExperienciaLaboral> Listar(string numero)
        {
            List<ExperienciaLaboral> lista = new List<ExperienciaLaboral>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    //solo me permite hacer saltos de linea 
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("SELECT *, CONVERT(char(10),expl.FechaIngreso,103)[atFechaIngreso],");
                    sb.AppendLine("CONVERT(char(10),expl.FechaEgreso,103)[atFechaEgreso] FROM PERSONA p ");
                    sb.AppendLine("inner join EXPERIENCIA_LABORAL expl on expl.IdPersona = p.IdPersona");
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
                                new ExperienciaLaboral()
                                {
                                    IdExperienciaLaboral = Convert.ToInt32(dr["IdExperienciaLaboral"]),
                                    EmpresaEntidad = dr["EmpresaEntidad"].ToString(),
                                    Pais = dr["Pais"].ToString(),
                                    Ciudad = dr["Ciudad"].ToString(),
                                    Direccion = dr["Direccion"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    CorreoElectronico = dr["CorreoElectronico"].ToString(),
                                    SectorEmpresa = dr["SectorEmpresa"].ToString(),
                                    CargoContratoActual = dr["CargoContratoActual"].ToString(),
                                    Dependencia = dr["Dependencia"].ToString(),
                                    FechaIngreso = dr["atFechaIngreso"].ToString(),
                                    FechaEgreso = dr["atFechaEgreso"].ToString(),
                                    //AdjuntarSoporte = dr["AdjuntarSoporte"] as byte[],
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
                lista = new List<ExperienciaLaboral>();
            }


            return lista;
        }


        //EDITAR EXPERIENCIA LABORAL
        public bool EditarExpLaboral(int IdPersona, int IdExperienciaL, string Cumple, string Observacion, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarExpLaboral", oconexion);
                    cmd.Parameters.AddWithValue("IdPersona", IdPersona);
                    cmd.Parameters.AddWithValue("IdExperienciaLaboral", IdExperienciaL);
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
