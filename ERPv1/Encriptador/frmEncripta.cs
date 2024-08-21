using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPv1.Encriptador
{
    public partial class frmEncripta : Form
    {
        public frmEncripta()
        {
            InitializeComponent();
        }

        private void btnEncriptar_Click(object sender, EventArgs e)
        {
            uiSalida.Text = ERP.Business.Tools.CryptoHelper.Encrypt(uiEntrada.Text);
        }

        private void btnDesencriptar_Click(object sender, EventArgs e)
        {
            uiSalida.Text = ERP.Business.Tools.CryptoHelper.Decrypt(uiEntrada.Text);
        }

        private void frmEncripta_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(uiSalida.Text);
        }
    }
}
