using ConexionBD.Models;
using ERP.Business;
using ERP.Models;
using ERP.Models.Pedidos;
using ERP.Reports;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DevExpress.XtraReports.UI;


namespace ConexionBD
{
    public class PedidoOrdenBusiness:BusinessObject
    {
        int err = 0;
        string error = "";
        ResultAPIModel result;
        private string validar(doc_pedidos_orden orden,
            doc_pedidos_orden_detalle ordenDetalle,
            int[] mesas, 
            int meseroId
            )
        {
            string error = "";
            try
            {
                int ordenId = orden.PedidoId;
                int sucursalid = orden.SucursalId;
               
                if (orden.Personas == 0)
                {
                    error = error + ".Indique el número de personas";
                }
                if (mesas.Count() == 0)
                {
                    error = error + "La mesa es requerida";
                }
                if (meseroId == 0)
                {
                    error = error + ". El mesero es requerido";
                }

                //Si es para llevar, solicitar nombre
                if (
                    (
                    oContext.doc_pedidos_orden_detalle
                    .Where(w => w.PedidoId == ordenId &&
                    w.Parallevar == true &&
                    (w.Cancelado ?? false) == false).Count() > 0
                    ||
                    (ordenDetalle == null ? false : ordenDetalle.Parallevar) == true
                    )
                    
                    &&
                    orden.Para.Length == 0
                    )
                {
                    error = error + ". Complete el campo PARA";

                }
                if (ordenDetalle != null)
                {
                    if (ordenDetalle.Cantidad == 0)
                    {
                        error = error + ". La cantidad debe de ser mayor a 0";
                    }
                    if (ordenDetalle.ProductoId == 0)
                    {
                        error = error + ". Seleccione un platillo";
                    }
                    else
                    {
                        int productoId = ordenDetalle.ProductoId;
                        

                        cat_productos_precios precio = oContext.cat_productos_precios
                            .Where(w => w.IdProducto == productoId &&
                            w.IdPrecio == (int)Enumerados.precios.publicoGral
                            ).FirstOrDefault();

                        if(precio == null)
                        {
                            error = error + ". No es posible agregar un producto sin precio";
                        }
                        else
                        {
                            if((precio.Precio)==0)
                            {
                                error = error + ". No es posible agregar un producto sin precio";
                            }
                        }
                    }

                    
                }
                if (orden.UberEats == true)
                {
                    doc_cargo_adicional_config entityCargo = oContext.doc_cargo_adicional_config
                        .Where(w => w.Activo == true && w.SucursalId == sucursalid && w.CargoAdicionalId == 1)
                        .FirstOrDefault();
                    if (entityCargo != null)
                    {
                        if(Utilerias.Nulos.IsNullDecimal( entityCargo.MontoFijo.ToString(),0) == 0
                            && Utilerias.Nulos.IsNullDecimal(entityCargo.PorcentajeVenta.ToString(), 0) == 0
                            )
                        {
                            error = error + ". No está configurado el cargo para UBER EATS";

                        }
                    }
                    else
                    {
                        error = error + ". No está configurado el cargo para UBER EATS";

                    }
                }

                //Validar que la mesa no esté ocupada en otra cuenta
                var resultmesaOcupada = oContext.cat_rest_mesas
                    .Where(
                        w => mesas.Contains(w.MesaId) &&
                        w.doc_pedidos_orden_mesa.Count > 0 &&
                        w.doc_pedidos_orden_mesa.Where(
                            p => p.doc_pedidos_orden.Activo &&
                            p.doc_pedidos_orden.PedidoId != ordenId
                            ).Count() > 0
                    ).Select(
                        s => new
                        {
                            MesaId = s.MesaId,
                            PedidoId = s.doc_pedidos_orden_mesa.FirstOrDefault().PedidoOrdenId,
                            Mesa = s.Nombre

                        }
                    ).ToList();

                foreach (var itemMesa in resultmesaOcupada)
                {
                    error = error + ". La mesa " + itemMesa.Mesa + " ya está ocupada en otra cuenta";
                }
                
                
            }
            catch (Exception ex)
            {

                error = ex.Message;
            }

            return error;
        }


        private string validarCompleto(doc_pedidos_orden orden,
           List<doc_pedidos_orden_detalle> ordenDetalle,
           int[] mesas,
           int meseroId
           )
        {
            string error = "";
            try
            {
                int ordenId = orden.PedidoId;
                int sucursalid = orden.SucursalId;

                if (orden.Personas == 0)
                {
                    error = error + ".Indique el número de personas";
                }
               
                

                //Si es para llevar, solicitar nombre
                foreach (var itemDet in ordenDetalle)
                {
                   /* if (
                   (
                   oContext.doc_pedidos_orden_detalle
                   .Where(w => w.PedidoId == ordenId &&
                   w.Parallevar == true &&
                   (w.Cancelado ?? false) == false).Count() > 0
                   ||
                   (ordenDetalle == null ? false : itemDet.Parallevar) == true
                   )

                   &&
                   orden.Para.Length == 0
                   )
                    {
                        error = error + ". Complete el campo PARA";

                    }
                    */
                    if (ordenDetalle.Count>0)
                    {
                        if (itemDet.Cantidad == 0)
                        {
                            error = error + ". La cantidad debe de ser mayor a 0";
                        }
                        if (itemDet.ProductoId == 0)
                        {
                            error = error + ". Seleccione un platillo";
                        }
                        else
                        {
                            int productoId = itemDet.ProductoId;


                            cat_productos_precios precio = oContext.cat_productos_precios
                                .Where(w => w.IdProducto == productoId &&
                                w.IdPrecio == (int)Enumerados.precios.publicoGral
                                ).FirstOrDefault();

                            if (precio == null)
                            {
                                error = error + ". No es posible agregar un producto sin precio";
                            }
                            else
                            {
                                if ((precio.Precio) == 0)
                                {
                                    error = error + ". No es posible agregar un producto sin precio";
                                }
                            }
                        }


                    }
                }
               
               
                if (orden.UberEats == true)
                {
                    doc_cargo_adicional_config entityCargo = oContext.doc_cargo_adicional_config
                        .Where(w => w.Activo == true && w.SucursalId == sucursalid && w.CargoAdicionalId == 1)
                        .FirstOrDefault();
                    if (entityCargo != null)
                    {
                        if (Utilerias.Nulos.IsNullDecimal(entityCargo.MontoFijo.ToString(), 0) == 0
                            && Utilerias.Nulos.IsNullDecimal(entityCargo.PorcentajeVenta.ToString(), 0) == 0
                            )
                        {
                            error = error + ". No está configurado el cargo para UBER EATS";

                        }
                    }
                    else
                    {
                        error = error + ". No está configurado el cargo para UBER EATS";

                    }
                }

                
              


            }
            catch (Exception ex)
            {

                error = ex.Message;
            }

            return error;
        }

        public string AgregarOrdenDetalle(ref doc_pedidos_orden orden, 
            ref doc_pedidos_orden_detalle ordenDetalle,
            int[] mesas, int meseroId,
            int[] SinIngredientesId,
            int[] adicionalesId,
            ref int comandaId,
            bool paraLlevar,
            PuntoVentaContext context)
        {
            int pedido = orden.PedidoId;
            int comandaId2 = comandaId;
            string error = "";
            bool esNuevo = orden.PedidoId > 0 ? false:true;
            try
            {
                error = validar(orden,ordenDetalle,mesas,meseroId);

                if(error.Length > 0)
                {
                    return error;
                }

                if(context.solicitarComanda && comandaId == 0)
                {
                    error = "La comanda es requerida";
                    return error;
                }
                if(
                    oContext.doc_pedidos_orden_detalle
                    .Where(
                        w=> w.ComandaId == comandaId2 &&
                        w.PedidoId != pedido
                    )
                    .Count() > 0                    
                    )
                    
                {
                    error = "La comanda no está disponible. Ya ha sido usada";
                    return error;
                }

                using (TransactionScope transactionScope = new TransactionScope())
                {
                    
                    #region encabezado
                    ObjectParameter pPedidoId = new ObjectParameter("pPedidoId", orden.PedidoId);

                    oContext.p_doc_pedidos_orden_insupd(pPedidoId, orden.SucursalId, orden.ComandaId, orden.PorcDescuento,
                        orden.Subtotal, orden.Descuento, orden.Impuestos, orden.Total, orden.ClienteId,
                        orden.MotivoCancelacion, orden.Activo, orden.CreadoPor, orden.Personas, orden.FechaApertura, orden.FechaCierre, orden.UberEats, orden.Para,null,null,
                        orden.TipoPedidoId,false);

                    orden.PedidoId = int.Parse(pPedidoId.Value.ToString());
                    #endregion

                    if (esNuevo)
                    {
                        #region mesas
                        oContext.p_doc_pedidos_orden_mesa_del(orden.PedidoId);

                        foreach (int itemMesa in mesas)
                        {
                            oContext.p_doc_pedidos_orden_mesa_ins(orden.PedidoId, itemMesa);
                        }
                        #endregion

                        #region meseros
                        oContext.p_doc_pedidos_orden_mesero_del(orden.PedidoId);

                        oContext.p_doc_pedidos_orden_mesero_ins(orden.PedidoId, meseroId);
                        #endregion
                    }


                    #region detalle

                    ObjectParameter pPedidoDetalleId = new ObjectParameter("pPedidoDetalleId", ordenDetalle.PedidoDetalleId);
                    ObjectParameter pComandaId = new ObjectParameter("pComandaId", comandaId);
                    ObjectParameter pError = new ObjectParameter("pError", "");
                    oContext.p_doc_pedidos_orden_detalle_insupd(pPedidoDetalleId, orden.PedidoId, ordenDetalle.ProductoId,
                        ordenDetalle.Cantidad, ordenDetalle.PrecioUnitario, ordenDetalle.PorcDescuento, ordenDetalle.Descuento, ordenDetalle.Impuestos,
                        ordenDetalle.Notas, ordenDetalle.Total, ordenDetalle.CreadoPor, ordenDetalle.TasaIVA, paraLlevar,pComandaId, ordenDetalle.TipoDescuentoId,"",pError);

                    if(pError.Value.ToString().Length > 0)
                    {
                        transactionScope.Dispose();
                        error = pError.Value.ToString();

                        return error;
                    }
                    ordenDetalle.PedidoDetalleId = int.Parse(pPedidoDetalleId.Value.ToString());
                    comandaId = int.Parse(pComandaId.Value.ToString());

                    #endregion                    

                    #region ingredientes
                    oContext.p_doc_pedidos_orden_ingre_del(orden.PedidoId);

                    foreach (int itemIng in SinIngredientesId)
                    {
                        oContext.p_doc_pedidos_orden_ingre_ins(ordenDetalle.PedidoDetalleId, itemIng, false, true, orden.CreadoPor);
                    }
                    #endregion

                    #region adicionales
                    oContext.p_doc_pedidos_orden_adicional_del(orden.PedidoId);

                    foreach (int itemAdic in adicionalesId)
                    {
                        oContext.p_doc_pedidos_orden_adicional_ins(ordenDetalle.PedidoDetalleId, itemAdic, orden.CreadoPor);
                    }
                    #endregion

                    transactionScope.Complete();
                }

                   
            }
            catch (Exception ex)
            {
                error = ex.Message;
                
            }

            return error;
        }


