using ConexionBD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static ConexionBD.Enumerados;

namespace ConexionBD
{
    public class PuntoVenta
    {
        ERPProdEntities oContext;

        public PuntoVenta()
        {
            oContext = new ERPProdEntities();
        }

        public string pagar(ref long ventaId,
            int? clienteId,
            string folio,
            decimal porcDescuentoVenta,
            decimal montoDescuentoVenta,
            decimal descuentoEnPartidas,
            decimal impuestos,
            decimal subTotal,
            decimal totalVenta,
            decimal totalRecibido,
            decimal cambio,
            bool descuentoVentaSiNo,
            int sucursalId,
            int usuarioId,
            int cajaId,
            List<ProductoModel0> productos,
            List<FormaPagoModel> formasPago,
        List<ValeFPModel> vales,
        int pedidoOrdenId,
        bool Facturar,
        int? empleadoId = null
        )
        {
            string error = "";

            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted,
                    Timeout = TimeSpan.FromMinutes(5)
                };

                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                {
                   if(clienteId==0)
                    {
                        clienteId = null;
                    }
                    ObjectParameter pVentaId = new ObjectParameter("pVentaId", 0);

                    DateTime fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                    /**************Validar que no existan tickets con fechas inconsistentes*******************/                   

                    oContext.p_InsertarVenta(pVentaId, folio, fechaActual, clienteId, descuentoVentaSiNo, porcDescuentoVenta, montoDescuentoVenta, descuentoEnPartidas,
                       montoDescuentoVenta + descuentoEnPartidas, impuestos, subTotal, totalVenta, totalRecibido, cambio, true, usuarioId, DateTime.Now, null, null,sucursalId,cajaId,pedidoOrdenId,Facturar,empleadoId);

                    ventaId = long.Parse(pVentaId.Value.ToString());
                    foreach (ProductoModel0 itemProducto in productos)
                    {
                        oContext.p_InsertarVentaDetalle(0, int.Parse(pVentaId.Value.ToString()), itemProducto.productoId, itemProducto.cantidad,itemProducto.descripcion, itemProducto.precioUnitario,
                            itemProducto.porcDescuento, itemProducto.montoDescuento, itemProducto.impuestos, itemProducto.total, usuarioId, DateTime.Now,
                            itemProducto.tipoDescuentoId,itemProducto.promocionCMId,itemProducto.cargoAdicionalId,null,itemProducto.paraLlevar,itemProducto.paraMesa);
                    }

                    foreach (FormaPagoModel itemFP in formasPago)
                    {
                        if (itemFP.cantidad > 0)
                        {
                            oContext.p_InsertarVentaFormaPago(itemFP.id, int.Parse(pVentaId.Value.ToString()), itemFP.cantidad, 1,itemFP.digitoVerificador);
                        }
                    }

                    foreach (ValeFPModel itemVale in vales)
                    {
                        oContext.p_doc_venta_fp_vale_ins(0, int.Parse(pVentaId.Value.ToString()), (int)tipoVale.devolucion, itemVale.monto, itemVale.folioVale);
                    }

                    oContext.p_venta_afecta_inventario(int.Parse(pVentaId.Value.ToString()), usuarioId);

                    

                    //oContext.SaveChanges();
                    scope.Complete();

                }
           }
            catch (Exception ex)
            {
                error = ex.Message;
                
            }

            return error;
        }
    }
}
