using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD.Models
{
    public class ValeFPModel
    {
        public int index { get; set; }
        public int ventaId { get; set; }
        public int folioVale { get; set; }
        public int tipoVale { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public decimal monto { get; set; }
        public string eliminar { get { return "Eliminar"; } }

    }
}
