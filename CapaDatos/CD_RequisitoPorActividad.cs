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
    public class CD_RequisitoPorActividad
    {
        public List<RequisitoPorActividad> Listar()
        {
            List<RequisitoPorActividad> lista = new List<RequisitoPorActividad>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    //solo me permite hacer saltos de linea 
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("select rp.IdRequisitoActividad, rp.IdActividad, a.NombreActividad,rp.IdCrearRequisitoLegal,cr.NombreRequisito");
                    sb.AppendLine("from REQUISITO_ACTIVIDAD rp inner join ACTIVIDAD a on rp.IdActividad = a.IdActividad");
                    sb.AppendLine("inner join  CREAR_REQUISITOLEGAL cr on cr.IdCrearRequisitoLegal = rp.IdCrearRequisitoLegal");


                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new RequisitoPorActividad()
                                {
                                    IdRequisitoActividad = Convert.ToInt32(dr["IdRequisitoActividad"]),
                                    oActividad = new Actividad() { IdActividad = Convert.ToInt32(dr["IdActividad"]), NombreActividad = dr["NombreActividad"].ToString()},
                                    oRequisitoLegal = new CrearRequisitoLegal() { IdCrearRequisitoLegal = Convert.ToInt32(dr["IdCrearRequisitoLegal"]), NombreRequisito = dr["NombreRequisito"].ToString() }
                                }
                            );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<RequisitoPorActividad>();
            }


            return lista;
        }


        public List<RequisitoPorActividad> ListarParaSindicato(int idActivdad)
        {
            List<RequisitoPorActividad> lista = new List<RequisitoPorActividad>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarRequisitoActividadSindicato", oconexion);
                    cmd.Parameters.AddWithValue("idActividad", idActivdad);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new RequisitoPorActividad()
                                {
                                    IdRequisitoActividad = Convert.ToInt32(dr["IdRequisitoActividad"]),
                                    oActividad = new Actividad() { IdActividad = Convert.ToInt32(dr["IdActividad"]), NombreActividad = dr["NombreActividad"].ToString() },
                                    oRequisitoLegal = new CrearRequisitoLegal() { IdCrearRequisitoLegal = Convert.ToInt32(dr["IdCrearRequisitoLegal"]), NombreRequisito = dr["NombreRequisito"].ToString() }
                                }
                            );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<RequisitoPorActividad>();
            }


            return lista;
        }

        public int Registrar(int idActividad, int idRequisitoL, out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarRequisitoPorActividad", oconexion);
                    cmd.Parameters.AddWithValue("IdActividad", idActividad);
                    cmd.Parameters.AddWithValue("IdCrearRequisitoLegal", idRequisitoL);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    //Ejecutamo todo nuestro comando
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


        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("delete top (1) from REQUISITO_ACTIVIDAD where IdRequisitoActividad = @id", oconexion);
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
