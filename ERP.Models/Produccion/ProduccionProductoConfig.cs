using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Produccion
{
    public class ProduccionProductoConfig
    {
        public int index { get; set; }
        public int productoId { get; set; }
        public string descripcion { get; set; }
        public int productoTerminadoId { get; set; }
        public bool requerido { get; set; }
        public int orden { get; set; }
        public bool existe { get; set; }

    }
}
