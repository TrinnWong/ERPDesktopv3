using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using ERP.Common.Base;
using ERP.Models.Pedidos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace ERP.Common.Pedido
{
    public partial class PedidoDevolucionVentasDirectas : FormBaseXtraForm
    {
        int err = 0;
        string error = "";
        DateTime fechaActual;

        List<Models.Pedidos.PedidoDevolucionVentaDirectaMasaTortilla> lstDevoluciones;
        private void PedidoDevolucionVentasDirectas_Load(object sender, EventArgs e)
        {
            oContext = new ConexionBD.ERPProdEntities(true);
            this.fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

            LoadGrid();
        }

        public PedidoDevolucionVentasDirectas()
        {
            InitializeComponent();
        }

        public void LoadGrid()
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities(true);

                this.fechaActual = this.fechaActual.AddDays(-1);

                this.lstDevoluciones = oContext.doc_ventas_detalle.Where(w =>
                    w.doc_ventas.ClienteId != null &&
                    w.doc_ventas.Activo == true &&
                    w.doc_ventas.SucursalId == puntoVentaContext.sucursalId &&
                    DbFunctions.TruncateTime(w.doc_ventas.Fecha) >= DbFunctions.TruncateTime(fechaActual) &&
                    (w.ProductoId == (int)ERP.Business.Enumerados.productosSistema.tortilla || w.ProductoId == (int)ERP.Business.Enumerados.productosSistema.masa) &&
                    w.doc_ventas.doc_pedidos_orden.Count() == 0)
               .Select(s => new PedidoDevolucionVentaDirectaMasaTortilla()
               {
                   cliente = s.doc_ventas.cat_clientes.Nombre,
                   clienteId = s.doc_ventas.ClienteId ?? 0,
                   devolucionMasa = 0,
                   devolucionTortilla = 0,
                   fecha = s.doc_ventas.Fecha,
                   folio = s.doc_ventas.Folio,
                   precioMasa = s.ProductoId == (int)ERP.Business.Enumerados.productosSistema.masa ? s.PrecioUnitario : 0,
                   precioTortilla = s.ProductoId == (int)ERP.Business.Enumerados.productosSistema.tortilla ? s.PrecioUnitario : 0,
                   ventaId = s.VentaId,
                   pedidoId = 0,
                   cantidadVentaMasa = s.ProductoId == (int)ERP.Business.Enumerados.productosSistema.masa ? s.Cantidad ??0 : 0,
                   cantidadVentaTortilla = s.ProductoId == (int)ERP.Business.Enumerados.productosSistema.tortilla ? s.Cantidad ?? 0 : 0

               }).ToList();

                this.lstDevoluciones = this.lstDevoluciones
                    .GroupBy(s => new
                    {
                        s.cliente,
                        s.clienteId,
                        s.fecha,
                        s.folio,
                        s.ventaId
                    }
                    )
                      .Select(group => new PedidoDevolucionVentaDirectaMasaTortilla()
                      {
                          cliente = group.Key.cliente,
                          clienteId = group.Key.clienteId,
                          devolucionMasa = 0,
                          devolucionTortilla = 0,
                          fecha = group.Key.fecha,
                          folio = group.Key.folio,
                          precioMasa = group.Max(s => s.precioMasa),
                          precioTortilla = group.Max(s => s.precioTortilla),
                          ventaId = group.Key.ventaId,
                          pedidoId = 0,
                          cantidadVentaMasa = group.Sum(s=> s.cantidadVentaMasa),
                          cantidadVentaTortilla = group.Sum(s => s.cantidadVentaTortilla)
                      }).ToList();
                ;


                uiGrid.DataSource = this.lstDevoluciones;
                uiGridView.ExpandAllGroups();
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

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void guardar()
        {
            try
            {
                foreach (var item in ((List<ERP.Models.Pedidos.PedidoDevolucionVentaDirectaMasaTortilla>)uiGrid.DataSource).ToList())
                {
                    if(item.devolucionMasa <0 || item.devolucionTortilla < 0)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("No se permiten cantidades menoras a 0");
                        uiGuardar.Enabled = true;
                        uiCancelar.Enabled = true;
                        return;
                    }

                    if (item.devolucionMasa > item.cantidadVentaMasa || item.devolucionTortilla > item.cantidadVentaTortilla)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("No se puede devolver una cantidad mayor a la venta");
                        uiGuardar.Enabled = true;
                        uiCancelar.Enabled = true;
                        return;
                    }
                } 


                if(XtraMessageBox.Show("Aviso","¿Estás seguro(a) de continuar?, ya no será  posible modifica la información para las ventas modificadas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    uiGuardar.Enabled = true;
                    uiCancelar.Enabled = true;
                    return;
                }
               

                //por cada renglon generar un ticket
                foreach (PedidoDevolucionVentaDirectaMasaTortilla itemDevolucion in 
                    ((List<ERP.Models.Pedidos.PedidoDevolucionVentaDirectaMasaTortilla>)uiGrid.DataSource).Where(w=> w.devolucionMasa > 0 || w.devolucionTortilla >0))
                {
                    List<ProductoModel0> lstPedido = new List<ProductoModel0>();
                    ProductoModel0 oPedidoDetalle = new ProductoModel0();


                    //Tortilla
                    oPedidoDetalle.cantidad = -itemDevolucion.devolucionTortilla;
                    oPedidoDetalle.cantidadCobroReparto = -itemDevolucion.devolucionTortilla;
                    oPedidoDetalle.cantidadDevolucion = itemDevolucion.devolucionTortilla;
                    oPedidoDetalle.cantidadFinalReparto = -itemDevolucion.devolucionTortilla;
                    oPedidoDetalle.cantidadOriginal = 0;
                    oPedidoDetalle.clave = "1";
                    oPedidoDetalle.descripcion = "TORTILLA";
                    oPedidoDetalle.impuestos = 0;
                    oPedidoDetalle.montoDescuento = 0;
                    oPedidoDetalle.precioUnitario = itemDevolucion.precioTortilla;
                    oPedidoDetalle.productoId = 1;
                    oPedidoDetalle.tieneBascula = false;
                    oPedidoDetalle.total = oPedidoDetalle.cantidad * oPedidoDetalle.precioUnitario;
                    oPedidoDetalle.unidadId = oContext.cat_productos.Where(w => w.ProductoId == 1).FirstOrDefault().cat_unidadesmed.Clave;
                    lstPedido.Add(oPedidoDetalle);

                    oPedidoDetalle = new ProductoModel0();
                    //Masa
                    oPedidoDetalle.cantidad = -itemDevolucion.devolucionMasa;
                    oPedidoDetalle.cantidadCobroReparto = -itemDevolucion.devolucionMasa;
                    oPedidoDetalle.cantidadDevolucion = itemDevolucion.devolucionMasa;
                    oPedidoDetalle.cantidadFinalReparto = -itemDevolucion.devolucionMasa;
                    oPedidoDetalle.cantidadOriginal = 0;
                    oPedidoDetalle.clave = "2";
                    oPedidoDetalle.descripcion = "MASA";
                    oPedidoDetalle.impuestos = 0;
                    oPedidoDetalle.montoDescuento = 0;
                    oPedidoDetalle.precioUnitario = itemDevolucion.devolucionMasa;
                    oPedidoDetalle.productoId = 2;
                    oPedidoDetalle.tieneBascula = false;
                    oPedidoDetalle.total = oPedidoDetalle.cantidad * oPedidoDetalle.precioUnitario;
                    oPedidoDetalle.unidadId = oContext.cat_productos.Where(w => w.ProductoId == 2).FirstOrDefault().cat_unidadesmed.Clave;
                    lstPedido.Add(oPedidoDetalle);

                  
                        //Generar pedido de venta
                        doc_pedidos_orden pedido = new doc_pedidos_orden();
                        pedido.ClienteId = itemDevolucion.clienteId;
                        pedido.SucursalId = puntoVentaContext.sucursalId;
                        pedido.VentaId = itemDevolucion.ventaId;

                        PedidoOrdenBusiness oPedido = new PedidoOrdenBusiness();
                        //Gnerar pedido sin detalle
                        oPedido.GuardarPedido(pedido, ERP.Business.Enumerados.tipoPedido.PedidoTelefono,new List<ProductoModel0>(), puntoVentaContext.usuarioId, puntoVentaContext.sucursalId, ref error,true,true);

                        //Generar pedido de devoluciones
                        pedido = new doc_pedidos_orden();
                        pedido.ClienteId = itemDevolucion.clienteId;
                        pedido.SucursalId = puntoVentaContext.sucursalId;                       

                        oPedido = new PedidoOrdenBusiness();                        

                        pedido = oPedido.GuardarPedido(pedido, ERP.Business.Enumerados.tipoPedido.PedidoTelefono,
                        lstPedido, puntoVentaContext.usuarioId, puntoVentaContext.sucursalId, ref error,false,true);

                        

                        if (error.Length == 0)
                        {
                            List<FormaPagoModel> formasPago = new List<FormaPagoModel>();

                            formasPago.Add(new FormaPagoModel() { cantidad = lstPedido.Sum(s => s.total), id = 1, descripcion = "EFECTIVO" });

                            long ventaId = 0;
                            int? clienteId = pedido.ClienteId;
                            decimal descuentoPartidas = lstPedido.Sum(s => s.montoDescuento);
                            error = "";

                            ConexionBD.PuntoVenta oData = new ConexionBD.PuntoVenta();

                            error = ERP.Business.VentasBusiness.pagar(ref ventaId, clienteId, "", 0,
                                lstPedido.Sum(s => s.montoDescuento),
                                lstPedido.Sum(s => s.montoDescuento), lstPedido.Sum(s => s.impuestos),
                                lstPedido.Sum(s => s.total) - lstPedido.Sum(s => s.impuestos),
                                lstPedido.Sum(s => s.total),
                                lstPedido.Sum(s => s.total), 0,
                                lstPedido.Sum(s => s.montoDescuento) > 0 ? true : false,
                                puntoVentaContext.sucursalId,
                                puntoVentaContext.usuarioId,
                                puntoVentaContext.cajaId, lstPedido, formasPago, new List<ValeFPModel>(), pedido.PedidoId,
                                false, false, null, true);

                            if (error.Length > 0)
                            {
                                XtraMessageBox.Show(error, "ERROR");
                                return;
                            }
                            else
                            {
                                oContext = new ERPProdEntities();
                                //ASEGURARSE QUE EL PEDIDO TENGA VENTA LIGADA                    
                                ERP.Reports.rptPedidoDevolucion oTicketPedido = new ERP.Reports.rptPedidoDevolucion();


                                ERP.Common.Reports.ReportViewer oViewerPedido = new ERP.Common.Reports.ReportViewer(this.puntoVentaContext.cajaId);
                                oContext = new ERPProdEntities();
                                oTicketPedido.DataSource = oContext.p_rpt_pedido_orden_sel(pedido.PedidoId).ToList();

                                oViewerPedido.ShowTicket(oTicketPedido);

                                #region registrar mov Bascula

                                #endregion
                                oContext = new ERPProdEntities();
                                cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

                                if (lstPedido.Sum(s => s.total) >= (entity.MontoImpresionTicket ?? 0))
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

                                this.LoadGrid();
                                this.DialogResult = DialogResult.OK;

                                this.Close();

                            }
                        }
                        else
                        {
                            uiGuardar.Enabled = true;
                            uiCancelar.Enabled = true;
                            ERP.Utils.MessageBoxUtil.ShowError(error);
                            return;
                        }

                        

                    


                }
            }
            catch (Exception ex)
            {
                uiGuardar.Enabled = true;
                uiCancelar.Enabled = true;

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                  "ERP",
                                                  this.Name,
                                                  ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            uiGuardar.Enabled = false;
            uiCancelar.Enabled = false;

            this.guardar();
        }
    }
}
