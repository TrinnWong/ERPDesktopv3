using ERP.Business;
using ERP.Models;
using ERP.Models.Cliente;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERP.WebAPI.Controllers
{
   
    public class ClienteController : ApiController
    {
        ClienteBusiness oCLiente;
       

        public ClienteController()
        {
            oCLiente = new ClienteBusiness();
        }

        // GET: api/Cliente
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

       

        // POST: api/Cliente
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cliente/5
        [HttpPut]
        public ResultAPIModel RegistroDemo([FromBody]ClienteRegistroDemoModel value)
        {
            return oCLiente.RegistroDemoPV(value);
        }

        [HttpPost]
        public ResultAPIModel Add([FromBody]ClienteModel value)
        {
            return oCLiente.Add(value);
        }

        [HttpPost]
        public ResultAPIModel Edit([FromBody]ClienteModel value)
        {
            return oCLiente.Edit(value);

        }

        [HttpGet]
        public ClienteListModel GetList(int sucursalId)
        {
            return oCLiente.GetClientes(sucursalId);
        }

        [HttpGet]
        public ClienteModel Get(int id)
        {
            return oCLiente.Get(id);
        }

        [HttpGet]
        public ClienteModel Login(string email,string pass)
        {
            return oCLiente.Login(email,pass);
        }
        [HttpGet]
        public CargoPendienteModel GetCargoPendiente(int clienteId)
        {
            return oCLiente.GetCargoPendiente(clienteId);
        }

        [HttpGet]
        public ResultAPIModel RecuperarPass([FromUri]string email)
        {
            return oCLiente.RecuperarPass(email);
        }

        [HttpPost]
        public ResultAPIModel CambiarPass([FromBody]ClienteCambiarPassModel value)
        {
            return oCLiente.CambiarPass(value);

        }

        // DELETE: api/Cliente/5
        public void Delete(int id)
        {
        }
    }
}
