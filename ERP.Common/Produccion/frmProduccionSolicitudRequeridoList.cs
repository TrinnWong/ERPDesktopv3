using ConexionBD;
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

namespace ERP.Common.Produccion
{
    public partial class frmProduccionSolicitudRequeridoList : FormBaseXtraForm
    {
        int err = 0;
        public int produccionSolicitudID { get; set; }

        private static frmProduccionSolicitudRequeridoList _instance;
        public static frmProduccionSolicitudRequeridoList GetInstance()
        {
            if (_instance == null) _instance = new frmProduccionSolicitudRequeridoList();
            else _instance.BringToFront();
            return _instance;
        }

        public frmProduccionSolicitudRequeridoList()
        {
            InitializeComponent();
        }

        public void LoadGrid()
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();

                uiGrid.DataSource = oContext
                    .p_doc_solicitud_produccion_requerido_grd(produccionSolicitudID)
                    .ToList();

                uiGridView.ExpandAllGroups();
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                   "ERP",
                                   this.Name,
                                   ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiGrid_Load(object sender, EventArgs e)
        {
            uiProduccionId.Value = this.produccionSolicitudID;
            LoadGrid();
        }

        private void frmProduccionSolicitudRequeridoList_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiGrid_Click(object sender, EventArgs e)
        {
                    }
    }
}
