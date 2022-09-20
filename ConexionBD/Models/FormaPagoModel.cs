using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class FormaPagoModel
    {
        public int id { get; set; }
        public decimal? cantidad { get; set; }
        public string digitoVerificador { get; set; }
        public string descripcion { get; set; }
        public bool requiereDigito { get; set; }
    }
}
