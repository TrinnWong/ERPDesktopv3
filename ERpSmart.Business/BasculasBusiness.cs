using ConexionBD;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business
{
    public class BasculasBusiness: BusinessObject
    {
        public static decimal rangoTolerancia = .01M;
        List<doc_basculas_bitacora> bitacora;
        cat_basculas_configuracion conf = null;
        int contadorBitacora = 0;
        public bool vaciando = false;
        int sucursalId;

        public BasculasBusiness(int _sucursalId)
        {
            bitacora = new List<doc_basculas_bitacora>();
            conf = GetConfiguracionPCLocal_NoStatic(1);
            sucursalId = _sucursalId;
        }
        public ResultAPIModel Insert(ref cat_basculas entity,int usuarioId)
        {
            ResultAPIModel result = new ResultAPIModel();

            try
            {
                if (
                    entity.Alias == String.Empty ||
                    entity.Marca == String.Empty 
                    )
                {
                    result.error = "El Alias y Marca son requeridos";
                    return result;
                }

                entity.BasculaId = (oContext.cat_basculas.Max(m => (int?)m.BasculaId) ?? 0) + 1;
                entity.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                entity.CreadoPor = usuarioId;
                entity.Activo = true;
                entity.SucursalAsignadaId = entity.SucursalAsignadaId == 0 ? null : entity.SucursalAsignadaId;

                cat_basculas entityInsert = entity;
                oContext.cat_basculas.Add(entityInsert);
                oContext.SaveChanges();
                
            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                     "ERP",
                                     "BasculasBusiness",
                                     ex);

                result.error = ConstantesBusiness.messageErrorBitacora.Replace("{id}",err.ToString());
            }

            return result;

        }

        public ResultAPIModel Update(cat_basculas entity, int usuarioId)
        {
            ResultAPIModel result = new ResultAPIModel();

            try
            {
                if (
                    entity.Alias == String.Empty ||
                    entity.Marca == String.Empty
                    )
                {
                    result.error = "El Alias y Marca son requeridos";
                    return result;
                }

                int id = entity.BasculaId;

                cat_basculas entityUpd = oContext.cat_basculas.Where(w => w.BasculaId == id).FirstOrDefault();
                entityUpd.Activo = entity.Activo;
                entityUpd.Alias = entity.Alias;                
                entityUpd.ModificadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                entityUpd.ModificadoPor = usuarioId;
                entityUpd.Marca = entity.Marca;
                entityUpd.Modelo = entity.Modelo;
                entityUpd.Serie = entity.Serie;
                entityUpd.SucursalAsignadaId = entity.SucursalAsignadaId == 0 ? null : entity.SucursalAsignadaId;                

                
                oContext.SaveChanges();

            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                     "ERP",
                                     "BasculasBusiness",
                                     ex);

                result.error = ConstantesBusiness.messageErrorBitacora.Replace("{id}", err.ToString());
            }

            return result;

        }


        public static    cat_basculas_configuracion GetConfiguracionPCLocal(int usuarioId,int sucursalId)
        {
            cat_basculas_configuracion result = null;
            try
            {
                ERPProdEntities oContext = new ERPProdEntities();
               

                string hardwareId = EquipoComputoBusiness.GetProcessorID();

                result = oContext.cat_basculas_configuracion
                    .Where(w=> w.cat_equipos_computo.HardwareID == hardwareId && w.SucursalId == sucursalId).FirstOrDefault();
                    

            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                      "ERP",
                                      "BasculasBusiness",
                                      ex);

                ConstantesBusiness.messageErrorBitacora.Replace("{id}", err.ToString());
            }

            return result;
        }

        public  cat_basculas_configuracion GetConfiguracionPCLocal_NoStatic(int usuarioId)
        {
            cat_basculas_configuracion result = null;
            try
            {
                ERPProdEntities oContext = new ERPProdEntities();


                string hardwareId = EquipoComputoBusiness.GetProcessorID();

                result = oContext.cat_basculas_configuracion
                    .Where(w => w.cat_equipos_computo.HardwareID == hardwareId && w.cat_equipos_computo.SucursalId == sucursalId).FirstOrDefault();


            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                      "ERP",
                                      "BasculasBusiness",
                                      ex);

                ConstantesBusiness.messageErrorBitacora.Replace("{id}", err.ToString());
            }

            return result;
        }

        public static ResultAPIModel InsertUpdateLocalConfig(cat_basculas_configuracion entity,int usuarioId)
        {
            string error = "";
            ResultAPIModel result = new ResultAPIModel();
            try
            {

                if (entity == null)
                {
                    result.error = "No hay información para guardar";
                }
                if(entity.BasculaId == 0)
                {
                    result.error = "La Báscula es requerida";
                }
                if(entity.PortName == String.Empty)
                {
                    result.error = "El campo POrtName es requerido";
                }

                if(!result.ok)
                {
                    return result;
                }

                
                string HardwareId = EquipoComputoBusiness.GetProcessorID();
                ERPProdEntities oContext = new ERPProdEntities();

                cat_equipos_computo entityEquipoComputo = oContext.cat_equipos_computo
                    .Where(w => w.HardwareID == HardwareId && w.SucursalId == entity.SucursalId).FirstOrDefault();               
               

                if(entityEquipoComputo.cat_basculas_configuracion != null)
                {
                    int equipoId = entityEquipoComputo.EquipoComputoId;

                    cat_basculas_configuracion entityUpd = oContext.cat_basculas_configuracion
                        .Where(w => w.EquipoComputoId == equipoId).FirstOrDefault();

                    entityUpd.BasculaId = entity.BasculaId;
                    entityUpd.BaudRate = entity.BaudRate;
                    entityUpd.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                    entityUpd.CreadoPor = usuarioId;
                    entityUpd.EquipoComputoId = entityEquipoComputo.EquipoComputoId;
                    entityUpd.PortName = entity.PortName;
                    entityUpd.ReadBufferSize = entity.ReadBufferSize;
                    entityUpd.WriteBufferSize = entity.WriteBufferSize;
                    entityUpd.PesoDefault = entity.PesoDefault;
                    entityUpd.SucursalId = entity.SucursalId;
                    oContext.SaveChanges();
                }
                else
                {
                    cat_basculas_configuracion entityIns = new cat_basculas_configuracion();

                    entityIns.BasculaId = entity.BasculaId;
                    entityIns.BaudRate = entity.BaudRate;
                    entityIns.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                    entityIns.CreadoPor = usuarioId;
                    entityIns.EquipoComputoId = entityEquipoComputo.EquipoComputoId;
                    entityIns.PortName = entity.PortName;
                    entityIns.ReadBufferSize = entity.ReadBufferSize;
                    entityIns.WriteBufferSize = entity.WriteBufferSize;
                    entityIns.PesoDefault = entity.PesoDefault;
                    entityIns.SucursalId = entity.SucursalId;
                    oContext.cat_basculas_configuracion.Add(entityIns);

                    oContext.SaveChanges();
                }             


            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                      "ERP",
                                      "BasculasBusiness",
                                      ex);

                result.error= ConstantesBusiness.messageErrorBitacora.Replace("{id}", err.ToString());


            }

            return result;
        }

        public string LecturaRegistroBascula(ref SerialPort port)
        {
            ResultAPIModel result = new ResultAPIModel();

            if (vaciando)
                return "Vaciando..";

            try
            {
               

                contadorBitacora++;

                if (!port.IsOpen)
                {
                    port.Open();

                }

                port.Write("P");
                string value = port.ReadExisting();

                //if (port.IsOpen)
                //{
                //    port.Close();

                //}

                value = value.Replace("Kg", "").Replace("+", "").Replace("KG", "").Replace("kg", "");

                decimal cantidad = 0;

                 decimal.TryParse(value, out cantidad);

                if(cantidad > 0)
                {
                    bitacora.Add(new doc_basculas_bitacora()
                    {
                        Cantidad = cantidad/1000,
                        Fecha = DateTime.Now,
                        SucursalId = conf.cat_basculas.SucursalAsignadaId ?? 0,
                        BasculaId = conf.BasculaId
                    });
                }
                    
                       
                        
                    
               
            }
            catch (Exception ex)
            {
                bitacora.Add(new doc_basculas_bitacora()
                {
                    Cantidad = 0,
                    Fecha = DateTime.Now,
                    SucursalId = conf.cat_basculas.SucursalAsignadaId ?? 0,
                    BasculaId = conf.BasculaId
                });

                int err = ERP.Business.SisBitacoraBusiness.Insert(1,
                                      "ERP",
                                      "BasculasBusiness",
                                      ex);

                result.error = ConstantesBusiness.messageErrorBitacora.Replace("{id}", err.ToString());

                return ex.Message + ":" +ex.StackTrace;
            }

            if(contadorBitacora >= 10 && !vaciando)
            {
                BasculasBusiness oRegistroBascula = new BasculasBusiness(sucursalId);
               ResultAPIModel task = oRegistroBascula.VaciarRegistrarBitacora(bitacora);

                if (!task.ok)
                {
                   
                    return task.error;
                }
                else
                {
                    bitacora = new List<doc_basculas_bitacora>();
                    contadorBitacora = 0;
                }
                
            }
            return "";
        }

        private ResultAPIModel VaciarRegistrarBitacora(List<doc_basculas_bitacora> _bitacora)
        {
            ResultAPIModel result = new ResultAPIModel();

            try
            {
                vaciando = true;
                ERPProdEntities oContext = new ERPProdEntities();
                for (int i = 0; i < _bitacora.Count; i++)
                {
                    try
                    {
                        doc_basculas_bitacora itemNew = new doc_basculas_bitacora();

                        itemNew.Id = (oContext.doc_basculas_bitacora.Max(m => (int?)m.Id) ?? 0) + 1;
                        itemNew.BasculaId = _bitacora[i].BasculaId;
                        itemNew.Cantidad = _bitacora[i].Cantidad;
                        itemNew.Fecha = _bitacora[i].Fecha;
                        itemNew.SucursalId = _bitacora[i].SucursalId;

                        oContext.doc_basculas_bitacora.Add(itemNew);
                        oContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {

                        int err = ERP.Business.SisBitacoraBusiness.Insert(1,
                                     "ERP",
                                     "BasculasBusiness",
                                     ex);

                      
                    }

                }
                
                
                


            }
            catch (Exception ex)
            {
               
                vaciando = false;

              
                int err = ERP.Business.SisBitacoraBusiness.Insert(1,
                                      "ERP",
                                      "BasculasBusiness",
                                      ex);

                result.error = ex.Message + ":" + ex.StackTrace + ":"+ (ex.InnerException!= null ? ex.InnerException.Message:"");// ConstantesBusiness.messageErrorBitacora.Replace("{id}", err.ToString());



            }

            vaciando = false;

            return result;
        }

        public static doc_basculas_bitacora InsertBitacora(int BasculaId,int SucursalId,
            int UsuarioId,decimal Cantidad,
            int? TipoBasculaBitacoraId,int? productoId,int? pedidoDetalleId, ERPProdEntities oContext)
        {
            doc_basculas_bitacora entityNew = new doc_basculas_bitacora();
            try
            {
                oContext = new ERPProdEntities();

                entityNew.Id = (oContext.doc_basculas_bitacora.Max(m => (int?)m.Id) ?? 0) + 1;
                entityNew.BasculaId = BasculaId;
                entityNew.Cantidad = Cantidad;
                entityNew.Fecha = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                entityNew.SucursalId = SucursalId;
                entityNew.TipoBasculaBitacoraId = TipoBasculaBitacoraId;
                entityNew.ProductoId = productoId;
                entityNew.PedidoDetalleId = pedidoDetalleId;
                oContext.doc_basculas_bitacora.Add(entityNew);

                oContext.SaveChanges();
                return entityNew;
            }
            catch (Exception ex)
            {

                ERP.Business.SisBitacoraBusiness.Insert(1,
                                     "ERP",
                                     "BasculasBusiness",
                                     ex);
            }

            return entityNew;
        }

        public static doc_basculas_bitacora InsertBitacora(int BasculaId, int SucursalId,
           int UsuarioId, decimal Cantidad,
           int? TipoBasculaBitacoraId, int? productoId, int? pedidoDetalleId)
        {
            doc_basculas_bitacora entityNew = new doc_basculas_bitacora();
            try
            {
                ERPProdEntities oContext = new ERPProdEntities();

                entityNew.Id = (oContext.doc_basculas_bitacora.Max(m => (int?)m.Id) ?? 0) + 1;
                entityNew.BasculaId = BasculaId;
                entityNew.Cantidad = Cantidad;
                entityNew.Fecha = DateTime.Now;
                entityNew.SucursalId = SucursalId;
                entityNew.TipoBasculaBitacoraId = TipoBasculaBitacoraId;
                entityNew.ProductoId = productoId;
                entityNew.PedidoDetalleId = pedidoDetalleId;
                oContext.doc_basculas_bitacora.Add(entityNew);

                oContext.SaveChanges();
                return entityNew;
            }
            catch (Exception ex)
            {

                ERP.Business.SisBitacoraBusiness.Insert(1,
                                     "ERP",
                                     "BasculasBusiness",
                                     ex);
            }

            return entityNew;
        }

        public static decimal ObtenerValorPorRangoGramos(decimal gramos)
        {
            decimal result = 0;
            ERPProdEntities oContext;
            try
            {
                oContext = new ERPProdEntities();

                if(oContext.sis_preferencias_empresa.Where(w=> w.sis_preferencias.Preferencia == "ValidarGramosVenta").Count() >0)
                {
                    doc_rango_gramos_venta valor = oContext.doc_rango_gramos_venta.Where(w => gramos >= w.RangoIniVenta && gramos <= w.RangoFinVenta).FirstOrDefault();

                    if (valor != null)
                    {
                        return valor.EstablecerValor;
                    }
                    else
                    {
                        return gramos;
                    }
                }
                else
                {
                    return gramos;
                }


            }
            catch (Exception ex)
            {

                ERP.Business.SisBitacoraBusiness.Insert(1,
                                     "ERP",
                                     "BasculasBusiness.ObtenerValorPorRangoGramos",
                                     ex);

            }

            return result;
        }

    }
}
