using ConexionBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business
{
    public class ProduccionSolicitudBusiness : BusinessObject
    {
        string error="";
        int err = 0;
        SisBitacoraBusiness oBitacora;
        InventarioBusiness oInventario;
        public string Guardar(ref doc_produccion_solicitud datos,int sucursalId,int usuarioId)
        {
             
            try
            {
                error = "";
                if (datos.DeSucursalId <= 0)
                {
                    error = "La sucursal Solicitante es requerida";
                }
                if (datos.ParaSucursalId <= 0)
                {
                    error = error + ".La sucursal Asigndada es requerida"; ;
                }
                if (datos.FechaProgramada == null) 
                {
                    error = error + ".La Fecha Programada es requerida"; ;
                }
                if (datos.DepartamentoId == null)
                {
                    error = error + ".El departamento es requerido"; ;
                }
                if (error.Length > 0)
                {
                    return error;
                }
                using (oContext = new ERPProdEntities())
                {
                    using (var dbContextTransaction = oContext.Database.BeginTransaction())
                    {
                        SisBitacoraBusiness oBitacora = new SisBitacoraBusiness(oContext);
                        try
                        {
                            if(datos.ProduccionSolicitudId == 0)
                            {
                                doc_produccion_solicitud entityNew = new doc_produccion_solicitud();

                                entityNew.Activa = true;
                                entityNew.Completada = false;
                                entityNew.CreadoEl = DateTime.Now;
                                entityNew.CreadoPor = usuarioId;
                                entityNew.DeSucursalId = datos.DeSucursalId;
                                entityNew.ParaSucursalId = datos.ParaSucursalId;
                                entityNew.FechaProgramada = datos.FechaProgramada;
                                entityNew = oContext.doc_produccion_solicitud.Add(entityNew);
                                entityNew.DepartamentoId = datos.DepartamentoId;
                                oContext.SaveChanges();
                                datos = entityNew;
                                oBitacora.GuardarBitacoraGeneral("INSERT", sucursalId, entityNew, usuarioId);
                            }
                            else
                            {
                                int id = datos.ProduccionSolicitudId;
                                doc_produccion_solicitud entityUpd = oContext.doc_produccion_solicitud
                                    .Where(w => w.ProduccionSolicitudId == id).FirstOrDefault();

                                if(entityUpd != null)
                                {
                                    entityUpd.Activa = datos.Activa;
                                    entityUpd.Completada = datos.Completada;
                                    entityUpd.DeSucursalId = datos.DeSucursalId;
                                    entityUpd.ParaSucursalId = datos.ParaSucursalId;
                                    entityUpd.FechaProgramada = datos.FechaProgramada;
                                    entityUpd.DepartamentoId = datos.DepartamentoId;
                                    oContext.SaveChanges();

                                    oBitacora.GuardarBitacoraGeneral("UPDATE", sucursalId, entityUpd, usuarioId);
                                }

                            }
                            

                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();

                            int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                              "ERP",
                                              "ERP.Business.ProduccionSolicitudBusiness",
                                              ex);

                            return "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

                        }
                    }

                    return "";
                }
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

        public string GuardarDetalle(doc_produccion_solicitud_detalle datos,int sucursalId,int usuarioId)
        {
            try
            {
                error = "";
                if (datos.ProductoId <= 0)
                {
                    error = "El producto es requerido";
                }
                if (datos.UnidadId <= 0)
                {
                    error = error + ".La unidad es requerida" ;
                }
                if (datos.Cantidad <= 0)
                {
                    error = error + ".La cantidad es requerida";
                }
                if (error.Length > 0)
                {
                    return error;
                }
                using (oContext = new ERPProdEntities())
                {
                    using (var dbContextTransaction = oContext.Database.BeginTransaction())
                    {
                        try
                        {
                            SisBitacoraBusiness oBitacora = new SisBitacoraBusiness(oContext);

                            if (datos.Id == 0)
                            {
                                doc_produccion_solicitud_detalle entityNew = new doc_produccion_solicitud_detalle();

                                entityNew.Id = (oContext.doc_produccion_solicitud_detalle.Max(m => (int?)m.Id) ?? 0) + 1;
                                entityNew.Cantidad = datos.Cantidad;
                                entityNew.CreadoEl = DateTime.Now;
                                entityNew.CreadoPor = usuarioId;
                                entityNew.ProductoId = datos.ProductoId;
                                entityNew.UnidadId = datos.UnidadId;
                                entityNew.ProduccionSolicitudId = datos.ProduccionSolicitudId;
                                oContext.doc_produccion_solicitud_detalle.Add(entityNew);
                                oContext.SaveChanges();

                                oBitacora.GuardarBitacoraGeneral("INSERT", sucursalId, entityNew, usuarioId);

                            }
                            else
                            {
                                doc_produccion_solicitud_detalle entityUpd = oContext.doc_produccion_solicitud_detalle
                                    .Where(w => w.Id == datos.Id).FirstOrDefault();
                                if (entityUpd != null)
                                {
                                    entityUpd.Cantidad = datos.Cantidad;
                                    entityUpd.ProductoId = datos.ProductoId;
                                    entityUpd.UnidadId = datos.UnidadId;

                                    oContext.SaveChanges();

                                    oBitacora.GuardarBitacoraGeneral("UPDATE", sucursalId, entityUpd, usuarioId);

                                }


                            }

                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {

                            dbContextTransaction.Rollback();

                            int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                              "ERP",
                                              "ERP.Business.ProduccionSolicitudBusiness",
                                              ex);

                            return "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

                        }


                    }
                    return "";
                }

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

        public string Enviar(int produccionSoicitudId,int sucursalId,int usuarioId)
        {
            try
            {
                using (oContext = new ERPProdEntities())
                {
                    using (var dbContextTransaction = oContext.Database.BeginTransaction())
                    {
                        try
                        {
                            SisBitacoraBusiness oBitacora = new SisBitacoraBusiness(oContext);

                            doc_produccion_solicitud entity = oContext.doc_produccion_solicitud
                                .Where(w => w.ProduccionSolicitudId == produccionSoicitudId).FirstOrDefault();

                            entity.Enviada = true;

                            oContext.SaveChanges();

                            oContext.p_doc_produccion_solicitud_requerido_gen(produccionSoicitudId, usuarioId);


                            oBitacora.GuardarBitacoraGeneral("UPDATE", sucursalId, entity, usuarioId);

                           
                            dbContextTransaction.Commit();

                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
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

                err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                             "ERP",
                                             "ERP.Business.ProductoSobranteBusiness",
                                             ex);

                return "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
            }
        }

        public string Eliminar(int produccionSolicitudId,int usuarioId,int sucursalId)
        {
            try
            {
                if(oContext.doc_produccion_solicitud_detalle
                    .Where(w=> w.ProduccionSolicitudId == produccionSolicitudId).Count() == 0)
                {
                    return "No hay prouctos para enviar";
                }

                using (oContext = new ERPProdEntities())
                {
                    using (var dbContextTransaction = oContext.Database.BeginTransaction())
                    {
                        try
                        {
                            SisBitacoraBusiness oBitacora = new SisBitacoraBusiness(oContext);

                            oContext.doc_produccion_solicitud_detalle.RemoveRange(oContext.doc_produccion_solicitud_detalle.Where(w=> w.ProduccionSolicitudId == produccionSolicitudId));

                            doc_produccion_solicitud entity = oContext.doc_produccion_solicitud
                                                    .Where(w => w.ProduccionSolicitudId == produccionSolicitudId).FirstOrDefault();

                            oContext.doc_produccion_solicitud.Remove(entity);
                            oContext.SaveChanges();
                            oBitacora.GuardarBitacoraGeneral("DELETE", sucursalId, entity, usuarioId);

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

                    return "";
                }


            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                  "ERP",
                                  "ERP.Business.ProduccionSolicitudBusiness",
                                  ex);

                return "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

            }
        }

        public string EliminarDetalle(int Id, int usuarioId, int sucursalId)
        {
            try
            {

                using (oContext = new ERPProdEntities())
                {
                    using (var dbContextTransaction = oContext.Database.BeginTransaction())
                    {
                        try
                        {
                            SisBitacoraBusiness oBitacora = new SisBitacoraBusiness(oContext);

                            doc_produccion_solicitud_detalle entity = oContext.doc_produccion_solicitud_detalle
                                                    .Where(w => w.Id == Id).FirstOrDefault();

                            oContext.doc_produccion_solicitud_detalle.Remove(entity);
                            oContext.SaveChanges();
                            oBitacora.GuardarBitacoraGeneral("DELETE", sucursalId, entity, usuarioId);

                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                 "ERP",
                                 "ERP.Business.ProduccionSolicitudBusiness",
                                 ex);

                            return "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
                        }
                        



                    }

                    return "";
                }


            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                  "ERP",
                                  "ERP.Business.ProduccionSolicitudBusiness",
                                  ex);

                return "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

            }
        }

        public string Iniciar(int produccionSolicitudId,int usuarioId,int sucursalId)
        {
            try
            {
                oContext = new ERPProdEntities();
                doc_produccion_solicitud entitySol = null;
                #region validaciones
                if(oContext.doc_produccion_solicitud_requerido
                    .Where(w => w.doc_produccion_solicitud_detalle.ProduccionSolicitudId == produccionSolicitudId &&
                    w.UnidadRequeridaId != w.cat_productos.ClaveUnidadMedida && w.doc_produccion_solicitud_detalle.doc_produccion_solicitud_ajuste_unidad.Count() ==0)
                    .Count() > 0)
                {
                    return "Se requiere realizar el ajsute de unidades antes de iniciar";
                }

                entitySol = oContext.doc_produccion_solicitud
                               .Where(w => w.ProduccionSolicitudId == produccionSolicitudId).FirstOrDefault();

                if(entitySol.doc_produccion_solicitud_detalle.Count() == 0)
                {
                    return "No hay producciones relacionados a la solicitud";
                }

                if(entitySol.Enviada == false)
                {
                    return "La solicitud debe de estar con estatus de enviada";
                }
                #endregion
                using (oContext = new ERPProdEntities())
                {
                    using (var dbContextTransaction = oContext.Database.BeginTransaction())
                    {
                        try
                        {
                            oBitacora = new SisBitacoraBusiness(oContext);
                            oInventario = new InventarioBusiness(oContext);

                            int tipoMovimientoId = (int)Enumerados.tipoMovimientoInventario.InsumoInternoProduccion;

                            List<doc_produccion_solicitud_requerido> invRequerido = oContext.doc_produccion_solicitud_requerido.Where(w => w.doc_produccion_solicitud_detalle
                            .doc_produccion_solicitud.ProduccionSolicitudId == produccionSolicitudId).ToList();

                            doc_inv_movimiento movInv = new doc_inv_movimiento();

                            movInv.Activo = true;
                            movInv.Autorizado = true;
                            movInv.Cancelado = false;
                            movInv.Consecutivo = oContext.doc_inv_movimiento
                                .Where(w => w.SucursalId == sucursalId && w.TipoMovimientoId == tipoMovimientoId).Count() + 1;
                            movInv.CreadoEl = DateTime.Now;
                            movInv.CreadoPor = usuarioId;
                            movInv.FechaAutoriza = DateTime.Now;
                            movInv.FechaCancelacion = null;
                            movInv.FechaMovimiento = DateTime.Now;
                            movInv.FolioMovimiento = movInv.Consecutivo.ToString();
                            movInv.HoraMovimiento = DateTime.Now.TimeOfDay;
                            movInv.ImporteTotal = 0;
                            movInv.MovimientoId = (oContext.doc_inv_movimiento
                                .Max(m => (int?)m.MovimientoId) ?? 0) + 1;
                            movInv.SucursalId = sucursalId;
                            movInv.TipoMovimientoId = tipoMovimientoId;
                            movInv.Comentarios = "";
                            movInv.AutorizadoPor = usuarioId;
                            oContext.doc_inv_movimiento.Add(movInv);

                            oContext.SaveChanges();   
                                                      

                            foreach (var item in invRequerido)
                            {

                                doc_inv_movimiento_detalle movInvDetalle = new doc_inv_movimiento_detalle();


                                movInvDetalle.Cantidad = item.doc_produccion_solicitud_detalle.doc_produccion_solicitud_ajuste_unidad.Where(s1=> s1.ProductoId == item.ProductoRequeridoId).Count() > 0 ?
                                                            item.doc_produccion_solicitud_detalle.doc_produccion_solicitud_ajuste_unidad.Where(s1 => s1.ProductoId == item.ProductoRequeridoId).Sum(s=> (decimal?)s.Cantidad) : (decimal?)item.Cantidad;
                                movInvDetalle.Comisiones = 0;
                                movInvDetalle.Consecutivo = 0;
                                movInvDetalle.CreadoEl = DateTime.Now;
                                movInvDetalle.CreadoPor = usuarioId;
                                movInvDetalle.MovimientoDetalleId = (oContext.doc_inv_movimiento_detalle
                                    .Max(m => (int?)m.MovimientoDetalleId) ?? 0) + 1;
                                movInvDetalle.MovimientoId = movInv.MovimientoId;
                                movInvDetalle.PrecioNeto = ProductoBusiness.ObtenerPrecioNeto(item.ProductoRequeridoId, Enumerados.tipoPrecioProducto.PublicoGeneral,usuarioId);
                                movInvDetalle.PrecioUnitario = ProductoBusiness.ObtenerPrecio(item.ProductoRequeridoId, Enumerados.tipoPrecioProducto.PublicoGeneral, usuarioId,sucursalId);
                                movInvDetalle.ProductoId = item.ProductoRequeridoId;
                                movInvDetalle.SubTotal = movInvDetalle.PrecioNeto * movInvDetalle.Cantidad;
                                
                                oContext.doc_inv_movimiento_detalle.Add(movInvDetalle);
                                oContext.SaveChanges();
                            }

                            oBitacora.GuardarBitacoraGeneral("INICIO PRODUCCION COCINA ID:" + produccionSolicitudId.ToString() , sucursalId, null, usuarioId);

                            entitySol = oContext.doc_produccion_solicitud
                                .Where(w => w.ProduccionSolicitudId == produccionSolicitudId).FirstOrDefault();

                            entitySol.Iniciada = true;
                            entitySol.FechaInicioEjecucion = DateTime.Now;
                            oContext.SaveChanges();

                            oContext.p_doc_produccion_generar_por_solicitud(produccionSolicitudId,usuarioId);

                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                 "ERP",
                                 "ERP.Business.ProduccionSolicitudBusiness",
                                 ex);

                            return "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
                        }

                    }

                    return "";
                }

            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                             "ERP",
                             "ERP.Business.ProduccionSolicitudBusiness.Iniciar",
                             ex);

                return "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";


            }
        }

        public string Terminar(int produccionSolicitudId, int usuarioId, int sucursalId)
        {
            try
            {
                oContext = new ERPProdEntities();
                doc_produccion_solicitud entitySol = null;
                #region validaciones

                entitySol = oContext.doc_produccion_solicitud
                               .Where(w => w.ProduccionSolicitudId == produccionSolicitudId).FirstOrDefault();

                if (entitySol.doc_produccion_solicitud_detalle.Count() == 0)
                {
                    return "No hay producciones relacionados a la solicitud";
                }

                if (entitySol.Iniciada == false)
                {
                    return "La solicitud debe de estar con estatus de Iniciada";
                }
                #endregion
                using (oContext = new ERPProdEntities())
                {
                    using (var dbContextTransaction = oContext.Database.BeginTransaction())
                    {
                        try
                        {
                            oBitacora = new SisBitacoraBusiness(oContext);
                           
                            oBitacora.GuardarBitacoraGeneral("FIN DE PRODUCCION COCINA ID:"+produccionSolicitudId.ToString(), sucursalId, null, usuarioId);

                            entitySol = oContext.doc_produccion_solicitud
                                .Where(w => w.ProduccionSolicitudId == produccionSolicitudId).FirstOrDefault();
                            entitySol.Terminada = true;
                            entitySol.FechaFinEjecucion = DateTime.Now;

                            oContext.SaveChanges();

                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                 "ERP",
                                 "ERP.Business.ProduccionSolicitudBusiness",
                                 ex);

                            return "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
                        }

                    }

                    return "";
                }

            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                             "ERP",
                             "ERP.Business.ProduccionSolicitudBusiness.Iniciar",
                             ex);

                return "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";


            }
        }

        public string GuardarAjusteUnidad(doc_produccion_solicitud_ajuste_unidad datos, int usuarioId,int sucursalId)
        {
            try
            {
                oContext = new ERPProdEntities();
                
                #region validaciones              

                if (datos.Cantidad <=0)
                {
                    return "La cantidad debe de ser mayor a cero";
                }

                
                #endregion

                using (oContext = new ERPProdEntities())
                {
                    using (var dbContextTransaction = oContext.Database.BeginTransaction())
                    {
                        try
                        {
                            oBitacora = new SisBitacoraBusiness(oContext);                          

                            doc_produccion_solicitud_ajuste_unidad rowNew = new doc_produccion_solicitud_ajuste_unidad();

                            rowNew.Cantidad = datos.Cantidad;
                            rowNew.CreadoEl = DateTime.Now;
                            rowNew.CreadoPor = usuarioId;
                            rowNew.ProduccionSolicitudDetalleId = datos.ProduccionSolicitudDetalleId;
                            rowNew.ProductoId = datos.ProductoId;
                            rowNew.UnidadId = datos.UnidadId;

                            oContext.doc_produccion_solicitud_ajuste_unidad.Add(rowNew);

                            oContext.SaveChanges();

                            oBitacora.GuardarBitacoraGeneral("INSERTAR AJUSTE UNIDAD PRODUCCIÓN:" + rowNew.Id, sucursalId, null, usuarioId);
                            
                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                 "ERP",
                                 "ERP.Business.ProduccionSolicitudBusiness",
                                 ex);

                            return "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
                        }

                    }

                   
                }

                return "";
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                              "ERP",
                              "ERP.Business.ProduccionSolicitudBusiness.GuardarAjusteUnidad",
                              ex);

                return "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
            }
        }


        public string EliminarAjusteUnidad(int id, int usuarioId, int sucursalId)
        {
            try
            {
                oContext = new ERPProdEntities();

             
                using (oContext = new ERPProdEntities())
                {
                    using (var dbContextTransaction = oContext.Database.BeginTransaction())
                    {
                        try
                        {
                            oBitacora = new SisBitacoraBusiness(oContext);



                            doc_produccion_solicitud_ajuste_unidad rowDel = oContext.doc_produccion_solicitud_ajuste_unidad
                                .Where(w => w.Id == id).FirstOrDefault();

                            oContext.doc_produccion_solicitud_ajuste_unidad.Remove(rowDel);
                            oContext.SaveChanges();


                            oBitacora.GuardarBitacoraGeneral("DELETE AJUSTE UNIDAD PRODUCCIÓN:" + id, sucursalId, null, usuarioId);


                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                 "ERP",
                                 "ERP.Business.ProduccionSolicitudBusiness",
                                 ex);

                            return "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
                        }

                    }

                   
                }

                return "";
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                              "ERP",
                              "ERP.Business.ProduccionSolicitudBusiness.GuardarAjusteUnidad",
                              ex);

                return "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
            }
        }

        public string GuardarAceptacion(int produccionSolicitudId,List<ERP.Models.ProduccionSolicitud.ProduccionSolicitudAceptacionGrd> datos,
            int usuarioId,
            int sucursalId)
        {
            try
            {
                
                oContext = new ERPProdEntities();

                #region validaciones
                if(datos.Where(w=> w.cantidadAceptacion <= 0).Count() > 0)
                {
                    return "Las cantidades de aceptación deben de ser mayores a cero";
                }
                #endregion
                using (oContext = new ERPProdEntities())
                {
                    using (var dbContextTransaction = oContext.Database.BeginTransaction())
                    {
                        try
                        {
                            oBitacora = new SisBitacoraBusiness(oContext);


                            int tipoMovimientoId = (int)Enumerados.tipoMovimientoInventario.ProductoProduccion;
                            doc_inv_movimiento movInv = new doc_inv_movimiento();

                            movInv.Activo = true;
                            movInv.Autorizado = true;
                            movInv.Cancelado = false;
                            movInv.Consecutivo = oContext.doc_inv_movimiento
                                .Where(w => w.SucursalId == sucursalId && w.TipoMovimientoId == tipoMovimientoId).Count() + 1;
                            movInv.CreadoEl = DateTime.Now;
                            movInv.CreadoPor = usuarioId;
                            movInv.FechaAutoriza = DateTime.Now;
                            movInv.FechaCancelacion = null;
                            movInv.FechaMovimiento = DateTime.Now;
                            movInv.FolioMovimiento = movInv.Consecutivo.ToString();
                            movInv.HoraMovimiento = DateTime.Now.TimeOfDay;
                            movInv.ImporteTotal = 0;
                            movInv.MovimientoId = (oContext.doc_inv_movimiento
                                .Max(m => (int?)m.MovimientoId) ?? 0) + 1;
                            movInv.SucursalId = sucursalId;
                            movInv.TipoMovimientoId = tipoMovimientoId;
                            movInv.Comentarios = "";
                            movInv.AutorizadoPor = usuarioId;
                            oContext.doc_inv_movimiento.Add(movInv);

                            oContext.SaveChanges();

                            foreach (var itemRow in datos)
                            {
                                #region actualizar aceptación
                                doc_produccion_solicitud_aceptacion entityAceptacion = new doc_produccion_solicitud_aceptacion();

                                entityAceptacion.AceptadoPor = usuarioId;
                                entityAceptacion.Cantidad = itemRow.cantidadAceptacion ?? 0;
                                entityAceptacion.CreadoEl = DateTime.Now;
                                entityAceptacion.ProduccionSolicitudDetalleId = itemRow.produccionSolicitudDetalleId;
                                entityAceptacion.UnidadId = itemRow.unidadId;
                                entityAceptacion.Comentarios = itemRow.comentarios;
                                oContext.doc_produccion_solicitud_aceptacion.Add(entityAceptacion);
                                oContext.SaveChanges();
                                
                                #endregion
                                #region afectar inventario
                                doc_inv_movimiento_detalle movInvDetalle = new doc_inv_movimiento_detalle();

                                movInvDetalle.Cantidad = (decimal?)itemRow.cantidadAceptacion;
                                movInvDetalle.Comisiones = 0;
                                movInvDetalle.Consecutivo = 0;
                                movInvDetalle.CreadoEl = DateTime.Now;
                                movInvDetalle.CreadoPor = usuarioId;
                                movInvDetalle.MovimientoDetalleId = (oContext.doc_inv_movimiento_detalle
                                    .Max(m => (int?)m.MovimientoDetalleId) ?? 0) + 1;
                                movInvDetalle.MovimientoId = movInv.MovimientoId;
                                movInvDetalle.PrecioNeto = ProductoBusiness.ObtenerPrecioNeto(itemRow.productoId, Enumerados.tipoPrecioProducto.PublicoGeneral, usuarioId);
                                movInvDetalle.PrecioUnitario = ProductoBusiness.ObtenerPrecio(itemRow.productoId, Enumerados.tipoPrecioProducto.PublicoGeneral, usuarioId,sucursalId);
                                movInvDetalle.ProductoId = itemRow.productoId;
                                movInvDetalle.SubTotal = movInvDetalle.PrecioNeto * movInvDetalle.Cantidad;

                                oContext.doc_inv_movimiento_detalle.Add(movInvDetalle);
                                oContext.SaveChanges();
                                #endregion
                            }

                            oBitacora.GuardarBitacoraGeneral("GUARDAR ACEPTACIÓN PRODUCCIÓN ID:" + produccionSolicitudId.ToString(), sucursalId, null, usuarioId);

                            doc_produccion_solicitud entityProd = oContext.doc_produccion_solicitud
                                .Where(w => w.ProduccionSolicitudId == produccionSolicitudId).FirstOrDefault();

                            entityProd.Aceptada = true;
                            oContext.SaveChanges();

                            oContext.p_doc_produccion_completar_por_solicitud(produccionSolicitudId, usuarioId);
                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                 "ERP",
                                 "ERP.Business.ProduccionSolicitudBusiness",
                                 ex);

                            return "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
                        }

                    }


                }

                return "";
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                          "ERP",
                          "ERP.Business.ProduccionSolicitudBusiness.GuardarAjusteUnidad",
                          ex);

                return "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

            }
        }
    }
}
