using ConexionBD;
using ConexionBD.Forms;
using ConexionBD.Models;
using ERP.Business;
using ERP.Common.Inventarios;
using ERP.Models;
using ERP.Reports;
using ERPv1.rpt;
using Productos;
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

namespace ERPv1.Inventarios
{
    public partial class frmEntradaTraspasoUpd : FormERP
    {
        List<MovimientoInventarioProductoModel> lstMovs;


        private static frmEntradaTraspasoUpd _instance;
        public int tipoMovimientoForm{get;set;}
        cat_empresas_config_inventario confEmp;


        public static frmEntradaTraspasoUpd GetInstance()
        {
            if (_instance == null) _instance = new frmEntradaTraspasoUpd();
            else _instance.BringToFront();
            return _instance;
        }

        public frmEntradaTraspasoUpd()
        {
            InitializeComponent();
        }

        #region eventos de la forma
        private void frmSalidaTraspasoUpd_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void frmSalidaTraspasoUpd_Load(object sender, EventArgs e)
        {
            int empresaId=puntoVentaContext.empresaId;
            this.puntoVentaContext = frmMenu.GetInstance().puntoVentaContext;
            lstMovs = new List<MovimientoInventarioProductoModel>();
            CargarCombos();
            uiSucursalOrigen.SelectedValue = puntoVentaContext.sucursalId;
            uiSucursalDestino.SelectedValue = puntoVentaContext.sucursalId;
            confEmp = oContext.cat_empresas_config_inventario.Where(w => w.EmpresaId == empresaId).FirstOrDefault();
            //uiCantidad.EditValue = null;
            switch (tipoMovimientoForm)
            {
                case 3:
                    lblTitulo.Text = "Entrada Por Traspaso";
                    uiSucursalDestino.Enabled = false;
                    uiSucursalOrigen.Enabled = true;
                    uiPrecioUnitario.Visible = true;
                    lblPrecio.Visible = true;
                    break;
                case 4:
                    lblTitulo.Text = "Salida Por Traspaso";
                    uiSucursalDestino.Enabled = true;
                    uiSucursalOrigen.Enabled = false;
                    uiPrecioUnitario.Visible = false;
                    lblPrecio.Visible = false;
                    break;
                default:
                    break;
            }

            switch (accionForm)
            {
                case 1:
                    uiImprimir.Enabled = false;
                    uiCancelar.Enabled = false;                   
                    break;
                case 2:
                    
                    buscarRegistro();
                    CalcularTotal();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region eventos de controles
        private void uiClave_Validating(object sender, CancelEventArgs e)
        {
            buscarProducto();
        }
        private void uiAgregar_Click(object sender, EventArgs e)
        {

            agregarProducto();


        }
        #endregion

        #region metodos
        public void agregarProducto()
        {
            if (
              uiDescProducto.Text != ""
              &&
              uiCantidad.Value > 0
              )
            {
               
                agregarProductoGrid();
                CalcularTotal();
                uiClave.Text = "";
                uiDescProducto.Text = "";
                uiCantidad.Value = 0;
            }
            else
            {
                MessageBox.Show("Es necesario especificar un producto y cantidad", "AVISO");
            }
        }
        private MovimientoInventarioProductoModel buscarProducto()
        {
            MovimientoInventarioProductoModel producto = null;
            try
            {
                string clave = uiClave.Text;


                cat_productos entity = oContext.cat_productos.Where(w => w.Clave == clave).FirstOrDefault();

                if (entity != null)
                {
                    producto = new MovimientoInventarioProductoModel();
                    uiDescProducto.Text = entity.Descripcion;
                    producto.cantidadMov = 0;
                    producto.clave = entity.Clave;
                    producto.precioUnitario = 0;
                    producto.productoId = entity.ProductoId;
                    producto.unidadId = entity.ClaveUnidadMedida ?? 0;
                    producto.unidad = entity.cat_unidadesmed != null ? entity.cat_unidadesmed.Descripcion : "";
                    producto.descripcion = entity.Descripcion;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

            return producto;
        }

        public void buscarProductoF3(string clave)
        {
            uiClave.Text = clave;
            buscarProducto();
            uiCantidad.Focus();
            uiCantidad.Select();
        }

        private void agregarProductoGrid()
        {
            try
            {
                MovimientoInventarioProductoModel producto = buscarProducto();
                producto.cantidadMov = uiCantidad.Value;
                producto.partida = lstMovs.Count + 1;
                producto.precioCompra = uiPrecioUnitario.Value;
                producto.precioUnitario = uiPrecioUnitario.Value;
                int empresaid = puntoVentaContext.empresaId;
                cat_empresas_config_inventario confEmp = oContext.cat_empresas_config_inventario.Where(w => w.EmpresaId == empresaid).FirstOrDefault();

                if (
                    (confEmp == null ? false : (confEmp.ValidarExistenciaTraspaso ?? false))
                    )
                {
                    string error = InventarioBusiness.ValidarExistencia(producto.productoId, int.Parse(uiSucursalOrigen.SelectedValue.ToString()), producto.cantidadMov);

                    if (error.Length > 0)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning(error);
                        return;
                    }


                }

                lstMovs.Add(producto);

                uiGrid.AutoGenerateColumns = false;
                uiGrid.DataSource = null;
                uiGrid.DataSource = lstMovs;
                uiGrid.Refresh();
            }
            catch (Exception ex) 
            {

                MessageBox.Show("Ocurrió un error inesperado");
            }
          
        }

        private void obtenerFolioSig()
        {
            int folio = oContext.doc_inv_movimiento.Count() > 0 ? oContext.doc_inv_movimiento.Max(m => m.MovimientoId) + 1 : 1;

            uiFolio.Text = folio.ToString();
        }
        public void CargarCombos()
        {
            uiSucursalDestino.DataSource = oContext.cat_sucursales.Where(w => w.Estatus == true).ToList();
            uiSucursalOrigen.DataSource = oContext.cat_sucursales.Where(w => w.Estatus == true).ToList();
        }

        private void eliminarProducto()
        {
            int rowIndex = uiGrid.CurrentCell.RowIndex;
            if (rowIndex >= 0)
            {

                if (uiGrid.Rows[rowIndex].Cells["partida"].Value != null)
                {
                    //Eliminar del grid
                    int partida = int.Parse(uiGrid.Rows[rowIndex].Cells["partida"].Value.ToString());
                    //DataGridViewRow dr = uiGridProducto.Rows[rowIndex];
                    //uiGridProducto.Rows.Remove(dr);

                    //Eliminar del arreglo
                    MovimientoInventarioProductoModel producto = lstMovs.Where(w => w.partida == partida).FirstOrDefault();
                    lstMovs.Remove(producto);


                    uiGrid.DataSource = lstMovs.ToList();                   

                }

            }
        }

       

        private void guardar(bool autorizar)
        {
            try
            {
                oContext = new ERPProdEntities();
                ObjectParameter pMovimientoID = new ObjectParameter("pMovimientoId", 0);

                string error = validarGuardar();

                if (error.Length > 0)
                {
                    MessageBox.Show(error, "ERROR");
                    return;
                }

                int sucursalOrigen = uiSucursalOrigen.SelectedValue == null ? 0 : int.Parse(uiSucursalOrigen.SelectedValue.ToString());
                int sucursalDestino = uiSucursalDestino.SelectedValue == null ? 0 : int.Parse(uiSucursalDestino.SelectedValue.ToString());
                int sucursalMov = 0;

                if (tipoMovimientoForm == (int)ConexionBD.Enumerados.tipoMovsInventario.entradaPorTraspaso)
                {
                    sucursalMov = sucursalDestino;
                }

                if (tipoMovimientoForm == (int)ConexionBD.Enumerados.tipoMovsInventario.salidaPorTraspaso)
                {
                    sucursalMov = sucursalOrigen;
                }

                DateTime fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                decimal total = lstMovs.Sum(s => s.importe);

                switch (accionForm)
                {
                    /**********Agregar***************************/
                    case 1:
                        using (TransactionScope scope = new TransactionScope())
                        {
                            oContext.p_doc_inv_movimiento_ins(pMovimientoID, sucursalMov, uiFolio.Text, tipoMovimientoForm, fechaActual, fechaActual.TimeOfDay, "",
                          total, 1, false, null,sucursalOrigen, sucursalDestino, null,null);

                            foreach (MovimientoInventarioProductoModel itemMov in lstMovs)
                            {
                                if (confEmp == null ? false : (confEmp.ValidarExistenciaTraspaso ?? false))
                                {
                                    error = InventarioBusiness.ValidarExistencia(itemMov.productoId, sucursalOrigen, itemMov.cantidadMov);
                                    if (error.Length > 0)
                                    {
                                        ERP.Utils.MessageBoxUtil.ShowWarning(error);
                                        return;
                                    }
                                }
                                

                                ObjectParameter pMovimientoDetalleId = new ObjectParameter("pMovimientoDetalleId", 0);
                                oContext.p_inv_movimiento_detalle_ins(pMovimientoDetalleId, int.Parse(pMovimientoID.Value.ToString()), itemMov.productoId, 0, itemMov.cantidadMov, itemMov.precioUnitario, 0, itemMov.cantidadMov, 1,0,0,itemMov.subtotal,itemMov.precioNeto);
                            }

                            accionForm = (int)ConexionBD.Enumerados.accionForm.actualizar;
                            idForm = int.Parse(pMovimientoID.Value.ToString());
                            uiFolio.Text = pMovimientoID.Value.ToString();

                            //MessageBox.Show("El movimiento ha sigo guardado con éxito", "OK");
                            scope.Complete();
                        }
                        break;
                    case 2:
                        using (TransactionScope scope = new TransactionScope())
                        {
                            pMovimientoID.Value = idForm;
                            oContext.p_doc_inv_movimiento_upd(pMovimientoID, sucursalMov, uiFolio.Text, tipoMovimientoForm, fechaActual, fechaActual.TimeOfDay, "",
                            total, 1, false, null,sucursalOrigen, sucursalDestino, null,null);

                            /********Eliminar detalle************/
                            List<doc_inv_movimiento_detalle> lstDetalle = oContext.doc_inv_movimiento_detalle.Where(w => w.MovimientoId == idForm).ToList();
                            foreach (doc_inv_movimiento_detalle itemDel in lstDetalle)
                            {
                                oContext.doc_inv_movimiento_detalle.Remove(itemDel);
                            }

                            oContext.SaveChanges();

                            foreach (MovimientoInventarioProductoModel itemMov in lstMovs)
                            {
                                if (confEmp == null ? false : (confEmp.ValidarExistenciaTraspaso ?? false))
                                {
                                    error = InventarioBusiness.ValidarExistencia(itemMov.productoId, sucursalOrigen, itemMov.cantidadMov);
                                    if (error.Length > 0)
                                    {
                                        ERP.Utils.MessageBoxUtil.ShowWarning(error);
                                        return;
                                    }
                                }                                

                                ObjectParameter pMovimientoDetalleId = new ObjectParameter("pMovimientoDetalleId", 0);
                                oContext.p_inv_movimiento_detalle_ins(pMovimientoDetalleId, int.Parse(pMovimientoID.Value.ToString()), itemMov.productoId, 0, itemMov.cantidadMov, itemMov.precioUnitario, 0, itemMov.cantidadMov, 1,0,0,itemMov.subtotal,itemMov.precioNeto);
                            }

                            accionForm = (int)ConexionBD.Enumerados.accionForm.actualizar;
                            idForm = int.Parse(pMovimientoID.Value.ToString());
                            uiFolio.Text = pMovimientoID.Value.ToString();

                            //MessageBox.Show("El movimiento ha sigo guardado con éxito", "OK");
                            scope.Complete();
                        }
                        break;
                    default:
                        break;
                }

                if (autorizar)
                {
                    autorizarInv();
                    imprimir();
                }
                else {
                    MessageBox.Show("El movimiento ha sigo guardado con éxito", "OK");
                    if (tipoMovimientoForm == 3)
                    {
                        frmEntradaTraspasoList oForm = frmEntradaTraspasoList.GetInstance();
                        oForm.cargarGrid();
                    }

                    if (tipoMovimientoForm == 4)
                    {
                        frmSalidaTraspasoList oForm = frmSalidaTraspasoList.GetInstance();
                        oForm.cargarGrid();
                    }

                    this.Close();
                }

                  
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        public string validarGuardar()
        {
            string error = "";
            int sucursalOrigen = uiSucursalOrigen.SelectedValue == null ? 0 : int.Parse(uiSucursalOrigen.SelectedValue.ToString());
            int sucursalDestino = uiSucursalDestino.SelectedValue == null ? 0 : int.Parse(uiSucursalDestino.SelectedValue.ToString());

            if (sucursalDestino == 0
                ||
                sucursalOrigen == 0
                )
            {
                error = "Es necesario especificar la sucursal Origen y de Destino";
            }
            if (sucursalOrigen == sucursalDestino)
            {
                error = error + "|La sucursal Origen y de Destino no pueden ser la misma";
            }
            if (lstMovs.Count == 0)
            {
                error = error + "|No se han capturado productos";
            }

            return error;
        }

        public void buscarRegistro()
        {

            try
            {
                oContext = new ERPProdEntities();

                doc_inv_movimiento entity = oContext.doc_inv_movimiento.Where(w => w.MovimientoId == idForm).FirstOrDefault();

                obtenerEstatus(entity);
                habilitarBotones(entity);

                uiFolio.Text = entity.Consecutivo.ToString();
                uiFecha.Value = entity.FechaMovimiento;
                uiSucursalOrigen.SelectedValue = entity.SucursalOrigenId;
                uiSucursalDestino.SelectedValue = entity.SucursalDestinoId;
                //uiFechaCancelacion.Value = entity.FechaCancelacion ?? DateTime.Now;

                lstMovs = entity.doc_inv_movimiento_detalle
                    .Select(
                        s => new MovimientoInventarioProductoModel()
                        {
                            cantidadMov = s.Cantidad??0,
                            clave = s.cat_productos.Clave,
                            descripcion = s.cat_productos.Descripcion,
                            precioUnitario = s.PrecioUnitario,
                            productoId = s.ProductoId,
                            unidad = s.cat_productos.cat_unidadesmed != null?  s.cat_productos.cat_unidadesmed.Descripcion : "",
                            unidadId = s.cat_productos.ClaveUnidadMedida ?? 0,
                            precioCompra = s.PrecioUnitario
                        }
                    ).ToList();

                for (int i = 0; i < lstMovs.Count; i++)
                {
                    lstMovs[i].partida = i + 1;
                }

                uiGrid.AutoGenerateColumns = false;
                uiGrid.DataSource = lstMovs;

                

            }
            catch (Exception)
            {

                throw;
            }
            
        }
        
      

        private void CalcularTotal()
        {
            //uiTotal.Value = lstMovs.Sum(s => s.importe);
        }

        private void autorizarInv()
        {
            try
            {

                if (
                    MessageBox.Show("¿Está seguro de continuar?", "AVISO", MessageBoxButtons.YesNo) == DialogResult.Yes
                    )
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        oContext.p_inv_movimiento_autoriza(idForm, 1);

                        #region traspaso automático
                        int empresaId = this.puntoVentaContext.empresaId;
                        cat_empresas_config_inventario confEmp = oContext
                            .cat_empresas_config_inventario
                            .Where(w => w.EmpresaId == empresaId).FirstOrDefault();

                        if ((confEmp == null ? false : confEmp.EnableTraspasoAutomatico )
                            && (
                                tipoMovimientoForm == (int)ConexionBD.Enumerados.tipoMovsInventario.salidaPorTraspaso ||
                                tipoMovimientoForm == (int)ConexionBD.Enumerados.tipoMovsInventario.entradaPorTraspaso
                            ) )
                        {
                            InventarioBusiness oInventario = new InventarioBusiness();
                            ResultAPIModel result = oInventario.GeneraTraspasoAutomatico(empresaId, idForm, this.puntoVentaContext.usuarioId);

                            if (!result.ok)
                            {
                                ERP.Utils.MessageBoxUtil.ShowError(result.error);
                                scope.Dispose();
                                return;
                            }
                           
                        }
                        #endregion

                        scope.Complete();
                    }




                    MessageBox.Show("El movimiento ha sido autorizado", "OK");

                    if (tipoMovimientoForm == 3)
                    {
                        frmEntradaTraspasoList oForm = frmEntradaTraspasoList.GetInstance();
                        oForm.cargarGrid();
                    }

                    if (tipoMovimientoForm == 4)
                    {
                        frmSalidaTraspasoList oForm = frmSalidaTraspasoList.GetInstance();
                        oForm.cargarGrid();
                    }

                    this.Close();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void obtenerEstatus(doc_inv_movimiento entity)
        {
            if (entity != null)
            {
                uiGuardado.Checked = true;
            }
            else {
                uiGuardado.Checked = false;
            }
            if (entity.Autorizado == true)
            {
                uiCargadoInv.Checked = true;
            }
            else {
                uiCargadoInv.Checked = false;
            }
            if (entity.Cancelado == true)
            {
                uiCancelado.Checked = true;
                uiFechaCancelacion.Visible = true;
            }
            else {
                uiCancelado.Checked = false;
            }
        }

        private void habilitarBotones(doc_inv_movimiento entity)
        {
            if (uiCancelado.Checked)
            {
                panelSup.Enabled = false;
                panel1.Enabled = false;
                uiGrid.Enabled = false;
            }
            else
            {
                if (entity.Autorizado == true)
                {
                    uiGuardar.Enabled = false;
                    uiAutorizar.Enabled = false;
                    uiCancelar.Enabled = true;
                    uiImprimir.Enabled = true;
                    uiGrid.Enabled = false;
                    uiAgregar.Enabled = false;
                }
                else
                {
                    uiGuardar.Enabled = true;
                    uiAutorizar.Enabled = true;
                    uiCancelar.Enabled = true;
                    uiImprimir.Enabled = false;
                }
            }
        }

        private void cancelar()
        {
            try
            {
                if (uiCargadoInv.Checked)
                {
                    if (
                        MessageBox.Show("¿Está seguro de continuar?, esto afectará el Inventario", "AVISO", MessageBoxButtons.YesNo) == DialogResult.Yes
                        )
                    {
                        try
                        {
                            oContext = new ERPProdEntities();

                            oContext.p_doc_inv_movimiento_cancel(idForm, 1);

                            ERP.Common.ReportesBusiness.imprimirMovInventarioCancelacion(idForm, 0);

                            if (tipoMovimientoForm == 3)
                            {
                                frmEntradaTraspasoList oForm = frmEntradaTraspasoList.GetInstance();
                                oForm.cargarGrid();
                            }

                            if (tipoMovimientoForm == 4)
                            {
                                frmSalidaTraspasoList oForm = frmSalidaTraspasoList.GetInstance();
                                oForm.cargarGrid();
                            }


                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenu.GetInstance().puntoVentaContext.usuarioId,
                              "ERP",
                              this.Name,
                              ex);
                            ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
                        }
                    }
                }
                else {
                    try
                    {
                        oContext = new ERPProdEntities();

                        oContext.p_doc_inv_movimiento_cancel(idForm, 1);

                        ERP.Common.ReportesBusiness.imprimirMovInventarioCancelacion(idForm, 0);

                        if (tipoMovimientoForm == 3)
                        {
                            frmEntradaTraspasoList oForm = frmEntradaTraspasoList.GetInstance();
                            oForm.cargarGrid();
                        }

                        if (tipoMovimientoForm == 4)
                        {
                            frmSalidaTraspasoList oForm = frmSalidaTraspasoList.GetInstance();
                            oForm.cargarGrid();
                        }

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenu.GetInstance().puntoVentaContext.usuarioId,
                             "ERP",
                             this.Name,
                             ex);
                        ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
                    }

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region eventos de controles.
        private void uiGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                eliminarProducto();
            }
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            guardar(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiAutorizar_Click(object sender, EventArgs e)
        {
            guardar(true);
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
        }

        #endregion

        private void uiImprimir_Click(object sender, EventArgs e)
        {

            boton_imprimir();
        }
        private void boton_imprimir()
        {
            try
            {
                if (idForm > 0)
                {
                    doc_inv_movimiento eMov = oContext.doc_inv_movimiento
                   .Where(w => w.MovimientoId == idForm).FirstOrDefault();

                    if (eMov.Cancelado ?? false)
                    {
                        ERP.Common.ReportesBusiness.imprimirMovInventarioCancelacion(idForm, 0);
                    }
                    else
                    {
                        imprimir();
                    }
                }

            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenu.GetInstance().puntoVentaContext.usuarioId,
                              "ERP",
                              this.Name,
                              ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }
        private void imprimir()
        {
            if (idForm > 0)
            {
                rptTraspasoInventario oTicket = new rptTraspasoInventario();
                ReportViewer oViewer = new ReportViewer();
                var ds = oContext.p_inv_movimiento_rpt(idForm).ToList();
                oTicket.DataSource = ds;
                oTicket.autorizadoPor = ds.FirstOrDefault().AutorizadoPor;
                oViewer.ShowReport(oTicket);
            }
        }

        private void frmEntradaTraspasoUpd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
             
                if (Convert.ToInt32(this.uiSucursalOrigen.SelectedValue) <= 0
                    || Convert.ToInt32(this.uiSucursalOrigen.SelectedValue) == Convert.ToInt32(this.uiSucursalDestino.SelectedValue)
                    )
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Es necesario especificar la sucursal Origen/Destino");
                    return;
                }
                

                ERP.Common.Productos.frmProductosBusqueda oForm = new ERP.Common.Productos.frmProductosBusqueda();

                var resultDialog = oForm.ShowDialog();

                if(resultDialog == DialogResult.OK)
                {

                    buscarProductoF3(oForm.response.Clave);
                }
            }
        }

        private void frmEntradaTraspasoUpd_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void frmEntradaTraspasoUpd_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void uiCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                agregarProducto();
            }
        }

        private void uiGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMovimiento_Click(object sender, EventArgs e)
        {
            frmExistenciasV2 frmo = new frmExistenciasV2();
            frmo.sucursalIdParam = Convert.ToInt32(uiSucursalDestino.SelectedValue);
            frmo.puntoVentaContext = this.puntoVentaContext;
            frmo.WindowState = FormWindowState.Normal;
            frmo.ShowDialog();

            
        }
    }
}
