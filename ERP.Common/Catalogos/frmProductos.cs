using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Catalogos
{
    public partial class frmProductos : XtraForm
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        public frmProductos()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        private static frmProductos _instance;

        public static frmProductos GetInstance()
        {

            if (_instance == null) _instance = new frmProductos();
            else _instance.BringToFront();
            return _instance;
        }


        private void frmProductos_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }

        public void llenarGrid()
        {
            try
            {
                oContext = new ERPProdEntities();
                uiGrid.DataSource = oContext.p_cat_productos_grd(puntoVentaContext.empresaId);
               
                uiGridView.ExpandAllGroups();
            }
            catch (Exception ex)
            {

               
            }
        }

        private void frmProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiNuevo_Click(object sender, EventArgs e)
        {
            frmPoductosEdit oForm = new frmPoductosEdit();
            oForm.esNuevo = true;
            oForm.puntoVentaContext = this.puntoVentaContext;
            oForm.ShowDialog();
        }

        private void uiGridView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
               p_cat_productos_grd_Result productoId = (p_cat_productos_grd_Result)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                if(productoId != null)
                {
                    frmPoductosEdit oForm = new frmPoductosEdit();
                    oForm.productoId = int.Parse(productoId.ProductoId.ToString());
                    oForm.puntoVentaContext = this.puntoVentaContext;
                    oForm.esNuevo = false;
                    oForm.ShowDialog();
                    
                }
            }
            catch (Exception ex)
            {

               
            }
        }

        private void uiEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                p_cat_productos_grd_Result productoId = (p_cat_productos_grd_Result)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                if(productoId.ProductoId > 0)
                {
                    int id = 0;
                    cat_productos producto = oContext.cat_productos
                        .Where(w => w.ProductoId == id).FirstOrDefault();

                    producto.Estatus = false;
                    oContext.SaveChanges();

                    XtraMessageBox.Show("El producto se dio de baja con éxito", "Aviso", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                }
                else
                {
                    XtraMessageBox.Show("Es necesario seleccionar un producto","Aviso", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                

            }
            catch (Exception ex)
            {

               
            }
        }
    }
}
