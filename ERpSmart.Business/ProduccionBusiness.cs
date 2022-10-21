using ConexionBD;
using ConexionBD.Models;
using ERP.Models;
using ERP.Models.Produccion;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static ERP.Business.Enumerados;

namespace ERP.Business
{
    public class ProduccionBusiness: BusinessObject
    {
        public static ResultAPIModel IniciarProduccion(
             ref doc_produccion entityProduccion,
            List<ProduccionSucProductoModel> lstEntradas,
            List<ProduccionSucProductoModel> lstSalidas,
            PuntoVentaContext puntoVentaContext
            )
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                ERPProdEntities oContext = new ERPProdEntities();
                cat_basculas_configuracion configBascula = null;
                if (lstEntradas.Where(w=> w.UsoBascula).Count() > 0)
                {
                    configBascula = ERP.Business.BasculasBusiness.GetConfiguracionPCLocal(puntoVentaContext.usuarioId, puntoVentaContext.sucursalId);
                    if (configBascula == null)
                    {
                        result.error = "No existe configuración de Báscula";
                        return result;
                    }
                }

                

                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        DateTime fechaAct = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                        #region encabezado
                        entityProduccion.EstatusProduccionId = (int)estatusProduccion.En_Produccion;
                        entityProduccion.Activo = true;
                        entityProduccion.FechaHoraInicio = fechaAct;
                        entityProduccion.CreadoEl = fechaAct;
                        entityProduccion.FechaHoraFin = null;
                        entityProduccion.CreadoPor = puntoVentaContext.usuarioId;
                        entityProduccion.SucursalId = puntoVentaContext.sucursalId;
                        entityProduccion.ProduccionId = (oContext.doc_produccion.Max(m => (int?)m.ProduccionId) ?? 0) + 1;
                        
                        oContext.doc_produccion.Add(entityProduccion);
                        oContext.SaveChanges();
                        #endregion

                        #region entradas
                        fechaAct = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                        foreach (ProduccionSucProductoModel itemEntrada in lstEntradas)
                        {
                            doc_produccion_entrada entityEntrada = new doc_produccion_entrada();

                            entityEntrada.Cantidad = itemEntrada.cantidad;
                            entityEntrada.CreadoEl = fechaAct;
                            entityEntrada.ProduccionId = entityProduccion.ProduccionId;
                            entityEntrada.ProductoId = itemEntrada.productoId;
                            entityEntrada.UnidadId = itemEntrada.unidadId;

                            oContext.doc_produccion_entrada.Add(entityEntrada);
                            oContext.SaveChanges();

                            if (itemEntrada.UsoBascula)
                            {
                                ERP.Business.BasculasBusiness.InsertBitacora(
                                    configBascula.BasculaId,
                                    puntoVentaContext.sucursalId,
                                    puntoVentaContext.usuarioId,
                                    itemEntrada.cantidad,
                                    (int)ERP.Business.Enumerados.tipoBasculaBitacora.InsumoProduccion,
                                    itemEntrada.productoId,    
                                    null,
                                    oContext);
                            }

                        }
                        #endregion

                        #region salidas
                        fechaAct = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                        foreach (ProduccionSucProductoModel itemSalida in lstSalidas)
                        {
                            doc_produccion_salida entitySalida = new doc_produccion_salida();

                            entitySalida.Cantidad = itemSalida.cantidad;
                            entitySalida.CreadoEl = fechaAct;
                            entitySalida.ProduccionId = entityProduccion.ProduccionId;
                            entitySalida.ProductoId = itemSalida.productoId;
                            entitySalida.UnidadId = itemSalida.unidadId;

                            oContext.doc_produccion_salida.Add(entitySalida);
                            oContext.SaveChanges();

                        }
                        #endregion

                        #region Inventario Encabezado
                        doc_inv_movimiento entityInvEnc = new doc_inv_movimiento();

                        entityInvEnc.Activo = true;
                        entityInvEnc.Autorizado = true;
                        entityInvEnc.AutorizadoPor = puntoVentaContext.usuarioId;
                        entityInvEnc.Cancelado = false;
                        entityInvEnc.Comentarios = "Insumo Producción ID:"+entityProduccion.ProduccionId.ToString();
                        entityInvEnc.Consecutivo = 0;
                        entityInvEnc.CreadoPor = puntoVentaContext.usuarioId;
                        entityInvEnc.FechaAutoriza = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                        entityInvEnc.FechaCancelacion = null;
                        entityInvEnc.FechaMovimiento = (DateTime)entityInvEnc.FechaAutoriza;
                        entityInvEnc.HoraMovimiento = entityInvEnc.FechaAutoriza.Value.TimeOfDay;
                        entityInvEnc.ImporteTotal = 0;
                        entityInvEnc.SucursalId = puntoVentaContext.sucursalId;
                        entityInvEnc.TipoMovimientoId = (int)ERP.Business.Enumerados.tipoMovimientoInventario.InsumoInternoProduccion;

                        result = ERP.Business.InventarioBusiness.Guardar(ref entityInvEnc, puntoVentaContext.usuarioId, oContext);

                        if (result.ok)
                        {
                            #region Inventario Detalle
                            foreach (ProduccionSucProductoModel itemEntrada in lstEntradas)
                            {
                                doc_inv_movimiento_detalle entityInvDetalle = new doc_inv_movimiento_detalle();

                                entityInvDetalle.Cantidad = itemEntrada.cantidad;
                                entityInvDetalle.Comisiones = 0;
                                entityInvDetalle.CreadoPor = puntoVentaContext.usuarioId;
                                entityInvDetalle.ProductoId = itemEntrada.productoId;

                                result = ERP.Business.InventarioBusiness
                                    .GuardarDetalle(ref entityInvDetalle, entityInvEnc,
                                    puntoVentaContext.usuarioId, oContext);

                                if (!result.ok)
                                {
                                    return result;
                                }
                                
                            }
                            #endregion
                        }
                        else{
                            return result;
                        }
                        #endregion
                        #region Bitácora
                        fechaAct = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                        sis_bitacora_general entityBitacora = new sis_bitacora_general();

                        entityBitacora.BitacoraId = (oContext.sis_bitacora_general
                            .Max(m => (int?)m.BitacoraId) ?? 0) + 1;
                        entityBitacora.CreadoEl = fechaAct;
                        entityBitacora.CreadoPor = puntoVentaContext.usuarioId;
                        entityBitacora.Detalle = "Se inicia Producción de producto ID:" +entityProduccion.ProduccionId.ToString();
                        entityBitacora.SucursalId = puntoVentaContext.sucursalId;

                        oContext.sis_bitacora_general.Add(entityBitacora);
                        oContext.SaveChanges();

