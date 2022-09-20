using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Business;
using ERP.Models;
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
    public partial class frmPoliticas : XtraForm
    {
        private static frmPoliticas _instance;
        public PuntoVentaContext puntoVentaContext;
        PoliticasBusiness oPolitica;
        public frmPoliticas()
        {
            InitializeComponent();
            oPolitica = new PoliticasBusiness();
        }

        public static frmPoliticas GetInstance()
        {
            if (_instance == null) _instance = new frmPoliticas();
            else _instance.BringToFront();
            return _instance;
        }

        public void LoadGrid()
        {
            try
            {
                List<cat_politicas> lst = oPolitica.GetList();               

                uiGrid.DataSource = new BindingList<cat_politicas>(lst);
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un error el cargar el grid", "ERROR",
                     MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
            }
        }

        private void uiGrid_Click(object sender, EventArgs e)
        {

        }

        private void uiNuevo_Click(object sender, EventArgs e)
        {
            uiGridView.AddNewRow();
            
        }

        private void uiGridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            cat_politicas row = (cat_politicas)e.Row;
            
        }

        private void uiGrid_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void uiGridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            cat_politicas row = (cat_politicas)e.Row;
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (row!= null)
            {
                if (Utils.isNull(row.Descripcion).Length == 0)
                {
                    view.SetColumnError(colDescripcion, "La descripción es requerida");
                    e.ErrorText = "La descripción es requerida";
                    e.Valid = false;
                    return;
                }
                if (Utils.isNull(row.Politica).Length == 0)
                {
                    view.SetColumnError(colPolitica, "La politica es requerida");
                    e.ErrorText = "La politica es requerida";
                    e.Valid = false;
                    return;
                }

                ResultAPIModel result = new ResultAPIModel();

                if (row.PoliticaId == 0)
                {
                    result = oPolitica.Insert(row);

                    if (!result.ok)
                    {
                        view.SetColumnError(colPoliticaId, result.error);
                        e.ErrorText = result.error;
                        e.Valid = false;
                        return;
                    }
                }
                else
                {
                    result = oPolitica.Update(row);
                    if (!result.ok)
                    {
                        e.ErrorText = result.error;
                        e.Valid = false;
                        return;
                    }
                }
            }

           
        }

        private void frmPoliticas_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiGrid_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void uiGridView_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, colPoliticaId, 0);
            view.SetRowCellValue(e.RowHandle, colActivo, true);
            view.SetRowCellValue(e.RowHandle, colDescripcion, "");
            view.SetRowCellValue(e.RowHandle, colPolitica, "");
        }
    }
}