        public string GuardarOrdenCompleta(ref doc_pedidos_orden orden,
           ref List<doc_pedidos_orden_detalle> ordenDetalle,
           doc_pedidos_orden_programacion programacion,
           int[] mesas, int meseroId,
           int[] SinIngredientesId,
           int[] adicionalesId,
           ref int comandaId,
           bool paraLlevar,
           PuntoVentaContext context)
        {
            int pedido = orden.PedidoId;
            int comandaId2 = comandaId;
            string error = "";
            bool esNuevo = orden.PedidoId > 0 ? false : true;
            try
            {
                error = validarCompleto(orden, ordenDetalle, mesas, meseroId);

                if (error.Length > 0)
                {
                    return error;
                }

                if (context.solicitarComanda && comandaId == 0)
                {
                    error = "La comanda es requerida";
                    return error;
                }
                if (
                    oContext.doc_pedidos_orden_detalle
                    .Where(
                        w => w.ComandaId == comandaId2 &&
                        w.PedidoId != pedido
                    )
                    .Count() > 0
                    )

                {
                    error = "La comanda no está disponible. Ya ha sido usada";
                    return error;
                }

                using (TransactionScope transactionScope = new TransactionScope())
                {

                    #region encabezado
                    ObjectParameter pPedidoId = new ObjectParameter("pPedidoId", orden.PedidoId);

                    oContext.p_doc_pedidos_orden_insupd(pPedidoId, orden.SucursalId, orden.ComandaId, orden.PorcDescuento,
                        orden.Subtotal, orden.Descuento, orden.Impuestos, orden.Total, orden.ClienteId,
                        orden.MotivoCancelacion, orden.Activo, orden.CreadoPor, orden.Personas, orden.FechaApertura, orden.FechaCierre, orden.UberEats, orden.Para,orden.Notas,null,orden.TipoPedidoId,false);

                    orden.PedidoId = int.Parse(pPedidoId.Value.ToString());
                    #endregion

                    #region programacion

                    if(programacion.FechaProgramada.Year > 2000)
                    {
                        if (programacion.ClienteId == 0)
                        {
                            cat_clientes cliente = new cat_clientes();

                            cliente.ClienteId = (oContext.cat_clientes.Max(m => (int?)m.ClienteId) ?? 0) + 1;
                            cliente.Activo = true;
                            cliente.Nombre = programacion.cat_clientes.Nombre;
                            cliente.Telefono = programacion.cat_clientes.Telefono;

                            oContext.cat_clientes.Add(cliente);
                            oContext.SaveChanges();

                            programacion.cat_clientes = cliente;
                            programacion.ClienteId = cliente.ClienteId;
                        }
                        else
                        {
                            int clienteId = programacion.ClienteId;

                            cat_clientes clienteUpd = oContext.cat_clientes.Where(w => w.ClienteId == clienteId).FirstOrDefault();

                            clienteUpd.Nombre = programacion.cat_clientes.Nombre;
                            clienteUpd.Telefono = programacion.cat_clientes.Telefono;

                            oContext.SaveChanges();

                            programacion.cat_clientes = clienteUpd;
                            programacion.ClienteId = clienteId;
                        }


                        if(programacion.PedidoProgramacionId == 0)
                        {
                            doc_pedidos_orden_programacion entityPrognew = new doc_pedidos_orden_programacion();

                            entityPrognew.PedidoProgramacionId = (oContext.doc_pedidos_orden_programacion
                                .Max(m => (int?)m.PedidoProgramacionId) ?? 0) + 1;

                            entityPrognew.CreadoEl = 1;
                            entityPrognew.CreadoPor = context.usuarioId;
                            entityPrognew.PedidoId = orden.PedidoId;
                            entityPrognew.FechaProgramada = programacion.FechaProgramada.Date;
                            entityPrognew.HoraProgramada = programacion.HoraProgramada;
                            entityPrognew.ClienteId = programacion.ClienteId;
                            oContext.doc_pedidos_orden_programacion.Add(entityPrognew);
                            oContext.SaveChanges();

                            programacion = entityPrognew;
                        }
                        else
                        {
                            int pedidoProgramacionId = programacion.PedidoProgramacionId;
                            doc_pedidos_orden_programacion progUpd = oContext.doc_pedidos_orden_programacion
                                .Where(w => w.PedidoProgramacionId == pedidoProgramacionId).FirstOrDefault();

                            progUpd.FechaProgramada = programacion.FechaProgramada;
                            progUpd.HoraProgramada = programacion.HoraProgramada;

                            oContext.SaveChanges();

                        }

                    }

                    



                    #endregion

                    if (esNuevo)
                    {
                        #region mesas
                        oContext.p_doc_pedidos_orden_mesa_del(orden.PedidoId);

                        if(mesas != null)
                        {
                            foreach (int itemMesa in mesas)
                            {
                                oContext.p_doc_pedidos_orden_mesa_ins(orden.PedidoId, itemMesa);
                            }
                        }
                        
                        #endregion

                        #region meseros
                        oContext.p_doc_pedidos_orden_mesero_del(orden.PedidoId);

                        if(meseroId > 0)
                        {

                            oContext.p_doc_pedidos_orden_mesero_ins(orden.PedidoId, meseroId);
                        }

                        #endregion
                    }


                    #region detalle

                   

                    int id = 0;
                    
                    foreach (var itemDet in ordenDetalle)
                    {
                        ObjectParameter pPedidoDetalleId = new ObjectParameter("pPedidoDetalleId", itemDet.PedidoDetalleId);
                        ObjectParameter pComandaId = new ObjectParameter("pComandaId", comandaId);
                        ObjectParameter pError = new ObjectParameter("pError", "");

                        oContext.p_doc_pedidos_orden_detalle_insupd(pPedidoDetalleId, orden.PedidoId, itemDet.ProductoId,
                      itemDet.Cantidad, itemDet.PrecioUnitario, itemDet.PorcDescuento, itemDet.Descuento, itemDet.Impuestos,
                      itemDet.Notas, itemDet.Total, itemDet.CreadoPor, itemDet.TasaIVA, itemDet.Parallevar, pComandaId, 
                      itemDet.TipoDescuentoId,itemDet.Descripcion, pError);

                        if (pError.Value.ToString().Length > 0)
                        {
                            transactionScope.Dispose();
                            error = pError.Value.ToString();

                            return error;
                        }
                        ordenDetalle[id].PedidoDetalleId = int.Parse(pPedidoDetalleId.Value.ToString());

                        comandaId = comandaId > 0 ? comandaId : int.Parse(pComandaId.Value.ToString());


                        #region ingredientes
                        oContext.p_doc_pedidos_orden_ingre_del(orden.PedidoId);

                        foreach (int itemIng in SinIngredientesId)
                        {
                            oContext.p_doc_pedidos_orden_ingre_ins(ordenDetalle[id].PedidoDetalleId, itemIng, false, true, orden.CreadoPor);
                        }
                        #endregion


                        #region adicionales
                        oContext.p_doc_pedidos_orden_adicional_del(orden.PedidoId);

                        foreach (int itemAdic in adicionalesId)
                        {
                            oContext.p_doc_pedidos_orden_adicional_ins(ordenDetalle[id].PedidoDetalleId, itemAdic, orden.CreadoPor);
                        }
                        #endregion

                        id++;
                    }
                  
                  

                    #endregion                    

                  

                  

                    transactionScope.Complete();
                }


            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(context.usuarioId,
                      "ERP",
                      "PedidoOrdenBusiness",
                      ex);

                programacion.PedidoProgramacionId = 0;
                error = "Ocurrió un error inesperado, revise el registro de bitácora ["+err+"]";

            }

            return error;
        }



