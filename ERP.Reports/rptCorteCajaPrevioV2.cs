using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using ConexionBD;
using System.Linq;

namespace ERP.Reports
{
    /// <summary>
    /// Summary description for rptCorteCajaPrevioV2.
    /// </summary>
    public partial class rptCorteCajaPrevioV2 : GrapeCity.ActiveReports.SectionReport
    {
        public bool esAdmin { get; set; }
        ERPProdEntities oContext;
        public rptCorteCajaPrevioV2()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        private void detail_Format(object sender, EventArgs e)
        {
            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            if (entity != null)
            {

                detail.Visible = entity.CajeroIncluirDetalleVenta ?? false;

            }
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

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            int folio;

            int.TryParse(uiCorteId.Text, out folio);
            subRptVentaFormasPago oReportGas = new subRptVentaFormasPago();

            subFormasPago.Report = oReportGas;
            subFormasPago.Report.DataSource = oContext.p_rpt_corte_caja_fp_previo(folio).ToList();
        }

        private void groupFooter1_Format(object sender, EventArgs e)
        {
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
                subCancelaciones.Report.DataSource = oContext.p_rpt_corte_caja_cancelaciones_previo(folio).ToList();
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
                subGastos.Report.DataSource = oContext.p_rpt_corte_caja_gastos_previo(folio).ToList();
                subGastos.Visible = true;
            }
            #endregion
            #region retiros

            subRptRetirosList oReportRet = new subRptRetirosList();


            subRetiros.Report = oReportRet;
            subRetiros.Report.DataSource = oContext.p_rpt_corte_caja_retiros_previo(folio).ToList();


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
                subDenom.Report.DataSource = oContext.p_rpt_corte_caja_denom_previo(folio).ToList();
                subGastos.Visible = true;
            }
            #endregion

            #region descuentos
            subRptDescuentos oReportDescuentos = new subRptDescuentos();
            subDescuentos.Report = oReportDescuentos;
            subDescuentos.Report.DataSource = oContext.p_rpt_corte_caja_descuentos_previo(folio).ToList();
            subDescuentos.Visible = true;

            #endregion

            #region DEVOLUCIONES
            subRptDevoluciones oReportDevoluciones = new subRptDevoluciones();
            subDevoluciones.Report = oReportDevoluciones;
            subDevoluciones.Report.DataSource = oContext.p_rpt_corte_caja_devoluciones_previo(folio).ToList();
            subDevoluciones.Visible = true;
            #endregion


            #region EXISTENCIAS


            subRptProductoExistencias oReportExist = new subRptProductoExistencias();
            subExistencias.Report = oReportExist;
            subExistencias.Report.DataSource = oContext.p_rpt_corte_productos_existencias_previo(folio, true).ToList();
            subExistencias.Visible = entity.CorteCajaIncluirExistencia ?? false;
            #endregion


            #region APARTADOS
            subRptCorteCajaApartado oReportAapartado = new subRptCorteCajaApartado();
            subApartados.Report = oReportAapartado;
            subApartados.Report.DataSource = oContext.p_rpt_corte_caja_apartados_previo(folio).ToList();
            subApartados.Visible = true;
            #endregion

            #region apartados detalle
            subRptCorteCajaApartadoDet oReportAapartadoDet = new subRptCorteCajaApartadoDet();
            subApartadosDetalle.Report = oReportAapartadoDet;
            subApartadosDetalle.Report.DataSource = oContext.p_rpt_corte_caja_apartados_det_previo(folio).ToList();
            subApartadosDetalle.Visible = true;
            #endregion

            #region reimpresiones
            //subRptReimpresionTicket oReportReimpresionTicket = new subRptReimpresionTicket();
            //subReimpresiones.Report = oReportReimpresionTicket;
            //subReimpresiones.Report.DataSource = oContext.p_rpt_corte_reimpresiones(folio).ToList();
            //subReimpresiones.Visible = true;
            #endregion

            #region valesdetalle

            subRptCorteCajaVales oReportVales = new subRptCorteCajaVales();
            subVales.Report = oReportVales;
            subVales.Report.DataSource = oContext.p_rpt_corte_caja_vales_previo(folio).ToList();
            subVales.Visible = true;
            #endregion


            #region dig apartados

            subRptCorteCajaDigitoTpv oReportDig = new subRptCorteCajaDigitoTpv();
            this.subDigito.Report = oReportDig;
            subDigito.Report.DataSource = oContext.p_rpt_corte_caja_tpv_digito_previo(folio).ToList();
            subDigito.Visible = true;

            #endregion
        }
    }
}
