using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using ERP.Common.Base;
using ERP.Common.Catalogos;
using ERP.Common.Catalogos.Restaurante;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Configuracion
{
    public partial class ConfigInicial : FormBaseXtraForm
    {
        string filePath = "";
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        private static ConfigInicial _instance;

        public static ConfigInicial GetInstance()
        {
            if (_instance == null) _instance = new ConfigInicial();
            return _instance;
        }

        public ConfigInicial()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string folderApp = System.Windows.Forms.Application.StartupPath + "\\cargaProductos.xlsx";
                //ProcessStartInfo startInfo = new ProcessStartInfo();
                //startInfo.FileName = "EXCEL.EXE";
                //startInfo.Arguments = folderApp ;
                //Process.Start(startInfo);

                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbooks workbooks = app.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Open(folderApp);
                //Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.Worksheets[1];

                //do stuff to worksheet here

                workbooks.Application.Visible = true;
               


            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un error al intentar abrir la plantilla, asegurese de tener instalado EXCEL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void uiImportar_Click(object sender, EventArgs e)
        {
            try
            {
                if(filePath.Length ==0)
                {
                    XtraMessageBox.Show("No se ha seleccionado ningun archivo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if(XtraMessageBox.Show("¿Está seguro de continuar?, esta acción afectará el inventario","Avso", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                uiImportar.Text = "PROCESANDO ESPERE........";
                System.Threading.Thread.Sleep(1000);

                ProductoBusiness ob = new ProductoBusiness();

                Guid uuid=new Guid();
                string error = "";
                error = ob.ImportarProductosConfigInicial(this.filePath,this.puntoVentaContext, ref uuid);

                if(error.Length > 0)
                {
                    XtraMessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                oContext = new ERPProdEntities();
                uiResultados.DataSource = oContext.p_rpt_productos_importacion(uuid).ToList();


                uiImportar.Text = "Importar";

                ConfigTabPage();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un error durante la importación", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigTabPage()
        {
            var nProds = oContext.cat_productos.Where(w=> w.ProductoId > 0).Count();
            if(nProds > 0)
            {
                uiTabProductos.Appearance.Header.ForeColor = Color.Green;
                uiTabProductos.Text = "PRODUCTOS (COMPLETADO)";
            }
            if(oContext.cat_rest_mesas.Count() > 0)
            {
                uiTabMesas.Appearance.Header.ForeColor = Color.Green;
                uiTabMesas.Text = "MESAS (COMPLETADO)";
            }
            if(oContext.cat_configuracion_ticket_venta.Where(w=> w.TextoCabecera1.Length  > 0).Count()> 0)
            {
                uiTabTicket.Appearance.Header.ForeColor = Color.Green;
                uiTabTicket.Text = "TICKET VENTA (COMPLETADO)";
            }

            oContext = new ERPProdEntities();
            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            if(entity != null)
            {
                if(entity.Giro == Enumerados.systemGiro.REST.ToString())
                {
                    uiTabMesas.PageVisible = true;
                }
                else
                {
                    uiTabMesas.PageVisible = false;
                }
            }
        }

        private void ConfigInicial_Load(object sender, EventArgs e)
        {
            ValidarAcceso(this.puntoVentaContext.usuarioId, this.puntoVentaContext.sucursalId, "ConfigInicial");
            oContext = new ERPProdEntities();

            ConfigTabPage();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frmMesas frmo = frmMesas.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this.MdiParent;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();

            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frmConfiguracionTicketVenta frmo = frmConfiguracionTicketVenta.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this.MdiParent;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();

            }
        }

        private void ConfigInicial_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void btnBuscarPlantilla_Click(object sender, EventArgs e)
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
    }
}
