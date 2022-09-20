using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using PuntoVenta.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVenta
{
    public partial class frmPuntoVenta : MetroFramework.Forms.MetroForm
    {
        public PuntoVentaContext puntoVentaContext;
        public bool permitirDescManueles { get; set; }
        private static frmPuntoVenta _instance;
        private bool basculaSiNo;
        private delegate void DelegadoAcceso(string accion);
        public bool tieneVentaPendiente { get {
                return lstProductos.Count > 0 ? true : false;
            } }
        ERPProdEntities oContext;
        List<ProductoModel0> lstProductos { get; set; }
        ProductoModel0 productoBuscar;
        List<FormaPagoModel> lstFormasPago { get; set; }
        public int clienteId;
        public string nombreCliente;
        ConexionBD.PuntoVenta oData;

        public static frmPuntoVenta GetInstance()
        {
            if (_instance == null) _instance = new frmPuntoVenta();
            else _instance.BringToFront();
            return _instance;
        }

        #region constructor
        public frmPuntoVenta()
        {
            InitializeComponent();
            uiGridProducto.AutoGenerateColumns = false;
            oData = new ConexionBD.PuntoVenta();

            //formato columnas
          
            this.uiGridProducto.Columns[3].DefaultCellStyle.Format = "c2";
            this.uiGridProducto.Columns[4].DefaultCellStyle.Format = "c2";
           // this.uiGridProducto.Columns[5].DefaultCellStyle.Format = "c2";
            this.uiGridProducto.Columns[6].DefaultCellStyle.Format = "c2";
            //this.uiGridProducto.Columns[7].DefaultCellStyle.Format = "c2";
            this.uiGridProducto.Columns[8].DefaultCellStyle.Format = "c2";

            this.uiGridProducto.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGridProducto.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGridProducto.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGridProducto.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGridProducto.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGridProducto.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            uiCodigoProducto.Focus();
        }
        #endregion

        #region eventos de la forma
        private void frmPuntoVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }
        private void frmPuntoVenta_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frmPuntoVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                basculaAbrirCerrar(2);
               // leerbascula();
            }
            


            if (e.KeyCode == Keys.F3)
            {
                abrirBuscarProd();

            }
            if (e.KeyCode == Keys.F4)
            {
                abrirBuscarCliente();

            }
        }

        private void frmPuntoVenta_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void frmPuntoVenta_Load(object sender, EventArgs e)
        {
            oContext = new ERPProdEntities();
            lstProductos = new List<ProductoModel0>();

            //frmMenu oForm = (frmMenu)this.MdiParent;
            this.puntoVentaContext = frmMenu.GetInstance().puntoVentaContext;
            obtenerFolioSig();
            uiCodigoProducto.Select();


            if(puntoVentaContext.giroPuntoVenta == Enumerados.systemGiro.AUTOLAV.ToString())
            {
                grAdicionalesAutoLav.Visible = true;
                grAdicioanles.Visible = false;
            }
            if (puntoVentaContext.giroPuntoVenta == Enumerados.systemGiro.ESTANDAR.ToString())
            {
                grAdicionalesAutoLav.Visible = false;
                grAdicioanles.Visible = true;
            }

            this.WindowState = FormWindowState.Maximized;

            int cajaId = puntoVentaContext.cajaId;
            if (
               oContext.cat_cajas
               .Where(w => w.Clave == cajaId)
               .FirstOrDefault().cat_cajas_impresora.Count == 0

                )
            {
                frMenuImpresota frm = new frMenuImpresota();
                frm.puntoVentaContext = this.puntoVentaContext;
                frm.StartPosition = FormStartPosition.CenterParent;
                //frm.MdiParent = this.MdiParent;
                frm.ShowDialog();
            }


        }
        #endregion

        #region eventos del grid
        private void uiGridProducto_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                ProductoModel0 entityRow;
                decimal cantidad = 0;
                decimal precioUnitario = 0;
                int partida = 0;
                decimal porcDescuento = 0;
                decimal total = 0;



                if (
                   uiGridProducto.Columns[e.ColumnIndex].Name == "Cantidad"
                   )
                {

                    partida = uiGridProducto.Rows[e.RowIndex].Cells["partida"].Value != null ? int.Parse(uiGridProducto.Rows[e.RowIndex].Cells["partida"].Value.ToString()) : 0;
                    entityRow = lstProductos.Where(w => w.partida == partida).FirstOrDefault();
                    cantidad = uiGridProducto.Rows[e.RowIndex].Cells["Cantidad"].Value != null ? decimal.Parse(uiGridProducto.Rows[e.RowIndex].Cells["Cantidad"].Value.ToString()) : 1;
                    precioUnitario = uiGridProducto.Rows[e.RowIndex].Cells["precioUnitario"].Value != null ? decimal.Parse(uiGridProducto.Rows[e.RowIndex].Cells["precioUnitario"].Value.ToString()) : 0;

                    /***********VALIDAr*************/
                    if (cantidad <= 0)
                    {
                        MessageBox.Show("No es posible capturar cantidad en cero");
                        uiGridProducto.Rows[e.RowIndex].Cells["Cantidad"].Value = decimal.Parse("1");
                        cantidad = 1;
                        
                    }

                    total = precioUnitario * cantidad;

                    entityRow.cantidad = cantidad;
                    entityRow.total = total;

                    CalcularImpuestos(entityRow);

                    porcDescuento = uiGridProducto.Rows[e.RowIndex].Cells["PorcDescuento"].Value != null ? decimal.Parse(uiGridProducto.Rows[e.RowIndex].Cells["PorcDescuento"].Value.ToString()) : 0;

                    if (porcDescuento > 0)
                    {
                        entityRow = aplicarDctoPartida(entityRow);
                    }

                    //Actualizar Fila
                    ActualizarGridModel(e.RowIndex, entityRow);

                    CalcularTotales();
                }

                if (
                    uiGridProducto.Columns[e.ColumnIndex].Name == "PorcDescuento"
                    )
                {
                    partida = uiGridProducto.Rows[e.RowIndex].Cells["partida"].Value != null ? int.Parse(uiGridProducto.Rows[e.RowIndex].Cells["partida"].Value.ToString()) : 0;
                    entityRow = lstProductos.Where(w => w.partida == partida).FirstOrDefault();

                    //Si la partida tiene descuento, ipedir modificar el porc de descuento
                    if (!entityRow.tienePromocion)
                    {

                        porcDescuento = uiGridProducto.Rows[e.RowIndex].Cells["PorcDescuento"].Value != null ? decimal.Parse(uiGridProducto.Rows[e.RowIndex].Cells["PorcDescuento"].Value.ToString()) : 0;

                        entityRow.porcDescunetoVta = 0;
                        entityRow.porcDescuentoPartida = porcDescuento;

                        entityRow = aplicarDctoPartida(entityRow);

                        //Actualizar Fila
                        ActualizarGridModel(e.RowIndex, entityRow);

                        CalcularTotales();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar refrescar la fila", "ERROR");
            }






        }

        private void uiGridProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                eliminarProducto();
            }
        }
        #endregion

        #region metodos
        private void abrirBuscarProd()
        {
            frmBuscarProducto f = new frmBuscarProducto();
            f.StartPosition = FormStartPosition.CenterParent;

            f.ShowDialog(this);
        }

        private string validar()
        {
            string error = "";
            try
            {
                if (uiTotal.Value <= 0)
                {
                    error = "No se ha agregado ningun producto.";
                    
                }
                if (puntoVentaContext.giroPuntoVenta == Enumerados.systemGiro.AUTOLAV.ToString())
                {
                    if(uiNombreClienteAuto.Text.Trim() == "")
                    {
                        error = error + ".Es necesario ingresar un nombre de cliente";
                    }
                    if (uiModeloAuto.Text.Trim() == "")
                    {
                        error = error+".Es necesario ingresar un modelo de auto";
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                
            }
            return error;
        }
        private void abrirFormasPago()
        {
            string error = validar();

            if(error.Length > 0)
            {
                XtraMessageBox.Show(error, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            frmVentaFormasPago f = new frmVentaFormasPago();
            f.StartPosition = FormStartPosition.CenterParent;
            f.totalVenta = uiTotal.Value;
            f.ShowDialog(this);
        }
        private string guarClienteId(ref int? clienteId)
        {
            string error = "";
           
            if(puntoVentaContext.giroPuntoVenta == Enumerados.systemGiro.AUTOLAV.ToString())
            {
                ClientesBusiness clientesB = new ClientesBusiness();

                cat_clientes cliente = new cat_clientes();
                cat_clientes_automovil clienteAuto = new cat_clientes_automovil();


                cliente.Nombre = uiNombreClienteAuto.Text.Trim();
                cliente.Activo = true;

                clienteAuto.Color = uiColorAuto.Text.Trim();
                clienteAuto.Observaciones = uiObservaciones.Text;
                clienteAuto.Modelo = uiModeloAuto.Text.Trim();
                clienteAuto.Placas = uiPlacas.Text.Trim();

                clientesB.InsertarClienteAutomovil(ref cliente, ref clienteAuto);

                clienteId = cliente.ClienteId;

                if (clienteId == 0 || clienteId == null || clienteAuto.ClienteAutoId == 0 || clienteAuto.ClienteAutoId == null)
                {
                    error = "No fue posible generar el cliente";
                }

            }

            return error;

           
            
        }
            
        private void abrirBuscarCliente()
        {
            frmBuscarCliente f = new frmBuscarCliente();
            f.StartPosition = FormStartPosition.CenterParent;
            
            f.ShowDialog(this);
        }
        public void asignarCliente(int clave, string nombre)
        {
            uiClienteId.Text = clave.ToString();
            uiNombreCliente.Text = nombre;
        }
        public void CalcularTotales()
        {
            uiDescuento.Value = lstProductos.Sum(s => s.montoDescuento);
            uiTotal.Value = lstProductos.Sum(s => s.total);
            uiImpuestos.Value = lstProductos.Sum(s => s.impuestos);
            uiSubTotal.Value = uiTotal.Value - uiImpuestos.Value ;
        }
        public void AgregarProducto(ProductoModel0 item)
        {

            item.partida = lstProductos.Count > 0 ? lstProductos.Max(M => M.partida) + 1 : 1;
            int promocionId=0;
            decimal porcentajePromocion=0;
            #region promociones

            buscarPromocion(item.productoId, this.puntoVentaContext.sucursalId, ref promocionId, ref porcentajePromocion);

            item.porcDescuento = porcentajePromocion;

            #endregion

            if ((item.porcDescuentoPartida + item.porcDescunetoVta + item.porcDescuento) > 0)
            {
                aplicarDctoPartida(item);
                item.tienePromocion = promocionId > 0 ? true : false;
            }
            

            lstProductos.Add(item);

            
            uiGridProducto.DataSource = lstProductos.ToList();

            productoBuscar = new ProductoModel0();            

            CalcularTotales();
        }

        private void uiCodigoProducto_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void obtenerFolioSig()
        {
            try
            {
               long folio =  oContext.doc_ventas.Count() > 0 ? oContext.doc_ventas.Max(m => m.VentaId) + 1 : 1;

                uiFolio.Text = folio.ToString();


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al tratar de obtener el folio siguiente");
            }
        }

        public void pagar(List<FormaPagoModel> _formasPago,List<ValeFPModel> _vales,decimal totalRecibido,decimal cambio)
        {
            lstFormasPago = _formasPago;
            long ventaId = 0;
            int? clienteId = uiClienteId.Text != "" ? int.Parse(uiClienteId.Text) : (int?)null;
            decimal descuentoPartidas = lstProductos.Sum(s => s.montoDescuento);
            string error = "";

            error = guarClienteId(ref clienteId);

            if (error.Length > 0)
            {
                XtraMessageBox.Show(error, "ERROR");
                return;
            }
            error = oData.pagar(ref ventaId, clienteId, uiFolio.Text, uiPorcDescVenta.Value, uiDescuento.Value - descuentoPartidas, descuentoPartidas, uiImpuestos.Value, uiSubTotal.Value, uiTotal.Value,
                totalRecibido, cambio, uiDescTodaVenta.Checked, puntoVentaContext.sucursalId, puntoVentaContext.usuarioId, puntoVentaContext.cajaId, lstProductos, lstFormasPago,_vales,0,false);

            if (error.Length > 0)
            {
                XtraMessageBox.Show(error, "ERROR");
                return;
            }
            else {
                //MessageBox.Show("La venta con FOLIO:" + uiFolio.Text + " se ha registrado con éxito");
            
                try
                {
                                       
                    cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();

                    if (uiTotal.Value >= (entity.MontoImpresionTicket??0))
                    {
                        if (entity.ImprimirTicketMediaCarta == true)
                        {
                            ERP.Reports.rptVentaTicket_CartaM oTicket1 = new ERP.Reports.rptVentaTicket_CartaM();


                            ERP.Common.Reports.ReportViewer oViewer = new ERP.Common.Reports.ReportViewer();

                            oTicket1.DataSource = oContext.p_rpt_VentaTicket(int.Parse(uiFolio.Text)).ToList();

                            oViewer.ShowTicket(oTicket1);
                        }
                        else {
                            ERP.Reports.rptVentaTicket oTicket2 = new ERP.Reports.rptVentaTicket();


                            ERP.Common.Reports.ReportViewer oViewer = new ERP.Common.Reports.ReportViewer();

                            oTicket2.DataSource = oContext.p_rpt_VentaTicket(int.Parse(uiFolio.Text)).ToList();

                            oViewer.ShowTicket(oTicket2);
                        }
                       

                        //oViewer.Show();
                    }


                       
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Ocurrió un error al intentar imprimir el ticket."+ex.Message, "ERROR");
                }
              

                Limpiar();


            }


        }

        public void Limpiar()
        {
            permitirDescManueles = false;
            panelCentro.Enabled = true;
            panelInferior.Enabled = true;
            panelSup.Enabled = true;
            grAdicionalesAutoLav.Enabled = true;
            uiGridProducto.DataSource = null;
            uiClienteId.Text = "";
            uiFecha.Value = DateTime.Now;
            uiNombreCliente.Text = "";
            uiDescPartida.Checked = false;
            uiDescTodaVenta.Checked = false;
            uiPorcDescVenta.Value = 0;
            uiCodigoProducto.Text = "";
            uiCantidad.Value = 1;
            uiDescripcionProd.Text = "";
            uiPrecioUnitario.Value = 0;
            uiPorcDescPartida.Value = 0;
            uiDescuento.Value = 0;
            uiImpuestos.Value = 0;
            uiSubTotal.Value = 0;
            uiTotal.Value = 0;
            uiVentaId.Value = 0;
            uiPrecioConDesc.Value = 0;
            uiNombreClienteAuto.Text = "";
            uiModeloAuto.Text = "";
            uiColorAuto.Text = "";
            uiPlacas.Text = "";
            uiObservaciones.Text = "";
            obtenerFolioSig();
            

            lstFormasPago = new List<FormaPagoModel>();
            lstProductos = new List<ProductoModel0>();
            CalcularTotales();
        }

        private void buscarPromocion(int productoId, int sucursalId, ref int promocionId, ref decimal porcentajePromocion)
        {
            oContext = new ERPProdEntities();
            var result = oContext.p_producto_promocion_sel(sucursalId,productoId,0,0).FirstOrDefault();

            if (result != null)
            {
                porcentajePromocion = result.PorcentajeDescuento;
                promocionId = result.PromocionId;
            }
        }



        private void subirProductoGrid()
        {

            int promocionId = 0;
            decimal porcentajePromocion = 0;
            decimal precioUltCompra = 0;

            

            productoBuscar.cantidad = uiCantidad.Value;
            
            productoBuscar.total = productoBuscar.cantidad * productoBuscar.precioUnitario;
            productoBuscar.impuestos = productoBuscar.total / (1 + (productoBuscar.porcImpuestos / 100));
            productoBuscar.impuestos = productoBuscar.total - productoBuscar.impuestos;

            #region promociones

            buscarPromocion(productoBuscar.productoId, this.puntoVentaContext.sucursalId, ref promocionId, ref porcentajePromocion);

            uiPorcDescPartida.Value = porcentajePromocion;            

            #endregion

            #region descuentos
            if (uiPorcDescPartida.Value > 0)
            {
                productoBuscar.porcDescuentoPartida = uiPorcDescPartida.Value;
                productoBuscar.porcDescuento = productoBuscar.porcDescunetoVta + productoBuscar.porcDescuentoPartida;
                productoBuscar.tienePromocion = promocionId > 0 ? true : false;

            }
            #endregion

           

            if (uiCantidad.Value <= 0)
            {
                MessageBox.Show("Es necesario especificar una cantidad", "ERROR");
                return;
            }
            

            if (productoBuscar.productoId > 0)
            {
                int productoId = productoBuscar.productoId;


                List<cat_productos_existencias> existencias = oContext.cat_productos_existencias.Where(w=> w.ProductoId == productoId).ToList();
                precioUltCompra = existencias.Max(m => m.CostoUltimaCompra);

                

                if (productoBuscar.precioUnitario <= 0)
                {
                    MessageBox.Show("El producto no existe o no tiene precio, no es posible agregar", "ERROR");
                    return;
                }

                if (productoBuscar.precioUnitario < precioUltCompra)
                {
                    MessageBox.Show("El producto no puede tener un precio menor al de la ultima compra", "ERROR");
                    return;
                }

                AgregarProducto(productoBuscar);
                uiDescripcionProd.Text = "";
                uiPrecioUnitario.Value = 0;
                uiPorcDescPartida.Value = 0;
                uiFotoProducto.Image = null;
                uiCodigoProducto.Text = "";
                uiCodigoProducto.Select();
                uiPrecioConDesc.Value = 0;
                uiTotalPartida.Value = 0;
                uiCantidad.Value = 1;
            }

            basculaAbrirCerrar(0);
        }

        private void eliminarProducto()
        {
            int rowIndex = uiGridProducto.CurrentCell.RowIndex;
            if (rowIndex >= 0)
            {

                if (uiGridProducto.Rows[rowIndex].Cells["partida"].Value != null)
                {
                    //Eliminar del grid
                    int partida = int.Parse(uiGridProducto.Rows[rowIndex].Cells["partida"].Value.ToString());
                    //DataGridViewRow dr = uiGridProducto.Rows[rowIndex];
                    //uiGridProducto.Rows.Remove(dr);

                    //Eliminar del arreglo
                    ProductoModel0 producto = lstProductos.Where(w => w.partida == partida).FirstOrDefault();
                    lstProductos.Remove(producto);


                    uiGridProducto.DataSource = lstProductos.ToList();
                    CalcularTotales();

                }

            }
        }

        private ProductoModel0 aplicarDctoPartida(ProductoModel0 entity)
        {

            entity.total = entity.cantidad * entity.precioUnitario;
            entity.impuestos = entity.total -( entity.total / ( 1+(entity.porcImpuestos / 100)));

            decimal subtotal = entity.total - entity.impuestos;

            entity.montoDescuento = subtotal * (entity.porcDescuento / 100);

            subtotal = subtotal - entity.montoDescuento;

            entity.total = subtotal * (1 + (entity.porcImpuestos/100));
               
            entity.impuestos = entity.total - (entity.total / (1 + (entity.porcImpuestos / 100)));

            //decimal totalSinImp = entity.total - entity.impuestos;
            //entity.montoDescuento = entity.porcDescuento > 0 ?  (totalSinImp * (entity.porcDescuento / 100)) : 0;
            //totalSinImp = totalSinImp - entity.montoDescuento;
            //entity.total = totalSinImp * (1 + (entity.porcImpuestos / 100));
            //entity.impuestos = entity.total - (entity.total / (1 + (entity.porcImpuestos / 100)));


            return entity;

        }

        private void AplicarDctoGrid()
        {
            int count = lstProductos.Count;

            for (int i = 0; i < count; i++)
            {
                ProductoModel0 entity = lstProductos[i];
                entity.porcDescunetoVta = uiPorcDescVenta.Value;
                entity.porcDescuento = entity.porcDescunetoVta + entity.porcDescuentoPartida;

                entity = aplicarDctoPartida(entity);

                lstProductos[i] = entity;

                


            }

            uiGridProducto.DataSource = lstProductos;
            uiGridProducto.Refresh();
        }

        private void CalcularImpuestos(ProductoModel0 entity)
        {
            entity.impuestos = entity.total - (entity.total / (1 + (entity.porcImpuestos / 100)));
        }

        private void ActualizarGridModel(int indexRow, ProductoModel0 entity)
        {
            uiGridProducto.Rows[indexRow].Cells["partida"].Value = entity.partida;
            uiGridProducto.Rows[indexRow].Cells["impuestos"].Value = entity.impuestos;
            uiGridProducto.Rows[indexRow].Cells["cantidad"].Value = entity.cantidad;
            uiGridProducto.Rows[indexRow].Cells["porcDescuento"].Value = entity.porcDescuento;
            uiGridProducto.Rows[indexRow].Cells["MontoDescuento"].Value = entity.montoDescuento;
            uiGridProducto.Rows[indexRow].Cells["total"].Value = entity.total;
            uiGridProducto.Refresh();
        }

        public void buscarTicket(string folio)
        {
            try
            {
                oContext = new ERPProdEntities();
                Limpiar();

                doc_ventas ticket = oContext.doc_ventas.Where(w => w.Folio == folio.Trim()).FirstOrDefault();

                if (ticket != null)
                {
                    panelCentro.Enabled = false;
                    panelInferior.Enabled = false;
                    panelInferior.Enabled = false;
                    grAdicionalesAutoLav.Enabled = false;

                    //gpVenta.Enabled = false;

                    uiGridProducto.DataSource = ticket.doc_ventas_detalle
                        .Select(
                            s => new ProductoModel0()
                            {
                                cantidad = s.Cantidad??0,
                                clave = s.cat_productos.Clave,
                                descripcion = s.cat_productos.Descripcion,
                                impuestos = s.Impuestos,
                                montoDescuento = s.Descuento,
                                porcDescuento = s.PorcDescuneto,
                                //partida = s.VentaDetalleId,
                                porcDescuentoPartida = s.PorcDescuneto,
                                porcDescunetoVta = s.PorcDescuneto,
                                precioUnitario = s.PrecioUnitario,
                                productoId = s.ProductoId,
                                total = s.Total
                            }
                        ).ToList();

                    uiClienteId.Text = ticket.ClienteId != null ? ticket.ClienteId.ToString() : "";
                    uiFecha.Value = ticket.Fecha;
                    uiFolio.Text = ticket.Folio;
                    uiDescuento.Value = ticket.TotalDescuento ?? 0;
                    uiSubTotal.Value = ticket.SubTotal;
                    uiImpuestos.Value = ticket.Impuestos;
                    uiTotal.Value = ticket.TotalVenta;
                    uiVentaId.Value = ticket.VentaId;
                    uiActivo.Checked = ticket.Activo;
                    uiNombreClienteAuto.Text = ticket.cat_clientes != null ? ticket.cat_clientes.Nombre : "";
                    uiModeloAuto.Text = ticket.cat_clientes != null ?
                            ticket.cat_clientes.cat_clientes_automovil.Count > 0 ?
                            ticket.cat_clientes.cat_clientes_automovil.FirstOrDefault().Modelo : ""
                        :"";
                    uiColorAuto.Text = ticket.cat_clientes != null ? 
                        ticket.cat_clientes.cat_clientes_automovil.Count > 0 ?
                        ticket.cat_clientes.cat_clientes_automovil.FirstOrDefault().Color : ""
                        :"";
                    uiPlacas.Text = ticket.cat_clientes != null ? 
                        ticket.cat_clientes.cat_clientes_automovil.Count > 0 ?
                       ticket.cat_clientes.cat_clientes_automovil.FirstOrDefault().Placas : ""
                       :"";
                    uiObservaciones.Text = ticket.cat_clientes != null ? 
                        ticket.cat_clientes.cat_clientes_automovil.Count > 0 ?
                        ticket.cat_clientes.cat_clientes_automovil.FirstOrDefault().Observaciones : ""
                      :"";
                }
                else {
                    MessageBox.Show("El ticket no existe");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al buscar el ticket", "ERROR");
            }
            
        }

        public void Cancelar()
        {
            try
            {
                oContext = new ERPProdEntities();
                int ventaId = 0;

                if (!uiActivo.Checked)
                {
                    MessageBox.Show("NO ES POSIBLE VOLVER A CANCELAR EL TICKET", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int.TryParse(uiVentaId.Value.ToString(), out ventaId);

                frmCancelarTicket oFrm = new frmCancelarTicket();
                oFrm.ventaId = ventaId;
                oFrm.StartPosition = FormStartPosition.CenterParent;
                oFrm.puntoVentaContext = this.puntoVentaContext;
                oFrm.ShowDialog();


               

                //doc_ventas entityVenta = oContext.doc_ventas.Where(w => w.VentaId == ventaId).FirstOrDefault();

                //if (entityVenta != null)
                //{
                //    DateTime fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                //    if (fechaActual.Date != entityVenta.Fecha.Date)
                //    {
                //        MessageBox.Show("Solo se pueden cancelar tickets del día actual", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }
                //    if (entityVenta.Activo == false)
                //    {
                //        MessageBox.Show("No es posible volver a cancelar el ticket", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return;
                //    }

                //    if (entityVenta != null)
                //    {
                //        if (MessageBox.Show("¿Está seguro de cancelar el ticket con folio:" + entityVenta.Folio, "AVISO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //        {

                //            oContext.p_doc_ventas_cancelacion(ventaId, puntoVentaContext.usuarioId);

                //            MessageBox.Show("El ticket con folio:" + entityVenta.Folio + " ha sido cancelado", "AVISO");
                //            Limpiar();
                //        }

                //    }
                //    else
                //    {
                //        MessageBox.Show("Es necesario primero buscar el ticket a cancelar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
                //else {
                //    MessageBox.Show("Es necesario primero buscar un ticket", "ERROR",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}





            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message :ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        #endregion
          

        #region eventos de controles
        private void uiDescTodaVenta_CheckedChanged(object sender, EventArgs e)
        {
            if (uiDescTodaVenta.Checked)
            {
                uiPorcDescVenta.Enabled = true;
                uiPorcDescPartida.Enabled = false;
            }
            else {
                uiPorcDescVenta.Enabled = false;
                uiPorcDescPartida.Enabled = true;
            }
        }

        private void uiDescPartida_CheckedChanged(object sender, EventArgs e)
        {
            if (uiDescTodaVenta.Checked)
            {
                uiPorcDescVenta.Enabled = true;
                uiPorcDescPartida.Enabled = false;
            }
            else
            {
                uiPorcDescVenta.Enabled = false;
                uiPorcDescPartida.Enabled = true;
            }
        }

        private void uiAgregarProd_Click(object sender, EventArgs e)
        {
            subirProductoGrid();


        }

        private void uiCodigoProducto_TextChanged(object sender, EventArgs e)
        {


        }

        private void uiCodigoProducto_Validated(object sender, EventArgs e)
        {
            oContext = new ERPProdEntities();
            decimal descuento=0;
            int promocionId=0;

            productoBuscar = new ProductoModel0();

            uiDescripcionProd.Text = "";
            uiPrecioUnitario.Value = 0;

            var result = oContext.p_BuscarProductos(uiCodigoProducto.Text,true,0,false).FirstOrDefault();

            
                      

            if (result != null)
            {

                if (result.Estatus == false)
                {
                    MessageBox.Show("El producto:" + result.Descripcion + " está inactivo, es necesario activarlo desde el catálogo de productos para poder venderlo",
                         "AVISO",
                          MessageBoxButtons.OK,
                           MessageBoxIcon.Warning);
                    return;
                }

                buscarPromocion(result.ID, this.puntoVentaContext.sucursalId, ref promocionId, ref descuento);

                productoBuscar = new ProductoModel0()
                {
                    cantidad = 1,
                    clave = result.Clave.ToString(),
                    descripcion = result.Descripcion,
                    impuestos = result.impuestos ?? 0,
                    precioUnitario = result.Precio,
                    productoId = result.ID,
                    porcImpuestos = result.porcImpuestos ?? 0,
                    total = 0
                };

                if (result.Foto != null)
                {
                    using (var ms = new MemoryStream(result.Foto))
                    {
                        uiFotoProducto.Image = Image.FromStream(ms);
                    }
                }
                else {
                    uiFotoProducto.Image = null;
                }
               

                uiDescripcionProd.Text = productoBuscar.descripcion;
                uiPrecioUnitario.Value = productoBuscar.precioUnitario;
                uiPrecioConDesc.Value = descuento > 0 ?
                    productoBuscar.precioUnitario - (uiPrecioUnitario.Value * (descuento / 100) ):
                     uiPrecioUnitario.Value;
                uiPorcDescPartida.Value = descuento;

                if(result.ProdVtaBascula==true)
                {
                    uiCantidad.DecimalPlaces = 4;
                    basculaSiNo = true;
                    basculaAbrirCerrar(1);
                }
                else
                {
                    uiCantidad.DecimalPlaces = 0;
                    basculaSiNo = false;
                }

            }

            
        }
        private void uiBuscarCliente_Click(object sender, EventArgs e)
        {
            abrirBuscarCliente();

        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            basculaAbrirCerrar(0);
            abrirFormasPago();
        }

        private void uiCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                subirProductoGrid();
            }
           
        }

        private void uiCantidad_ValueChanged(object sender, EventArgs e)
        {

        }

        private void uiPrecioUnitario_ValueChanged(object sender, EventArgs e)
        {
            uiTotalPartida.Value = uiCantidad.Value * uiPrecioConDesc.Value;
        }

        private void uiCantidad_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void uiCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

       

        private void uiCodigoProducto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                uiCantidad.Focus();
            }
        }


        #endregion

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void uiPorcDescVenta_ValueChanged(object sender, EventArgs e)
        {
            AplicarDctoGrid();
        }

        private void uiBuscarCliente_Click_1(object sender, EventArgs e)
        {
            abrirBuscarCliente();
        }

        private void uiGridProducto_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            ProductoModel0 entityRow;
            decimal cantidad = 0;
            decimal precioUnitario = 0;
            int partida = 0;
            decimal porcDescuento = 0;
            decimal total = 0;
            if (
                    uiGridProducto.Columns[e.ColumnIndex].Name == "PorcDescuento"
                    )
            {
                partida = uiGridProducto.Rows[e.RowIndex].Cells["partida"].Value != null ? int.Parse(uiGridProducto.Rows[e.RowIndex].Cells["partida"].Value.ToString()) : 0;
                entityRow = lstProductos.Where(w => w.partida == partida).FirstOrDefault();

                //Si la partida tiene descuento, ipedir modificar el porc de descuento
                if (entityRow.tienePromocion || !permitirDescManueles)
                {

                    e.Cancel = true;
                }

            }
        }

        private void uiGridProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int partida = 0;
                if (
                   uiGridProducto.Columns[e.ColumnIndex].Name == "PorcDescuento"
                   )
                {
                    partida = uiGridProducto.Rows[e.RowIndex].Cells["partida"].Value != null ? int.Parse(uiGridProducto.Rows[e.RowIndex].Cells["partida"].Value.ToString()) : 0;
                    ProductoModel0 entityRow;

                    entityRow = lstProductos.Where(w => w.partida == partida).FirstOrDefault();

                    if (!permitirDescManueles && !entityRow.tienePromocion)
                    {
                        frmAutorizacion oAut = new frmAutorizacion();
                        oAut.opcionLlamado = 4;//permitir descuentos
                        oAut.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                                
            }
        }

        public void habilitarDescuentosManuales()
        {
            permitirDescManueles = true;
        }

        private void uiCantidad_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void btnCobrar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                subirProductoGrid();
                uiTotalPartida.Value = uiCantidad.Value * uiPrecioConDesc.Value;
            }
        }

        private void basculaAbrirCerrar(int abrir_cerrar_o)
        {
            try
            {
                if(abrir_cerrar_o == 2)
                {
                    if (serialPort1.IsOpen)
                    {
                        abrir_cerrar_o = 0;
                    }
                    else
                    {
                        abrir_cerrar_o = 1;
                    }
                }

                if(abrir_cerrar_o == 1)
                {
                    if(!basculaSiNo)
                    {
                        XtraMessageBox.Show("No es posible habilitar la bascula para este producto","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                    if (!serialPort1.IsOpen)
                    {
                        serialPort1.Open();
                        
                    }
                    basculaSiNo = true;
                    timerBascula.Enabled = true;
                    lblAviso.Text = "LEYENDO BASCULA...";
                    uiCantidad.Focus();
                }

                if (abrir_cerrar_o == 0)
                {
                    basculaSiNo =false;
                    serialPort1.Close();
                    timerBascula.Enabled = false;
                    lblAviso.Text = "";
                }

              
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }

          
        }

      
        private void leerBascula()
        {
            try
            { 
                
                
                serialPort1.Write("P");
                string value = serialPort1.ReadExisting();
                value = value.Replace("Kg", "").Replace("+", "").Replace("KG","").Replace("kg","");
                decimal cantidad = 0;

                if(value.Length > 0)
                {
                    decimal.TryParse(value,out cantidad);
                    uiCantidad.Value = cantidad;
                }
                

            }
            catch (Exception EX)
            {
                timerBascula.Enabled = false;
                XtraMessageBox.Show(EX.Message,"error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
            }

        }


        void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {

                Thread.Sleep(500);

                string value = serialPort1.ReadExisting();
                MessageBox.Show(value);
                this.BeginInvoke(new DelegadoAcceso(si_DataReceived),new object[] { value});

                /*decimal cantidadBascula = 0;

                decimal.TryParse(value, out cantidadBascula);

                XtraMessageBox.Show(serialPort1.ReadExisting());

                uiCantidad.Value = cantidadBascula;*/
            }


        }

        private void si_DataReceived(string accion)
        {
            lblAviso.Text = accion;
        }

        private void panelInferior_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiCantidad_Leave(object sender, EventArgs e)
        {
            uiTotalPartida.Value = uiCantidad.Value * uiPrecioConDesc.Value;
        }

        private void uiGridProducto_Enter(object sender, EventArgs e)
        {
           
        }

        private void uiCantidad_Enter(object sender, EventArgs e)
        {
            uiCantidad.Select(0, uiCantidad.Text.Length);
        }

        public void setClave(string clave)
        {
            try
            {
                uiCodigoProducto.Text = clave;
                //uiCodigoProducto.Focus();
                
                uiCantidad.Focus();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void timerBascula_Tick(object sender, EventArgs e)
        {
            leerBascula();
        }

        private void uiCodigoProducto_Leave(object sender, EventArgs e)
        {

        }
    }
}
