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

namespace ERP.Common.CorteCaja
{
    public partial class frmCorteCajaTortilleria : FormBaseXtraForm
    {
        private static frmCorteCajaTortilleria _instance;
        public static frmCorteCajaTortilleria GetInstance()
        {
            if (_instance == null) _instance = new frmCorteCajaTortilleria();
            else _instance.BringToFront();
            return _instance;
        }
        public frmCorteCajaTortilleria()
        {
            InitializeComponent();
        }
    }
}
