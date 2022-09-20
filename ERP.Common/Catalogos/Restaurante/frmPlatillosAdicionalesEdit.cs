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

namespace ERP.Common.Catalogos.Restaurante
{
    public partial class frmPlatillosAdicionalesEdit : Form
    {
        public PuntoVentaContext puntoVentaContext;
        ERPProdEntities oContext;
        PlatillosAdicionalesBusiness oPlatilloB;

        int adicionalId = 0;

        private static frmPlatillosAdicionalesEdit _instance;

        public static frmPlatillosAdicionalesEdit GetInstance()
        {

            if (_instance == null) _instance = new frmPlatillosAdicionalesEdit();
            return _instance;
        }


        public frmPlatillosAdicionalesEdit()
        {
            InitializeComponent();
            oPlatilloB = new PlatillosAdicionalesBusiness();
        }

        private void llenarGridAdicionales()
        {
            try
            {
                List<cat_rest_platillo_adicionales> lst = oContext.cat_rest_platillo_adicionales
                    .ToList();

                uiGrid.DataSource =  new BindingList<cat_rest_platillo_adicionales>(lst);

            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un error al obtener la información",
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void llenarGridSubfamilia()
        {
            try
            {

                List<cat_rest_platillo_adicionales_sfam> lst = oContext.cat_rest_platillo_adicionales_sfam
              .Where(w => w.PlatilloAdicionalId == adicionalId).ToList();

                uiGridSubfamilias.DataSource = new BindingList<cat_rest_platillo_adicionales_sfam>(lst);



            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un error al obtener la información",
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void llenarCmbSubfamilia()
        {
            repLkpSubfamilia.DataSource = oContext.cat_subfamilias
                .Where(w => w.Estatus == true).ToList();
        }

        private void frmPlatillosAdicionalesEdit_Load(object sender, EventArgs e)
        {
            oContext = new ERPProdEntities();
            llenarGridAdicionales();
            llenarCmbSubfamilia();
            llenarGridSubfamilia();
           
        }

        private void uiGridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            cat_rest_platillo_adicionales item = (cat_rest_platillo_adicionales)e.Row;
            string error = "";

            if (item.Id > 0)
            {
                error = oPlatilloB.Actualizar(item);
            }
            else
            {
                error = oPlatilloB.Insertar(item, this.puntoVentaContext);

            }

            if (error.Length > 0)
            {
                e.Valid = false;
                e.ErrorText = error;

            }

        }

        private void repBtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (uiGridView.FocusedRowHandle >= 0)
                {
                    if (XtraMessageBox.Show("¿Está seguro de eliminar el registro?", "Aviso",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        uiGridView.DeleteRow(uiGridView.FocusedRowHandle);
                    }
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un error al eliminar", "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void uiGridView_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            
        }

        private void uiGridViewSubfamilias_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            cat_rest_platillo_adicionales_sfam item = (cat_rest_platillo_adicionales_sfam)e.Row;
            string error = "";

            if (item.PlatilloAdicionalId > 0)
            {
                error = "No es posible editar un registro";
            }
            else
            {
                item.PlatilloAdicionalId = adicionalId;

                error = oPlatilloB.InsertarSubfam(item, this.puntoVentaContext);

            }

            if (error.Length > 0)
            {
                e.Valid = false;
                e.ErrorText = error;

            }

        }

        private void repBtnDelete2_Click(object sender, EventArgs e)
        {
           
        }

        private void uiGridViewSubfamilias_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
           
        }

        private void uiGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (uiGridView.FocusedRowHandle >= 0)
            {
                cat_rest_platillo_adicionales item = (cat_rest_platillo_adicionales)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                adicionalId = item.Id;

                llenarGridSubfamilia();
            }


        }

        private void frmPlatillosAdicionalesEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiGridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {

        }

        private void repBtnDelete2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (uiGridViewSubfamilias.FocusedRowHandle >= 0)
                {
                    if (XtraMessageBox.Show("¿Está seguro de eliminar el registro?", "Aviso",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        uiGridViewSubfamilias.DeleteRow(uiGridViewSubfamilias.FocusedRowHandle);
                    }
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un error al eliminar", "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void uiGridView_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            cat_rest_platillo_adicionales item = (cat_rest_platillo_adicionales)e.Row;

            string error = oPlatilloB.Eliminar(item);

            if (error.Length > 0)
            {
                XtraMessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void uiGridViewSubfamilias_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            cat_rest_platillo_adicionales_sfam item = (cat_rest_platillo_adicionales_sfam)e.Row;

            string error = oPlatilloB.EliminarsUBFAM(item);

            if (error.Length > 0)
            {
                XtraMessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;

            }
        }
    }
}
