using ConexionBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPv1.Procesos
{
    public partial class frmPromocionesExcluision : Form
    {
        ERPProdEntities oContext;
        
        public frmPromocionesExcluision()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }
    }
}