                        doc_produccion_bitacora entityProduccionBitacora = new doc_produccion_bitacora();

                        entityProduccionBitacora.BitacoraId = entityBitacora.BitacoraId;
                        entityProduccionBitacora.CreadoEl = fechaAct;
                        entityProduccionBitacora.ProduccionId = entityProduccion.ProduccionId;

                        oContext.doc_produccion_bitacora.Add(entityProduccionBitacora);

                        oContext.SaveChanges();
                        #endregion

                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        entityProduccion.ProduccionId = 0;
                        scope.Dispose();

                        int err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                               "ERP",
                               "ERP.Business.ProduccionBusiness",
                               ex);

                        result.error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

                    }

                }
                
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                 "ERP",
                                 "ERP.Business.ProduccionBusiness",
                                 ex);

                result.error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
            }

            return result;
        }

        public static void RegistrarBitacora(int ProduccionId,string Detalle, int usuarioId,int sucursalId,
            ERPProdEntities oContext)
        {
            #region Bitácora
            DateTime fechaAct = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
            sis_bitacora_general entityBitacora = new sis_bitacora_general();

            entityBitacora.BitacoraId = (oContext.sis_bitacora_general
                .Max(m => (int?)m.BitacoraId) ?? 0) + 1;
            entityBitacora.CreadoEl = fechaAct;
            entityBitacora.CreadoPor = usuarioId;
            entityBitacora.Detalle = Detalle;
            entityBitacora.SucursalId = sucursalId;

            oContext.sis_bitacora_general.Add(entityBitacora);
            oContext.SaveChanges();

            doc_produccion_bitacora entityProduccionBitacora = new doc_produccion_bitacora();

            entityProduccionBitacora.BitacoraId = entityBitacora.BitacoraId;
            entityProduccionBitacora.CreadoEl = fechaAct;
            entityProduccionBitacora.ProduccionId = ProduccionId;

            oContext.doc_produccion_bitacora.Add(entityProduccionBitacora);

            oContext.SaveChanges();
            #endregion
        }

        public static ResultAPIModel TerminarProduccion(
             int ProduccionId,
            List<ProduccionSucProductoModel> lstEntradas,
            List<ProduccionSucProductoModel> lstSalidas,
            PuntoVentaContext puntoVentaContext
            )
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                cat_basculas_configuracion configBascula = null;

                if(lstSalidas.Where(w=> w.UsoBascula).Count() > 0)
                {
                    configBascula = ERP.Business.BasculasBusiness.GetConfiguracionPCLocal(puntoVentaContext.usuarioId, puntoVentaContext.sucursalId);

                    if (configBascula == null)
                    {
                        result.error = "No existe configuración de Báscula";
                        return result;
                    }

                }
                


                foreach (var item in lstSalidas)
                {
                    if(item.cantidad <= 0)
                    {
                        result.error = "El peso de salida debe de ser mayor a 0";
                        return result;
                    }
                }
                ERPProdEntities oContext = new ERPProdEntities();
                
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        doc_produccion entityProduccion = oContext.doc_produccion
                       .Where(w => w.ProduccionId == ProduccionId).FirstOrDefault();

                        if(entityProduccion != null)
                        {
                            
                            entityProduccion.FechaHoraFin = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                            entityProduccion.Completado = true;
                            entityProduccion.EstatusProduccionId = (int)ERP.Business.Enumerados.estatusProduccion.Produccion_Terminada;
                            oContext.SaveChanges();

                           
                            #region Bitácora
                            DateTime fechaAct = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                            sis_bitacora_general entityBitacora = new sis_bitacora_general();

                            entityBitacora.BitacoraId = (oContext.sis_bitacora_general
                                .Max(m => (int?)m.BitacoraId) ?? 0) + 1;
                            entityBitacora.CreadoEl = fechaAct;
                            entityBitacora.CreadoPor = puntoVentaContext.usuarioId;
                            entityBitacora.Detalle = "Se Termina Producción de producto ID:"+entityProduccion.ProductoId.ToString();
                            entityBitacora.SucursalId = puntoVentaContext.sucursalId;

                            oContext.sis_bitacora_general.Add(entityBitacora);
                            oContext.SaveChanges();

                            doc_produccion_bitacora entityProduccionBitacora = new doc_produccion_bitacora();

                            entityProduccionBitacora.BitacoraId = entityBitacora.BitacoraId;
                            entityProduccionBitacora.CreadoEl = fechaAct;
                            entityProduccionBitacora.ProduccionId = entityProduccion.ProduccionId;

                            oContext.doc_produccion_bitacora.Add(entityProduccionBitacora);

                            oContext.SaveChanges();
                            #endregion


                            scope.Complete();
                        }
                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();
                        int err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                                 "ERP",
                                                 "ERP.Business.ProduccionBusiness",
                                                 ex);

                        result.error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

                    }



                }


            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                                 "ERP",
                                                 "ERP.Business.ProduccionBusiness",
                                                 ex);

                result.error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

            }

            return result;
        }



        public static ResultAPIModel TerminarProduccion(
            int ProduccionId,    
            
           PuntoVentaContext puntoVentaContext
           )
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                               
                ERPProdEntities oContext = new ERPProdEntities();

                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        doc_produccion entityProduccion = oContext.doc_produccion
                       .Where(w => w.ProduccionId == ProduccionId).FirstOrDefault();

                        if (entityProduccion != null)
                        {

                            entityProduccion.FechaHoraFin = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                            entityProduccion.Completado = true;
                            entityProduccion.EstatusProduccionId = (int)ERP.Business.Enumerados.estatusProduccion.Produccion_Terminada;
                            oContext.SaveChanges();


                            #region Bitácora
                            DateTime fechaAct = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                            sis_bitacora_general entityBitacora = new sis_bitacora_general();

                            entityBitacora.BitacoraId = (oContext.sis_bitacora_general
                                .Max(m => (int?)m.BitacoraId) ?? 0) + 1;
                            entityBitacora.CreadoEl = fechaAct;
                            entityBitacora.CreadoPor = puntoVentaContext.usuarioId;
                            entityBitacora.Detalle = "Se Termina Producción de producto ID:" + entityProduccion.ProductoId.ToString();
                            entityBitacora.SucursalId = puntoVentaContext.sucursalId;

                            oContext.sis_bitacora_general.Add(entityBitacora);
                            oContext.SaveChanges();

                            doc_produccion_bitacora entityProduccionBitacora = new doc_produccion_bitacora();

                            entityProduccionBitacora.BitacoraId = entityBitacora.BitacoraId;
                            entityProduccionBitacora.CreadoEl = fechaAct;
                            entityProduccionBitacora.ProduccionId = entityProduccion.ProduccionId;

                            oContext.doc_produccion_bitacora.Add(entityProduccionBitacora);

                            oContext.SaveChanges();
                            #endregion


                            scope.Complete();
                        }
                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();
                        int err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                                 "ERP",
                                                 "ERP.Business.ProduccionBusiness",
                                                 ex);

                        result.error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

                    }



                }


            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                                 "ERP",
                                                 "ERP.Business.ProduccionBusiness",
                                                 ex);

                result.error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

            }

            return result;
        }


        public static ResultAPIModel TerminarCocimientoProduccion(

          int ProduccionId,
          decimal cocimientoAgua,
            decimal cocimientoGas1,
            decimal cocimientoGas2,
         PuntoVentaContext puntoVentaContext
         )
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {

                ERPProdEntities oContext = new ERPProdEntities();

                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        doc_produccion entityProduccion = oContext.doc_produccion
                       .Where(w => w.ProduccionId == ProduccionId).FirstOrDefault();

                        if (entityProduccion != null)
                        {

                            entityProduccion.FechaHoraFin = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                            entityProduccion.Completado = true;
                            entityProduccion.EstatusProduccionId = (int)ERP.Business.Enumerados.estatusProduccion.Produccion_Terminada;
                            oContext.SaveChanges();                                                        
                            
                            #region conceptos
                            List<cat_conceptos> lstConceptos = oContext.cat_conceptos.ToList();

                            if(lstConceptos.Count() == 0)
                            {
                                result.error = "No existe registro de conceptos";
                                return result;
                            }

                            doc_produccion_conceptos entityConcepto = new doc_produccion_conceptos();
                            entityConcepto.ProduccionConceptoId = (oContext.doc_produccion_conceptos
                                .Max(m => (int?)m.ProduccionConceptoId) ?? 0)+1;
                            entityConcepto.Cantidad = cocimientoAgua;
                            entityConcepto.ConceptoId = lstConceptos.Where(w => w.Descripcion.ToUpper() == "AGUA").FirstOrDefault().ConceptoId;
                            entityConcepto.CreadoEl = DateTime.Now;
                            entityConcepto.CreadoPor = puntoVentaContext.usuarioId;
                            entityConcepto.ProduccionId = entityProduccion.ProduccionId;

                            oContext.doc_produccion_conceptos.Add(entityConcepto);
                            oContext.SaveChanges();


                            entityConcepto = new doc_produccion_conceptos();
                            entityConcepto.ValorRango1_1 = (double)cocimientoGas1;
                            entityConcepto.ValorRango1_2 = (double)cocimientoGas2;
                            entityConcepto.ProduccionConceptoId = (oContext.doc_produccion_conceptos
                               .Max(m => (int?)m.ProduccionConceptoId) ?? 0) + 1;
                            entityConcepto.ConceptoId = lstConceptos.Where(w => w.Descripcion.ToUpper() == "GAS").FirstOrDefault().ConceptoId;
                            entityConcepto.CreadoEl = DateTime.Now;
                            entityConcepto.CreadoPor = puntoVentaContext.usuarioId;
                            entityConcepto.ProduccionId = entityProduccion.ProduccionId;

                            oContext.doc_produccion_conceptos.Add(entityConcepto);
                            oContext.SaveChanges();

                            #endregion

                            doc_cocimientos entityCocimiento = oContext.doc_cocimientos
                                .Where(w => w.ProduccionId == entityProduccion.ProduccionId).FirstOrDefault();

                            entityCocimiento.FechaHoraFin = DateTime.Now;
                            oContext.SaveChanges();

                            #region Bitácora
                            DateTime fechaAct = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                            sis_bitacora_general entityBitacora = new sis_bitacora_general();

                            entityBitacora.BitacoraId = (oContext.sis_bitacora_general
                                .Max(m => (int?)m.BitacoraId) ?? 0) + 1;
                            entityBitacora.CreadoEl = fechaAct;
                            entityBitacora.CreadoPor = puntoVentaContext.usuarioId;
                            entityBitacora.Detalle = "Se Termina Producción de producto ID:" + entityProduccion.ProductoId.ToString();
                            entityBitacora.SucursalId = puntoVentaContext.sucursalId;

                            oContext.sis_bitacora_general.Add(entityBitacora);
                            oContext.SaveChanges();

                            doc_produccion_bitacora entityProduccionBitacora = new doc_produccion_bitacora();

                            entityProduccionBitacora.BitacoraId = entityBitacora.BitacoraId;
                            entityProduccionBitacora.CreadoEl = fechaAct;
                            entityProduccionBitacora.ProduccionId = entityProduccion.ProduccionId;

                            oContext.doc_produccion_bitacora.Add(entityProduccionBitacora);

                            oContext.SaveChanges();
                            #endregion


                            scope.Complete();
                        }
                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();
                        int err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                                 "ERP",
                                                 "ERP.Business.ProduccionBusiness",
                                                 ex);

                        result.error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

                    }



                }


            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                                 "ERP",
                                                 "ERP.Business.ProduccionBusiness",
                                                 ex);

                result.error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

            }

            return result;
        }

        public static ResultAPIModel AgregarSalida(ref doc_produccion_salida entity,
            bool usoBascula,
            int usuarioId,
            int sucursalId)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                ERPProdEntities oContext = new ERPProdEntities();
                using (TransactionScope scope = new TransactionScope())
                {
                    entity.CreadoEl = DateTime.Now;
                    oContext.doc_produccion_salida.Add(entity);
                    oContext.SaveChanges();


                    #region Inventario Encabezado
                    doc_inv_movimiento entityInvEnc = new doc_inv_movimiento();

                    entityInvEnc.Activo = true;
                    entityInvEnc.Autorizado = true;
                    entityInvEnc.AutorizadoPor = usuarioId;
                    entityInvEnc.Cancelado = false;
                    entityInvEnc.Comentarios = "Producto  Producción";
                    entityInvEnc.Consecutivo = 0;
                    entityInvEnc.CreadoPor = usuarioId;
                    entityInvEnc.FechaAutoriza = DateTime.Now;
                    entityInvEnc.FechaCancelacion = null;
                    entityInvEnc.FechaMovimiento = (DateTime)entityInvEnc.FechaAutoriza;
                    entityInvEnc.HoraMovimiento = entityInvEnc.FechaAutoriza.Value.TimeOfDay;
                    entityInvEnc.ImporteTotal = 0;
                    entityInvEnc.SucursalId = sucursalId;
                    entityInvEnc.TipoMovimientoId = (int)ERP.Business.Enumerados.tipoMovimientoInventario.ProductoProduccion;

                    result = ERP.Business.InventarioBusiness.Guardar(ref entityInvEnc, usuarioId, oContext);

                    if (result.ok)
                    {
                        #region Inventario Detalle
                        
                            doc_inv_movimiento_detalle entityInvDetalle = new doc_inv_movimiento_detalle();

                            entityInvDetalle.Cantidad = entity.Cantidad;
                            entityInvDetalle.Comisiones = 0;
                            entityInvDetalle.CreadoPor = usuarioId;
                            entityInvDetalle.ProductoId = entity.ProductoId;

                            result = ERP.Business.InventarioBusiness
                                .GuardarDetalle(ref entityInvDetalle, entityInvEnc,
                                usuarioId, oContext);

                            if (!result.ok)
                            {
                                return result;
                            }

                        
                        #endregion
                    }
                    else
                    {
                        return result;
                    }

                    doc_produccion_movs_inventario entityProduccionMovs = new doc_produccion_movs_inventario();

                    entityProduccionMovs.ProduccionId = entity.ProduccionId;
                    entityProduccionMovs.CreadoEl = DateTime.Now;
                    entityProduccionMovs.MovimientoInventarioId = entityInvEnc.MovimientoId;
                    oContext.doc_produccion_movs_inventario.Add(entityProduccionMovs);
                    oContext.SaveChanges();
                    #endregion

                    cat_basculas_configuracion configBascula = null;

                    if (usoBascula)
                    {
                        configBascula = ERP.Business.BasculasBusiness.GetConfiguracionPCLocal(usuarioId, sucursalId);

                        if (configBascula == null)
                        {
                            result.error = "No existe configuración de Báscula";
                            return result;
                        }
                        ERP.Business.BasculasBusiness.InsertBitacora(
                            configBascula.BasculaId,
                            sucursalId,
                            usuarioId,
                            entity.Cantidad ?? 0,
                            (int)ERP.Business.Enumerados.tipoBasculaBitacora.SalidaDeProduccion,
                            entity.ProductoId,
                            null,
                            oContext);
                    }

                    //RegistrarBitacora(entity.ProduccionId,
                    //                   String.Format("Se actualizó peso [produccionId]:{0} [productoId]:{1} [Peso]:{2}",entity.ProductoId, entity.ProductoId, entity.Cantidad),
                    //                   usuarioId,
                    //                   sucursalId,
                    //                   oContext);

                   

                    scope.Complete();
                }
                
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                                 "ERP",
                                                 "ERP.Business.ProduccionBusiness",
                                                 ex);

                result.error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

            }

            return result;
        }


        public static ResultAPIModel AgregarEntrada(ref doc_produccion_entrada entity,
          bool usoBascula,
          int usuarioId,
          int sucursalId)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                ERPProdEntities oContext = new ERPProdEntities();
                using (TransactionScope scope = new TransactionScope())
                {
                    entity.CreadoEl = DateTime.Now;
                    oContext.doc_produccion_entrada.Add(entity);
                    oContext.SaveChanges();


                    #region Inventario Encabezado
                    doc_inv_movimiento entityInvEnc = new doc_inv_movimiento();

                    entityInvEnc.Activo = true;
                    entityInvEnc.Autorizado = true;
                    entityInvEnc.AutorizadoPor = usuarioId;
                    entityInvEnc.Cancelado = false;
                    entityInvEnc.Comentarios = "Insumo Producción";
                    entityInvEnc.Consecutivo = 0;
                    entityInvEnc.CreadoPor = usuarioId;
                    entityInvEnc.FechaAutoriza = DateTime.Now;
                    entityInvEnc.FechaCancelacion = null;
                    entityInvEnc.FechaMovimiento = (DateTime)entityInvEnc.FechaAutoriza;
                    entityInvEnc.HoraMovimiento = entityInvEnc.FechaAutoriza.Value.TimeOfDay;
                    entityInvEnc.ImporteTotal = 0;
                    entityInvEnc.SucursalId = sucursalId;
                    entityInvEnc.TipoMovimientoId = (int)ERP.Business.Enumerados.tipoMovimientoInventario.InsumoInternoProduccion;

                    result = ERP.Business.InventarioBusiness.Guardar(ref entityInvEnc, usuarioId, oContext);

                    if (result.ok)
                    {
                        #region Inventario Detalle

                        doc_inv_movimiento_detalle entityInvDetalle = new doc_inv_movimiento_detalle();

                        entityInvDetalle.Cantidad = entity.Cantidad;
                        entityInvDetalle.Comisiones = 0;
                        entityInvDetalle.CreadoPor = usuarioId;
                        entityInvDetalle.ProductoId = entity.ProductoId;

                        result = ERP.Business.InventarioBusiness
                            .GuardarDetalle(ref entityInvDetalle, entityInvEnc,
                            usuarioId, oContext);

                        if (!result.ok)
                        {
                            return result;
                        }


                        #endregion
                    }
                    else
                    {
                        return result;
                    }

                    doc_produccion_movs_inventario entityProduccionMovs = new doc_produccion_movs_inventario();

                    entityProduccionMovs.ProduccionId = entity.ProduccionId;
                    entityProduccionMovs.CreadoEl = DateTime.Now;
                    entityProduccionMovs.MovimientoInventarioId = entityInvEnc.MovimientoId;
                    oContext.doc_produccion_movs_inventario.Add(entityProduccionMovs);
                    oContext.SaveChanges();
                    #endregion

                    cat_basculas_configuracion configBascula = null;

                    if (usoBascula)
                    {
                        configBascula = ERP.Business.BasculasBusiness.GetConfiguracionPCLocal(usuarioId, sucursalId);

                        if (configBascula == null)
                        {
                            result.error = "No existe configuración de Báscula";
                            return result;
                        }
                        ERP.Business.BasculasBusiness.InsertBitacora(
                            configBascula.BasculaId,
                            sucursalId,
                            usuarioId,
                            entity.Cantidad,
                            (int)ERP.Business.Enumerados.tipoBasculaBitacora.InsumoProduccion,
                            entity.ProductoId,
                            null,
                            oContext);
                    }

                    scope.Complete();
                }

            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                                 "ERP",
                                                 "ERP.Business.ProduccionBusiness",
                                                 ex);

                result.error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

            }

            return result;
        }

        public static ResultAPIModel Guardar(ref doc_produccion datos,int usuarioId)
        {
            ResultAPIModel result = new ResultAPIModel();
            doc_produccion entitySave;
            ERPProdEntities oContext = new ERPProdEntities();
            try
            {
                if(datos.ProduccionId == 0)
                {
                    entitySave = new doc_produccion();

                    entitySave.ProduccionId = (oContext.doc_produccion.Max(m => (int?)m.ProduccionId) ?? 0) + 1;
                    entitySave.Activo = true;
                    entitySave.Completado = false;
                    entitySave.CreadoEl = DateTime.Now;
                    entitySave.CreadoPor = datos.CreadoPor;
                    entitySave.EstatusProduccionId = datos.EstatusProduccionId;
                    entitySave.FechaHoraInicio = datos.FechaHoraInicio;
                    entitySave.ProductoId = datos.ProductoId;
                    entitySave.SucursalId = datos.SucursalId;

                    oContext.doc_produccion.Add(entitySave);
                    datos.ProduccionId = entitySave.ProduccionId;
                    RegistrarBitacora(entitySave.ProduccionId, "Registro de nueva producción", entitySave.CreadoPor,
                        entitySave.SucursalId, oContext);


                        
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                                 "ERP",
                                                 "ERP.Business.ProduccionBusiness",
                                                 ex);

                result.error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
            }

            return result;
        }

        public static ResultAPIModel EliminarDetalle(int id,bool salida,int usuarioId,int sucursalId)
        {
            ResultAPIModel result = new ResultAPIModel();
            ERPProdEntities oContext = new ERPProdEntities();
            try
            {
                if (salida)
                {
                    doc_produccion_salida entitySalida = oContext.doc_produccion_salida
                        .Where(w => w.Id == id).FirstOrDefault();

                    if (entitySalida != null)
                    {
                        oContext.doc_produccion_salida.Remove(entitySalida);
                        oContext.SaveChanges();
                        RegistrarBitacora(entitySalida.ProduccionId,
                            String.Format("Eliminación en Historial de Produccion ID-Historial[{0}] Producto[{1}] Cantidad[{2}] ", id.ToString(), entitySalida.cat_productos.DescripcionCorta, entitySalida.Cantidad),
                            usuarioId, sucursalId, oContext
                            );
                    }
                }
                else
                {
                    doc_produccion_entrada entityEntrada = oContext.doc_produccion_entrada
                       .Where(w => w.Id == id).FirstOrDefault();

                    if (entityEntrada != null)
                    {
                        RegistrarBitacora(entityEntrada.ProduccionId,
                           String.Format("Eliminación en Historial de Produccion ID-Historial[{0}] Producto[{1}] Cantidad[{2}] ", id.ToString(), entityEntrada.cat_productos.DescripcionCorta, entityEntrada.Cantidad),
                           usuarioId, sucursalId, oContext
                           );
                        oContext.doc_produccion_entrada.Remove(entityEntrada);
                        oContext.SaveChanges();
                       
                    }
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                                "ERP",
                                                "ERP.Business.ProduccionBusiness",
                                                ex);

                result.error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
            }

            return result;
        }

        #region Cocimiento
        public static ResultAPIModel IniciarCocimientoProduccion(
            int ProduccionId,           
           PuntoVentaContext puntoVentaContext
           )
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {

                ERPProdEntities oContext = new ERPProdEntities();

                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        doc_produccion entityProduccion = oContext.doc_produccion
                       .Where(w => w.ProduccionId == ProduccionId).FirstOrDefault();

                        if (entityProduccion != null)
                        {

                            doc_cocimientos entityCocimiento = new doc_cocimientos();

                            entityCocimiento.CocimientoId = (oContext.doc_cocimientos
                                .Max(m => (int?)m.CocimientoId) ?? 0) + 1;
                            entityCocimiento.CreadoEl = DateTime.Now;
                            entityCocimiento.CreadoPor = puntoVentaContext.usuarioId;
                            entityCocimiento.FechaCocimiento = DateTime.Now;
                            entityCocimiento.FechaHabilitado = null;
                            entityCocimiento.ProduccionId = entityProduccion.ProduccionId;
                            entityCocimiento.ProductoId = entityProduccion.ProductoId??0;
                            entityCocimiento.FechaHoraIni = DateTime.Now;
                            oContext.doc_cocimientos.Add(entityCocimiento);
                            oContext.SaveChanges();                           


                            #region Bitácora
                            DateTime fechaAct = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                            sis_bitacora_general entityBitacora = new sis_bitacora_general();

                            entityBitacora.BitacoraId = (oContext.sis_bitacora_general
                                .Max(m => (int?)m.BitacoraId) ?? 0) + 1;
                            entityBitacora.CreadoEl = fechaAct;
                            entityBitacora.CreadoPor = puntoVentaContext.usuarioId;
                            entityBitacora.Detalle = "Se Inicoa Cocimiento ID:" + entityCocimiento.CocimientoId.ToString();
                            entityBitacora.SucursalId = puntoVentaContext.sucursalId;

                            oContext.sis_bitacora_general.Add(entityBitacora);
                            oContext.SaveChanges();

                            doc_produccion_bitacora entityProduccionBitacora = new doc_produccion_bitacora();

                            entityProduccionBitacora.BitacoraId = entityBitacora.BitacoraId;
                            entityProduccionBitacora.CreadoEl = fechaAct;
                            entityProduccionBitacora.ProduccionId = entityProduccion.ProduccionId;

                            oContext.doc_produccion_bitacora.Add(entityProduccionBitacora);

                            oContext.SaveChanges();
                            #endregion


                            scope.Complete();
                        }
                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();
                        int err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                                 "ERP",
                                                 "ERP.Business.ProduccionBusiness",
                                                 ex);

                        result.error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

                    }



                }


            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                                 "ERP",
                                                 "ERP.Business.ProduccionBusiness",
                                                 ex);

                result.error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

            }

            return result;
        }

        public static ResultAPIModel HabilitarCocimientos(int sucursalId,int usuarioId)
        {
            ERPProdEntities oContext = new ERPProdEntities();
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                oContext.p_doc_cocimiento_habilitar(sucursalId);

                int productoSobranteId = oContext.cat_productos
                    .Where(w => w.Descripcion.Contains("NIXTAMAL") && w.Descripcion.Contains("SOBRANTE")).FirstOrDefault().ProductoId;

            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                                 "ERP",
                                                 "ERP.Business.HabilitarCocimientos",
                                                 ex);

                result.error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
            }

            return result;
        }
        #endregion

        #region nixtamal
        public static ResultAPIModel GuardarNixtamalSucio( 
          decimal cantidad,
         int usuarioId,
         int sucursalId)
        {
            ResultAPIModel result = new ResultAPIModel();
            cat_productos nixtamalSucioProd ;
            ERPProdEntities oContext = new ERPProdEntities();
            doc_inv_movimiento entityInventarioMovimiento = new doc_inv_movimiento();
            doc_inv_movimiento_detalle entityInventarioMovimientoDetalle = new doc_inv_movimiento_detalle();
            List<int> lstMvsInventario = new List<int>();
            doc_cocimientos_grupos_movs_inventario cocimientoGrupoMovs=null;
            try
            {
               

                doc_cocimientos_grupos cocimientoGrupo = oContext.doc_cocimientos_grupos
                    .Where(w => w.SucursalId == sucursalId && 
                    DbFunctions.TruncateTime(w.CreadoEl) < DbFunctions.TruncateTime(DateTime.Now)
                    ).OrderByDescending(o=> o.Id).FirstOrDefault();

                if (cocimientoGrupo == null)
                {
                    result.error = "No fue posible encontrar un grupo de cocimiento";
                    return result;
                }

                using (TransactionScope scope = new TransactionScope())
                {

                    nixtamalSucioProd = oContext.cat_productos
                        .Where(w => w.Descripcion.ToUpper().Contains("NIXTAMAL") &&
                        w.Descripcion.ToUpper().Contains("SUCIO")).FirstOrDefault();

                    if(nixtamalSucioProd != null)
                    {
                        //Guardar Movimiento de Inventario
                        entityInventarioMovimiento.Activo = true;
                        entityInventarioMovimiento.Autorizado = true;
                        entityInventarioMovimiento.AutorizadoPor = usuarioId;
                        entityInventarioMovimiento.Cancelado = false;
                        entityInventarioMovimiento.Comentarios = "ENTRADA DE NIXTAMAL SUCIO EN PANTALLA DE PRODUCCIÓN";
                        entityInventarioMovimiento.CreadoEl = DateTime.Now;
                        entityInventarioMovimiento.CreadoPor = usuarioId;
                        entityInventarioMovimiento.FechaAutoriza = DateTime.Now;
                        entityInventarioMovimiento.FechaCancelacion = null;
                        entityInventarioMovimiento.FechaMovimiento = DateTime.Now;
                        entityInventarioMovimiento.HoraMovimiento = DateTime.Now.TimeOfDay;
                        entityInventarioMovimiento.ImporteTotal = 0;
                        entityInventarioMovimiento.SucursalId = sucursalId;
                        entityInventarioMovimiento.TipoMovimientoId = (int)Enumerados.tipoMovimientoInventario.EntradaDirecta;

                        //Guardar ENTRADA NIXTAMAL SUCIO
                        result = InventarioBusiness.Guardar(ref entityInventarioMovimiento, usuarioId, oContext);
                        lstMvsInventario.Add(entityInventarioMovimiento.MovimientoId);
                        if (result.ok)
                        {
                            entityInventarioMovimientoDetalle.Cantidad = cantidad;
                            entityInventarioMovimientoDetalle.Comisiones = 0;
                            entityInventarioMovimientoDetalle.CreadoEl = DateTime.Now;
                            entityInventarioMovimientoDetalle.CreadoPor = usuarioId;
                            entityInventarioMovimientoDetalle.Flete = 0;
                            entityInventarioMovimientoDetalle.Importe = 0;
                            entityInventarioMovimientoDetalle.MovimientoId = entityInventarioMovimiento.MovimientoId;
                            entityInventarioMovimientoDetalle.PrecioNeto = 0;
                            entityInventarioMovimientoDetalle.PrecioUnitario = 0;
                            entityInventarioMovimientoDetalle.ProductoId = nixtamalSucioProd.ProductoId;
                            entityInventarioMovimientoDetalle.SubTotal = 0;

                            result = InventarioBusiness.GuardarDetalle(ref entityInventarioMovimientoDetalle, entityInventarioMovimiento, usuarioId, oContext);

                            if (result.ok)
                            {
                                //GUARDAR SALIDA NIXTAMAL SUCIO
                                entityInventarioMovimiento = new doc_inv_movimiento();
                                entityInventarioMovimiento.Activo = true;
                                entityInventarioMovimiento.Autorizado = true;
                                entityInventarioMovimiento.AutorizadoPor = usuarioId;
                                entityInventarioMovimiento.Cancelado = false;
                                entityInventarioMovimiento.Comentarios = "SALLIDA DE NIXTAMAL SUCIO EN PANTALLA DE PRODUCCIÓN";
                                entityInventarioMovimiento.CreadoEl = DateTime.Now;
                                entityInventarioMovimiento.CreadoPor = usuarioId;
                                entityInventarioMovimiento.FechaAutoriza = DateTime.Now;
                                entityInventarioMovimiento.FechaCancelacion = null;
                                entityInventarioMovimiento.FechaMovimiento = DateTime.Now;
                                entityInventarioMovimiento.HoraMovimiento = DateTime.Now.TimeOfDay;
                                entityInventarioMovimiento.ImporteTotal = 0;
                                entityInventarioMovimiento.SucursalId = sucursalId;
                                entityInventarioMovimiento.TipoMovimientoId = (int)Enumerados.tipoMovimientoInventario.AjustePorSalida;

                                result = InventarioBusiness.Guardar(ref entityInventarioMovimiento, usuarioId, oContext);
                                lstMvsInventario.Add(entityInventarioMovimiento.MovimientoId);
                                if (result.ok)
                                {
                                    entityInventarioMovimientoDetalle.Cantidad = cantidad;
                                    entityInventarioMovimientoDetalle.Comisiones = 0;
                                    entityInventarioMovimientoDetalle.CreadoEl = DateTime.Now;
                                    entityInventarioMovimientoDetalle.CreadoPor = usuarioId;
                                    entityInventarioMovimientoDetalle.Flete = 0;
                                    entityInventarioMovimientoDetalle.Importe = 0;
                                    entityInventarioMovimientoDetalle.MovimientoId = entityInventarioMovimiento.MovimientoId;
                                    entityInventarioMovimientoDetalle.PrecioNeto = 0;
                                    entityInventarioMovimientoDetalle.PrecioUnitario = 0;
                                    entityInventarioMovimientoDetalle.ProductoId = nixtamalSucioProd.ProductoId;
                                    entityInventarioMovimientoDetalle.SubTotal = 0;

                                    result = InventarioBusiness.GuardarDetalle(ref entityInventarioMovimientoDetalle, entityInventarioMovimiento, usuarioId, oContext);

                                    //Relacion Grupo de Comiento con Movimiento de Inventario
                                    foreach (int itemMov in lstMvsInventario)
                                    {
                                        cocimientoGrupoMovs = new doc_cocimientos_grupos_movs_inventario();

                                        cocimientoGrupoMovs.CocimientoGrupoId = cocimientoGrupo.Id;
                                        cocimientoGrupoMovs.CreadoEl = DateTime.Now;
                                        cocimientoGrupoMovs.MovimientoInventarioId = itemMov;

                                        oContext.doc_cocimientos_grupos_movs_inventario.Add(cocimientoGrupoMovs);
                                        oContext.SaveChanges();
                                    }

                                }
                            }


                        }
                        else
                        {
                            scope.Dispose();
                            return result;
                        }

                    }
                    else
                    {
                        result.error = "No se encontró el producto NIXTAMAL SUCIO";
                    }

                    scope.Complete();
                }

            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                                 "ERP",
                                                 "ERP.Business.GuardarNixtamalSucio",
                                                 ex);

                result.error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

            }

            return result;
        }


        public static ResultAPIModel GuardarNixtamalSucio(ref doc_produccion_entrada entity,
        ref doc_produccion_salida entitySalida,
        bool usoBascula,
        int usuarioId,
        int sucursalId,
        bool sobrante)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                ERPProdEntities oContext = new ERPProdEntities();

                doc_cocimientos_grupos cocimientoGrupo = oContext.doc_cocimientos_grupos
                    .Where(w => w.SucursalId == sucursalId 
                    
                    ).OrderByDescending(o => o.Id).FirstOrDefault();

                if (cocimientoGrupo == null)
                {
                    result.error = "No fue posible encontrar un grupo de cocimiento";
                    return result;
                }

                using (TransactionScope scope = new TransactionScope())
                {
                    //ENTRADA
                    entity.ProductoId = oContext.cat_productos
                          .Where(w => w.Descripcion.Contains("NIXTAMAL") && w.Descripcion.Contains("SUCIO")).FirstOrDefault().ProductoId;
                    entity.CreadoEl = DateTime.Now;
                    oContext.doc_produccion_entrada.Add(entity);
                    oContext.SaveChanges();


                    #region Inventario Encabezado
                    doc_inv_movimiento entityInvEnc = new doc_inv_movimiento();

                    entityInvEnc.Activo = true;
                    entityInvEnc.Autorizado = true;
                    entityInvEnc.AutorizadoPor = usuarioId;
                    entityInvEnc.Cancelado = false;
                    entityInvEnc.Comentarios = "Insumo Producción";
                    entityInvEnc.Consecutivo = 0;
                    entityInvEnc.CreadoPor = usuarioId;
                    entityInvEnc.FechaAutoriza = DateTime.Now;
                    entityInvEnc.FechaCancelacion = null;
                    entityInvEnc.FechaMovimiento = (DateTime)entityInvEnc.FechaAutoriza;
                    entityInvEnc.HoraMovimiento = entityInvEnc.FechaAutoriza.Value.TimeOfDay;
                    entityInvEnc.ImporteTotal = 0;
                    entityInvEnc.SucursalId = sucursalId;
                    entityInvEnc.TipoMovimientoId = (int)ERP.Business.Enumerados.tipoMovimientoInventario.InsumoInternoProduccion;

                    result = ERP.Business.InventarioBusiness.Guardar(ref entityInvEnc, usuarioId, oContext);

                    //Relación cocimiento - inventario
                    doc_cocimientos_grupos_movs_inventario cocimientoGrupoMovs = new doc_cocimientos_grupos_movs_inventario();

                    cocimientoGrupoMovs.CocimientoGrupoId = cocimientoGrupo.Id;
                    cocimientoGrupoMovs.CreadoEl = DateTime.Now;
                    cocimientoGrupoMovs.MovimientoInventarioId = entityInvEnc.MovimientoId;

                    oContext.doc_cocimientos_grupos_movs_inventario.Add(cocimientoGrupoMovs);
                    oContext.SaveChanges();


                    if (result.ok)
                    {
                        #region Inventario Detalle

                        doc_inv_movimiento_detalle entityInvDetalle = new doc_inv_movimiento_detalle();

                        entityInvDetalle.Cantidad = entity.Cantidad;
                        entityInvDetalle.Comisiones = 0;
                        entityInvDetalle.CreadoPor = usuarioId;
                        entityInvDetalle.ProductoId = entity.ProductoId;

                        result = ERP.Business.InventarioBusiness
                            .GuardarDetalle(ref entityInvDetalle, entityInvEnc,
                            usuarioId, oContext);

                        if (!result.ok)
                        {
                            return result;
                        }


                        #endregion
                    }
                    else
                    {
                        return result;
                    }

                    doc_produccion_movs_inventario entityProduccionMovs = new doc_produccion_movs_inventario();

                    entityProduccionMovs.ProduccionId = entity.ProduccionId;
                    entityProduccionMovs.CreadoEl = DateTime.Now;
                    entityProduccionMovs.MovimientoInventarioId = entityInvEnc.MovimientoId;
                    oContext.doc_produccion_movs_inventario.Add(entityProduccionMovs);
                    oContext.SaveChanges();
                    #endregion

                    cat_basculas_configuracion configBascula = null;

                    if (usoBascula)
                    {
                        configBascula = ERP.Business.BasculasBusiness.GetConfiguracionPCLocal(usuarioId, sucursalId);

                        if (configBascula == null)
                        {
                            result.error = "No existe configuración de Báscula";
                            return result;
                        }
                        ERP.Business.BasculasBusiness.InsertBitacora(
                            configBascula.BasculaId,
                            sucursalId,
                            usuarioId,
                            entity.Cantidad,
                            (int)ERP.Business.Enumerados.tipoBasculaBitacora.InsumoProduccion,
                            entity.ProductoId,
                            null,
                            oContext);
                    }


                    //SALIDA
                    entitySalida.ProductoId = oContext.cat_productos
                          .Where(w => w.Descripcion.Contains("NIXTAMAL") && w.Descripcion.Contains("SUCIO")).FirstOrDefault().ProductoId;

                    entitySalida.CreadoEl = DateTime.Now;
                    oContext.doc_produccion_salida.Add(entitySalida);
                    oContext.SaveChanges();


                    #region Inventario Encabezado
                    entityInvEnc = new doc_inv_movimiento();

                    entityInvEnc.Activo = true;
                    entityInvEnc.Autorizado = true;
                    entityInvEnc.AutorizadoPor = usuarioId;
                    entityInvEnc.Cancelado = false;
                    entityInvEnc.Comentarios = "Producto  Producción";
                    entityInvEnc.Consecutivo = 0;
                    entityInvEnc.CreadoPor = usuarioId;
                    entityInvEnc.FechaAutoriza = DateTime.Now;
                    entityInvEnc.FechaCancelacion = null;
                    entityInvEnc.FechaMovimiento = (DateTime)entityInvEnc.FechaAutoriza;
                    entityInvEnc.HoraMovimiento = entityInvEnc.FechaAutoriza.Value.TimeOfDay;
                    entityInvEnc.ImporteTotal = 0;
                    entityInvEnc.SucursalId = sucursalId;
                    entityInvEnc.TipoMovimientoId = (int)ERP.Business.Enumerados.tipoMovimientoInventario.ProductoProduccion;

                    result = ERP.Business.InventarioBusiness.Guardar(ref entityInvEnc, usuarioId, oContext);
                    //Relación cocimiento - inventario
                    cocimientoGrupoMovs = new doc_cocimientos_grupos_movs_inventario();

                    cocimientoGrupoMovs.CocimientoGrupoId = cocimientoGrupo.Id;
                    cocimientoGrupoMovs.CreadoEl = DateTime.Now;
                    cocimientoGrupoMovs.MovimientoInventarioId = entityInvEnc.MovimientoId;

                    oContext.doc_cocimientos_grupos_movs_inventario.Add(cocimientoGrupoMovs);
                    oContext.SaveChanges();
                    //
                    if (result.ok)
                    {
                        #region Inventario Detalle

                        doc_inv_movimiento_detalle entityInvDetalle = new doc_inv_movimiento_detalle();

                        entityInvDetalle.Cantidad = entity.Cantidad;
                        entityInvDetalle.Comisiones = 0;
                        entityInvDetalle.CreadoPor = usuarioId;
                        entityInvDetalle.ProductoId = entitySalida.ProductoId;

                        result = ERP.Business.InventarioBusiness
                            .GuardarDetalle(ref entityInvDetalle, entityInvEnc,
                            usuarioId, oContext);

                        if (!result.ok)
                        {
                            return result;
                        }


                        #endregion
                    }
                    else
                    {
                        return result;
                    }

                    entityProduccionMovs = new doc_produccion_movs_inventario();

                    entityProduccionMovs.ProduccionId = entity.ProduccionId;
                    entityProduccionMovs.CreadoEl = DateTime.Now;
                    entityProduccionMovs.MovimientoInventarioId = entityInvEnc.MovimientoId;
                    oContext.doc_produccion_movs_inventario.Add(entityProduccionMovs);
                    oContext.SaveChanges();
                    #endregion

                    configBascula = null;

                    if (usoBascula)
                    {
                        configBascula = ERP.Business.BasculasBusiness.GetConfiguracionPCLocal(usuarioId, sucursalId);

                        if (configBascula == null)
                        {
                            result.error = "No existe configuración de Báscula";
                            return result;
                        }
                        ERP.Business.BasculasBusiness.InsertBitacora(
                            configBascula.BasculaId,
                            sucursalId,
                            usuarioId,
                            entitySalida.Cantidad ?? 0,
                            (int)ERP.Business.Enumerados.tipoBasculaBitacora.SalidaDeProduccion,
                            entity.ProductoId,
                            null,
                            oContext);
                    }

                    if (sobrante)
                    {
                        //SOBRANTE
                        entitySalida = new doc_produccion_salida();
                        entitySalida.Cantidad = entity.Cantidad;
                        entitySalida.ProduccionId = entity.ProduccionId;
                        entitySalida.ProductoId = oContext.cat_productos
                            .Where(w => w.Descripcion.Contains("NIXTAMAL") && w.Descripcion.Contains("SOBRANTE")).FirstOrDefault().ProductoId;
                        entitySalida.CreadoEl = DateTime.Now;
                        oContext.doc_produccion_salida.Add(entitySalida);
                        oContext.SaveChanges();


                        #region Inventario Encabezado
                        entityInvEnc = new doc_inv_movimiento();

                        entityInvEnc.Activo = true;
                        entityInvEnc.Autorizado = true;
                        entityInvEnc.AutorizadoPor = usuarioId;
                        entityInvEnc.Cancelado = false;
                        entityInvEnc.Comentarios = "Producto  Producción";
                        entityInvEnc.Consecutivo = 0;
                        entityInvEnc.CreadoPor = usuarioId;
                        entityInvEnc.FechaAutoriza = DateTime.Now;
                        entityInvEnc.FechaCancelacion = null;
                        entityInvEnc.FechaMovimiento = (DateTime)entityInvEnc.FechaAutoriza;
                        entityInvEnc.HoraMovimiento = entityInvEnc.FechaAutoriza.Value.TimeOfDay;
                        entityInvEnc.ImporteTotal = 0;
                        entityInvEnc.SucursalId = sucursalId;
                        entityInvEnc.TipoMovimientoId = (int)ERP.Business.Enumerados.tipoMovimientoInventario.ProductoProduccion;

                        result = ERP.Business.InventarioBusiness.Guardar(ref entityInvEnc, usuarioId, oContext);
                        //Relación cocimiento - inventario
                        cocimientoGrupoMovs = new doc_cocimientos_grupos_movs_inventario();

                        cocimientoGrupoMovs.CocimientoGrupoId = cocimientoGrupo.Id;
                        cocimientoGrupoMovs.CreadoEl = DateTime.Now;
                        cocimientoGrupoMovs.MovimientoInventarioId = entityInvEnc.MovimientoId;

                        oContext.doc_cocimientos_grupos_movs_inventario.Add(cocimientoGrupoMovs);
                        oContext.SaveChanges();
                        //
                        if (result.ok)
                        {
                            #region Inventario Detalle

                            doc_inv_movimiento_detalle entityInvDetalle = new doc_inv_movimiento_detalle();

                            entityInvDetalle.Cantidad = entity.Cantidad;
                            entityInvDetalle.Comisiones = 0;
                            entityInvDetalle.CreadoPor = usuarioId;
                            entityInvDetalle.ProductoId = entitySalida.ProductoId;

                            result = ERP.Business.InventarioBusiness
                                .GuardarDetalle(ref entityInvDetalle, entityInvEnc,
                                usuarioId, oContext);

                            if (!result.ok)
                            {
                                return result;
                            }


                            #endregion
                        }
                        else
                        {
                            return result;
                        }

                        entityProduccionMovs = new doc_produccion_movs_inventario();

                        entityProduccionMovs.ProduccionId = entity.ProduccionId;
                        entityProduccionMovs.CreadoEl = DateTime.Now;
                        entityProduccionMovs.MovimientoInventarioId = entityInvEnc.MovimientoId;
                        oContext.doc_produccion_movs_inventario.Add(entityProduccionMovs);
                        oContext.SaveChanges();
                        #endregion

                        configBascula = null;

                        if (usoBascula)
                        {
                            configBascula = ERP.Business.BasculasBusiness.GetConfiguracionPCLocal(usuarioId, sucursalId);

                            if (configBascula == null)
                            {
                                result.error = "No existe configuración de Báscula";
                                return result;
                            }
                            ERP.Business.BasculasBusiness.InsertBitacora(
                                configBascula.BasculaId,
                                sucursalId,
                                usuarioId,
                                entitySalida.Cantidad ?? 0,
                                (int)ERP.Business.Enumerados.tipoBasculaBitacora.SalidaDeProduccion,
                                entity.ProductoId,
                                null,
                                oContext);
                        }

                    }
                    scope.Complete();
                }

            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                                 "ERP",
                                                 "ERP.Business.ProduccionBusiness",
                                                 ex);

                result.error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

            }

            return result;
        }


      
        #endregion
    }
}
