using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

using CapaEntidad;
using CapaNegocio;
using ClosedXML.Excel;
using System.Globalization;
using System.Data;
using static ClosedXML.Excel.XLPredefinedFormat;
using DateTime = System.DateTime;
using System.Web.Services.Description;
using CapaPresentacionAdmin.filter;
using System.Web.UI;
using Rotativa;

namespace CapaPresentacionAdmin.Controllers
{
  
    
    [Authorize]
    [ValidarSession]
    public class VerificarController : Controller
    {
        private CN_Reporte objReporte = new CN_Reporte();

        // GET: Verificar
        public ActionResult Buscar()
        {
            return View();
        }
        public ActionResult DatosPersonales()
        {
            return View();
        }
        public ActionResult FormacionAcademica()
        {
            return View();
        }
        public ActionResult Capacitaciones()
        {
            return View();
        }
        public ActionResult Idiomas()
        {
            return View();
        }
        public ActionResult ExperienciaLaboral()
        {
            return View();
        }
        public ActionResult DatosLaborales()
        {
            return View();
        }
        public ActionResult Requisitos()
        {
            return View();
        }
        public ActionResult Reporte()
        {
            return View();
        }
        public ActionResult CrearReporte()
        {
            int contador = 0;
            List<Reporte> oLista = new List<Reporte>();
            List<Reporte> oLista2 = new List<Reporte>();
            List<Reporte> oLista3 = new List<Reporte>();

            List<Reporte> eliminar = new List<Reporte>();

            string numero = ((string)Session["numDocumento"]);

            Session["numDocumento"] = numero;

            //oLista = new CN_Reporte().Listar(numero);
            oLista = new CN_Reporte().ListarGenerarPdf(numero);

            foreach(Reporte r in oLista)
            {
                if(contador >= 18)
                {
                    oLista2.Add(r);
                    eliminar.Add(r);                   

                }
                contador++;
            }

            //eliminar
            foreach(Reporte r in eliminar)
            {
                oLista.Remove(r);
            }

            eliminar.Clear();

            contador = 0;
            foreach(Reporte r in oLista2)
            {
                if (contador >= 32)
                {
                    oLista3.Add(r);
                    eliminar.Add(r);                    

                }
                contador++;
            }

            //eliminar
            foreach (Reporte r in eliminar)
            {
                oLista2.Remove(r);
            }

            eliminar.Clear();

            contador = 0;

            PaginasLista objPaginaList = new PaginasLista()
            {
                hoja1 = oLista,
                hoja2 = oLista2,
                hoja3 = oLista3,
            };

            //return View(objPaginaList);

            return new ViewAsPdf("CrearReporte", objPaginaList)
            {
                FileName = "Reporte.pdf",
                PageOrientation = Rotativa.Options.Orientation.Portrait,
                PageSize = Rotativa.Options.Size.A4,
                PageMargins = new Rotativa.Options.Margins { Bottom = 5, Left = 5, Right = 5, Top = 5 }
            };

        }


        //--------------------------------BUSCAR JSONRESULT

