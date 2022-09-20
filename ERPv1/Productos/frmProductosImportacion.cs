using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using ERP.Common.Procesos;
using ERP.Common.Reports;
using ERP.Reports;
using LinqToExcel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace ERPv1.Productos
{
    public partial class frmProductosImportacion : Form
    {
        ERPProdEntities oContext;
        private static frmProductosImportacion _instance;
        public PuntoVentaContext puntoVentaContext;

        string filePath="";
        public static frmProductosImportacion GetInstance()
        {
            if (_instance == null) _instance = new frmProductosImportacion();
            else _instance.BringToFront();
            return _instance;
        }
        public frmProductosImportacion()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        private void btnBuscarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();



            openFileDialog1.InitialDirectory = @"C:\";

            openFileDialog1.Title = "Browse Text Files";



            openFileDialog1.CheckFileExists = true;

            openFileDialog1.CheckPathExists = true;



           // openFileDialog1.DefaultExt = "txt";

            //openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            openFileDialog1.FilterIndex = 2;

            openFileDialog1.RestoreDirectory = true;



            openFileDialog1.ReadOnlyChecked = true;

            openFileDialog1.ShowReadOnly = true;



            if (openFileDialog1.ShowDialog() == DialogResult.OK)

            {

                filePath = openFileDialog1.FileName;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {

                if (XtraMessageBox.Show("¿Está seguro de continuar?, esta acción afectará el inventario", "Avso", MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

               
                System.Threading.Thread.Sleep(1000);

                ProductoBusiness ob = new ProductoBusiness();

                Guid uuid = new Guid();
                string error = "";
                uiResultado.Text = "IMPORTANDO.....\n";
                error = ob.ImportarProductosConfigInicial(this.filePath, this.puntoVentaContext, ref uuid);

                if (error.Length > 0)
                {
                    uiResultado.Text = "*********ERROR****************\n";

                    uiResultado.Text = uiResultado.Text + error;
                    //XtraMessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    uiResultado.Text = "EL PROCESO TERMINÓ CON ÉXITO......";
                    imprimir(uuid);
                }
                
               


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void frmProductosImportacion_Load(object sender, EventArgs e)
        {

        }

        private void frmProductosImportacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmImpProductoReimpresion oForm = new frmImpProductoReimpresion();

            oForm.ShowDialog();
        }
    }
}
