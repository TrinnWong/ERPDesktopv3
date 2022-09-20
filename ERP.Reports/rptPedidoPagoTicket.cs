using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using ConexionBD;
using ERP.Reports;

namespace ERP.Reports
{
    /// <summary>
    /// Summary description for rptApartadoTicket.
    /// </summary>
    public partial class rptPedidoPagoTicket : GrapeCity.ActiveReports.SectionReport
    {

        public rptPedidoPagoTicket()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void reportFooter1_Format(object sender, EventArgs e)
        {
            List<p_rpt_pedido_pago_ticket_Result> result = ((List<p_rpt_pedido_pago_ticket_Result>)this.DataSource);

            if(result.Count> 0)
            {
                uiTotal.Text = result[0].TotalApartado.ToString("c2");
                uiFechaApartado.Text = result[0].FechaApartado.ToShortDateString();
                uiSaldo.Text = (result[0].Saldo??0).ToString("c2");
                uiPagoRecibido.Text = result[0].PagoRealizado.ToString("c2");
                uiFechaLimite.Text = result[0].FechaLimite.Value.ToShortDateString();
                uiClienteId.Text = result[0].ClienteId.ToString();
                uiCliente.Text = result[0].Cliente.ToString();
                uiTextoPie.Text = result[0].TextoPie.ToString();
                uiAtendio.Text = result[0].Atendio.ToString();
                textBox3.Text = result[0].Politica.ToString();
            }
            



        }

        private void pageHeader_Format(object sender, EventArgs e)
        {
            subRptLogo oReportFoto = new subRptLogo();
            subRepFoto.Report = oReportFoto;
        }
    }
}
