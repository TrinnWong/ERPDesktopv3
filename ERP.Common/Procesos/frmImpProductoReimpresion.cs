using ConexionBD;
using ConexionBD.Models;
using ERP.Common.Reports;
using ERP.Procesos;
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

namespace ERP.Common.Procesos
{
    public partial class frmImpProductoReimpresion : Form
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        public frmImpProductoReimpresion()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        private static frmImpProductoReimpresion _instance;
        public static frmImpProductoReimpresion GetInstance()
        {

            if (_instance == null) _instance = new frmImpProductoReimpresion();
            return _instance;
        }

        public void llenarGrid()
        {
            try
            {
                uiGrid.DataSource = oContext.p_productos_importacion_bitacora_sel().ToList();
            }
            catch (Exception)
            {

                
            }
        }

        private void frmImpProductoReimpresion_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void uiReimprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if(uiGrid.SelectedRows.Count > 0)
                {
                    string uuid = uiGrid.SelectedRows[0].Cells["UUID"].Value.ToString();

                    imprimir(Guid.Parse(uuid));
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


        private void imprimir(Guid uuid)
        {
            try
            {
                rptProductoImportacion oReport = new rptProductoImportacion();
                ReportViewer oViewer = new ReportViewer();

                oReport.DataSource = oContext.p_rpt_productos_importacion(uuid).ToList();

                oViewer.ShowTicket(oReport);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar imprimir el resumen", "ERRPR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
