using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.PV
{
    public class PVMenuButton
    {
        public int pagina { get; set; }
        public int itemsPagina { get; set; }
        public int indexIni { get; set; }
        public int indexFin { get; set; }
        public int totalItems { get; set; }
        public bool seleccionado { get; set; }

    }
}
