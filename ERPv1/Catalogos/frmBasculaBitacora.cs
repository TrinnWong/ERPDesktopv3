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

namespace ERPv1.Catalogos
{
    public partial class frmBasculaBitacora :  FormBaseXtraForm
    {
        public frmBasculaBitacora()
        {
            InitializeComponent();
        }

        private static frmBasculaBitacora _instance;

        public static frmBasculaBitacora GetInstance()
        {
            if (_instance == null) _instance = new frmBasculaBitacora();
            else _instance.BringToFront();
            return _instance;
        }

        private void frmBasculaBitacora_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiGrid_Load(object sender, EventArgs e)
        {
            loadGrid();
        }
        private void loadGrid()
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();
                uiGrid.DataSource = oContext.doc_basculas_bitacora
                    .OrderByDescending(o => o.Fecha).ToList();
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenu.GetInstance().puntoVentaContext.usuarioId,
                                      "ERP",
                                      this.Name,
                                      ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiActualizar_Click(object sender, EventArgs e)
        {
            loadGrid();
        }
    }
}
