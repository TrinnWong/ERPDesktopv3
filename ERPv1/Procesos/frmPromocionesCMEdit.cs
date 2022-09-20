using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using ERP.Business;
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
    public partial class frmPromocionesCMEdit : Form
    {
        public int id { get; set; }
        public int idDetalle { get; set; }
        PromocionesCMBusiness boPromociones;
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        private static frmPromocionesCMEdit _instance;


        public static frmPromocionesCMEdit GetInstance()
        {
            if (_instance == null) _instance = new frmPromocionesCMEdit();
            else _instance.BringToFront();
            return _instance;
        }



        #region eventos de la forma
        public frmPromocionesCMEdit()
        {
            InitializeComponent();
        }

        private void frmPromocionesCMEdit_Load(object sender, EventArgs e)
        {
            oContext = new ERPProdEntities();
            llenarLkpProductos();
            LlenarForma();
            llenarRepLkpProductos();
        }
        private void frmPromocionesCMEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }
        #endregion

        #region eventos de controles
        private void uiGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                doc_promociones_cm entity = new doc_promociones_cm();

                entity.PromocionCMId = int.Parse(uiID.Value.ToString());
                entity.Activo = uiActivo.Checked;
                entity.Domingo = uiDomingo.Checked;
                entity.FechaRegistro = DateTime.Now;
                entity.FechaVigencia = uiFechaVigencia.DateTime;
                entity.HoraVigencia = new TimeSpan(uiHoraVigencia.Time.Hour, uiHoraVigencia.Time.Minute, uiHoraVigencia.Time.Second);
                entity.Jueves = uiJueves.Checked;
                entity.Lunes = uiLunes.Checked;
                entity.Martes = uiMartes.Checked;
                entity.Miercoles = uiMiercoles.Checked;
                entity.NombrePromocion = uiNombre.Text;
                entity.Sabado = uiSabado.Checked;
                entity.SucursalId = this.puntoVentaContext.sucursalId;
                entity.Viernes = uiViernes.Checked;
                boPromociones = new PromocionesCMBusiness();
                string error = boPromociones.InsertarActualizar(ref entity, this.puntoVentaContext);

                if (error.Length > 0)
                {
                    XtraMessageBox.Show(error, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.id = entity.PromocionCMId;
                    uiID.Value = this.id;
                    XtraMessageBox.Show("Los datos se guardaron correctamente", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un error al guardar la promoción", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void uiGroup1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiAgregarProd_Click(object sender, EventArgs e)
        {
            try
            {
                doc_promociones_cm_detalle entity = new doc_promociones_cm_detalle();

                entity.CantidadCompraMinima = uiCantMinima.Value;
                entity.CantidadCobro = uiCantPagar.Value;
                entity.ProductoId = uiProducto.EditValue == null ? 0 : int.Parse(uiProducto.EditValue.ToString());
                entity.PromocionCMId = this.id;
                entity.PromocionCMDetId = this.idDetalle;

                boPromociones = new PromocionesCMBusiness();

                string error = boPromociones.InsertarActualizarDetalle(ref entity, this.puntoVentaContext);

                if (error.Length > 0)
                {
                    XtraMessageBox.Show(error, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    limpiarDetalle();

                    XtraMessageBox.Show("Los datos se guardaron correctamente", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    llenarGridDetalle();
                }

            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error al guardar", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void repBtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                doc_promociones_cm_detalle entity = (doc_promociones_cm_detalle)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                if (entity.PromocionCMDetId > 0)
                {
                    this.idDetalle = entity.PromocionCMDetId;
                    uiProducto.EditValue = entity.ProductoId;
                    uiCantMinima.EditValue = entity.CantidadCompraMinima;
                    uiCantPagar.EditValue = entity.CantidadCobro;
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error al editar", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void repBtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                doc_promociones_cm_detalle entity = (doc_promociones_cm_detalle)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                if (entity.PromocionCMDetId > 0)
                {
                    if (XtraMessageBox.Show("¿Está seguro de eliminar el registro?", "AVISO",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oContext.doc_promociones_cm_detalle.Remove(entity);
                        oContext.SaveChanges();

                        llenarGridDetalle();
                    }
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Error al editar", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region funcionalidad
        private void habilitarDeshabilitar()
        {
            uiGroup2.Enabled = uiID.Value > 0 ? true : false;


        }
        private void llenarLkpProductos()
        {
            try
            {
                uiProducto.Properties.DataSource = oContext.cat_productos
                    .ToList();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un error al buscar los productos", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LlenarForma()
        {
            try
            {
                if (id > 0)
                {
                    doc_promociones_cm entity = oContext.doc_promociones_cm
                   .Where(w => w.PromocionCMId == id).FirstOrDefault();

                    if (entity != null)
                    {
                        uiID.Value = entity.PromocionCMId;
                        uiFechaRegistro.DateTime = entity.FechaRegistro;
                        uiFechaVigencia.DateTime = entity.FechaVigencia;
                        uiNombre.Text = entity.NombrePromocion;
                        uiLunes.Checked = entity.Lunes ?? false;
                        uiMartes.Checked = entity.Martes ?? false;
                        uiMiercoles.Checked = entity.Miercoles ?? false;
                        uiJueves.Checked = entity.Jueves ?? false;
                        uiViernes.Checked = entity.Viernes ?? false;
                        uiSabado.Checked = entity.Sabado ?? false;
                        uiDomingo.Checked = entity.Domingo ?? false;
                        uiActivo.Checked = entity.Activo;
                        uiHoraVigencia.EditValue = entity.HoraVigencia;

                        uiGrid.DataSource = entity.doc_promociones_cm_detalle.ToList();

                        habilitarDeshabilitar();


                    }
                }
                else
                {
                    uiFechaRegistro.EditValue = DateTime.Now;
                    uiHoraVigencia.EditValue = new TimeSpan(23, 59, 59);
                }

                //else
                //{
                //    XtraMessageBox.Show("Ocurrió un error al buscar la promoción", "ERROR",
                //   MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un error al buscar la promoción", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llenarGridDetalle()
        {
            oContext = new ERPProdEntities();
            uiGrid.DataSource = oContext.doc_promociones_cm_detalle
                .Where(w => w.PromocionCMId == id).ToList();
        }
        private void llenarRepLkpProductos()
        {
            try
            {
                repLkpProducto.DataSource = oContext.cat_productos
                    .ToList();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un error al buscar los productos", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiarDetalle()
        {
            uiProducto.EditValue = null;
            uiCantMinima.EditValue = 0;
            uiCantPagar.EditValue = 0;
            this.idDetalle = 0;
        }


        #endregion

        private void uiProducto_EditValueChanged(object sender, EventArgs e)
        {

        }

    }
}
