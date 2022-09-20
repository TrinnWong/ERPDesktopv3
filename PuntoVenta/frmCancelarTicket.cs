using ConexionBD;
using ConexionBD.Models;
using ERP.Common.Reports;
using ERP.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVenta
{
    public partial class frmCancelarTicket : Form
    {
        public int ventaId;
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        public frmCancelarTicket()
        {
            InitializeComponent();

            oContext = new ERPProdEntities();
        }

        public void llenarForma()
        {
            doc_ventas oVenta = oContext.doc_ventas
                .Where(
                    w => w.VentaId == ventaId &&
                    w.Activo == true &&
                    w.FechaCancelacion == null
                ).FirstOrDefault();

            if (oVenta != null)
            {
                string serie = oVenta.Serie;

                uiTicket.Text = (serie == null ? "" : serie) +
                    oVenta.VentaId;


            }
            else {
                MessageBox.Show("No fue posible encontrar la información del ticket. No es posible cancelar",
                    "ERROR",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();

            }


        }

        private void frmCancelarTicket_Load(object sender, EventArgs e)
        {
            llenarForma();
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                oContext = new ERPProdEntities();

                if (uiMotivo.Text.Trim() == "")
                {
                    MessageBox.Show("Es necesario ingresar el motivo de cancelación");
                    return;
                }

                doc_ventas entityVenta = oContext.doc_ventas.Where(w => w.VentaId == ventaId).FirstOrDefault();

                if (entityVenta != null)
                {
                    DateTime fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                    if (fechaActual.Date != entityVenta.Fecha.Date)
                    {
                        MessageBox.Show("Solo se pueden cancelar tickets del día actual", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (entityVenta.Activo == false)
                    {
                        MessageBox.Show("No es posible volver a cancelar el ticket", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (entityVenta != null)
                    {
                        if (MessageBox.Show("¿Está seguro de cancelar el ticket con folio:" + entityVenta.Folio, "AVISO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            oContext.p_doc_ventas_cancelacion(ventaId, puntoVentaContext.usuarioId,uiMotivo.Text);

                            MessageBox.Show("El ticket con folio:" + entityVenta.Folio + " ha sido cancelado", "AVISO");

                            imprimirTicket();
                            this.Close();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Es necesario primero buscar el ticket a cancelar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Es necesario primero buscar un ticket", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(
                    ex.InnerException != null ? ex.InnerException.Message:ex.Message, "ERROR",
                     MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
            }
        }


        private void imprimirTicket()
        {

            try
            {
                rptVentaTicket oTicket = new rptVentaTicket();

                ReportViewer oViewer = new ReportViewer();

                oTicket.DataSource = oContext.p_rpt_VentaTicket(this.ventaId).ToList();

                oViewer.ShowTicket(oTicket);
            }
            catch (Exception EX)
            {

                MessageBox.Show(EX.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }
}
