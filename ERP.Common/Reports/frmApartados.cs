using ConexionBD;
using ConexionBD.Models;
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

namespace ERP.Common.Reports
{
    public partial class frmApartados : Form
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        private static frmApartados _instance;
        public static frmApartados GetInstance()
        {

            if (_instance == null) _instance = new frmApartados();
            return _instance;
        }
        public frmApartados()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
            

        }

        public void cargarCombos()
        {
            List<cat_sucursales> lstSucursales = ERP.Business.SucursalBusiness.ObtenSucursalesPorUsuario(this.puntoVentaContext.empresaId,
                    this.puntoVentaContext.usuarioId);

            uiSucursal.DataSource = lstSucursales.ToList();

            List<cat_clientes> lstClientes = oContext.cat_clientes.ToList();

            lstClientes.Add(
                new cat_clientes()
                {
                    ClienteId = 0,
                    Nombre = "(Todos)"
                }
                );

            uiCliente.DataSource = lstClientes;

            uiCliente.SelectedValue = 0;
        }

        private void uiSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int sucursalId = int.Parse(uiSucursal.SelectedValue.ToString());

            //List<cat_cajas> lstCajas = oContext.cat_cajas.Where(w => w.Sucursal == sucursalId).ToList();
            //lstCajas.Add(
            //    new cat_cajas() {
            //        Clave = 0,
            //         Descripcion = "(Todos)"
            //    }
            //    );


            //uiCaja.DataSource = lstCajas.ToList();

            //uiCaja.SelectedValue = 0;
        }
        public void showReport(bool enviar)
        {
            rptApartados oReport = new rptApartados();

            int sucursal = uiSucursal.SelectedValue == null ? 0 : int.Parse(uiSucursal.SelectedValue.ToString());


            int clienteId = Convert.ToInt32(uiCliente.SelectedValue.ToString());
            oReport.DataSource = oContext.p_rpt_apartados(
                sucursal,
                  clienteId,
                uiDel.Value,
                uiAl.Value, uiSoloVencido.Checked).ToList();



            if (enviar)
            {
                string error = "";
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
            else {
                ReportViewer oViewer = new ReportViewer();

                oViewer.ShowPreview(oReport);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showReport(false);
        }

        private void frmRptCorteCajaResumido_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiSoloVencido_CheckedChanged(object sender, EventArgs e)
        {
            CambiaVencido();
        }

        private void CambiaVencido()
        {
            if (uiSoloVencido.Checked)
            {
                uiDel.ResetText();
                uiAl.ResetText();

                uiDel.Enabled = false;
                uiAl.Enabled = false;
            }
            else
            {
                uiDel.Enabled = true;
                uiAl.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showReport(true);
        }

        private void frmApartados_Load(object sender, EventArgs e)
        {
            cargarCombos();
            CambiaVencido();

        }
    }
}
