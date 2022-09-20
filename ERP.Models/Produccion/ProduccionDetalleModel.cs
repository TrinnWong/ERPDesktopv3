using ERP.Models.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Produccion
{
    public class ProduccionDetalleModel : GridBaseModel
    {
        public int ProductoMateriaPrimaId { get; set; }
        public int ProductoId { get; set; }
        public int ProductoBaseId { get; set; }
        public decimal Cantidad { get; set; }
        public string Unidad { get; set; }
        public int UnidadConcinaId { get; set; }
        public string UnidadCocina { get; set; }
        public bool Cocina { get; set; }
        public decimal costoPromedio { get; set; }
        public bool Requerido { get; set; }
        public int Orden { get; set; }
        public bool GenerarSalidaVenta { get; set; }
    }
}
