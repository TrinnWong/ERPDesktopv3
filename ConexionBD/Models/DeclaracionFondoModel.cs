using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD.Models
{
    public class DeclaracionFondoModel
    {
        public int sucursalId { get; set; }
        public int clave { get; set; }
        public string descripcion { get; set; }
        public decimal valor { get; set; }
        public int? cantidad { get; set; }
        public decimal? total { get; set; }
    }
}
