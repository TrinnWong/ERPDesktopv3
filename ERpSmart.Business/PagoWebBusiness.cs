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
using static ERP.Business.Enumerados;

namespace ERP.Business
{
    public class PagoWebBusiness : BusinessObject
    {
        MailBusiness oMail;
        SisBitacoraBusiness oSisBitacora;

        public PagoWebBusiness()
        {
            oMail = new MailBusiness();
            oSisBitacora = new SisBitacoraBusiness();
        }
        public string pagar(int idCarrito, string refTransaction, decimal montoPagado, formaPagoOnline formaPagoOnline)
        {
            string error = "";
            try
            {
                //Obtener la inf. del carrito
                doc_web_carrito entityCarrito = oContext.doc_web_carrito.Where(w => w.id == idCarrito).FirstOrDefault();

                #region validaciones
                if (entityCarrito.VentaId > 0)
                {
                    error = "Ya está pagado la compra con folio de carrito:" + idCarrito.ToString();
                }
                //if (entityCarrito.Total != montoPagado)
                //{
                //    error = error+"|El monto de la transacción no cubre el total del carrito folio:" + idCarrito.ToString();
                //}
                #endregion


                if (error.Length == 0)
                {
                    using (TransactionScope scope = new TransactionScope())
                    {


                        if (entityCarrito != null)
                        {
                            ObjectParameter pVentaId = new ObjectParameter("pVentaId", 0);
                            //Generar la venta
                            oContext.p_InsertarVenta(pVentaId, "", DateTime.Now, entityCarrito.ClienteId, false, 0, 0, 0, 0, entityCarrito.Impuestos, entityCarrito.Subtotal, entityCarrito.Total, entityCarrito.Total,
                                0, true, (int)ERP.Business.Enumerados.UserDefault.UserDefault, DateTime.Now, null, null, ERP.Business.Enumerados.sucursalWEB, ERP.Business.Enumerados.cajaWeb, null,false,null);

                            foreach (var itemDet in entityCarrito.doc_web_carrito_detalle)
                            {
                                ObjectParameter pVentaDetalleId = new ObjectParameter("pVentaDetalleId", 0);
                                oContext.p_InsertarVentaDetalle(0, int.Parse(pVentaId.Value.ToString()), itemDet.ProductoId, itemDet.Cantidad,"", itemDet.PrecioUnitario, 0, 0, itemDet.Impuestos, itemDet.Importe, 
                                    (int)ERP.Business.Enumerados.UserDefault.UserDefault, DateTime.Now, null, null, null,itemDet.CargoDetalleId,false,false);
                                
                                //Si es un cargo, recalcular saldo
                                if (itemDet.CargoDetalleId > 0)
                                {
                                    CargoBusiness oCargo = new CargoBusiness();

                                    ResultAPIModel resultSaldos =  oCargo.CalcularSaldos(itemDet.doc_cargos_detalle.CargoId, itemDet.CargoDetalleId??0);

                                    if(!resultSaldos.ok)
                                    {
                                        scope.Dispose();
                                        return resultSaldos.error;
                                    }
                                }

                            }

                            oContext.p_InsertarVentaFormaPago((int)ERP.Business.Enumerados.formasPago.TARJETA_DE_DEBITO, int.Parse(pVentaId.Value.ToString()), montoPagado, (int?)ERP.Business.Enumerados.UserDefault.UserDefault, refTransaction);

                            oContext.p_venta_afecta_inventario(int.Parse(pVentaId.Value.ToString()), ERP.Business.Enumerados.sucursalWEB);

                            entityCarrito.VentaId = int.Parse(pVentaId.Value.ToString());
                            oContext.SaveChanges();

                            //pagar el carrito
                            ObjectParameter pError = new ObjectParameter("pError", "");
                            oContext.p_doc_web_carrito_pagar((int)ERP.Business.Enumerados.sucursalWEB, idCarrito, refTransaction, montoPagado.ToString(), (byte)formaPagoOnline, pError);

                            if (pError.Value.ToString().Length > 0)
                            {
                                error = pError.Value.ToString();
                                scope.Dispose();
                                return error;

                            }


                            enviarMailConfirmacionPedido(entityCarrito.id);

                        }
                        else
                        {
                            error = "No fue posible encontrar el carrito con folio, posiblemente ya está pagado" + idCarrito.ToString();

                        }
                        scope.Complete();


                    }
                }


            }
            catch (Exception ex)
            {
                error = "idCarrito:" +
                    idCarrito.ToString() + "|refTransaction:" +
                    (refTransaction == null ? "" : refTransaction) + "|";
                error = error + (ex.InnerException != null ? ex.InnerException.Message : ex.Message);

                oSisBitacora.sis_bitacora_ins(this.GetType().Name, "pagar", error);

            }

            if (error.Length > 0)
            {
                oSisBitacora.sis_bitacora_ins(this.GetType().Name, "pagar", error);
            }

            return error;
        }

        public string enviarMailConfirmacionPedido(int folioCarrito)
        {
            string error = "";

            try
            {
                string appPath = AppDomain.CurrentDomain.BaseDirectory;

                string cuerpoMail = System.IO.File.ReadAllText(appPath + @"bin\MailTemplate\PaySucess.txt");

                doc_web_carrito entity = oContext.doc_web_carrito.Where(w => w.id == folioCarrito).FirstOrDefault();

                if (cuerpoMail.Length > 0 || entity == null)
                {
                    string tablaResumenPedido =
                        "<table class='table'>" +
                            "<tr><th>Producto</th><th>Precio</th><th>Cantidad</th><th>Importe</th></tr>";

                    foreach (var itemDet in entity.doc_web_carrito_detalle)
                    {
                        tablaResumenPedido = tablaResumenPedido + "<tr><td>" + itemDet.Descripcion + "</td><td>" + itemDet.PrecioUnitario.ToString("c2") + "</td><td>" + itemDet.Cantidad + "</td><td>" + itemDet.Importe.ToString("c2") + "</td></tr>";
                    }

                    tablaResumenPedido = tablaResumenPedido + "<tr><td></td><td></td><td></td><td>" + entity.Total.ToString("c2") + "</td></tr>";



                    tablaResumenPedido = tablaResumenPedido + "</table>";

                    cuerpoMail = cuerpoMail.Replace("{noPedido}", entity.id.ToString());
                    //cuerpoMail = cuerpoMail.Replace("{fechaEntrega}", String.Format("{0:dd MMMM yyyy}", entity.FechaEstimadaEntrega));
                    cuerpoMail = cuerpoMail.Replace("{userName}", entity.Email);
                    //cuerpoMail = cuerpoMail.Replace("{dirEnvio}", entity.EnvioCalle + " " + entity.EnvioColonia + " " + entity.EnvioCiudad + " " + entity.cat_estados.Nombre + " " + entity.EnvioCP + " MÉXICO");

                    cuerpoMail = cuerpoMail.Replace("{resumen_pedido}", tablaResumenPedido);

                    oMail.Send(cuerpoMail, entity.Email, "Confirmación de pedido: #" + entity.id, "dmoreno@trinn.com.mx", null);

                }
                else
                {
                    error = "no fue posible obtener el template/carrito para el envio de confirmación de pago folioCarrito" + folioCarrito.ToString();
                }


            }
            catch (Exception ex)
            {

                error = ex.Message;
                oSisBitacora.sis_bitacora_ins(this.GetType().Name, "enviarMailConfirmacionPedido", error);
            }

            if (error.Length > 0)
            {
                oSisBitacora.sis_bitacora_ins(this.GetType().Name, "enviarMailConfirmacionPedido", error);
            }

            return error;
        }

        
    }
}