        public string GuardarPedidoCliente(ref doc_pedidos_orden orden,
          ref List<doc_pedidos_orden_detalle> ordenDetalle,
          doc_pedidos_orden_programacion programacion,
          PuntoVentaContext context)
        {
            int pedido = orden.PedidoId;
            
            string error = "";
            bool esNuevo = orden.PedidoId > 0 ? false : true;
            try
            {
                error = validarCompleto(orden, ordenDetalle, null, 0);

                if (error.Length > 0)
                {
                    return error;
                }

               

                using (TransactionScope transactionScope = new TransactionScope())
                {

                    #region encabezado
                    ObjectParameter pPedidoId = new ObjectParameter("pPedidoId", orden.PedidoId);

                    oContext.p_doc_pedidos_orden_insupd(pPedidoId, orden.SucursalId, orden.ComandaId, orden.PorcDescuento,
                        orden.Subtotal, orden.Descuento, orden.Impuestos, orden.Total, orden.ClienteId,
                        orden.MotivoCancelacion, orden.Activo, orden.CreadoPor, orden.Personas, orden.FechaApertura, orden.FechaCierre, orden.UberEats, orden.Para, orden.Notas, null,
                        orden.TipoPedidoId,false);

                    orden.PedidoId = int.Parse(pPedidoId.Value.ToString());
                    #endregion

                    #region programacion

                    if (programacion.FechaProgramada.Year > 2000)
                    {
                        if (programacion.ClienteId == 0)
                        {
                            cat_clientes cliente = new cat_clientes();

                            cliente.ClienteId = (oContext.cat_clientes.Max(m => (int?)m.ClienteId) ?? 0) + 1;
                            cliente.Activo = true;
                            cliente.Nombre = programacion.cat_clientes.Nombre;
                            cliente.Telefono = programacion.cat_clientes.Telefono;

                            oContext.cat_clientes.Add(cliente);
                            oContext.SaveChanges();

                            programacion.cat_clientes = cliente;
                            programacion.ClienteId = cliente.ClienteId;
                        }
                        else
                        {
                            int clienteId = programacion.ClienteId;

                            cat_clientes clienteUpd = oContext.cat_clientes.Where(w => w.ClienteId == clienteId).FirstOrDefault();

                            clienteUpd.Nombre = programacion.cat_clientes.Nombre;
                            clienteUpd.Telefono = programacion.cat_clientes.Telefono;

                            oContext.SaveChanges();

                            programacion.cat_clientes = clienteUpd;
                            programacion.ClienteId = clienteId;
                        }


                        if (programacion.PedidoProgramacionId == 0)
                        {
                            doc_pedidos_orden_programacion entityPrognew = new doc_pedidos_orden_programacion();

                            entityPrognew.PedidoProgramacionId = (oContext.doc_pedidos_orden_programacion
                                .Max(m => (int?)m.PedidoProgramacionId) ?? 0) + 1;

                            entityPrognew.CreadoEl = 1;
                            entityPrognew.CreadoPor = context.usuarioId;
                            entityPrognew.PedidoId = orden.PedidoId;
                            entityPrognew.FechaProgramada = programacion.FechaProgramada.Date;
                            entityPrognew.HoraProgramada = programacion.HoraProgramada;
                            entityPrognew.ClienteId = programacion.ClienteId;
                            oContext.doc_pedidos_orden_programacion.Add(entityPrognew);
                            oContext.SaveChanges();

                            programacion = entityPrognew;
                        }
                        else
                        {
                            int pedidoProgramacionId = programacion.PedidoProgramacionId;
                            doc_pedidos_orden_programacion progUpd = oContext.doc_pedidos_orden_programacion
                                .Where(w => w.PedidoProgramacionId == pedidoProgramacionId).FirstOrDefault();

                            progUpd.FechaProgramada = programacion.FechaProgramada;
                            progUpd.HoraProgramada = programacion.HoraProgramada;

                            oContext.SaveChanges();

                        }

                    }

                    #endregion


                    #region detalle



                    int id = 0;

                    foreach (var itemDet in ordenDetalle)
                    {
                        ObjectParameter pPedidoDetalleId = new ObjectParameter("pPedidoDetalleId", itemDet.PedidoDetalleId);
                        ObjectParameter pComandaId = new ObjectParameter("pComandaId", null);
                        ObjectParameter pError = new ObjectParameter("pError", "");

                        oContext.p_doc_pedidos_orden_detalle_insupd(pPedidoDetalleId, orden.PedidoId, itemDet.ProductoId,
                      itemDet.Cantidad, itemDet.PrecioUnitario, itemDet.PorcDescuento, itemDet.Descuento, itemDet.Impuestos,
                      itemDet.Notas, itemDet.Total, itemDet.CreadoPor, itemDet.TasaIVA, itemDet.Parallevar, pComandaId,
                      itemDet.TipoDescuentoId, itemDet.Descripcion, pError);

                        if (pError.Value.ToString().Length > 0)
                        {
                            transactionScope.Dispose();
                            error = pError.Value.ToString();

                            return error;
                        }
                        ordenDetalle[id].PedidoDetalleId = int.Parse(pPedidoDetalleId.Value.ToString());

                    

                        id++;
                    }



                    #endregion





                    transactionScope.Complete();
                }


            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(context.usuarioId,
                      "ERP",
                      "PedidoOrdenBusiness",
                      ex);

                programacion.PedidoProgramacionId = 0;
                error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err + "]";

            }

            return error;
        }


        public string GuardarCuentaEnc(ref doc_pedidos_orden orden,
             int[] mesas, int meseroId)
        {
            string error = "";
            try
            {
                error = validar(orden, null, mesas, meseroId);

                if (error.Length > 0)
                {
                    return error;
                }

                using (TransactionScope transactionScope = new TransactionScope())
                {

                    
                        #region encabezado
                        ObjectParameter pPedidoId = new ObjectParameter("pPedidoId", orden.PedidoId);

                        oContext.p_doc_pedidos_orden_insupd(pPedidoId, orden.SucursalId, orden.ComandaId, orden.PorcDescuento,
                            orden.Subtotal, orden.Descuento, orden.Impuestos, orden.Total, orden.ClienteId,
                            orden.MotivoCancelacion, orden.Activo, orden.CreadoPor, orden.Personas, orden.FechaApertura, orden.FechaCierre,orden.UberEats,orden.Para,orden.Notas,null,
                            orden.TipoPedidoId,false);

                        orden.PedidoId = int.Parse(pPedidoId.Value.ToString());
                        #endregion

                        #region mesas
                        oContext.p_doc_pedidos_orden_mesa_del(orden.PedidoId);

                        foreach (int itemMesa in mesas)
                        {
                            oContext.p_doc_pedidos_orden_mesa_ins(orden.PedidoId, itemMesa);
                        }
                        #endregion

                        #region meseros
                        oContext.p_doc_pedidos_orden_mesero_del(orden.PedidoId);

                        oContext.p_doc_pedidos_orden_mesero_ins(orden.PedidoId, meseroId);
                        #endregion
                    


                    transactionScope.Complete();
                }


            }
            catch (Exception ex)
            {
                error = ex.Message;

            }

            return error;
        }
            


        public string buscarCuenta(int[] mesas, int comandaId, ref int pedidoId)
        {
            string error = "";
            try
            {
                #region validar
                if(mesas.Length == 0)
                {
                    error = "La mesa es requerida";
                }
                #endregion

                string mesasId = "";
                foreach (var item in mesas)
                {
                    mesasId = mesasId + item.ToString() + ",";
                }


                var result = oContext.p_doc_pedidos_orden_buscar(mesasId, comandaId).FirstOrDefault();

                if(result != null)
                {
                    pedidoId = result.Value;
                }
            }
            catch (Exception ex)
            {

                error = "Ocurrió un error al buscar la cuenta";
            }
            return error;
        }


        #region pedidos-pagos



