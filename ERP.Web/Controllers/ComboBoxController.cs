using ConexionBD.Models;
using DevExpress.Web.Mvc;
using ERP.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Web.Controllers
{
    public class ComboBoxController : Controller
    {
        ConexionBD.ERPProdEntities oContext;

        public ComboBoxController()
        {
           
            oContext = new ConexionBD.ERPProdEntities();
        }
        // GET: ComboBox
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductoComboBox()
        {
            List<ConexionBD.Models.ComboBoxViewModel> viewModel = new List<ConexionBD.Models.ComboBoxViewModel>();

            viewModel = oContext.cat_productos
                .Select(
                    s=> new ComboBoxViewModel()
                    {
                          id = s.ProductoId,
                           descripcion = s.Clave + " "+ s.Descripcion +" "+ 
                           (s.Talla != null ? s.Talla : "")
                           
                    }
                )
                .OrderBy(o=> o.descripcion)
                .ToList();

            
            return PartialView(viewModel);
        }

        public ActionResult ProductoImgComboBox()
        {
            List<ERP.Models.ComboBox.ProductoComboBoxViewModel> viewModel = new List<ERP.Models.ComboBox.ProductoComboBoxViewModel>();

            viewModel = oContext.cat_productos
                .Select(
                    s => new ERP.Models.ComboBox.ProductoComboBoxViewModel()
                    {
                        id = s.ProductoId,
                        descripcion = s.Clave + " " + s.Descripcion + " " +
                           (s.Talla != null ? s.Talla : ""),
                        marca = s.cat_marcas != null ? s.cat_marcas.Descripcion : "",
                        pathFoto = "https://masymaszapatos.com/Content/Productos/1.jpg"

                    }
                )
                .OrderBy(o => o.descripcion)
                .ToList();


            return PartialView(viewModel);
        }

        public ActionResult SucursalComboBox(int? sucursalId)
        {
            UsuarioModel usuario = (UsuarioModel)Session["Usuario"];
            int sucursalId_ = usuario.lstSucursales.FirstOrDefault().sucursalId;
            List<ConexionBD.Models.ComboBoxViewModel> viewModel = new List<ConexionBD.Models.ComboBoxViewModel>();

            viewModel = oContext.cat_sucursales
                .Where(w=> w.Clave == sucursalId_)
                .Select(
                    s => new ComboBoxViewModel()
                    {
                        id = s.Clave,
                        descripcion = s.NombreSucursal

                    }
                )
                
                .OrderBy(o => o.descripcion)
                .ToList();

            ViewData["SucursalId"] = sucursalId == null ? null: sucursalId -1;
            return PartialView(viewModel);
        }


    }
}