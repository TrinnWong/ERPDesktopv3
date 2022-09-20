using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD.Models
{
    public class MovimientoInventarioProductoModel
    {
        public int partida { get; set; }
        public int productoId { get; set; }
        public decimal precioUnitario { get; set; }
        public string descripcion { get; set; }
        public string clave { get; set; }
        public int unidadId { get; set; }
        public string unidad { get; set; }
        public decimal cantidadMov { get; set; }
        public decimal importe { get { return cantidadMov * precioUnitario; } }
        public decimal precioCompra { get; set; }
        public decimal porcImpuestos { get; set; }
        public decimal impuestos { get; set; }
        public decimal subtotal { get; set; }
        public decimal precioNeto { get; set; }

    }
}
