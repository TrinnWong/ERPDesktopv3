using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Produccion
{
    public class ProduccionSucProductoModel
    {
        public int productoId { get; set; }
        public string clave { get; set; }
        public string descripcionProducto { get; set; }
        public decimal cantidad { get; set; }
        public int unidadId { get; set; }
        public bool UsoBascula { get; set; }
    }
}
