using ConexionBD;
using ConexionBD.Forms;
using ConexionBD.Models;
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
    public partial class frmEntradaDirectaUpd : FormERP
    {
        List<MovimientoInventarioProductoModel> lstMovs;


        private static frmEntradaDirectaUpd _instance;
        public int tipoMovimientoForm{get;set;}

        public static frmEntradaDirectaUpd GetInstance()
        {
            if (_instance == null) _instance = new frmEntradaDirectaUpd();
            else _instance.BringToFront();
            return _instance;
        }

        public frmEntradaDirectaUpd()
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
            this.puntoVentaContext = frmMenu.GetInstance().puntoVentaContext;
            lstMovs = new List<MovimientoInventarioProductoModel>();
            CargarCombos();

            uiSucursalOrigen.SelectedValue = puntoVentaContext.sucursalId;
            
            

            switch (tipoMovimientoForm)
            {
                case 3:
                   
                    lblTituloForm.Text = "Entrada Por Traspaso";
                    this.Text = "Entrada Por Traspaso";
                    break;
                case 4:
                    lblTituloForm.Text = "Salida Por Traspaso";
                    this.Text = "Salida Por Traspaso";
                    break;
                case 7:
                    lblTituloForm.Text = "Entrada Directa";
                    this.Text = "Entrada Directa";
                    break;
                default:
                    break;
            }

            switch (accionForm)
            {
                case 1:
                    uiImprimir.Enabled = false;
                    uiCancelar.Enabled = false;
                    // obtenerFolioSig();
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
        private void agregarProducto()
        {
            if (
               uiDescProducto.Text != ""
               &&
               uiCantidad.Value > 0
               && 
               uiPrecioCompra1.Value > 0
               )
            {
                agregarProductoGrid();
                CalcularTotal();
                uiClave.Text = "";
                uiDescProducto.Text = "";
                uiCantidad.Value = 0;
                uiPrecioCompra1.Value = 0;
            }
            else
            {
                MessageBox.Show("Es necesario especificar un producto, cantidad y precio de compra", "AVISO");
            }
        }
        #endregion

        #region metodos
        public void buscarProductoF3(string clave)
        {
            uiClave.Text = clave;
            buscarProducto();
            uiCantidad.Focus();
            uiCantidad.Select();
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
                    producto.porcImpuestos = entity.cat_productos_impuestos != null ?
                                                    entity.cat_productos_impuestos.Sum(s => s.cat_impuestos.Porcentaje??0)
                                                :0;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

            return producto;
        }

        private void agregarProductoGrid()
        {
            MovimientoInventarioProductoModel producto = buscarProducto();
            producto.cantidadMov = uiCantidad.Value;
            producto.partida = lstMovs.Count + 1;
            producto.precioUnitario = uiPrecioCompra1.Value;
            producto.subtotal = ERP.Utils.CalculosContaTool.DesgloceIVA(producto.importe, producto.porcImpuestos).subtotal;
            producto.impuestos = ERP.Utils.CalculosContaTool.DesgloceIVA(producto.importe, producto.porcImpuestos).impuestos;
            producto.precioNeto = ERP.Utils.CalculosContaTool.DesgloceIVA(producto.precioUnitario, producto.porcImpuestos).subtotal;
            lstMovs.Add(producto);

            uiGrid.AutoGenerateColumns = false;
            uiGrid.DataSource = null;
            uiGrid.DataSource = lstMovs.ToList();  
            uiGrid.Refresh();
        }

        private void obtenerFolioSig()
        {
            int folio = oContext.doc_inv_movimiento.Count() > 0 ? oContext.doc_inv_movimiento.Max(m => m.MovimientoId) + 1 : 1;

            uiFolio.Text = folio.ToString();
        }
        public void CargarCombos()
        {
            //uiSucursalDestino.DataSource = oContext.cat_sucursales.Where(w => w.Estatus == true).ToList();
            uiSucursalOrigen.DataSource = ERP.Business.SucursalBusiness.ObtenSucursalesPorUsuario(this.puntoVentaContext.empresaId,
                    this.puntoVentaContext.usuarioId);
        }

        private void eliminarProducto()
        {
            try
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

                        uiGrid.DataSource = null;
                        uiGrid.DataSource = lstMovs;
                        uiGrid.Refresh();
                        uiGrid.Parent.Refresh();

                    }

                }
            }
            catch (Exception ex)
            {

                ERP.Utils.MessageBoxUtil.ShowError("Ocurrió un error inesperado");
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
               // int sucursalDestino = uiSucursalDestino.SelectedValue == null ? 0 : int.Parse(uiSucursalDestino.SelectedValue.ToString());
                DateTime fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                decimal total = lstMovs.Sum(s => s.importe);

                switch (accionForm)
                {
                    /**********Agregar***************************/
                    case 1:
                        using (TransactionScope scope = new TransactionScope())
                        {
                            oContext.p_doc_inv_movimiento_ins(pMovimientoID, sucursalOrigen, uiFolio.Text, tipoMovimientoForm, fechaActual, fechaActual.TimeOfDay, "",
                          total, 1, false, null,sucursalOrigen, null, null,null);

                            foreach (MovimientoInventarioProductoModel itemMov in lstMovs)
                            {

                                ObjectParameter pMovimientoDetalleId = new ObjectParameter("pMovimientoDetalleId", 0);
                                oContext.p_inv_movimiento_detalle_ins(pMovimientoDetalleId, 
                                    int.Parse(pMovimientoID.Value.ToString()), 
                                    itemMov.productoId, 0, 
                                    itemMov.cantidadMov, itemMov.precioUnitario, 0, 
                                    itemMov.cantidadMov, 1,0,0,itemMov.subtotal,itemMov.precioNeto);
                            }

                            accionForm = (int)Enumerados.accionForm.actualizar;
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
                            oContext.p_doc_inv_movimiento_upd(pMovimientoID, sucursalOrigen, uiFolio.Text, tipoMovimientoForm, fechaActual, fechaActual.TimeOfDay, "",
                            total, 1, false, null,sucursalOrigen, null, null,null);

                            /********Eliminar detalle************/
                            List<doc_inv_movimiento_detalle> lstDetalle = oContext.doc_inv_movimiento_detalle.Where(w => w.MovimientoId == idForm).ToList();
                            foreach (doc_inv_movimiento_detalle itemDel in lstDetalle)
                            {
                                oContext.doc_inv_movimiento_detalle.Remove(itemDel);
                            }

                            oContext.SaveChanges();

                            foreach (MovimientoInventarioProductoModel itemMov in lstMovs)
                            {

                                ObjectParameter pMovimientoDetalleId = new ObjectParameter("pMovimientoDetalleId", 0);
                                oContext.p_inv_movimiento_detalle_ins(pMovimientoDetalleId, int.Parse(pMovimientoID.Value.ToString()), itemMov.productoId, 0, itemMov.cantidadMov, itemMov.precioUnitario, 0, itemMov.cantidadMov, 1,0,0,itemMov.subtotal,itemMov.precioNeto);
                            }

                            accionForm = (int)Enumerados.accionForm.actualizar;
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
                    
                        frmEntradaDirectaList oForm = frmEntradaDirectaList.GetInstance();
                        oForm.cargarGrid();
                   


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
            //int sucursalDestino = uiSucursalDestino.SelectedValue == null ? 0 : int.Parse(uiSucursalDestino.SelectedValue.ToString());

            if (
                sucursalOrigen == 0
                )
            {
                error = "Es necesario especificar la sucursal Origen y de Destino";
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
                uiSucursalOrigen.SelectedValue = entity.SucursalId;
               // uiSucursalDestino.SelectedValue = entity.SucursalDestinoId;
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
                            unidad = s.cat_productos.cat_unidadesmed  != null ? 
                                        s.cat_productos.cat_unidadesmed.Descripcion
                                        :"",
                            unidadId = s.cat_productos.ClaveUnidadMedida ?? 0
                        }
                    ).ToList();

                for (int i = 0; i < lstMovs.Count; i++)
                {
                    lstMovs[i].partida = i + 1;
                }

                uiGrid.AutoGenerateColumns = false;

                
                uiGrid.DataSource = lstMovs.ToList();
                uiGrid.Refresh();
                

            }
            catch (Exception EX)
            {

                MessageBox.Show("Error al buscar el movimiento", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    oContext.p_inv_movimiento_autoriza(idForm, 1);
                   

                    MessageBox.Show("El movimiento ha sido autorizado", "OK");

                    frmEntradaDirectaList oForm = frmEntradaDirectaList.GetInstance();
                    oForm.cargarGrid();

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
                uiPrecioCompra.Enabled = false;
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

                            ERP.Common.ReportesBusiness.imprimirMovInventarioCancelacion(idForm,0);

                            frmEntradaDirectaList oForm = frmEntradaDirectaList.GetInstance();
                            oForm.cargarGrid();



                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR");
                        }
                    }
                }
                else {
                    try
                    {
                        oContext = new ERPProdEntities();

                        oContext.p_doc_inv_movimiento_cancel(idForm, 1);

                        ERP.Common.ReportesBusiness.imprimirMovInventarioCancelacion(idForm, 0);

                        if (tipoMovimientoForm == (int)Enumerados.tipoMovsInventario.ajustePorEntrada)
                        {
                            frmAjusteEntradaList oForm = frmAjusteEntradaList.GetInstance();
                            oForm.cargarGrid();
                        }

                        if (tipoMovimientoForm == (int)Enumerados.tipoMovsInventario.ajustePorSalida)
                        {
                            frmAjusteSalidaList oForm = frmAjusteSalidaList.GetInstance();
                            oForm.cargarGrid();
                        }


                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR");
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
                if(idForm > 0)
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
           rptMovimientoInventario oTicket = new rptMovimientoInventario();
            ReportViewer oViewer = new ReportViewer();
            var ds = oContext.p_inv_movimiento_rpt(idForm).ToList();
            oTicket.DataSource = ds;
            oTicket.autorizadoPor = ds.FirstOrDefault().AutorizadoPor;
            oViewer.ShowReport(oTicket);
        }

        private void frmEntradaDirectaUpd_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void frmEntradaDirectaUpd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                ERP.Common.Productos.frmProductosBusqueda oForm = new ERP.Common.Productos.frmProductosBusqueda();

                var resultDialog = oForm.ShowDialog();

                if (resultDialog == DialogResult.OK)
                {

                    buscarProductoF3(oForm.response.Clave);
                }
            }
        }

        private void uiCantidad_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void numericUpDown1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                agregarProducto();
            }
        }
    }
}
