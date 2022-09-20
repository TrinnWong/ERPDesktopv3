using ConexionBD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPv1.Productos
{
    public partial class frmImportarFotos : Form
    {
        private static frmImportarFotos _instance;
        ConexionBD.ProductoInterface oProducto;
        string filePath = "";
        public PuntoVentaContext puntoVentaContext;
        public frmImportarFotos()
        {
            InitializeComponent();
            oProducto = new ConexionBD.ProductoInterface();
        }

        public static frmImportarFotos GetInstance()
        {
            if (_instance == null) _instance = new frmImportarFotos();
            else _instance.BringToFront();
            return _instance;
        }

        private void btnBuscarArchivo_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();

            string error = "";

            if (result == DialogResult.OK)
            {
                lblProgress.Text = "SUBIENDO FOTOS...........";
                lblError.Text= "";
                uiPath.Text = folderBrowserDialog1.SelectedPath;

                if (uiPath.Text.Length > 0)
                {
                    error = oProducto.importarImagenes(uiPath.Text);

                    if (error.Length > 0)
                    {
                        lblError.Text = error;

                        MessageBox.Show(error,
                             "ERROR",
                              MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                    }
                    else {
                        lblProgress.Text = "EL PROCESO TERMINÓ CON ÉXITO";
                        MessageBox.Show("El proceso terminó con éxito",
                             "AVISO",
                              MessageBoxButtons.OK,
                               MessageBoxIcon.Asterisk);

                    }
                }                
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void frmImportarFotos_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }
    }
}
