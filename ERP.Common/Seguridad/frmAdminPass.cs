using ConexionBD;
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

namespace ERP.Common.Seguridad
{
    public partial class frmAdminPass : XtraForm
    {
        public frmAdminPass()
        {
            InitializeComponent();
        }

        private void uiAceptar_Click(object sender, EventArgs e)
        {
            continuar();
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                continuar();
            }
        }

        private void continuar()
        {
            try
            {
                ERPProdEntities oContext = new ERPProdEntities();
                int numEmpleado;
                //if (int.TryParse(uiNumeroEmpleado.Text, out numEmpleado))
                //{
                string password = uiPass.Text;

                cat_usuarios entity = oContext.cat_usuarios.Where(
                        w =>
                          w.NombreUsuario == uiUser.Text &&
                        (
                        (w.EsSupervisor == true &&
                        w.PasswordSupervisor == password)
                        ||
                        (
                        w.EsSupervisorCajero == true &&
                        w.PasswordSupervisorCajero == password
                        )
                        )
                    ).FirstOrDefault();

                if (entity != null)
                {

                    this.DialogResult = DialogResult.OK;
                    this.Close();



                }
                else
                {
                    this.DialogResult = DialogResult.No;
                    MessageBox.Show("Clave no válida", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //}
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void frmAdminPass_Load(object sender, EventArgs e)
        {
                  }
    }
}
