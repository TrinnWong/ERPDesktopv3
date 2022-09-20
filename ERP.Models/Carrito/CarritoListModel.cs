using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Carrito
{
    public class CarritoListModel
    {
        public CarritoListModel()
        {
            lstCarrito = new List<CarritoModel>();
            datosEnvio = new CarritoEnvioModel();
            uuid = Guid.NewGuid().ToString();
            ok = new ResultAPIModel();
           
        }

        public string uuid { get; set; }
        public int id { get; set; }
        public List<CarritoModel> lstCarrito { get; set; }
        public decimal total { get { return lstCarrito.Sum(s => s.importe); } }
        public CarritoEnvioModel datosEnvio { get; set; }
        public List<CarritoEnvioModel> lstDireccionesEnvio { get; set; }
        
        public string clienteOpenPayId { get; set; }
        public string emailUser { get; set; }

        public DateTime fechaEstimadaEntrega { get { return DateTime.Now; } }

        public ResultAPIModel ok { get; set; }
       
    }

}
