using ConexionBD.Models;
using ERP.Common.Catalogos;
using ERP.Common.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVenta
{
    public partial class frMenuImpresota : Form
    {
        public PuntoVentaContext puntoVentaContext;
        public frMenuImpresota()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmAdminPass oForm = new frmAdminPass();
            oForm.WindowState = FormWindowState.Normal;
            oForm.StartPosition = FormStartPosition.CenterScreen;

            oForm.ShowDialog();

            if (oForm.DialogResult == DialogResult.OK)
            {
                frmImpresoras frmo = frmImpresoras.GetInstance();

                if (!frmo.Visible)
                {
                    //frmo = new frmPuntoVenta();
                    frmo.puntoVentaContext = this.puntoVentaContext;
                    //frmo.MdiParent = this.MdiParent;
                    frmo.WindowState = FormWindowState.Maximized;
                    frmo.Show();
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frmAdminPass oForm = new frmAdminPass();
            oForm.WindowState = FormWindowState.Normal;
            oForm.StartPosition = FormStartPosition.CenterScreen;

            oForm.ShowDialog();

            if (oForm.DialogResult == DialogResult.OK)
            {
                frmCajasImpresoras frmo = frmCajasImpresoras.GetInstance();

                if (!frmo.Visible)
                {
                    //frmo = new frmPuntoVenta();
                    frmo.puntoVentaContext = this.puntoVentaContext;
                    frmo.MdiParent = this.MdiParent;
                    frmo.WindowState = FormWindowState.Normal;
                    frmo.Show();
                }
            }
        }
    }
}
