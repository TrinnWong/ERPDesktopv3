using ConexionBD;
using ERP.Models.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business
{
    public class ProductoSobranteBusiness : BusinessObject
    {
        public string Guardar(List<ProductoInventarioModel> datos, int usuarioId,int empresId,int sucursalId)
        {
            try
            {
                List<doc_productos_sobrantes_config> configSobrantes = oContext.doc_productos_sobrantes_config
                    .Where(w => w.EmpresaId == empresId).ToList();

                using (var context = new ERPProdEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var basculaConfig = BasculasBusiness.GetConfiguracionPCLocal(usuarioId, sucursalId);

                            #region movimiento Salida Encabezado
                            doc_inv_movimiento movimientoSalida = new doc_inv_movimiento();

                            movimientoSalida.Activo = true;
                            movimientoSalida.SucursalId = sucursalId;
                            movimientoSalida.SucursalDestinoId = null;
                            movimientoSalida.SucursalOrigenId = null;
                            movimientoSalida.FechaMovimiento = DateTime.Now;
                            movimientoSalida.HoraMovimiento = DateTime.Now.TimeOfDay;
                            movimientoSalida.Autorizado = true;
                            movimientoSalida.AutorizadoPor = usuarioId;
                            movimientoSalida.Cancelado = false;
                            movimientoSalida.Comentarios = "Ajuste por Regitro de Productos Sobrantes";
                            movimientoSalida.FechaAutoriza = DateTime.Now;
                            movimientoSalida.TipoMovimientoId = (int)ConexionBD.Enumerados.tipoMovsInventario.ajustePorSalida;
                            movimientoSalida.MovimientoId = (context.doc_inv_movimiento.Max(m => (int?)m.MovimientoId) ?? 0) + 1;
                            movimientoSalida.Consecutivo = (context.doc_inv_movimiento
                                                            .Where(w => w.SucursalId == sucursalId &&
                                                            w.TipoMovimientoId == (int)ConexionBD.Enumerados.tipoMovsInventario.ajustePorSalida)
                                                            .Max(m => (int?)m.Consecutivo) ?? 0) + 1;
                            movimientoSalida.FolioMovimiento = movimientoSalida.Consecutivo.ToString();
                            movimientoSalida.CreadoEl = DateTime.Now;
                            movimientoSalida.CreadoPor = usuarioId;
                            context.doc_inv_movimiento.Add(movimientoSalida);
                            context.SaveChanges();
                            #endregion

                            #region movimiento Entrada Encabezado
                            doc_inv_movimiento movimientoEntrada = new doc_inv_movimiento();

                            movimientoEntrada.Activo = true;
                            movimientoEntrada.SucursalId = sucursalId;
                            movimientoEntrada.SucursalDestinoId = null;
                            movimientoEntrada.SucursalOrigenId = null;
                            movimientoEntrada.FechaMovimiento = DateTime.Now;
                            movimientoEntrada.HoraMovimiento = DateTime.Now.TimeOfDay;
                            movimientoEntrada.Autorizado = true;
                            movimientoEntrada.AutorizadoPor = usuarioId;
                            movimientoEntrada.Cancelado = false;
                            movimientoEntrada.Comentarios = "Ajuste por Regitro de Productos Sobrantes";
                            movimientoEntrada.FechaAutoriza = DateTime.Now;
                            movimientoEntrada.TipoMovimientoId = (int)ConexionBD.Enumerados.tipoMovsInventario.ajustePorEntrada;
                            movimientoEntrada.MovimientoId = (context.doc_inv_movimiento.Max(m => (int?)m.MovimientoId) ?? 0) + 1;
                            movimientoEntrada.Consecutivo = (context.doc_inv_movimiento
                                                            .Where(w => w.SucursalId == sucursalId &&
                                                            w.TipoMovimientoId == (int)ConexionBD.Enumerados.tipoMovsInventario.ajustePorEntrada)
                                                            .Max(m => (int?)m.Consecutivo) ?? 0) + 1;
                            movimientoEntrada.FolioMovimiento = movimientoEntrada.Consecutivo.ToString();
                            movimientoEntrada.CreadoEl = DateTime.Now;
                            movimientoEntrada.CreadoPor = usuarioId;
                            context.doc_inv_movimiento.Add(movimientoEntrada);
                            context.SaveChanges();
                            #endregion

                            foreach (ProductoInventarioModel itemDato in datos)
                            {
                                short consecutivoSalidaDet = 1;
                                short consecutivoEntradaDet = 1;
                                doc_productos_sobrantes_registro regitroSobrante = new doc_productos_sobrantes_registro();

                                regitroSobrante.CantidadSobrante = (double?)itemDato.cantidad;
                                regitroSobrante.CreadoEl = DateTime.Now;
                                regitroSobrante.CreadoPor = usuarioId;
                                regitroSobrante.ProductoId = itemDato.productoId;
                                regitroSobrante.SucursalId = sucursalId;
                                regitroSobrante.Id = (context.doc_productos_sobrantes_registro.Max(m => (int?)m.Id) ?? 0) + 1;

                                regitroSobrante= context.doc_productos_sobrantes_registro.Add(regitroSobrante);
                                context.SaveChanges();

                                #region detalle Salida

                                doc_inv_movimiento_detalle movDetalleSalidaInv = new doc_inv_movimiento_detalle();

                                movDetalleSalidaInv.Cantidad = itemDato.cantidad;
                                movDetalleSalidaInv.Comisiones = 0;
                                movDetalleSalidaInv.Consecutivo = consecutivoSalidaDet;
                                movDetalleSalidaInv.CostoPromedio = null;
                                movDetalleSalidaInv.CostoUltimaCompra = null;
                                movDetalleSalidaInv.CreadoEl = DateTime.Now;
                                movDetalleSalidaInv.CreadoPor = usuarioId;
                                movDetalleSalidaInv.Disponible = null;
                                movDetalleSalidaInv.Flete = 0;
                                movDetalleSalidaInv.Importe = 0;
                                movDetalleSalidaInv.MovimientoDetalleId = (context.doc_inv_movimiento_detalle
                                    .Max(m => (int?)m.MovimientoDetalleId) ?? 0) + 1;
                                movDetalleSalidaInv.MovimientoId = movimientoSalida.MovimientoId;
                                movDetalleSalidaInv.PrecioUnitario = 0;//ERP.Business.ProductoBusiness.ObtenerPrecioUnitario(itemDato.productoId, Enumerados.tipoPrecioProducto.PublicoGeneral, usuarioId);
                                movDetalleSalidaInv.ProductoId = itemDato.productoId;
                                movDetalleSalidaInv.ValCostoPromedio = null;
                                movDetalleSalidaInv.ValCostoUltimaCompra = null;
                                movDetalleSalidaInv.ValorMovimiento = null;

                                context.doc_inv_movimiento_detalle.Add(movDetalleSalidaInv);
                                context.SaveChanges();

                                #endregion


                                #region detalle Entrada

                                doc_inv_movimiento_detalle movDetalleEntradaInv = new doc_inv_movimiento_detalle();

                                movDetalleEntradaInv.Cantidad = itemDato.cantidad;
                                movDetalleEntradaInv.Comisiones = 0;
                                movDetalleEntradaInv.Consecutivo = consecutivoEntradaDet;
                                movDetalleEntradaInv.CostoPromedio = null;
                                movDetalleEntradaInv.CostoUltimaCompra = null;
                                movDetalleEntradaInv.CreadoEl = DateTime.Now;
                                movDetalleEntradaInv.CreadoPor = usuarioId;
                                movDetalleEntradaInv.Disponible = null;
                                movDetalleEntradaInv.Flete = 0;
                                movDetalleEntradaInv.Importe = 0;
                                movDetalleEntradaInv.MovimientoDetalleId = (context.doc_inv_movimiento_detalle
                                    .Max(m => (int?)m.MovimientoDetalleId) ?? 0) + 1;
                                movDetalleEntradaInv.MovimientoId = movimientoEntrada.MovimientoId;
                                movDetalleEntradaInv.PrecioUnitario = ERP.Business.ProductoBusiness.ObtenerPrecioUnitario(itemDato.productoId, Enumerados.tipoPrecioProducto.PublicoGeneral, usuarioId);
                                movDetalleEntradaInv.ProductoId = configSobrantes.Where(w=> w.ProductoSobranteId == itemDato.productoId).Count() > 0 
                                    ? configSobrantes.Where(w => w.ProductoSobranteId == itemDato.productoId).FirstOrDefault().ProductoConvertirId : itemDato.productoId;
                                movDetalleEntradaInv.ValCostoPromedio = null;
                                movDetalleEntradaInv.ValCostoUltimaCompra = null;
                                movDetalleEntradaInv.ValorMovimiento = null;

                                context.doc_inv_movimiento_detalle.Add(movDetalleEntradaInv);
                                context.SaveChanges();

                                #endregion

                                #region relacion Inventario Sobrante
                                doc_productos_sobrantes_regitro_inventario registroSobranteInventario = new doc_productos_sobrantes_regitro_inventario();

                                registroSobranteInventario.CreadoEl = DateTime.Now;
                                registroSobranteInventario.MovimientoDetalleId = movDetalleSalidaInv.MovimientoDetalleId;
                                registroSobranteInventario.SobranteRegsitroId = regitroSobrante.Id;
                                context.doc_productos_sobrantes_regitro_inventario.Add(registroSobranteInventario);
                                context.SaveChanges();

                                registroSobranteInventario = new doc_productos_sobrantes_regitro_inventario();

                                registroSobranteInventario.CreadoEl = DateTime.Now;
                                registroSobranteInventario.MovimientoDetalleId = movDetalleEntradaInv.MovimientoDetalleId;
                                registroSobranteInventario.SobranteRegsitroId = regitroSobrante.Id;
                                context.doc_productos_sobrantes_regitro_inventario.Add(registroSobranteInventario);
                                context.SaveChanges();
                                #endregion

                                var productoVar = ERP.Business.DataMemory.DataBucket.GetProductosMemory(false)
                                    .Where(w => w.ProductoId == itemDato.productoId)
                                    .FirstOrDefault();

                                if(productoVar.ProdVtaBascula == true)
                                {
                                    BasculasBusiness.InsertBitacora(basculaConfig.BasculaId, 
                                        sucursalId, 
                                        usuarioId, 
                                        itemDato.cantidad,
                                       (int)ERP.Business.Enumerados.tipoBasculaBitacora.ProductoSobrante,
                                       itemDato.productoId, null);
                                }

                               

                                consecutivoEntradaDet++;
                                consecutivoSalidaDet++;
                            }
                            context.SaveChanges();

                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                              "ERP",
                                              "ERP.Business.ProductoSobranteBusiness",
                                              ex);

                            return "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
                        }
                        
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                              "ERP",
                                              "ERP.Business.ProductoSobranteBusiness",
                                              ex);

                return "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
            }
        }

        public static bool ExistenSobrantes(int sucursalId,DateTime fecha, int usuarioId)
        {
            bool result = false;
            try
            {
                ERPProdEntities oContext = new ERPProdEntities();
                int dia = fecha.Day;int mes = fecha.Month; int anio = fecha.Year;

                if(oContext.doc_productos_sobrantes_registro
                    .Where(w=> w.SucursalId == sucursalId && w.CreadoEl.Value.Day == dia &&
                    w.CreadoEl.Value.Month == mes && w.CreadoEl.Value.Year == anio).Count() > 0)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                              "ERP",
                                              "ERP.Business.ProductoSobranteBusiness",
                                              ex);
               
            }

            return result;
        }
    }
}
