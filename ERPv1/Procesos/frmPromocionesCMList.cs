using ConexionBD;
using ConexionBD.Models;
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

namespace ERPv1.Procesos
{
    public partial class frmPromocionesCMList : XtraForm
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        private static frmPromocionesCMList _instance;

        public static frmPromocionesCMList GetInstance()
        {
            if (_instance == null) _instance = new frmPromocionesCMList();
            else _instance.BringToFront();
            return _instance;
        }

        public frmPromocionesCMList()
        {
            InitializeComponent();
        }

        private void frmPromocionesCMList_Load(object sender, EventArgs e)
        {
            oContext = new ERPProdEntities();
            //llenarGrid();
        }

        #region funcionalidad
        private void llenarGrid()
        {
            try
            {
                int sucursalId = this.puntoVentaContext.sucursalId;
                oContext = new ERPProdEntities();
                uiGrid.DataSource = oContext.doc_promociones_cm
                    .Where(w => w.SucursalId == sucursalId).ToList();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un error al cargar la información", "ERROR",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region eventos de la forma
        private void frmPromocionesCMList_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        #endregion

        #region eventos de controles

        private void uiAgregar_Click(object sender, EventArgs e)
        {
            frmPromocionesCMEdit frmo = frmPromocionesCMEdit.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.id = 0;
                frmo.MdiParent = this.MdiParent;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();

            }
        }

        private void uiGridView_DoubleClick(object sender, EventArgs e)
        {
            
        }
        #endregion

        private void repBtnEditar_Click(object sender, EventArgs e)
        {
            doc_promociones_cm entity = (doc_promociones_cm)uiGridView.GetRow(uiGridView.FocusedRowHandle);

            if(entity.PromocionCMId > 0)
            {
                frmPromocionesCMEdit frmo = frmPromocionesCMEdit.GetInstance();

                if (!frmo.Visible)
                {
                    //frmo = new frmPuntoVenta();
                    frmo.id = entity.PromocionCMId;
                    frmo.MdiParent = this.MdiParent;
                    frmo.puntoVentaContext = this.puntoVentaContext;
                    frmo.WindowState = FormWindowState.Maximized;
                    frmo.Show();

                }
            }

        }

        private void frmPromocionesCMList_Enter(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
