using ConexionBD.Models;
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
    public partial class frmMenu : Form
    {
        public PuntoVentaContext puntoVentaContext;
        object mdiParenAux;
        private static frmMenu _instance;
        public static frmMenu GetInstance()
        {
            if (_instance == null) _instance = new frmMenu();
            return _instance;
        }

        public frmMenu()
        {
            InitializeComponent();
        }

        private void uiConfiguración_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmRecConfiguracion frmo = frmRecConfiguracion.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.MdiParent = this;
                frmo.Show();
                if (mdiParenAux == null)
                {
                    mdiParenAux = frmo.MdiParent;
                }

            }
        }

        private void uiPuntoVenta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
