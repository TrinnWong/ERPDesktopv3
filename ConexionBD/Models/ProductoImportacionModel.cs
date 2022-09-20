using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD.Models
{
    public class ProductoImportacionModel
    {
        public string linea { get; set; }
        public string familia { get; set; }
        public string subfamilia { get; set; }
        public string claveProducto { get; set; }
        public string descripcionCorta { get; set; }
        public string descripcionLarga { get; set; }        
        public decimal precio { get; set; }
        public decimal existencias { get; set; }
        public float costoPromedio { get; set; }
        public int iva { get; set; }
        public string unidad { get; set; }
        public string marca { get; set; }
        //
        public string talla { get; set; }
        public string sexo { get; set; }
        public string color { get; set; }
        public string colorSecundario { get; set; }
        public bool  sobrePedido { get; set; }
        public bool materiaPrima { get; set; }
        public bool prodParaVenta { get; set; }
        //Licencias
        public string unidadLicencia { get; set; }
        public short tiempoLicencia { get; set; }
        public string version { get; set; }
        //Nuveas columnas
        public float costoUltimaCompra { get; set; }
        public bool productoActivo { get; set; }
        public bool productoTerminado { get; set; }
        public bool productoInventariable { get; set; }
        public bool productoBascula { get; set; }
        public bool productoSeriado { get; set; }
        public string unidadInvetario { get; set; }
        public string unidadVenta { get; set; }
        public float minimoInventario { get; set; }
        public float maximoInventario { get; set; }
        public float cantidadProductoCaja { get; set; }
        public string codigoBarras { get; set; }


    }
}
