using ConexionBD;
using DevExpress.XtraEditors;
using ERP.Common.Base;
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

namespace ERPv1.Gastos
{
    public partial class frmGastosNegocioList : FormBaseXtraForm
    {
        int err = 0;
        doc_gastos entityGasto;
        private static frmGastosNegocioList _instance;
        public static frmGastosNegocioList GetInstance()
        {
            if (_instance == null) _instance = new frmGastosNegocioList();
            else _instance.BringToFront();
            return _instance;
        }
        public frmGastosNegocioList()
        {
            InitializeComponent();
        }

        private void LoadCentroCostos()
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();
                uiCentroCosto.Properties.DataSource = oContext.cat_centro_costos.ToList();
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

        private void LoadConceptos()
        {
            try
            {
                int cc = Convert.ToInt32(uiCentroCosto.EditValue);

                oContext = new ConexionBD.ERPProdEntities();
                uiConcepto.Properties.DataSource = oContext.cat_gastos
                    .Where(W => W.ClaveCentroCosto == cc).ToList();
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


        private void LoadSucursales()
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();
                uiSucursal.Properties.DataSource = ERP.Business.SucursalBusiness
                    .ObtenSucursalesPorUsuario(this.puntoVentaContext.empresaId,
                    this.puntoVentaContext.usuarioId);
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

        private void frmGastosNegocioList_Load(object sender, EventArgs e)
        {
            uiFecha.DateTime = DateTime.Now;
            oContext = new ConexionBD.ERPProdEntities();
            entityGasto = new doc_gastos();
            uiDel.DateTime = DateTime.Now;
            uiAl.DateTime = DateTime.Now;
            uiLayoutCaptura.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            LoadSucursales();
            LoadCentroCostos();
            LoadConceptos();
            LoadGrid();
        }

        private void uiCentroCosto_EditValueChanged(object sender, EventArgs e)
        {
            LoadConceptos();
        }

        private void Limpiar()
        {
            uiFecha.DateTime = DateTime.Now;
            entityGasto = new doc_gastos();
            uiSucursal.EditValue = puntoVentaContext.sucursalId;
            uiCentroCosto.EditValue = null;
            uiConcepto.EditValue = null;
            uiMonto.EditValue = 0;
            uiObservaciones.EditValue = "";
        }

        private void uiLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGastosNegocioList_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void Guardar()
        {
            bool esNuevo = false;
            try
            {
                
                if(uiSucursal.EditValue == null || uiCentroCosto.EditValue == null
                    || uiConcepto.EditValue == null || uiMonto.Value == 0 || uiObservaciones.Text == "")
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Es necesario capturar todos los campos");
                    return;
                }

                if(entityGasto != null)
                {
                    if(entityGasto.GastoId == 0)
                    {
                        esNuevo = true;
                        doc_gastos entityGastoNuevo = new doc_gastos();

                        entityGastoNuevo.GastoId = (oContext.doc_gastos.Max(m => (int?)m.GastoId) ?? 0) + 1;
                        entityGastoNuevo.Activo = true;
                        entityGastoNuevo.CajaId = null;
                        entityGastoNuevo.CentroCostoId = Convert.ToInt32(uiCentroCosto.EditValue);
                        entityGastoNuevo.CreadoEl = uiFecha.DateTime;
                        entityGastoNuevo.CreadoPor = puntoVentaContext.usuarioId;
                        entityGastoNuevo.GastoConceptoId = Convert.ToInt32(uiConcepto.EditValue);
                        entityGastoNuevo.Monto = Convert.ToDecimal(uiMonto.EditValue);
                        entityGastoNuevo.Obervaciones = uiObservaciones.Text;
                        entityGastoNuevo.SucursalId = puntoVentaContext.sucursalId;

                        oContext.doc_gastos.Add(entityGastoNuevo);
                        oContext.SaveChanges();


                        imprimir(entityGastoNuevo.GastoId);
                    }
                    else
                    {
                        esNuevo = false;
                        doc_gastos entityUpd = oContext.doc_gastos
                            .Where(w => w.GastoId == entityGasto.GastoId).FirstOrDefault();

                        entityUpd.CreadoEl = uiFecha.DateTime;
                        entityUpd.Activo = true;
                        entityUpd.CajaId = null;
                        entityUpd.CentroCostoId = Convert.ToInt32(uiCentroCosto.EditValue);                       
                        entityUpd.CreadoPor = puntoVentaContext.usuarioId;
                        entityUpd.GastoConceptoId = Convert.ToInt32(uiConcepto.EditValue);
                        entityUpd.Monto = Convert.ToDecimal(uiMonto.EditValue);
                        entityUpd.Obervaciones = uiObservaciones.Text;
                        entityUpd.SucursalId = puntoVentaContext.sucursalId;

                        oContext.SaveChanges();

                        imprimir(entityGasto.GastoId);
                    }

                    Limpiar();
                    LoadGrid();
                    
                }
            }
            catch (Exception ex)
            {
                
                entityGasto = new doc_gastos();
                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                  "ERP",
                                  this.Name,
                                  ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void LoadGrid()
        {
            try
            {
                int anioMesDiaIni = (uiDel.DateTime.Year * 10000) + (uiDel.DateTime.Year * 100) + uiDel.DateTime.Day;
                int anioMesDiaFin = (uiAl.DateTime.Year * 10000) + (uiAl.DateTime.Year * 100) + uiAl.DateTime.Day;
                uiGrid.DataSource = oContext.doc_gastos
                    .Where(w => w.SucursalId == puntoVentaContext.sucursalId 
                    && ((w.CreadoEl.Year * 10000) + (w.CreadoEl.Year * 100) + w.CreadoEl.Day) >= anioMesDiaIni &&
                    ((w.CreadoEl.Year * 10000) + (w.CreadoEl.Year * 100) + w.CreadoEl.Day) <= anioMesDiaFin)
                    .ToList();

                uiTotal.EditValue = ((List<doc_gastos>)uiGrid.DataSource).Sum(s => s.Monto);
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

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void repBtnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SeleccionarGasto();
        }

        private void SeleccionarGasto()
        {
            try
            {
                if(uiGridView.FocusedRowHandle >= 0)
                {
                    uiLayoutCaptura.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    entityGasto = (doc_gastos)uiGridView.GetRow(uiGridView.FocusedRowHandle);
                    uiFecha.EditValue = entityGasto.CreadoEl;
                    uiSucursal.EditValue = entityGasto.SucursalId;
                    uiCentroCosto.EditValue = entityGasto.CentroCostoId;
                    uiConcepto.EditValue = entityGasto.GastoConceptoId;
                    uiMonto.EditValue = entityGasto.Monto;
                    uiObservaciones.EditValue = entityGasto.Obervaciones;
                    
                }
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


        private void SeleccionarEImprimir()
        {
            try
            {
                if (uiGridView.FocusedRowHandle >= 0)
                {
                   
                    entityGasto = (doc_gastos)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                    imprimir(entityGasto.GastoId);

                }
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


        private void imprimir(int id)
        {
            rptGastoTicket oTicket = new rptGastoTicket();

            ReportViewer oViewer = new ReportViewer();

            oTicket.DataSource = oContext.p_rpt_gasto_ticket(id).ToList();

            oViewer.ShowTicket(oTicket);
            //oViewer.Show();
        }

        private void uiNuevo_Click(object sender, EventArgs e)
        {
            uiLayoutCaptura.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void uiOcultar_Click(object sender, EventArgs e)
        {
            uiLayoutCaptura.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void uiBuscar_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void uiGuardar_Click_1(object sender, EventArgs e)
        {
            Guardar();
        }

        private void uiLimpiar_Click_1(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void uiCentroCosto_EditValueChanged_1(object sender, EventArgs e)
        {
            LoadConceptos();
        }

        private void repBtnPrint_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SeleccionarEImprimir();
        }

        private void repBtnDelete2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("¿Está seguro de eliminar el  gasto?", "Avso", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                var row = ((doc_gastos)uiGridView.GetRow(uiGridView.FocusedRowHandle));

                if(row!= null)
                {
                    doc_gastos gastoEliminar = oContext.doc_gastos
                        .Where(w => w.GastoId == row.GastoId).FirstOrDefault();

                    oContext.doc_gastos.Remove(gastoEliminar);
                    oContext.SaveChanges();

                    this.LoadGrid();
                }
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
    }
}
