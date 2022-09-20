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
    public partial class frmExistencias : FormERP
    {
        public int familia { get; set; }
        public int subfamilia { get; set; }
        public int linea { get; set; }
        
        public static frmExistencias GetInstance()
        {
            if (_instance == null) _instance = new frmExistencias();
            return _instance;
        }
        private static frmExistencias _instance;

        public frmExistencias()
        {
            InitializeComponent();
            uiGuardar.Text = "BUSCAR";
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
            List<cat_productos> lstProductoss = oContext.cat_productos.ToList();
            lstProductoss.Add(new cat_productos() { ProductoId = 0, Descripcion = "(Todas)" });
            uiProducto.DataSource = lstProductoss;

            // int empresaId = puntoVentaContext.empresaId;

            uiSucursal.DataSource = oContext.cat_sucursales.Where(w => w.Empresa == 1).ToList();

            uiLinea.SelectedValue = linea;
            uiFamilia.SelectedValue = familia;
            uiSubfamilia.SelectedValue = subfamilia;
            uiProducto.SelectedValue = 0;


        }
        private void LlenarGrid()
        {
            int sucursalId = int.Parse(uiSucursal.SelectedValue.ToString());
            int linea = uiLinea.SelectedValue == null ? 0 : int.Parse(uiLinea.SelectedValue.ToString());
            int familia = uiFamilia.SelectedValue == null ? 0 : int.Parse(uiFamilia.SelectedValue.ToString());
            int subFamilia = uiSubfamilia.SelectedValue == null ? 0 : int.Parse(uiSubfamilia.SelectedValue.ToString());
            int productoId = uiProducto.SelectedValue == null ? 0 : int.Parse(uiProducto.SelectedValue.ToString());


            uiGrid.AutoGenerateColumns = false;

            uiGrid.DataSource = oContext.p_productos_existencia_sel(sucursalId, linea, familia, subFamilia, productoId,uiSoloExistencia.Checked);
        }


        private void frmExistencias_Load(object sender, EventArgs e)
        {
            LlenarCombos();

            uiSucursal.SelectedValue = puntoVentaContext.sucursalId;

            LlenarGrid();
        }

        private void frmExistencias_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            LlenarGrid();
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

            if (e.RowIndex >= 0)
            {
                string claveProd = uiGrid.Rows[e.RowIndex].Cells["Clave"].Value != null ? uiGrid.Rows[e.RowIndex].Cells["Clave"].Value.ToString():"";

                if (claveProd.Length > 0)
                {
                    frmProductoKardex frmKardex = frmProductoKardex.GetInstance();

                    frmKardex.claveProducto = claveProd;
                    frmKardex.WindowState = FormWindowState.Normal;
                    frmKardex.StartPosition = FormStartPosition.CenterParent;
                    frmKardex.puntoVentaContext = this.puntoVentaContext;
                    frmKardex.ShowDialog();
                }
               

            }
        }

        public void showReport(bool enviar)
        {
            subRptProductoExistencias oCorte = new subRptProductoExistencias();
            ReportViewer oViewer = new ReportViewer();

            int sucursalId = int.Parse(uiSucursal.SelectedValue.ToString());
            int linea = uiLinea.SelectedValue == null ? 0 : int.Parse(uiLinea.SelectedValue.ToString());
            int familia = uiFamilia.SelectedValue == null ? 0 : int.Parse(uiFamilia.SelectedValue.ToString());
            int subFamilia = uiSubfamilia.SelectedValue == null ? 0 : int.Parse(uiSubfamilia.SelectedValue.ToString());
            int productoId = uiProducto.SelectedValue == null ? 0 : int.Parse(uiProducto.SelectedValue.ToString());

            oCorte.DataSource = oContext.p_productos_existencia_sel(sucursalId, linea, familia, subFamilia, productoId, uiSoloExistencia.Checked).ToList();
            oViewer.ShowTicket(oCorte);

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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showReport(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showReport(true);
        }
    }
}
