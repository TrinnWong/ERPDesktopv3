using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
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

namespace ERP.Common.Pedido
{
    public partial class frmPedidoDevolucionReparto : FormBaseXtraForm
    {
        int err = 0;
        public doc_pedidos_orden pedido;
        List<ProductoModel0> lstProductos { get; set; }
        public frmPedidoDevolucionReparto()
        {
            InitializeComponent();
        }

        private void LoadGrid()
        {
            try
            {
                uiGrid.DataSource = lstProductos;
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

        private void frmPedidoDevolucionReparto_Load(object sender, EventArgs e)
        { 
            uiRepCantidadFinalReparto.AllowFocused = true;
            BuscarPedido();
        }

        private void calcularTotales()
        {
            lstProductos = (List<ProductoModel0>)uiGrid.DataSource;
            uiTotal.EditValue = lstProductos.Sum(s => s.total);
        }
        private void BuscarPedido()
        {
            try
            {
                if (pedido != null)
                {
                    //uiCliente.EditValue = pedido.ClienteId;

                    this.lstProductos = pedido.doc_pedidos_orden_detalle
                        .ToList().Select(s => new ProductoModel0()
                        {
                            cantidad = s.Cantidad,
                            clave = s.cat_productos.Clave,
                            descripcion = s.cat_productos.Descripcion,
                            precioNeto = s.PrecioUnitario,
                            impuestos = 0,
                            productoId = s.ProductoId,
                            unidadId = s.cat_productos.ClaveUnidadMedida ?? 0,
                            unidad = s.cat_productos.cat_unidadesmed.Descripcion,
                            precioUnitario = s.PrecioUnitario,
                            total = s.Total,
                            pedidoDetalleId = s.PedidoDetalleId,
                            cantidadCobroReparto =s.Cantidad

                        }).ToList();

                    uiGrid.DataSource = lstProductos;
                    calcularTotales();
                   
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

        private void uiGuardar1_Click(object sender, EventArgs e)
        {
            registrarVenta(false);
        }

        private void uiContinuar_Click(object sender, EventArgs e)
        {
            if(XtraMessageBox.Show("Está seguro(a) de continuar?, se registrará la venta sin devouciones de reparto","Aviso", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                registrarVenta(true);
            }
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void uiRepCantidadFinalReparto_Enter(object sender, EventArgs e)
        {

        }

        private void uiRepCantidadFinalReparto_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void uiGridView_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if(e.CellValue != null)
            {
                if (e.Column == colCantidadFinalReparto)
                {
                    decimal cantidadFinal = Convert.ToDecimal(e.CellValue);
                    decimal cantidad = Convert.ToDecimal(uiGridView.GetRowCellValue(e.RowHandle, "cantidad"));
                   
                    decimal precio =Convert.ToDecimal( uiGridView.GetRowCellValue(e.RowHandle, "precioUnitario"));

                    if(cantidadFinal > cantidad)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("La cantidad Final no puede ser MAYOR a la original");
                        
                        return;
                    }

                    if(cantidadFinal >= 0)
                    {                       
                        uiGridView.SetRowCellValue(e.RowHandle, colTotal, precio * (cantidad- cantidadFinal));
                        uiGridView.SetRowCellValue(e.RowHandle,colCantidadCobroReparto, (cantidad - cantidadFinal));
                        calcularTotales();
                    }

                }
            }
            
        }

        public void registrarVenta(bool saltarSinDevolucion)
        {
            try
            {
                oContext = new ERPProdEntities();
                this.lstProductos = (List<ProductoModel0>)uiGrid.DataSource;

                if (!saltarSinDevolucion)
                {
                    lstProductos.ForEach(f => f.cantidadOriginal = f.cantidad);
                    lstProductos.ForEach(f => f.cantidadDevolucion = f.cantidadOriginal - f.cantidadCobroReparto);
                    lstProductos.ForEach(f => f.cantidad = f.cantidadCobroReparto);
                }

                #region Actualizar Pedido
                foreach (var itemPedido in lstProductos)
                {
                    doc_pedidos_orden_detalle oPedidoDetalle = oContext.doc_pedidos_orden_detalle
                        .Where(w => w.PedidoDetalleId == itemPedido.pedidoDetalleId).FirstOrDefault();

                    oPedidoDetalle.CantidadDevolucion = itemPedido.cantidadDevolucion;
                    oPedidoDetalle.CantidadOriginal = itemPedido.cantidadOriginal;
                    oPedidoDetalle.Cantidad = itemPedido.cantidad;
                    oPedidoDetalle.Total = itemPedido.cantidad * itemPedido.precioUnitario;
                    oContext.SaveChanges();

                    doc_pedidos_orden oPedido = oContext.doc_pedidos_orden
                        .Where(w => w.PedidoId == this.pedido.PedidoId).FirstOrDefault();

                    oPedido.Total = lstProductos.Sum(s=> s.cantidad * s.precioUnitario);
                    oContext.SaveChanges();

                }

                ERP.Reports.rptPedidoDevolucion oTicketPedido = new ERP.Reports.rptPedidoDevolucion();


                ERP.Common.Reports.ReportViewer oViewerPedido = new ERP.Common.Reports.ReportViewer(this.puntoVentaContext.cajaId);
                oContext = new ERPProdEntities();
                oTicketPedido.DataSource = oContext.p_rpt_pedido_orden_sel(pedido.PedidoId).ToList();

                oViewerPedido.ShowTicket(oTicketPedido);
                #endregion

                List<FormaPagoModel> formasPago = new List<FormaPagoModel>();

                formasPago.Add(new FormaPagoModel() { cantidad = uiTotal.Value, id = 1, descripcion = "EFECTIVO" });

                long ventaId = 0;
                int? clienteId = pedido.ClienteId;
                decimal descuentoPartidas = lstProductos.Sum(s => s.montoDescuento);
                string error = "";

                ConexionBD.PuntoVenta oData = new ConexionBD.PuntoVenta();

                error = ERP.Business.VentasBusiness.pagar(ref ventaId, clienteId, "", 0,
                    lstProductos.Sum(s => s.montoDescuento),
                    lstProductos.Sum(s => s.montoDescuento), lstProductos.Sum(s => s.impuestos),
                    lstProductos.Sum(s => s.total) - lstProductos.Sum(s => s.impuestos),
                    uiTotal.Value,
                    uiTotal.Value, 0,
                    lstProductos.Sum(s => s.montoDescuento) > 0 ? true : false,
                    puntoVentaContext.sucursalId,
                    puntoVentaContext.usuarioId,
                    puntoVentaContext.cajaId, lstProductos, formasPago, new List<ValeFPModel>(), pedido.PedidoId,
                    false, false);

                if (error.Length > 0)
                {
                    XtraMessageBox.Show(error, "ERROR");
                    return;
                }
                else
                {
                    #region registrar mov Bascula

                    #endregion
                    oContext = new ERPProdEntities();
                    cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

                    if (uiTotal.Value >= (entity.MontoImpresionTicket ?? 0))
                    {
                        if (entity.ImprimirTicketMediaCarta == true)
                        {
                            ERP.Reports.rptVentaTicket_CartaM oTicket1 = new ERP.Reports.rptVentaTicket_CartaM();


                            ERP.Common.Reports.ReportViewer oViewer = new ERP.Common.Reports.ReportViewer(this.puntoVentaContext.cajaId);

                            oTicket1.DataSource = oContext.p_rpt_VentaTicket((int?)ventaId).ToList();

                            oViewer.ShowTicket(oTicket1);
                        }
                        else
                        {
                            ERP.Reports.rptVentaTicket oTicket2 = new ERP.Reports.rptVentaTicket();


                            ERP.Common.Reports.ReportViewer oViewer = new ERP.Common.Reports.ReportViewer(this.puntoVentaContext.cajaId);

                            oTicket2.DataSource = oContext.p_rpt_VentaTicket((int?)ventaId).ToList();

                            oViewer.ShowTicket(oTicket2);
                        }


                        //oViewer.Show();
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();

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
