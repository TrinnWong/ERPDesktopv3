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
    public partial class frmMesas : XtraForm
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        MesasBusiness oMesas;

        private static frmMesas _instance;

        public static frmMesas GetInstance()
        {

            if (_instance == null) _instance = new frmMesas();
            return _instance;
        }


        public frmMesas()
        {
            InitializeComponent();
            oMesas = new MesasBusiness();
            oContext = new ERPProdEntities();
        }

        public void llenarGrid()
        {
            try
            {
                uiGrid.DataSource = oMesas.GETBySucursal(puntoVentaContext.sucursalId);
                uiGrid.Refresh();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un error al llenar el grid", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uiNuevo_Click(object sender, EventArgs e)
        {
            frmMesasEdit oForm = new frmMesasEdit();
            oForm.esNuevo = true;
            oForm.puntoVentaContext = this.puntoVentaContext;
            oForm.ShowDialog();
        }

        private void frmMesas_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void repBtnEditar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            cat_rest_mesas item = (cat_rest_mesas)uiGridView.GetRow(uiGridView.FocusedRowHandle);

            if (item != null)
            {
                frmMesasEdit oForm = new frmMesasEdit();
                oForm.id = item.MesaId;
                oForm.puntoVentaContext = this.puntoVentaContext;
                oForm.esNuevo = false;
                oForm.ShowDialog();

            }
        }

        private void repBtnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           
        }

        private void repBtnEditar_Click(object sender, EventArgs e)
        {
            cat_rest_mesas item = (cat_rest_mesas)uiGridView.GetRow(uiGridView.FocusedRowHandle);

            if (item != null)
            {
                frmMesasEdit oForm = new frmMesasEdit();
                oForm.id = item.MesaId;
                oForm.puntoVentaContext = this.puntoVentaContext;
                oForm.esNuevo = false;
                oForm.ShowDialog();

            }
        }

        private void repBtnDelete_Click(object sender, EventArgs e)
        {
            cat_rest_mesas item = (cat_rest_mesas)uiGridView.GetRow(uiGridView.FocusedRowHandle);

            if (item != null)
            {
                if (
                XtraMessageBox.Show("¿Está seguro de eliminar este registro?",
                "Aviso",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                    ) == DialogResult.Yes
                )
                {
                    try
                    {
                        int mesaId = item.MesaId;
                        cat_rest_mesas entity = oContext.cat_rest_mesas
                            .Where(w => w.MesaId == mesaId).FirstOrDefault();

                        oContext.cat_rest_mesas.Remove(entity);
                        oContext.SaveChanges();

                        llenarGrid();
                    }
                    catch (Exception ex)
                    {

                        XtraMessageBox.Show("Ocurrió un error al eliminar la mesa. Si la mesa ha sido ocupada en alguna venta no será posible eliminar, solo desactivar",
                            "ERROR",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }

            }

        }

        private void frmMesas_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;

        }
    }
}
