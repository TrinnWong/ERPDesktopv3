using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Sincronizacion
{
    public class SyncSourceDestinationIdModel
    {
        public long ventaId { get; set; }
        public long ventaId_Externa { get; set; }

        public int idOrigen { get; set; }
        public int idDestino { get; set; }
    }
}
