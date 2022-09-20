using ConexionBD;
using ConexionBD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ConexionBD.Enumerados;

namespace PuntoVenta
{
    public partial class frmGastosList : Form
    {
        ERPProdEntities oContext;
        private static frmGastosList _instance;
        public PuntoVentaContext puntoVentaContext;
        public static frmGastosList GetInstance()
        {
            if (_instance == null) _instance = new frmGastosList();
            else _instance.BringToFront();
            return _instance;
        }

        public frmGastosList()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        private void HabilitarDeshabilitar()
        {
            if (uiBuscarFolio.Checked)
            {
                gpFolio.Enabled = true;
                gpFechas.Enabled = false;
            }
            else
            {
                gpFechas.Enabled = true;
                gpFolio.Enabled = false;
                uiFolio.Text = "";
            }
        }

        public void Buscar()
        {
            oContext = new ERPProdEntities();
            uiGrid.AutoGenerateColumns = false;
            DateTime fechaIni = uiFechaIni.Value;
            DateTime fechaFin = uiFechaFin.Value;

            int gastoid;

            int.TryParse(uiFolio.Text, out gastoid);
            int sucursalId = this.puntoVentaContext.sucursalId;

            uiGrid.DataSource = oContext.doc_gastos
                .Where(
                    w => (w.GastoId == gastoid && uiBuscarFolio.Checked)
                    ||
                    (
                   DbFunctions.TruncateTime(w.CreadoEl) >= DbFunctions.TruncateTime(fechaIni) && DbFunctions.TruncateTime(w.CreadoEl) <= DbFunctions.TruncateTime(fechaFin)
                    && uiBuscarFechas.Checked)
                    && w.SucursalId == sucursalId
                ).Select(
                    s => new
                    {
                        Folio = s.GastoId.ToString(),
                        Concepto = s.cat_gastos.Descripcion,
                        CentroCosto = s.cat_centro_costos.Descripcion,
                        Observaciones = s.Obervaciones,
                        Monto = s.Monto
                    }
                ).ToList();


        }

        private void uiBuscarFechas_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarDeshabilitar();
        }

        private void uiBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void frmGastosList_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void frmGastosList_Load(object sender, EventArgs e)
        {
            HabilitarDeshabilitar();
            Buscar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmGastos frmo = frmGastos.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                //this.Owner.MdiChildren[0] = frmo;
                //frmo.MdiParent = this.MdiParent;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.accionForm = (int)accionForm.agregar;
                //frmo.WindowState = FormWindowState.Maximized;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.ShowDialog();

            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void editar()
        {
            try
            {
                int rowIndex = uiGrid.CurrentCell.RowIndex;

                if (rowIndex >= 0)
                {
                    int id = int.Parse(uiGrid.Rows[rowIndex].Cells["Folio"].Value.ToString());

                    frmGastos frmo = frmGastos.GetInstance();

                    if (!frmo.Visible)
                    {
                        //frmo = new frmPuntoVenta();
                        //this.Owner.MdiChildren[0] = frmo;
                       // frmo.MdiParent = this.MdiParent;
                        frmo.puntoVentaContext = this.puntoVentaContext;
                        frmo.accionForm = (int)accionForm.actualizar;
                        frmo.idForm = id;
                        frmo.ShowDialog();

                    }
                }
            }
            catch (Exception ex)
            {


            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void eliminar()
        {
            try
            {
                int rowIndex = uiGrid.CurrentCell.RowIndex;

                if (rowIndex >= 0)
                {
                    int id = int.Parse(uiGrid.Rows[rowIndex].Cells["Folio"].Value.ToString());

                    frmGastos frmo = frmGastos.GetInstance();

                    if (!frmo.Visible)
                    {
                        //frmo = new frmPuntoVenta();
                        //this.Owner.MdiChildren[0] = frmo;
                        frmo.MdiParent = this.MdiParent;
                        frmo.puntoVentaContext = this.puntoVentaContext;
                        frmo.accionForm = (int)accionForm.eliminar;
                        frmo.idForm = id;
                        frmo.Show();

                    }
                }
            }
            catch (Exception ex)
            {


            }

        }

        private void uiGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            editar();
        }
    }
}
