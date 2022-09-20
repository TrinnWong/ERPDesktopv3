using ConexionBD.Models;
using DevExpress.XtraEditors;
using ERP.Business;
using ERP.Models.Producto;
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
    public partial class frmMaximosMinimos : Form
    {
        public PuntoVentaContext puntoVentaContext;
        private static frmMaximosMinimos _instance;
        ProductoBusiness oProducto;

        public static frmMaximosMinimos GetInstance()
        {
            if (_instance == null) _instance = new frmMaximosMinimos();
            else _instance.BringToFront();
            return _instance;
        }

        public frmMaximosMinimos()
        {
            InitializeComponent();
            oProducto = new ProductoBusiness();
        }

        private void frmMaximosMinimos_Load(object sender, EventArgs e)
        {
            ProductoMinMaxListModel result = oProducto.GetMaxMinResumen(puntoVentaContext.sucursalId);

            if(result.error.ok)
            {
                uiGrid.DataSource = result.lstProductos.ToList();
            }
            else
            {
                XtraMessageBox.Show("Error al intentar obtener la información", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void uiGridView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                ProductoMinMaxModel row = (ProductoMinMaxModel)uiGridView.GetRow(e.RowHandle);
                if (row.disponible <= row.minimo)
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;
                    //e.HighPriority = true;
                }
            }
        }

        private void frmMaximosMinimos_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }
    }
}
