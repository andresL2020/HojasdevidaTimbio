using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaEntidad;



namespace CapaDatos
{
    public class CD_Buscar
    {
        public List<Buscar> Listar(string documento)
        {
            List<Buscar> lista = new List<Buscar>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("sp_ListarBuscar", oconexion);
                    cmd.Parameters.AddWithValue("numDocumento", documento);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Buscar()
                                {
                                    IdPersona = Convert.ToInt32(dr["IdPersona"]),
                                    Cedula = Convert.ToInt32(dr["Cedula"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    Genero = dr["Genero"].ToString(),
                                    FechaNacimiento = dr["FechaNacimiento"].ToString(),
                                    CorreoElectronico = dr["CorreoElectronico"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    Sindicato = dr["Sindicato"].ToString(),
                                    Profesion = dr["Profesion"].ToString(),
                                    Actividad = dr["Actividad"].ToString(),
                                    FechaIngreso = dr["FechaIngreso"].ToString(),
                                    FechaRetiro = dr["FechaRetiro"].ToString(),
                                    Estado = Convert.ToInt32(dr["Estado"]),
                                    Verificado = dr["Verificado"].ToString(),
                                    ModalidadAcademica = dr["ModalidadAcademica"].ToString(),
                                }
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                object me = ex;
                lista = new List<Buscar>();
            }


            return lista;
        }
    }
}
