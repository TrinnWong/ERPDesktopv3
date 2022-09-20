using ConexionBD;
using ConexionBD.Models;
using ERP.Common;
using ERP.Common.Reports;
using ERP.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPv1.Reports
{
    public partial class frmRptNotasVentaResumido_Mesa : Form
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        private static frmRptNotasVentaResumido_Mesa _instance;
        public static frmRptNotasVentaResumido_Mesa GetInstance()
        {

            if (_instance == null) _instance = new frmRptNotasVentaResumido_Mesa();
            else _instance.BringToFront();
            return _instance;
        }
        public frmRptNotasVentaResumido_Mesa()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
            cargarCombos();
        }

        public void cargarCombos()
        {
            List<cat_sucursales> lstSucursales = oContext.cat_sucursales.ToList();

            uiSucursal.DataSource = lstSucursales.ToList();
        }

        private void uiSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sucursalId = int.Parse(uiSucursal.SelectedValue.ToString());

            List<cat_rest_mesas> lstCajas = oContext.cat_rest_mesas.Where(w => w.SucursalId == sucursalId).ToList();


            lstCajas.Add(
               new cat_rest_mesas()
               {
                   MesaId = 0,
                   Nombre = "(Todos)"
               }
               );

            uiCaja.DataSource = lstCajas.ToList();



            uiCaja.SelectedValue = 0;
        }


        public void showReport(bool enviar)
        {
            rptNotasVentaResumido_Mesa oReport = new rptNotasVentaResumido_Mesa();
            string error = "";

            int sucursal = uiSucursal.SelectedValue == null ? 0 : int.Parse(uiSucursal.SelectedValue.ToString());
            int caja = uiCaja.SelectedValue == null ? 0 : int.Parse(uiCaja.SelectedValue.ToString());

            oReport.DataSource = oContext.p_rpt_notas_venta_resumido(
                sucursal,
                0,
                caja,
                uiDel.Value,
                uiAl.Value).OrderBy(o=> o.Mesa).ThenBy(o=> o.Fecha).ToList();



            if (enviar)
            {
                ReportesBusiness oReportB = new ReportesBusiness();
                error = oReportB.enviarReporteCorreoEnc(this.puntoVentaContext.sucursalId, oReport);

                if (error.Length > 0)
                {
                    MessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Se ha enviado el reporte con éxito", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                ReportViewer oViewer = new ReportViewer();
                oViewer.ShowPreview(oReport);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showReport(false);
        }

        private void frmRptNotasVentaResumido_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showReport(true);
        }
    }
}
