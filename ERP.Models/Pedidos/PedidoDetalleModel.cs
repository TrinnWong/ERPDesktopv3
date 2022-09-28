using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Pedidos
{
    public class PedidoDetalleModel
    {
        public int pedidoId { get; set; }
        public int pedidoDetalleId{ get; set; }
        public int key{ get; set; }
        public int productoId { get; set; }
        public string cliente { get; set; }
        public string clave { get; set; }
        public string descripcion { get; set; }
        public decimal cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal precioOriginal { get; set; }
        public int unidadId { get; set; }
        public string unidad { get; set; }
        public decimal totalImpuestos { get; set; }
        public decimal totalDescuento { get; set; }
        public decimal total { get; set; }
        public bool paraLlevar { get; set; }
        public bool paraMesa { get; set; }
        public bool cortesia { get; set; }
        public bool consumoInterno { get; set; }
        public bool precioEmpleado { get; set; }
        public decimal porcDescuento { get; set; }
        public decimal porcImpuestos { get; set; }
        public bool requiereBascula { get; set; }
        public bool basculaPendiente { get; set; }
        public decimal cantidadPendienteBascula { get; set; }
        public string registradoPor { get; set; }
        public string estado { get; set; }
        public string folio { get; set; }
        public int familiaId { get; set; }
        public string nombreFamilia { get; set; }
        public int tipoPedidoId { get; set; }
        public DateTime fechaEntrega { get; set; }
        public TimeSpan horaEntrega { get; set; }
        public long ventaId { get; set; }
        public string TipoCaja { get; set; }
        public decimal totalDetalle { get; set; }
    }
}
