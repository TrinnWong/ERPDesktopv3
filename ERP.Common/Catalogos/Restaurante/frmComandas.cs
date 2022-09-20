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
    public partial class frmComandas : XtraForm
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        ComandasBusiness oComandas;

        public frmComandas()
        {
            InitializeComponent();
            oComandas = new ComandasBusiness();
            oContext = new ERPProdEntities();
        }

        private static frmComandas _instance;

        public static frmComandas GetInstance()
        {

            if (_instance == null) _instance = new frmComandas();
            else _instance.BringToFront();
            return _instance;
        }

        public void llenarGrid()
        {
            uiGrid.DataSource = oComandas.GetBySucursal(puntoVentaContext.sucursalId);
        }

        private void frmComandas_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiAgregar_Click(object sender, EventArgs e)
        {
            frmComandasEdit oForm = new frmComandasEdit();
            //oForm.esNuevo = true;
            oForm.puntoVentaContext = this.puntoVentaContext;
            oForm.StartPosition = FormStartPosition.CenterParent;
            oForm.ShowDialog();
        }

        private void repBtnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(XtraMessageBox.Show("¿Está seguro de desactivar la comanda?",
                "Aviso",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error)== DialogResult.Yes)
               
            {
                try
                {
                    cat_rest_comandas item = (cat_rest_comandas)uiGridView.GetRow(uiGridView.FocusedRowHandle);
                    int comandaId = item.ComandaId;

                    cat_rest_comandas entity = oContext.cat_rest_comandas
                        .Where(w => w.ComandaId == comandaId).FirstOrDefault();

                    if (entity != null)
                    {
                        entity.Disponible = false;

                        oContext.SaveChanges();

                        llenarGrid();

                        XtraMessageBox.Show("El proceso terminó con éxito", "OK", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                    }
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show("Ocurrió un error","ERROR",MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
              
            }
        }

        private void frmComandas_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }
    }
}
