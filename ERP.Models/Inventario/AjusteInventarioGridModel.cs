using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Inventario
{
    public class AjusteInventarioGridModel
    {
        public int ProductoId { get; set; }
        public string ClaveProducto { get; set; }
        public string Producto { get; set; }
        public decimal CantidadActual { get; set; }
        public decimal CantidadAjuste { get; set; }
    }
}
