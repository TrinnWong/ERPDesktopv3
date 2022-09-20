using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD.Models
{
    public class ERPContext
    {
        public int usuarioId { get; set; }
        public string usuario { get; set; }
        public int empresaId { get; set; }
        public int sucursalId { get; set; }
        public int cajaId { get; set; }
        public bool esSupervisor { get; set; }
    }
}