        public string GuardarPedidoAnticipo(ref doc_pedidos_orden orden,
           ref List<doc_pedidos_orden_detalle> ordenDetalle,
           doc_pedidos_orden_programacion programacion,
           int[] mesas, int meseroId,
           int[] SinIngredientesId,
           int[] adicionalesId,
           ref int comandaId,
           bool paraLlevar,
           decimal montoAnticipo,
           ref int pagoId,
           PuntoVentaContext context)
        {
            int pedido = orden.PedidoId;
            int comandaId2 = comandaId;
            string error = "";
            bool esNuevo = orden.PedidoId > 0 ? false : true;
            DateTime fechaActual;
            try
            {
                CargoBusiness oCargo = new CargoBusiness();
                error = validarCompleto(orden, ordenDetalle, mesas, meseroId);

                if (error.Length > 0)
                {
                    return error;
                }

                doc_cargos cargoEntity = new doc_cargos();

                using (TransactionScope transactionScope = new TransactionScope())
                {

                    fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                    if ((orden.CargoId ??0)== 0)
                    {
                       
                        #region cargos
                       
                        cargoEntity.CargoId = (oContext.doc_cargos.Max(m => (int?)m.CargoId) ?? 0) + 1;
                        cargoEntity.Activo = true;
                        cargoEntity.ClienteId = orden.ClienteId ?? 0;
                        cargoEntity.CreadoPor = context.usuarioId;
                        cargoEntity.CredoEl = fechaActual;
                        cargoEntity.Descuento = 0;
                        cargoEntity.Saldo = ordenDetalle.Sum(s => s.Total) - montoAnticipo;
                        cargoEntity.Total = ordenDetalle.Sum(s => s.Total);
                        cargoEntity.Descripcion = "PEDIDO PARA:"+fechaActual.ToShortDateString();
                        oContext.doc_cargos.Add(cargoEntity);
                        oContext.SaveChanges();

                        #endregion

                        #region cargos detralle

                        //Cargo anticipo
                        doc_cargos_detalle cargoEntityDet = new doc_cargos_detalle();

                        cargoEntityDet.CargoDetalleId = (oContext.doc_cargos_detalle.Max(m => (int?)m.CargoDetalleId) ?? 0) + 1;
                        cargoEntityDet.CargoId = cargoEntity.CargoId;
                        cargoEntityDet.CreadoEl = fechaActual;
                        cargoEntityDet.Descuento = 0;
                        cargoEntityDet.FechaCargo = fechaActual.Date;
                        cargoEntityDet.FechaPago = fechaActual;
                        cargoEntityDet.Saldo = 0;
                        cargoEntityDet.Total = montoAnticipo;

                        oContext.doc_cargos_detalle.Add(cargoEntityDet);
                        oContext.SaveChanges();

                        //cargo por lo restante
                        cargoEntityDet = new doc_cargos_detalle();

                        cargoEntityDet.CargoDetalleId = (oContext.doc_cargos_detalle.Max(m => (int?)m.CargoDetalleId) ?? 0) + 1;
                        cargoEntityDet.CargoId = cargoEntity.CargoId;
                        cargoEntityDet.CreadoEl = fechaActual;
                        cargoEntityDet.Descuento = 0;
                        cargoEntityDet.FechaCargo = programacion.FechaProgramada;
                        cargoEntityDet.FechaPago = null;
                        cargoEntityDet.Saldo = ordenDetalle.Sum(s => s.Total) - montoAnticipo;
                        cargoEntityDet.Total = cargoEntityDet.Saldo??0;

                        oContext.doc_cargos_detalle.Add(cargoEntityDet);
                        oContext.SaveChanges();

                        

                        #endregion

                        #region pago
                        doc_pagos pagoEntity = new doc_pagos();

                        pagoEntity.PagoId = (oContext.doc_pagos.Max(m => (int?)m.PagoId) ?? 0) + 1;
                        pagoEntity.Activo = true;
                        pagoEntity.CargoId = cargoEntity.CargoId;
                        pagoEntity.ClienteId = orden.ClienteId??0;
                        pagoEntity.CreadoEl = fechaActual;
                        pagoEntity.CreadoPor = context.usuarioId;
                        pagoEntity.FechaPago = fechaActual;
                        pagoEntity.FormaPagoId = 1; //Efectivo
                        pagoEntity.Monto = montoAnticipo;

                        oContext.doc_pagos.Add(pagoEntity);
                        oContext.SaveChanges();
                        pagoId = pagoEntity.PagoId;
                        #endregion

                        orden.doc_cargos = cargoEntity;
                        orden.doc_cargos.doc_pagos.Add(pagoEntity);


                    }                    
                    else
                    {
                        doc_pagos pagoEntity = new doc_pagos();

                        pagoEntity.PagoId = (oContext.doc_pagos.Max(m => (int?)m.PagoId) ?? 0) + 1;
                        pagoEntity.Activo = true;
                        pagoEntity.CargoId = orden.CargoId;
                        pagoEntity.ClienteId = orden.ClienteId ?? 0;
                        pagoEntity.CreadoEl = fechaActual;
                        pagoEntity.CreadoPor = context.usuarioId;
                        pagoEntity.FechaPago = fechaActual;
                        pagoEntity.FormaPagoId = 1; //Efectivo
                        pagoEntity.Monto = montoAnticipo;

                        oContext.doc_pagos.Add(pagoEntity);
                        oContext.SaveChanges();
                        pagoId = pagoEntity.PagoId;
                        ResultAPIModel result = oCargo.CalcularSaldosPagos(orden.CargoId??0);

                        if (!result.ok)
                        {
                            return result.error;
                        }
                    }
                    



                    #region encabezado
                    ObjectParameter pPedidoId = new ObjectParameter("pPedidoId", orden.PedidoId);

                    oContext.p_doc_pedidos_orden_insupd(pPedidoId, orden.SucursalId, orden.ComandaId, orden.PorcDescuento,
                        orden.Subtotal, orden.Descuento, orden.Impuestos, orden.Total, orden.ClienteId,
                        orden.MotivoCancelacion, orden.Activo, orden.CreadoPor, orden.Personas, orden.FechaApertura, orden.FechaCierre, orden.UberEats, orden.Para, orden.Notas,cargoEntity.CargoId,
                        orden.TipoPedidoId,false);

                    orden.PedidoId = int.Parse(pPedidoId.Value.ToString());
                    #endregion

                    #region programacion

                    if (programacion.FechaProgramada.Year > 2000)
                    {
                        if (programacion.ClienteId == 0)
                        {
                            cat_clientes cliente = new cat_clientes();

                            cliente.ClienteId = (oContext.cat_clientes.Max(m => (int?)m.ClienteId) ?? 0) + 1;
                            cliente.Activo = true;
                            cliente.Nombre = programacion.cat_clientes.Nombre;
                            cliente.Telefono = programacion.cat_clientes.Telefono;

                            oContext.cat_clientes.Add(cliente);
                            oContext.SaveChanges();

                            programacion.cat_clientes = cliente;
                            programacion.ClienteId = cliente.ClienteId;
                        }
                        else
                        {
                            int clienteId = programacion.ClienteId;

                            cat_clientes clienteUpd = oContext.cat_clientes.Where(w => w.ClienteId == clienteId).FirstOrDefault();

                            clienteUpd.Nombre = programacion.cat_clientes.Nombre;
                            clienteUpd.Telefono = programacion.cat_clientes.Telefono;

                            oContext.SaveChanges();

                            programacion.cat_clientes = clienteUpd;
                            programacion.ClienteId = clienteId;
                        }


                        if (programacion.PedidoProgramacionId == 0)
                        {
                            doc_pedidos_orden_programacion entityPrognew = new doc_pedidos_orden_programacion();

                            entityPrognew.PedidoProgramacionId = (oContext.doc_pedidos_orden_programacion
                                .Max(m => (int?)m.PedidoProgramacionId) ?? 0) + 1;

                            entityPrognew.CreadoEl = 1;
                            entityPrognew.CreadoPor = context.usuarioId;
                            entityPrognew.PedidoId = orden.PedidoId;
                            entityPrognew.FechaProgramada = programacion.FechaProgramada.Date;
                            entityPrognew.HoraProgramada = programacion.HoraProgramada;
                            entityPrognew.ClienteId = programacion.ClienteId;
                            oContext.doc_pedidos_orden_programacion.Add(entityPrognew);
                            oContext.SaveChanges();

                            programacion = entityPrognew;
                        }
                        else
                        {
                            int pedidoProgramacionId = programacion.PedidoProgramacionId;
                            doc_pedidos_orden_programacion progUpd = oContext.doc_pedidos_orden_programacion
                                .Where(w => w.PedidoProgramacionId == pedidoProgramacionId).FirstOrDefault();

                            progUpd.FechaProgramada = programacion.FechaProgramada;
                            progUpd.HoraProgramada = programacion.HoraProgramada;

                            oContext.SaveChanges();

                        }

                    }





                    #endregion

                    if (esNuevo)
                    {
                        #region mesas
                        oContext.p_doc_pedidos_orden_mesa_del(orden.PedidoId);

                        if (mesas != null)
                        {
                            foreach (int itemMesa in mesas)
                            {
                                oContext.p_doc_pedidos_orden_mesa_ins(orden.PedidoId, itemMesa);
                            }
                        }

                        #endregion

                        #region meseros
                        oContext.p_doc_pedidos_orden_mesero_del(orden.PedidoId);

                        if (meseroId > 0)
                        {

                            oContext.p_doc_pedidos_orden_mesero_ins(orden.PedidoId, meseroId);
                        }

                        #endregion
                    }


                    #region detalle



                    int id = 0;

                    foreach (var itemDet in ordenDetalle)
                    {
                        ObjectParameter pPedidoDetalleId = new ObjectParameter("pPedidoDetalleId", itemDet.PedidoDetalleId);
                        ObjectParameter pComandaId = new ObjectParameter("pComandaId", comandaId);
                        ObjectParameter pError = new ObjectParameter("pError", "");

                        oContext.p_doc_pedidos_orden_detalle_insupd(pPedidoDetalleId, orden.PedidoId, itemDet.ProductoId,
                      itemDet.Cantidad, itemDet.PrecioUnitario, itemDet.PorcDescuento, itemDet.Descuento, itemDet.Impuestos,
                      itemDet.Notas, itemDet.Total, itemDet.CreadoPor, itemDet.TasaIVA, itemDet.Parallevar, pComandaId,
                      itemDet.TipoDescuentoId, itemDet.Descripcion, pError);

                        if (pError.Value.ToString().Length > 0)
                        {
                            transactionScope.Dispose();
                            error = pError.Value.ToString();

                            return error;
                        }
                        ordenDetalle[id].PedidoDetalleId = int.Parse(pPedidoDetalleId.Value.ToString());

                        comandaId = comandaId > 0 ? comandaId : int.Parse(pComandaId.Value.ToString());


                        #region ingredientes
                        oContext.p_doc_pedidos_orden_ingre_del(orden.PedidoId);

                        foreach (int itemIng in SinIngredientesId)
                        {
                            oContext.p_doc_pedidos_orden_ingre_ins(ordenDetalle[id].PedidoDetalleId, itemIng, false, true, orden.CreadoPor);
                        }
                        #endregion


                        #region adicionales
                        oContext.p_doc_pedidos_orden_adicional_del(orden.PedidoId);

                        foreach (int itemAdic in adicionalesId)
                        {
                            oContext.p_doc_pedidos_orden_adicional_ins(ordenDetalle[id].PedidoDetalleId, itemAdic, orden.CreadoPor);
                        }
                        #endregion

                        id++;
                    }



                    #endregion

                    orden.CargoId = (orden.CargoId??0) == 0 ? cargoEntity.CargoId : orden.CargoId;

                    transactionScope.Complete();
                }


            }
            catch (Exception ex)
            {

                programacion.PedidoProgramacionId = 0;
                pagoId = 0;
                error = ex.Message;

            }

            return error;
        }


