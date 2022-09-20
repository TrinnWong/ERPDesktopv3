using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Produccion
{
    public class ProduccionHistorialModel
    {
        public int Id { get; set; }
        public int ProduccionId { get; set; }
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime Fecha { get; set; }
    }
}
