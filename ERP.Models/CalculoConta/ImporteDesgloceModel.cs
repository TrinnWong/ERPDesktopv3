using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.CalculoConta
{
    public class ImporteDesgloceModel
    {

        public ResultAPIModel error { get; set; }
        public decimal subtotal { get; set; }
        public decimal impuestos { get; set; }
        public decimal total{get;set;}

    }
}
