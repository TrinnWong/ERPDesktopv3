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

namespace ERP.Rec
{
    public partial class frmAdmin : XtraForm
    {
        ConexionBD.Login oLogin;
        public frmAdmin()
        {
            InitializeComponent();
            oLogin = new ConexionBD.Login();
        }

        private void uiAceptar_Click(object sender, EventArgs e)
        {

         
        }

        private void iniciarSesion()
        {



            string usuario = uiUsuario.Text.Trim();
            string contraseña = uiPassword.Text.Trim();
            PuntoVentaContext oerpContext = new PuntoVentaContext();

            string error = oLogin.validar(usuario, contraseña, ref oerpContext);

            if (error.Length == 0)
            {
               
            }
            else
            {
                MessageBox.Show(error, "Error");
            }

        }
    }
}
