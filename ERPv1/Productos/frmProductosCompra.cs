using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using ERP.Business;
using ERP.Common;
using ERP.Common.Base;
using ERP.Models.CalculoConta;
using ERP.Reports;
using ERP.Utils;
using ERPv1;
using ERPv1.rpt;
//using PuntoVenta.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace Productos
{
    public partial class frmProductosCompra : FormBaseWinForm
    {
       
        private static frmProductosCompra _instance;
        public bool isEdit = false;
        public decimal iva { get; set; }
        ProductoInterface pI;

        public bool tieneVentaPendiente { get {
                return lstProductos.Count > 0 ? true : false;
            } }
        
        List<ProductoModel0> lstProductos { get; set; }
        ProductoModel0 productoBuscar;
        List<FormaPagoModel> lstFormasPago { get; set; }
        public int clienteId;
        public string nombreCliente;
        ConexionBD.PuntoVenta oData;

        public static frmProductosCompra GetInstance()
        {
            if (_instance == null) _instance = new frmProductosCompra();
            else _instance.BringToFront();
            return _instance;
        }

        #region constructor
        public frmProductosCompra()
        {
            InitializeComponent();
            uiGridProducto.AutoGenerateColumns = false;
            oData = new ConexionBD.PuntoVenta();
            pI = new ProductoInterface();

            //formato columnas
          
            this.uiGridProducto.Columns[4].DefaultCellStyle.Format = "c2";
            this.uiGridProducto.Columns[5].DefaultCellStyle.Format = "c2";
           // this.uiGridProducto.Columns[5].DefaultCellStyle.Format = "c2";
           // this.uiGridProducto.Columns[6].DefaultCellStyle.Format = "c2";
            this.uiGridProducto.Columns[7].DefaultCellStyle.Format = "c2";
            this.uiGridProducto.Columns[9].DefaultCellStyle.Format = "c2";
            this.uiGridProducto.Columns[10].DefaultCellStyle.Format = "c2";

            this.uiGridProducto.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGridProducto.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGridProducto.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGridProducto.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGridProducto.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGridProducto.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.uiGridProducto.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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
            if (e.KeyCode == Keys.F3)
            {
                abrirBuscarProd();

            }
            if (e.KeyCode == Keys.F4)
            {
              //  abrirBuscarCliente();

            }
        }

        private void frmPuntoVenta_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void frmPuntoVenta_Load(object sender, EventArgs e)
        {
            ValidarAcceso(frmMenu.GetInstance().puntoVentaContext.usuarioId,
                frmMenu.GetInstance().puntoVentaContext.sucursalId,
                "frmProductosCompra");
            oContext = new ERPProdEntities();
            lstProductos = new List<ProductoModel0>();

            frmMenu oForm = (frmMenu)this.MdiParent;
            this.puntoVentaContext = oForm.puntoVentaContext;

            obtenerFolioSig();
            uiCodigoProducto.Focus();

            uiSucursal.DataSource = oContext.cat_sucursales.ToList();
            uiSucursal.SelectedValue = frmMenu.GetInstance().puntoVentaContext.sucursalId;

            iva = oContext.cat_impuestos.Where(w => w.Clave == (int)ConexionBD.Enumerados.impuestos.IVA).FirstOrDefault().Porcentaje??0;
            CargarProveedoresFlete();
            CargarProveedoresComisiones();
            Limpiar();

        }
        #endregion

        #region eventos del grid
        private void desglozarPrecio(DataGridViewCellEventArgs e)
        {
            try
            {
                ProductoModel0 entityRow;
                decimal cantidad = 0;
                decimal precioUnitario = 0;
                int partida = 0;
                decimal porcDescuento = 0;
                decimal total = 0;
                decimal precioCompra = 0;



                if (
                   uiGridProducto.Columns[e.ColumnIndex].Name == "Cantidad" ||
                   uiGridProducto.Columns[e.ColumnIndex].Name == "PorcImpuestos" ||
                   uiGridProducto.Columns[e.ColumnIndex].Name == "PrecioCompra"

                   )
                {


                    partida = uiGridProducto.Rows[e.RowIndex].Cells["partida"].Value != null ? int.Parse(uiGridProducto.Rows[e.RowIndex].Cells["partida"].Value.ToString()) : 0;
                    entityRow = lstProductos.Where(w => w.partida == partida).FirstOrDefault();
                    cantidad = uiGridProducto.Rows[e.RowIndex].Cells["Cantidad"].Value != null ? decimal.Parse(uiGridProducto.Rows[e.RowIndex].Cells["Cantidad"].Value.ToString()) : 1;
                    //precioUnitario = uiGridProducto.Rows[e.RowIndex].Cells["precioUnitario"].Value != null ? decimal.Parse(uiGridProducto.Rows[e.RowIndex].Cells["precioUnitario"].Value.ToString()) : 0;
                    precioCompra = uiGridProducto.Rows[e.RowIndex].Cells["precioCompra"].Value != null ? decimal.Parse(uiGridProducto.Rows[e.RowIndex].Cells["precioCompra"].Value.ToString()) : 0;
                    
                    precioUnitario = precioCompra;

                    if(cantidad <=0 || precioCompra<=0 )
                    {
                        
                        XtraMessageBox.Show("La cantidad y precio deben de ser mayores a cero","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        
                        

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

                    porcDescuento = uiGridProducto.Rows[e.RowIndex].Cells["PorcDescuento"].Value != null ? decimal.Parse(uiGridProducto.Rows[e.RowIndex].Cells["PorcDescuento"].Value.ToString()) : 0;

                    entityRow.porcDescunetoVta = 0;
                    entityRow.porcDescuentoPartida = porcDescuento;

                    entityRow = aplicarDctoPartida(entityRow);

                    //Actualizar Fila
                    ActualizarGridModel(e.RowIndex, entityRow);

                    CalcularTotales();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar refrescar la fila", "ERROR");
            }

        }

        private void agregarImpPrecio(DataGridViewCellEventArgs e)
        {
            try
            {
                ProductoModel0 entityRow;
                decimal cantidad = 0;
                decimal precioUnitario = 0;
                int partida = 0;
                decimal porcDescuento = 0;
                decimal porcImpuestos = 0;
                decimal total = 0;
                decimal impuestoPorPord = 0;
                decimal precioNeto=0;
                decimal precioCompra = 0;

                if (uiGridProducto.Columns[e.ColumnIndex].Name == "PrecioCompra")
                {
                    //precioUnitario = uiGridProducto.Rows[e.RowIndex].Cells["precioUnitario"].Value != null ? decimal.Parse(uiGridProducto.Rows[e.RowIndex].Cells["precioUnitario"].Value.ToString()) : 0;
                    precioCompra = uiGridProducto.Rows[e.RowIndex].Cells["precioCompra"].Value != null ? decimal.Parse(uiGridProducto.Rows[e.RowIndex].Cells["precioCompra"].Value.ToString()) : 0;
                    uiGridProducto.Rows[e.RowIndex].Cells["precioNeto"].Value = precioCompra;
                }

                if (
                   uiGridProducto.Columns[e.ColumnIndex].Name == "Cantidad" ||
                   uiGridProducto.Columns[e.ColumnIndex].Name == "PorcImpuestos" ||
                   uiGridProducto.Columns[e.ColumnIndex].Name == "PrecioCompra"

                   )
                {

                    partida = uiGridProducto.Rows[e.RowIndex].Cells["partida"].Value != null ? int.Parse(uiGridProducto.Rows[e.RowIndex].Cells["partida"].Value.ToString()) : 0;
                    entityRow = lstProductos.Where(w => w.partida == partida).FirstOrDefault();
                    cantidad = uiGridProducto.Rows[e.RowIndex].Cells["Cantidad"].Value != null ? decimal.Parse(uiGridProducto.Rows[e.RowIndex].Cells["Cantidad"].Value.ToString()) : 1;
                    //precioUnitario = uiGridProducto.Rows[e.RowIndex].Cells["precioUnitario"].Value != null ? decimal.Parse(uiGridProducto.Rows[e.RowIndex].Cells["precioUnitario"].Value.ToString()) : 0;
                    precioCompra = uiGridProducto.Rows[e.RowIndex].Cells["precioCompra"].Value != null ? decimal.Parse(uiGridProducto.Rows[e.RowIndex].Cells["precioCompra"].Value.ToString()) : 0;
                    porcImpuestos = uiGridProducto.Rows[e.RowIndex].Cells["PorcImpuestos"].Value != null ? decimal.Parse(uiGridProducto.Rows[e.RowIndex].Cells["PorcImpuestos"].Value.ToString()) : 0;
                    precioCompra = uiGridProducto.Rows[e.RowIndex].Cells["precioCompra"].Value != null ? decimal.Parse(uiGridProducto.Rows[e.RowIndex].Cells["precioCompra"].Value.ToString()) : 0;
                    precioNeto = ERP.Utils.CalculosContaTool.DesgloceIVA(precioCompra, porcImpuestos).subtotal; // uiGridProducto.Rows[e.RowIndex].Cells["precioNeto"].Value != null ? decimal.Parse(uiGridProducto.Rows[e.RowIndex].Cells["precioNeto"].Value.ToString()) : 0;


                    impuestoPorPord = ERP.Utils.CalculosContaTool.DesgloceIVA(precioCompra, porcImpuestos).impuestos;
                    precioUnitario = precioNeto + impuestoPorPord;

                    if (cantidad <= 0 || precioCompra <= 0)
                    { 
                      
                    XtraMessageBox.Show("La cantidad y precio deben de ser mayores a cero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        

                    }


                    total = precioUnitario * cantidad;

                    entityRow.precioUnitario = precioUnitario;
                    entityRow.cantidad = cantidad;
                    entityRow.total = total;
                    entityRow.impuestos = cantidad * impuestoPorPord;
                    entityRow.precioNeto = precioNeto;



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

                    porcDescuento = uiGridProducto.Rows[e.RowIndex].Cells["PorcDescuento"].Value != null ? decimal.Parse(uiGridProducto.Rows[e.RowIndex].Cells["PorcDescuento"].Value.ToString()) : 0;

                    entityRow.porcDescunetoVta = 0;
                    entityRow.porcDescuentoPartida = porcDescuento;

                    entityRow = aplicarDctoPartida(entityRow);

                    //Actualizar Fila
                    ActualizarGridModel(e.RowIndex, entityRow);

                    CalcularTotales();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar refrescar la fila", "ERROR");
            }

        }

        private void uiGridProducto_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            
            //if (uiPrecioConIVA.Checked)
            //{
            //    desglozarPrecio(e);
            //}
            //else {
            //    agregarImpPrecio(e);
            //}
           
        }

        private void uiGridProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if(XtraMessageBox.Show("¿Desea eliminarla la fila?","Aviso",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)== DialogResult.Yes)
                {
                    eliminarProducto();
                }
                
            }
        }
        #endregion

        #region metodos
       
        private void abrirBuscarProd()
        {
            frmBuscarProducto f = new frmBuscarProducto();
            f.opcionERP = (int)ConexionBD.Enumerados.opcionesERP.productosCompra;
            f.StartPosition = FormStartPosition.CenterParent;

            f.ShowDialog(this);
        }
        //private void abrirFormasPago()
        //{
        //    if (uiTotal.Value <= 0)
        //    {
        //        MessageBox.Show("No se ha agregado ningun producto");
        //        return;
        //    }
        //    frmVentaFormasPago f = new frmVentaFormasPago();
        //    f.StartPosition = FormStartPosition.CenterParent;
        //    f.totalVenta = uiTotal.Value;
        //    f.ShowDialog(this);
        //}
        private void abrirBuscarProveedor()
        {
            frmBuscarProveedor f = new frmBuscarProveedor();
            f.StartPosition = FormStartPosition.CenterParent;

            f.ShowDialog(this);
        }

        private void abrirBuscarFolio()
        {
            frmBuscarCompra f = new frmBuscarCompra();
            f.StartPosition = FormStartPosition.CenterParent;

            f.ShowDialog(this);
        }
        public void asignarCliente(int clave, string nombre)
        {
            uiProveedorId.Text = clave.ToString();
            uiNombreCliente.Text = nombre;
        }

        public void asignarFolio(int clave)
        {
            uiFolio.Text = clave.ToString();

            buscarCompra(uiFolio.Text);
        }
        public void CalcularTotales()
        {
            uiDescuento.Value = lstProductos.Sum(s => s.montoDescuento);
            uiTotal.Value = lstProductos.Sum(s => s.total);
            uiImpuestos.Value = lstProductos.Sum(s => s.impuestos) ;
            uiImpuestosOtros.Value = uiOtrosCargosImpuestos.Value;
            uiSubTotal.Value = uiTotal.Value  > 0  ? uiTotal.Value - uiImpuestos.Value : 0;

            if(uiFlete.Checked)
            {
                uiTotal.Value = uiTotal.Value + uiFleteTotal.Value;
                uiFleteTotal2.Value = uiFleteTotal.Value;
            }
            else
            {
                uiFleteTotal2.Value = 0;
            }
            if(uiComision.Checked)
            {
                uiTotal.Value = uiTotal.Value + uiComisionTotal.Value;
                uiComisionesTotal2.Value = uiComisionTotal.Value;
            }
            else
            {
                uiComisionesTotal2.Value = 0;
            }

            uiOtrosCargosTotal.Value = uiFleteTotal.Value + uiComisionTotal.Value;
            
        }
        public void AgregarProducto(ProductoModel0 item)
        {

            item.partida = lstProductos.Count > 0 ? lstProductos.Max(M => M.partida) + 1 : 1;
            if ((item.porcDescuentoPartida + item.porcDescunetoVta) > 0)
            {
                aplicarDctoPartida(item);
            }
            item.total = item.cantidad * item.precioUnitario;

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

                oContext = new ERPProdEntities();
               long folio =  oContext.doc_productos_compra.Count() > 0 ? oContext.doc_productos_compra.Max(m => m.ProductoCompraId) + 1 : 1;

                uiFolio.Text = folio.ToString();


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al tratar de obtener el folio siguiente");
            }
        }

        //public void pagar(List<FormaPagoModel> _formasPago,decimal totalRecibido,decimal cambio)
        //{
        //    lstFormasPago = _formasPago;
        //    long ventaId = 0;
        //    int? clienteId = uiProveedorId.Text != "" ? int.Parse(uiProveedorId.Text) : (int?)null;
        //    decimal descuentoPartidas = lstProductos.Sum(s => s.montoDescuento);
        //    string error = "";

        //    error = oData.pagar(ref ventaId, clienteId, uiFolio.Text, uiPorcDescVenta.Value, uiDescuento.Value - descuentoPartidas, descuentoPartidas, uiImpuestos.Value, uiSubTotal.Value, uiTotal.Value,
        //        totalRecibido, cambio, uiDescTodaVenta.Checked, lstProductos, lstFormasPago);

        //    if (error.Length > 0)
        //    {
        //        MessageBox.Show(error, "ERROR");
        //    }
        //    else {
        //        MessageBox.Show("La venta con FOLIO:" + uiFolio.Text + " se ha registrado con éxito");

        //        //rptVentaTicket oTicket = new rptVentaTicket();
        //        //ReportViewer oViewer = new ReportViewer();



        //        //oTicket.DataSource = oContext.p_rpt_VentaTicket(int.Parse(uiFolio.Text)).ToList();


        //        Limpiar();                

        //        //oViewer.ShowTicket(oTicket);
        //        //oViewer.Show();





        //    }


        //}

        public void Limpiar()
        {
            panelCentro.Enabled = true;
            panelInferior.Enabled = true;
            panelSup.Enabled = true;
            uiGridProducto.DataSource = null;
            grCargos.Enabled = true;
            uiProveedorId.Text = "";
            uiFecha.Value = DateTime.Now;
            uiNombreCliente.Text = "";
            uiDescPartida.Checked = false;
            uiDescTodaVenta.Checked = false;
            uiPorcDescVenta.Value = 0;
            uiCodigoProducto.Text = "";
            uiCantidad.Value = 0;
            uiDescripcionProd.Text = "";
            uiPrecioUnitario.Value = 0;
            uiPorcDescPartida.Value = 0;
            uiDescuento.Value = 0;
            uiImpuestos.Value = 0;
            uiSubTotal.Value = 0;
            uiTotal.Value = 0;
            uiRemision.Text = "";
            uiFechaRemision.Value = DateTime.Now;
            uiPrecioConIVA.Enabled = true;
            uiFechaRemision.Enabled = true;
            uiRemision.Enabled = true;
            uiNombreCliente.Text = "";
            uiAfectado.Checked = false;
            uiGrabada.Checked = false;
            uiActivo.Checked = false;

            uiFlete.Checked = false;
            uiFleteFecha.DateTime = DateTime.Now;
            uiFleteTotal.Value = 0;
            uiFleteImpuestos.Value = 0;
            uiFleteProveedor.EditValue = null;
            uiFleteRemision.Text = "";
            uiSubTotal.Value = 0;

            uiImpuestosOtros.Value = 0;
            uiComision.Checked = false;
            uiComisionFecha.DateTime = DateTime.Now;
            uiComisionProveedor.EditValue = null;
            uiComisionRemision.Text = "";
            uiComisionTotal.Value = 0;
            uiComisionImpuestos.Value = 0;
            uiOtrosCargosTotal.Value = 0;
            EnblaDisableComision(false);
            EnblaDisableFlete(false);


            lstFormasPago = new List<FormaPagoModel>();
            lstProductos = new List<ProductoModel0>();

            uiFolio.Enabled = true;
            btnCobrar.Enabled = true;


            isEdit = false;
            uiFolio.Enabled = true;
            btnCobrar.Enabled = true;
            btnActualizarPrecio.Enabled = true;
            uiCancelarCompra.Enabled = false;
            uiImprimir.Enabled = false;
            uiTotal.Value = 0;
            uiSubTotal.Value = 0;
            uiImpuestos.Value = 0;
            obtenerFolioSig();
        }

        private void subirProductoGrid()
        {

            if (uiCantidad.Value != 1)
            {
                productoBuscar.cantidad = uiCantidad.Value;

            }

            int productoId = productoBuscar.productoId;
            var oImpuestos = oContext.cat_productos_impuestos
                .Where(w => w.ProductoId == productoId).FirstOrDefault();

            if(oImpuestos != null && (uiAgregarIVA.Checked || uiPrecioConIVA.Checked))
            {
                productoBuscar.porcImpuestos = oImpuestos.cat_impuestos.Porcentaje??0;
            }

            if (uiAgregarIVA.Checked)
            {
                ImporteDesgloceModel calculImpProd=CalculosContaTool.AgregarImpuesto(uiPrecioUnitario.Value, productoBuscar.porcImpuestos);

                productoBuscar.precioCompra = uiPrecioUnitario.Value;
                productoBuscar.total = (productoBuscar.cantidad * productoBuscar.precioCompra);
                productoBuscar.impuestos = CalculosContaTool.AgregarImpuesto(productoBuscar.total, productoBuscar.porcImpuestos).impuestos;

                productoBuscar.total = productoBuscar.total + productoBuscar.impuestos;
                productoBuscar.precioUnitario = calculImpProd.total;
                productoBuscar.precioNeto = calculImpProd.subtotal;
            }
            else
            {
                if (uiPrecioConIVA.Checked)
                {
                    productoBuscar.precioCompra = uiPrecioUnitario.Value;
                    productoBuscar.total = productoBuscar.cantidad * productoBuscar.precioCompra;
                    productoBuscar.impuestos = productoBuscar.total / (1 + (productoBuscar.porcImpuestos / 100));
                    productoBuscar.impuestos = productoBuscar.total - productoBuscar.impuestos;
                    productoBuscar.precioUnitario = uiPrecioUnitario.Value;
                    productoBuscar.precioNeto = uiPrecioUnitario.Value / (1 + (productoBuscar.porcImpuestos / 100));

                }
                else
                {
                    productoBuscar.precioCompra = uiPrecioUnitario.Value;
                    productoBuscar.total = productoBuscar.cantidad * productoBuscar.precioCompra;
                    productoBuscar.impuestos = 0;
                    productoBuscar.impuestos = 0;
                    productoBuscar.precioUnitario = uiPrecioUnitario.Value;
                    productoBuscar.precioNeto = uiPrecioUnitario.Value;

                }
            }

            //productoBuscar.precioUnitario = uiPrecioUnitario.Value;
           
           

            #region descuentos
            if (uiPorcDescPartida.Value > 0)
            {
                productoBuscar.porcDescuentoPartida = uiPorcDescPartida.Value;
                productoBuscar.porcDescuento = productoBuscar.porcDescunetoVta + productoBuscar.porcDescuentoPartida;               

            }
            #endregion

            if (productoBuscar.precioUnitario <= 0)
            {
                MessageBox.Show("El producto no tiene precio, no es posible agregar","AVISO");
                return;
            }
            if (productoBuscar.cantidad <= 0)
            {
                MessageBox.Show("Falta capturar la cantidad", "AVISO");
                return;
            }
            if (uiProveedorId.Text == "")
            {
                MessageBox.Show("Falta capturar el proveedor", "AVISO");
                return;
            }


            if (productoBuscar.productoId > 0)
            {
               
                AgregarProducto(productoBuscar);
                uiDescripcionProd.Text = "";
                uiPrecioUnitario.Value = 0;
                uiPorcDescPartida.Value = 0;
                uiCantidad.Value = 0;
                uiFotoProducto.Image = null;
                uiCodigoProducto.Text = "";
                uiCodigoProducto.Select();
                uiCodigoProducto.SelectAll();
            }
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
            entity.impuestos = ERP.Utils.CalculosContaTool.DesgloceIVA( entity.total, entity.porcImpuestos).impuestos;

            entity.precioNeto = ERP.Utils.CalculosContaTool.DesgloceIVA(entity.precioUnitario, entity.porcImpuestos).impuestos;
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

        public void buscarCompra(string folio)
        {
            try
            {

                using (TransactionScope scope = new TransactionScope())
                {
                


                    int productoCompraId = int.Parse(folio);
                    oContext = new ERPProdEntities();
                    Limpiar();

                    doc_productos_compra ticket = oContext.doc_productos_compra.Where(w => w.ProductoCompraId == productoCompraId).FirstOrDefault();

                    if (ticket != null)
                    {
                        uiFolio.Enabled = false;
                        uiPrecioConIVA.Checked = false;

                        if (ticket.PrecioAfectado == true || ticket.Activo == false)
                        {
                            panelCentro.Enabled = false;
                            panelInferior.Enabled = false;
                            grCargos.Enabled = false;
                           // panelSup.Enabled = false;
                            uiRemision.Enabled = false;
                            uiFechaRemision.Enabled = false;
                            btnActualizarPrecio.Enabled = false;
                            isEdit = false;

                            if (ticket.Activo == false)
                            {
                                uiCancelarCompra.Enabled = false;
                                uiImprimir.Enabled = false;
                            }
                            else
                            {
                                uiCancelarCompra.Enabled = true;
                                uiImprimir.Enabled = true;
                            }
                        }
                        else
                        {
                            isEdit = true;
                            grCargos.Enabled = true;
                            btnCobrar.Enabled = true;
                            btnActualizarPrecio.Enabled = true;
                            if (ticket.Activo == true)
                            {
                                uiCancelarCompra.Enabled = true;
                                uiImprimir.Enabled = true;
                            }
                            else
                            {
                                uiCancelarCompra.Enabled = false;
                                uiImprimir.Enabled = false;
                            }
                            
                        }

                        lstProductos = ticket.doc_productos_compra_detalle
                            .Select(
                                s => new ProductoModel0()
                                {
                                    cantidad = s.Cantidad,
                                    clave = s.cat_productos.Clave,
                                    descripcion = s.cat_productos.Descripcion +
                                                    " "+
                                                    (s.cat_productos.Talla != null ? s.cat_productos.Talla : ""),
                                    impuestos = s.Impuestos,
                                    montoDescuento = s.Descuentos,
                                    porcDescuento = s.PorcDescuentos,
                                    //partida = s.VentaDetalleId,
                                    porcDescuentoPartida = s.PorcDescuentos,
                                    porcDescunetoVta = s.PorcDescuentos,
                                    precioUnitario = s.PrecioUnitario,
                                    productoId = s.ProductoId,
                                    porcImpuestos = s.PorcImpuestos,
                                    total = s.Total,
                                    precioNeto = s.PrecioNeto ?? 0,
                                    precioCompra = s.PrecioCompra ?? 0
                                }
                            ).ToList();

                        for (int i = 0; i < lstProductos.Count; i++)
                        {
                            lstProductos[i].partida = i + 1;
                        }


                        #region gastos
                        List<doc_productos_compra_cargos> lstCargos = ticket.doc_productos_compra_cargos.ToList();

                        foreach (var itemCargo in lstCargos)
                        {
                            if (itemCargo.ProductoId == (int)ERP.Business.Enumerados.productosSistema.fletes)
                            {
                                uiFlete.Checked = true;
                                uiFleteFecha.DateTime = itemCargo.Fecha;
                                uiFleteProveedor.EditValue = itemCargo.ProveedorId;
                                uiFleteTotal.Value = itemCargo.Total;
                                uiFleteRemision.Text = itemCargo.Remision;
                                uiFleteTotal2.Value = itemCargo.Total;
                            }
                            if (itemCargo.ProductoId == (int)ERP.Business.Enumerados.productosSistema.comisiones)
                            {
                                uiComision.Checked = true;
                                uiComisionFecha.DateTime = itemCargo.Fecha;
                                uiComisionProveedor.EditValue = itemCargo.ProveedorId;
                                uiComisionTotal.Value = itemCargo.Total;
                                uiComisionRemision.Text = itemCargo.Remision;
                                uiComisionesTotal2.Value = itemCargo.Total;
                            }
                        }

                        #endregion



                        uiGridProducto.DataSource = lstProductos;

                        uiProveedorId.Text = ticket.ProveedorId != null ? ticket.ProveedorId.ToString() : "";
                        uiFecha.Value = ticket.FechaRegistro;
                        uiFolio.Text = ticket.ProductoCompraId.ToString();
                        uiDescuento.Value = ticket.Descuento;
                        uiSubTotal.Value = ticket.Subtotal;
                        uiImpuestos.Value = ticket.Impuestos;
                        uiTotal.Value = ticket.Total;
                        uiProductoCompraId.Value = ticket.ProductoCompraId;
                        uiActivo.Checked = !ticket.Activo;
                        uiRemision.Text = ticket.NumeroRemision;
                        uiPrecioConIVA.Checked = ticket.PrecioConImpuestos ?? false;
                        uiNombreCliente.Text = ticket.cat_proveedores.Nombre;
                        uiGrabada.Checked = ticket != null ? true : false;
                        uiAfectado.Checked = ticket.PrecioAfectado ?? false;
                        uiSucursal.SelectedValue = ticket.SucursalId ;
                        if (ticket.FechaRemision == null)
                        {
                            uiFechaRemision.Text = "";
                        }
                        else
                        {
                            uiFechaRemision.Value = ticket.FechaRemision ?? DateTime.MinValue;
                        }



                    }
                else
                {
                    isEdit = false;
                }

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al buscar la compra", "ERROR");
            }
            
        }

        public void Cancelar()
        {
            try
            {
                oContext = new ERPProdEntities();
                int ventaId = 0;

                int.TryParse(uiProductoCompraId.Value.ToString(), out ventaId);

                doc_ventas entityVenta = oContext.doc_ventas.Where(w => w.VentaId == ventaId).FirstOrDefault();

                if (entityVenta != null)
                {
                    if (MessageBox.Show("¿Está seguro de cancelar el ticket con folio:" + entityVenta.Folio, "AVISO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        oContext.p_doc_ventas_cancelacion(ventaId, puntoVentaContext.usuarioId,"Cancelación Productos de Compra");

                        MessageBox.Show("El ticket con folio:"+ entityVenta.Folio + " ha sido cancelado", "AVISO");
                    }

                }
                else {
                    MessageBox.Show("Es necesario primero buscar el ticket a cancelar", "ERROR");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        public bool guardar(bool guardarYAfectar)
        {
            //string error = "";
            //using (TransactionScope scope = new TransactionScope())
            //{

            //    error = validarGuardar();

            //    if (error.Length > 0)
            //    {
            //        MessageBox.Show(error, "ERROR");
            //        return;
            //    }



            //    scope.Complete();
            //}

            try
            {
                string error = "";

                error = validarGuardar();

                if (error.Length > 0)
                {
                    MessageBox.Show(error, "ERROR");
                    return false;
                }
                int proveedorId = 0;
                proveedorId = int.Parse(uiProveedorId.Text);

                ObjectParameter pProductoCompraId = new ObjectParameter("pProductoCompraId", 0);
                pProductoCompraId.Value = int.Parse(uiProductoCompraId.Value.ToString());
                int sucursalId = 0;

                sucursalId = uiSucursal.SelectedValue == null ? 0 : int.Parse(uiSucursal.SelectedValue.ToString());
                int? fleteProveedorId = uiFleteProveedor.EditValue == null ? 0 : Convert.ToInt32(uiFleteProveedor.EditValue);
                int? comisionProveedorId = uiComisionProveedor.EditValue == null ? 0 : Convert.ToInt32(uiComisionProveedor.EditValue);

                if (isEdit)
                {


                    ObjectParameter pError = new ObjectParameter("pError", "");
                    oContext.p_doc_productos_compra_upd(pProductoCompraId, proveedorId, sucursalId, DateTime.Now, uiRemision.Text, uiFechaRemision.Value,
                    uiDescuento.Value, uiSubTotal.Value, uiImpuestos.Value, uiTotal.Value, 1, uiFlete.Checked, uiFleteFecha.DateTime,
                    uiFleteRemision.Text, uiFleteTotal.Value, fleteProveedorId, uiComision.Checked, uiComisionFecha.DateTime,
                    uiComisionRemision.Text, uiComisionTotal.Value,
                    comisionProveedorId, pError);

                    if (pError.Value.ToString().Length > 0)
                    {
                        MessageBox.Show(pError.Value.ToString(), "ERROR");
                        return false;
                    }



                    int ProductoCompraIdint = int.Parse(pProductoCompraId.Value.ToString());

                    List<doc_productos_compra_detalle> lstProductoCompra = oContext.doc_productos_compra_detalle.Where(w => w.ProductoCompraId == ProductoCompraIdint).ToList();

                    foreach (doc_productos_compra_detalle itemDelete in lstProductoCompra)
                    {
                        oContext.doc_productos_compra_detalle.Remove(itemDelete);
                    }
                    oContext.SaveChanges();

                    oContext = new ERPProdEntities();

                    foreach (ProductoModel0 itemProducto in lstProductos)
                    {

                        oContext.p_doc_productos_compra_detalle_ins(0, int.Parse(pProductoCompraId.Value.ToString()), itemProducto.productoId, itemProducto.cantidad,
                            itemProducto.precioUnitario, itemProducto.porcImpuestos, itemProducto.impuestos, itemProducto.porcDescuento, itemProducto.montoDescuento, itemProducto.total - itemProducto.impuestos, itemProducto.total, 1, itemProducto.precioNeto, itemProducto.precioCompra);
                    }

                    oContext.SaveChanges();
                }
                else
                { 
                    ObjectParameter pError = new ObjectParameter("pError", "");
                    oContext.p_doc_productos_compra_ins(pProductoCompraId, proveedorId,sucursalId, DateTime.Now, uiRemision.Text, uiFechaRemision.Value,
                   uiDescuento.Value, uiSubTotal.Value, uiImpuestos.Value, uiTotal.Value, 1, uiPrecioConIVA.Checked,
                   uiFlete.Checked, uiFleteFecha.DateTime,uiFleteRemision.Text,
                   uiFleteTotal.Value,fleteProveedorId,uiComision.Checked,uiComisionFecha.DateTime,uiComisionRemision.Text,
                   uiComisionTotal.Value,comisionProveedorId, pError);

                    if(pError.Value.ToString().Length > 0)
                    {
                        MessageBox.Show(pError.Value.ToString(), "ERROR");
                        return false;
                    }

                    foreach (ProductoModel0 itemProducto in lstProductos)
                    {

                        oContext.p_doc_productos_compra_detalle_ins(0, int.Parse(pProductoCompraId.Value.ToString()), itemProducto.productoId, itemProducto.cantidad,
                            itemProducto.precioUnitario, itemProducto.porcImpuestos, itemProducto.impuestos, itemProducto.porcDescuento, itemProducto.montoDescuento, itemProducto.total - itemProducto.impuestos, itemProducto.total, 1, itemProducto.precioNeto, itemProducto.precioCompra);
                    }
                }

                MessageBox.Show("La compra se registró con éxito");

                if(!guardarYAfectar)
                {
                    Limpiar();
                }
                

                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
                return false;
            }
        }

        public string validarGuardar()
        {
            string error="";
            if (uiProveedorId.Text.Trim() == "")
            {
                error = "El proveedor es requerido";
            }
            if (uiRemision.Text.Trim() == "")
            {
                error = "La remisión es requerida";
            }
            if (lstProductos.Count <= 0)
            {
                error = error+ "|No hay productos agregados";
            }
            if(
                lstProductos.Where(w=> w.cantidad <= 0).Count() > 0 ||
                lstProductos.Where(w => w.precioCompra <= 0).Count() > 0
                )
            {
                error = error + "|No se pueden guardar productos en precio/cantidad en cero";
            }
            

            if(uiFlete.Checked)
            {
                if(uiFleteFecha.DateTime == null || uiFleteProveedor.EditValue == null || uiFleteRemision.Text.Trim() == ""
                    || uiFleteTotal.Value <= 0)
                {
                    error = error + "|Es necesario completar la información de gastos de fletes";
                }
            }

            if(uiComision.Checked)
            {
                if(uiComisionFecha.DateTime == null || uiComisionProveedor.EditValue ==null || uiComisionRemision.Text.Trim() == ""
                    || uiComisionTotal.Value <=0
                    )
                {
                    error = error + "|Es necesario completar la información de comisiones";
                }
            }
            return error;

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
            buscarProductos();
        }

        private void buscarProductos()
        {
            oContext = new ERPProdEntities();

            productoBuscar = new ProductoModel0();

            uiDescripcionProd.Text = "";
            uiPrecioUnitario.Value = 0;

            var result = oContext.p_BuscarProductos(uiCodigoProducto.Text, true,0,false).FirstOrDefault();

            if (result != null)
            {
                productoBuscar = new ProductoModel0()
                {
                    cantidad = 1,
                    clave = result.Clave.ToString(),
                    descripcion = result.Descripcion,
                    impuestos = result.impuestos ?? 0,
                    precioUnitario = 0,/* result.Precio,*/
                    productoId = result.ID,
                    porcImpuestos = 0,
                    total = 0
                };

                if (result.Foto != null)
                {
                    using (var ms = new MemoryStream(result.Foto))
                    {
                        uiFotoProducto.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    uiFotoProducto.Image = null;
                }


                uiDescripcionProd.Text = productoBuscar.descripcion;
                uiPrecioUnitario.Value = productoBuscar.precioUnitario;


            }
        }

        private void uiBuscarCliente_Click(object sender, EventArgs e)
        {
           // abrirBuscarCliente();

        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            //Asegurarse que haya registros en el grid
            if (lstProductos.Count <= 0)
            {
                MessageBox.Show("No hay productos para procesar", "ERROR");
                return;
            }

            guardar(false);         

        }

        private void uiCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                subirProductoGrid();
            }
            uiTotalPartida.Value = uiCantidad.Value * uiPrecioUnitario.Value;
        }

        private void uiCantidad_ValueChanged(object sender, EventArgs e)
        {

        }

        private void uiPrecioUnitario_ValueChanged(object sender, EventArgs e)
        {
            uiTotalPartida.Value = uiCantidad.Value * uiPrecioUnitario.Value;
        }

        private void uiCantidad_Validating(object sender, CancelEventArgs e)
        {

        }

        private void uiCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

       

        private void uiCodigoProducto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
            abrirBuscarProveedor();
        }

        private void uiPrecioUnitario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                subirProductoGrid();
            }
            uiTotalPartida.Value = uiCantidad.Value * uiPrecioUnitario.Value;
        }

        private void uiFolio_Validated(object sender, EventArgs e)
        {
            buscarCompra(uiFolio.Text);
        }

        
        private void btnActualizarPrecio_Click(object sender, EventArgs e)
        {
           

        }

        private void btnActualizarPrecio_Click_1(object sender, EventArgs e)
        {
            try
            {
                bool error = false;
                bool imprimirSiNO = false;
                if (uiActivo.Checked == true)
                {
                    return;
                }

                //Asegurarse que haya registros en el grid
                if (lstProductos.Count <= 0)
                {
                    MessageBox.Show("No hay productos para procesar","ERROR");
                    return;
                }

                if (MessageBox.Show("¿Está seguro de continuar?, se afectará la lista de precios y el inventario de estos productos", "AVISO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                   

                    using (TransactionScope scope = new TransactionScope())
                    {


                        if (guardar(true))
                        {

                            oContext = new ERPProdEntities();

                            uiProductoCompraId.Value = int.Parse(uiFolio.Text);

                            ObjectParameter pError = new ObjectParameter("pError", "");
                            int productoCompraId = int.Parse(uiProductoCompraId.Value.ToString());
                            oContext.p_Actualizar_CompraListaPrecios(productoCompraId,0, 1, pError);

                            if (pError.Value.ToString().Length > 0)
                            {
                                error = true;
                                MessageBox.Show(pError.Value.ToString(), "ERROR");
                                return;
                            }
                            else
                            {
                                oContext.p_productos_compra_inv(productoCompraId,puntoVentaContext.sucursalId,puntoVentaContext.usuarioId);
                                
                                scope.Complete();
                                imprimirSiNO = true;
                                


                            }

                            //oContext.p_productos_compra_inv(productoCompraId, 1);
                            //scope.Complete();
                            //MessageBox.Show("El cambio de precios se ha realizado", "AVISO");
                        }
                        else
                        {
                            error = true;
                        }

                    }

                    if (!error)
                    {
                        MessageBox.Show("El cambio de precios se ha realizado", "AVISO");
                        if (imprimirSiNO)
                        {
                            imprimir();
                        }
                        Limpiar();
                    }



                }

                


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void uiLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void uiPrecioConIVA_Validated(object sender, EventArgs e)
        {

        }

        private void uiPrecioConIVA_Validating(object sender, CancelEventArgs e)
        {

        }

        private void uiGridProducto_DataSourceChanged(object sender, EventArgs e)
        {
            if (lstProductos.Count > 0)
            {
                uiPrecioConIVA.Enabled = false;
            }
            else {
                uiPrecioConIVA.Enabled = true;
            }
        }

        private void uiBuscarFolio_Click(object sender, EventArgs e)
        {
            abrirBuscarFolio();
        }

        private void uiCancelarCompra_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("¿Está seguro de continuar?", "AVISO", MessageBoxButtons.YesNo) == DialogResult.Yes
                )
            {
                try
                {
                    oContext.p_doc_productos_compra_cancelar(int.Parse(uiProductoCompraId.Value.ToString()), 1);

                    ERP.Common.ReportesBusiness.imprimirMovInventarioCancelacion(0, int.Parse(uiProductoCompraId.Value.ToString()));

                    Limpiar();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message,"ERROR");
                }
            }
        }

        public void buscarProductoF3(string claveProd)
        {
            uiCodigoProducto.Text = claveProd;
            buscarProductos();
            uiCantidad.Select();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void uiRemision_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiImprimir_Click(object sender, EventArgs e)
        {
            imprimir();
        }

        private void imprimir()
        {
            try
            {
                int folioCompra = 0;
               
                int.TryParse(uiFolio.Text, out folioCompra);
                oContext = new ERPProdEntities();
                doc_inv_movimiento entity = oContext.doc_inv_movimiento.Where(w => w.ProductoCompraId == folioCompra).FirstOrDefault();

                if (entity != null)
                {
                    if (entity.Cancelado ?? false)
                    {
                        ERP.Common.ReportesBusiness.imprimirMovInventarioCancelacion(entity.MovimientoId, 0);
                    }
                    else
                    {
                        rptEntradaCompra_Carta oTicket = new rptEntradaCompra_Carta();
                        ERP.Common.Reports.ReportViewer oViewer = new ERP.Common.Reports.ReportViewer();
                        var ds = oContext.p_inv_movimiento_rpt(entity.MovimientoId).ToList();
                        oTicket.DataSource = ds;
                        oTicket.autorizadoPor = ds.FirstOrDefault().AutorizadoPor;
                        oViewer.ShowPreview(oTicket);
                    }

                }
            }
            catch (Exception ex)
            {

                ERP.Utils.MessageBoxUtil.ShowError("Ocurrió un error al imprimir");
            }
            

            
        }

        private void uiFlete_CheckedChanged(object sender, EventArgs e)
        {
            EnblaDisableFlete(uiFlete.Checked);
            CalcularTotales();
        }

        private void EnblaDisableFlete(bool enable)
        {
            //uiFlete.Enabled = enable;
            uiFleteFecha.Enabled = enable;
            uiFleteRemision.Enabled = enable;
            uiFleteTotal.Enabled = enable;
            uiFleteProveedor.Enabled = enable;
        }
        private void EnblaDisableComision(bool enable)
        {
            //uiComision.Enabled = enable;
            uiComisionFecha.Enabled = enable;
            uiComisionRemision.Enabled = enable;
            uiComisionTotal.Enabled = enable;
            uiComisionProveedor.Enabled = enable;
        }

        private void CargarProveedoresFlete()
        {
            try
            {
                uiFleteProveedor.Properties.DataSource = oContext.cat_proveedores.ToList();
            }
            catch (Exception ex)
            {

                
            }
        }

        private void CargarProveedoresComisiones()
        {
            try
            {
                uiComisionProveedor.Properties.DataSource = oContext.cat_proveedores.ToList();
            }
            catch (Exception ex)
            {


            }
        }

        private void uiComision_CheckedChanged(object sender, EventArgs e)
        {
            EnblaDisableComision(uiComision.Checked);
             CalcularTotales();
        }

        private void uiGridProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void uiFleteTotal_Leave(object sender, EventArgs e)
        {
            //CalcularTotales();
        }

        private void uiComisionTotal_Leave(object sender, EventArgs e)
        {
           // CalcularTotales();
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void uiOtrosCargosTotal_EditValueChanged(object sender, EventArgs e)
        {
            uiTotalOtros.Value = uiOtrosCargosTotal.Value - uiOtrosCargosImpuestos.Value;
        }

        private void uiFleteTotal_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                
                uiFleteImpuestos.Value = ERP.Utils.CalculosContaTool.DesgloceIVA(uiFleteTotal.Value, iva).impuestos; 
                uiOtrosCargosImpuestos.Value = uiFleteImpuestos.Value + uiComisionImpuestos.Value;
                CalcularTotales();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uiComisionTotal_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                uiComisionImpuestos.Value = ERP.Utils.CalculosContaTool.DesgloceIVA(uiComisionTotal.Value ,iva).impuestos;
                uiOtrosCargosImpuestos.Value = uiFleteImpuestos.Value + uiComisionImpuestos.Value;
                CalcularTotales();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uiGridProducto_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }

        private void uiGridProducto_Validating(object sender, CancelEventArgs e)
        {
            //if (
            //       uiGridProducto.Columns[e.ColumnIndex].Name == "Cantidad" ||
            //       uiGridProducto.Columns[e.ColumnIndex].Name == "PorcImpuestos" ||
            //       uiGridProducto.Columns[e.ColumnIndex].Name == "PrecioCompra"

            //       )
            //{
            //    decimal cantidad = uiGridProducto.Rows[e.RowIndex].Cells["Cantidad"].Value != null ? decimal.Parse(uiGridProducto.Rows[e.RowIndex].Cells["Cantidad"].Value.ToString()) : 1;
            //    decimal precioCompra = uiGridProducto.Rows[e.RowIndex].Cells["precioCompra"].Value != null ? decimal.Parse(uiGridProducto.Rows[e.RowIndex].Cells["precioCompra"].Value.ToString()) : 0;

            //    if (cantidad <= 0 || precioCompra <= 0)
            //    {
            //        XtraMessageBox.Show("La cantidad y precio deben de ser mayores a cero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        e.Cancel = true;

            //    }


            //}
        }

        private void uiPrecioConIVA_CheckedChanged(object sender, EventArgs e)
        {
            if (uiPrecioConIVA.Checked)
            {
                uiAgregarIVA.Enabled = false;
                uiAgregarIVA.Checked = false;
            }
            else
            {
                uiAgregarIVA.Enabled = true;
                uiAgregarIVA.Checked = false;
            }
        }
    }
}
