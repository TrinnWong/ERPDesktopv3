using ERP.Common.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.PuntoVenta
{
    public partial class frmDevolucionesProducto : FormBaseXtraForm
    {
        int err = 0;
        string error = "";
        
        private static frmDevolucionesProducto _instance;
        public static frmDevolucionesProducto GetInstance()
        {
            if (_instance == null) _instance = new frmDevolucionesProducto();
            else _instance.BringToFront();
            return _instance;
        }
        public frmDevolucionesProducto()
        {
            InitializeComponent();
        }

        private void frmDevolucionesProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }
    }
}
