using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using ConexionBD;
using System.Linq;
using ERP.Reports;

namespace ERP.Reports
{
    /// <summary>
    /// Summary description for rptCorteCaja.
    /// </summary>
    public partial class rptCorteCaja : GrapeCity.ActiveReports.SectionReport
    {
        int sucursalId;
        public bool esAdmin{get;set;}
        ERPProdEntities oContext;
        public rptCorteCaja()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            oContext = new ERPProdEntities();
            this.Document.PrintOptions.Margin = new GrapeCity.ActiveReports.Extensibility.Printing.Margin(0, 0, 0, 0);
            this.Document.PrintOptions.PrintPageBorder = false;

            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            if (entity != null)
            {

                detail.Visible = entity.CajeroIncluirDetalleVenta ?? false;

            }

        }

        public rptCorteCaja(int _sucursalId)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            oContext = new ERPProdEntities();
            this.Document.PrintOptions.Margin = new GrapeCity.ActiveReports.Extensibility.Printing.Margin(0, 0, 0, 0);
            this.Document.PrintOptions.PrintPageBorder = false;

            sucursalId = _sucursalId;

            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            if (entity != null)
            {

                detail.Visible = entity.CajeroIncluirDetalleVenta ?? false;

            }

        }


        private void detail_Format(object sender, EventArgs e)
        {
            
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {
            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            if (entity != null)
            {
                uiEnc1.Visible = entity.CajeroIncluirDetalleVenta ?? false;
                uiEnc2.Visible = entity.CajeroIncluirDetalleVenta ?? false;
            }

            subRptLogo oReportFoto = new subRptLogo();
            subRepFoto.Report = oReportFoto;
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
            

        }

        private void groupFooter1_Format(object sender, EventArgs e)
        {
            oContext = new ERPProdEntities();
            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            int folio;

            int.TryParse(uiCorteId.Text, out folio);
            #region cancelaciones

            subRptCancelaciones oReportCan = new subRptCancelaciones();
            if (
                (entity.CajeroCorteCancelaciones ?? false &&
                !esAdmin)
                ||
                 (entity.SupCorteCancelaciones ?? false &&
                esAdmin)
                )
            {
                subCancelaciones.Report = oReportCan;
                subCancelaciones.Report.DataSource = oContext.p_rpt_corte_caja_cancelaciones(folio).ToList();
                subCancelaciones.Visible = true;
            }

            #endregion
            #region gastos
            subRptGastos oReportGas = new subRptGastos();

            if (
                    (entity.CajeroCorteDetGasto ?? false &&
                    !esAdmin)
                    ||
                     (entity.SupCorteDetGasto ?? false &&
                    esAdmin)
                    )
            {
                subGastos.Report = oReportGas;
                subGastos.Report.DataSource = oContext.p_rpt_corte_caja_gastos(folio).ToList();
                subGastos.Visible = true;
            }
            #endregion
            #region retiros

            subRptRetirosList oReportRet = new subRptRetirosList();


            subRetiros.Report = oReportRet;
            subRetiros.Report.DataSource = oContext.p_rpt_corte_caja_retiros(folio).ToList();


            #endregion
            #region denominaciones
            if (
                (entity.CajDeclaracionFondoCorte ?? false &&
                !esAdmin)
                ||
                 (entity.SupDeclaracionFondoCorte ?? false &&
                esAdmin)
                )
            {
                subRptCorteDenominacion oReportDenom = new subRptCorteDenominacion();
                subDenom.Report = oReportDenom;
                subDenom.Report.DataSource = oContext.p_rpt_corte_caja_denom(folio).ToList();
                subGastos.Visible = true;
            }
            #endregion

            #region descuentos
            subRptDescuentos oReportDescuentos = new subRptDescuentos();
            subDescuentos.Report = oReportDescuentos;
            subDescuentos.Report.DataSource = oContext.p_rpt_corte_caja_descuentos(folio).ToList();
            subDescuentos.Visible = true;

            #endregion

            #region DEVOLUCIONES
            subRptDevoluciones oReportDevoluciones = new subRptDevoluciones();
            subDevoluciones.Report = oReportDevoluciones;
            subDevoluciones.Report.DataSource = oContext.p_rpt_corte_caja_devoluciones(folio).ToList();
            subDevoluciones.Visible = true;
            #endregion


            #region EXISTENCIAS


            subRptProductoExistencias oReportExist = new subRptProductoExistencias();
            subExistencias.Report = oReportExist;
            subExistencias.Report.DataSource = oContext.p_rpt_corte_productos_existencias(folio, true).ToList();
            subExistencias.Visible = entity.CorteCajaIncluirExistencia ?? false;
            #endregion


            #region APARTADOS
            subRptCorteCajaApartado oReportAapartado = new subRptCorteCajaApartado();
            subApartados.Report = oReportAapartado;
            subApartados.Report.DataSource = oContext.p_rpt_corte_caja_apartados(folio).ToList();
            subApartados.Visible = true;
            #endregion

            #region apartados detalle
            subRptCorteCajaApartadoDet oReportAapartadoDet = new subRptCorteCajaApartadoDet();
            subApartadosDetalle.Report = oReportAapartadoDet;
            subApartadosDetalle.Report.DataSource = oContext.p_rpt_corte_caja_apartados_det(folio).ToList();
            subApartadosDetalle.Visible = true;
            #endregion

            #region reimpresiones
            subRptReimpresionTicket oReportReimpresionTicket = new subRptReimpresionTicket();
            subReimpresiones.Report = oReportReimpresionTicket;
            subReimpresiones.Report.DataSource = oContext.p_rpt_corte_reimpresiones(folio).ToList();
            subReimpresiones.Visible = true;
            #endregion

            #region valesdetalle

            subRptCorteCajaVales oReportVales = new subRptCorteCajaVales();
            subVales.Report = oReportVales;
            subVales.Report.DataSource = oContext.p_rpt_corte_caja_vales(folio).ToList();
            subVales.Visible = true;
            #endregion


            #region dig apartados

            subRptCorteCajaDigitoTpv oReportDig = new subRptCorteCajaDigitoTpv();
            this.subDigito.Report = oReportDig;
            subDigito.Report.DataSource = oContext.p_rpt_corte_caja_tpv_digito(folio).ToList();
            subDigito.Visible = true;

            #endregion

            #region pedidos pendientes
            subRptPedidosSinCerrar oReportpED = new subRptPedidosSinCerrar();
            this.subReport1.Report = oReportpED;
            this.subReport1.Visible = true;
            subReport1.Report.DataSource = oContext.doc_corte_caja_pedidos_sin_cerrar
                .Where(w=> w.CorteCajaId == folio)
                .Select(s=> new {
                    Folio = s.doc_pedidos_orden.Folio,
                    Total = s.doc_pedidos_orden.Total,
                    Tipo = s.doc_pedidos_orden.cat_tipos_pedido.Nombre
                })
                .OrderBy(o=> o.Folio).ToList();

            #endregion

            


        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            oContext = new ERPProdEntities();

            int folio;

            int.TryParse(uiCorteId.Text, out folio);
            oContext = new ERPProdEntities();
            doc_corte_caja corte = oContext.doc_corte_caja
                .Where(w => w.CorteCajaId == folio).FirstOrDefault();
            subRptVentaFormasPago oReportGas = new subRptVentaFormasPago();
            
            subFormasPago.Report = oReportGas;
            subFormasPago.Report.DataSource = oContext.p_rpt_corte_caja_fp(folio).ToList();

            #region Ventas Por Producto

            if (oContext.sis_preferencias_empresa
                .Where(w => w.sis_preferencias.Preferencia == "CorteCajaSubReporteVentasProd").Count() > 0)
            {
                this.subReport2.Visible = true;

                subRptCorteCajaVentaPorProducto oReporteVentasPorProducto = new subRptCorteCajaVentaPorProducto();
                this.subReport2.Report = oReporteVentasPorProducto;

                subReport2.Report.DataSource = oContext.p_rpt_corte_caja_venta_por_producto(1, folio).ToList();
            }
            else
            {
                this.subReport2.Visible = true;
            }
            #endregion

            #region Exis Ini y Ventas Por Producto

            if (oContext.sis_preferencias_empresa
                .Where(w => w.sis_preferencias.Preferencia == "CorteCajaSubReporteVentasExistenciasProd").Count() > 0)
            {
                this.subReport3.Visible = true;

                subRptCorteCajaVentaExisPorProducto oReporteVentasPorProducto = new subRptCorteCajaVentaExisPorProducto();
                this.subReport3.Report = oReporteVentasPorProducto;               

                subReport3.Report.DataSource = oContext.p_rpt_corte_caja_producto(corte.doc_ventas.SucursalId, corte.FechaApertura,corte.FechaCorte).ToList();
            }
            else
            {
                this.subReport3.Visible = true;
            }
            #endregion

            #region gramos a favor en contra
            var oCorte = oContext.doc_corte_caja.Where(w => w.CorteCajaId == folio).FirstOrDefault();
            subRptGramosFavorContra oReportGFC = new subRptGramosFavorContra();
            this.subReport4.Report = oReportGFC;
            this.subReport4.Visible = true;
            this.subReport4.Report.DataSource = oContext.p_rpt_gramos_favor_contra_agrupado(corte.doc_ventas.SucursalId, oCorte.FechaCorte, oCorte.FechaCorte).ToList();
            #endregion
        }

        private void rptCorteCaja_ReportStart(object sender, EventArgs e)
        {

        }
    }
}