        #endregion


        public string GuardarPedido(ref doc_pedidos_orden orden,
         ref List<doc_pedidos_orden_detalle> ordenDetalle,
         doc_pedidos_orden_programacion programacion,
         int[] mesas, int meseroId,
         int[] SinIngredientesId,
         int[] adicionalesId,
         ref int comandaId,
         bool paraLlevar,
         PuntoVentaContext context)
        {
            int pedido = orden.PedidoId;
            int comandaId2 = comandaId;
            string error = "";
            bool esNuevo = orden.PedidoId > 0 ? false : true;
            DateTime fechaActual;
            try
            {
                CargoBusiness oCargo = new CargoBusiness();
                error = validarCompleto(orden, ordenDetalle, mesas, meseroId);

                if (error.Length > 0)
                {
                    return error;
                }

                doc_cargos cargoEntity = new doc_cargos();

                using (TransactionScope transactionScope = new TransactionScope())
                {

                    fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                    #region encabezado
                    ObjectParameter pPedidoId = new ObjectParameter("pPedidoId", orden.PedidoId);

                    oContext.p_doc_pedidos_orden_insupd(pPedidoId, orden.SucursalId, orden.ComandaId, orden.PorcDescuento,
                        orden.Subtotal, orden.Descuento, orden.Impuestos, orden.Total, orden.ClienteId,
                        orden.MotivoCancelacion, orden.Activo, orden.CreadoPor, orden.Personas, orden.FechaApertura, orden.FechaCierre, orden.UberEats, orden.Para, orden.Notas, null,
                        orden.TipoPedidoId,false);

                    orden.PedidoId = int.Parse(pPedidoId.Value.ToString());
                    #endregion

                    #region programacion

                    if (programacion.FechaProgramada.Year > 2000)
                    {
                        if (programacion.ClienteId == 0)
                        {
                            cat_clientes cliente = new cat_clientes();

                            cliente.ClienteId = (oContext.cat_clientes.Max(m => (int?)m.ClienteId) ?? 0) + 1;
                            cliente.Activo = true;
                            cliente.Nombre = programacion.cat_clientes.Nombre;
                            cliente.Telefono = programacion.cat_clientes.Telefono;

                            oContext.cat_clientes.Add(cliente);
                            oContext.SaveChanges();

                            programacion.cat_clientes = cliente;
                            programacion.ClienteId = cliente.ClienteId;
                        }
                        else
                        {
                            int clienteId = programacion.ClienteId;

                            cat_clientes clienteUpd = oContext.cat_clientes.Where(w => w.ClienteId == clienteId).FirstOrDefault();

                            clienteUpd.Nombre = programacion.cat_clientes.Nombre;
                            clienteUpd.Telefono = programacion.cat_clientes.Telefono;

                            oContext.SaveChanges();

                            programacion.cat_clientes = clienteUpd;
                            programacion.ClienteId = clienteId;
                        }


                        if (programacion.PedidoProgramacionId == 0)
                        {
                            doc_pedidos_orden_programacion entityPrognew = new doc_pedidos_orden_programacion();

                            entityPrognew.PedidoProgramacionId = (oContext.doc_pedidos_orden_programacion
                                .Max(m => (int?)m.PedidoProgramacionId) ?? 0) + 1;

                            entityPrognew.CreadoEl = 1;
                            entityPrognew.CreadoPor = context.usuarioId;
                            entityPrognew.PedidoId = orden.PedidoId;
                            entityPrognew.FechaProgramada = programacion.FechaProgramada.Date;
                            entityPrognew.HoraProgramada = programacion.HoraProgramada;
                            entityPrognew.ClienteId = programacion.ClienteId;
                            oContext.doc_pedidos_orden_programacion.Add(entityPrognew);
                            oContext.SaveChanges();

                            programacion = entityPrognew;
                        }
                        else
                        {
                            int pedidoProgramacionId = programacion.PedidoProgramacionId;
                            doc_pedidos_orden_programacion progUpd = oContext.doc_pedidos_orden_programacion
                                .Where(w => w.PedidoProgramacionId == pedidoProgramacionId).FirstOrDefault();

                            progUpd.FechaProgramada = programacion.FechaProgramada;
                            progUpd.HoraProgramada = programacion.HoraProgramada;

                            oContext.SaveChanges();

                        }

                    }





                    #endregion

                    if (esNuevo)
                    {
                        #region mesas
                        oContext.p_doc_pedidos_orden_mesa_del(orden.PedidoId);

                        if (mesas != null)
                        {
                            foreach (int itemMesa in mesas)
                            {
                                oContext.p_doc_pedidos_orden_mesa_ins(orden.PedidoId, itemMesa);
                            }
                        }

                        #endregion

                        #region meseros
                        oContext.p_doc_pedidos_orden_mesero_del(orden.PedidoId);

                        if (meseroId > 0)
                        {

                            oContext.p_doc_pedidos_orden_mesero_ins(orden.PedidoId, meseroId);
                        }

                        #endregion
                    }


                    #region detalle



                    int id = 0;

                    foreach (var itemDet in ordenDetalle)
                    {
                        ObjectParameter pPedidoDetalleId = new ObjectParameter("pPedidoDetalleId", itemDet.PedidoDetalleId);
                        ObjectParameter pComandaId = new ObjectParameter("pComandaId", comandaId);
                        ObjectParameter pError = new ObjectParameter("pError", "");

                        oContext.p_doc_pedidos_orden_detalle_insupd(pPedidoDetalleId, orden.PedidoId, itemDet.ProductoId,
                      itemDet.Cantidad, itemDet.PrecioUnitario, itemDet.PorcDescuento, itemDet.Descuento, itemDet.Impuestos,
                      itemDet.Notas, itemDet.Total, itemDet.CreadoPor, itemDet.TasaIVA, itemDet.Parallevar, pComandaId,
                      itemDet.TipoDescuentoId, itemDet.Descripcion, pError);

                        if (pError.Value.ToString().Length > 0)
                        {
                            transactionScope.Dispose();
                            error = pError.Value.ToString();

                            return error;
                        }
                        ordenDetalle[id].PedidoDetalleId = int.Parse(pPedidoDetalleId.Value.ToString());

                        comandaId = comandaId > 0 ? comandaId : int.Parse(pComandaId.Value.ToString());


                        #region ingredientes
                        oContext.p_doc_pedidos_orden_ingre_del(orden.PedidoId);

                        foreach (int itemIng in SinIngredientesId)
                        {
                            oContext.p_doc_pedidos_orden_ingre_ins(ordenDetalle[id].PedidoDetalleId, itemIng, false, true, orden.CreadoPor);
                        }
                        #endregion


                        #region adicionales
                        oContext.p_doc_pedidos_orden_adicional_del(orden.PedidoId);

                        foreach (int itemAdic in adicionalesId)
                        {
                            oContext.p_doc_pedidos_orden_adicional_ins(ordenDetalle[id].PedidoDetalleId, itemAdic, orden.CreadoPor);
                        }
                        #endregion

                        id++;
                    }



                    #endregion

                    orden.CargoId = (orden.CargoId ?? 0) == 0 ? cargoEntity.CargoId : orden.CargoId;

                    transactionScope.Complete();
                }


            }
            catch (Exception ex)
            {

                programacion.PedidoProgramacionId = 0;
               
                error = ex.Message;

            }

            return error;
        }



