using ConexionBD;
using ConexionBD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Inventarios
{
    public partial class frmProductoKardexV2 : Form
    {
        int productoId;
        public string claveProducto = "";
        public PuntoVentaContext puntoVentaContext;
        ERPProdEntities oContext;
        private static frmProductoKardexV2 _instance;
        public static frmProductoKardexV2 GetInstance()
        {
            if (_instance == null) _instance = new frmProductoKardexV2();
            return _instance;
        }

        public frmProductoKardexV2()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        private void buscar()
        {
            oContext = new ERPProdEntities();

            try
            {
                int sucursalId = this.puntoVentaContext.sucursalId;

                uiGrid.DataSource = oContext.p_inv_producto_kardex_grd(sucursalId, productoId);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void buscarProducto()
        {
            try
            {
                productoId = 0;
                cat_productos entity = oContext.cat_productos.Where(w => w.Clave == claveProducto).FirstOrDefault();

                if (entity != null)
                {
                    uiProducto.Text = entity.Clave + "-"+ entity.Descripcion;
                    productoId = entity.ProductoId;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void frmProductoKardexV2_Load(object sender, EventArgs e)
        {
          
            buscarProducto();
            buscar();
        }

        private void frmProductoKardexV2_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiGridView_DoubleClick(object sender, EventArgs e)
        {
            //if (uiGridView.FocusedRowHandle >= 0)
            //{
                
            //    if (claveProd.Length > 0)
            //    {
            //        frmProductoKardexV2 frmKardex = frmProductoKardexV2.GetInstance();

            //        frmKardex.claveProducto = claveProd;
            //        frmKardex.WindowState = FormWindowState.Normal;
            //        frmKardex.StartPosition = FormStartPosition.CenterParent;
            //        frmKardex.puntoVentaContext = this.puntoVentaContext;
            //        frmKardex.ShowDialog();
            //    }


            //}
        }
    }
}
