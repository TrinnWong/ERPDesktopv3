using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.SDK
{
    public class Usuario
    {
        public int id { get; set; }
        public string correoElectronico { get; set; }
        public string contrasena { get; set; }
        public string token { get; set; }
    }
}
