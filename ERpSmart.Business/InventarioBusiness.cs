using ConexionBD;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ERP.Business
{
    public class InventarioBusiness : BusinessObject
    {
        int err=0;
        ResultAPIModel result;
        public InventarioBusiness()
        {
           
        }
        public InventarioBusiness(ERPProdEntities _oContext)
        {
            oContext = _oContext;
        }
        public ResultAPIModel GeneraTraspasoAutomatico(int empresaId, int movimientoInvOrigenId, int usuarioId)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                oContext = new ERPProdEntities();

                cat_empresas_config_inventario confEmpresaIn = oContext.cat_empresas_config_inventario
                    .Where(w => w.EmpresaId == empresaId).FirstOrDefault();



                if (confEmpresaIn == null)
                {
                    result.error = "No están habilitados los traspasos automáticos";
                    return result;
                }
                if (!confEmpresaIn.EnableTraspasoAutomatico)
                {
                    result.error = "No están habilitados los traspasos automáticos";
                    return result;
                }


                doc_inv_movimiento movOrigen = oContext.doc_inv_movimiento
                    .Where(w => w.Activo == true
                    && w.Autorizado == true
                    && w.Activo == true
                    && (w.Cancelado ?? false) == false
                    && w.MovimientoId == movimientoInvOrigenId).FirstOrDefault();

                if (movOrigen.TipoMovimientoId == (int)ConexionBD.Enumerados.tipoMovsInventario.salidaPorTraspaso)
                {


                    if (movOrigen != null)
                    {
                        int tipoMovimientoId = (int)ConexionBD.Enumerados.tipoMovsInventario.entradaPorTraspaso;
                        doc_inv_movimiento movDestino = new doc_inv_movimiento();
                        int sucursalOrigenId = movOrigen.SucursalDestinoId ?? 0;
                        DateTime fechaMov = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                        movDestino.MovimientoId = (oContext.doc_inv_movimiento
                            .Max(m => (int?)m.MovimientoId) ?? 0) + 1;
                        movDestino.Activo = true;
                        movDestino.Autorizado = true;
                        movDestino.AutorizadoPor = movOrigen.AutorizadoPor;
                        movDestino.Cancelado = movOrigen.Cancelado;
                        movDestino.Comentarios = (movOrigen.Comentarios ?? "") + "|TRASPASO GENERADO DE MENERA AUTMÁTICA";
                        movDestino.Consecutivo = (oContext.doc_inv_movimiento
                            .Where(w => w.SucursalId == sucursalOrigenId &&
                            w.TipoMovimientoId == tipoMovimientoId).Max(m => (int?)m.Consecutivo) ?? 0) + 1;
                        movDestino.CreadoEl = fechaMov;
                        movDestino.CreadoPor = usuarioId;
                        movDestino.FechaAutoriza = fechaMov;
                        movDestino.FechaMovimiento = fechaMov;
                        movDestino.FolioMovimiento = movDestino.Consecutivo.ToString();
                        movDestino.HoraMovimiento = fechaMov.Date.TimeOfDay;
                        movDestino.ImporteTotal = movOrigen.ImporteTotal;
                        movDestino.SucursalOrigenId = movOrigen.SucursalOrigenId;
                        movDestino.SucursalDestinoId = movOrigen.SucursalDestinoId;
                        movDestino.SucursalId = sucursalOrigenId;
                        movDestino.TipoMovimientoId = tipoMovimientoId;

                        oContext.doc_inv_movimiento.Add(movDestino);
                        oContext.SaveChanges();
                        oContext = new ERPProdEntities();

                        short consecutivoDet = 1;

                        foreach (var itemDestinoDet in movOrigen.doc_inv_movimiento_detalle)
                        {
                            fechaMov = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                            doc_inv_movimiento_detalle movDestinoDet = new doc_inv_movimiento_detalle();

                            movDestinoDet.Cantidad = itemDestinoDet.Cantidad;
                            movDestinoDet.Comisiones = itemDestinoDet.Comisiones;
                            movDestinoDet.Consecutivo = consecutivoDet;
                            movDestinoDet.CostoPromedio = null;
                            movDestinoDet.CostoUltimaCompra = null;
                            movDestinoDet.CreadoEl = fechaMov;
                            movDestinoDet.CreadoPor = usuarioId;
                            movDestinoDet.Disponible = null;
                            movDestinoDet.Flete = itemDestinoDet.Flete;
                            movDestinoDet.Importe = itemDestinoDet.Importe;
                            movDestinoDet.MovimientoDetalleId = (oContext.doc_inv_movimiento_detalle
                                .Max(m => (int?)m.MovimientoDetalleId) ?? 0) + 1;
                            movDestinoDet.MovimientoId = movDestino.MovimientoId;
                            movDestinoDet.PrecioUnitario = itemDestinoDet.PrecioUnitario;
                            movDestinoDet.ProductoId = itemDestinoDet.ProductoId;
                            movDestinoDet.ValCostoPromedio = null;
                            movDestinoDet.ValCostoUltimaCompra = null;
                            movDestinoDet.ValorMovimiento = null;

                            oContext.doc_inv_movimiento_detalle.Add(movDestinoDet);
                            oContext.SaveChanges();

                        }


                    }

                }
                if (movOrigen.TipoMovimientoId == (int)ConexionBD.Enumerados.tipoMovsInventario.entradaPorTraspaso)
                {


                    if (movOrigen != null)
                    {
                        int tipoMovimientoId = (int)ConexionBD.Enumerados.tipoMovsInventario.salidaPorTraspaso;
                        doc_inv_movimiento movDestino = new doc_inv_movimiento();
                        int sucursalOrigenId = movOrigen.SucursalOrigenId ?? 0;
                        DateTime fechaMov = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                        movDestino.MovimientoId = (oContext.doc_inv_movimiento
                            .Max(m => (int?)m.MovimientoId) ?? 0) + 1;
                        movDestino.Activo = true;
                        movDestino.Autorizado = true;
                        movDestino.AutorizadoPor = movOrigen.AutorizadoPor;
                        movDestino.Cancelado = movOrigen.Cancelado;
                        movDestino.Comentarios = (movOrigen.Comentarios ?? "") + "|TRASPASO GENERADO DE MENERA AUTMÁTICA";
                        movDestino.Consecutivo = (oContext.doc_inv_movimiento
                            .Where(w => w.SucursalId == sucursalOrigenId &&
                            w.TipoMovimientoId == tipoMovimientoId).Max(m => (int?)m.Consecutivo) ?? 0) + 1;
                        movDestino.CreadoEl = fechaMov;
                        movDestino.CreadoPor = usuarioId;
                        movDestino.FechaAutoriza = fechaMov;
                        movDestino.FechaMovimiento = fechaMov;
                        movDestino.FolioMovimiento = movDestino.Consecutivo.ToString();
                        movDestino.HoraMovimiento = fechaMov.Date.TimeOfDay;
                        movDestino.ImporteTotal = movOrigen.ImporteTotal;
                        movDestino.SucursalDestinoId = movOrigen.SucursalDestinoId;
                        movDestino.SucursalId = sucursalOrigenId;
                        movDestino.TipoMovimientoId = tipoMovimientoId;
                        movDestino.SucursalOrigenId = movOrigen.SucursalOrigenId;

                        oContext.doc_inv_movimiento.Add(movDestino);
                        oContext.SaveChanges();
                        oContext = new ERPProdEntities();

                        short consecutivoDet = 1;

                        foreach (var itemDestinoDet in movOrigen.doc_inv_movimiento_detalle)
                        {
                            fechaMov = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                            doc_inv_movimiento_detalle movDestinoDet = new doc_inv_movimiento_detalle();

                            movDestinoDet.Cantidad = itemDestinoDet.Cantidad;
                            movDestinoDet.Comisiones = itemDestinoDet.Comisiones;
                            movDestinoDet.Consecutivo = consecutivoDet;
                            movDestinoDet.CostoPromedio = null;
                            movDestinoDet.CostoUltimaCompra = null;
                            movDestinoDet.CreadoEl = fechaMov;
                            movDestinoDet.CreadoPor = usuarioId;
                            movDestinoDet.Disponible = null;
                            movDestinoDet.Flete = itemDestinoDet.Flete;
                            movDestinoDet.Importe = itemDestinoDet.Importe;
                            movDestinoDet.MovimientoDetalleId = (oContext.doc_inv_movimiento_detalle
                                .Max(m => (int?)m.MovimientoDetalleId) ?? 0) + 1;
                            movDestinoDet.MovimientoId = movDestino.MovimientoId;
                            movDestinoDet.PrecioUnitario = itemDestinoDet.PrecioUnitario;
                            movDestinoDet.ProductoId = itemDestinoDet.ProductoId;
                            movDestinoDet.ValCostoPromedio = null;
                            movDestinoDet.ValCostoUltimaCompra = null;
                            movDestinoDet.ValorMovimiento = null;

                            oContext.doc_inv_movimiento_detalle.Add(movDestinoDet);
                            oContext.SaveChanges();

                        }


                    }

                }
            }
            catch (Exception ex)
            {

                result.error = ex.Message;
            }

            return result;
        }

        public static ResultAPIModel GeneraTraspasoAutomatico(int empresaId, 
            int movimientoInvOrigenId, int usuarioId,
            ERPProdEntities oContext)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                oContext = new ERPProdEntities();

                cat_empresas_config_inventario confEmpresaIn = oContext.cat_empresas_config_inventario
                    .Where(w => w.EmpresaId == empresaId).FirstOrDefault();



                if (confEmpresaIn == null)
                {
                    result.error = "No están habilitados los traspasos automáticos";
                    return result;
                }
                if (!confEmpresaIn.EnableTraspasoAutomatico)
                {
                    result.error = "No están habilitados los traspasos automáticos";
                    return result;
                }


                doc_inv_movimiento movOrigen = oContext.doc_inv_movimiento
                    .Where(w => w.Activo == true
                    && w.Autorizado == true
                    && w.Activo == true
                    && (w.Cancelado ?? false) == false
                    && w.MovimientoId == movimientoInvOrigenId).FirstOrDefault();

                if (movOrigen.TipoMovimientoId == (int)ConexionBD.Enumerados.tipoMovsInventario.salidaPorTraspaso)
                {


                    if (movOrigen != null)
                    {
                        int tipoMovimientoId = (int)ConexionBD.Enumerados.tipoMovsInventario.entradaPorTraspaso;
                        doc_inv_movimiento movDestino = new doc_inv_movimiento();
                        int sucursalOrigenId = movOrigen.SucursalDestinoId ?? 0;
                        DateTime fechaMov = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                        movDestino.MovimientoId = (oContext.doc_inv_movimiento
                            .Max(m => (int?)m.MovimientoId) ?? 0) + 1;
                        movDestino.Activo = true;
                        movDestino.Autorizado = true;
                        movDestino.AutorizadoPor = movOrigen.AutorizadoPor;
                        movDestino.Cancelado = movOrigen.Cancelado;
                        movDestino.Comentarios = (movOrigen.Comentarios ?? "") + "|TRASPASO GENERADO DE MENERA AUTMÁTICA";
                        movDestino.Consecutivo = (oContext.doc_inv_movimiento
                            .Where(w => w.SucursalId == sucursalOrigenId &&
                            w.TipoMovimientoId == tipoMovimientoId).Max(m => (int?)m.Consecutivo) ?? 0) + 1;
                        movDestino.CreadoEl = fechaMov;
                        movDestino.CreadoPor = usuarioId;
                        movDestino.FechaAutoriza = fechaMov;
                        movDestino.FechaMovimiento = fechaMov;
                        movDestino.FolioMovimiento = movDestino.Consecutivo.ToString();
                        movDestino.HoraMovimiento = fechaMov.Date.TimeOfDay;
                        movDestino.ImporteTotal = movOrigen.ImporteTotal;
                        movDestino.SucursalOrigenId = movOrigen.SucursalOrigenId;
                        movDestino.SucursalDestinoId = movOrigen.SucursalDestinoId;
                        movDestino.SucursalId = sucursalOrigenId;
                        movDestino.TipoMovimientoId = tipoMovimientoId;

                        oContext.doc_inv_movimiento.Add(movDestino);
                        oContext.SaveChanges();
                        oContext = new ERPProdEntities();

                        short consecutivoDet = 1;

                        foreach (var itemDestinoDet in movOrigen.doc_inv_movimiento_detalle)
                        {
                            fechaMov = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                            doc_inv_movimiento_detalle movDestinoDet = new doc_inv_movimiento_detalle();

                            movDestinoDet.Cantidad = itemDestinoDet.Cantidad;
                            movDestinoDet.Comisiones = itemDestinoDet.Comisiones;
                            movDestinoDet.Consecutivo = consecutivoDet;
                            movDestinoDet.CostoPromedio = null;
                            movDestinoDet.CostoUltimaCompra = null;
                            movDestinoDet.CreadoEl = fechaMov;
                            movDestinoDet.CreadoPor = usuarioId;
                            movDestinoDet.Disponible = null;
                            movDestinoDet.Flete = itemDestinoDet.Flete;
                            movDestinoDet.Importe = itemDestinoDet.Importe;
                            movDestinoDet.MovimientoDetalleId = (oContext.doc_inv_movimiento_detalle
                                .Max(m => (int?)m.MovimientoDetalleId) ?? 0) + 1;
                            movDestinoDet.MovimientoId = movDestino.MovimientoId;
                            movDestinoDet.PrecioUnitario = itemDestinoDet.PrecioUnitario;
                            movDestinoDet.ProductoId = itemDestinoDet.ProductoId;
                            movDestinoDet.ValCostoPromedio = null;
                            movDestinoDet.ValCostoUltimaCompra = null;
                            movDestinoDet.ValorMovimiento = null;

                            oContext.doc_inv_movimiento_detalle.Add(movDestinoDet);
                            oContext.SaveChanges();

                        }


                    }

                }
                if (movOrigen.TipoMovimientoId == (int)ConexionBD.Enumerados.tipoMovsInventario.entradaPorTraspaso)
                {


                    if (movOrigen != null)
                    {
                        int tipoMovimientoId = (int)ConexionBD.Enumerados.tipoMovsInventario.salidaPorTraspaso;
                        doc_inv_movimiento movDestino = new doc_inv_movimiento();
                        int sucursalOrigenId = movOrigen.SucursalOrigenId ?? 0;
                        DateTime fechaMov = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                        movDestino.MovimientoId = (oContext.doc_inv_movimiento
                            .Max(m => (int?)m.MovimientoId) ?? 0) + 1;
                        movDestino.Activo = true;
                        movDestino.Autorizado = true;
                        movDestino.AutorizadoPor = movOrigen.AutorizadoPor;
                        movDestino.Cancelado = movOrigen.Cancelado;
                        movDestino.Comentarios = (movOrigen.Comentarios ?? "") + "|TRASPASO GENERADO DE MENERA AUTMÁTICA";
                        movDestino.Consecutivo = (oContext.doc_inv_movimiento
                            .Where(w => w.SucursalId == sucursalOrigenId &&
                            w.TipoMovimientoId == tipoMovimientoId).Max(m => (int?)m.Consecutivo) ?? 0) + 1;
                        movDestino.CreadoEl = fechaMov;
                        movDestino.CreadoPor = usuarioId;
                        movDestino.FechaAutoriza = fechaMov;
                        movDestino.FechaMovimiento = fechaMov;
                        movDestino.FolioMovimiento = movDestino.Consecutivo.ToString();
                        movDestino.HoraMovimiento = fechaMov.Date.TimeOfDay;
                        movDestino.ImporteTotal = movOrigen.ImporteTotal;
                        movDestino.SucursalDestinoId = movOrigen.SucursalDestinoId;
                        movDestino.SucursalId = sucursalOrigenId;
                        movDestino.TipoMovimientoId = tipoMovimientoId;
                        movDestino.SucursalOrigenId = movOrigen.SucursalOrigenId;

                        oContext.doc_inv_movimiento.Add(movDestino);
                        oContext.SaveChanges();
                        oContext = new ERPProdEntities();

                        short consecutivoDet = 1;

                        foreach (var itemDestinoDet in movOrigen.doc_inv_movimiento_detalle)
                        {
                            fechaMov = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                            doc_inv_movimiento_detalle movDestinoDet = new doc_inv_movimiento_detalle();

                            movDestinoDet.Cantidad = itemDestinoDet.Cantidad;
                            movDestinoDet.Comisiones = itemDestinoDet.Comisiones;
                            movDestinoDet.Consecutivo = consecutivoDet;
                            movDestinoDet.CostoPromedio = null;
                            movDestinoDet.CostoUltimaCompra = null;
                            movDestinoDet.CreadoEl = fechaMov;
                            movDestinoDet.CreadoPor = usuarioId;
                            movDestinoDet.Disponible = null;
                            movDestinoDet.Flete = itemDestinoDet.Flete;
                            movDestinoDet.Importe = itemDestinoDet.Importe;
                            movDestinoDet.MovimientoDetalleId = (oContext.doc_inv_movimiento_detalle
                                .Max(m => (int?)m.MovimientoDetalleId) ?? 0) + 1;
                            movDestinoDet.MovimientoId = movDestino.MovimientoId;
                            movDestinoDet.PrecioUnitario = itemDestinoDet.PrecioUnitario;
                            movDestinoDet.ProductoId = itemDestinoDet.ProductoId;
                            movDestinoDet.ValCostoPromedio = null;
                            movDestinoDet.ValCostoUltimaCompra = null;
                            movDestinoDet.ValorMovimiento = null;

                            oContext.doc_inv_movimiento_detalle.Add(movDestinoDet);
                            oContext.SaveChanges();

                        }


                    }

                }
            }
            catch (Exception ex)
            {

                result.error = ex.Message;
            }

            return result;
        }

        public static string ValidarExistencia(int producto, int sucursal, decimal cantidad)
        {
            string error = "";
            ERPProdEntities oContext2 = new ERPProdEntities();
            int productoid = producto;
            cat_productos_existencias exists = oContext2.cat_productos_existencias
                .Where(w => w.ProductoId == productoid && w.SucursalId == sucursal).FirstOrDefault();

            if (exists != null)
            {
                if (exists.ExistenciaTeorica < cantidad)
                {
                    error = "No hay existencia para el producto:" + exists.cat_productos.Descripcion;
                    return error;
                }
            }
            else
            {
                error = "No hay existencias para el producto:" + producto;
                return error;
            }


            return error;
        }

        public static ResultAPIModel Guardar(ref doc_inv_movimiento entity, int usuarioId, ERPProdEntities oContext)
        {
            ResultAPIModel result = new ResultAPIModel();

            try
            {
                int sucursalId = entity.SucursalId;
                int id = entity.MovimientoId;

                if((entity==null ? new doc_inv_movimiento() : entity).MovimientoId > 0)
                {
                    doc_inv_movimiento entityUpd = oContext.doc_inv_movimiento
                        .Where(w => w.MovimientoId == id).FirstOrDefault();

                    entityUpd.SucursalDestinoId = entity.SucursalDestinoId;
                    entityUpd.Activo = entity.Activo;
                    entityUpd.Autorizado = entity.Autorizado;
                    entityUpd.Cancelado = entity.Cancelado;
                    entityUpd.Comentarios = entity.Comentarios;
                    entityUpd.FechaAutoriza = entity.FechaAutoriza;
                    entityUpd.FechaCancelacion = entity.FechaCancelacion;
                    entityUpd.ImporteTotal = entity.ImporteTotal;
                    entityUpd.TipoMermaId = entity.TipoMermaId;
                    entityUpd.Comentarios = entity.Comentarios;
                    oContext.SaveChanges();

                    entity = entityUpd;
                }
                else
                {
                    doc_inv_movimiento entityNew = new doc_inv_movimiento();


                    entityNew.MovimientoId = (oContext.doc_inv_movimiento
                        .Max(m => (int?)m.MovimientoId) ?? 0) + 1;
                    entityNew.Activo = true;
                    entityNew.Autorizado = entity.Autorizado;
                    entityNew.AutorizadoPor = entity.AutorizadoPor;
                    entityNew.Cancelado = entity.Cancelado;
                    entityNew.Comentarios = entity.Comentarios;
                    entityNew.Consecutivo = (oContext.doc_inv_movimiento
                        .Where(w => w.SucursalId == sucursalId)
                        .Max(m => (int?)m.Consecutivo) ?? 0) + 1;
                    entityNew.CreadoEl = DateTime.Now;
                    entityNew.CreadoPor = usuarioId;
                    entityNew.FechaAutoriza = entity.FechaAutoriza;
                    entityNew.FechaCancelacion = entity.FechaCancelacion;
                    entityNew.FechaMovimiento = entity.FechaMovimiento;
                    entityNew.FolioMovimiento = entityNew.Consecutivo.ToString();
                    entityNew.HoraMovimiento = entity.HoraMovimiento;
                    entityNew.ImporteTotal = entity.ImporteTotal;
                    entityNew.MovimientoRefId = entity.MovimientoRefId;
                    entityNew.ProductoCompraId = entity.ProductoCompraId;
                    entityNew.SucursalDestinoId = entity.SucursalDestinoId;
                    entityNew.SucursalId = entity.SucursalId;
                    entityNew.SucursalOrigenId = entity.SucursalOrigenId;
                    entityNew.TipoMovimientoId = entity.TipoMovimientoId;
                    entityNew.VentaId = entity.VentaId;
                    entityNew.TipoMermaId = entity.TipoMermaId;
                    entityNew.Comentarios = entity.Comentarios;

                    oContext.doc_inv_movimiento.Add(entityNew);

                    oContext.SaveChanges();

                    entity = entityNew;
                }

               

                

            }
            catch (Exception ex)
            {
                entity.MovimientoId = 0;

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                    "ERP",
                                    "InventarioBusiness.Guardar",
                                    ex);

                result.error = ConstantesBusiness.messageErrorBitacora.Replace("{id}", err.ToString());

            }


            return result;
        }

        public static ResultAPIModel GuardarDetalle(ref doc_inv_movimiento_detalle entityDet, doc_inv_movimiento entityEnc, int usuarioId, ERPProdEntities oContext)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                doc_inv_movimiento_detalle entityNew = new doc_inv_movimiento_detalle();
                int MovimientoId = entityEnc.MovimientoId;
                entityNew.MovimientoDetalleId = (oContext.doc_inv_movimiento_detalle
                    .Max(m => (int?)m.MovimientoDetalleId) ?? 0) + 1;
                entityNew.Cantidad = entityDet.Cantidad;
                entityNew.Comisiones = entityDet.Comisiones;
                entityNew.Consecutivo = (short)((oContext.doc_inv_movimiento_detalle
                    .Where(w=> w.MovimientoId == MovimientoId).Max(m=> (int?)m.Consecutivo)??0)+1);
                entityNew.CostoPromedio = entityDet.CostoPromedio;
                entityNew.CostoUltimaCompra = entityDet.CostoUltimaCompra;
                entityNew.CreadoEl = DateTime.Now;
                entityNew.CreadoPor = entityDet.CreadoPor;
                entityNew.Disponible = entityDet.Disponible;
                entityNew.Flete = entityDet.Flete;
                entityNew.Importe = entityDet.Importe;
                entityNew.MovimientoId = entityEnc.MovimientoId;
                entityNew.PrecioUnitario = entityDet.PrecioUnitario;
                entityNew.ProductoId = entityDet.ProductoId;
                entityNew.ValCostoPromedio = entityDet.ValCostoPromedio;
                entityNew.ValCostoUltimaCompra = entityDet.ValCostoUltimaCompra;
                entityNew.ValorMovimiento = entityDet.ValorMovimiento;


                oContext.doc_inv_movimiento_detalle.Add(entityNew);

                oContext.SaveChanges();
                entityDet = entityNew;


            }
            catch (Exception ex)
            {
                entityDet.MovimientoDetalleId = 0;
                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                    "ERP",
                                    "InventarioBusiness.Guardar",
                                    ex);

                result.error = ConstantesBusiness.messageErrorBitacora.Replace("{id}", err.ToString());


            }

            return result;
        }


        public static ResultAPIModel GuardarTraspaso(ref doc_inv_movimiento entity,
            List<doc_inv_movimiento_detalle> entityDetalle,
            int usuarioId,
            int empresaId,
            ERPProdEntities oContext)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                var configBascula = ERP.Business.BasculasBusiness.GetConfiguracionPCLocal(usuarioId,entity.SucursalId);
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        result = Guardar(ref entity, usuarioId, oContext);

                        if (result.ok)
                        {
                            for (int i = 0; i < entityDetalle.Count; i++)
                            {
                                doc_inv_movimiento_detalle itemDET = entityDetalle[i];
                                result = GuardarDetalle(ref itemDET, entity,
                                    usuarioId, oContext);

                                if (!result.ok)
                                {
                                    return result;
                                }
                                if(ERP.Business.DataMemory.DataBucket.GetProductosMemory(false).Where(w=> w.ProductoId == entityDetalle[i].ProductoId).FirstOrDefault()
                                    .ProdVtaBascula == true)
                                {
                                    //Guarda Bitácora Báscula
                                    ERP.Business.BasculasBusiness.InsertBitacora(configBascula.BasculaId, entity.SucursalId, usuarioId, entityDetalle[i].Cantidad ?? 0,
                                        (int)ERP.Business.Enumerados.tipoBasculaBitacora.Traspaso, entityDetalle[i].ProductoId, null);
                                }
                                
                            }

                            cat_empresas_config_inventario confEmpresaIn = oContext.cat_empresas_config_inventario
                           .Where(w => w.EmpresaId == empresaId).FirstOrDefault();

                            if (confEmpresaIn != null)
                            {
                                if (confEmpresaIn.EnableTraspasoAutomatico)
                                {
                                    result = GeneraTraspasoAutomatico(empresaId, entity.MovimientoId,
                                         usuarioId, oContext);

                                    if (!result.ok)
                                    {
                                        return result;
                                    }
                                }
                            }
                        }
                        else
                        {
                            scope.Dispose();
                            return result;
                        }

                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();

                        int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                  "ERP",
                                  "InventarioBusiness.Guardar",
                                  ex);

                        result.error = ConstantesBusiness.messageErrorBitacora.Replace("{id}", err.ToString());


                    }
                }
               
            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                   "ERP",
                                   "InventarioBusiness.Guardar",
                                   ex);

                result.error = ConstantesBusiness.messageErrorBitacora.Replace("{id}", err.ToString());



            }

            return result;
        }


        public static ResultAPIModel GuardarInventarioReal(List<doc_inventario_registro> datos, 
            int sucursalId,int usuarioId,
             ERPProdEntities oContext
            )
        {
            int err = 0;
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                using (oContext = new ERPProdEntities())
                {
                    using (var dbContextTransaction = oContext.Database.BeginTransaction())
                    {
                        
                        try
                        {
                            foreach (doc_inventario_registro itemDato in datos)
                            {
                                if(itemDato.RegistroInventarioId == 0)
                                {
                                    doc_inventario_registro entityNew = new doc_inventario_registro();

                                    entityNew.CantidadReal = itemDato.CantidadReal;
                                    entityNew.CantidadTeorica = itemDato.CantidadTeorica;
                                    entityNew.CreadoEl = DateTime.Now;
                                    entityNew.CreadoPor = usuarioId;
                                    entityNew.Diferencia = entityNew.CantidadReal - entityNew.CantidadTeorica;
                                    entityNew.ProductoId = itemDato.ProductoId;
                                    entityNew.SucursalId = sucursalId;
                                    entityNew.RegistroInventarioId = (oContext.doc_inventario_registro.Max(m => (int?)m.RegistroInventarioId) ?? 0) + 1;

                                    oContext.doc_inventario_registro.Add(entityNew);
                                    oContext.SaveChanges();


                                    SisBitacoraBusiness.GuardaBitacoraGeneral(sucursalId, entityNew, usuarioId);


                                }
                                //else
                                //{
                                //    doc_inventario_registro entityUpd = oContext.doc_inventario_registro
                                //        .Where(w => w.RegistroInventarioId == itemDato.RegistroInventarioId).FirstOrDefault();

                                //    entityUpd.CantidadReal = itemDato.CantidadReal;
                                //    entityUpd.Diferencia = entityUpd.CantidadReal - entityUpd.CantidadTeorica;

                                //    oContext.SaveChanges();

                                //    SisBitacoraBusiness.GuardaBitacoraGeneral(sucursalId, entityUpd, usuarioId);

                                //}
                            }
                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {

                            dbContextTransaction.Rollback();
                            err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                   "ERP",
                                   "InventarioBusiness.GuardarInventarioReal",
                                   ex);

                            result.error = ConstantesBusiness.messageErrorBitacora.Replace("{id}", err.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                 err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                   "ERP",
                                   "InventarioBusiness.GuardarInventarioReal",
                                   ex);

                result.error = ConstantesBusiness.messageErrorBitacora.Replace("{id}", err.ToString());

            }

            return result;
        }

        public ResultAPIModel GuardarAceptacionSucursal(
            List<ERP.Models.Inventario.AceptacionSucursalGrdModel> lstAceptacion,
            int usuarioId,
            int sucursalId)
        {
            result = new ResultAPIModel();
            
            try
            {
                using (oContext = new ERPProdEntities())
                {
                    using (var dbContextTransaction = oContext.Database.BeginTransaction())
                    {
                        try
                        {
                            doc_aceptaciones_sucursal entityAceptacion = new doc_aceptaciones_sucursal();
                            entityAceptacion.AceptadoPor = usuarioId;
                            entityAceptacion.Fecha = DateTime.Now;
                            entityAceptacion.MovimientoId = lstAceptacion[0].movimientoId;
                            entityAceptacion.SucursalId = sucursalId;

                            oContext.doc_aceptaciones_sucursal.Add(entityAceptacion);
                            oContext.SaveChanges();
                            
                            foreach (var itemAceptacion in lstAceptacion)
                            {
                                doc_aceptaciones_sucursal_detalle entityAceptacionDetalle = new doc_aceptaciones_sucursal_detalle();

                                entityAceptacionDetalle.AceptacionSucursalId = entityAceptacion.Id;
                                entityAceptacionDetalle.CantidadReal = itemAceptacion.cantidadReal;
                                entityAceptacionDetalle.CreadoEl = DateTime.Now;
                                entityAceptacionDetalle.CreadoPor = usuarioId;
                                entityAceptacionDetalle.MovimientoDetalleId = itemAceptacion.movimientoDetalleId;
                                entityAceptacionDetalle.MovimientoDetalleAjusteId = itemAceptacion.movimientoDetalleId;
                                oContext.doc_aceptaciones_sucursal_detalle.Add(entityAceptacionDetalle);
                                oContext.SaveChanges();
                            }

                            List<doc_aceptaciones_sucursal_detalle> lstAceptacionDetalle = oContext.doc_aceptaciones_sucursal_detalle.Where(w => w.AceptacionSucursalId == entityAceptacion.Id &&
                            w.doc_inv_movimiento_detalle.Cantidad != w.CantidadReal
                            ).ToList();
                            
                            //Ajustes de Inventario

                            if (lstAceptacionDetalle.Count() > 0)
                            {
                                doc_inv_movimiento entityMov = new doc_inv_movimiento();

                                entityMov.Autorizado = true;
                                entityMov.AutorizadoPor = usuarioId;
                                entityMov.Comentarios = "AJUSTE DE INVENTARIO POR TRASPASO EN SUCURSAL";
                                entityMov.CreadoEl = DateTime.Now;
                                entityMov.CreadoPor = usuarioId;
                                entityMov.FechaMovimiento = DateTime.Now;
                                entityMov.SucursalId = sucursalId;
                                entityMov.TipoMovimientoId = (int)ERP.Business.Enumerados.tipoMovimientoInventario.AjustePorSalida;
                                
                                result = Guardar(ref entityMov, usuarioId, oContext);

                                if (!result.ok)
                                {
                                    dbContextTransaction.Rollback();
                                    return result;
                                }

                                foreach (doc_aceptaciones_sucursal_detalle itemAceptacionDetalle in lstAceptacionDetalle)
                                {
                                    doc_inv_movimiento_detalle entityMovDet = new doc_inv_movimiento_detalle();

                                    doc_inv_movimiento_detalle itemAceptacionDetalle2 = oContext.doc_inv_movimiento_detalle
                                        
                                        .Where(w => w.MovimientoDetalleId == itemAceptacionDetalle.MovimientoDetalleId).FirstOrDefault();

                                    entityMovDet.Cantidad = itemAceptacionDetalle2.Cantidad- itemAceptacionDetalle.CantidadReal;
                                    entityMovDet.CreadoEl = DateTime.Now;
                                    entityMovDet.CreadoPor = usuarioId;
                                    entityMovDet.MovimientoId = entityMov.MovimientoId;
                                    entityMovDet.ProductoId = itemAceptacionDetalle2.ProductoId;

                                    result = GuardarDetalle(ref entityMovDet, entityMov, usuarioId, oContext);

                                    if (!result.ok)
                                    {
                                        dbContextTransaction.Rollback();
                                        return result;
                                    }
                                }
                            }

                            
                           

                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                   "ERP",
                                   "InventarioBusiness.GuardarAceptacionSucursal",
                                   ex);

                            result.error = ConstantesBusiness.messageErrorBitacora.Replace("{id}", err.ToString());
                        }
                       
                    }
                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                   "ERP",
                                   "InventarioBusiness.GuardarAceptacionSucursal",
                                   ex);

                result.error = ConstantesBusiness.messageErrorBitacora.Replace("{id}", err.ToString());
            }
            return result;
        }

    }
}
