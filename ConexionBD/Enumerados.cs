using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class Enumerados
    {
        public static string CS = "data source=##SERVERDB##;initial catalog=##BD##;user id=##USERBD##;password=##PASSWORD##;MultipleActiveResultSets=True;App=EntityFramework";
        public enum accionForm
        {
            agregar = 1,
            actualizar=2,
            eliminar = 3
          
        }
        public enum precios
        {
            publicoGral = 1,
            medioMayoreo = 2
        }

        public enum impuestos
        {
            IVA = 1
        }

        public enum proceso
        {
            retiroEfectivo = 1
        }

        public enum tipoVale
        {
            devolucion= 1
        }

        public enum tipoMovsInventario
        {
            cargaInicial = 1,
                entradaPorCompra=2,
                entradaPorTraspaso=3,
                salidaPorTraspaso=4,
                ajustePorEntrada=5,
                ajustePorSalida=6,
                entradaDirecta=7,
                desperdicioInventario=25

        }

        public enum opcionesERP
        {
            productosCompra = 1,
            ajusteEntrada = 2,
            ajusteSalida=3,
            entradaDirecta=4,
            entradaTraspaso=5,
            kardexProducto=6,
            apartadosUpd=7
        }

        public enum opcionesPV
        {
           reimpresionTicket =5,
           cancelarTicket=6,
           registroGastos=7,
           devoluciones=8,
           apartados=9,
           existencias=10,
           apartadosPagos=11
        }
        
        public enum systemGiro
        {
            REST=2,
            AUTOLAV = 1,
            ESTANDAR = 0
        }

        public enum tipoDescuento
        {
            DESCUENTO_PROMOCION = 1,
            CORTESIA = 2,
            DESCUENTO_EMPLEADO=3
        }

        public enum Lineas
        {
            SinDefinir = 0
        }
        public enum Familia
        {
            SinDefinir = 0
        }
        public enum SubFamilia
        {
            SinDefinir = 0
        }

        
    }
}
