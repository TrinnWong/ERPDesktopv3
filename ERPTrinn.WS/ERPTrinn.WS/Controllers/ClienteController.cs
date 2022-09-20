using ERP.Models;
using ERP.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ERPTrinn.WS.Controllers
{
    public class ClienteController : ApiController
    {
        ERP.Business.ClienteBusiness oCliente;
        public ClienteController()
        {

            oCliente = new ERP.Business.ClienteBusiness();
        }
        public HttpResponseMessage GetLlicencias(string KeyClient,string tipoProducto,string version)
        {
            var result= oCliente.GetLicenciaPV(KeyClient,tipoProducto,version);

            var json = new JavaScriptSerializer().Serialize(result);

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

       [System.Web.Http.HttpPut]
        public IHttpActionResult RegistroDemoPV(ClienteRegistroDemoModel model)
        {
            ResultAPIModel result=new ResultAPIModel();
            if (ModelState.IsValid)
            {
                 result = oCliente.RegistroDemoPV(model);
            }
            else
            {
                result.Ok = false;
                foreach (var itemValues in ModelState.Values)
                {
                    foreach (var itemError in itemValues.Errors)
                    {
                        result.ErrorMessage = itemError.ErrorMessage + "|" + result.ErrorMessage;
                    }
                }
                 
            }            

            var json = new JavaScriptSerializer().Serialize(result);

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
           

            return Json(result);
        }
    }
}
