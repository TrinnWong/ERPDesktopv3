using ERP.Business;
using ERP.Models;
using ERP.Models.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static ERP.Business.Enumerados;
namespace ERP.WebAPI.Controllers
{
    public class PagoController : ApiController
    {
        PagoWebBusiness oPago;
        MercadoPagoBusiness oMP;

        public PagoController()
        {
            oPago = new PagoWebBusiness();
            oMP = new MercadoPagoBusiness();
        }
        [HttpPost]
        public ResultAPIModel PagoPaypal([FromBody]PagoOnlineParamModel param)
        {
            string error = "";
            error = oPago.pagar(param.idCarrito, param.refTransaction, param.montoPagado, (formaPagoOnline)param.formaPagoOnline);

            ResultAPIModel result = new ResultAPIModel();

            result.error = error;

            return result;
        }

        [HttpPost]
        public ResultAPIModel PagoMPTarjeta([FromBody]PagoOnlineParamModel param)
        {
            string error = "";
            error = oMP.realizarPagoTarjeta(param.idCarrito, param.total, param.refTransaction, param.mediPago, param.installments, param.issuer_id);            

            ResultAPIModel result = new ResultAPIModel();

            result.error = error;

            return result;
        }

        [HttpGet]
        public string PagoMPDeposito([FromUri]int folioCarrito)
        {
           
            return oMP.obtenerFichaDepositoOXXO(folioCarrito);
           
        }

        [HttpGet]
        public ResultAPIModel ConfirmarPagoOXXO([FromUri]long paymentId)
        {
            string error = "";
            error = oMP.confirmarPagoOXXO(paymentId);

            ResultAPIModel result = new ResultAPIModel();

            result.error = error;

            return result;
        }
    }
}
