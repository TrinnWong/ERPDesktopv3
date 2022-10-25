using ConexionBD;
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
                uiSucursal.Properties.DataSource = ERP.Business.SucursalBusiness.ObtenSucursalesPorUsuario(this.puntoVentaContext.empresaId,
                    this.puntoVentaContext.sucursalId);
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
            oContext = new ConexionBD.ERPProdEntities();
            entityGasto = new doc_gastos();
            
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
                        entityGasto = new doc_gastos();

                        entityGasto.GastoId = (oContext.doc_gastos.Max(m => (int?)m.GastoId) ?? 0) + 1;
                        entityGasto.Activo = true;
                        entityGasto.CajaId = 0;
                        entityGasto.CentroCostoId = Convert.ToInt32(uiCentroCosto.EditValue);
                        entityGasto.CreadoEl = DateTime.Now;
                        entityGasto.CreadoPor = puntoVentaContext.usuarioId;
                        entityGasto.GastoConceptoId = Convert.ToInt32(uiConcepto.EditValue);
                        entityGasto.Monto = Convert.ToDecimal(uiMonto.EditValue);
                        entityGasto.Obervaciones = uiObservaciones.Text;
                        entityGasto.SucursalId = puntoVentaContext.sucursalId;

                        oContext.doc_gastos.Add(entityGasto);
                        oContext.SaveChanges();


                        imprimir(entityGasto.GastoId);
                    }
                    else
                    {
                        doc_gastos entityUpd = oContext.doc_gastos
                            .Where(w => w.GastoId == entityGasto.GastoId).FirstOrDefault();

                        entityUpd.Activo = true;
                        entityUpd.CajaId = 0;
                        entityUpd.CentroCostoId = Convert.ToInt32(uiCentroCosto.EditValue);
                        entityUpd.CreadoEl = DateTime.Now;
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
                uiGrid.DataSource = oContext.doc_gastos
                    .Where(w => w.SucursalId == puntoVentaContext.sucursalId)
                    .ToList();
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

        }

        private void SeleccionarGasto()
        {
            try
            {
                if(uiGridView.FocusedRowHandle >= 0)
                {
                    entityGasto = (doc_gastos)uiGridView.GetRow(uiGridView.FocusedRowHandle);

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


        private void imprimir(int id)
        {
            rptGastoTicket oTicket = new rptGastoTicket();

            ReportViewer oViewer = new ReportViewer(puntoVentaContext.cajaId);

            oTicket.DataSource = oContext.p_rpt_gasto_ticket(id).ToList();

            oViewer.ShowTicket(oTicket);
            //oViewer.Show();
        }
    }
}
