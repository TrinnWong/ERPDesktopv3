using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Carrito
{
    public class CarritoModel
    {
        public CarritoModel()
        {

        }
        public int id { get; set; }
        public int cargoId { get; set; }
        public int cargoDetalleId { get; set; }
        public int rowNumber { get; set; }
        public int productoId { get; set; }
        public string descripcion { get; set; }
        public decimal cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal importe { get { return precioUnitario * cantidad; } }
    }
}
