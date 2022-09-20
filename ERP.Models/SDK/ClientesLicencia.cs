using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.SDK
{
    public class ClientesLicencia
    {
        public int ClienteLicenciaId { get; set; }
        public int ClienteId { get; set; }
        public int ProductoId { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public bool Activo { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
