using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Pago
{
    public class PagoOnlineParamModel
    {
        public int idCarrito { get; set; }
        public string refTransaction { get; set; }
        public decimal montoPagado { get; set; }
        public int formaPagoOnline { get; set; }
        public decimal total { get; set; }
        public int installments { get; set; }
        public string issuer_id { get; set; }
        public string mediPago { get; set; }
    }
}
