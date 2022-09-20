using ConexionBD;
using DevExpress.XtraEditors;
using ERP.Common.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Pedido
{
    public partial class frmPedidosClientesList : FormBaseXtraForm
    {
        PedidoOrdenBusiness pedidoOrdenB;
        private static frmPedidosClientesList _instance;
        public static frmPedidosClientesList GetInstance()
        {
            if (_instance == null) _instance = new frmPedidosClientesList();
            else _instance.BringToFront();
            return _instance;
        }
        public frmPedidosClientesList()
        {
            oContext = new ERPProdEntities();
            pedidoOrdenB = new PedidoOrdenBusiness();
            InitializeComponent();
        }

        private void ClearObjects()
        {
            pedidoOrdenB = null;
        }

        public void LoadGrid()
        {
            try
            {
                oContext = new ERPProdEntities();
                int? sucursalId = Convert.ToInt32( uiSucursal.EditValue);
                uiGrid.DataSource = oContext.doc_pedidos_orden                    
                    .Where(
                    w => 
                        ((w.Activo == true || w.VentaId > 0) 
                        && w.SucursalId == (sucursalId ?? 0) && w.ClienteId != null)
                        || w.Cancelada == true
                    ).ToList();
            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                 "ERP",
                                                 this.Name,
                                                 ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        public void LoadSucursales()
        {
            try
            {
                oContext = new ERPProdEntities();
                uiSucursal.Properties.DataSource = oContext
                    .cat_sucursales.ToList();
            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                 "ERP",
                                                 this.Name,
                                                 ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void frmPedidosClientesList_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSucursales();
                uiSucursal.EditValue = puntoVentaContext.sucursalId;
                LoadGrid();

            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                 "ERP",
                                                 this.Name,
                                                 ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void frmPedidosClientesList_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
            ClearObjects();
        }

        private void uiNuevo_Click(object sender, EventArgs e)
        {
            frmPedidosClientes frmo = frmPedidosClientes.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this.MdiParent;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();

            }
        }

        private void repBtnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(uiGridView.FocusedRowHandle >= 0)
            {
                doc_pedidos_orden entityDetalle = (doc_pedidos_orden)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                if(entityDetalle.Cancelada == true)
                {
                    ERP.Utils.MessageBoxUtil.ShowError("El pedido está cancelado");
                    return;
                }

                frmPedidosClientes frmo = frmPedidosClientes.GetInstance();

                if (!frmo.Visible)
                {
                    //frmo = new frmPuntoVenta();
                    frmo.MdiParent = this.MdiParent;
                    frmo.puntoVentaContext = this.puntoVentaContext;
                    frmo.WindowState = FormWindowState.Maximized;
                    frmo.IDForm = entityDetalle.PedidoId;
                    frmo.Show();

                }
            }
            
        }

        private void uiBuscar_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void uiSucursal_EditValueChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void uiGridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            try
            {
                doc_pedidos_orden row = null;
                if (e.Column.FieldName == "estado")
                {
                    row = (doc_pedidos_orden)uiGridView.GetRow(e.ListSourceRowIndex);
                    e.DisplayText = ConexionBD.PedidoOrdenBusiness.ObtenerEstado(row);
                }
                if(e.Column.FieldName == "saldo")
                {
                    row = (doc_pedidos_orden)uiGridView.GetRow(e.ListSourceRowIndex);
                    if (row.TipoPedidoId == (int)ERP.Business.Enumerados.tipoPedido.PedidoClienteMayoreo)
                    {
                        e.DisplayText = string.Format("{0:#.00}", row.doc_cargos != null ? row.doc_cargos.Saldo : 0); 
                    }
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                "ERP",
                                                this.Name,
                                                ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void repBtnCancelar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(uiGridView.FocusedRowHandle >= 0)
                {
                    if (XtraMessageBox.Show("¿Está seguro(a) de cancelar este pedido?", "Atención", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int pedidoOrdenId =((doc_pedidos_orden)uiGridView.GetRow(uiGridView.FocusedRowHandle)).PedidoId;

                        string error = pedidoOrdenB.CancelarPedido(pedidoOrdenId, puntoVentaContext.usuarioId);   
                        
                        if(error.Length > 0)
                        {
                            ERP.Utils.MessageBoxUtil.ShowError(error);
                        }
                        else
                        {
                            ERP.Utils.MessageBoxUtil.ShowOk();
                            LoadGrid();
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
