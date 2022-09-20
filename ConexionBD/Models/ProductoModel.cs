using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class ProductoModel0
    {
        public decimal _porcDescuento { get; set; }
        public int partida { get; set; }
        public string clave { get; set; }
        public int productoId { get; set; }
        public string descripcion { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal precioNeto { get; set; }
        public decimal precioCompra { get; set; }
        public decimal cantidad { get; set; }
        public decimal porcImpuestos { get; set; }
        public decimal impuestos { get; set; }
        public decimal porcDescuento { get; set; }
        public decimal porcDescuentoPartida { get; set; }
        public decimal porcDescunetoVta { get; set; }
        public decimal montoDescuento { get; set; }
        public decimal total { get; set; }
        public bool tienePromocion { get; set; }
        public int unidadId { get; set; }
        public string unidad { get; set; }
        public int tipoDescuentoId { get; set; }
        public int promocionCMId { get; set; }
        public int? cargoAdicionalId { get; set; }
        public bool tieneBascula { get; set; }
        public bool paraLlevar { get; set; }
        public bool paraMesa { get; set; }
        public decimal cantidadFinalReparto { get; set; }
        public decimal cantidadCobroReparto { get; set; }
        public int pedidoDetalleId { get; set; }
        public decimal cantidadOriginal { get; set; }
        public decimal cantidadDevolucion { get; set; }
    }
}
