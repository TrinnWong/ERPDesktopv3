using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Cargo
{
    public class CargoModel
    {
        public CargoModel()
        {
            detalle = new List<CargoDetalleModel>();
        }
        public int cargoId { get; set; }
        public int clienteId { get; set; }
        public string claveCliente { get; set; }
        public string nombreCliente { get; set; }
        public string sucursalCliente { get; set; }
        public int productoId { get; set; }
        public ProductoModel producto2 { get; set; }
        public string producto { get; set; }
        public decimal saldo { get; set; }
        public decimal descuento { get; set; }
        public decimal total { get; set; }    
        public  bool activo { get; set; }

        public List<CargoDetalleModel> detalle { get; set; }
    }
}
