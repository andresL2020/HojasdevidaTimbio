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
    public class CD_Requisitos
    {

        public List<Requisitos> Listar(string numero)
        {
            List<Requisitos> lista = new List<Requisitos>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    //solo me permite hacer saltos de linea 
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("SELECT p.IdPersona, rl.IdRequisitosLegales, crl.NombreRequisito,");
                    sb.AppendLine("CONVERT(char(10),rl.FechaExpedicion,103)[atFechaExpedicion],");
                    sb.AppendLine("rl.Archivo, rl.Cumple, rl.Observacion FROM PERSONA p");
                    sb.AppendLine("inner join  REQUISITOS_LEGALES rl on rl.IdPersona = p.IdPersona");
                    sb.AppendLine("left join CREAR_REQUISITOLEGAL crl on crl.IdCrearRequisitoLegal = rl.IdCrearRequisitoLegal where p.NumeroDocumento = @numero");


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
                                new Requisitos()
                                {
                                    IdRequisitosLegales = Convert.ToInt32(dr["IdRequisitosLegales"]),
                                    NombreRequisito = dr["NombreRequisito"].ToString(),
                                    FechaExpedicion = dr["atFechaExpedicion"].ToString(),
                                    //Archivo = dr["Archivo"] as byte[],
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
                lista = new List<Requisitos>();
            }


            return lista;
        }


        //EDITAR REQUISITO
        public bool EditarRequisito(int IdPersona, int IdRequisito, string Cumple, string Observacion, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarRequisito", oconexion);
                    cmd.Parameters.AddWithValue("IdPersona", IdPersona);
                    cmd.Parameters.AddWithValue("IdRequisitosLegales", IdRequisito);
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
