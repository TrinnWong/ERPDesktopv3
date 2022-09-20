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
    public partial class frmCorteCajaPrevioList : Form
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        private static frmCorteCajaPrevioList _instance;
        public static frmCorteCajaPrevioList GetInstance()
        {

            if (_instance == null) _instance = new frmCorteCajaPrevioList();
            return _instance;
        }
        public frmCorteCajaPrevioList()
        {
            InitializeComponent();
        }

        public void llenarGrid()
        {
            try
            {
                int cajaId = puntoVentaContext.cajaId;
                oContext = new ERPProdEntities();
                uiGrid.DataSource = oContext.doc_corte_caja_previo
                    .Where(w=> w.CajaId == cajaId)
                    .Select(
                        s=> new
                        {
                            Folio = s.CorteCajaId,
                            TotalCorte = s.TotalCorte,
                            Fecha = s.FechaCorte
                        }
                    )
                    .OrderByDescending(o=> o.Fecha)
                     .ToList();
            }
            catch (Exception ex)
            {

                
            }
        }

        private void frmCorteCajaPrevioList_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void reimprimirPrevio(int corteCaja)
        {
            try
            {
                int corteId = corteCaja;

                rptCorteCajaPrevioV2 oCorte = new rptCorteCajaPrevioV2();
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

        private void uiGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if(
                    MessageBox.Show("¿Está seguro de generar el corte parcial?","Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)== DialogResult.Yes
                    )
                {
                    DateTime fecha = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                    ObjectParameter pCorteCajaId = new ObjectParameter("pCorteCajaId", 0);
                    oContext.p_corte_caja_generacion_previo(puntoVentaContext.cajaId,
                        puntoVentaContext.usuarioId, fecha, pCorteCajaId, true);


                    reimprimirPrevio(int.Parse(pCorteCajaId.Value.ToString()));

                    llenarGrid();
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uiReimprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (uiGrid.SelectedRows.Count > 0)
                {
                    string uuid = uiGrid.SelectedRows[0].Cells["Folio"].Value.ToString();

                    reimprimirPrevio(int.Parse(uuid));
                }
                else
                {
                    MessageBox.Show("Es necesario seleccionar una fila", "Aviso"
                        , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {


            }
        }
    }
}
