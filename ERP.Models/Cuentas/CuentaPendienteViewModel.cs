using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Cuentas
{
    public class CuentaPendienteViewModel
    {
        public int sucursalId { get; set; }        
        public int cuentaId { get; set; }
        public string folio { get; set; }
        public string mesas { get; set; }
        public decimal importe { get; set; }
        public string status { get; set; }
        public DateTime fechaApertura { get; set; }
        public DateTime? fechaProgramada { get; set; }
        public TimeSpan? horaProgramada { get; set; }

        public string notas { get; set; }
        public decimal? saldo { get; set; }
        public string tipo { get; set; }
        public string telefono { get; set; }

        public string cliente { get; set; }
        
    }
}
