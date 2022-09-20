using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Inventario
{
    public class AceptacionSucursalGrdModel
    {
        public int id { get; set; }
        public int movimientoId { get; set; }
        public int movimientoDetalleId { get; set; }
        public int productoId { get; set; }
        public string producto { get; set; }
        public decimal cantidadMovimiento { get; set; }
        public decimal cantidadReal { get; set; }
        public int movimientoDetalleAjusteId { get; set; }
    }
}
