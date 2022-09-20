using ConexionBD;
using DevExpress.XtraEditors;
using ERP.Business;
using ERP.Common.Base;
using ERP.Common.Pagos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPv1.Cargos
{
   
    public partial class frmCargoDetalleList : FormBaseXtraForm
    {
        public int cargoId { get; set; }
        private doc_cargos entityCargo { get; set; }
        int err = 0;
        string error = "";
        PagoBusiness oPagoB;
        public frmCargoDetalleList()
        {
            
            InitializeComponent();
            oContext = new ERPProdEntities();
            oPagoB = new PagoBusiness();
        }

        public void LoadForm()
        {
            try
            {
                entityCargo = oContext.doc_cargos
                    .Where(w => w.CargoId == cargoId).FirstOrDefault();

                uiID.EditValue = entityCargo.CargoId;
                uiCliente.Text = entityCargo.cat_clientes.Nombre;
                uiFechaRegistro.EditValue = entityCargo.CredoEl;
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

        public void LoadDetalle()
        {
            try
            {
                oContext = new ERPProdEntities();
                uiGridDetalle.DataSource = oContext.doc_cargos_detalle
                    .Where(w => w.CargoId == cargoId).ToList();
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
        public void LoadPagos()
        {
            try
            {
                oContext = new ERPProdEntities();
                uiGridPagos.DataSource = oContext.doc_pagos
                    .Where(w => w.CargoId == cargoId).ToList();
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

        private void frmCargoDetalleList_Load(object sender, EventArgs e)
        {
            LoadForm();
            LoadDetalle();
            LoadPagos();
            LoadPedidos();
        }

        private void uiRegistrarPago_Click(object sender, EventArgs e)
        {
            frmPagoRegistro frm = new frmPagoRegistro();

            frm.puntoVentaContext = this.puntoVentaContext;
            frm.clienteId = entityCargo.ClienteId;
            frm.cargoId = entityCargo.CargoId;
            var result = frm.ShowDialog();

            if(result == DialogResult.OK)
            {
                LoadDetalle();
                LoadPagos();
            }
        }

        private void repBtnDel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(XtraMessageBox.Show("¿Está seguro(a) de eliminar el pago?","AVISO", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
                if (uiGridPagosView.FocusedRowHandle >= 0)
                {
                    doc_pagos entityPago = (doc_pagos)uiGridPagosView.GetRow(uiGridPagosView.FocusedRowHandle); 

                    if(entityPago != null)
                    {
                        if(oPagoB.Eliminar(entityPago.PagoId, this.puntoVentaContext.usuarioId, this.puntoVentaContext.sucursalId, ref error))
                        {
                            LoadDetalle();
                            LoadPagos();
                            ERP.Utils.MessageBoxUtil.ShowOk();
                        }
                        else
                        {
                            ERP.Utils.MessageBoxUtil.ShowError(error);
                        }
                    }
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

        private void LoadPedidos()
        {
            try
            {
                oContext = new ERPProdEntities();
                uiGridPedidoDetalle.DataSource = oContext.doc_pedidos_orden_detalle
                    .Where(w => w.doc_pedidos_orden.doc_pedidos_cargos.Where(w1 => w1.CargoId == cargoId).Count() > 0).ToList();
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
