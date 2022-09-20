using ERP.Business;
using ERP.Common.Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TacosAna.Desktop
{
    public partial class StartApp : Form
    {
        bool importando = false;

        public StartApp()
        {
            InitializeComponent();
        }

        private void StartApp_Load(object sender, EventArgs e)
        {
            this.Hide();
            Login oForm = new Login();
            oForm.Show();
            this.Hide();
            //if (Licencia.ValidarLicencia())
            //{
            //    if (!timer1.Enabled)
            //    {
            //        timer1.Enabled = true;
            //    }

            //    //Importar Información Master




            //}
            //else
            //{
            //    Application.Exit();
            //}

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!importando)
            {
                importando = true;
                ////Importar Información Master
                //SincronizacionBusiness oSinc = new SincronizacionBusiness();
                //oSinc.Importar();

                Login oForm = new Login();
                oForm.Show();

                this.Hide();

            }



        }
    }
}
