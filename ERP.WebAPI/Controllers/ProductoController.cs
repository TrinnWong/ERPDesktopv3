using ConexionBD;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERP.WebAPI.Controllers
{
    public class ProductoController : ApiController
    {
        ProductoBusiness oProducto;

        public ProductoController()
        {
            oProducto = new ProductoBusiness();
        }

        [HttpPost]
        public ResultAPIModel Add([FromBody]ERP.Models.ProductoModel value)
        {
            return oProducto.Add(value);
        }

        [HttpPost]
        public ResultAPIModel Edit([FromBody]ERP.Models.ProductoModel value)
        {
            return oProducto.Edit(value);
        }

        [HttpGet]
        public List<ERP.Models.ProductoModel> GetList()
        {
            return oProducto.GetList();
        }

        [HttpGet]
        public ERP.Models.ProductoModel Get(int productoId)
        {
            return oProducto.Get(productoId);
        }
    }
}
