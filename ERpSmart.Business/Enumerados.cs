using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business
{
   
   
    public class Enumerados
    {
        public enum TipoProducto
        {
            ERP =2,
            PV = 1
        }

        public enum sistemasTrinn
        {
            eCommerce = 1
        }

        public enum Menu
        {
            Comandas=1,
            Cuentas=2,
            Ticket=3,
            Caja=4,           
            Nueva_Comanda=6,
            Imprimir_Comanda=7,
            Imprimir_Cuenta=8,
            Cancelar_Cuenta=9,
            Ver_Cuentas=10,
            Pagar=11,
            Buscar_Ticket=12,
            Reimprimir_Ticket=13,
            Cancelar_Ticket=14,
            Retiros=15,
            Gastos=16,
            Corte_Caja=17,
            Abrir_Cajon=18,
            Impresoras=19,
            Impresora_Tickets=20,
            Impresora_Comanda=21
        }

        public enum CargoAdicional
        {
            EnvioUberEats = 1
        }

        public enum UserDefault
        { 
            UserDefault = 1
        }

        public enum formaPagoOnline
        {
            paypal = 1,
            openPayTarjeta = 2,
            mercadoLibreTarjeta = 3,
            mercadoLibreOxxo = 3
        }

        public enum formasPago
        {
            EFECTIVO = 1,
            TARJETA_DE_CRÉDITO = 2,
            TARJETA_DE_DEBITO = 3,
            CH = 4,
            VALES = 5
        }


        
        public static int sucursalWEB = 1;
        public static int cajaWeb = 1;
         public static string urlAPI_ERP = "http://erpapi.english-user.com/api/";
        //public static string urlAPI_ERP = "http://localhost:58868/api/";
        //public static string urlAPI_ERP = "http://localhost/erp/api/";

        public enum productosSistema
        {
            fletes=-2,
            comisiones=-3,
            cocimiento=-999
        }

        public enum tipoDescuento
        {
            promocion=1,
            cortesia=2,
            descuentoEmpleado=3
        }

        public enum roles
        {
            adiministradorSistema = 1
        }

        public enum estatusProduccion
        {
            Registrada=1,
            En_Produccion=2,
            Produccion_Terminada = 3
        }

        public enum tipoBasculaBitacora
        {
            VentaMostrador= 1,
            InsumoProduccion=2,
            SalidaDeProduccion=3,
            Indefinido=4,
            VentaPedidoMayoreo = 5,
            ProductoSobrante= 6,
            Traspaso = 7,
            Cortesia = 8,
            EntradaInventario = 9,
            SalidaInventario = 10,
            DesperdicioInventario=11,
            CancelacionProductoPV=12,
            CancelacionVentaPV =13,
            PrecioEmpleado=14,
            VentaMayoreoPorPagar = 15
        }

        public enum tipoMovimientoInventario
        {
            Carga_Inicial =	1,
            Compra_Productos=2,
            EntradaPorTraspaso	=3,
            SalidaPorTraspaso	=4,
            AjustePorEntrada	=5,
            AjustePorSalida	=6,
            EntradaDirecta =7,
            VentaCaja =	8,
            CancelaCargaInicial=	9,
            CancelaCompraProductos	=10,
            CancelaEntradaPorTraspaso =	11,
            CancelaSalidaPorTraspaso=	12,
            CancelaAjustePorEntrada=	13,
            CancelaAjustePorSalida=	14,
            CancelaEntradaDirecta =	15,
            CancelaVentaCaja =	16,
            Apartado	=17,
            CancelacionApartado=	18,
            CancelaDevolucion=	19,
            Devolucion =	20,
            InsumoInternoProduccion =	21,
            ProductoProduccion =	22,
            Cancelacion_Insumo_Interno_Produccion =	23,
            Cancelacion_Producto_Produccion	=24,
            EntradaPorTraspasoDev = 28,
            SalidaPorTraspasoDev = 30
        }

        public enum tipoPrecioProducto
        {
            PublicoGeneral = 1,
            MedioMayoreo = 2,
            Mayoreo = 3,
            Franquicias = 4,
            Distribuidores = 5
        }
        public enum tipoVale
        {
            devolucion = 1
        }
        public enum tipoPedido
        {
            PedidoClienteMayoreo = 1,
            PedidoTelefono=2,
            PedidoVentaCaja=3
        }

        public enum tipoModalProducto {
            venta=1,
            traspasoSucursal = 2,
            sobranteProducto=3
        }

        public enum tipoProductoLicencia
        {
            LICENCIA_PUNTO_DE_VENTA = 10001,
            LICENCIA_ERP_DESKTOP = 10002
        }

        public enum tipoProductoProduccion
        {
            COCINA =1,
            OTRO = 2,
            TODO=2
        }
    }
}
