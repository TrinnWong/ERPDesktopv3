using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Producto
{
    public class ProductoMinMaxModel
    {
        public int productoId { get; set; }
        public string claveProd { get; set; }
        public string descripcion { get; set; }
        public decimal disponible { get; set; }
        public decimal minimo { get; set; }
        public decimal maximo { get; set; }
        public decimal? solicitar { get; set; }
    }
}
