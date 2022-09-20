using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.ProductoSobrante
{
    public class ProductoSobranteModel
    {
        public int sucursalId { get; set; }
        public string nombreSucursal { get; set; }
        public int productoId { get; set; }
        public string producto { get; set; }
        public double cantidadSobrante { get; set; }
        public decimal cantidadInventarioTeorico { get; set; }
        public decimal cantidadDiferencia { get { return (decimal)cantidadSobrante - cantidadInventarioTeorico; } }
        public DateTime fecha { get; set; }
    }
}
