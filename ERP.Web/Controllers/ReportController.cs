using ConexionBD;
using DevExpress.Web.Mvc;
using ERP.Models.Usuario;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ERP.Web.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        ERPProdEntities oContext;
        // GET: Report
        public ActionResult VentaResumen()
        {
            
            return View();
        }

        [ValidateInput(false)]
        public ActionResult RptVentasResumenPartial()
        {
            UsuarioModel usuario = (UsuarioModel)Session["Usuario"];
            oContext = new ERPProdEntities();
            var model = oContext.p_rpt_ventas_resumen(usuario.lstSucursales.FirstOrDefault().sucursalId);
            return PartialView("_RptVentasResumenPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult RptVentasResumenPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] ConexionBD.p_rpt_ventas_resumen_Result item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_RptVentasResumenPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult RptVentasResumenPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] ConexionBD.p_rpt_ventas_resumen_Result item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_RptVentasResumenPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult RptVentasResumenPartialDelete(System.String Folio)
        {
            var model = new object[0];
            if (Folio != null)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_RptVentasResumenPartial", model);
        }

        public ActionResult ExportToCSV()
        {
            UsuarioModel usuario = (UsuarioModel)Session["Usuario"];
            oContext = new ERPProdEntities();
            List<p_rpt_ventas_resumen_Result> model = oContext.p_rpt_ventas_resumen(usuario.lstSucursales.FirstOrDefault().sucursalId).ToList();

            StringBuilder sb = new StringBuilder();
            sb.Append("Sucursal,");            
            sb.Append("Serie,");            
            sb.Append("Folio,");
            sb.Append("Clave,");           
            sb.Append("Fecha,");
            sb.Append("Hora,");
            sb.Append("Descripcion,");
            sb.Append("Cantidad,");
            sb.Append("Descuento,");
            sb.Append("Cancelado,");
            sb.Append("Total,");
            sb.Append("Cliente,");
            sb.Append("Observaciones,");
            sb.Append("FolioPagoWeb");
            sb.Append("\n");

            foreach (var item in model)
            {
                sb.Append((item.Sucursal == null ? "" : item.Sucursal )+ ",");
                sb.Append((item.Serie == null ? "" : item.Serie) + ",");
                sb.Append((item.Folio == null ? "" : item.Folio) + ",");
                sb.Append((item.Clave == null ? "" : item.Clave) + ",");
                sb.Append((item.FechaHora == null ? "" : item.FechaHora.ToShortDateString()) + ",");
                sb.Append((item.FechaHora == null ? "" : item.FechaHora.ToShortTimeString()) + ",");
                sb.Append((item.Descripcion == null ? "" : item.Descripcion) + ",");
                sb.Append((item.Cantidad == null ? "" : item.Cantidad.ToString()) + ",");
                sb.Append((item.Descuento == null ? "" : item.Descuento.ToString()) + ",");
                sb.Append((item.Cancelado == null ? "" : item.Cancelado.ToString()) + ",");
                sb.Append((item.Total == null ? "" : item.Total.ToString()) + ",");
                sb.Append((item.Cliente == null ? "" : item.Cliente.ToString()) + ",");
                sb.Append((item.Observaciones == null ? "" : item.Observaciones.ToString()) + ",");
                sb.Append((item.FolioPagoWeb == null ? "" : item.FolioPagoWeb.ToString()) + "");
                sb.Append("\n");
            }
            byte[] myByteArray = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            MemoryStream ms = new MemoryStream(myByteArray);

            //var result = Json(sb.ToString());

            return File(myByteArray, "application/octet-stream", "Filename.csv");
        }
    }
}