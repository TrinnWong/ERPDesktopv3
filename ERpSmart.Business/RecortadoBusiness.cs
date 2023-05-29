using ConexionBD;
using ERP.Models.Sincronizacion;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business
{
    public class RecortadoBusiness
    {
        int err;
        SisCuentaBusiness sisCuenta;
        public string Iniciar(int usuarioId)
        {
            try
            {
                
                sisCuenta = new SisCuentaBusiness();
                ERPProdEntities contextSuc = new ERPProdEntities();
                ERPProdEntities contextMaster = new ERPProdEntities(ConexionBD.Sistema.scMain);
                sis_cuenta sisCuentaData =  sisCuenta.ObtieneArchivoConfiguracionCuenta();
                List<doc_ventas> lstVentas = contextSuc.doc_ventas.Where(w => (w.Rec ?? false) == false && w.doc_corte_caja.Count() == 0).ToList();
                long[] ventas = lstVentas.Select(s => s.VentaId).ToArray();
                List<doc_ventas_detalle> lstVentasDetalle = contextSuc.doc_ventas_detalle
                    .Where(w => (w.doc_ventas.Rec ?? false) == false && w.doc_ventas.doc_corte_caja.Count() == 0).ToList();
                List<doc_ventas_formas_pago> lstVentasFormasPago = contextSuc.doc_ventas_formas_pago.Where(w => ventas.Contains(w.VentaId)).ToList();
                List<doc_inv_movimiento> lstVentasInv = contextSuc.doc_inv_movimiento.Where(w => ventas.Contains(w.VentaId??0)).ToList();
                List<doc_inv_movimiento_detalle> lstVentasInvDetalle = contextSuc.doc_inv_movimiento_detalle
                    .Where(w => ventas.Contains(w.doc_inv_movimiento.VentaId ?? 0)).ToList();
                List<VentaRelacionModel> lstVentaRelacion = new List<VentaRelacionModel>();
                List<InventarioMovimientoRelacion> lstInventarioRelacion = new List<InventarioMovimientoRelacion>();
                #region enviar ventas a Master
                using (var dbContextTransaction = contextMaster.Database.BeginTransaction())
               {
                    try
                    {
                        

                        foreach (doc_ventas itemVenta in lstVentas)
                        {
                            doc_ventas itemNew = new doc_ventas();
                            itemNew.VentaId = (contextMaster.doc_ventas.Max(m => (int?)m.VentaId) ?? 0) + 1;
                            itemNew.Activo = itemVenta.Activo;
                            itemNew.CajaId = itemVenta.CajaId;
                            itemNew.Cambio = itemVenta.Cambio;
                            itemNew.ClienteId = itemVenta.ClienteId;
                            itemNew.DescuentoEnPartidas = itemVenta.DescuentoEnPartidas;
                            itemNew.DescuentoVentaSiNo = itemVenta.DescuentoVentaSiNo;
                            itemNew.Fecha = itemVenta.Fecha;
                            itemNew.FechaCancelacion = itemVenta.FechaCancelacion;
                            itemNew.FechaCreacion = itemVenta.FechaCreacion;
                            itemNew.Folio = itemVenta.Folio;
                            itemNew.Impuestos = itemVenta.Impuestos;
                            itemNew.MontoDescuentoVenta = itemVenta.MontoDescuentoVenta;
                            itemNew.MotivoCancelacion = itemVenta.MotivoCancelacion;
                            itemNew.PorcDescuentoVenta = itemVenta.PorcDescuentoVenta;
                            itemNew.Rec = true;
                            itemNew.Serie = itemVenta.Serie;
                            itemNew.SubTotal = itemVenta.SubTotal;
                            itemNew.SucursalId = itemVenta.SucursalId;
                            itemNew.TotalDescuento = itemVenta.TotalDescuento;
                            itemNew.TotalRecibido = itemVenta.TotalRecibido;
                            itemNew.TotalVenta = itemVenta.TotalVenta;
                            itemNew.UsuarioCancelacionId = itemVenta.UsuarioCancelacionId;
                            itemNew.UsuarioCreacionId = itemVenta.UsuarioCreacionId;


                            contextMaster.doc_ventas.Add(itemNew);
                            contextMaster.SaveChanges();

                            lstVentaRelacion.Add(new VentaRelacionModel() { ventaMasterId = itemNew.VentaId,
                            ventaSucursalId = itemVenta.VentaId});

                            //lstVentasDetalle.ForEach(w => w.VentaId = (w.VentaId == itemVenta.VentaId ? itemNew.VentaId : w.VentaId));
                            //lstVentasFormasPago.ForEach(w => w.VentaId = (w.VentaId == itemVenta.VentaId ? itemNew.VentaId : w.VentaId));
                            //lstVentasInv.ForEach(w => w.VentaId = (w.VentaId == itemVenta.VentaId ? itemNew.VentaId : w.VentaId));

                        }

                        //ventas Detalle
                        foreach (doc_ventas_detalle itemVentaDetalle in lstVentasDetalle)
                        {
                            doc_ventas_detalle itemDetNew = new doc_ventas_detalle();
                            itemDetNew.VentaDetalleId = (contextMaster.doc_ventas_detalle.Max(m => (int?)m.VentaDetalleId) ?? 0) + 1;
                            itemDetNew.Cantidad = itemVentaDetalle.Cantidad;
                            itemDetNew.CargoAdicionalId = itemVentaDetalle.CargoAdicionalId;
                            itemDetNew.CargoDetalleId = itemVentaDetalle.CargoDetalleId;
                            itemDetNew.Descripcion = itemVentaDetalle.Descripcion;
                            itemDetNew.Descuento = itemVentaDetalle.Descuento;
                            itemDetNew.FechaCreacion = itemVentaDetalle.FechaCreacion;
                            itemDetNew.Impuestos = itemVentaDetalle.Impuestos;
                            itemDetNew.PorcDescuneto = itemVentaDetalle.PorcDescuneto;
                            itemDetNew.PrecioUnitario = itemVentaDetalle.PrecioUnitario;
                            itemDetNew.ProductoId = itemVentaDetalle.ProductoId;
                            itemDetNew.PromocionCMId = itemVentaDetalle.PromocionCMId;
                            itemDetNew.TasaIVA = itemVentaDetalle.TasaIVA;
                            itemDetNew.TipoDescuentoId = itemVentaDetalle.TipoDescuentoId;
                            itemDetNew.Total = itemVentaDetalle.Total;
                            itemDetNew.UsuarioCreacionId = itemVentaDetalle.UsuarioCreacionId;
                            itemDetNew.VentaId = lstVentaRelacion.Where(w=> w.ventaSucursalId == itemVentaDetalle.VentaId)
                                .FirstOrDefault().ventaMasterId;

                            contextMaster.doc_ventas_detalle.Add(itemDetNew);
                            contextMaster.SaveChanges();

                        }

                        //ventas Formas Pago               
                        foreach (doc_ventas_formas_pago itemVentaDetalleFP in lstVentasFormasPago)
                        {
                            doc_ventas_formas_pago itemFPNew = new doc_ventas_formas_pago();

                            itemFPNew.FormaPagoId = itemVentaDetalleFP.FormaPagoId;
                            itemFPNew.Cantidad = itemVentaDetalleFP.Cantidad;
                            itemFPNew.digitoVerificador = itemVentaDetalleFP.digitoVerificador;
                            itemFPNew.FechaCreacion = itemVentaDetalleFP.FechaCreacion;
                            itemFPNew.UsuarioCreacionId = itemVentaDetalleFP.UsuarioCreacionId;
                            itemFPNew.VentaId = lstVentaRelacion.Where(w => w.ventaSucursalId == itemVentaDetalleFP.VentaId)
                                .FirstOrDefault().ventaMasterId;
                            
                            contextMaster.doc_ventas_formas_pago.Add(itemFPNew);
                            contextMaster.SaveChanges();

                        }


                        //Iventarios
                        foreach (doc_inv_movimiento itemInv in lstVentasInv)
                        {
                            doc_inv_movimiento itemInvNew = new doc_inv_movimiento();

                            itemInvNew.Activo = itemInv.Activo;
                            itemInvNew.Autorizado = itemInv.Autorizado;
                            itemInvNew.AutorizadoPor = itemInv.AutorizadoPor;
                            itemInvNew.Cancelado = itemInv.Cancelado;
                            itemInvNew.Comentarios = itemInv.Comentarios;
                            itemInvNew.Consecutivo = itemInv.Consecutivo;
                            itemInvNew.CreadoEl = itemInv.CreadoEl;
                            itemInvNew.CreadoPor = itemInv.CreadoPor;
                            itemInvNew.FechaAutoriza = itemInv.FechaAutoriza;
                            itemInvNew.FechaCancelacion = itemInv.FechaCancelacion;
                            itemInvNew.FechaMovimiento = itemInv.FechaMovimiento;
                            itemInvNew.FolioMovimiento = itemInv.FolioMovimiento;
                            itemInvNew.HoraMovimiento = itemInv.HoraMovimiento;
                            itemInvNew.ImporteTotal = itemInv.ImporteTotal;
                            itemInvNew.MovimientoId = (contextMaster.doc_inv_movimiento
                                .Max(m => (int?)m.MovimientoId) ?? 0) + 1;
                            itemInvNew.MovimientoRefId = null;
                            itemInvNew.ProductoCompraId = null;
                            itemInvNew.SucursalDestinoId = itemInv.SucursalDestinoId;
                            itemInvNew.SucursalId = itemInv.SucursalId;
                            itemInvNew.SucursalOrigenId = itemInv.SucursalOrigenId;
                            itemInvNew.TipoMovimientoId = itemInv.TipoMovimientoId;
                            itemInvNew.VentaId = lstVentaRelacion.Where(w => w.ventaSucursalId == itemInv.VentaId)
                                .FirstOrDefault().ventaMasterId; 

                            contextMaster.doc_inv_movimiento.Add(itemInvNew);
                            contextMaster.SaveChanges();

                            lstInventarioRelacion.Add(new InventarioMovimientoRelacion() {
                                MovimientoMasteriId = itemInvNew.MovimientoId,
                                MovimientoSucursaliId = itemInv.MovimientoId
                            });

                            //lstVentasInvDetalle.ForEach(f => f.MovimientoId = (itemInv.MovimientoId == f.MovimientoId ? itemInvNew.MovimientoId : f.MovimientoId));

                        }

                        //Inventarios Detalle
                        foreach (doc_inv_movimiento_detalle itemInvDetalle in lstVentasInvDetalle)
                        {
                            doc_inv_movimiento_detalle itemInvDetalleNew = new doc_inv_movimiento_detalle();

                            itemInvDetalleNew.Cantidad = itemInvDetalle.Cantidad;
                            itemInvDetalleNew.Comisiones = itemInvDetalle.Comisiones;
                            itemInvDetalleNew.Consecutivo = itemInvDetalle.Consecutivo;
                            itemInvDetalleNew.CostoPromedio = null;
                            itemInvDetalleNew.CostoUltimaCompra = null;
                            itemInvDetalleNew.CreadoEl = itemInvDetalle.CreadoEl;
                            itemInvDetalleNew.CreadoPor = itemInvDetalle.CreadoPor;
                            itemInvDetalleNew.Disponible = null;
                            itemInvDetalleNew.Flete = 0;
                            itemInvDetalleNew.Importe = itemInvDetalle.Importe;
                            itemInvDetalleNew.MovimientoDetalleId = (contextMaster.doc_inv_movimiento_detalle
                                .Max(m => (int?)m.MovimientoDetalleId) ?? 0) + 1;
                            itemInvDetalleNew.MovimientoId = lstInventarioRelacion.Where(w => w.MovimientoSucursaliId == itemInvDetalle.MovimientoId)
                                .FirstOrDefault().MovimientoMasteriId;
                            itemInvDetalleNew.PrecioNeto = itemInvDetalle.PrecioNeto;
                            itemInvDetalleNew.PrecioUnitario = itemInvDetalle.PrecioUnitario;
                            itemInvDetalleNew.ProductoId = itemInvDetalle.ProductoId;
                            itemInvDetalleNew.SubTotal = itemInvDetalle.SubTotal;
                            itemInvDetalleNew.ValCostoPromedio = 0;
                            itemInvDetalleNew.ValCostoUltimaCompra = 0;
                            itemInvDetalleNew.ValorMovimiento = 0;

                            contextMaster.doc_inv_movimiento_detalle.Add(itemInvDetalleNew);
                            contextMaster.SaveChanges();

                        }

                        var ultimaVentaMaster = contextMaster.doc_ventas.Where(w => w.SucursalId == sisCuentaData.ClaveSucursal).OrderByDescending(o => o.VentaId)
                            .FirstOrDefault();

                        if(lstVentas.Count() > 0)
                        {
                            ObjectParameter pCorteCajaId = new ObjectParameter("pCorteCajaId", 0);
                            //Realizar Corte de Caja en Master
                            contextMaster.p_corte_caja_generacion(ultimaVentaMaster.CajaId,
                                ultimaVentaMaster.UsuarioCreacionId,
                                DateTime.Now, pCorteCajaId, false);
                        }

                        

                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        dbContextTransaction.Rollback();

                        err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                          "ERP",
                                          "ERP.Business.RecortadoBusiness.Iniciar",
                                          ex);

                        return "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
                    }
               }
                #endregion

                contextSuc = new ERPProdEntities();
                foreach (int itemVenta in ventas)
                {
                    doc_ventas ventaUpd = contextSuc.doc_ventas.Where(w => w.VentaId == itemVenta).FirstOrDefault();

                    ventaUpd.Rec = true;
                    contextSuc.SaveChanges();

                }

                #region recortar
                ObjectParameter pError = new ObjectParameter("pError","");
                contextSuc.p_doc_ventas_rec(sisCuentaData.ClaveSucursal, pError);

                if(pError.Value.ToString().Length > 0)
                {
                    return pError.ToString();
                }

                #endregion



                return "";
            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                          "ERP",
                                          "ERP.Business.RecortadoBusiness.Iniciar",
                                          ex);

                return "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

            }
        }
    }
}
