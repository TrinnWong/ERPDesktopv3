using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Sincronizacion
{
    public class InventarioMovimientoRelacion
    {
        public int MovimientoMasteriId { get; set; }
        public int MovimientoSucursaliId { get; set; }
    }
}
