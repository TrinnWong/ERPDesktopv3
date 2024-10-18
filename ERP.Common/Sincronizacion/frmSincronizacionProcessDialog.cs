using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Sincronizacion
{
    public partial class frmSincronizacionProcessDialog : Form
    {
        string tipo = "";
        bool allowClose = false;
        public frmSincronizacionProcessDialog(string _tipo=null)
        {
            tipo = _tipo == null ? "all" : _tipo;
            InitializeComponent();
        }

        private void frmSincronizacionProcessDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            e.Cancel = !allowClose; // Evita que el formulario se cierre
        }

        public void Sincronizar()
        {
            
            ERP.Business.SincronizacionBusiness oSinc = new Business.SincronizacionBusiness();

            oSinc.ImportarALocal();
            oSinc.ExportANube();
            allowClose = true;
            
        }

        public void Import()
        {

            ERP.Business.SincronizacionBusiness oSinc = new Business.SincronizacionBusiness();

            oSinc.ImportarALocal();
           
            allowClose = true;

        }

        public void Export()
        {

            ERP.Business.SincronizacionBusiness oSinc = new Business.SincronizacionBusiness();

            oSinc.ExportANube();

            allowClose = true;

        }


        private void frmSincronizacionProcessDialog_Load(object sender, EventArgs e)
        {
           
        }

        private async void frmSincronizacionProcessDialog_Shown(object sender, EventArgs e)
        {
            this.Refresh();
            await Task.Run(() =>
            {
                if(this.tipo == "all")
                {
                    // Simular trabajo costoso
                    this.Sincronizar();
                }
                if (this.tipo == "import")
                {
                    // Simular trabajo costoso
                    this.Import();
                }

                if (this.tipo == "export")
                {
                    // Simular trabajo costoso
                    this.Export();
                }

            });
            this.Close();
        }
    }
}
