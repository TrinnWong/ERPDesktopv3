using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Empleados
{
    public class EmpleadosDescuentosGrd
    {
        public string ClaveProducto { get; set; }
        public string Producto { get; set; }
        public decimal MontoDescuento { get; set; }
        public decimal Precio { get; set; }
        public Nullable<decimal> PrecioDescuento { get; set; }
        public int Id { get; set; }
    }
}
