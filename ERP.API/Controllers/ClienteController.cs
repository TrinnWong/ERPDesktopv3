using ERP.Business;
using ERP.Models;
using ERP.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERP.API.Controllers
{
    public class ClienteController : ApiController
    {
        ClienteBusiness oCliente;

        public ClienteController()
        {
            oCliente = new ClienteBusiness();
        }

        [HttpPut()]       
        public ResultAPIModel RegistroDemo1(int? id,[FromBody]ClienteRegistroDemoModel cliente)
        {
            return oCliente.RegistroDemoPV(cliente);
        }


        // GET: api/Cliente
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cliente/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cliente
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cliente/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cliente/5
        public void Delete(int id)
        {
        }
    }
}
