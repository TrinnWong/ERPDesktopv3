using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConexionBD;
namespace ERP.Web.Controllers
{
    [Authorize]
    public class PedidoConfigController : Controller
    {
        // GET: PedidoConfig
        public ActionResult List()
        {
            return View();
        }

       public ConexionBD.ERPProdEntities db = new ConexionBD.ERPProdEntities();

        [ValidateInput(false)]
        public ActionResult _PedidoConfigGridView()
        {
            var model = db.doc_pedidos_configuracion;
            return PartialView("__PedidoConfigGridView", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult _PedidoConfigGridViewAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] ConexionBD.doc_pedidos_configuracion item)
        {
            var model = db.doc_pedidos_configuracion;
            item.PedidoConfiguracionId = db.doc_pedidos_configuracion.Count() > 0 ?
                       db.doc_pedidos_configuracion.Max(m => m.PedidoConfiguracionId) + 1 :
                       1;
            if (ModelState.IsValid)
            {
                try
                {
                   
                    item.CreadoEl = DateTime.Now;
                    item.CreadoPor = 1;
                    item.Activo = true;
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("__PedidoConfigGridView", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult _PedidoConfigGridViewUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] ConexionBD.doc_pedidos_configuracion item)
        {
            var model = db.doc_pedidos_configuracion;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = db.doc_pedidos_configuracion.FirstOrDefault(it => it.PedidoConfiguracionId == item.PedidoConfiguracionId);
                    if (modelItem != null)
                    {
                        modelItem.Activo = item.Activo;
                        modelItem.Cierre = item.Cierre;
                        modelItem.Descripcion = item.Descripcion;
                        modelItem.FechaFinEntrega = item.FechaFinEntrega;
                        modelItem.FechaInicioEntrega = item.FechaInicioEntrega;
                        modelItem.FechaLlegada = item.FechaLlegada;
                        modelItem.Inicio = item.Inicio;
                        modelItem.ModificadoEl = DateTime.Now;
                        modelItem.ModificadoPor = 1;
                        modelItem.SucursalId = item.SucursalId;
                        //this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("__PedidoConfigGridView", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult _PedidoConfigGridViewDelete([ModelBinder(typeof(DevExpressEditorsBinder))] ConexionBD.doc_pedidos_configuracion item)
        {
            int PedidoConfiguracionId = item.PedidoConfiguracionId;
            var model = db.doc_pedidos_configuracion;
            if (PedidoConfiguracionId >= 0)
            {
                try
                {
                    
                    var item1 = model.FirstOrDefault(it => it.PedidoConfiguracionId == PedidoConfiguracionId);

                    List<doc_pedidos_configuracion_det> lstDetalle = item1.doc_pedidos_configuracion_det.ToList();

                    foreach (var itemDet in lstDetalle)
                    {
                        db.doc_pedidos_configuracion_det.Remove(itemDet);
                    }

                    if (item1 != null)
                        model.Remove(item1);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("__PedidoConfigGridView", model.ToList());
        }
    }
}