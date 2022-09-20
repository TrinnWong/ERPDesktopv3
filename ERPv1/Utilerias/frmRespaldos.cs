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

namespace ERPv1.Utilerias
{
    public partial class frmRespaldos : Form
    {
        public frmRespaldos()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ConexionBD.Sistema oSisitema = new ConexionBD.Sistema();

            string error = oSisitema.respaldoDB();

            if(error.Length > 0)
            {
                XtraMessageBox.Show("Ocurrió un error:" + error,
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                XtraMessageBox.Show("Los respaldos se generaron en la carpeta C:\\ERP_BACKUP",
                    "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
