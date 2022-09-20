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

namespace ERP.Rec
{
    public partial class frmRecConfiguracion : XtraForm
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        RecBusiness oRec;
        public frmRecConfiguracion()
        {
            InitializeComponent();
            oRec = new RecBusiness();
            oContext = new ERPProdEntities();
        }

        public static frmRecConfiguracion GetInstance()
        {
            if (_instance == null) _instance = new frmRecConfiguracion();
            return _instance;
        }
        private static frmRecConfiguracion _instance;

        private void uiSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiGridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            string error = "";
            cat_rec_configuracion_rangos entity = (cat_rec_configuracion_rangos)e.Row;

            if(entity.RangoInicial > entity.RangoFinal)
            {
                e.Valid = false;
                e.ErrorText = "No es posible que el rango final sea mayor al ";
                return;
            }
            if (entity.PorcDeclarar <=0)
            {
                e.Valid = false;
                e.ErrorText = "El % a declarar debe de ser mayor a 0";
                return;
            }

            error = oRec.InsertarRecConfiguracion(entity);

            if (error.Length == 0)
            {
                error= guardarRec();

                if(error.Length > 0)
                {
                    e.Valid = false;
                    e.ErrorText = error;
                }
                else
                {
                    XtraMessageBox.Show("El proceso concluyó con éxito", "OK",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                e.Valid = false;
                e.ErrorText = error;
            }
               
            
        }
        public string guardarRec()
        {
            string error = "";
            try
            {
                oContext = new ERPProdEntities();
                oContext.p_cat_configuracion_rec_upd(uiRecortado.Checked);


                llenarGrid();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                //XtraMessageBox.Show("Ocurrió un error al guardar",
                //    "ERROR",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Error);
            }

            return error;
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            string error = "";
            error=guardarRec();

            if(error.Length > 0)
            {
                XtraMessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                XtraMessageBox.Show("El proceso concluyó con éxito", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }

        }

        private void llenarGrid()
        {
            try
            {
                List<cat_rec_configuracion_rangos> lst;
                lst = oContext.cat_rec_configuracion_rangos.ToList();
                uiGrid.DataSource = new BindingList<cat_rec_configuracion_rangos>(lst);
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un error al intentar poblar el grid",
                    "ERROR",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
        }

        private void frmRecConfiguracion_Load(object sender, EventArgs e)
        {
            cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

            uiRecortado.Checked = entity.TieneRec??false;
            llenarGrid();
        }

        private void frmRecConfiguracion_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void repBtnDel_Click(object sender, EventArgs e)
        {
            cat_rec_configuracion_rangos item = (cat_rec_configuracion_rangos)uiGridView.GetRow(uiGridView.FocusedRowHandle);

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
                        int id = item.Id;
                        cat_rec_configuracion_rangos entity = oContext.cat_rec_configuracion_rangos
                            .Where(w => w.Id == id).FirstOrDefault();

                        oContext.cat_rec_configuracion_rangos.Remove(entity);
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
    }
}
