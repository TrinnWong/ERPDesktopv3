using ConexionBD;
using ConexionBD.Models;
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

namespace ERP.Common.Catalogos
{
    public partial class frmBasculaList : FormBaseXtraForm
    {
        public PuntoVentaContext puntoVentaContext;
        public int idForm { get; set; }
        private static frmBasculaList _instance;

        public static frmBasculaList GetInstance()
        {

            if (_instance == null) _instance = new frmBasculaList();
            else _instance.BringToFront();
            return _instance;
        }
        public frmBasculaList()
        {
            InitializeComponent();
        }

        public void LoadGrid()
        {
            try
            {
                oContext = new ERPProdEntities();
                int empresaId = puntoVentaContext.empresaId;
                uiGrid.DataSource = oContext.cat_basculas
                    .Where(w => w.EmpresaId == puntoVentaContext.empresaId).ToList();
                    
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void frmBasculaList_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void frmBasculaList_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void uiGrid_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void uiGridView_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void repBtnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(uiGridView.FocusedRowHandle >= 0)
                {
                    cat_basculas entity = (cat_basculas)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                    frmBasculaUpd frmo = new frmBasculaUpd();
                    frmo.puntoVentaContext = this.puntoVentaContext;
                    frmo.idForm = entity.BasculaId;
                    frmo.WindowState = FormWindowState.Normal;
                    frmo.StartPosition = FormStartPosition.CenterScreen;
                    frmo.ShowDialog();

                    
                }
                
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                    frmBasculaUpd frmo = new frmBasculaUpd();
                frmo.puntoVentaContext = this.puntoVentaContext;
                    frmo.idForm = 0;
                    frmo.WindowState = FormWindowState.Normal;
                    frmo.StartPosition = FormStartPosition.CenterScreen;
                    frmo.ShowDialog();

            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }
    }
}
