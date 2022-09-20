using ConexionBD;
using ConexionBD.Models;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static ERP.Business.Enumerados;

namespace ERP.Business
{
    public class VentasBusiness
    {
        public static string pagar(ref long ventaId,
           int? clienteId,
           string folio,
           decimal porcDescuentoVenta,
           decimal montoDescuentoVenta,
           decimal descuentoEnPartidas,
           decimal impuestos,
           decimal subTotal,
           decimal totalVenta,
           decimal totalRecibido,
           decimal cambio,
           bool descuentoVentaSiNo,
           int sucursalId,
           int usuarioId,
           int cajaId,
           List<ProductoModel0> productos,
           List<FormaPagoModel> formasPago,
            List<ValeFPModel> vales,
       int pedidoOrdenId,
       bool cortesia=false,
       bool precioEmpleado = false
       )
        {
            string error = "";
            ERPProdEntities oContext;
            try
            {
                oContext = new ERPProdEntities();
                using (TransactionScope scope = new TransactionScope())
                {
                    
                    if (clienteId == 0)
                    {
                        clienteId = null;
                    }
                    ObjectParameter pVentaId = new ObjectParameter("pVentaId", 0);

                    DateTime fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                    /**************Validar que no existan tickets con fechas inconsistentes*******************/
                    //if (
                    //    oContext.doc_ventas
                    //    .Where(
                    //        w => DbFunctions.TruncateTime(fechaActual) < DbFunctions.TruncateTime(w.Fecha)
                    //        ).Count() > 0
                    //    )
                    //{
                    //    error = "No es posible generar el ticket, ya que se detectó una inconsitencia con la fecha del ticket";
                    //    return error;
                    //}

                    oContext.p_InsertarVenta(pVentaId, folio, fechaActual, clienteId, descuentoVentaSiNo, porcDescuentoVenta, montoDescuentoVenta, descuentoEnPartidas,
                       montoDescuentoVenta + descuentoEnPartidas, impuestos, subTotal, totalVenta, totalRecibido, cambio, true, usuarioId, DateTime.Now, null, null, sucursalId, cajaId, pedidoOrdenId,false);

                    ventaId = long.Parse(pVentaId.Value.ToString());
                    foreach (ProductoModel0 itemProducto in productos)
                    {
                        oContext.p_InsertarVentaDetalle(0, int.Parse(pVentaId.Value.ToString()), itemProducto.productoId, itemProducto.cantidad, itemProducto.descripcion, itemProducto.precioUnitario,
                            itemProducto.porcDescuento, itemProducto.montoDescuento, itemProducto.impuestos, itemProducto.total, usuarioId, DateTime.Now,
                            itemProducto.tipoDescuentoId, itemProducto.promocionCMId, itemProducto.cargoAdicionalId, null,itemProducto.paraLlevar,itemProducto.paraMesa);
                    }

                    foreach (FormaPagoModel itemFP in formasPago)
                    {
                        if (itemFP.cantidad > 0)
                        {
                            oContext.p_InsertarVentaFormaPago(itemFP.id, int.Parse(pVentaId.Value.ToString()), itemFP.cantidad, 1, itemFP.digitoVerificador);
                        }
                    }

                    foreach (ValeFPModel itemVale in vales)
                    {
                        oContext.p_doc_venta_fp_vale_ins(0, int.Parse(pVentaId.Value.ToString()), (int)tipoVale.devolucion, itemVale.monto, itemVale.folioVale);
                    }

                    oContext.p_venta_afecta_inventario(int.Parse(pVentaId.Value.ToString()), usuarioId);

                    #region Báscula Bitácora
                    cat_basculas_configuracion configBascula = null;
                    configBascula = ERP.Business.BasculasBusiness.GetConfiguracionPCLocal(usuarioId);
                    if (productos.Where(w => w.tieneBascula).Count() > 0)
                    {
                        

                        if (configBascula != null)
                        {
                            foreach (ProductoModel0 itemProducto in productos.Where(w => w.tieneBascula))
                            {
                                ERP.Business.BasculasBusiness.InsertBitacora(configBascula.BasculaId,
                                    sucursalId,
                                    usuarioId,
                                    itemProducto.cantidad,
                                    cortesia ? (int)ERP.Business.Enumerados.tipoBasculaBitacora.Cortesia : 
                                    (precioEmpleado ? (int)ERP.Business.Enumerados.tipoBasculaBitacora.PrecioEmpleado : (int)ERP.Business.Enumerados.tipoBasculaBitacora.VentaMostrador),
                                    itemProducto.productoId,
                                    null,
                                    oContext);
                            }
                        }
                        
                    }

                    #endregion

                    #region DevolucionReparto
                    if(productos.Where(w=> w.cantidadCobroReparto > 0).Count() > 0)
                    {
                        if(oContext.sis_preferencias_empresa
                            .Where(w=> w.sis_preferencias.Preferencia == "SolictarDevolucionPedido").Count() > 0)
                        {
                            PedidoOrdenBusiness oPedido = new PedidoOrdenBusiness();

                           error= oPedido.GuardarDevolucionReparto(pedidoOrdenId, productos, usuarioId, sucursalId, ref oContext);

                            if(error.Length > 0)
                            {
                                scope.Dispose();
                                return error;
                            }
                        }
                    }
                    #endregion

                    //oContext.SaveChanges();
                    scope.Complete();

                }
            }
            catch (Exception ex)
            {
                error = ex.Message;

            }

            return error;
        }