        public static decimal ObtenerCantidadPendienteBascula(int pedidoDetalleId,int usuarioId)
        {
            decimal result=0;
            try
            {
                ERPProdEntities oContext = new ERPProdEntities();

               doc_pedidos_orden_detalle pedidoDetalle = oContext.doc_pedidos_orden_detalle
                    .Where(w => w.PedidoDetalleId == pedidoDetalleId)
                    .FirstOrDefault();

                if(pedidoDetalle!= null)
                {
                    if(pedidoDetalle.cat_productos.ProdVtaBascula == true)
                    {
                        result = pedidoDetalle.Cantidad - (pedidoDetalle.doc_basculas_bitacora.Sum(s => (decimal?)s.Cantidad) ?? 0);
                    }
                }

                return result <0 ? 0 :result;
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                    "ERP",
                                    "InventarioBusiness.Guardar",
                                    ex);

               
            }

            return result;
        }

        public static decimal ObtenerCantidadRegistradaEnBascula(int pedidoDetalleId, int usuarioId)
        {
            decimal result = 0;
            try
            {
                ERPProdEntities oContext = new ERPProdEntities();

                doc_pedidos_orden_detalle pedidoDetalle = oContext.doc_pedidos_orden_detalle
                     .Where(w => w.PedidoDetalleId == pedidoDetalleId)
                     .FirstOrDefault();

                if (pedidoDetalle != null)
                {
                    if (pedidoDetalle.cat_productos.ProdVtaBascula == true)
                    {
                        result = (pedidoDetalle.doc_basculas_bitacora.Sum(s => (decimal?)s.Cantidad) ?? 0);
                    }
                }

                return result ;
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                    "ERP",
                                    "InventarioBusiness.Guardar",
                                    ex);


            }

