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
    public partial class frmRptVentasVendedor : Form
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        private static frmRptVentasVendedor _instance;
        public static frmRptVentasVendedor GetInstance()
        {

            if (_instance == null) _instance = new frmRptVentasVendedor();
            return _instance;
        }
        public frmRptVentasVendedor()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
            
        }

        private void llenarComboCajero()
        {
            int cajaId = uiCaja.SelectedValue == null ? 0 :
                int.Parse(uiCaja.SelectedValue.ToString());

            List<cat_usuarios> lstUsuario = oContext.cat_usuarios.ToList();
            lstUsuario.Add(
                    new cat_usuarios()
                    {
                        IdUsuario = 0,
                        NombreUsuario = "(Todos)"
                    }
                );

            uiCajero.DataSource = lstUsuario;
        }

        public void cargarCombos()
        {

            llenarComboCajero();
            List<cat_sucursales> lstSucursales = ERP.Business.SucursalBusiness.ObtenSucursalesPorUsuario(this.puntoVentaContext.empresaId,
                    this.puntoVentaContext.usuarioId);

            uiSucursal.DataSource = lstSucursales.ToList();
        }

        private void uiSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sucursalId = int.Parse(uiSucursal.SelectedValue.ToString());

            List<cat_cajas> lstCajas = oContext.cat_cajas.Where(w => w.Sucursal == sucursalId).ToList();
            lstCajas.Add(
                new cat_cajas() {
                    Clave = 0,
                     Descripcion = "(Todos)"
                }
                );


            uiCaja.DataSource = lstCajas.ToList();

            uiCaja.SelectedValue = 0;
        }

        public void showReport(bool enviar)
        {
            rptVentasVendedor oReport = new rptVentasVendedor();

            int sucursal = uiSucursal.SelectedValue == null ? 0 : int.Parse(uiSucursal.SelectedValue.ToString());
            int caja = uiCaja.SelectedValue == null ? 0 : int.Parse(uiCaja.SelectedValue.ToString());
            int cajero = uiCajero.SelectedValue == null ? 0 :
                int.Parse(uiCajero.SelectedValue.ToString());

            oReport.DataSource = oContext.p_rpt_ventas_vendedor(
                sucursal,
                caja,
                cajero,
                uiDel.Value,
                uiAl.Value).ToList();




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

        private void frmRptVentasVendedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showReport(true);
        }

        private void frmRptVentasVendedor_Load(object sender, EventArgs e)
        {
            cargarCombos();
        }
    }
}
