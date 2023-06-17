using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class S_CN_Ex_Laboral
    {
        private CD_ExLaboral objCapaDato = new CD_ExLaboral();
        public List<S_Ex_Laboral> Listar(string numero)
        {
            return objCapaDato.Listar(numero);
        }
        
         public List<S_Ex_Laboral> ListarArchivo()
        {
            return objCapaDato.ListarArchivo();
        }
        public int RegistrarExpLaboral(S_Ex_Laboral obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.EmpresaEntidad) || string.IsNullOrWhiteSpace(obj.EmpresaEntidad))
            {
                Mensaje = "Este campo EmpresaEntidad es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Pais) || string.IsNullOrWhiteSpace(obj.Pais))
            {
                Mensaje = "Este campo Pais es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Departamento) || string.IsNullOrWhiteSpace(obj.Departamento))
            {
                Mensaje = "Este campo Departamento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Ciudad) || string.IsNullOrWhiteSpace(obj.Ciudad))
            {
                Mensaje = "Este campo Ciudad es obligatorio";
            }

            else if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
            {
                Mensaje = "Este campo Direccion es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
            {
                Mensaje = "Este campo Telefono es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.CorreoElectronico) || string.IsNullOrWhiteSpace(obj.CorreoElectronico))
            {
                Mensaje = "Este campo CorreoElectronico es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.SectorEmpresa) || string.IsNullOrWhiteSpace(obj.SectorEmpresa))
            {
                Mensaje = "Este campo SectorEmpresa es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.CargoContratoActual) || string.IsNullOrWhiteSpace(obj.CargoContratoActual))
            {
                Mensaje = "Este campo CargoContratoActual es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Dependencia) || string.IsNullOrWhiteSpace(obj.Dependencia))
            {
                Mensaje = "Este campo Dependencia es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.FechaIngreso) || string.IsNullOrWhiteSpace(obj.FechaIngreso))
            {
                Mensaje = "Este campo FechaIngreso es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.FechaEgreso) || string.IsNullOrWhiteSpace(obj.FechaEgreso))
            {
                Mensaje = "Este campo FechaEgreso es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.AdjuntarSoporteNombre) || string.IsNullOrWhiteSpace(obj.AdjuntarSoporteNombre))
            {
                Mensaje = "Adjunte un pdf";
            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.RegistrarExpLaboral(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        public bool ActualizarExpLaboral(S_Ex_Laboral obj, out String Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.EmpresaEntidad) || string.IsNullOrWhiteSpace(obj.EmpresaEntidad))
            {
                Mensaje = "Este campo EmpresaEntidad es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Pais) || string.IsNullOrWhiteSpace(obj.Pais))
            {
                Mensaje = "Este campo Pais es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Departamento) || string.IsNullOrWhiteSpace(obj.Departamento))
            {
                Mensaje = "Este campo Departamento es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Ciudad) || string.IsNullOrWhiteSpace(obj.Ciudad))
            {
                Mensaje = "Este campo Ciudad es obligatorio";
            }

            else if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
            {
                Mensaje = "Este campo Direccion es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
            {
                Mensaje = "Este campo Telefono es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.CorreoElectronico) || string.IsNullOrWhiteSpace(obj.CorreoElectronico))
            {
                Mensaje = "Este campo CorreoElectronico es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.SectorEmpresa) || string.IsNullOrWhiteSpace(obj.SectorEmpresa))
            {
                Mensaje = "Este campo SectorEmpresa es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.CargoContratoActual) || string.IsNullOrWhiteSpace(obj.CargoContratoActual))
            {
                Mensaje = "Este campo CargoContratoActual es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Dependencia) || string.IsNullOrWhiteSpace(obj.Dependencia))
            {
                Mensaje = "Este campo Dependencia es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.FechaIngreso) || string.IsNullOrWhiteSpace(obj.FechaIngreso))
            {
                Mensaje = "Este campo FechaIngreso es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.FechaEgreso) || string.IsNullOrWhiteSpace(obj.FechaEgreso))
            {
                Mensaje = "Este campo FechaEgreso es obligatorio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.ActualizarExpLaboral(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }
        public bool EliminarExlaboral(int id, out string Mensaje)
        {
            return objCapaDato.EliminarExlaboral(id, out Mensaje);
        }
        
    }

}
