using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Cuentas
{
    public class CuentasDetalleViewModel
    {
        public int posicion { get; set; }
        public int cuentaDetalleId { get; set; }
        public string folioComanda { get; set; }
        public string descripcion { get; set; }
        public decimal cantidad { get; set; }
        public decimal total { get; set; }
        public bool imprimir { get; set; }
        public bool paraLlevar { get; set; }
        public bool cancelado { get; set; }

    }
}
