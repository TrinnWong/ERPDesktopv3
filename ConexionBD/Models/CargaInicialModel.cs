using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD.Models
{
    public class CargaInicialModel
    {
        public int cargaInventarioId { get; set; }
        public string clave { get; set; }
        public int productoId { get; set; }
        public string descripcion { get; set; }
        public decimal InventarioFisico { get; set; }
        public decimal costoPromedio { get; set; }
        public decimal ultimoCosto { get; set; }
        public bool tieneCargaInicial { get; set; }
    }
}
