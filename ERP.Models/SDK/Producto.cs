using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.SDK
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public DateTime CreadoEl { get; set; }
    }
}
