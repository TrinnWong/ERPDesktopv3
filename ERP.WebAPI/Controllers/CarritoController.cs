using ERP.Business;
using ERP.Models;
using ERP.Models.Carrito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERP.WebAPI.Controllers
{
    public class CarritoController : ApiController
    {
        CarritoBusiness oCarrito;

        public CarritoController()
        {
            oCarrito = new CarritoBusiness();
        }

        [HttpPost]
        public CarritoListModel Guardar(CarritoListModel carrito)
        {
            carrito.ok = new ResultAPIModel();
            oCarrito.guardarCarrito(ref carrito);

            return carrito;
        }

        [HttpGet]
        public CarritoListModel Get(int id)
        {
            return oCarrito.Get(id);

            
        }

    }
}
