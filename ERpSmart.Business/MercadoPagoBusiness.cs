using ConexionBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ERP.Models.Carrito;
using MercadoPago;
using MercadoPago.Common;
using MercadoPago.DataStructures.Payment;
using MercadoPago.Resources;

namespace ERP.Business
{
    public class MercadoPagoBusiness : BusinessObject
    {
        PagoWebBusiness oPago;
        SisBitacoraBusiness oSisBitacora;


        public MercadoPagoBusiness()
        {
            oPago = new PagoWebBusiness();
            oSisBitacora = new SisBitacoraBusiness();
        }

        public void GetToken()
        {
            if (MercadoPago.SDK.ClientId == null)
            {
                //MercadoPago.SDK.AppId = "7189658840236016";
                MercadoPago.SDK.ClientId = "6289655136610477";
                MercadoPago.SDK.ClientSecret = "NXc2YSrBCRoVAztyAhQB9J5uOOxwOyFG";
                MercadoPago.SDK.SetAccessToken("APP_USR-6289655136610477-082818-b1889068650121a2151ea6bbe38fb0ea-396762868");
            }
        }

        public string crearCliente(ref string customerMP, string nombre, string apellido, string email, string direccion,
            string cp, string ciudad, string pais, string estado, string whatsApp)
        {
            string error = "";

            try
            {

                Customer customer = new Customer
                {
                    FirstName = "DFaniel",
                    LastName = "Moreno",
                    Email = email,
                    Phone = new MercadoPago.DataStructures.Customer.Phone
                    {
                        AreaCode = "+52",
                        Number = whatsApp

                    },
                    Address = new MercadoPago.DataStructures.Customer.Address
                    {
                        ZipCode = cp,
                        StreetName = direccion
                    }

                };


                customer.Save();

                customerMP = customer.Id;


            }
            catch (Exception ex)
            {
                error = ex.Message;

            }

            return error;
        }

        public string realizarPagoTarjeta(int carritoId,decimal total, string tokenId, string mediPago,
            int installments, string issuer_id)
        {
            string error = "";
            try
            {
                GetToken();

                doc_web_carrito entityCarrito = oContext.doc_web_carrito.Where(w => w.id == carritoId).FirstOrDefault();

                if(entityCarrito==null)
                {
                    error = "Error al obtener el carrito";
                    return error;
                }
               
               
                //MercadoPago.SDK.SetAccessToken("APP_USR-7189658840236016-030119-5d585140398d55c739cb2969976fa351-353953298");
                Payment payment = new Payment()
                {
                    TransactionAmount = float.Parse(total.ToString()),
                    Token = tokenId,
                    Description = "Pago registrado con el FolioWeb:" + entityCarrito.id.ToString(),
                    Installments = installments,
                    PaymentMethodId = mediPago,
                    IssuerId = issuer_id,
                    ExternalReference = entityCarrito.id.ToString(),
                    Payer = new Payer()
                    {
                        Email = entityCarrito.Email
                    }
                };
                // Guarda y postea el pago
                payment.Save();

                if (payment.Status == PaymentStatus.approved)
                {
                   error= oPago.pagar(entityCarrito.id, tokenId, entityCarrito.Total, ERP.Business.Enumerados.formaPagoOnline.mercadoLibreTarjeta);
                }
                else
                {
                    error = "El pago fue rechazado";
                }



            }
            catch (Exception ex)
            {

                error = ex.Message;
            }

            return error;
        }


        public string obtenerFichaDepositoOXXO(int folioCarrito)
        {
            string result = "";

            try
            {
                GetToken();
                // Newtonsoft.Json.Linq.JToken var = MercadoPago.SDK.Get("/v1/payment_methods");

                doc_web_carrito entityCarrito = oContext.doc_web_carrito.Where(w => w.id == folioCarrito).FirstOrDefault();

                if(entityCarrito.VentaId > 0)
                {
                    return result;
                }

                Payment payment = new Payment()
                {
                    TransactionAmount = float.Parse(entityCarrito.Total.ToString()),
                    Description = "Pago English-User folio:[" + entityCarrito.id.ToString() + "] uuid:[" + entityCarrito.uUID.ToString().ToUpper() + "]",
                    PaymentMethodId = "oxxo",
                    ExternalReference = folioCarrito.ToString(),                    
                    
                    Payer = new Payer()
                    {
                        Email = entityCarrito.Email
                    }
                };
                // Save and posting the payment
                payment.Save();

                result = payment.TransactionDetails.Value.ExternalResourceUrl;

               


            }
            catch (Exception ex)
            {

               
            }

            return result;
        }

        public string confirmarPagoOXXO(long paymentId)
        {
            string error = "";
            try
            {
                GetToken();
                Payment payment = MercadoPago.Resources.Payment.FindById(paymentId);

                if (payment.Id > 0)
                {
                    if (payment.Status == PaymentStatus.approved)
                    {
                        int folioCarrito = 0;

                        int.TryParse(payment.ExternalReference, out folioCarrito);

                        if (folioCarrito == 0)
                        {
                            string folioStr = payment.Description;

                            int pFrom = folioStr.IndexOf("Folio:[") + "Folio:[".Length;
                            int pTo = folioStr.LastIndexOf("] uuid");

                            folioStr = folioStr.Substring(pFrom, pTo - pFrom);

                            int.TryParse(folioStr, out folioCarrito);


                        }

                        if (folioCarrito > 0)
                        {
                            error = oPago.pagar(folioCarrito, "PaymentId MercadoPago:" + payment.Id.ToString(), decimal.Parse(payment.TransactionAmount == null ? "0" : payment.TransactionAmount.ToString()),ERP.Business.Enumerados.formaPagoOnline.mercadoLibreOxxo);

                            if (error.Length > 0)
                            {
                                oSisBitacora.sis_bitacora_ins(this.GetType().Name, "pagar", error);
                            }


                        }

                    }

                }
            }
            catch (Exception ex)
            {

                error = ex.Message;
                oSisBitacora.sis_bitacora_ins(this.GetType().Name, "pagar", error);
            }

            return error;
        }
    }
}
