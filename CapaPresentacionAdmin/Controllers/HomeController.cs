using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CapaEntidad;
using CapaNegocio;
using ClosedXML.Excel;
using CapaPresentacionAdmin.filter;

namespace CapaPresentacionAdmin.Controllers
{
    [Authorize]
    [ValidarSession]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Procesos()
        {
            return View();
        }
        public ActionResult Actividades()
        {
            return View();
        }
        public ActionResult RequisitosLegales()
        {
            return View();
        }
        public ActionResult RequisitoActividad()
        {
            return View();
        }
        public ActionResult ReporteGeneral()
        {
            return View();
        }
        
       

        //--------------------------------PROCESOS JSONRESULT
        [HttpGet]
        public JsonResult ListarProcesos()
        {
            List<Procesos> oLista = new List<Procesos>();

            oLista = new CN_Procesos().Listar();

            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new {data = oLista}, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GuardarProceso(Procesos objeto)
        {
            //nos permite guarda cualquier tipo de datos
            object resultado;
            string mensaje = string.Empty;

            if(objeto.IdProceso == 0)
            {
                resultado = new CN_Procesos().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Procesos().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarProceso(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Procesos().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }



        //--------------------------------ACTIVIDAD JSONRESULT
        [HttpGet]
        public JsonResult ListarActividades()
        {
            List<Actividad> oLista = new List<Actividad>();

            oLista = new CN_Actividad().Listar();

            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GuardarActividad(Actividad objeto)
        {
            //nos permite guarda cualquier tipo de datos
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdActividad == 0)
            {
                resultado = new CN_Actividad().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Actividad().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult EliminarActividad(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Actividad().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }



        //--------------------------------REQUISITO LEGAL JSONRESULT
        [HttpGet]
        public JsonResult ListarCRequisitoLegal()
        {
            List<CrearRequisitoLegal> oLista = new List<CrearRequisitoLegal>();

            oLista = new CN_CRequisitoLegal().Listar();

            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GuardarCRequisitoLegal(CrearRequisitoLegal objeto)
        {
            //nos permite guarda cualquier tipo de datos
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdCrearRequisitoLegal == 0)
            {
                resultado = new CN_CRequisitoLegal().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_CRequisitoLegal().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult EliminarCRequisitoLegal(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_CRequisitoLegal().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        //--------------------------------REQUISITO LEGAL JSONRESULT
        [HttpGet]
        public JsonResult ListarRequisitoPorActividad()
        {
            List<RequisitoPorActividad> oLista = new List<RequisitoPorActividad>();

            oLista = new CN_RequisitoPorActividad().Listar();

            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult GuardarRequisitoPorActividad(int idActividad, int idRequisitoL)
        {
            //nos permite guarda cualquier tipo de datos
            int resultado;
            string mensaje = string.Empty;
            
            resultado = new CN_RequisitoPorActividad().Registrar(idActividad, idRequisitoL, out mensaje);

            RequisitoPorActividad objeto = new CN_RequisitoPorActividad().Listar().Where((Ra) => Ra.IdRequisitoActividad == resultado).FirstOrDefault();




            return Json(new { resultado = resultado, objeto= objeto, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult EliminarRequisitoPorActividad(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_RequisitoPorActividad().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        //--------------------------------REPORTE GENERAL
        [HttpPost]
        public ActionResult exportarRpGeneral(string exLaboral)
        {
            List<RpGeneral> oLista = new List<RpGeneral>();

            oLista = new CN_RpGeneral().Listar(exLaboral);

            //dt es de tipo tabla
            DataTable dt = new DataTable();

            dt.Locale = new System.Globalization.CultureInfo("es-CO");

            dt.Columns.Add("TipoIdentificacion", typeof(string));
            dt.Columns.Add("NumeroDocumento", typeof(int));
            dt.Columns.Add("Nombres", typeof(string));
            dt.Columns.Add("Apellidos", typeof(string));
            dt.Columns.Add("Telefono", typeof(string));
            dt.Columns.Add("CargoAspira", typeof(string));
            dt.Columns.Add("EducacionSuperior", typeof(string));
            dt.Columns.Add("Cursos", typeof(string));
            dt.Columns.Add("exp_laboral", typeof(string));


            foreach(RpGeneral rp in oLista)
            {
                dt.Rows.Add(new object[]
                {
                    rp.TipoIdentificacion,
                    rp.NumeroDocumento,
                    rp.Nombres,
                    rp.Apellidos,
                    rp.Telefono,
                    rp.CargoAspira,
                    rp.EducacionSuperior,
                    rp.Cursos,
                    rp.exp_laboral,
                });
            }

            dt.TableName = "datos";

            //creamos el doumento excel
            using (XLWorkbook wb = new XLWorkbook())
            {
                var hoja = wb.Worksheets.Add(dt);

                //vamos a guardar el documento en el memorystream
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte General " + DateTime.Now.ToString() + ".xlsx");
                }
            }
        }



        [HttpGet]
        public JsonResult ListarRpGeneral(string consultar)
        {
            string exLaboral = consultar; 

            List<RpGeneral> oLista = new List<RpGeneral>();

            oLista = new CN_RpGeneral().Listar(exLaboral);

            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


    }
}