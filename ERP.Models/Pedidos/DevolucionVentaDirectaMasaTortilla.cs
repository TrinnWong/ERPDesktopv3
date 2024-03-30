using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Pedidos
{
    public class PedidoDevolucionVentaDirectaMasaTortilla
    {
        public long ventaId { get; set; }
        public string folio { get; set; }
        public int clienteId { get; set; }
        public string cliente { get; set; }
        public DateTime fecha { get; set; }
        public decimal devolucionTortilla { get; set; }
        public decimal devolucionMasa { get; set; }

        public decimal precioTortilla{get;set;}
        public decimal precioMasa { get; set; }
    }
}
