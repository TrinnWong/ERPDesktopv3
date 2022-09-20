using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.ProduccionSolicitud
{
    public class ProduccionSolicitudAceptacionGrd
    {
        public int produccionSolicitudAceptcionId { get; set; }
        public int produccionSolicitudDetalleId { get; set; }
        public string clave { get; set; }
        public int productoId { get; set; }
        public string producto { get; set; }
        public int unidadId { get; set; }
        public string unidad { get; set; }
        public double cantidadSolicitada { get; set; }
        public double? cantidadAceptacion { get; set; }
        public string comentarios { get; set; }

    }
}
