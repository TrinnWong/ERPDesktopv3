using ConexionBD;
using ERP.Common.Base;
using ERP.Models.Precios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPv1.Productos
{
    public partial class frmCambioPrecioList : FormBaseXtraForm
    {
        int err = 0;
        private static frmCambioPrecioList _instance;
        public static frmCambioPrecioList GetInstance()
        {
            if (_instance == null) _instance = new frmCambioPrecioList();
            else _instance.BringToFront();
            return _instance;
        }
        public frmCambioPrecioList()
        {
            InitializeComponent();
        }

        private void frmCambioPrecioList_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        public void llenarGrid()
        {
            try
            {
                string filtro = uiBuscar.Text.ToUpper();
                oContext = new ConexionBD.ERPProdEntities();

                uiGrid.DataSource = oContext.cat_productos_precios
                    .Where(w => (w.cat_productos.Descripcion.ToUpper().Contains(filtro) || 
                    filtro == "") &&
                    w.cat_productos.Estatus == true &&
                    w.IdPrecio == 1 
                    )
                    .Select(
                        s=> new ProductoPrecioModel()
                        {
                             clave = s.cat_productos.Clave,
                              precioOriginal = s.Precio,                              
                               precio = s.Precio,
                                precioId = s.IdProductoPrecio,
                                 producto = s.cat_productos.Descripcion,
                                  productoId = s.IdProducto,
                                  costo = s.cat_productos.cat_productos_existencias
                                  .Where(w=> w.SucursalId == puntoVentaContext.sucursalId).Count() > 0 ?
                                  s.cat_productos.cat_productos_existencias
                                  .Where(w => w.SucursalId == puntoVentaContext.sucursalId).FirstOrDefault().CostoCapturaUsuario ?? 0: 0,
                                  costoOriginal = s.cat_productos.cat_productos_existencias
                                  .Where(w => w.SucursalId == puntoVentaContext.sucursalId).Count() > 0 ?
                                  s.cat_productos.cat_productos_existencias
                                  .Where(w => w.SucursalId == puntoVentaContext.sucursalId).FirstOrDefault().CostoCapturaUsuario ?? 0 : 0
                        }
                    )
                    .ToList();

            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void frmCambioPrecioList_Load(object sender, EventArgs e)
        {
           
        }

        private void uiBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                llenarGrid();
            }
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            try
            {
                oContext = new ERPProdEntities();
                List<ProductoPrecioModel> lstData = (List<ProductoPrecioModel>)uiGrid.DataSource;

                foreach (ProductoPrecioModel item in lstData.Where(w=> w.modificado))
                {
                    cat_productos_precios oProductoPrecio = oContext.cat_productos_precios
                        .Where(w=> w.IdProductoPrecio == item.precioId).FirstOrDefault();

                    oProductoPrecio.Precio = item.precio;
                    oContext.SaveChanges();

                    cat_productos_existencias oProductoExistencia = oContext.cat_productos_existencias
                        .Where(w => w.ProductoId == item.productoId && w.SucursalId == puntoVentaContext.sucursalId).FirstOrDefault();

                    if(oProductoExistencia != null)
                    {
                        oProductoExistencia.CostoCapturaUsuario = item.costo;
                        oContext.SaveChanges();
                    }
                }

                ERP.Utils.MessageBoxUtil.ShowOk();
                llenarGrid();
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                     "ERP",
                                     this.Name,
                                     ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            llenarGrid();
        }
    }
}