            return result;
        }

        public static string ObtenerEstado(doc_pedidos_orden pedido)
        {
            if (pedido == null)
            {
                return "Sin Registro";
            }
            if (pedido.Cancelada == true)
            {
                return "Cancelado";
            }

            
            if (
              pedido.VentaId > 0
           )
            {
                return "Pagado";
            }

            if(pedido.doc_cargos != null)
            {
                if (pedido.doc_cargos.Saldo == 0)
                {
                    return "Pagado";
                }

                if (pedido.doc_cargos.Saldo < pedido.doc_cargos.Total && pedido.doc_cargos.Saldo > 0)
                {
                    return "Pagado Parcialmente";
                }
            }
            
            

            if(pedido.doc_pedidos_cargos.Count() > 0)
            {
                return "Cargo Generado";
            }

            if (
                pedido.doc_pedidos_orden_detalle
                .Where(w => w.doc_basculas_bitacora.Sum(s => s.Cantidad) < w.Cantidad && w.cat_productos.ProdVtaBascula == true).Count() == 0
             )
            {
                return "Listo Para Entrega";
            }
            if (
                pedido.doc_pedidos_orden_detalle
                .Where(w=> w.doc_basculas_bitacora.Sum(s=> s.Cantidad) < w.Cantidad && w.cat_productos.ProdVtaBascula == true).Count() > 0
             )
            {
                return "Registrado";
            }



           

            return "Sin Definir";
        }

        public string CancelarPedido(int pedidoId, int usuarioId)
        {
            string error = "";
            try
            {
                doc_pedidos_orden pedidoUpd = oContext.doc_pedidos_orden
                           .Where(w => w.PedidoId == pedidoId).FirstOrDefault();

               if(pedidoUpd.Cancelada == true)
                {
                    return "El pedido ya está cancelado";
                }
               if(oContext.doc_pagos
                    .Where(
                   w=> w.Activo == true &&
                   w.doc_cargos.doc_pedidos_orden.Where(s1=> s1.PedidoId == pedidoId).Count() > 0

                    ).Count() > 0)
                {
                    return "El pedido tiene pagos registrados, no es posible cancelar";
                }

                pedidoUpd.Activo = false;
                pedidoUpd.FechaCancelacion = DateTime.Now;
                pedidoUpd.Cancelada = true;
                pedidoUpd.CanceladoPor = usuarioId;

                oContext.SaveChanges();

                return "";
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                     "ERP",
                                     "InventarioBusiness.Guardar",
                                     ex);

                error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

            }

            return error;
        }

        public string ObtenerFolio(ERP.Business.Enumerados.tipoPedido tipoPedido,int sucursalId)
        {
            string folio = "";

                folio=(oContext.doc_pedidos_orden
                    .Where(w => w.SucursalId == sucursalId && w.TipoPedidoId == (int)tipoPedido).Count() + 1).ToString();
           

           return folio;
        }

        public static string ObtenerFolioPorTipo(ERP.Business.Enumerados.tipoPedido tipoPedido, int sucursalId)
        {
            string folio = "";
            ERPProdEntities oContext = new ERPProdEntities();
            folio = (oContext.doc_pedidos_orden
                .Where(w => w.SucursalId == sucursalId && w.TipoPedidoId == (int)tipoPedido).Count() + 1).ToString();


            return folio;
        }

        public doc_pedidos_orden GuardarPedido(
            doc_pedidos_orden pedidoParam,             
            ERP.Business.Enumerados.tipoPedido tipoPedido,
            List<ProductoModel0> lstProductos,
            int usuarioId,
            int sucursalId,
            ref string error)
        {
            error = "";

            doc_pedidos_orden pedido = new doc_pedidos_orden();
            doc_cargos entityCargo = null;
            doc_cargos_detalle entityCargoDetalle = null;
            doc_pedidos_orden_detalle pedidoDetalle = new doc_pedidos_orden_detalle();
            try
            {
                
                #region validaciones
                if((pedidoParam.ClienteId == null?0 : pedidoParam.ClienteId) <=0)
                {
                    error = "El cliente es requerido";                    
                }
                if(lstProductos.Count() == 0)
                {
                    error = error + "| No hay productos en el listado";
                }

                if(error.Length > 0)
                {
                    return pedidoParam;
                }
                #endregion
                using (ERPProdEntities oContext = new ERPProdEntities())
                {
                    using (var dbContextTransaction = oContext.Database.BeginTransaction())
                    {
                        try
                        {

                            //PEDIDO
                            
                            cat_clientes entityCliente = oContext.cat_clientes
                                .Where(w => w.ClienteId == pedidoParam.ClienteId).FirstOrDefault();
                            if (pedidoParam.PedidoId == 0)
                            {
                                pedido.PedidoId = (oContext.doc_pedidos_orden
                                    .Max(m => (int?)m.PedidoId) ?? 0) + 1;
                                pedido.Activo = true;
                                pedido.CajaId = pedidoParam.CajaId;
                                pedido.Cancelada = false;
                                pedido.CanceladoPor = null;
                                pedido.CargoId = null;
                                pedido.ClienteId = pedidoParam.ClienteId;
                                pedido.CreadoEl = DateTime.Now;
                                pedido.CreadoPor = usuarioId;
                                pedido.Credito = (entityCliente.DiasCredito??0) > 0 ? true : false; ;
                                pedido.Descuento = 0;
                                pedido.Facturar = false;
                                pedido.FechaApertura = DateTime.Now;
                                pedido.FechaCancelacion = null;
                                pedido.FechaCierre = DateTime.Now;
                                pedido.Folio = ObtenerFolio(tipoPedido, sucursalId);
                                pedido.Impuestos = 0;
                                pedido.MotivoCancelacion = null;
                                pedido.Notas = "";
                                pedido.Para = "";
                                pedido.Subtotal = lstProductos.Sum(s => s.total);
                                pedido.SucursalCobroId = sucursalId;
                                pedido.SucursalId = sucursalId;
                                pedido.TipoPedidoId = (int)tipoPedido;
                                pedido.Total = lstProductos.Sum(s => s.total);
                                pedido.VentaId = null;

                                oContext.doc_pedidos_orden.Add(pedido);
                                oContext.SaveChanges();

                                foreach (var itemDetalle in lstProductos)
                                {
                                    pedidoDetalle = new doc_pedidos_orden_detalle();

                                    pedidoDetalle.PedidoDetalleId = (oContext.doc_pedidos_orden_detalle
                                        .Max(m => (int?)m.PedidoDetalleId) ?? 0) + 1;
                                    pedidoDetalle.Cancelado = false;
                                    pedidoDetalle.Cantidad = itemDetalle.cantidad;
                                    pedidoDetalle.CreadoEl = DateTime.Now;
                                    pedidoDetalle.CreadoPor = usuarioId;
                                    pedidoDetalle.Descripcion = itemDetalle.descripcion;
                                    pedidoDetalle.Descuento = 0;
                                    pedidoDetalle.Impreso = false;
                                    pedidoDetalle.Impuestos = 0;
                                    pedidoDetalle.Notas = "";
                                    pedidoDetalle.Parallevar = false;
                                    pedidoDetalle.PedidoId = pedido.PedidoId;
                                    pedidoDetalle.PorcDescuento = 0;
                                    pedidoDetalle.PrecioUnitario = itemDetalle.precioUnitario;
                                    pedidoDetalle.ProductoId = itemDetalle.productoId;
                                    pedidoDetalle.Total = itemDetalle.total;

                                    oContext.doc_pedidos_orden_detalle.Add(pedidoDetalle);
                                    oContext.SaveChanges();
                                    
                                }

                                //CARGOS                                
                                entityCargo = new doc_cargos();

                                entityCargo.CargoId = (oContext.doc_cargos
                                    .Max(m => (int?)m.CargoId) ?? 0) + 1;
                                entityCargo.Activo = true;
                                entityCargo.ClienteId = pedidoParam.ClienteId??0;
                                entityCargo.CreadoPor = usuarioId;
                                entityCargo.CredoEl = ERP.Business.Tools.TimeTools.ConvertToTimeZoneDefault();
                                entityCargo.Descripcion = String.Format("CARGO PEDIDO ID:{0}",pedido.PedidoId);
                                entityCargo.Descuento = 0;
                                entityCargo.ProductoId = null;
                                entityCargo.Saldo = lstProductos.Sum(s => s.total);
                                entityCargo.Total = lstProductos.Sum(s => s.total);

                                oContext.doc_cargos.Add(entityCargo);
                                oContext.SaveChanges();

                                //CARGO DETALLE
                                entityCargoDetalle = new doc_cargos_detalle();
                                entityCargoDetalle.CargoDetalleId = (oContext.doc_cargos_detalle
                                    .Max(m => (int?)m.CargoDetalleId) ?? 0) + 1;
                                entityCargoDetalle.CreadoEl = ERP.Business.Tools.TimeTools.ConvertToTimeZoneDefault();
                                entityCargoDetalle.Descuento = 0;
                                entityCargoDetalle.FechaCargo = ERP.Business.Tools.TimeTools.ConvertToTimeZoneDefault();
                                entityCargoDetalle.FechaPago = null;
                                entityCargoDetalle.Impuestos = 0;
                                entityCargoDetalle.Saldo = lstProductos.Sum(s => s.total);
                                entityCargoDetalle.Subtotal = lstProductos.Sum(s => s.total);
                                entityCargoDetalle.Total = lstProductos.Sum(s => s.total);
                                entityCargoDetalle.CargoId = entityCargo.CargoId;

                                oContext.doc_cargos_detalle.Add(entityCargoDetalle);
                                oContext.SaveChanges();

                                //LIGAR CARGO
                                doc_pedidos_cargos entityPedidoCargo = new doc_pedidos_cargos();
                                entityPedidoCargo.PedidoCargoId = (oContext.doc_pedidos_cargos.Max(m => (int?)m.PedidoCargoId) ?? 0) + 1;
                                entityPedidoCargo.CargoId = entityCargo.CargoId;
                                entityPedidoCargo.CreadoEl = ERP.Business.Tools.TimeTools.ConvertToTimeZoneDefault();
                                entityPedidoCargo.CreadoPor = usuarioId;
                                entityPedidoCargo.PedidoId = pedido.PedidoId;

                                oContext.doc_pedidos_cargos.Add(entityPedidoCargo);
                                oContext.SaveChanges();

                            }
                            else
                            {
                                oContext.Database.ExecuteSqlCommand("DELETE FROM DOC_PEDIDOS_ORDEN_DETALLE WHERE PEDIDOID = {0}", pedidoParam.PedidoId);
                                oContext.SaveChanges();
                                foreach (var itemDetalle in lstProductos)
                                {
                                    pedidoDetalle = new doc_pedidos_orden_detalle();

                                    pedidoDetalle.PedidoDetalleId = (oContext.doc_pedidos_orden_detalle
                                        .Max(m => (int?)m.PedidoDetalleId) ?? 0) + 1;
                                    pedidoDetalle.Cancelado = false;
                                    pedidoDetalle.Cantidad = itemDetalle.cantidad;
                                    pedidoDetalle.CreadoEl = DateTime.Now;
                                    pedidoDetalle.CreadoPor = usuarioId;
                                    pedidoDetalle.Descripcion = itemDetalle.descripcion;
                                    pedidoDetalle.Descuento = 0;
                                    pedidoDetalle.Impreso = false;
                                    pedidoDetalle.Impuestos = 0;
                                    pedidoDetalle.Notas = "";
                                    pedidoDetalle.Parallevar = false;
                                    pedidoDetalle.PedidoId = pedidoParam.PedidoId;
                                    pedidoDetalle.PorcDescuento = 0;
                                    pedidoDetalle.PrecioUnitario = itemDetalle.precioUnitario;
                                    pedidoDetalle.ProductoId = itemDetalle.productoId;
                                    pedidoDetalle.Total = itemDetalle.total;

                                    oContext.doc_pedidos_orden_detalle.Add(pedidoDetalle);
                                    oContext.SaveChanges();

                                   

                                }
                                pedido = pedidoParam;

                                //CARGOS
                                entityCargo = oContext.doc_cargos
                                    .Where(w => w.doc_pedidos_cargos.Where(s1 => s1.PedidoId == pedido.PedidoId).Count() > 0).FirstOrDefault();                                
                                entityCargo.Saldo = lstProductos.Sum(s => s.total);
                                entityCargo.Total = lstProductos.Sum(s => s.total);

                                oContext.SaveChanges();

                                oContext.Database.ExecuteSqlCommand("DELETE FROM DOC_CARGOS_DETALLE WHERE CargoId = {0}", entityCargo.CargoId);
                                oContext.SaveChanges();


                                //CARGO DETALLE
                                entityCargoDetalle = new doc_cargos_detalle();
                                entityCargoDetalle.CargoDetalleId = (oContext.doc_cargos_detalle
                                    .Max(m => (int?)m.CargoDetalleId) ?? 0) + 1;
                                entityCargoDetalle.CreadoEl = ERP.Business.Tools.TimeTools.ConvertToTimeZoneDefault();
                                entityCargoDetalle.Descuento = 0;
                                entityCargoDetalle.FechaCargo = ERP.Business.Tools.TimeTools.ConvertToTimeZoneDefault();
                                entityCargoDetalle.FechaPago = null;
                                entityCargoDetalle.Impuestos = 0;
                                entityCargoDetalle.Saldo = lstProductos.Sum(s => s.total);
                                entityCargoDetalle.Subtotal = lstProductos.Sum(s => s.total);
                                entityCargoDetalle.Total = lstProductos.Sum(s => s.total);
                                entityCargoDetalle.CargoId = entityCargo.CargoId;

                                oContext.doc_cargos_detalle.Add(entityCargoDetalle);
                                oContext.SaveChanges();


                            }




                            #region Báscula Bitácora
                            cat_basculas_configuracion configBascula = null;
                            configBascula = ERP.Business.BasculasBusiness.GetConfiguracionPCLocal(usuarioId, sucursalId);
                            if (lstProductos.Where(w => w.tieneBascula).Count() > 0)
                            {

                                if (configBascula != null)
                                {
                                    foreach (ProductoModel0 itemProducto in lstProductos.Where(w => w.tieneBascula))
                                    {
                                        ERP.Business.BasculasBusiness.InsertBitacora(configBascula.BasculaId,
                                            sucursalId,
                                            usuarioId,
                                            itemProducto.cantidad,
                                            (int)ERP.Business.Enumerados.tipoBasculaBitacora.VentaMayoreoPorPagar,
                                            itemProducto.productoId,
                                            null,
                                            oContext);
                                    }
                                }

                            }

                            #endregion

                            dbContextTransaction.Commit();
                            
                            
                        }
                        catch (Exception ex)
                        {

                            dbContextTransaction.Rollback();

                            err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                                "ERP",
                                                "ERP.Business.PedidOrdenBusiness.GuardarPedidoTemporal",
                                                ex);

                            error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
                            pedido = pedidoParam;

                        }


                    }
                }

               ERP.Business.CargoBusiness.CalcularSaldos_Static(oContext, entityCargo.CargoId, 0);

            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                     "ERP",
                                     "InventarioBusiness.Guardar",
                                     ex);

                error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
                pedido = pedidoParam;
            }

            return pedido;
        }

        public  string GuardarDevolucionReparto(int pedidoId,
            List<ProductoModel0> lstProductos,
            int usuarioId,
            int sucursalId,
            ref ERPProdEntities oContext)
        {
           
            try
            {
                //Dar salida de inventario a la devolución
                doc_inv_movimiento entityMov = new doc_inv_movimiento();
                entityMov.Autorizado = true;
                entityMov.AutorizadoPor = usuarioId;
                entityMov.Cancelado = false;
                entityMov.Comentarios = String.Format( "Salida por reparto PedidoId:{0}",pedidoId.ToString());
                entityMov.FechaAutoriza = DateTime.Now;
                entityMov.FechaCancelacion = null;
                entityMov.FechaMovimiento = DateTime.Now;;
                
                entityMov.HoraMovimiento = DateTime.Now.TimeOfDay;
                entityMov.ImporteTotal = lstProductos.Where(w=> w.cantidadCobroReparto > 0).Sum(s=> s.total);
                entityMov.MovimientoRefId = null;
                entityMov.ProductoCompraId = null;
                entityMov.SucursalDestinoId = null;
                entityMov.SucursalId = sucursalId;
                entityMov.SucursalOrigenId = null;
                entityMov.TipoMovimientoId = (int)ERP.Business.Enumerados.tipoMovimientoInventario.AjustePorSalida;
                entityMov.VentaId = null;

                result = InventarioBusiness.Guardar(ref entityMov, usuarioId, oContext);

                if (result.ok)
                {
                    foreach (ProductoModel0 itemProducto in lstProductos.Where(w => w.cantidadCobroReparto > 0))
                    {
                        doc_inv_movimiento_detalle entityDetalle = new doc_inv_movimiento_detalle();

                        entityDetalle.Cantidad = itemProducto.cantidadFinalReparto;
                                              
                        entityDetalle.Comisiones = 0;
                        entityDetalle.Consecutivo = (short)((oContext.doc_inv_movimiento_detalle
                            .Where(w => w.MovimientoId == entityMov.MovimientoId).Max(m => (int?)m.Consecutivo) ?? 0) + 1);
                        entityDetalle.CostoPromedio = 0;
                        entityDetalle.CostoUltimaCompra = 0;
                        entityDetalle.CreadoEl = DateTime.Now;
                        entityDetalle.CreadoPor = usuarioId;
                        entityDetalle.Disponible = 0;
                        entityDetalle.Flete = 0;
                        entityDetalle.Importe = itemProducto.cantidadFinalReparto * itemProducto.precioUnitario;
                        entityDetalle.MovimientoId = entityMov.MovimientoId;
                        entityDetalle.PrecioUnitario = itemProducto.precioUnitario;
                        entityDetalle.ProductoId = itemProducto.productoId;
                        entityDetalle.ValCostoPromedio = 0;
                        entityDetalle.ValCostoUltimaCompra = 0;
                        entityDetalle.ValorMovimiento = 0;

                        result = InventarioBusiness.GuardarDetalle(ref entityDetalle, entityMov, usuarioId, oContext);

                        if (!result.ok)
                        {
                            error = result.error;
                            break;
                        }
                    }

                    if (result.ok)
                    {
                        //Dar entrada de inventario a la devolución
                        entityMov = new doc_inv_movimiento();
                        entityMov.Autorizado = true;
                        entityMov.AutorizadoPor = usuarioId;
                        entityMov.Cancelado = false;
                        entityMov.Comentarios = String.Format("Entrada por devolución de reparto PedidoId:{0}", pedidoId.ToString());
                        entityMov.FechaAutoriza = DateTime.Now;
                        entityMov.FechaCancelacion = null;
                        entityMov.FechaMovimiento = DateTime.Now; ;

                        entityMov.HoraMovimiento = DateTime.Now.TimeOfDay;
                        entityMov.ImporteTotal = lstProductos.Where(w => w.cantidadCobroReparto > 0).Sum(s => s.total);
                        entityMov.MovimientoRefId = null;
                        entityMov.ProductoCompraId = null;
                        entityMov.SucursalDestinoId = null;
                        entityMov.SucursalId = sucursalId;
                        entityMov.SucursalOrigenId = null;
                        entityMov.TipoMovimientoId = (int)ERP.Business.Enumerados.tipoMovimientoInventario.Devolucion;
                        entityMov.VentaId = null;

                        result = InventarioBusiness.Guardar(ref entityMov, usuarioId, oContext);

                        if (result.ok)
                        {
                            foreach (ProductoModel0 itemProducto in lstProductos.Where(w => w.cantidadCobroReparto > 0))
                            {
                                doc_inv_movimiento_detalle entityDetalle = new doc_inv_movimiento_detalle();

                                entityDetalle.Cantidad = itemProducto.cantidadFinalReparto;

                              
                                entityDetalle.Comisiones = 0;
                                entityDetalle.Consecutivo = (short)((oContext.doc_inv_movimiento_detalle
                                    .Where(w => w.MovimientoId == entityMov.MovimientoId).Max(m => (int?)m.Consecutivo) ?? 0) + 1);
                                entityDetalle.CostoPromedio = 0;
                                entityDetalle.CostoUltimaCompra = 0;
                                entityDetalle.CreadoEl = DateTime.Now;
                                entityDetalle.CreadoPor = usuarioId;
                                entityDetalle.Disponible = 0;
                                entityDetalle.Flete = 0;
                                entityDetalle.Importe = itemProducto.cantidadFinalReparto * itemProducto.precioUnitario;
                                entityDetalle.MovimientoId = entityMov.MovimientoId;
                                entityDetalle.PrecioUnitario = itemProducto.precioUnitario;
                                entityDetalle.ProductoId = itemProducto.productoId;
                                entityDetalle.ValCostoPromedio = 0;
                                entityDetalle.ValCostoUltimaCompra = 0;
                                entityDetalle.ValorMovimiento = 0;

                                result = InventarioBusiness.GuardarDetalle(ref entityDetalle, entityMov, usuarioId, oContext);

                                if (!result.ok)
                                {
                                    error = result.error;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            error = result.error;
                        }

                    }
                }
                else
                {
                    error = result.error;
                }

                


            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                     "ERP",
                                     "InventarioBusiness.Guardar",
                                     ex);

                error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
            }

            return error;
        }

        public static string ImpresionAutomaticaPedido(int sucursalId,
            int usuarioId,int cajaId=0)
        {
            string error = "";
            string printerName = "";
            try
            {
                ERPProdEntities oContext = new ERPProdEntities();
                int[] pedidos;
                List<doc_pedidos_orden_detalle_impresion> lstPedidosOrdenImpresion =
                    oContext.doc_pedidos_orden_detalle_impresion
                    .Where(w => w.Impreso == false
                    && w.doc_pedidos_orden_detalle.doc_pedidos_orden.Activo == true 
                    && w.doc_pedidos_orden_detalle.doc_pedidos_orden.SucursalId == sucursalId
                    )
                    .ToList();
                pedidos = lstPedidosOrdenImpresion.Select(s => s.doc_pedidos_orden_detalle.PedidoId).Distinct().ToList().ToArray();

                cat_cajas_impresora oCajaImpresora = oContext.cat_cajas_impresora.Where(w => w.CajaId == cajaId).FirstOrDefault();

                if(oCajaImpresora != null)
                {
                    printerName = oCajaImpresora.cat_impresoras.NombreRed;
                }

                foreach (int pedidoId in pedidos)
                {
                    rptComanda oReport = new rptComanda();

                    List<p_rpt_Comanda_Result> lstResult = oContext.p_rpt_Comanda(pedidoId, 0, true, "").ToList();

                    if (lstResult.Count > 0)
                    {
                        oReport.DataSource = lstResult;
                        oReport.CreateDocument();

                        //oReport.Print(conf.NombreImpresora);

                        if (printerName == "")
                        {
                            oReport.ShowPreview();
                        }
                        else
                        {
                            oReport.Print(printerName);

                            oReport = new rptComanda();

                            oReport.DataSource = lstResult;
                            oReport.CreateDocument();
                            oReport.Print(printerName);
                        }


                        
                        
                    }
                    else
                    {
                        error = "No fue posible imprimir la comanda";
                    }

                }


            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                    "ERP",
                                    "InventarioBusiness.Guardar",
                                    ex);

                error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
               
            }

            return error;
        }

        public static string CargoPorTarjeta(int empresaId,int sucursalId,int pedidoId,int usuarioId,
            bool quitarCargo)
        {
            string error = "";
            try
            {
                ERPProdEntities oContext = new ERPProdEntities();
                string valor = "";

                if (!quitarCargo)
                {
                    if (ERP.Business.PreferenciaBusiness.AplicaPreferencia(empresaId, sucursalId, "CargoAdicionalTarjeta", usuarioId, ref valor))
                    {
                        if ((valor == null ? "" : valor).Length > 0)
                        {
                            decimal porcentaje = 0;

                            decimal.TryParse(valor, out porcentaje);

                            if (porcentaje > 0)
                            {
                                oContext.p_doc_pedidos_orden_detalle_cargo_upd(pedidoId, quitarCargo ? 0 : porcentaje);

                            }
                        }
                    }

                }
                else
                {
                    oContext.p_doc_pedidos_orden_detalle_cargo_upd(pedidoId, 0);
                }


            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                    "ERP",
                                    "InventarioBusiness.Guardar",
                                    ex);

                error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

            }

            return error;
        }
    }
}
