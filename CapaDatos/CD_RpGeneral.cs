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
    public class CD_RpGeneral
    {
        public List<RpGeneral> Listar(string exLaboral)
        {
            List<RpGeneral> lista = new List<RpGeneral>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("sp_ListarRpGeneral", oconexion);
                    cmd.Parameters.AddWithValue("cumple", exLaboral);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new RpGeneral()
                                {
                                    IdPersona = Convert.ToInt32(dr["IdPersona"]),
                                    TipoIdentificacion = dr["TipoIdentificacion"].ToString(),
                                    NumeroDocumento = Convert.ToInt32(dr["NumeroDocumento"]),
                                    Nombres = dr["Nombres"].ToString(),
                                    Apellidos = dr["Apellidos"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    CargoAspira = dr["CargoAspira"].ToString(),
                                    EducacionSuperior = dr["EducacionSuperior"].ToString(),
                                    Cursos = dr["Cursos"].ToString(),
                                    exp_laboral = dr["exp_laboral"].ToString(),
                                }
                            );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<RpGeneral>();
            }


            return lista;
        }
    }
}
