using ConexionBD;
using ERP.Models;
using ERP.Models.Cargo;
using ERP.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.Entity;


namespace ERP.Business
{
    public class CargoBusiness : BusinessObject
    {
        public ResultAPIModel AddMassive(CargoParamModel model)
        {
            ResultAPIModel result = new ResultAPIModel();

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (var itemCargo in model.cargo)
                    {
                        doc_cargos entityCargo = new doc_cargos();
                        int cargoId = 0;
                        entityCargo.CargoId = (oContext.doc_cargos.Max(m => (int?)m.CargoId) ?? 0) + 1;
                        entityCargo.ClienteId = itemCargo.clienteId;
                        entityCargo.CreadoPor = 1;
                        entityCargo.CredoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                        entityCargo.Total = 0;
                        entityCargo.Activo = true;

                        oContext.doc_cargos.Add(entityCargo);

                        cargoId = entityCargo.CargoId;

                        foreach (var itemDet in itemCargo.detalle)
                        {
                            doc_cargos_detalle entityCargoDet = new doc_cargos_detalle();

                            entityCargoDet.CargoDetalleId = (oContext.doc_cargos_detalle.Max(m => (int?)m.CargoDetalleId) ?? 0) + 1;
                            entityCargoDet.CargoId = entityCargo.CargoId;
                            entityCargoDet.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                            entityCargoDet.FechaCargo = itemDet.fechaCargo;
                            entityCargoDet.FechaPago = itemDet.fechaCargo;
                            entityCargoDet.Impuestos = itemDet.impuestos;
                            entityCargoDet.Subtotal = itemDet.subTotal;
                            entityCargoDet.Total = itemDet.total;
                            entityCargoDet.Saldo = itemDet.total;

                            oContext.doc_cargos_detalle.Add(entityCargoDet);
                        }

                        oContext.SaveChanges();

                        List<doc_cargos_detalle> cargoTotal = oContext.doc_cargos_detalle.Where(w => w.CargoId == cargoId).ToList();

                        doc_cargos entityCargoUpd = oContext.doc_cargos.Where(w => w.CargoId == cargoId).FirstOrDefault();

                        if(cargoTotal != null)
                        {
                            entityCargoUpd.Total = cargoTotal.Sum(s => s.Total);
                            entityCargo.Saldo = cargoTotal.Sum(s => s.Total);
                        }

                        oContext.SaveChanges();

                       // CalcularSaldos(entityCargo.CargoId, 0);
                    }

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {

                result.error = ex.Message;
            }

            return result;

        }


        public ResultAPIModel  AddCargosClientes(CargoClienteRegistroModel model)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (ClienteModel itemCliente in model.clientes)
                    {
                        doc_cargos oCargo = new doc_cargos();

                        oCargo.CargoId = (oContext.doc_cargos.Max(m => (int?)m.CargoId) ?? 0) + 1;
                        oCargo.ClienteId = itemCliente.clienteId;
                        oCargo.CreadoPor = (int)ERP.Business.Enumerados.UserDefault.UserDefault;
                        oCargo.CredoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                        oCargo.ProductoId = model.productoId;
                        oCargo.Saldo = model.cargo.detalle.Sum(s => s.total);
                        oCargo.Total = model.cargo.detalle.Sum(s => s.total);
                        oCargo.Activo = true;
                        oContext.doc_cargos.Add(oCargo);
                        oContext.SaveChanges();
                        foreach (var itemCargoDet in model.cargo.detalle)
                        {
                            doc_cargos_detalle oCargoDet = new doc_cargos_detalle();
                            oCargoDet.CargoDetalleId = (oContext.doc_cargos_detalle.Max(m => (int?)m.CargoDetalleId) ?? 0) + 1;
                            oCargoDet.CargoId = oCargo.CargoId;
                            oCargoDet.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                            oCargoDet.FechaCargo = itemCargoDet.fechaCargo;
                            oCargoDet.FechaPago = null;
                            oCargoDet.Impuestos = itemCargoDet.impuestos;
                            oCargoDet.Saldo = itemCargoDet.total;
                            oCargoDet.Subtotal = itemCargoDet.subTotal;
                            oCargoDet.Total = itemCargoDet.total;

                            oContext.doc_cargos_detalle.Add(oCargoDet);

                            oContext.SaveChanges();
                        }

                        
                    }

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                result.error = ex.Message;
            }

