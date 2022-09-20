using ConexionBD;
using ConexionBD.Models;
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
using static ConexionBD.Enumerados;

namespace ERP.Common.PuntoVenta
{
    public partial class frmDevoluciones : Form
    {
        ERPProdEntities oContext;

        private static frmDevoluciones _instance;
        public PuntoVentaContext puntoVentaContext;

        public static frmDevoluciones GetInstance()
        {
            if (_instance == null) _instance = new frmDevoluciones();
            else _instance.BringToFront();
            return _instance;
        }
        public frmDevoluciones()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
            LlenarGrid();
        }

        public void LlenarGrid()
        {
            try
            {
                uiGrid.AutoGenerateColumns = false;
                uiGrid.DataSource = oContext.doc_devoluciones.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmDevolucionesUpd frmo = frmDevolucionesUpd.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                //this.Owner.MdiChildren[0] = frmo;
                frmo.MdiParent = this.MdiParent;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.accionForm = (int)accionForm.agregar;
                frmo.Show();

            }
        }
        private void eliminar()
        {
            try
            {
                int rowIndex = uiGrid.CurrentCell.RowIndex;

                if (rowIndex >= 0)
                {
                    int id = int.Parse(uiGrid.Rows[rowIndex].Cells["DevolucionId"].Value.ToString());

                    frmDevolucionesUpd frmo = frmDevolucionesUpd.GetInstance();

                    if (!frmo.Visible)
                    {
                        //frmo = new frmPuntoVenta();
                        //this.Owner.MdiChildren[0] = frmo;
                        frmo.MdiParent = this.MdiParent;
                        frmo.puntoVentaContext = this.puntoVentaContext;
                        frmo.accionForm = (int)accionForm.eliminar;
                        frmo.devolucionId = id;
                        frmo.Show();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");

            }

        }

        private void uiGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int id = int.Parse(uiGrid.Rows[e.RowIndex].Cells["DevolucionId"].Value.ToString());
                frmDevolucionesUpd frmo = frmDevolucionesUpd.GetInstance();

                if (!frmo.Visible)
                {
                    //frmo = new frmPuntoVenta();
                    //this.Owner.MdiChildren[0] = frmo;
                    frmo.MdiParent = this.MdiParent;
                    frmo.puntoVentaContext = this.puntoVentaContext;
                    frmo.accionForm = (int)accionForm.actualizar;
                    frmo.devolucionId = id;
                    frmo.Show();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void frmDevoluciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void imprimir(int id)
        {
            rptDevolucionTicket oTicket = new rptDevolucionTicket();

            ReportViewer oViewer = new ReportViewer();

            oTicket.DataSource = oContext.p_rpt_devolucion(id).ToList();

            oViewer.ShowTicket(oTicket);
            //oViewer.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = uiGrid.CurrentCell.RowIndex;

                if (rowIndex >= 0)
                {
                    int id = int.Parse(uiGrid.Rows[rowIndex].Cells["DevolucionId"].Value.ToString());

                    imprimir(id);
                }
            }
            catch (Exception ex)
            {


            }
        }
    }
}
