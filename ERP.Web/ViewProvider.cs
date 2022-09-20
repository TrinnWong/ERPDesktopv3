using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web
{
    public static class ErpProdProvider
    {
        public static IEnumerable GetSucursales()
        {
            ConexionBD.ERPProdEntities oContext = new ConexionBD.ERPProdEntities();


            return oContext.cat_sucursales.ToList(); 
        }

        public static IEnumerable GetProductos()
        {
            ConexionBD.ERPProdEntities oContext = new ConexionBD.ERPProdEntities();


            return oContext.cat_productos.ToList();
        }

        public static IEnumerable GetProductosCmb()
        {
            ConexionBD.ERPProdEntities oContext = new ConexionBD.ERPProdEntities();
            List<ERP.Models.ComboBox.ProductoComboBoxViewModel> viewModel = new List<ERP.Models.ComboBox.ProductoComboBoxViewModel>();

            viewModel = oContext.cat_productos
                .Select(
                    s => new ERP.Models.ComboBox.ProductoComboBoxViewModel()
                    {
                        id = s.ProductoId,
                        descripcion = s.Clave + " " + s.Descripcion + " " +
                           (s.Talla != null ? s.Talla : "") +
                           (s.Color != null ? s.Color : ""),
                        marca = s.cat_marcas != null ? s.cat_marcas.Descripcion : "",
                        pathFoto = "https://masymaszapatos.com/Content/Productos/1.jpg"

                    }
                )
                .OrderBy(o => o.descripcion)
                .ToList();


            return viewModel.ToList();
        }
    }
}