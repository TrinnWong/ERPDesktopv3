using ConexionBD;
using ConexionBD.Models;
using ERP.Common.Forms;
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
    public partial class frmProductoKardex : Form
    {
        int productoId;
        public string claveProducto="";
        public PuntoVentaContext puntoVentaContext;
        ERPProdEntities oContext;
        private static frmProductoKardex _instance;
        public static frmProductoKardex GetInstance()
        {
            if (_instance == null) _instance = new frmProductoKardex();
            return _instance;
        }
        public frmProductoKardex()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        private void frmProductoKardex_Load(object sender, EventArgs e)
        {
            this.uiGrid.Columns[11].DefaultCellStyle.Format = "c2";
            //this.uiGrid.Columns[12].DefaultCellStyle.Format = "c2";
            //this.uiGrid.Columns[13].DefaultCellStyle.Format = "c2";
            //this.uiGrid.Columns[14].DefaultCellStyle.Format = "c2";
            //this.uiGrid.Columns[15].DefaultCellStyle.Format = "c2";

            this.uiGrid.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGrid.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGrid.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGrid.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.uiGrid.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.uiGrid.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.uiGrid.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //this.uiGrid.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            uiSucursal.DataSource = oContext.cat_sucursales.ToList();
            uiSucursal.SelectedValue = puntoVentaContext.sucursalId;

            if (claveProducto.Length > 0)
            {
                uiClaveProd.Text = claveProducto;
                uiClaveProd.Enabled = false;
                uiDescripcionProd.Enabled = false;
                buscarProducto();
                buscar();
            }

           
        }

        private void buscar()
        {
            oContext = new ERPProdEntities();

            try
            {
                int sucursalId = int.Parse(uiSucursal.SelectedValue.ToString());

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
                cat_productos entity = oContext.cat_productos.Where(w => w.Clave == uiClaveProd.Text).FirstOrDefault();

                if (entity != null)
                {
                    uiDescripcionProd.Text = entity.Descripcion;
                    productoId = entity.ProductoId;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void frmProductoKardex_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiClaveProd_Validating(object sender, CancelEventArgs e)
        {
            buscarProducto();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buscar();
        }

        public void buscarProductoF3(string clave)
        {
            uiClaveProd.Text = clave;
            buscarProducto();
            buscar();

        }

        private void frmProductoKardex_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                frmBuscarProducto f = new frmBuscarProducto();
                f.opcionERP = (int)Enumerados.opcionesERP.kardexProducto;
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog(this);
            }
        }

        private void uiGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void uiGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
