using ConexionBD;
using ERP.Models;
using ERP.Models.Carrito;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.Entity;
namespace ERP.Business
{
    public class CarritoBusiness:BusinessObject
    {
        public void guardarCarrito(ref CarritoListModel carrito)
        {
          

            try
            {
                string uUID = carrito.uuid;
                var result = oContext.doc_web_carrito.Where(w => w.uUID == uUID).FirstOrDefault();
                if (result != null)
                {
                    carrito.uuid = Guid.NewGuid().ToString();
                }

                using (TransactionScope scope = new TransactionScope())
                {
                    #region carrito enc
                    
                    ObjectParameter pId = new ObjectParameter("pid", 0);
                    ObjectParameter pClienteId = new ObjectParameter("pClienteId", 0);
                    oContext.p_doc_web_carrito_ins(carrito.uuid, pId, carrito.emailUser, carrito.total, carrito.datosEnvio.calleNumero,
                        carrito.datosEnvio.colonia, carrito.datosEnvio.ciudad, carrito.datosEnvio.estadoId, carrito.datosEnvio.cp,
                        carrito.datosEnvio.personaRecibe, carrito.datosEnvio.telefonoContacto, pClienteId, carrito.fechaEstimadaEntrega);

                    int idEnc = int.Parse(pId.Value.ToString());

                    DateTime fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                    foreach (var itemCart in carrito.lstCarrito)
                    {
                        if (itemCart.cargoDetalleId > 0)
                        {
                            int cargoDetalleId = itemCart.cargoDetalleId ;
                            doc_cargos_detalle cargoDetalle = oContext.doc_cargos_detalle.Where(w => w.CargoDetalleId == cargoDetalleId)
                                .FirstOrDefault();

                            if (cargoDetalle != null)
                            {
                                decimal montoRecargo = 0;
                                cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

                                if (entity != null)
                                {
                                    montoRecargo = entity.MontoRecargoDiario ?? 0;
                                }

                                itemCart.cantidad = 1;
                                itemCart.cargoId = cargoDetalle.CargoId;
                                itemCart.descripcion = cargoDetalle.doc_cargos.cat_productos.Descripcion +" "+ cargoDetalle.FechaCargo.ToShortDateString();
                                itemCart.precioUnitario = fechaActual > cargoDetalle.FechaCargo.Date ?
                                              (cargoDetalle.Saldo ?? 0) + ((decimal)(fechaActual.Date - cargoDetalle.FechaCargo.Date).TotalDays) * montoRecargo
                                                : (cargoDetalle.Saldo ?? 0);
                                itemCart.productoId = cargoDetalle.doc_cargos.ProductoId??0;
                                
                            }
                        }

                        ObjectParameter pIdDetalle = new ObjectParameter("pIdDetalle", 0);
                        oContext.p_doc_web_carrito_detalle_ins(idEnc, pIdDetalle, carrito.uuid, itemCart.productoId, itemCart.cantidad, itemCart.descripcion, itemCart.precioUnitario, itemCart.importe, itemCart.cargoDetalleId);
                    }
                    #endregion



                    scope.Complete();

                    carrito.id = idEnc;
                }
            }
            catch (Exception ex)
            {

                carrito.ok.error = ex.Message;
            }

           
        }

        public CarritoListModel Get(int id)
        {
            CarritoListModel carrito = new CarritoListModel();

            
            try
            {
                doc_web_carrito entityCarrito = oContext.doc_web_carrito
                    .Include(i=>i.doc_web_carrito_detalle)
                    .Include(i => i.doc_ventas)
                    .Where(w => w.id == id).FirstOrDefault();

                carrito.emailUser = entityCarrito.Email;
               // carrito.fechaEstimadaEntrega = entityCarrito.FechaEstimadaEntrega??DateTime.Now;
                carrito.id = entityCarrito.id;
                carrito.uuid = entityCarrito.uUID;

                foreach (doc_web_carrito_detalle itemDet in entityCarrito.doc_web_carrito_detalle)
                {
                    CarritoModel carritoDet = new CarritoModel();

                    
                    
                        carritoDet.cantidad = itemDet.Cantidad;
                        carritoDet.cargoDetalleId = itemDet.CargoDetalleId ?? 0;
                        carritoDet.descripcion = itemDet.Descripcion;
                        carritoDet.id = itemDet.Id ?? 0;
                        carritoDet.precioUnitario = itemDet.PrecioUnitario;
                        carritoDet.productoId = itemDet.ProductoId;
                    

                   

                   

                    carrito.lstCarrito.Add(carritoDet);

                }


            }
            catch (Exception ex)
            {

                carrito.ok.error = ex.Message;
            }

            return carrito;
        }
        
    }
}
