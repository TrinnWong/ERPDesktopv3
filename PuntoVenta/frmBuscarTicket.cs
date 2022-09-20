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
    public partial class frmBuscarTicket : Form
    {
        public frmBuscarTicket()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void buscar()
        {
            frmPuntoVenta oForm = (frmPuntoVenta)this.Owner.MdiChildren[0];

            oForm.buscarTicket(uiFolio.Text);
            this.Close();
        }

        private void uiFolio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscar();
            }
        }
    }
}