        [HttpGet]
        public JsonResult ListarBuscar()
        {
            string numero = "";

            List<Buscar> oLista = new List<Buscar>();

            oLista = new CN_Buscar().Listar(numero);


            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Consultar(string documento)
        {
            List<Buscar> oLista = new List<Buscar>();

            oLista = new CN_Buscar().Listar(documento);

            Session["numDocumento"] = "0";

            if (oLista.Count() > 0)
            {
                Session["numDocumento"] = documento;
              
            }


            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public ActionResult exportarReporte(string numero)
        {
            List<Buscar> oLista = new List<Buscar>();

            oLista = new CN_Buscar().Listar(numero);

            //dt es de tipo tabla
            DataTable dt = new DataTable();

            dt.Locale = new System.Globalization.CultureInfo("es-CO");

            dt.Columns.Add("IdPersona", typeof(int));
            dt.Columns.Add("Cedula", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Genero", typeof(string));
            dt.Columns.Add("FechaNacimiento", typeof(string));
            dt.Columns.Add("CorreoElectronico", typeof(string));
            dt.Columns.Add("Telefono", typeof(string));
            dt.Columns.Add("Sindicato", typeof(string));
            dt.Columns.Add("Profesion", typeof(string));
            dt.Columns.Add("Actividad", typeof(string));
            dt.Columns.Add("FechaIngreso", typeof(string));
            dt.Columns.Add("FechaRetiro", typeof(string));
            dt.Columns.Add("Estado", typeof(int));
            dt.Columns.Add("Verificado", typeof(string));

            foreach (Buscar rp in oLista)
            {
                dt.Rows.Add(new object[]
                {
                    rp.IdPersona,
                    rp.Cedula,
                    rp.Nombre,
                    rp.Genero,
                    rp.FechaNacimiento,
                    rp.CorreoElectronico,
                    rp.Telefono,
                    rp.Sindicato,
                    rp.Profesion,
                    rp.Actividad,
                    rp.FechaIngreso,
                    rp.FechaRetiro,
                    rp.Estado,
                    rp.Verificado,
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
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte" + DateTime.Now.ToString() + ".xlsx");
                }
            }
        }

        //--------------------------------LISTAR DATOS PERSONALES Y DEMAS
        [HttpGet]
        public JsonResult ListarDatosPersonales()
        {

            List<FormacionAcademica> oLista = new List<FormacionAcademica>();

            string numero = ((string)Session["numDocumento"]);

            Session["numDocumento"] = numero;

            oLista = new CN_FormacioAc_Cursos().ListarFormacion(numero);

            //Session["InfoCPersona"] = oLista;
            //List<InfoCPersona> hola = ((List<InfoCPersona>)Session["InfoCPersona"]);

            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        //--------------------------------FORMACION ACADEMICA
        [HttpGet]
        public JsonResult ListarFAcademica()
        {

            FormacionAcademica oLista;

            string numero = ((string)Session["numDocumento"]);

            Session["numDocumento"] = numero;


            //oLista = new CN_InfoCPersona().Listar(numero);
            oLista = new CN_FormacioAc_Cursos().ListarFormacion(numero).Where((Ra) => Ra.NumeroDocumento == int.Parse(numero)).FirstOrDefault();

            if (oLista == null)
            {
                oLista = new FormacionAcademica();
                if (string.IsNullOrEmpty(oLista.ObservacionBasica) && string.IsNullOrEmpty(oLista.ObservacionSuperior))
                {
                    oLista.ObservacionBasica = "Debes Hacer una consulta";
                    oLista.ObservacionSuperior = "Debes Hacer una consulta";
                }
            }

            if (string.IsNullOrEmpty(oLista.ObservacionBasica) && string.IsNullOrEmpty(oLista.ObservacionSuperior))
            {
                oLista.ObservacionBasica = "Agrega un Comentario";
                oLista.ObservacionSuperior = "Agrega un Comentario";
            }

            if (string.IsNullOrEmpty(oLista.CumpleBasica) && string.IsNullOrEmpty(oLista.CumpleSuperior))
            {
                oLista.CumpleBasica = "Sin Seleccionar";
                oLista.CumpleSuperior = "Sin Seleccionar";
            }


            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult EditarFormacioAcademica(int IdFAcademica, string Numero, string Cumple, string Observacion)
        {
            //nos permite guarda cualquier tipo de datos
            bool resultado;
            FormacionAcademica oLista;
            string mensaje = string.Empty;

            string numero = ((string)Session["numDocumento"]);

            Session["numDocumento"] = numero;

            oLista = new CN_FormacioAc_Cursos().ListarFormacion(numero).Where((Ra) => Ra.NumeroDocumento == int.Parse(numero)).FirstOrDefault();

            if (oLista == null)
            {
                resultado = false;
                mensaje = "Debes consultar una persona primero";
                return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
            }

            int IdPersona = oLista.IdPersonaFAcademica;

            resultado = new CN_FormacioAc_Cursos().Editar(IdPersona, IdFAcademica, Numero, Cumple, Observacion, out mensaje);


            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public FileResult verPdfFormacionAcademica(int IdFAcademica, string nombre)
        {

            string numero = ((string)Session["numDocumento"]);

            Session["numDocumento"] = numero;

            List<S_Formacion_academica> oLista = new List<S_Formacion_academica>();

            S_Formacion_academica fAcademica = new S_Formacion_academica();

            oLista = new S_CNF_Academica().ListarArchivo();

            fAcademica = oLista.Where((f) => f.IdFormacionAcademica == IdFAcademica).FirstOrDefault();

            if (fAcademica != null)
            {
                if (nombre == "ActaColegio")
                {
                    return File(fAcademica.ActaColegio, "application/pdf");

                }
                else if (nombre == "DiplomaColegio")
                {
                    return File(fAcademica.DiplomaColegio, "application/pdf");

                }
                else if (nombre == "ActaUniversitaria")
                {
                    return File(fAcademica.ActaUniversitaria, "application/pdf");

                }
                else if (nombre == "DiplomaUniversitario")
                {
                    return File(fAcademica.DiplomaUniversitario, "application/pdf");

                }
                else
                {
                    return File("../pdf/moral.pdf", "application/pdf", "No hay pdf");
                }
            }
            else
            {
                return File("../pdf/moral.pdf", "application/pdf", "No hay pdf");
            }

        }


        //--------------------------------CURSOS
        [HttpGet]
        public JsonResult ListarCursos()
        {

            List<CapacitacionesCursos> oLista = new List<CapacitacionesCursos>();

            string numero = ((string)Session["numDocumento"]);

            Session["numDocumento"] = numero;

            oLista = new CN_FormacioAc_Cursos().ListarCuros(numero);

            //Session["InfoCPersona"] = oLista;
            //List<InfoCPersona> hola = ((List<InfoCPersona>)Session["InfoCPersona"]);

            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult EditarCurso(int IdPersona, int IdCurso, string Cumple, string Observacion)
        {
            bool resultado;
            string mensaje = string.Empty;

            resultado = new CN_FormacioAc_Cursos().EditarCurso(IdPersona, IdCurso, Cumple, Observacion, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public FileResult verPdfCapaciatciones(int IdCapacitaciones)
        {

            string numero = ((string)Session["numDocumento"]);

            Session["numDocumento"] = numero;

            List<S_CapacitacionesC> oLista = new List<S_CapacitacionesC>();

            S_CapacitacionesC capacitaciones = new S_CapacitacionesC();

            oLista = new S_CNCapacitacionesC().ListarArchivo();

            capacitaciones = oLista.Where((c) => c.idCapacitacionesCursos == IdCapacitaciones).FirstOrDefault();

            if (capacitaciones != null)
            {

                return File(capacitaciones.Archivo, "application/pdf");
            }
            else
            {
                return File("../pdf/moral.pdf", "application/pdf", "No hay pdf");
            }

        }


        //--------------------------------IDIOMAS

        [HttpGet]
        public JsonResult ListarIdiomas()
        {

            List<Idiomas> oLista = new List<Idiomas>();

            string numero = ((string)Session["numDocumento"]);

            Session["numDocumento"] = numero;

            oLista = new CN_Idiomas().Listar(numero);

            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


        //--------------------------------EXPERIENCIA LABORAL

        [HttpGet]
        public JsonResult ListarExpLaboral()
        {

            List<ExperienciaLaboral> oLista = new List<ExperienciaLaboral>();

            string numero = ((string)Session["numDocumento"]);

            Session["numDocumento"] = numero;

            oLista = new CN_ExperienciaLaboral().Listar(numero);

            //foreach (exp in oLista)
            //{

            //}

            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult EditarExpLaboral(int IdPersona, int IdExperienciaL, string Cumple, string Observacion)
        {
            bool resultado;

            string mensaje = string.Empty;

            resultado = new CN_ExperienciaLaboral().EditarExpLaboral(IdPersona, IdExperienciaL, Cumple, Observacion, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public FileResult verPdExpLaboral(int IdexpLaboral)
        {

            string numero = ((string)Session["numDocumento"]);

            Session["numDocumento"] = numero;

            List<S_Ex_Laboral> oLista = new List<S_Ex_Laboral>();

            S_Ex_Laboral exLaboral = new S_Ex_Laboral();

            oLista = new S_CN_Ex_Laboral().ListarArchivo();

            exLaboral = oLista.Where((e) => e.IdExperienciaLaboral == IdexpLaboral).FirstOrDefault();

            if (exLaboral != null)
            {

                return File(exLaboral.AdjuntarSoporte, "application/pdf");
            }
            else
            {
                return File("../pdf/moral.pdf", "application/pdf", "No hay pdf");
            }

        }


        //--------------------------------DATOS LABORALES
        [HttpGet]
        public JsonResult ListarDatosLaborales()
        {

            List<DatosLaborales> oLista = new List<DatosLaborales>();

            string numero = ((string)Session["numDocumento"]);

            Session["numDocumento"] = numero;

            oLista = new CN_DatosLaborales().Listar(numero);

            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult EditarDatoLaboral(int IdPersona, int IdDlaboral, string Cumple, string Observacion)
        {
            bool resultado;

            string mensaje = string.Empty;

            resultado = new CN_DatosLaborales().EditarDatoLaboral(IdPersona, IdDlaboral, Cumple, Observacion, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


        //--------------------------------REQUISITOS
        [HttpGet]
        public JsonResult ListarRequisitos()
        {

            List<Requisitos> oLista = new List<Requisitos>();

            string numero = ((string)Session["numDocumento"]);

            Session["numDocumento"] = numero;

            oLista = new CN_Requisitos().Listar(numero);

            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult EditarRequisito(int IdPersona, int IdRequisito, string Cumple, string Observacion)
        {
            bool resultado;

            string mensaje = string.Empty;

            resultado = new CN_Requisitos().EditarRequisito(IdPersona, IdRequisito, Cumple, Observacion, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public FileResult verArchivoPdfRlegales(int IdRequisito)
        {

            string numero = ((string)Session["numDocumento"]);

            Session["numDocumento"] = numero;

            List<S_Rlegales> oLista = new List<S_Rlegales>();

            S_Rlegales rLegal = new S_Rlegales();

            oLista = new S_CN_Rlegales().ListarArchivo();

            rLegal = oLista.Where((r) => r.IdRequisitosLegales == IdRequisito).FirstOrDefault();

            if (rLegal != null)
            {
                return File(rLegal.Archivo, "application/pdf");
            }
            else
            {
                return File("../pdf/moral.pdf", "application/pdf", "No hay pdf");
            }

        }


        //--------------------------------REPORTE
        [HttpGet]
        public JsonResult ConfirmarVerificacion()
        {
            bool resultado;

            string mensaje = string.Empty;

            string numero = ((string)Session["numDocumento"]);

            Session["numDocumento"] = "0";

            resultado = new CN_Reporte().Editar(numero, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        //--------------------------------LISTAR DATOS PERSONALES Y DEMAS
        [HttpGet]
        public JsonResult ListarReporte()
        {

            List<Reporte> oLista = new List<Reporte>();

            string numero = ((string)Session["numDocumento"]);

            Session["numDocumento"] = numero;

            //oLista = new CN_Reporte().Listar(numero);
            oLista = objReporte.Listar(numero);          

            //retornamos esto de esta forma porque DataTable asi lo requiere
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);

        }



        [HttpGet]
        public ActionResult exportarReporteEspesifico()
        {
            List<Reporte> oLista = new List<Reporte>();
            string numero = ((string)Session["numDocumento"]);

            Session["numDocumento"] = numero;

            oLista = new CN_Reporte().Listar(numero);

            //dt es de tipo tabla
            DataTable dt = new DataTable();

            dt.Locale = new System.Globalization.CultureInfo("es-CO");

            dt.Columns.Add("oid", typeof(int));
            dt.Columns.Add("Item", typeof(string));
            dt.Columns.Add("Cumple", typeof(string));
            dt.Columns.Add("Observacion", typeof(string));
            dt.Columns.Add("FechaVerificacion", typeof(string));
            dt.Columns.Add("FechaResumen", typeof(string));
            dt.Columns.Add("Numero", typeof(int));

            foreach (Reporte rp in oLista)
            {
                dt.Rows.Add(new object[]
                {
                    rp.oid,
                    rp.Item,
                    rp.Cumple,
                    rp.Observacion,
                    rp.FechaVerificacion,
                    rp.FechaResumen,
                    rp.Numero,
                });
            }

            dt.TableName = "Reporte";

            //creamos el doumento excel
            using (XLWorkbook wb = new XLWorkbook())
            {
                var hoja = wb.Worksheets.Add(dt);

                //vamos a guardar el documento en el memorystream
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReporteEspecifico" + DateTime.Now.ToString() + ".xlsx");
                }
            }
        }
    }
}