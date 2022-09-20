using DevExpress.Web.Mvc;
using ERP.Models.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Web.Controllers
{
    public class PedidoConfigDetController : Controller
    {
        ConexionBD.ERPProdEntities oContext;

        public PedidoConfigDetController()
        {
            oContext = new ConexionBD.ERPProdEntities();
        }

        // GET: PedidoConfigDet
        public ActionResult Upd(int id)
        {
            PedidoConfiguracionViewModel viewModel = new PedidoConfiguracionViewModel();

            viewModel = oContext.doc_pedidos_configuracion
                .Where(
                    w => w.PedidoConfiguracionId == id
                )
                .Select(
                    s => new PedidoConfiguracionViewModel()
                    {
                        Activo = s.Activo,
                        Cierre = s.Cierre,
                        Descripcion = s.Descripcion,
                        FechaFinEntrega = s.FechaFinEntrega,
                        FechaInicioEntrega = s.FechaInicioEntrega,
                        FechaLlegada = s.FechaLlegada,
                        Inicio = s.Inicio,
                        PedidoConfiguracionId = s.PedidoConfiguracionId,
                        SucursalId = s.SucursalId

                    }
                ).FirstOrDefault();

            
            return View(viewModel);
        }

        ConexionBD.ERPProdEntities db = new ConexionBD.ERPProdEntities();

        [ValidateInput(false)]
        public ActionResult _PedidoConfigDetGrid(int id)
        {
            ViewData["PedidoConfiguracionId"] = id;
            var model = db.doc_pedidos_configuracion_det.Where(w=> w.PedidoConfiguracionId == id);
            return PartialView("__PedidoConfigDetGrid", model.ToList());
        }

      

        [HttpPost, ValidateInput(false)]
        public ActionResult _PedidoConfigDetGridAddNew(
            [ModelBinder(typeof(DevExpressEditorsBinder))] ConexionBD.doc_pedidos_configuracion_det item,int id)
        {
            var model = db.doc_pedidos_configuracion_det;

            item.PedidoConfiguracionId = id;
            item.PedidoConfiguracionDetId = db.doc_pedidos_configuracion_det.Count() > 0 ?
                db.doc_pedidos_configuracion_det.Max(m => m.PedidoConfiguracionDetId) + 1 : 1;
            if (ModelState.IsValid)
            {
                try
                {
                    item.CreadoEl = DateTime.Now;
                    item.CreadoPor = 1;

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
            return PartialView("__PedidoConfigDetGrid", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult _PedidoConfigDetGridUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] ConexionBD.doc_pedidos_configuracion_det item)
        {
            var model = db.doc_pedidos_configuracion_det;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.PedidoConfiguracionDetId == item.PedidoConfiguracionDetId);
                    if (modelItem != null)
                    {
                        modelItem.ProductoId = item.ProductoId;
                        modelItem.Precio = item.Precio;
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
            return PartialView("__PedidoConfigDetGrid", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult _PedidoConfigDetGridDelete([ModelBinder(typeof(DevExpressEditorsBinder))] ConexionBD.doc_pedidos_configuracion_det item)
        {
            int PedidoConfiguracionDetId = item.PedidoConfiguracionDetId;
            var model = db.doc_pedidos_configuracion_det;
            if (PedidoConfiguracionDetId >= 0)
            {
                try
                {
                    var item1 = model.FirstOrDefault(it => it.PedidoConfiguracionDetId == PedidoConfiguracionDetId);
                    if (item1 != null)
                        model.Remove(item1);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("__PedidoConfigDetGrid", model.ToList());
        }
    }
}