        public static string ObtenFolioVentaSiguiente(int sucursalId)
        {
            int folio = 0;
            string serie = ObtenSerie();
            ERPProdEntities oContext = new ERPProdEntities();

            var folioStr = oContext.doc_ventas
                .Where(w => w.Serie == serie).Max(f => f.Folio);

            int.TryParse(folioStr, out folio);

            return (folio + 1).ToString();
        }

        public static string ObtenSerie()
        {
            ERPProdEntities oContext = new ERPProdEntities();

            return oContext.cat_configuracion.FirstOrDefault().SerieTicketVenta == null ? "NV": oContext.cat_configuracion.FirstOrDefault().SerieTicketVenta;
        }

        public static ResultAPIModel GuardaVentaCancelada(List<ConexionBD.ProductoModel0> lstProductos,
            string moticoCancelacion,
            int usuarioId,
            int cajaId,
            int sucursalId)
        {
            int err = 0;
            ResultAPIModel result = new ResultAPIModel();
            cat_basculas_configuracion configBascula = null;
            try
            {
                using (ERPProdEntities oContext = new ERPProdEntities())
                {
                    using (var dbContextTransaction = oContext.Database.BeginTransaction())
                    {
                        try
                        {
                            doc_ventas entityVenta = new doc_ventas();

                            entityVenta.Activo = false;
                            entityVenta.CajaId = cajaId;
                            entityVenta.Cambio = 0;
                            entityVenta.ClienteId = null;
                            entityVenta.DescuentoEnPartidas = 0;
                            entityVenta.DescuentoVentaSiNo = false;
                            entityVenta.Facturar = false;
                            entityVenta.Fecha = DateTime.Now;
                            entityVenta.FechaCancelacion = DateTime.Now;
                            entityVenta.FechaCreacion = DateTime.Now;
                            entityVenta.Folio = ObtenFolioVentaSiguiente(sucursalId);
                            entityVenta.Impuestos = 0;
                            entityVenta.MontoDescuentoVenta = 0;
                            entityVenta.MotivoCancelacion = moticoCancelacion;
                            entityVenta.PorcDescuentoVenta = 0;
                            entityVenta.Rec = false;
                            entityVenta.Serie = ObtenSerie();
                            entityVenta.SubTotal = 0;
                            entityVenta.SucursalId = sucursalId;
                            entityVenta.TotalDescuento = 0;
                            entityVenta.TotalRecibido = 0;
                            entityVenta.TotalVenta = lstProductos.Sum(s => s.total);
                            entityVenta.UsuarioCancelacionId = usuarioId;
                            entityVenta.UsuarioCreacionId = usuarioId;
                            entityVenta.VentaId = (oContext.doc_ventas
                                .Max(m => (int?)m.VentaId) ?? 0) + 1;

                            oContext.doc_ventas.Add(entityVenta);
                            oContext.SaveChanges();


                            foreach (var itemDet in lstProductos)
                            {
                                doc_ventas_detalle entityDet = new doc_ventas_detalle();

                                entityDet.Cantidad = itemDet.cantidad;
                                entityDet.CargoAdicionalId = null;
                                entityDet.CargoDetalleId = null;
                                entityDet.Descripcion = itemDet.descripcion;
                                entityDet.Descuento = 0;
                                entityDet.FechaCreacion = DateTime.Now;
                                entityDet.Impuestos = 0;
                                entityDet.ParaLlevar = false;
                                entityDet.ParaMesa = false;
                                entityDet.PorcDescuneto = 0;
                                entityDet.PrecioUnitario = itemDet.precioUnitario;
                                entityDet.ProductoId = itemDet.productoId;
                                entityDet.PromocionCMId = null;
                                entityDet.TasaIVA = 0;
                                entityDet.TipoDescuentoId = null;
                                entityDet.Total = itemDet.total;
                                entityDet.UsuarioCreacionId = usuarioId;
                                entityDet.VentaDetalleId = (oContext.doc_ventas_detalle
                                    .Max(m => (long?)m.VentaDetalleId) ?? 0) + 1;
                                entityDet.VentaId = entityVenta.VentaId;


                                oContext.doc_ventas_detalle.Add(entityDet);
                                oContext.SaveChanges();
                            }

                            if (configBascula == null)
                            {
                                configBascula = BasculasBusiness.GetConfiguracionPCLocal(usuarioId);
                            }
                            if(configBascula!= null)
                            {
                                //Bitácora Báscula
                                foreach (var itemBascula in lstProductos.Where(w => w.tieneBascula))
                                {
                                    ERP.Business.BasculasBusiness.InsertBitacora(configBascula.BasculaId, sucursalId,
                                    usuarioId, itemBascula.cantidad,
                                    (int)ERP.Business.Enumerados.tipoBasculaBitacora.CancelacionVentaPV,
                                    itemBascula.productoId, null);
                                }
                            }
                            
                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {

                            dbContextTransaction.Rollback();

                            err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                                "ERP",
                                                "ERP.VentaBusiness.GuardaVentaCancelada",
                                                ex);

                            result.error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                                 "ERP",
                                                 "ERP.VentaBusiness.GuardaVentaCancelada",
                                                 ex);

                result.error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
            }

            return result;
        }
    }
}
