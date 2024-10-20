﻿using ConexionBD;
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
    public partial class frmRptNotasVentaDetallado : Form
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        private static frmRptNotasVentaDetallado _instance;
        public static frmRptNotasVentaDetallado GetInstance()
        {

            if (_instance == null) _instance = new frmRptNotasVentaDetallado();
            return _instance;
        }
        public frmRptNotasVentaDetallado()
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
            rptNotasVentaDetallado oReport = new rptNotasVentaDetallado();

            int sucursal = uiSucursal.SelectedValue == null ? 0 : int.Parse(uiSucursal.SelectedValue.ToString());
            int caja = uiCaja.SelectedValue == null ? 0 : int.Parse(uiCaja.SelectedValue.ToString());

            oReport.DataSource = oContext.p_rpt_notas_venta_detalle(
                sucursal,
                caja,
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

        private void frmRptNotasVentaDetallado_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showReport(true);
        }
    }
}
