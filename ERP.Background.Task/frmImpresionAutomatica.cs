using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Background.Task
{
    public partial class frmImpresionAutomatica : Form
    {
        public frmImpresionAutomatica()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           this.lblError.Text =  ConexionBD.PedidoOrdenBusiness.ImpresionAutomaticaPedido(1, 1,
                    1);
        }
    }
}
