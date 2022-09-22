using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Precios
{
    public class ProductoPrecioModel
    {
        public int productoId { get; set; }
        public string clave { get; set; }
        public string producto { get; set; }
        public int precioId { get; set; }
        public decimal precio { get; set; }
        public decimal precioOriginal { get; set; }
        public bool modificado { get { return precio != precioOriginal ? true : false; } }
    }
}
