using ConexionBD;
using ERP.Models.ProductoSobrante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraReports.UI;
namespace ERP.Common.Reports
{
    public class ReportPrint
    {
        public static void imprimirProductoSobrante(int sucursalId, DateTime fecha, int usuarioId,int cajaId)
        {
            try
            {
                int year = fecha.Year;
                int month = fecha.Month;
                int day = fecha.Day;

                ERPProdEntities oContext = new ERPProdEntities();
                ERP.Reports.rptProductoSobranteDia oTicket2 = new ERP.Reports.rptProductoSobranteDia();


                ReportViewer oViewer = new ReportViewer(cajaId);

                oTicket2.DataSource = oContext.doc_productos_sobrantes_registro
                    .Where(
                        w => w.SucursalId == sucursalId &&
                        w.CreadoEl.Value.Year == year &&
                        w.CreadoEl.Value.Month == month &&
                        w.CreadoEl.Value.Day == day
                    )
                    .Select(s => new ProductoSobranteModel()
                    {
                        cantidadInventarioTeorico = s.CantidadInventario ?? 0M,
                        cantidadSobrante = s.CantidadSobrante ?? 0,
                        nombreSucursal = s.cat_sucursales.NombreSucursal,
                        producto = s.cat_productos.Descripcion,
                        productoId = s.ProductoId ?? 0,
                        sucursalId = s.SucursalId ?? 0,
                        fecha = s.CreadoEl ?? DateTime.MinValue
                    }).OrderBy(o => o.producto).ToList();

                //Imprimir solo si hay datos
                if(((List<ProductoSobranteModel>)oTicket2.DataSource).Count() > 0){
                    oViewer.ShowTicket(oTicket2);
                }
               
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                               "ERP",
                               "ERP.Business.ReportesBusiness",
                               ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }


        public static string imprimirRptCorteCajaPedidosPagos(int sucursalId, int cajaId, int usuarioId)
        {
            int err = 0;
            try
            {

                ERPProdEntities oContext = new ERPProdEntities();
                ImpresorasBusiness oImpresora = new ImpresorasBusiness();
                cat_impresoras entityImpresora;
                entityImpresora = oImpresora.ObtenerCajaImpresora(cajaId);
                ERP.Reports.TacosAna.rptCorteCajaPedidoPagos oReport = new ERP.Reports.TacosAna.rptCorteCajaPedidoPagos();
                DateTime fechaCorte = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                oReport.DataSource = oContext.p_rpt_corte_caja_pedidos_pagos(sucursalId,
                    fechaCorte).ToList();
                oReport.CreateDocument();

                if (entityImpresora != null &&
                    ((List<p_rpt_corte_caja_pedidos_pagos_Result>)oReport.DataSource).Count() >0)
                {
                    if (entityImpresora.NombreRed != "")
                    {
                        oReport.Print(entityImpresora.NombreRed);
                    }


                }

                return "";

            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                               "ERP",
                              "ERP.Business.ReportesBusiness",
                               ex);

                return String.Format("Ocurrió un problema con tu solicitud. Bitácora Num[{0}]", err);
            }

        }
    }
}
