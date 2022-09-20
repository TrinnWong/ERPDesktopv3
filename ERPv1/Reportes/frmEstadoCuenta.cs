using ConexionBD;
using ERP.Common.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPv1.Reportes
{
    public partial class frmEstadoCuenta : FormBaseXtraForm
    {
        private static frmEstadoCuenta _instance;
        string error = "";
        List<p_rpt_estado_cuenta_detalle_Result> lstResult;
        int err;
        public static frmEstadoCuenta GetInstance()
        {
            if (_instance == null) _instance = new frmEstadoCuenta();
            else _instance.BringToFront();
            return _instance;
        }

        public frmEstadoCuenta()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        public void LlenarGrid()
        {
            try
            {
                oContext = new ERPProdEntities();
                lstResult = oContext.p_rpt_estado_cuenta_detalle(Convert.ToInt32(uiSucursal.EditValue),"all", uiDel.DateTime, uiAl.DateTime).ToList();

                uiGrid.DataSource = lstResult;

                uiCargos.EditValue = lstResult.Where(w => w.CargoAbono == false).Sum(s => s.Total)*-1;
                uiVentas.EditValue = lstResult.Where(w => w.CargoAbono == true).Sum(s => s.Total);
                uiBalance.EditValue = uiVentas.Value - uiCargos.Value;
                uiGridView.ExpandAllGroups();

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

        private void frmEstadoCuenta_HelpButtonClicked(object sender, CancelEventArgs e)
        {

        }

        private void frmEstadoCuenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        public void LlenarSucursales()
        {
            try
            {
                oContext = new ERPProdEntities();

                uiSucursal.Properties.DataSource = oContext.cat_sucursales.ToList();

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

        private void frmEstadoCuenta_Load(object sender, EventArgs e)
        {
            LlenarSucursales();
            uiDel.DateTime = DateTime.Now;
            uiAl.DateTime = DateTime.Now;
        }

        private void uiSucursal_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
