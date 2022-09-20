using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Sucursal
{
    public class SucursalProductoModel
    {
        public int sucursalId { get; set; }
        public int productoId { get; set; }
        public string clave { get; set; }
        public string descripcion { get; set; }
    }
}
