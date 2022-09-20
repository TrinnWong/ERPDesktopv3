using ConexionBD;
using ConexionBD.Models;
using ERP.Common.Reports;
using ERP.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Procesos
{
    public partial class frmCorteCajaPrevio : Form
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        private static frmCorteCajaPrevio _instance;
        public static frmCorteCajaPrevio GetInstance()
        {

            if (_instance == null) _instance = new frmCorteCajaPrevio();
            return _instance;
        }

        public frmCorteCajaPrevio()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                ObjectParameter pCorteCajaId = new ObjectParameter("pCorteCajaId", 0);
                oContext.p_corte_caja_generacion_previo(puntoVentaContext.cajaId,
                    puntoVentaContext.usuarioId, fecha, pCorteCajaId,true);


                reimprimirPrevio(int.Parse(pCorteCajaId.Value.ToString()));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reimprimirPrevio(int corteCaja)
        {
            try
            {
                    int corteId = corteCaja;

                    rptCorteCaja oCorte = new rptCorteCaja();
                    ReportViewer oViewer = new ReportViewer();

                    oCorte.DataSource = oContext.p_rpt_corte_caja_enc_previo(corteId).ToList();
                    oCorte.esAdmin = this.puntoVentaContext.esSupervisor;
                    oViewer.ShowTicket(oCorte);
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
