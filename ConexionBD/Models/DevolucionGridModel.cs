using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD.Models
{
    public class DevolucionGridModel
    {
        public long ventaId{get;set;}
        public int ventaDetalleId { get; set; }
        public int devolucionId { get; set; }
        public int devolucionDetId { get; set; }
        public int productoId { get; set; }
        public decimal precioUnitario { get; set; }
        public string producto { get; set; }
        public decimal cantidad { get; set; }
        public decimal total { get; set; }
        public bool seleccionar { get; set; }
        public decimal cantidadTicket { get; set; }
        public DateTime fechaTicket { get; set; }


    }
}
