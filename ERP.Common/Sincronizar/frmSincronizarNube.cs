using ERP.Business;
using ERP.Common.Base;
using ERP.Common.Forms;
using ERP.Models.Sincronizacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Sincronizar
{
    public partial class frmSincronizarNube : FormBaseXtraForm
    {
        LoadingForm oFormLoading;
        public List<SincronizaResultadoModel> data { get; set; }
        SincronizacionBusiness oSincronizar = new SincronizacionBusiness();
        private static frmSincronizarNube _instance;
        public static frmSincronizarNube GetInstance()
        {
            if (_instance == null) _instance = new frmSincronizarNube();
            else _instance.BringToFront();
            return _instance;
        }
        public frmSincronizarNube()
        {
            InitializeComponent();
            oFormLoading = new LoadingForm("Procesando...");
        }

        private void frmSincronizarNube_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiSincronizar_Click(object sender, EventArgs e)
        {

            this.uiGrid.DataSource = null;
            oFormLoading.Show();
            this.uiSincronizar.Enabled = false;
            oSincronizar.ImportarExportar();
            this.uiGrid.DataSource = oSincronizar.lstResultado.OrderByDescending(O=> O.Detalle);
            this.uiSincronizar.Enabled = true;
            oFormLoading.Hide();
        }

        private void uiGridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            bool cellValue = Convert.ToBoolean(uiGridView.GetRowCellValue(e.RowHandle, "Exitoso"));

            // Reemplaza "ValorCondicional" con el valor que quieres que desencadene el cambio de color
            if (!cellValue)
            {
                // Cambia el color del texto a rojo
                e.Appearance.ForeColor = Color.Red;
            }
            else
            {
                // Restablece el color del texto a su valor predeterminado
                e.Appearance.ForeColor = Color.Green;
            }
        }

        private void uiExportar_Click(object sender, EventArgs e)
        {

            this.uiGrid.DataSource = null;
            oFormLoading.Show();
            oSincronizar.lstResultado = new List<SincronizaResultadoModel>();
            this.uiSincronizar.Enabled = false;
            oSincronizar.ExportANube();
            this.uiGrid.DataSource = oSincronizar.lstResultado.OrderByDescending(O => O.Detalle);
            this.uiSincronizar.Enabled = true;
            oFormLoading.Hide();
        }

        private void uiImportar_Click(object sender, EventArgs e)
        {
            this.uiGrid.DataSource = null;
            oFormLoading.Show();
            oSincronizar.lstResultado = new List<SincronizaResultadoModel>();
            this.uiSincronizar.Enabled = false;
            oSincronizar.ImportarALocal();
            this.uiGrid.DataSource = oSincronizar.lstResultado.OrderByDescending(O => O.Detalle);
            this.uiSincronizar.Enabled = true;
            oFormLoading.Hide();
        }
    }
}
