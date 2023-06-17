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
    public class CD_nombreCompleto
    {

        public int RegistrarNombreC(NombreCompleto obj2, out string Mensaje)
        {

            int idautogenerado = 0;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("insertnombrecompleto", oconexion);


                    cmd.Parameters.AddWithValue("IdNombre", obj2.IdNombre);
                    cmd.Parameters.AddWithValue("nombre", obj2.nombre);
                    cmd.Parameters.AddWithValue("senombre", obj2.senombre);
                    cmd.Parameters.AddWithValue("apellido", obj2.apellido);
                    cmd.Parameters.AddWithValue("seapellido", obj2.seapellido);
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
        public List<NombreCompleto> Listar()
        {

            List<NombreCompleto> lista = new List<NombreCompleto>();


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select * from NombreCompleto INNER JOIN PERSONA ON IdNombre = NumeroDocumento ";


                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new NombreCompleto()
                                {

                                    IdNombre = Convert.ToInt32(dr["IdNombre"]),

                                    nombre = dr["nombre"].ToString(),
                                    senombre = dr["senombre"].ToString(),
                                    apellido = dr["apellido"].ToString(),
                                    seapellido = dr["seapellido"].ToString(),
                                    IdPersona = Convert.ToInt32(dr["IdPersona"]),

                                    //nombre senombre apellido seapellido


                                }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<NombreCompleto>();



            }

            return lista;

        }
    }
}