            return result;
        }


        public List<CargoModel> GetList(int sucursalId)
        {
            List<CargoModel> result = new List<CargoModel>();
            try
            {
                result = oContext.doc_cargos
                    .Where(W=> W.Activo == true && W.cat_clientes.SucursalBaseId == sucursalId)
                    .Select(
                        s => new CargoModel()
                        {
                            cargoId = s.CargoId,
                            claveCliente = s.cat_clientes.Clave,
                            clienteId = s.ClienteId,
                             nombreCliente  = s.cat_clientes.Nombre + " "+
                             (s.cat_clientes.ApellidoPaterno == null ? "" : s.cat_clientes.ApellidoPaterno) + " "+
                             (s.cat_clientes.ApellidoMaterno == null ? "" : s.cat_clientes.ApellidoMaterno),
                              productoId = s.ProductoId??0,
                              producto = s.cat_productos.Descripcion,
                               saldo = s.Saldo ?? 0,
                                sucursalCliente = s.cat_clientes.cat_sucursales != null ? s.cat_clientes.cat_sucursales.NombreSucursal : "",
                                 total = s.Total,
                                 activo = s.Activo ??false


                        }
                       
                    ).ToList();
            }
            catch (Exception ex)
            {

                
            }

            return result;

        }

        public CargoModel Get(int cargoId)
        {
            CargoModel model = new CargoModel();
            doc_cargos entity = new doc_cargos();
            try
            {
                entity = oContext.doc_cargos                   
                    .Include(i=> i.cat_clientes)
                    .Where(w => w.CargoId == cargoId && w.Activo == true).FirstOrDefault();

                model.activo = entity.Activo ?? false;
                model.cargoId = entity.CargoId;
                model.claveCliente = entity.cat_clientes.Clave;
                model.clienteId = entity.ClienteId;
                model.nombreCliente = entity.cat_clientes.Nombre + " " +
                    (entity.cat_clientes.ApellidoPaterno != null ? entity.cat_clientes.ApellidoPaterno : "") + " " +
                    (entity.cat_clientes.ApellidoMaterno != null ? entity.cat_clientes.ApellidoMaterno : "");
                model.producto = entity.cat_productos.Descripcion;
                model.productoId = entity.ProductoId??0;
                model.saldo = entity.Saldo ?? 0;
                model.sucursalCliente = entity.cat_clientes.cat_sucursales != null ? entity.cat_clientes.cat_sucursales.NombreSucursal : "";
                model.total = entity.Total;
            }
            catch (Exception)
            {

              
            }

            return model;
        }

        #region enc

        public ResultAPIModel CargoAdd(CargoModel cargo)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                doc_cargos entityAdd = new doc_cargos();

                entityAdd.CargoId = (oContext.doc_cargos.Max(m => (int?)m.CargoId) ?? 0) + 1;
                entityAdd.ClienteId = cargo.clienteId;
                entityAdd.CreadoPor = (int)ERP.Business.Enumerados.UserDefault.UserDefault;
                entityAdd.CredoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                entityAdd.ProductoId = cargo.productoId;
                entityAdd.Saldo = cargo.saldo;
                entityAdd.Total = cargo.total;
                entityAdd.Activo = true;

                oContext.doc_cargos.Add(entityAdd);

                oContext.SaveChanges();
            }
            catch (Exception ex)
            {

                result.error = ex.Message;
            }

            return result;
        }

        public ResultAPIModel CargoEdit(CargoModel cargo)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                int id = cargo.cargoId;
                doc_cargos entityUpd = oContext.doc_cargos.Where(w => w.CargoId == id).FirstOrDefault();

                entityUpd.ClienteId = cargo.clienteId;
                entityUpd.CreadoPor = (int)ERP.Business.Enumerados.UserDefault.UserDefault;
                entityUpd.CredoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                entityUpd.ProductoId = cargo.productoId;
                entityUpd.Saldo = cargo.saldo;
                entityUpd.Total = cargo.total;
                entityUpd.Activo = cargo.activo;

                oContext.SaveChanges();
            }
            catch (Exception ex)
            {

                result.error = ex.Message;
            }

            return result;
        }

        #endregion


        #region detalle

        public ResultAPIModel CargoDetEdit(CargoDetalleModel cargoDet)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    int id = cargoDet.cargoDetalleId;
                    doc_cargos_detalle entityUpd = oContext.doc_cargos_detalle.Where(w => w.CargoDetalleId == id).FirstOrDefault();

                    entityUpd.FechaCargo = cargoDet.fechaCargo;
                    entityUpd.Impuestos = cargoDet.impuestos;
                    entityUpd.Saldo = cargoDet.saldo;
                    entityUpd.Subtotal = cargoDet.subTotal;
                    entityUpd.Total = cargoDet.total;
                    entityUpd.Saldo = cargoDet.saldo ;
                    entityUpd.Descuento = cargoDet.descuento;
                    oContext.SaveChanges();

                    result = CalcularSaldos(cargoDet.cargoId, cargoDet.cargoDetalleId);

                    if(!result.ok)
                    {
                        scope.Dispose();
                        return result;
                    }

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {

                result.error = ex.Message;
            }

            return result;
        }

        public ResultAPIModel CargoDetDel(int id)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    doc_cargos_detalle entityUpd = oContext.doc_cargos_detalle.Where(w => w.CargoDetalleId == id).FirstOrDefault();

                    oContext.doc_cargos_detalle.Remove(entityUpd);

                    oContext.SaveChanges();

                   result = CalcularSaldos(entityUpd.CargoId, entityUpd.CargoDetalleId);

                    if (!result.ok)
                    {
                        scope.Dispose();
                        return result;
                    }

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {

                result.error = ex.Message;
            }

            return result;
        }

        public ResultAPIModel CargoDetAdd(CargoDetalleModel cargoDet)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    doc_cargos_detalle entityAdd = new doc_cargos_detalle();

                    entityAdd.CargoDetalleId = (oContext.doc_cargos_detalle.Max(m => (int?)m.CargoDetalleId) ?? 0) + 1;
                    entityAdd.CargoId = cargoDet.cargoId;
                    entityAdd.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                    entityAdd.FechaCargo = cargoDet.fechaCargo;
                    entityAdd.FechaPago = null;
                    entityAdd.Impuestos = cargoDet.impuestos;
                    entityAdd.Saldo = cargoDet.total;
                    entityAdd.Subtotal = cargoDet.subTotal;
                    entityAdd.Total = cargoDet.total;
                    entityAdd.Descuento = cargoDet.descuento;

                    oContext.doc_cargos_detalle.Add(entityAdd);

                    oContext.SaveChanges();

                    result=CalcularSaldos(entityAdd.CargoId, entityAdd.CargoDetalleId);

                    if (!result.ok)
                    {
                        scope.Dispose();
                        return result;
                    }

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {

                result.error = ex.Message;
            }

            return result;
        }
       

        public List<CargoDetalleModel> GetDetList(int cargoId)
        {
            decimal montoRecargo=0;
            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();
           

            if(entity!=null)
            {
                montoRecargo = entity.MontoRecargoDiario ?? 0;
            }
            DateTime fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
            montoRecargo = entity.MontoRecargoDiario??0;
            List<CargoDetalleModel> result = oContext.doc_cargos_detalle
                .Where(w=> w.CargoId == cargoId)
                .Select(
                    s => new CargoDetalleModel()
                    {
                        cargoDetalleId = s.CargoDetalleId,
                        cargoId = s.CargoId,
                        fechaCargo = s.FechaCargo,
                        fechaPago = s.FechaPago,
                        impuestos =  s.Impuestos,
                        saldo =DbFunctions.TruncateTime(fechaActual) > DbFunctions.TruncateTime(s.FechaCargo) ? 
                                              (s.Saldo??0) + ((DbFunctions.DiffDays(DbFunctions.TruncateTime(s.FechaCargo), DbFunctions.TruncateTime(fechaActual))??0) * montoRecargo)
                                                : (s.Saldo ?? 0),
                        subTotal = s.Subtotal,
                        total = s.Total,
                        descuento=s.Descuento??0
                    }
                ).ToList();

          /*  foreach (CargoDetalleModel item in result)
            {
                int cargoDetalleId = item.cargoDetalleId;

                result.Find(f => f.cargoDetalleId == cargoDetalleId).saldo = GetSaldo(cargoDetalleId,fechaActual,montoRecargo);
            }*/
            return result;
        }
        #endregion

        private decimal GetSaldo(int cargoDetalleId,DateTime fechaActual,decimal montoRecargo)
        {
            decimal saldo = 0;
            try
            {
                //DateTime fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                doc_cargos_detalle cargoDet = oContext.doc_cargos_detalle
                    .Where(w => w.CargoDetalleId == cargoDetalleId).FirstOrDefault();

                saldo = (cargoDet.Saldo??0) - (cargoDet.Descuento??0);

                if(fechaActual.Date > cargoDet.FechaCargo.Date)
                {
                    saldo = saldo +(decimal)(fechaActual.Date - cargoDet.FechaCargo.Date).TotalDays * montoRecargo;
                }


            }
            catch (Exception ex)
            {

                
            }

            return saldo;
        }

        public ResultAPIModel CalcularSaldos(int cargoId,int cargoDetalleId)
        {
            ResultAPIModel result = new ResultAPIModel();

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    List<doc_cargos_detalle> cargoDet = oContext.doc_cargos_detalle
                    .Where(w => (w.CargoDetalleId == cargoDetalleId || cargoDetalleId == 0) && (w.CargoId == cargoId || cargoId ==0)).ToList();

                    foreach (doc_cargos_detalle itemDet in cargoDet)
                    {
                        int i_cargoDetalleId = itemDet.CargoDetalleId;

                        List<doc_ventas_detalle> oPagos = oContext.doc_ventas_detalle
                            .Where(w => w.doc_ventas.Activo == true
                            && w.doc_ventas.FechaCancelacion == null
                            && w.CargoDetalleId == i_cargoDetalleId
                            ).ToList();

                        decimal pagos = oPagos.Sum(s => s.Total);
                        decimal saldo = itemDet.Total - pagos - (itemDet.Descuento??0);
                        /*
                        if(saldo < 0)
                        {
                            result.error = "El saldo no puede ser menor a cero, corregir";
                            return result;
                        }*/

                        doc_cargos_detalle itemUpd = oContext.doc_cargos_detalle
                            .Where(w => w.CargoDetalleId == i_cargoDetalleId).FirstOrDefault();

                        itemUpd.Saldo = saldo;

                        oContext.SaveChanges();
                    }

                    List<doc_cargos_detalle> cargosDetList = oContext.doc_cargos_detalle
                        .Where(w => w.CargoId == cargoId).ToList();

                    decimal saldoCargo = cargosDetList.Sum(s => s.Saldo)??0;

                    decimal totalCargo = cargosDetList.Sum(s => s.Total) ;

                    doc_cargos itemCargoUpd = oContext.doc_cargos.Where(w => w.CargoId == cargoId)
                        .FirstOrDefault();

                    itemCargoUpd.Saldo = saldoCargo;
                    itemCargoUpd.Total = totalCargo;
                    oContext.SaveChanges();

                    scope.Complete();
                }

            }
            catch (Exception ex)
            {
                result.error = ex.Message;
                
            }

            return result;
        }


        
        public static ResultAPIModel CalcularSaldos_Static(ERPProdEntities oContext,int cargoId, int cargoDetalleId,bool usarNube=false)
        {
            ResultAPIModel result = new ResultAPIModel();

            try
            {
                oContext = new ERPProdEntities(usarNube);
                using (TransactionScope scope = new TransactionScope())
                {
                    
                    List<doc_cargos_detalle> cargoDet = oContext.doc_cargos_detalle
                    .Where(w => (w.CargoDetalleId == cargoDetalleId || cargoDetalleId == 0) && (w.CargoId == cargoId || cargoId == 0)).ToList();

                    foreach (doc_cargos_detalle itemDet in cargoDet)
                    {
                        int i_cargoDetalleId = itemDet.CargoDetalleId;
                        decimal pagos = oContext.doc_pagos.Where(w => w.doc_cargos.CargoId == cargoId && w.Activo == true).Sum(s => s.Monto);
                                                
                        if(pagos == 0)
                        {
                            List<doc_ventas_detalle> oPagos = oContext.doc_ventas_detalle
                            .Where(w => w.doc_ventas.Activo == true
                            && w.doc_ventas.FechaCancelacion == null
                            && w.CargoDetalleId == i_cargoDetalleId
                            ).ToList();

                            pagos = oPagos.Sum(s => s.Total);
                        }
                        decimal saldo = itemDet.Total - pagos - (itemDet.Descuento ?? 0);
                        

                        doc_cargos_detalle itemUpd = oContext.doc_cargos_detalle
                            .Where(w => w.CargoDetalleId == i_cargoDetalleId).FirstOrDefault();

                        itemUpd.Saldo = saldo;

                        oContext.SaveChanges();
                    }

                    List<doc_cargos_detalle> cargosDetList = oContext.doc_cargos_detalle
                        .Where(w => w.CargoId == cargoId).ToList();

                    decimal saldoCargo = cargosDetList.Sum(s => s.Saldo) ?? 0;

                    decimal totalCargo = cargosDetList.Sum(s => s.Total);

                    doc_cargos itemCargoUpd = oContext.doc_cargos.Where(w => w.CargoId == cargoId)
                        .FirstOrDefault();

                    itemCargoUpd.Saldo = saldoCargo;
                    itemCargoUpd.Total = totalCargo;
                    oContext.SaveChanges();

                    scope.Complete();
                }

            }
            catch (Exception ex)
            {
                result.error = ex.Message;

            }

            return result;
        }

        public ResultAPIModel CalcularSaldosPagos(int cargoId)
        {
            ResultAPIModel result = new ResultAPIModel();

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    List<doc_cargos_detalle> cargoDet = oContext.doc_cargos_detalle
                    .Where(w => (w.CargoId == cargoId || cargoId == 0)).ToList();

                    List<doc_pagos> lstPagos = oContext.doc_pagos.Where(w => w.CargoId == cargoId && w.Activo == true).ToList();
                    decimal pagosTotal = lstPagos.Sum(s => s.Monto);
                    decimal pagosPorRepartir = lstPagos.Sum(s => s.Monto);


                    foreach (doc_cargos_detalle itemDet in cargoDet.OrderBy(f=> f.FechaCargo))
                    {
                        int i_cargoDetalleId = itemDet.CargoDetalleId;                       

                        doc_cargos_detalle itemUpd = oContext.doc_cargos_detalle
                            .Where(w => w.CargoDetalleId == i_cargoDetalleId).FirstOrDefault();

                        if(pagosPorRepartir > 0)
                        {
                            if (itemUpd.Total <= pagosPorRepartir)
                            {
                                itemUpd.Saldo = 0;
                                pagosPorRepartir = pagosPorRepartir - itemUpd.Total;
                            }
                            else
                            {
                                itemUpd.Saldo = itemUpd.Total - pagosPorRepartir;
                                pagosPorRepartir = 0;
                            }
                        }
                        else
                        {
                            itemUpd.Saldo = itemUpd.Total;
                        }                        

                        oContext.SaveChanges();
                    }

                    List<doc_cargos_detalle> cargosDetList = oContext.doc_cargos_detalle
                        .Where(w => w.CargoId == cargoId).ToList();

                    decimal saldoCargo = cargosDetList.Sum(s => s.Saldo) ?? 0;

                    decimal totalCargo = cargosDetList.Sum(s => s.Total);

                    doc_cargos itemCargoUpd = oContext.doc_cargos.Where(w => w.CargoId == cargoId)
                        .FirstOrDefault();

                    itemCargoUpd.Saldo = saldoCargo;
                    itemCargoUpd.Total = totalCargo;
                    oContext.SaveChanges();

                    scope.Complete();
                }

            }
            catch (Exception ex)
            {
                result.error = ex.Message;

            }

            return result;
        }

        public static doc_cargos GuardarCargoPedido(ERPProdEntities oContext,
            int clienteId,
            doc_pedidos_orden pedido,
            decimal total, 
            DateTime fechaProgPago,
            int usuarioId,
            ref string error)
        {
            doc_cargos entityCargo = new doc_cargos();
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                
                doc_cargos_detalle entityCargoDetalle = new doc_cargos_detalle();

                entityCargo = oContext.doc_cargos
                    .Where(w => w.doc_pedidos_orden.Where(s1 => s1.PedidoId == pedido.PedidoId && s1.Activo == true).Count() > 0).FirstOrDefault();

                if(entityCargo == null)
                {
                    entityCargo = new doc_cargos();
                    entityCargo.Activo = true;
                    entityCargo.CargoId = (oContext.doc_cargos.Max(m => (int?)m.CargoId)??0) + 1;
                    entityCargo.ClienteId = clienteId;
                    entityCargo.CreadoPor = usuarioId;
                    entityCargo.CredoEl = DateTime.Now;
                    entityCargo.Descripcion =String.Format( "CARGO PEDIDO-ID:{0}", pedido.PedidoId.ToString());
                    entityCargo.Descuento = 0;
                    entityCargo.ProductoId = null;
                    entityCargo.Saldo = total;
                    entityCargo.Total = total;

                    oContext.doc_cargos.Add(entityCargo);
                    oContext.SaveChanges();

                    entityCargoDetalle.CargoDetalleId = (oContext.doc_cargos_detalle.Max(m => (int?)m.CargoDetalleId) ?? 0) + 1;
                    entityCargoDetalle.CargoId = entityCargo.CargoId;
                    entityCargoDetalle.CreadoEl = DateTime.Now;
                    entityCargoDetalle.Descuento = 0;
                    entityCargoDetalle.FechaCargo = fechaProgPago;
                    entityCargoDetalle.FechaPago = null;
                    entityCargoDetalle.Impuestos = 0;
                    entityCargoDetalle.Saldo = total;
                    entityCargoDetalle.Subtotal = total;
                    entityCargoDetalle.Total = total;

                    oContext.doc_cargos_detalle.Add(entityCargoDetalle);
                    oContext.SaveChanges();

                    doc_pedidos_orden entityPedido = oContext.doc_pedidos_orden
                        .Where(w => w.PedidoId == pedido.PedidoId).FirstOrDefault();

                    entityPedido.CargoId = entityCargo.CargoId;
                    oContext.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                                 "ERP",
                                                 "CargoBusiness.GuardarCargoPedido",
                                                 ex);
                error = String.Format("Ocurrió un error inesperado con numero de identificación {0}",err);
            }

            return entityCargo;
        }


        public static ResultAPIModel ActualizarCargoPedido(ERPProdEntities oContext,
          int pedidoId,
           decimal total,         
           int usuarioId)
        {
            ResultAPIModel result = new ResultAPIModel();
            try
            {
                doc_cargos entityCargo = new doc_cargos();
                doc_cargos_detalle entityCargoDetalle = new doc_cargos_detalle();

                entityCargo = oContext.doc_cargos
                    .Where(w => w.doc_pedidos_orden.Where(s1 => s1.PedidoId == pedidoId && s1.Activo == true).Count() > 0).FirstOrDefault();

                if(entityCargo != null)
                {
                    entityCargo.Total = total;
                    oContext.SaveChanges();

                    entityCargoDetalle = oContext.doc_cargos_detalle.Where(w => w.CargoId == entityCargo.CargoId).FirstOrDefault();
                    entityCargoDetalle.Total = total;
                    entityCargoDetalle.Subtotal = total;
                    oContext.SaveChanges();

                    CalcularSaldos_Static(oContext, entityCargo.CargoId, 0);
                }

               

            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                                 "ERP",
                                                 "CargoBusiness.GuardarCargoPedido",
                                                 ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }

            return result;
        }

    }
}
