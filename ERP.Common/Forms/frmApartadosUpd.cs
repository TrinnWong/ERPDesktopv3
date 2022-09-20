using ConexionBD;
using ConexionBD.Forms;
using ERP.Common.Reports;
using ERP.Reports;
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

namespace ERP.Common.Forms
{
    public partial class frmApartadosUpd : FormERP
    {
        public ProductoModel0 productoSel { get; set; }
        private static frmApartadosUpd _instance;
        public int accionForm { get; set; }
        List<ProductoModel0> lstProductos { get; set; }
        public List<FormaPagoModel> lstFormasPagoAnticipo;
        
        public static frmApartadosUpd GetInstance()
        {

            if (_instance == null) _instance = new frmApartadosUpd();
            return _instance;
        }
        public frmApartadosUpd()
        {
            InitializeComponent();
            lstFormasPagoAnticipo = new List<FormaPagoModel>();
        }
        

        private ProductoModel0 buscarProducto()
        {
            ProductoModel0 producto = null;
            try
            {
                string clave = uiProducto.Text;


                cat_productos entity = oContext.cat_productos.Where(w => w.Clave == clave).FirstOrDefault();

                if (entity != null)
                {
                    producto = new ProductoModel0();
                    uiProductoDesc.Text = entity.Descripcion;
                    producto.cantidad = 0;
                    producto.clave = entity.Clave;
                    producto.precioUnitario = entity.cat_productos_precios.Count > 0 ?
                                            entity.cat_productos_precios.Where(
                                                    w=> w.IdPrecio == (int)Enumerados.precios.publicoGral
                                                ).FirstOrDefault().Precio
                                                :0;
                    producto.productoId = entity.ProductoId;
                    producto.unidadId = entity.ClaveUnidadMedida ?? 0;
                    producto.unidad = entity.cat_unidadesmed != null ? entity.cat_unidadesmed.Descripcion : "";
                    producto.descripcion = entity.Descripcion;
                    producto.porcImpuestos = entity.cat_productos_impuestos.Sum(s => s.cat_impuestos.Porcentaje ?? 0);
                    
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

            return producto;
        }

        private void uiProducto_Validating(object sender, CancelEventArgs e)
        {
            buscarProducto();
        }

        private void uiAgregarProducto_Click(object sender, EventArgs e)
        {
            agregarProductoGrid();
        }

        private ProductoModel0 aplicarDctoPartida(ProductoModel0 entity)
        {

            entity.total = entity.cantidad * entity.precioUnitario;
            entity.impuestos = entity.total - (entity.total / (1 + (entity.porcImpuestos / 100)));

            decimal subtotal = entity.total - entity.impuestos;

            entity.montoDescuento = subtotal * (entity.porcDescuento / 100);

            subtotal = subtotal - entity.montoDescuento;

            entity.total = subtotal * (1 + (entity.porcImpuestos / 100));

            entity.impuestos = entity.total - (entity.total / (1 + (entity.porcImpuestos / 100)));          


            return entity;

        }

        private void calcularDescuento(int partida, decimal descuento)
        {
            try
            {
                decimal total = lstProductos.Find(f => f.partida == partida).cantidad*
                    lstProductos.Find(f => f.partida == partida).precioUnitario;

                total = total - (total * (descuento / 100));

                lstProductos.Find(f => f.partida == partida).total = total;

                uiGrid.DataSource = lstProductos;

                uiGrid.Refresh();

                calcularTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al calcular el descuento", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void agregarProductoGrid()
        {
            ProductoModel0 producto = buscarProducto();
            int promocionId=0;
            decimal porcentajePromocion = 0;
            ConexionBD.ProductoInterface.buscarPromocion(producto.productoId, this.puntoVentaContext.sucursalId, ref promocionId, ref porcentajePromocion);

            producto.porcDescuentoPartida = porcentajePromocion;
            producto.porcDescuento = producto.porcDescuentoPartida;
            producto.tienePromocion = promocionId > 0 ? true : false;

            producto.cantidad = uiCantidad.Value;
            producto.partida = lstProductos.Count + 1;
            producto.total = producto.cantidad * producto.precioUnitario;

          

            if (producto.cantidad == 0)
            {
                MessageBox.Show("Especifique una cantidad");
                return;
            }
            if (producto.precioUnitario <= 0)
            {
                MessageBox.Show("No es posible agregar un producto sin precio");
                return;
            }

            if (producto.tienePromocion)
            {
                producto = aplicarDctoPartida(producto);
            }
            else {
                producto.total = producto.cantidad * producto.precioUnitario;
                producto.impuestos = producto.total / (1 + (producto.porcImpuestos / 100));
                producto.impuestos = producto.total - producto.impuestos;
            }

            lstProductos.Add(producto);

            calcularTotales();

            uiGrid.AutoGenerateColumns = false;
            uiGrid.DataSource = null;
            uiGrid.DataSource = lstProductos;
            uiGrid.Refresh();
        }

        private void frmApartadosUpd_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void frmApartadosUpd_Load(object sender, EventArgs e)
        {
            lstProductos = new List<ProductoModel0>();

            this.uiGrid.Columns[4].DefaultCellStyle.Format = "n2";
            this.uiGrid.Columns[5].DefaultCellStyle.Format = "c2";
            this.uiGrid.Columns[7].DefaultCellStyle.Format = "c2";
            this.uiGrid.Columns[6].DefaultCellStyle.Format = "n2";

            this.uiGrid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGrid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGrid.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGrid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            


            if (accionForm == 1)
            {
                ObtenerFolioSig();
                uiPagos.Enabled = false;
            }
            if (accionForm == 2)
            {
                uiGuardar.Enabled = false;
                panel1.Enabled = false;
                uiGrid.Enabled = false;
                llenarForma();
                uiPagos.Enabled = true;
            }

            
        }


        private void calcularTotales()
        {
            uiTotal.Value = lstProductos.Sum(s => s.total) ;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmBuscarCliente oForm = new frmBuscarCliente();
            oForm.StartPosition = FormStartPosition.CenterParent;
            oForm.opcionERP = (int)Enumerados.opcionesERP.apartadosUpd;
            oForm.ShowDialog();
        }

        public void SeleccionarCliente( cat_clientes cliente)
        {
            if (cliente != null)
            {
                uiCliente.Text = cliente.ClienteId.ToString();
                uiClienteNombre.Text = cliente.Nombre;
            }
        }

        public void SeleccionadProducto(ProductoModel0 producto)
        {
            uiProducto.Text = producto.clave;
            uiProductoDesc.Text = producto.descripcion;
            uiCantidad.Focus();
            uiCantidad.Select();
        }

        private void uiBuscarCliente_Click(object sender, EventArgs e)
        {
            frmBuscarProducto oForm = new frmBuscarProducto();

            oForm.opcionERP = (int)Enumerados.opcionesERP.apartadosUpd;
            oForm.StartPosition = FormStartPosition.CenterParent;
            oForm.ShowDialog();


        }

        public void ObtenerFolioSig()
        {
            oContext = new ERPProdEntities();
            int folio = oContext.doc_apartados.Count() > 0 ?
                oContext.doc_apartados.Max(m => m.ApartadoId) + 1
                : 1;

            uiFolio.Text = folio.ToString();
        }
        private void uiCantidad_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void uiCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                agregarProductoGrid();
            }
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private decimal calcularMinimoAnticipo()
        {
            decimal anticipo1 = 0, anticipo2 = 0;
            decimal apartadoHasta1 = 0, apartadoHasta2 = 0;

            
                cat_configuracion entity = oContext.cat_configuracion.FirstOrDefault();
                if (entity != null)
                {

                    anticipo1 = entity.ApartadoAnticipo1 == null ? 0: entity.ApartadoAnticipo1.Value;
                    anticipo2 = entity.ApartadoAnticipo2 == null ? 0 : entity.ApartadoAnticipo2.Value;
                    apartadoHasta1 = entity.ApartadoAnticipoHasta1 == null ? 0 : entity.ApartadoAnticipoHasta1.Value;
                    apartadoHasta2 = entity.ApatadoAnticipoEnAdelante2 == null ? 0 : entity.ApatadoAnticipoEnAdelante2.Value;
                }

                
                decimal totalMinimoAnticipo = 0;

                foreach (var itemProd in lstProductos)
                {
                    if ((itemProd.precioUnitario - itemProd.montoDescuento)  <= apartadoHasta1)
                    {
                        totalMinimoAnticipo = totalMinimoAnticipo + (anticipo1 * itemProd.cantidad);
                    }
                    if ((itemProd.precioUnitario - itemProd.montoDescuento) >= apartadoHasta2)
                    {
                        totalMinimoAnticipo = totalMinimoAnticipo + (anticipo2 * itemProd.cantidad);
                    }
                }
                
           
            return totalMinimoAnticipo;
        }

        private string validarGuardar()
        {
            int idSucursal = puntoVentaContext.sucursalId;
            cat_configuracion entityConf = oContext.cat_configuracion.FirstOrDefault();
            string error = "";
            decimal minimoAnticipo = calcularMinimoAnticipo();
            if (lstProductos.Count == 0)
            {
                error = "Es necesario agregar productos al apartado\n";
            }
            if (
               uiClienteNombre.Text.Trim()== ""
                )
            {
                error = error+"Es necesario selecccionar un cliente\n";
            }
            if (minimoAnticipo == 0)
            {
                error = error+"No estan configurados los rangos para el anticipo\n";
            }
            if (
                uiAnticipo.Value < minimoAnticipo
                )
            {
                error = error+"El anticipo debe de ser mínimo de:" +minimoAnticipo.ToString() + " \n";
            }

            if (entityConf != null)
            {
                if (
                    (entityConf.ApartadoDiasLiq ?? 0) <= 0
                    ||
                    (entityConf.ApartadoDiasProrroga ?? 0) <= 0
                    )
                {
                    error = error+ "Es necesario configurar los días de vencimiento y prorrogas para los apartados \n";
                }
                
            }
            else {
                error = error+ "Es necesario configurar los días de vencimiento y prorrogas para los apartados \n";
            }

            if (uiAnticipo.Value >= uiTotal.Value)
            {
                error = error+ "No es posible pagar mas que lo que se indica en el saldo \n";
            }

            //if (requiereDigito(int.Parse(uiFormaPago.SelectedValue.ToString())))
            //{
            //    if (uiDigitoVer.Text.Trim() == "")
            //    {
            //        error = error + "El digito verificador es requerido \n";
            //    }
            //}


            return error;

        }

        public bool requiereDigito(int formaPagoId)
        {
            bool requiere = false;
            if (formaPagoId > 0)
            {
                cat_formas_pago entity = oContext.cat_formas_pago.Where(w => w.FormaPagoId == formaPagoId).FirstOrDefault();

                if (entity != null)
                {
                    requiere = entity.RequiereDigVerificador;
                }
            }

            return requiere;
        }

        private void guardar()
        {
            string error = "";
            try
            {
                oContext = new ERPProdEntities();

                using (TransactionScope scope = new TransactionScope())
                {
                    error = validarGuardar();

                    if (error.Length > 0)
                    {
                        MessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int clienteId = 0;
                    int apartadoId = 0;

                    int.TryParse(uiCliente.Text, out clienteId);
                    /*Insertar encabezado*/
                    ObjectParameter pApartadoId = new ObjectParameter("pApartadoId",0);
                    ObjectParameter pApartadoProductoId = new ObjectParameter("pApartadoProductoId", 0);
                    ObjectParameter pApartadoPagoId = new ObjectParameter("pApartadoPagoId", 0);

                    oContext.p_doc_apartados_ins(pApartadoId, puntoVentaContext.sucursalId, clienteId, uiTotal.Value, 0, puntoVentaContext.usuarioId,this.puntoVentaContext.cajaId);

                    apartadoId = int.Parse(pApartadoId.Value.ToString());
                    foreach (var itemProd in lstProductos)
                    {
                        oContext.p_doc_apartados_productos_ins(pApartadoProductoId, apartadoId, itemProd.productoId, itemProd.cantidad, 
                            itemProd.precioUnitario, puntoVentaContext.usuarioId,itemProd.total-itemProd.impuestos,itemProd.impuestos,itemProd.montoDescuento,itemProd.porcDescuento,
                            itemProd.total);
                    }

                    //Insertar anticipo                   
                    foreach (var itemFP in lstFormasPagoAnticipo)
                    {
                        if (itemFP.cantidad > 0)
                        {
                            oContext.p_doc_apartados_pagos_ins(pApartadoPagoId, apartadoId, itemFP.cantidad, DateTime.Now, puntoVentaContext.usuarioId, true, itemFP.id, itemFP.digitoVerificador,this.puntoVentaContext.cajaId);
                        }

                    }

                    //generar movimiento de inventario
                    oContext.p_doc_apartados_mov_inv(apartadoId);                 

                   

                    int apartadoPagoId = int.Parse(pApartadoPagoId.Value.ToString());

                    imprimir(apartadoId, apartadoPagoId);

                    scope.Complete();

                   






                }
                MessageBox.Show("El proceso terminó con éxito", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                frmApartadosList.GetInstance().LlenarGrid();
                this.Close();



            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrió un error al intentar guardar la información","ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void imprimirTicket(int ventaId)
        {
            rptVentaTicket oTicket = new rptVentaTicket();

            ReportViewer oViewer = new ReportViewer();

            oTicket.DataSource = oContext.p_rpt_VentaTicket(ventaId).ToList();

            oViewer.ShowTicket(oTicket);
        }

        public void imprimir(int idApartado, int idPago)
        {
            rptApartadoTicket oTicket = new rptApartadoTicket();

            ReportViewer oViewer = new ReportViewer(this.puntoVentaContext,false);

            oTicket.DataSource = oContext.p_rpt_apartado_ticket(idApartado, idPago).ToList();
            oViewer.copias = 1;
            oViewer.ShowTicket(oTicket);


            oTicket = new rptApartadoTicket();

            oViewer = new ReportViewer(this.puntoVentaContext, false);

            oTicket.DataSource = oContext.p_rpt_apartado_ticket(idApartado, idPago).ToList();
            oViewer.copias = 1;
            oViewer.ShowTicket(oTicket);
            //oViewer.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void llenarForma()
        {
            try
            {
                oContext = new ERPProdEntities();

                doc_apartados entity = oContext.doc_apartados.Where(w => w.ApartadoId == idForm).FirstOrDefault();

                uiFolio.Text = entity.ApartadoId.ToString();
                uiFecha.Value = entity.CreadoEl;
                uiCliente.Text = entity.ClienteId.ToString();
                uiClienteNombre.Text = entity.cat_clientes.Nombre;
                uiSaldo.Value = entity.Saldo;
                decimal anticipo = entity.doc_apartados_pagos.Where(w => w.Anticipo == true).FirstOrDefault().Importe;
               
                uiAnticipo.Value = anticipo;


                lstProductos = new List<ProductoModel0>();
                foreach (var itemProd in entity.doc_apartados_productos)
                {
                    ProductoModel0 producto = new ProductoModel0();

                    producto.productoId = itemProd.ProductoId;
                    producto.cantidad = itemProd.Cantidad;
                    producto.descripcion = itemProd.cat_productos.Descripcion;
                    producto.precioUnitario = itemProd.Precio;
                    producto.total = itemProd.Total;
                    lstProductos.Add(producto);                  
                    
                }

                uiGrid.AutoGenerateColumns = false;
                uiGrid.DataSource = lstProductos;

                calcularTotales();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void uiGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                eliminarProducto();
            }
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
                    ProductoModel0 producto = lstProductos.Where(w => w.partida == partida).FirstOrDefault();
                    lstProductos.Remove(producto);


                    uiGrid.DataSource = lstProductos.ToList();
                    calcularTotales();

                }

            }
        }

        private void uiPagos_Click(object sender, EventArgs e)
        {
            frmApartadosPagos oFormPagos = frmApartadosPagos.GetInstance();
            oFormPagos.id = this.idForm;
            oFormPagos.puntoVentaContext = this.puntoVentaContext;
            oFormPagos.StartPosition = FormStartPosition.CenterScreen;
            oFormPagos.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmClientes oForm = new frmClientes();
            oForm.configurarBotones(true, false, false);
            oForm.ShowDialog();
        }

        private void uiAgregarAnticipo_Click(object sender, EventArgs e)
        {
            frmFormasPagoCaptura oFrm = new frmFormasPagoCaptura();
            oFrm.opcionPV = (int)Enumerados.opcionesPV.apartados;
            oFrm.lstFormasPago = this.lstFormasPagoAnticipo;
            oFrm.ShowDialog();
        }

        public void calcularTotalAnticipo()
        {
            uiAnticipo.Value = lstFormasPagoAnticipo.Sum(s => s.cantidad).Value;
        }

        private void uiGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void uiGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string error = "";
            try
            {
                if (uiGrid.Columns[e.ColumnIndex].Name == "PorcentajeDescuento")
                {

                    decimal porcDescuento = 0;
                    int partida = int.Parse(uiGrid.Rows[e.RowIndex].Cells["partida"].Value.ToString());
                    decimal.TryParse(e.FormattedValue.ToString()
                        , out porcDescuento);

                    uiGrid.Rows[e.RowIndex].Cells["PorcentajeDescuento"].Value = porcDescuento;

                    if (e.FormattedValue.ToString() != porcDescuento.ToString())
                    {
                        error = "El valor del % no es correcto";

                        e.Cancel = true;
                    }


                    calcularDescuento(partida, porcDescuento);




                }

                if (error.Length > 0)
                {
                    MessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }            




            }
            catch (Exception ex)
            {


            }
        }
    }


}
