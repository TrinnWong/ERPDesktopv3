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
    public partial class frmExistenciasV2 : Form
    {
        public int sucursalIdParam = 0;
        public PuntoVentaContext puntoVentaContext;
        public static frmExistenciasV2 GetInstance()
        {
            if (_instance == null) _instance = new frmExistenciasV2();
            else _instance.BringToFront();
            return _instance;
        }
        private static frmExistenciasV2 _instance;

        ERPProdEntities oContext;
        public frmExistenciasV2()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        private void LlenarGrid()
        {
            int sucursalId = sucursalIdParam >0 ? sucursalIdParam : puntoVentaContext.sucursalId;

            uiExistencias.DataSource = oContext.p_productos_existencia_sel(sucursalId, 0, 0, 0, 0, uiSoloExistencias.Checked);
        }

        private void frmExistenciasV2_Load(object sender, EventArgs e)
        {
            cat_sucursales entitySucursal = oContext.cat_sucursales
                .Where(w=> w.Clave == (sucursalIdParam>0 ? sucursalIdParam : puntoVentaContext.sucursalId) ).FirstOrDefault();

            uiSucursal.Text = entitySucursal.NombreSucursal;
            uiSoloExistencias.Checked = true;
            LlenarGrid();
        }

        private void uiSoloExistencias_CheckedChanged(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void frmExistenciasV2_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiViewExistencias_DoubleClick(object sender, EventArgs e)
        {

            if (uiViewExistencias.FocusedRowHandle >= 0)
            {
                p_productos_existencia_sel_Result entity = (p_productos_existencia_sel_Result)uiViewExistencias.GetRow(uiViewExistencias.FocusedRowHandle);

                if (entity != null)
                {
                    frmProductoKardexV2 frmKardex = frmProductoKardexV2.GetInstance();

                    frmKardex.claveProducto = entity.ClaveProducto;
                    frmKardex.WindowState = FormWindowState.Normal;
                    frmKardex.StartPosition = FormStartPosition.CenterParent;
                    frmKardex.puntoVentaContext = this.puntoVentaContext;
                    frmKardex.ShowDialog();
                }


            }
        }
    }
}
