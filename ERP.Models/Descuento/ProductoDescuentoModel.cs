using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Descuento
{
    public class ProductoDescuentoModel
    {
        public int ProductoId { get; set; }
        public short TipoDescuentoId { get; set; }
        public decimal porcentajeDescuento { get; set; }
    }
}
