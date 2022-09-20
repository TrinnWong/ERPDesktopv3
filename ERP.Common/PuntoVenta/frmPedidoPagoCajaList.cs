using ConexionBD;
using ConexionBD.Models;
using ERP.Common.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.PuntoVenta
{
    public partial class frmPedidoPagoCajaList : FormBaseXtraForm
    {
        doc_pedidos_orden pedidoSeleccionado;
        public bool esDialogForm { get; set; }
        public int pedidoId { get; set; }
        private static frmPedidoPagoCajaList _instance;
        public static frmPedidoPagoCajaList GetInstance()
        {
            if (_instance == null) _instance = new frmPedidoPagoCajaList();
            else _instance.BringToFront();
            return _instance;
        }

        public frmPedidoPagoCajaList()
        {
            InitializeComponent();
        }

        #region metodos
        private void loadGrid()
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;
                int day = DateTime.Now.Day;

                uiGrid.DataSource = oContext.doc_pedidos_orden
                    .Where(w => 
                    (pedidoId == 0 || w.PedidoId == pedidoId) &&
                    (w.SucursalCobroId == puntoVentaContext.sucursalId || w.SucursalId == puntoVentaContext.sucursalId) &&
                    w.TipoPedidoId != (int)ERP.Business.Enumerados.tipoPedido.PedidoTelefono &&
                    w.Activo == true &&
                    (w.Credito??false) == false &&
                    w.VentaId == null && 
                    (
                        (w.doc_pedidos_orden_programacion.FirstOrDefault() != null &&
                        w.doc_pedidos_orden_programacion.FirstOrDefault().FechaProgramada.Year == year &&
                        w.doc_pedidos_orden_programacion.FirstOrDefault().FechaProgramada.Month == month &&
                        w.doc_pedidos_orden_programacion.FirstOrDefault().FechaProgramada.Day == day )
                        ||
                        (
                            w.doc_pedidos_orden_programacion.FirstOrDefault() == null &&
                            w.CreadoEl.Year == year &&
                            w.CreadoEl.Month == month && 
                            w.CreadoEl.Day == day
                        )
                    )
                    ).OrderBy(o=> o.PedidoId).ToList();
                
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

        private void buscarpedido()
        {
            try
            {
                limpiar();
                if(uiGridView.FocusedRowHandle >= 0 || pedidoId  >0)
                {
                    doc_pedidos_orden entityOrden = (doc_pedidos_orden)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                    int pedidoId = entityOrden != null ? entityOrden.PedidoId : this.pedidoId;
                    oContext = new ERPProdEntities();
                    pedidoSeleccionado = oContext.doc_pedidos_orden
                        .Where(w => w.PedidoId == pedidoId).FirstOrDefault();

                    if(pedidoSeleccionado != null)
                    {
                        uiCliente.Text = pedidoSeleccionado.cat_clientes != null ? pedidoSeleccionado.cat_clientes.Nombre : "";
                        uiFolio.Text = pedidoSeleccionado.PedidoId.ToString();
                        uiRegistradoPor.Text = pedidoSeleccionado.cat_usuarios.NombreUsuario;
                        uiHora.DateTime = pedidoSeleccionado.CreadoEl;
                        uiGridDetalle.DataSource = pedidoSeleccionado.doc_pedidos_orden_detalle.Where(w=> (w.Cancelado??false) == false)
                            .Select(s=> new Models.Pedidos.PedidoDetalleModel() {
                                 cantidad = s.Cantidad,
                                  clave = s.cat_productos.Clave,
                                  descripcion = s.cat_productos.Descripcion,
                                   pedidoDetalleId = s.PedidoDetalleId,
                                    pedidoId = s.PedidoId,
                                     precioUnitario = s.PrecioUnitario,
                                      total = s.Total,
                                     basculaPendiente = ConexionBD.PedidoOrdenBusiness.ObtenerCantidadPendienteBascula(s.PedidoDetalleId,puntoVentaContext.usuarioId) > 0 ? true:false,
                                     cantidadPendienteBascula = ConexionBD.PedidoOrdenBusiness.ObtenerCantidadPendienteBascula(s.PedidoDetalleId, puntoVentaContext.usuarioId)

                            })
                            .ToList();

                        uiTotal.EditValue = pedidoSeleccionado.doc_pedidos_orden_detalle.Where(w => (w.Cancelado ?? false) == false).Sum(s => s.Total);

                        uiRecibi.Focus();
                        uiRecibi.Select();
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

        private void limpiar()
        {
            pedidoSeleccionado = null;
            uiFolio.Text = "";
            uiGridDetalle.DataSource = null;
            uiGridViewDetalle.RefreshData();
            uiHora.EditValue = null;
            uiRegistradoPor.Text = "";
            uiTotal.EditValue = 0;
            uiRecibi.EditValue = 0;
            uiCambio.EditValue = 0;
            uiGridView.SelectRow(0);
        }

        private void calcularCambio()
        {
            try
            {
                uiCambio.EditValue = (uiRecibi.Value - uiTotal.Value) < 0 ? 0:(uiRecibi.Value - uiTotal.Value);
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
        #endregion

        private void frmPedidoPagoCajaList_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            _instance = null;
        }

        private void frmPedidoPagoCajaList_Load(object sender, EventArgs e)
        {
            
            uiGridView.SelectRow(0);
            loadGrid();
            buscarpedido();
           
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void repBtnPagar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            buscarpedido();
        }

        private void uiRecibi_EditValueChanged(object sender, EventArgs e)
        {
            calcularCambio();
        }

        private void uiRecibi_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            calcularCambio();
        }

        private void uiRecibi_Leave(object sender, EventArgs e)
        {
            calcularCambio();
        }

        private void uiPagar_Click(object sender, EventArgs e)
        {
            registrarVenta();
        }

        public bool validarVenta()
        {
            try
            {
                if(pedidoSeleccionado == null)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("No hay un pedido seleccionado");
                    return false;
                }
                if (pedidoSeleccionado.doc_pedidos_orden_detalle.Where(w=> (w.Cancelado ?? false) == false).Count() == 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("El pedido no tiene productos");
                    return false;
                }
                if(
                    pedidoSeleccionado.doc_pedidos_orden_detalle.Where(w => (w.Cancelado ?? false) == false)
                    .Sum(s=> s.Total) > (uiRecibi.Value+.01M)
                  )
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("El monto recibido no es suficiente");
                    return false;
                }

                if(((List<Models.Pedidos.PedidoDetalleModel>)uiGridDetalle.DataSource).Where(w=> w.cantidadPendienteBascula > 0).Count() >0)
                {

                    ERP.Utils.MessageBoxUtil.ShowWarning("Hay productos que requieren báscula aún pendientes");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
               
                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                  "ERP",
                                  this.Name,
                                  ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);

                return false;
            }
        }

        public void registrarVenta()
        {

            if (!validarVenta())
            {
                return;
            }
            List<FormaPagoModel> formasPago = new List<FormaPagoModel>();
            List<ProductoModel0> lstProductos = pedidoSeleccionado
                .doc_pedidos_orden_detalle
                .Where(w => (w.Cancelado ?? false) == false)
                .Select(s => new ProductoModel0() {
                     cantidad = s.Cantidad,
                      productoId = s.ProductoId,
                       total = s.Total,
                        tieneBascula = s.cat_productos.ProdVtaBascula ?? false,
                         precioUnitario = s.PrecioUnitario
                          
                }).ToList();
                
            formasPago.Add(new FormaPagoModel() { cantidad = Convert.ToDecimal(uiRecibi.EditValue), id = 1, descripcion = "EFECTIVO" });

            long ventaId = 0;
            int? clienteId = pedidoSeleccionado.ClienteId;            
            string error = "";

            ConexionBD.PuntoVenta oData = new ConexionBD.PuntoVenta();

            error = ERP.Business.VentasBusiness.pagar(ref ventaId, clienteId, "", 0, 0, 0, lstProductos.Sum(s => s.impuestos),
                lstProductos.Sum(s => s.total) - lstProductos.Sum(s => s.impuestos), uiTotal.Value,
                Convert.ToDecimal(uiRecibi.EditValue), Convert.ToDecimal(uiCambio.EditValue), false,
                puntoVentaContext.sucursalId,
                puntoVentaContext.usuarioId,
                puntoVentaContext.cajaId, lstProductos, formasPago, new List<ValeFPModel>(), pedidoSeleccionado.PedidoId);

            if (error.Length > 0)
            {
                ERP.Utils.MessageBoxUtil.ShowError(error);
                if (esDialogForm)
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
                return;
            }
            else
            {
                pedidoId = 0;
                limpiar();
                loadGrid();

                ERP.Utils.MessageBoxUtil.ShowOk();

                if (esDialogForm)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

                return;

            }


        }

        private void uiRecibi_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                registrarVenta();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pedidoSeleccionado == null)
            {
                loadGrid();
            }
        }

        private void uiGridView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle <= -1)
                    return;
                var row = (doc_pedidos_orden)uiGridView.GetRow(e.RowHandle);
                if (row.ClienteId > 0)
                {
                    e.Appearance.BackColor = Color.Yellow;
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

        private void uiGridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Para" && e.ListSourceRowIndex >= 0)
                {
                    doc_pedidos_orden row = (doc_pedidos_orden)uiGridView.GetRow(e.ListSourceRowIndex);
                    if(row!= null)
                    {
                        e.DisplayText = row.cat_clientes != null ? row.cat_clientes.Nombre : "";
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
    }
}
