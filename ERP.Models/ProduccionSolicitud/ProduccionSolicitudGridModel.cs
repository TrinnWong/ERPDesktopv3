using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.ProduccionSolicitud
{
    public class ProduccionSolicitudGridModel
    {
        public int produccionSolicitudId { get; set; }
        public string deSucursal { get; set; }
        public string paraSucursal { get; set; }
        public DateTime CreadoEl { get; set; }
        public bool completada { get; set; }
        public bool activa { get; set; }
        public bool terminada { get; set; }
    }
}
