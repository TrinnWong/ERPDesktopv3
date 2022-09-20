using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Cliente
{
    public class ClienteLicenciaModel
    {
        public int ClienteLicenciaId { get; set; }
        public int productoId { get; set; }
        public DateTime FechaVigencia { get; set; }
        public bool Vigente { get; set; }
    }
}
