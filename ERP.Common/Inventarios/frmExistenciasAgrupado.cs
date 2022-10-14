using ConexionBD;
using ConexionBD.Forms;
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

namespace ERP.Common.Inventarios
{
    public partial class frmExistenciasAgrupado : FormERP
    {
        public static frmExistenciasAgrupado GetInstance()
        {
            if (_instance == null) _instance = new frmExistenciasAgrupado();
            return _instance;
        }
        private static frmExistenciasAgrupado _instance;

        public frmExistenciasAgrupado()
        {
            InitializeComponent();
            uiGuardar.Text = "VER EN CARTA";
            oContext = new ERPProdEntities();
        }

        private void LlenarCombos()
        {

            /**********LINEAS*************/
            List<cat_lineas> lstLineas = oContext.cat_lineas.ToList();
            lstLineas.Add(new cat_lineas() { Clave = 0, Descripcion = "(Todas)" });
            uiLinea.DataSource = lstLineas;

            /**********FAMILIAS************/
            List<cat_familias> lstFamilias = oContext.cat_familias.ToList();
            lstFamilias.Add(new cat_familias() { Clave = 0, Descripcion = "(Todas)" });
            uiFamilia.DataSource = lstFamilias;

            /**********SUBFAMILIAS************/
            List<cat_subfamilias> lstSubFamilias = oContext.cat_subfamilias.ToList();
            lstSubFamilias.Add(new cat_subfamilias() { Clave = 0, Descripcion = "(Todas)" });
            uiSubfamilia.DataSource = lstSubFamilias;

            /******productos**************/
            //List<cat_productos> lstProductoss = oContext.cat_productos.ToList();
            //lstProductoss.Add(new cat_productos() { ProductoId = 0, Descripcion = "(Todas)" });
            //uiProducto.DataSource = lstProductoss;

            // int empresaId = puntoVentaContext.empresaId;

            uiSucursal.DataSource = ERP.Business.SucursalBusiness.ObtenSucursalesPorUsuario(this.puntoVentaContext.empresaId,
                    this.puntoVentaContext.usuarioId);

            uiLinea.SelectedValue = 0;
            uiFamilia.SelectedValue = 0;
            uiSubfamilia.SelectedValue = 0;
            //uiProducto.SelectedValue = 0;


        }
        private void LlenarGrid()
        {
            int sucursalId = int.Parse(uiSucursal.SelectedValue.ToString());
            int linea = uiLinea.SelectedValue == null ? 0 : int.Parse(uiLinea.SelectedValue.ToString());
            int familia = uiFamilia.SelectedValue == null ? 0 : int.Parse(uiFamilia.SelectedValue.ToString());
            int subFamilia = uiSubfamilia.SelectedValue == null ? 0 : int.Parse(uiSubfamilia.SelectedValue.ToString());
            //int productoId = uiProducto.SelectedValue == null ? 0 : int.Parse(uiProducto.SelectedValue.ToString());


            //uiGrid.AutoGenerateColumns = false;

            //uiGrid.DataSource = oContext.p_rpt_existencias_agrupado(sucursalId, linea, familia, subFamilia,uiLineaG.Checked,uiFamiliaG.Checked,uiSubfamiliaG.Checked ,uiSoloExistencia.Checked).ToList();
        }


        private void frmExistencias_Load(object sender, EventArgs e)
        {
            LlenarCombos();

            uiSucursal.SelectedValue = puntoVentaContext.sucursalId;
        }

        private void frmExistencias_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            // LlenarGrid();


            int linea = uiLinea.SelectedValue == null ? 0 : int.Parse(uiLinea.SelectedValue.ToString());
            int familia = uiFamilia.SelectedValue == null ? 0 : int.Parse(uiFamilia.SelectedValue.ToString());
            int subFamilia = uiSubfamilia.SelectedValue == null ? 0 : int.Parse(uiSubfamilia.SelectedValue.ToString());

            rptExistenciasCarta oCorte = new rptExistenciasCarta(uiLineaG.Checked, uiFamiliaG.Checked, uiSubfamiliaG.Checked, uiProguctoG.Checked);
            ReportViewer oViewer = new ReportViewer();

            int sucursalId = int.Parse(uiSucursal.SelectedValue.ToString());



            oCorte.DataSource = oContext.p_rpt_productos_existencias(sucursalId, linea, familia, subFamilia, uiSoloExistencia.Checked, uiHabilitaFecha.Checked ? (DateTime?)uiFechaHasta.DateTime : null,
                uiClaveIni.Text,uiClaveFin.Text).ToList();
            oViewer.ShowPreview(oCorte);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void uiGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            //if (e.RowIndex >= 0)
            //{
            //    string claveProd = uiGrid.Rows[e.RowIndex].Cells["Clave"].Value != null ? uiGrid.Rows[e.RowIndex].Cells["Clave"].Value.ToString():"";

            //    if (claveProd.Length > 0)
            //    {
            //        int linea = uiLineaG.Checked ? int.Parse(claveProd) : 0;
            //        int familia = uiFamiliaG.Checked ? int.Parse(claveProd) : 0;
            //        int subFamilia = uiSubfamiliaG.Checked ? int.Parse(claveProd) : 0;
            //        frmExistencias frmKardex = frmExistencias.GetInstance();

            //        //frmKardex.claveProducto = claveProd;
            //        frmKardex.linea = linea;
            //        frmKardex.familia = familia;
            //        frmKardex.subfamilia = subFamilia;
            //        frmKardex.WindowState = FormWindowState.Normal;
            //        frmKardex.StartPosition = FormStartPosition.CenterParent;
            //        frmKardex.puntoVentaContext = this.puntoVentaContext;
            //        frmKardex.ShowDialog();
            //    }
               

            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            showReport(false);            
        }

        public void showReport(bool enviar)
        {
            
            int linea = uiLinea.SelectedValue == null ? 0 : int.Parse(uiLinea.SelectedValue.ToString());
            int familia = uiFamilia.SelectedValue == null ? 0 : int.Parse(uiFamilia.SelectedValue.ToString());
            int subFamilia = uiSubfamilia.SelectedValue == null ? 0 : int.Parse(uiSubfamilia.SelectedValue.ToString());

            rptExistenciasTicket oCorte = new rptExistenciasTicket(uiLineaG.Checked, uiFamiliaG.Checked, uiSubfamiliaG.Checked, uiProguctoG.Checked);
            ReportViewer oViewer = new ReportViewer();

            int sucursalId = int.Parse(uiSucursal.SelectedValue.ToString());



            oCorte.DataSource = oContext.p_rpt_productos_existencias(sucursalId, linea, familia, subFamilia, uiSoloExistencia.Checked,
               uiHabilitaFecha.Checked ? (DateTime?)uiFechaHasta.DateTime : null,uiClaveIni.Text,uiClaveFin.Text).ToList();


            if (enviar)
            {
                string error = "";
                ReportesBusiness oReportB = new ReportesBusiness();
                error = oReportB.enviarReporteCorreoEnc(this.puntoVentaContext.sucursalId, oCorte);

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
                oViewer.ShowTicket(oCorte);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showReport(true);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiHabilitaFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (uiHabilitaFecha.Checked)
            {
                uiFechaHasta.EditValue = DateTime.Now;
                uiFechaHasta.Enabled = true;

            }
            else
            {
                uiFechaHasta.EditValue = null;
                uiFechaHasta.Enabled = false;
            }
        }
    }
}
