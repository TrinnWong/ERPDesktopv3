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

namespace ERPv1.Procesos
{
    public partial class frmPromocionesList : Form
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        private static frmPromocionesList _instance;

        public static frmPromocionesList GetInstance()
        {
            if (_instance == null) _instance = new frmPromocionesList();
            else _instance.BringToFront();
            return _instance;
        }

        public frmPromocionesList()
        {
            InitializeComponent();
            uiGrid.AutoGenerateColumns = false;
            oContext = new ERPProdEntities();
        }

        public void LlenarGrid()
        {
            oContext = new ERPProdEntities();
            DateTime fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
            

            uiGrid.DataSource = oContext.doc_promociones               
                .Where(
                    w=> 
                    (
                    (
                        (DbFunctions.TruncateTime(w.FechaInicioVigencia) <= DbFunctions.TruncateTime(fechaActual) &&
                        DbFunctions.TruncateTime(w.FechaFinVigencia) >= DbFunctions.TruncateTime(fechaActual))
                        ||
                        w.Permanente == true

                     )
                     &&
                     w.Activo == true &&
                    uiSoloVigentes.Checked)
                    ||
                    !uiSoloVigentes.Checked
                )
                .Select(
                    s=> new {
                        s.PromocionId,
                        s.PorcentajeDescuento,
                        s.FechaInicioVigencia,
                        s.FechaFinVigencia,
                        s.FechaRegistro,
                        s.Activo,
                        Sucursal = s.cat_sucursales.NombreSucursal
                    }
                )
                .ToList();

        }

        private void editar()
        {
            try
            {
                int rowIndex = uiGrid.CurrentCell.RowIndex;

                if (rowIndex >= 0)
                {
                    int id = int.Parse(uiGrid.Rows[rowIndex].Cells["ID"].Value.ToString());

                    frmPromocionesUpd frmo = frmPromocionesUpd.GetInstance();

                    if (!frmo.Visible)
                    {
                        //frmo = new frmPuntoVenta();
                        //this.Owner.MdiChildren[0] = frmo;
                        frmo.MdiParent = this.MdiParent;
                        frmo.puntoVentaContext = this.puntoVentaContext;
                        frmo.accionForm = (int)accionForm.actualizar;
                        frmo.idForm = id;
                        frmo.Show();

                    }
                }
            }
            catch (Exception ex)
            {

               
            }
           
        }

        private void eliminar()
        {
            try
            {
                int rowIndex = uiGrid.CurrentCell.RowIndex;

                if (rowIndex >= 0)
                {
                    int id = int.Parse(uiGrid.Rows[rowIndex].Cells["ID"].Value.ToString());

                    frmPromocionesUpd frmo = frmPromocionesUpd.GetInstance();

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

        private void frmPromocionesList_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void uiSoloVigentes_CheckedChanged(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmPromocionesUpd frmo = frmPromocionesUpd.GetInstance();

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void uiGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editar();
        }

        private void frmPromocionesList_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiFinVigencia_ValueChanged(object sender, EventArgs e)
        {
            LlenarGrid();
        }
    }
}
