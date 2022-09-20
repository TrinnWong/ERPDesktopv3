using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Catalogos.Restaurante
{
    public partial class frmComandasEdit : Form
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        ComandasBusiness oComandas;
        public frmComandasEdit()
        {
            InitializeComponent();
            oComandas = new ComandasBusiness();
        }

        private static frmComandasEdit _instance;

        public static frmComandasEdit GetInstance()
        {

            if (_instance == null) _instance = new frmComandasEdit();
            else _instance.BringToFront();
            return _instance;
        }

        private void frmComandasEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiGenerar_Click(object sender, EventArgs e)
        {
            int folioIni = 0;
            int folioFin = 0;

            int.TryParse(uiFolioInicio.Value.ToString(), out folioIni);
            int.TryParse(uiFolioFin.Value.ToString(), out folioFin);
            string error=oComandas.Generar(folioIni, folioFin, this.puntoVentaContext);

            if(error.Length > 0)
            {
                XtraMessageBox.Show(error, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmComandas.GetInstance().llenarGrid();
                this.Close();
            }
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
