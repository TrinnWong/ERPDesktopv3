using ConexionBD;
using ConexionBD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace ERPv1.Procesos
{
    public partial class frmPromocionesUpd : Form
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        private static frmPromocionesUpd _instance;
        public int accionForm { get; set; }
        public int idForm { get; set; }
        

        public static frmPromocionesUpd GetInstance()
        {
            if (_instance == null) _instance = new frmPromocionesUpd();
            else _instance.BringToFront();
            return _instance;
        }
        public frmPromocionesUpd()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        private void LlenarCombos()
        {

            /**********LINEAS*************/
            List<cat_lineas> lstLineas = oContext.cat_lineas.Distinct().ToList();
            lstLineas.Add(new cat_lineas() { Clave = 0, Descripcion = "(Todas)" });
            uiLinea.DataSource = lstLineas;
            uiLinea.SelectedValue = 0;

            /**********FAMILIAS************/
            List<cat_familias> lstFamilias = oContext.cat_familias.ToList();
            lstFamilias.Add(new cat_familias() { Clave = 0, Descripcion = "(Todas)" });
            uiFamilia.DataSource = lstFamilias;
            uiFamilia.SelectedValue = 0;

            /**********SUBFAMILIAS************/
            List<cat_subfamilias> lstSubFamilias = oContext.cat_subfamilias.ToList();
            lstSubFamilias.Add(new cat_subfamilias() { Clave = 0, Descripcion = "(Todas)" });
            uiSubfamilia.DataSource = lstSubFamilias;
            uiSubfamilia.SelectedValue = 0;

            /******productos**************/
            List<cat_productos> lstProductoss = oContext.cat_productos.ToList();
            lstProductoss.Add(new cat_productos() { ProductoId = 0, Descripcion = "(Todas)" });
            uiProducto.DataSource = lstProductoss;
            uiProducto.SelectedValue = 0;

           // int empresaId = puntoVentaContext.empresaId;

            uiSucursal.DataSource = oContext.cat_sucursales.Where(w => w.Empresa == 1).ToList();


        }

        #region METODOS 

        private void LlenarComboSubFamilia()
        {
            try
            {
                int familia = (int)uiFamilia.SelectedValue;

                List<cat_subfamilias> lstSubFamilias = oContext.cat_subfamilias.Where(w=> w.Familia == familia || familia == 0).Distinct().ToList();
                lstSubFamilias.Add(new cat_subfamilias() { Clave = 0, Descripcion = "(Todas)" });
                uiSubfamilia.DataSource = lstSubFamilias;

                uiSubfamilia.SelectedValue = 0;

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void LlenarComboProducto()
        {
            try
            {
                int familia = (int)uiFamilia.SelectedValue;
                int subFamilia = (int)uiSubfamilia.SelectedValue;

                List<cat_productos> lstProductoss = oContext.cat_productos.Where(
                    w=> (w.ClaveFamilia == familia || familia == 0)
                    &&
                    (w.ClaveSubFamilia == subFamilia || subFamilia == 0)
                ).ToList();

                lstProductoss.Add(new cat_productos() { ProductoId = 0, Descripcion = "(Todas)" });
                uiProducto.DataSource = lstProductoss;

                uiProducto.SelectedValue = 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string GuardarEncabezado()
        {
            string error = "";
            try
            {
                oContext = new ERPProdEntities();
                int? sucursal = (int?)uiSucursal.SelectedValue;
                decimal? porcDescuento = uiPorcDescuento.Value;
                ObjectParameter pPromocionId = new ObjectParameter("pPromocionId", 0);
                DateTime fechaIni;
                DateTime fechaFin;

                fechaIni = new DateTime(uiFechaVigenciaIni.Value.Year, uiFechaVigenciaIni.Value.Month, uiFechaVigenciaIni.Value.Day, uiTimeIni.Value.Hour, uiTimeIni.Value.Minute, 0);
               fechaFin = new DateTime(uiFechaVigenciaFin.Value.Year, uiFechaVigenciaFin.Value.Month, uiFechaVigenciaFin.Value.Day, uiTimeFin.Value.Hour, uiTimeFin.Value.Minute, 0);



                if (sucursal <= 0)
                {
                    error = "La sucursal es requerida";
                }
                if (porcDescuento <= 0)
                {
                    error = error + "|El porcentaje de descuento es requerido";
                }

                if (fechaIni > fechaFin)
                {
                    error = error + "|La fecha de inicio no puede ser mayor a la final";
                }
                if (uiNombrePromocion.Text.Trim() == "")
                {
                    error = error + "|El nombre de la promoción es requerida";
                }

                if (error.Length > 0)
                {
                    return error;
                }

                if (uiID.Value <= 0)
                {
                    
                    oContext.p_doc_promociones_ins(pPromocionId, porcDescuento, fechaIni, fechaFin, 1, 1,
                   sucursal,uiNombrePromocion.Text, uiLunes.Checked, 
                   uiMartes.Checked, uiMiercoles.Checked, uiJueves.Checked, 
                   uiViernes.Checked, uiSabado.Checked, uiDomingo.Checked,uiActivo.Checked);
                    oContext.SaveChanges();

                    uiID.Value = (int)pPromocionId.Value;
                }
                else {
                    pPromocionId = new ObjectParameter("pPromocionId", uiID.Value);
                    oContext.p_doc_promociones_upd(pPromocionId, porcDescuento, fechaIni, fechaFin, 1, 1,
                   sucursal, uiNombrePromocion.Text,uiLunes.Checked, uiMartes.Checked,
                   uiMiercoles.Checked,uiJueves.Checked,uiViernes.Checked,
                   uiSabado.Checked,uiDomingo.Checked,uiActivo.Checked, uiPermanente.Checked);
                    oContext.SaveChanges();
                }

               
            }
            catch (Exception ex)
            {

                error = ex.Message;
            }
            

            return error;


        }

        private string GuardarExcepcion()
        {
            string error = "";
            try
            {

                int? linea = (int?)uiLinea.SelectedValue;
                int? familia = (int?)uiFamilia.SelectedValue;
                int? subfamilia = (int?)uiSubfamilia.SelectedValue;
                int? productoId = (int?)uiProducto.SelectedValue;

                linea = linea == 0 ? null : linea;
                familia = familia == 0 ? null : familia;
                subfamilia = subfamilia == 0 ? null : subfamilia;
                productoId = productoId == 0 ? null : productoId;

                if (
                    linea == 0 &&
                    familia == 0 &&
                    subfamilia == 0 &&
                    productoId == 0
                    )
                {
                    
                    return "No se pueden agregar todos los productos como excepción";
                }

                oContext.p_doc_promociones_excepcion_ins(0, (int)uiID.Value, linea, familia, subfamilia, productoId);
            }
            catch (Exception ex)
            {

                error = ex.Message;
            }

            return error;

        }

        private string GuardarDetalle()
        {
            string error = "";
            try
            {
                                
                int? linea = (int?)uiLinea.SelectedValue;
                int? familia = (int?)uiFamilia.SelectedValue;
                int? subfamilia = (int?)uiSubfamilia.SelectedValue;
                int? productoId = (int?)uiProducto.SelectedValue;

                linea = linea == 0 ? null : linea;
                familia = familia == 0 ? null : familia;
                subfamilia = subfamilia == 0 ? null : subfamilia;
                productoId = productoId == 0 ? null : productoId;

                oContext.p_doc_promociones_detalle(0, (int)uiID.Value, linea, familia, subfamilia, productoId);
            }
            catch (Exception ex)
            {

                error = ex.Message;
            }

            return error;
           
        }

        private void LlenarGridDetalle()
        {
            uiGridDetalle.AutoGenerateColumns = false;
            uiGridDetalle.DataSource = oContext.p_doc_promociones_detalle_grd((int)uiID.Value);

            if (uiGridDetalle.RowCount > 0)
            {
                btnAgregarExcepcion.Enabled = true;
            }
        }

        private void LlenarGridExcepcion()
        {
            uiGridExcepcion.AutoGenerateColumns = false;
            uiGridExcepcion.DataSource = oContext.p_doc_promociones_excepcion_grd((int)uiID.Value);
        }

        private string Guardar( )
        {
            try
            {
                string error = "";
                using (TransactionScope scope = new TransactionScope())
                {
                    error = GuardarEncabezado();

                    if (error.Length > 0)
                    {
                        MessageBox.Show(error, "ERROR");
                        return error;
                    }
                    else {
                        error = GuardarDetalle();
                        if (error.Length > 0)
                        {
                            MessageBox.Show(error, "ERROR");
                            return error;
                        }
                    }

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
                return ex.Message;             
            }

            return "";
        }


        private string GuardarExcepcion0()
        {
            try
            {
                string error = "";
                using (TransactionScope scope = new TransactionScope())
                {
                    

                    
                        error = GuardarExcepcion();
                        if (error.Length > 0)
                        {
                            MessageBox.Show(error, "ERROR");
                            return error;
                        }
                    

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
                return ex.Message;
            }

            return "";
        }

        private void LlenarForma()
        {
            try
            {
                oContext = new ERPProdEntities();
                doc_promociones entity = oContext.doc_promociones.Where(w => w.PromocionId == idForm).FirstOrDefault();

                if (entity != null)
                {
                    uiID.Value = entity.PromocionId;
                    uiSucursal.SelectedValue = entity.SucursalId;
                    uiFechaRegistro.Value = entity.FechaRegistro;
                    uiPorcDescuento.Value = entity.PorcentajeDescuento;
                    uiFechaVigenciaIni.Value = entity.FechaInicioVigencia;
                    uiFechaVigenciaFin.Value = entity.FechaFinVigencia;
                    uiActivo.Checked = entity.Activo ;
                    uiTimeIni.Value = entity.FechaInicioVigencia;
                    uiTimeFin.Value = entity.FechaFinVigencia;
                    uiNombrePromocion.Text = entity.NombrePromocion;
                    uiLunes.Checked = entity.Lunes??false;
                    uiMartes.Checked = entity.Martes ?? false;
                    uiMiercoles.Checked = entity.Miercoles ?? false;
                    uiJueves.Checked = entity.Jueves ?? false;
                    uiViernes.Checked = entity.Viernes ??false;
                    uiSabado.Checked = entity.Sabado??false;
                    uiDomingo.Checked = entity.Domingo ?? false;
                    uiPermanente.Checked = entity.Permanente ?? false;
                    LlenarGridDetalle();
                    LlenarGridExcepcion();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        #endregion

        #region eventos de controles
        private void uiFamilia_SelectedValueChanged(object sender, EventArgs e)
        {
            LlenarComboSubFamilia();
            LlenarComboProducto();
        }

        private void uiSubfamilia_SelectedValueChanged(object sender, EventArgs e)
        {
            LlenarComboProducto();
        }

        #endregion

        #region eventos de la forma
        private void frmPromocionesUpd_Load(object sender, EventArgs e)
        {
            try
            {
                uiFechaRegistro.Value = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                LlenarCombos();

                if (accionForm == 1)
                {
                    btnAgregar.Enabled = false;

                    DateTime horaIni = new DateTime(2018, 1, 1, 0, 0, 0);
                    DateTime horaFin = new DateTime(2018, 1, 1, 23, 59, 59);
                    uiTimeIni.Value = horaIni;
                    uiTimeFin.Value = horaFin;
                    uiLunes.Checked = uiMartes.Checked = uiMiercoles.Checked = uiJueves.Checked = uiViernes.Checked = uiSabado.Checked = uiDomingo.Checked = true;
                    uiActivo.Checked = true;
                    
                }

                if (accionForm == 2)                
                {
                    LlenarForma();
                    
                }
                if (accionForm == 3)
                {
                    LlenarForma();
                    panel1.Enabled = false;

                    uiGridDetalle.Enabled = false;

                    uiGuardar.BringToFront();
                    uiGuardar.Text = "ELIMINAR";
                    uiGuardar.Enabled = true;

                }
            }
            catch (Exception)
            {

                throw;
            }

        }




        #endregion

        private void frmPromocionesUpd_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            if (accionForm == 1 || accionForm == 2)
            {
                string error = GuardarEncabezado();

                if (error.Length > 0)
                {
                    MessageBox.Show(error, "ERROR");
                }
                else
                {

                    frmPromocionesList oForm = frmPromocionesList.GetInstance();
                    oForm.LlenarGrid();
                    btnAgregar.Enabled = true;
                    //this.Close();
                    MessageBox.Show("Proceo terminado", "OK");
                }
            }
            if (accionForm == 3)
            {

                doc_promociones entity = oContext.doc_promociones.Where(w => w.PromocionId == idForm).FirstOrDefault();

                List<doc_promociones_excepcion> lstExc = entity.doc_promociones_excepcion.ToList();

                foreach (var itemExc in lstExc)
                {
                    oContext.doc_promociones_excepcion.Remove(itemExc);
                }

                List<doc_promociones_detalle> lstDet = entity.doc_promociones_detalle.ToList();
                //entity.Activo = false;
                foreach (var itemDet in lstDet)
                {
                    oContext.doc_promociones_detalle.Remove(itemDet);
                }

                oContext.doc_promociones.Remove(entity);

                oContext.SaveChanges();
                frmPromocionesList oForm = frmPromocionesList.GetInstance();
                oForm.LlenarGrid();
                //this.Close();
                MessageBox.Show("Proceo terminado", "OK");
                this.Close();
            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string error = Guardar();

            if (error.Length > 0)
            {
                MessageBox.Show(error, "ERROR");
            }
            else {
                LlenarGridDetalle();
                
            }
        }

        private void uiGridDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
               e.RowIndex >= 0)
            {
                oContext = new ERPProdEntities();

                int IDrow = int.Parse(uiGridDetalle["ID", e.RowIndex].Value == null ? "0" :uiGridDetalle["ID", e.RowIndex].Value.ToString());

                doc_promociones_detalle entity = oContext.doc_promociones_detalle
                   .Where(w => w.PromocionDetalleId == IDrow).FirstOrDefault();

                if (entity != null)
                {
                    oContext.doc_promociones_detalle.Remove(entity);
                    oContext.SaveChanges();

                    LlenarGridDetalle();
                }               

            }

        }

        private void uiGridDetalle_DataSourceChanged(object sender, EventArgs e)
        {
            if (uiID.Value > 0)
            {
                btnAgregar.Enabled = true;
            }
            else {
                btnAgregar.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiClaveProducto_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (uiClaveProducto.Text.Length > 0)
                {
                    cat_productos entityProd = oContext.cat_productos.Where(
                        w => w.Clave == uiClaveProducto.Text.Trim()
                        ).FirstOrDefault();

                    if (entityProd != null)
                    {
                        uiProducto.SelectedValue = entityProd.ProductoId;
                    }

                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar buscar el producto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarExcepcion_Click(object sender, EventArgs e)
        {
            string error = GuardarExcepcion0();

            if (error.Length > 0)
            {
                MessageBox.Show(error, "ERROR");
            }
            else
            {
                LlenarGridExcepcion();

            }
        }

        private void uiGridExcepcion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
               e.RowIndex >= 0)
            {
                oContext = new ERPProdEntities();

                int IDrow = int.Parse(uiGridExcepcion["ID2", e.RowIndex].Value == null ?"0":uiGridExcepcion["ID2", e.RowIndex].Value.ToString());

                doc_promociones_excepcion entity = oContext.doc_promociones_excepcion
                   .Where(w => w.PromocionExcepcionId == IDrow).FirstOrDefault();

                if (entity != null)
                {
                    oContext.doc_promociones_excepcion.Remove(entity);
                    oContext.SaveChanges();

                    LlenarGridExcepcion();
                }

            }
        }
    }
}
