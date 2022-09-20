using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.SDK
{
    public class ClientesBd
    {
        public int ClienteBdid { get; set; }
        public int ClienteId { get; set; }
        public string ServidorBd { get; set; }
        public string NombreBd { get; set; }
        public string UsuarioBd { get; set; }
        public string Password { get; set; }
        public int? ClienteTipoBdid { get; set; }
        public bool Activo { get; set; }
    }
}
