using ConexionBD.Utilerias;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConexionBD.Utilerias;
using ConexionBD;
using System.Drawing.Imaging;
using System.Data.Entity.Core.Objects;
using static ConexionBD.Enumerados;
using System.Transactions;
using ConexionBD.Models;
using ERP.Common.Produccion;

namespace ERP.Common.Catalogos
{
    public partial class frmPoductosEdit : Form
    {
        int productoImagenId = 0;
        public PuntoVentaContext puntoVentaContext;
        ProductoInterface pI;
        UnidadesMedidaInterface umI;
        MarcasInterface mI;
        FamiliasInterface fI;
        SubFamiliasInterface sfI;
        LineasInterface lI;
        ERPProdEntities oContext;
        public int productoId = 0;
        public bool esNuevo { get; set; }

        Resultado resultado;

        public frmPoductosEdit()
        {
            pI = new ProductoInterface();
            umI = new UnidadesMedidaInterface();
            mI = new MarcasInterface();
            fI = new FamiliasInterface();
            sfI = new SubFamiliasInterface();
            lI = new LineasInterface();
            oContext = new ERPProdEntities();
            InitializeComponent();
        }

        #region eventos de la forma
        private void frmPoductos_Load(object sender, EventArgs e)
        {
            InitializeOpenFileDialog();
            
            CargarComboBox(ref cmbUnidadMedida, false, "Clave", "Descripcion", umI.ConsultaComboBox());
            CargarComboBox(ref cmbMarca, false, "Clave", "Descripcion", mI.ConsultaComboBox());
            CargarComboBox(ref uiFamilia, false, "Clave", "Descripcion", fI.ConsultaComboBox());
            CargarComboBox(ref uiSubfamilia, false, "Clave", "Descripcion", sfI.ConsultaComboBox());
            CargarComboBox(ref uiLinea, false, "Clave", "Descripcion", lI.ConsultaComboBox());
            CargarComboBox(ref cmbInvetariadoPor, false, "Clave", "Descripcion", umI.ConsultaComboBox());
            CargarComboBox(ref cmbVendidoPor, false, "Clave", "Descripcion", umI.ConsultaComboBox());
            LlenarCombos();
            //obtenerPorcentajeUtilidadConfig();
            uiSucursal.SelectedValue = this.puntoVentaContext.sucursalId;
            LimpiarControles();

            if(productoId > 0)
            {
                BuscarRegistro(productoId, "");
            }

            Buscar();
        }
        #endregion

        #region Metodos
        //private void obtenerPorcentajeUtilidadConfig()
        //{
        //    oContext = new ERPEntities();

        //    var config = oContext.cat_configuracion.FirstOrDefault();

        //    if (config != null)
        //    {
        //        uiIncUtilidadPorc.Value = config.PorcentajeUtilidadProd ?? 0;
        //        CalcularPrecioVenta();
        //    }
        //}
        private void CargarGridPrecios()
        {
            oContext = new ERPProdEntities();
            uiPrecios.AutoGenerateColumns = false;
            uiPrecios.DataSource = oContext.p_productos_precio_grd(int.Parse(nProductoId.Value.ToString()));
        }

        public void CargarImpuestos()
        {
            oContext = new ERPProdEntities();

            try
            {
                uiProductosImpuesto.AutoGenerateColumns = false;
                int productoId = (int)nProductoId.Value;

                uiProductosImpuesto.DataSource = oContext.cat_productos_impuestos
                    .Where(w => w.ProductoId == productoId)
                    .Select(
                        s => new {
                            ID = s.ProductoImpuestoId,
                            DescripcionImpuesto = s.cat_impuestos.Descripcion,
                            Porcentaje = s.cat_impuestos.Porcentaje,

                            Eliminar = "Eliminar"
                        }
                    )
                    .ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al obtener los impuestos", "ERROR");
            }


        }

        private void Buscar()
        {
           
        }


        private void SetEnableTAB(TabPage tp,bool enable)
        {
            foreach (Control ctl in tp.Controls) ctl.Enabled = enable;


            uiExistencia.Enabled = false;
            uiCostoUCompra.Enabled = false;
            uiCostoPromedio.Enabled = false;
            uiValuadoUtimaCom.Enabled = false;
            uiValuadoCostoProm.Enabled = false;

        }
        private void LimpiarControles()
        {
            uiImagenDetalle.Image = null;
            productoImagenId = 0;
            uiImagenPrincipal.Enabled = false;
            uiGridImagenes.DataSource = null;

            SetEnableTAB(tpPrecioImp, false);
            SetEnableTAB(tpImpuestos, false);
            SetEnableTAB(tpExistencias, false);
            txtClave.Enabled = true;
            txtClave.Text = "";
            txtNomProducto.Text = "";
            txtDescCorta.Text = "";
            cmbUnidadMedida.SelectedIndex = 0;
            cmbMarca.SelectedIndex = 0;
            uiFamilia.SelectedIndex = 0;
            uiSubfamilia.SelectedIndex = 0;
            uiLinea.SelectedIndex = 0;
            cmbInvetariadoPor.SelectedIndex = 0;
            cmbVendidoPor.SelectedIndex = 0;
            nDecimales.Value = 0;
            nDescEmp.Value = 0;
            nConXCaja.Value = 0;
            pbFoto.Image = null;
            uiImagenDetalle.Image = null;
            chkEstatusProducto.Checked = true;
            chkProductoTerminado.Checked = true;
            chkInventariable.Checked = true;
            chkMateriaPrima.Checked = false;
            chkProdParaVenta.Checked = true;
            chkProdVtaBascula.Checked = false;
            chkSeriado.Checked = false;
            chkEstatusProducto.Checked = true;
            uiAlmacen.SelectedValue = 0;
            uiAnden.SelectedValue = 0;
            uiLote.SelectedValue = 0;
            uiFechaCad.Text = "";
            uiMinimo.Value = 0;
            uiMaximo.Value = 0;
            nProductoId.Value = 0;
            uiPrecios.DataSource = null;
            uiTalla.Text = "";
            uiColor.Text = "";
            uiColor2.Text = "";
            uiEspecificaciones.Text = "";

            /********PRECIOS***********/
            uiCtoSinIVA.Value = 0;
            uiImpuestos.Value = 0;
            uiCtoNeto.Value = 0;
            uiIncUtilidadPorc.Value = 0;
            uiIncUtilidadPesos.Value = 0;
            uiEstablecerPrecio.Value = 0;
            uiPrecioVenta.Value = 0;
            uiSobrePedido.Checked = false;  
          

           // obtenerPorcentajeUtilidadConfig();

            CargarGridPrecios();

        }

        private void LlenarCombos()
        {
            var ds = oContext.cat_almacenes.ToList();
            ds.Add(new cat_almacenes() { Clave = 0, Descripcion = "(SELECCIONAR)" });
            uiAlmacen.DataSource = ds;
            uiAlmacen.SelectedValue = 0;


            var ds1 = oContext.cat_andenes.ToList();
            ds1.Add(new cat_andenes() { Clave = 0, Descripcion = "(SELECCIONAR)" });
            uiAnden.DataSource = oContext.cat_andenes.ToList();
            uiAnden.SelectedValue = 0;

            var ds2 = oContext.cat_lotes.ToList();
            ds2.Add(new cat_lotes() { Clave = 0, Descripcion = "(SELECCIONAR)" });            
            uiLote.DataSource = ds2;
            uiLote.SelectedValue = 0;

            var ds3 = oContext.cat_impuestos.ToList();
            ds3.Add(new cat_impuestos() { Clave = 0, Descripcion = "(SELECCIONAR)" });
            uiImpuestoCMB.ValueMember = "Clave";
            uiImpuestoCMB.DataSource = ds3;
            uiImpuestoCMB.SelectedValue = 0;


            uiSucursal.DataSource = oContext.cat_sucursales.ToList();
            

        }

        private void buscarExistencias()
        {
            try
            {
                int productoid = int.Parse(nProductoId.Value.ToString());
                int sucursalId = int.Parse(uiSucursal.SelectedValue.ToString());
                cat_productos_existencias entity = oContext.cat_productos_existencias
                    .Where(
                        w => w.ProductoId == productoid &&
                        w.SucursalId == sucursalId
                    ).FirstOrDefault();

                if (entity != null)
                {
                    uiExistencia.Value = entity.ExistenciaTeorica??0;
                    uiCostoUCompra.Value = entity.CostoUltimaCompra;
                    uiCostoPromedio.Value = entity.CostoPromedio;
                    uiValuadoUtimaCom.Value = entity.ValCostoUltimaCompra;
                    uiValuadoCostoProm.Value = entity.ValCostoPromedio;
                }
                else {
                    uiExistencia.Value = 0;
                    uiCostoUCompra.Value = 0;
                    uiCostoPromedio.Value = 0;
                    uiValuadoUtimaCom.Value = 0;
                    uiValuadoCostoProm.Value = 0;
                }

                uiExistencia.Enabled = false;
                uiCostoUCompra.Enabled = false;
                uiCostoPromedio.Enabled = false;
                uiValuadoUtimaCom.Enabled = false;
                uiValuadoCostoProm.Enabled = false;

            }
            catch (Exception ex)
            {

                
            }
        }

        private Resultado ValidarAgregar(string clave, string nomProducto, int unidadMedida, int? inventariadoPor,int familia,int subfamilia,
            int linea,int marca,decimal minimoInventario,decimal maximoInventario)
        {
            resultado = new Resultado();


            if (
                    oContext.cat_productos.Where(w => w.Clave.ToString() == clave).Count() > 0
                )

            {
                resultado.mensaje += "La clave ya existe, no es posible continuar. \n";
                resultado.ok = false;

            }
            if (clave == "")
            {
                resultado.mensaje += "Capture la Clave. \n";
                resultado.ok = false;
            }
            if (nomProducto == "")
            {
                resultado.mensaje += "Capture el nombre del Producto. \n";
                resultado.ok = false;
            }
            if (unidadMedida == null || unidadMedida == 0)
            {
                resultado.mensaje += "Selecione La Unidad de Medida. \n";
                resultado.ok = false;
            }
            if (inventariadoPor == null || inventariadoPor == 0)
            {
                resultado.mensaje += "Selecione el Tipo de Inventariado. \n";
                resultado.ok = false;
            }
            if (familia == 0)
            {
                resultado.mensaje += "Seleccione una familia. \n";
                resultado.ok = false;
            }
            if (subfamilia == 0)
            {
                resultado.mensaje += "Seleccione una Sub-familia. \n";
                resultado.ok = false;
            }
            if (linea == 0)
            {
                resultado.mensaje += "Seleccione una Línea. \n";
                resultado.ok = false;
            }
            if (marca == 0)
            {
                resultado.mensaje += "Seleccione una Marca. \n";
                resultado.ok = false;
            }
            if (minimoInventario > maximoInventario)
            {
                resultado.mensaje += "El mínimo de inventario no puede ser mayor al máximo \n";
                resultado.ok = false;
            }
            return resultado;
        }

        private Resultado ValidarEditar(string clave, string nomProducto, int unidadMedida, int inventariadoPor,decimal minimoInventario,
            decimal maximoInventario,int marca,int subFamilia)
        {
            resultado = new Resultado();
            if (clave == "")
            {
                resultado.mensaje += "Capture la Clave. \n";
                resultado.ok = false;
            }
            if (nomProducto == "")
            {
                resultado.mensaje += "Capture el nombre del Producto. \n";
                resultado.ok = false;
            }
            if (unidadMedida == null || unidadMedida == 0)
            {
                resultado.mensaje += "Selecione La Unidad de Medida. \n";
                resultado.ok = false;
            }
            if (inventariadoPor == null || inventariadoPor == 0)
            {
                resultado.mensaje += "Selecione el Tipo de Inventariado. \n";
                resultado.ok = false;
            }
            if (minimoInventario > maximoInventario)
            {
                resultado.mensaje += "El mínimo de inventario no puede ser mayor al máximo \n";
                resultado.ok = false;
            }
            if (marca == 0)
            {
                resultado.mensaje += "La marca es requerida \n";
                resultado.ok = false;
            }
            if (subFamilia == 0)
            {
                resultado.mensaje += "La subfamilia es requerida \n";
                resultado.ok = false;
            }
            return resultado;
        }

        private Resultado ValidarEliminar(int personaId)
        {
            resultado = new Resultado();
            DataTable dt = pI.ConsultarRegistro(personaId, false);
            if (personaId <= 0)
            {
                resultado.mensaje += "La clave debe ser mayor a cero. \n";
                resultado.ok = false;
            }
            if (personaId > 0 && (dt == null || dt.Rows.Count <= 0))
            {
                resultado.mensaje += "El registros seleccionado no existe. \n";
                resultado.ok = false;
            }
            return resultado;
        }

        private void Insertar()
        {
            resultado = new Resultado();
            int productoid = 0;
            string clave = txtClave.Text;
            string nomProducto = txtNomProducto.Text;
            string nomDescCorta = txtDescCorta.Text;
            int unidadMedida = 0;
            if (cmbUnidadMedida != null && cmbUnidadMedida.SelectedItem != null)
                unidadMedida = int.Parse(((ComboBoxItem)cmbUnidadMedida.SelectedItem).valor.ToString());
            int marca = 0;
            if (cmbMarca != null && cmbMarca.SelectedItem != null)
                marca = int.Parse(((ComboBoxItem)cmbMarca.SelectedItem).valor.ToString());
            int familia = 0;
            if (uiFamilia != null && uiFamilia.SelectedItem != null)
                familia = int.Parse(((ComboBoxItem)uiFamilia.SelectedItem).valor.ToString());
            int subFamilia = 0;
            if (uiSubfamilia != null && uiSubfamilia.SelectedItem != null)
                subFamilia = int.Parse(((ComboBoxItem)uiSubfamilia.SelectedItem).valor.ToString());
            int linea = 0;
            if (uiLinea != null && uiLinea.SelectedItem != null)
                linea = int.Parse(((ComboBoxItem)uiLinea.SelectedItem).valor.ToString());
            int? inventariadoPor = 0;
            if (cmbInvetariadoPor != null && cmbInvetariadoPor.SelectedItem != null)
                inventariadoPor = int.Parse(((ComboBoxItem)cmbInvetariadoPor.SelectedItem).valor.ToString());
            int sVendePor = 0;
            if (cmbVendidoPor != null && cmbVendidoPor.SelectedItem != null)
                sVendePor = int.Parse(((ComboBoxItem)cmbVendidoPor.SelectedItem).valor.ToString());
            bool estatus = chkEstatusProducto.Checked ? true : false;
            bool productoTerminado = chkProductoTerminado.Checked ? true : false;
            bool inventariable = chkInventariable.Checked ? true : false;
            bool materiaPrima = chkMateriaPrima.Checked ? true : false;
            bool productoParaVenta = chkProdParaVenta.Checked ? true : false;
            bool productoVentaBascula = chkProdVtaBascula.Checked ? true : false;
            bool productoSeriado = chkSeriado.Checked ? true : false;
            int numDec = (int)nDecimales.Value;
            decimal nPorcDescEmp = nDescEmp.Value;
            int contenidoCaja = (int)nConXCaja.Value;
            /******************************/
            int? almacen = (int?)uiAlmacen.SelectedValue == 0 ? null : (int?)uiAlmacen.SelectedValue;
            int? anden = (int?)uiAnden.SelectedValue == 0 ? null : (int?)uiAnden.SelectedValue;
            int? lote = (int)uiLote.SelectedValue == 0 ? null : (int?)uiLote.SelectedValue;
            DateTime? fechaCaducidad = uiFechaCad.Value;

            int? empresa = puntoVentaContext.empresaId; 
            int? sucursal = puntoVentaContext.sucursalId;
            string talla = uiTalla.Text;
            string color = uiColor.Text;
            string color2 = uiColor2.Text;
            string especificaciones = uiEspecificaciones.Text;

            if (!ValidarAgregar(clave, nomProducto, unidadMedida,inventariadoPor,familia,subFamilia,linea,marca,uiMinimo.Value,uiMaximo.Value).ok)
            {
                MessageBox.Show(resultado.mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (pbFoto.Image == null)
            {
                byte[] foto = null;
                resultado = pI.Agregar(clave, nomProducto, nomDescCorta, marca, familia, subFamilia, linea, unidadMedida, inventariadoPor, sVendePor, estatus, productoTerminado, inventariable, materiaPrima, productoParaVenta, productoVentaBascula, productoSeriado, numDec, nPorcDescEmp, contenidoCaja, foto, empresa, sucursal,
                    almacen,anden,lote,fechaCaducidad,uiMinimo.Value,uiMaximo.Value,uiIncUtilidadPorc.Value,
                    talla,color,color2,especificaciones,uiSobrePedido.Checked,
                    ref productoid);
               
            }
            else
            {
                MemoryStream stream = new MemoryStream();
                pbFoto.Image.Save(stream, ImageFormat.Jpeg);
                byte[] pic = stream.ToArray();

                resultado = pI.Agregar(clave, nomProducto, nomDescCorta, marca, familia, subFamilia, linea, unidadMedida, 
                    inventariadoPor, sVendePor, estatus, productoTerminado, inventariable, materiaPrima, productoParaVenta, 
                    productoVentaBascula, productoSeriado, numDec, nPorcDescEmp, contenidoCaja, pic, empresa, sucursal,almacen,
                    anden,lote,fechaCaducidad,uiMinimo.Value,uiMaximo.Value, uiIncUtilidadPorc.Value, 
                    talla,color,color2,especificaciones,uiSobrePedido.Checked,
                    ref productoid);
               
            }

            if (resultado.ok)
            {
                int usuarioId = puntoVentaContext.usuarioId;
                oContext.p_cat_productos_config_sucursal_ins_upd(productoid, sucursal, uiUsarIncUtilidad.Checked, uiUsarIncPesos.Checked, uiUsarEstablecer.Checked, uiIncUtilidadPorc.Value, uiIncUtilidadPesos.Value, usuarioId);
            }

            MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (resultado.ok)
            {
                LimpiarControles();
                if(frmProductos.GetInstance() != null)
                {
                    frmProductos.GetInstance().llenarGrid();
                }
                
                this.Close();

                //Buscar();
                //uiPrecios.AutoGenerateColumns = false;
                //uiPrecios.DataSource = oContext.p_productos_precio_grd(int.Parse(nProductoId.Value.ToString()));
            }

        }

        private void Editar()
        {
            resultado = new Resultado();
            int productoId = (int)nProductoId.Value == 0 ? this.productoId : (int)nProductoId.Value;
            string clave = txtClave.Text;
            string nomProducto = txtNomProducto.Text;
            string nomDescCorta = txtDescCorta.Text;
            int unidadMedida = 0;
            if (cmbUnidadMedida != null && cmbUnidadMedida.SelectedItem != null)
                unidadMedida = int.Parse(((ComboBoxItem)cmbUnidadMedida.SelectedItem).valor.ToString());
            int marca = 0;
            if (cmbMarca != null && cmbMarca.SelectedItem != null)
                marca = int.Parse(((ComboBoxItem)cmbMarca.SelectedItem).valor.ToString());
            int familia = 0;
            if (uiFamilia != null && uiFamilia.SelectedItem != null)
                familia = int.Parse(((ComboBoxItem)uiFamilia.SelectedItem).valor.ToString());
            int subFamilia = 0;
            if (uiSubfamilia != null && uiSubfamilia.SelectedItem != null)
                subFamilia = int.Parse(((ComboBoxItem)uiSubfamilia.SelectedItem).valor.ToString());
            int linea = 0;
            if (uiLinea != null && uiLinea.SelectedItem != null)
                linea = int.Parse(((ComboBoxItem)uiLinea.SelectedItem).valor.ToString());
            int inventariadoPor = 0;
            if (cmbInvetariadoPor != null && cmbInvetariadoPor.SelectedItem != null)
                inventariadoPor = int.Parse(((ComboBoxItem)cmbInvetariadoPor.SelectedItem).valor.ToString());
            int sVendePor = 0;
            if (cmbVendidoPor != null && cmbVendidoPor.SelectedItem != null)
                sVendePor = int.Parse(((ComboBoxItem)cmbVendidoPor.SelectedItem).valor.ToString());
            bool estatus = chkEstatusProducto.Checked ? true : false;
            bool productoTerminado = chkProductoTerminado.Checked ? true : false;
            bool inventariable = chkInventariable.Checked ? true : false;
            bool materiaPrima = chkMateriaPrima.Checked ? true : false;
            bool productoParaVenta = chkProdParaVenta.Checked ? true : false;
            bool productoVentaBascula = chkProdVtaBascula.Checked ? true : false;
            bool productoSeriado = chkSeriado.Checked ? true : false;
            int numDec = (int)nDecimales.Value;
            decimal nPorcDescEmp = nDescEmp.Value;
            int contenidoCaja = (int)nConXCaja.Value;
            /******************************/
            int? almacen = (int?)uiAlmacen.SelectedValue == 0 ? null : (int?)uiAlmacen.SelectedValue;
            int? anden = (int?)uiAnden.SelectedValue == 0 ? null : (int?)uiAnden.SelectedValue;
            int? lote = (int)uiLote.SelectedValue == 0 ? null :(int?)uiLote.SelectedValue;
            DateTime? fechaCaducidad = uiFechaCad.Value;

            string talla = uiTalla.Text;
            string color = uiColor.Text;
            string color2 = uiColor2.Text;
            string especificaciones = uiEspecificaciones.Text;

            if (!ValidarEditar(clave, nomProducto, unidadMedida, inventariadoPor,uiMinimo.Value,uiMaximo.Value,marca,subFamilia).ok)
            {
                MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    
                        byte[] foto = null;
                        resultado = pI.Actualizar(productoId, clave, nomProducto, nomDescCorta, marca, familia,
                            subFamilia, linea, unidadMedida, inventariadoPor, sVendePor, estatus, productoTerminado,
                            inventariable, materiaPrima, productoParaVenta, productoVentaBascula, productoSeriado,
                            numDec, nPorcDescEmp, contenidoCaja, foto, almacen, anden, lote, fechaCaducidad, uiMinimo.Value, uiMaximo.Value, uiIncUtilidadPorc.Value,
                            talla,color,color2,especificaciones,uiSobrePedido.Checked);

                    oContext.p_productos_agrupados_upd(productoId);

                   

                    if (resultado.ok)
                    {
                        int sucursal = puntoVentaContext.sucursalId;
                        int usuarioId = puntoVentaContext.usuarioId == 0 ? 1 : puntoVentaContext.usuarioId;
                        oContext.p_cat_productos_config_sucursal_ins_upd(productoId, sucursal, uiUsarIncUtilidad.Checked, uiUsarIncPesos.Checked, uiUsarEstablecer.Checked, uiIncUtilidadPorc.Value, uiIncUtilidadPesos.Value, usuarioId);

                        MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        scope.Complete();

                       
                    }
                    else {
                        MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    

                   
                   
                }
                catch (Exception ex)
                {
                    resultado.ok = false;
                    resultado.mensaje = ex.Message;


                    MessageBox.Show(resultado.mensaje, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

            }
            

            if (resultado.ok)
            {
                if (frmProductos.GetInstance() != null)
                {
                    frmProductos.GetInstance().llenarGrid();
                    this.Close();

                }

            }
        }

        private void Eliminar()
        {
            int clave = (int)nProductoId.Value;
            if (!ValidarEliminar(clave).ok)
            {
                MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var opcion = MessageBox.Show("¿Seguro que desea eliminar el registro " + clave + "?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (opcion == DialogResult.OK)
            {
                resultado = new Resultado();
                resultado = pI.Eliminar(clave);
                MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (resultado.ok)
                {
                    LimpiarControles();
                    Buscar();
                }
            }
        }
        private void InitializeOpenFileDialog()
        {
            // Set the file dialog to filter for graphics files.
            this.openFileDialog1.Filter =
                "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" +
                "All files (*.*)|*.*";

            // Allow the user to select multiple images.
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "My Image Browser";
        }
        public int BuscarRegistro(int id, string clave)
        {
            nProductoId.Value = id;
            DataTable dt = pI.ConsultarRegistro(id, false);
            productoId = 0;
            if (dt.Rows != null && dt.Rows.Count > 0)
            {
                SetEnableTAB(tpPrecioImp, true);
                SetEnableTAB(tpImpuestos, true);
                SetEnableTAB(tpExistencias, true);

                uiImagenPrincipal.Enabled = false;
                productoId = id;
                productoImagenId = 0;
                txtClave.Text = dt.Rows[0]["Clave"].ToString(); ;
                txtNomProducto.Text = dt.Rows[0]["Descripcion"].ToString();
                txtDescCorta.Text = dt.Rows[0]["DescripcionCorta"].ToString();
                nDecimales.Value = int.Parse(dt.Rows[0]["NumeroDecimales"].ToString());
                nDescEmp.Value = decimal.Parse(dt.Rows[0]["PorcDescuentoEmpleado"].ToString());
                nConXCaja.Value = int.Parse(dt.Rows[0]["ContenidoCaja"].ToString());
                chkEstatusProducto.Checked = bool.Parse(dt.Rows[0]["Estatus"].ToString());
                chkProductoTerminado.Checked = bool.Parse(dt.Rows[0]["ProductoTerminado"].ToString());
                chkInventariable.Checked = bool.Parse(dt.Rows[0]["Inventariable"].ToString());
                chkMateriaPrima.Checked = bool.Parse(dt.Rows[0]["MateriaPrima"].ToString());
                chkProdParaVenta.Checked = bool.Parse(dt.Rows[0]["ProdParaVenta"].ToString());
                chkProdVtaBascula.Checked = bool.Parse(dt.Rows[0]["ProdVtaBascula"].ToString());
                chkSeriado.Checked = bool.Parse(dt.Rows[0]["Seriado"].ToString());
                uiAlmacen.SelectedValue = dt.Rows[0]["ClaveAlmacen"] == DBNull.Value ? 0 : int.Parse(dt.Rows[0]["ClaveAlmacen"].ToString());
                uiAnden.SelectedValue = dt.Rows[0]["ClaveAnden"] == DBNull.Value ? 0 : int.Parse(dt.Rows[0]["ClaveAnden"].ToString());
                uiLote.SelectedValue = dt.Rows[0]["ClaveLote"] == DBNull.Value ? 0 : int.Parse(dt.Rows[0]["ClaveLote"].ToString());
                uiMinimo.Value = decimal.Parse(dt.Rows[0]["MinimoInventario"].ToString());
                uiMaximo.Value = decimal.Parse(dt.Rows[0]["MaximoInventario"].ToString());
                uiIncUtilidadPorc.Value = dt.Rows[0]["PorcUtilidad"] == DBNull.Value ? 0 : decimal.Parse(dt.Rows[0]["PorcUtilidad"].ToString());
                uiTalla.Text = dt.Rows[0]["Talla"].ToString();
                uiColor.Text = dt.Rows[0]["Color"].ToString();
                uiColor2.Text = dt.Rows[0]["Color2"].ToString();
                uiEspecificaciones.Text = dt.Rows[0]["Especificaciones"].ToString();
                uiSobrePedido.Checked = dt.Rows[0]["SobrePedido"] != DBNull.Value ?
                    bool.Parse(dt.Rows[0]["SobrePedido"].ToString()) : false;




                if (dt.Rows[0]["FechaCaducidad"] == DBNull.Value)
                {
                    uiFechaCad.Text = "";
                }
                else
                {
                    uiFechaCad.Value = dt.Rows[0]["FechaCaducidad"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(dt.Rows[0]["FechaCaducidad"].ToString());
                }
                pbFoto.Image = null;
                uiImagenDetalle.Image = null;
                #region buscar imagen
                cat_productos_imagenes eImagen = oContext.cat_productos_imagenes
                     .Where(w => w.ProductoId == id && w.Principal == true)
                     .FirstOrDefault();
                #endregion
                if (eImagen != null)
                {
                    using (var ms = new MemoryStream((byte[])eImagen.FileByte))
                    {
                        pbFoto.Image = Image.FromStream(ms);
                        uiImagenPrincipal.Image = Image.FromStream(ms);
                    }
                }
                

                //pbFoto.Image = (byte[])dt.Rows[0]["ProdVtaBascula"];
                int unidadMedida = dt.Rows[0]["ClaveUnidadMedida"] != DBNull.Value ? int.Parse(dt.Rows[0]["ClaveUnidadMedida"].ToString()) : 0; 
                int marca = dt.Rows[0]["ClaveMarca"] != System.DBNull.Value ? int.Parse(dt.Rows[0]["ClaveMarca"].ToString()) : 0;
                int familia = dt.Rows[0]["ClaveFamilia"] != System.DBNull.Value ? int.Parse(dt.Rows[0]["ClaveFamilia"].ToString()) : 0;
                int subfamilia = dt.Rows[0]["ClaveSubFamilia"] != System.DBNull.Value ? int.Parse(dt.Rows[0]["ClaveSubFamilia"].ToString()) : 0;
                int linea = dt.Rows[0]["ClaveLinea"] != System.DBNull.Value ? int.Parse(dt.Rows[0]["ClaveLinea"].ToString()) : 0;
                int inventariadoPor = dt.Rows[0]["ClaveInventariadoPor"] != System.DBNull.Value ? int.Parse(dt.Rows[0]["ClaveInventariadoPor"].ToString()) : 0;
                int seVendePor = dt.Rows[0]["ClaveVendidaPor"] != System.DBNull.Value ? int.Parse(dt.Rows[0]["ClaveVendidaPor"].ToString()) : 0;
                SeleccionarRegistroCombo(ref cmbUnidadMedida, unidadMedida);
                SeleccionarRegistroCombo(ref cmbMarca, marca);
                SeleccionarRegistroCombo(ref uiFamilia, familia);
                SeleccionarRegistroCombo(ref uiSubfamilia, subfamilia);
                SeleccionarRegistroCombo(ref uiLinea, linea);
                SeleccionarRegistroCombo(ref cmbInvetariadoPor, inventariadoPor);
                SeleccionarRegistroCombo(ref cmbVendidoPor, seVendePor);                
                Byte[] data = new Byte[0];
                if (dt.Rows[0]["Foto"] != DBNull.Value)
                {
                    data = (Byte[])(dt.Rows[0]["Foto"]);
                    MemoryStream mem = new MemoryStream(data);
                    pbFoto.Image = Image.FromStream(mem);
                    
                }


                CargarGridPrecios();
                CargarImpuestos();
                obtenerUltimaCompra();
                cargarGridImagenes();

                buscarExistencias();
                obtenerConfigSucursal();
            }
            return dt == null ? 0 : (dt.Rows == null ? 0 : dt.Rows.Count);
        }

        private void cargarGridImagenes()
        {
            try
            {
                
                uiGridImagenes.DataSource = oContext.p_productos_imagenes_sel(productoId);
            }
            catch (Exception)
            {

                
            }
        }

        private void SeleccionarRegistroCombo(ref ComboBox cmb, int id)
        {
            for (int i = 0; i < cmb.Items.Count; i++)
            {
                var prop = cmb.Items[i].GetType().GetProperty(cmb.ValueMember);
                if (prop != null && prop.GetValue(cmb.Items[i], null).ToString() == id.ToString())
                {
                    cmb.SelectedIndex = i;
                    break;
                }
            }
        }

        public List<ComboBoxItem> CargarComboBox(ref ComboBox comboBox, bool filtroTodos, string clave, string descripcion, DataTable dt)
        {
            List<ComboBoxItem> lista = new List<ComboBoxItem>();
            string textoInicial = filtroTodos ? "(TODOS)" : "(SELECCIONAR)";
            ComboBoxItem cmb = new ComboBoxItem();
            cmb.texo = "(SELECCIONAR)";
            cmb.valor = 0;
            comboBox.Items.Add(cmb);

            if (dt != null && dt.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        cmb = new ComboBoxItem();
                        cmb.valor = int.Parse(item[clave].ToString());
                        cmb.texo = item[descripcion].ToString();
                        comboBox.Items.Add(cmb);
                    }
                }
                catch { }
            }
            comboBox.SelectedIndex = 0;
            comboBox.DisplayMember = "texo";
            comboBox.ValueMember = "valor";
            return lista;
        }

        private void SeleccionarFoto()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "images| *.JPG; *.PNG; *.GJF";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbFoto.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void EliminarFoto()
        {
            pbFoto.Image = null;
            uiImagenDetalle.Image = null;
        }

        private void DesglozarPrecioVta()
        {
            try
            {
                int idProducto = int.Parse(nProductoId.Value.ToString());
                decimal precioVta = 0;
                decimal subtotal = 0;

                cat_productos producto = oContext.cat_productos.Where(w => w.ProductoId == idProducto).FirstOrDefault();

                cat_productos_precios productosPrec = producto.cat_productos_precios.Where(w => w.IdPrecio == (int)precios.publicoGral).FirstOrDefault();
                

                if (productosPrec != null)
                {
                    precioVta = productosPrec.Precio;
                }

                decimal porcUmpuestos = producto.cat_productos_impuestos.Sum(s => s.cat_impuestos.Porcentaje).Value;
                              
                subtotal = precioVta / (1 + (porcUmpuestos / 100));
               

                //uiCtoNeto.Value = precioVta;
                //uiImpuestos.Value = precioVta - subtotal;
                //uiCtoSinIVA.Value = uiCtoNeto.Value - uiImpuestos.Value;
                //uiPrecioVenta.Value = uiCtoNeto.Value;
                uiEstablecerPrecio.Value = 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrió un error al intentar desglozar el impuesto del precio venta");
            }
            
        }

        private void obtenerUltimaCompra()
        {
            try
            {
                var ultimaCompra = oContext.p_producto_ultima_compra((int)this.nProductoId.Value).ToList();

                if (ultimaCompra.Count > 0)
                {
                    uiCtoSinIVA.Value = ultimaCompra[0].PrecioNeto ?? 0;
                    uiImpuestos.Value = ultimaCompra[0].Impuestos;
                    uiCtoNeto.Value = uiCtoSinIVA.Value + uiImpuestos.Value;
                }
                else
                {
                    uiCtoSinIVA.Value = 0;
                    uiImpuestos.Value = 0;
                    uiCtoNeto.Value = 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void nuevoPrecioVenta()
        {
            
        }

        private void obtenerConfigSucursal()
        {
            oContext = new ERPProdEntities();

            int productoId = int.Parse(nProductoId.Value.ToString());
            int sucursalid = puntoVentaContext.sucursalId;

            cat_productos_config_sucursal entity = oContext.cat_productos_config_sucursal.Where(
                w => w.ProductoId == productoId &&
                w.SucursalId == sucursalid
                ).FirstOrDefault();

            if (entity != null)
            {
                uiUsarEstablecer.Checked = entity.CalculaPrecioManual;
                uiUsarIncPesos.Checked = entity.CalculaPrecioIncUtilidad;
                uiUsarIncUtilidad.Checked = entity.CalculaPrecioPorcUtilidad;
                uiIncUtilidadPesos.Value = entity.IncUtilidadValor;
                uiIncUtilidadPorc.Value = entity.PorcUtilidadValor;
            }
            else
            {
                uiUsarEstablecer.Checked =true;
                uiUsarIncPesos.Checked = false;
                uiUsarIncUtilidad.Checked =false;
                uiIncUtilidadPesos.Value = 0;
                uiIncUtilidadPorc.Value = 0;
            }


        }

        #endregion

        #region eventos de controles
        public void CalcularPrecioVenta()
        {
            uiCtoNeto.Value = uiCtoSinIVA.Value + uiImpuestos.Value;

            if (uiUsarIncUtilidad.Checked)
            {
                uiPrecioVenta.Value = uiCtoNeto.Value * (1 + (uiIncUtilidadPorc.Value / 100));
            }
            if (uiUsarIncPesos.Checked)
            {
                decimal porc=0;
                oContext = new ERPProdEntities();
                int clave = (int)nProductoId.Value;
                oContext = new ERPProdEntities();
                cat_productos entity = oContext.cat_productos.Where(w => w.ProductoId == clave).FirstOrDefault();

                if (entity == null)
                    return;

                var result = entity.cat_productos_impuestos
                    .Where(w => w.ImpuestoId == (int)Enumerados.impuestos.IVA);

                cat_productos_impuestos entityImpuesto = result.FirstOrDefault();

                if (entityImpuesto != null)
                {
                    porc = (decimal)entityImpuesto.cat_impuestos.Porcentaje / 100;
                    
                }

                if (porc > 0)
                {
                    uiPrecioVenta.Value = (uiCtoSinIVA.Value + uiIncUtilidadPesos.Value) * (1 + porc);
                }
                else
                {
                    uiPrecioVenta.Value = uiCtoNeto.Value + uiIncUtilidadPesos.Value;
                }
               
            }
            if (uiUsarEstablecer.Checked)
            {
                uiPrecioVenta.Value = uiEstablecerPrecio.Value;
            }
        }

        private void uiIncUtilidadPorc_ValueChanged(object sender, EventArgs e)
        {
            //uiIncUtilidadPesos.Value = 0;
            //uiEstablecerPrecio.Value = 0;
            CalcularPrecioVenta();
        }

        private void uiIncUtilidadPesos_ValueChanged(object sender, EventArgs e)
        {
            //uiIncUtilidadPorc.Value = 0;
            //uiEstablecerPrecio.Value = 0;
            CalcularPrecioVenta();
        }

        private void uiEstablecerPrecio_ValueChanged(object sender, EventArgs e)
        {
            //uiIncUtilidadPorc.Value = 0;
            //uiIncUtilidadPesos.Value = 0;
            CalcularPrecioVenta();
        }

        private void uiPrecios_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    oContext = new ERPProdEntities();
                    int precioId = int.Parse(uiPrecios["IdPrecio", e.RowIndex].Value.ToString());
                    decimal descuento = decimal.Parse(uiPrecios["PorcDescuento", e.RowIndex].Value.ToString());
                    int productoId = (int)nProductoId.Value;
                    ObjectParameter montoDescuento = new ObjectParameter("pMontoDescuento",0);
                    ObjectParameter precioFinal = new ObjectParameter("pPrecioFinal", 0);

                    /*obtener el precio general**********/
                    cat_productos_precios entitypgral = oContext.cat_productos_precios.Where(w => w.IdProducto == productoId && w.IdPrecio == (int)Enumerados.precios.publicoGral).FirstOrDefault();

                    if (entitypgral != null)
                    {
                        oContext.p_ActualizarListaPrecios(productoId, precioId, descuento, montoDescuento, precioFinal); //pI.modificarPrecioProducto(precioId, productoId, descuento, ref montoDescuento, ref precioFinal);



                        MessageBox.Show("El proceso terminó con éxito", "AVISO");
                        uiPrecios["MontoDescuento", e.RowIndex].Value = montoDescuento.Value;
                        uiPrecios["Precio", e.RowIndex].Value = precioFinal.Value;
                    }
                    else {
                        MessageBox.Show("Es necesario generar antes el precio de Publico Gral para poder aplicar un descuento","ERROR");
                    }



              


                    

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
            }

        }

        private string GuardarConfigSucursal()
        {

            string error = "";
            try
            {
                oContext = new ERPProdEntities();
                int productoId = (int)nProductoId.Value;

                cat_productos entity = oContext.cat_productos.Where(w => w.ProductoId == productoId).FirstOrDefault();

                if (entity.cat_productos_config_sucursal.Count == 0)
                {
                    cat_productos_config_sucursal entityConfig = new cat_productos_config_sucursal();

                    entityConfig.ProductoId = productoId;
                    entityConfig.SucursalId = puntoVentaContext.sucursalId;
                    entityConfig.CalculaPrecioPorcUtilidad = uiUsarIncUtilidad.Checked;
                    entityConfig.CalculaPrecioIncUtilidad = uiUsarIncPesos.Checked;
                    entityConfig.CalculaPrecioManual = uiUsarEstablecer.Checked;
                    entityConfig.PorcUtilidadValor = uiIncUtilidadPorc.Value;
                    entityConfig.IncUtilidadValor = uiIncUtilidadPesos.Value;
                    entityConfig.CreadoPor = puntoVentaContext.usuarioId;
                    entityConfig.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                    oContext.cat_productos_config_sucursal.Add(entityConfig);
                    oContext.SaveChanges();

                }
                else {

                    cat_productos_config_sucursal entityConfig = entity.cat_productos_config_sucursal.FirstOrDefault();

                    entityConfig.CalculaPrecioPorcUtilidad = uiUsarIncUtilidad.Checked;
                    entityConfig.CalculaPrecioIncUtilidad = uiUsarIncPesos.Checked;
                    entityConfig.CalculaPrecioManual = uiUsarEstablecer.Checked;
                    entityConfig.PorcUtilidadValor = uiIncUtilidadPorc.Value;
                    entityConfig.IncUtilidadValor = uiIncUtilidadPesos.Value;
                    entityConfig.ModificadoPor = puntoVentaContext.usuarioId;
                    entityConfig.ModificadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                    oContext.SaveChanges();



                }
            }
            catch (Exception ex)
            {

                error = ex.Message;
            }

            return error;

        }

        private void btnAplicarPrecioVta_Click(object sender, EventArgs e)
        {
            try
            {
                oContext = new ERPProdEntities();
                CalcularPrecioVenta();
                if (MessageBox.Show("¿Está seguro de continuar?, se afectará la lista de precios", "AVISO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Guardar % de utilidad
                    int productoId = (int)nProductoId.Value;
                    cat_productos entity = oContext.cat_productos.Where(w => w.ProductoId == productoId).FirstOrDefault();
                    entity.PorcUtilidad = uiIncUtilidadPorc.Value;
                    oContext.SaveChanges();



                   string error= GuardarConfigSucursal();

                    if (error.Length > 0)
                    {
                        MessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                     error = pI.aplicarPrecioVenta((int)nProductoId.Value, uiPrecioVenta.Value);

                   
                    if (error.Length > 0)
                    {
                        MessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("El proceso terminó con éxito", "AVISO");
                        oContext = new ERPProdEntities();
                      
                        ObjectParameter montoDescuento = new ObjectParameter("pMontoDescuento", 0);
                        ObjectParameter precioFinal = new ObjectParameter("pPrecioFinal", 0); ;
                        oContext.p_ActualizarListaPrecios((int)nProductoId.Value, null, null, montoDescuento, precioFinal);

                        oContext.p_productos_agrupados_upd((int)nProductoId.Value);

                        CargarGridPrecios();
                        DesglozarPrecioVta();
                        obtenerUltimaCompra();

                    }
                }

               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"ERROR");
            }

          

        }

        private void uiPrecios_RowValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void uiPrecios_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {



        }

        private void uiPrecios_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
           if (e.RowIndex >= 0)
            {
                int precioId = int.Parse(uiPrecios["IdPrecio", e.RowIndex].Value.ToString());

                if (precioId == (int)Enumerados.precios.publicoGral)
                {

                    e.Cancel = true;

                }

            }
        }

        private void btnAgregarImpuesto_Click(object sender, EventArgs e)
        {
            string error = pI.agregarImpuesto((int)nProductoId.Value, (int)uiImpuestoCMB.SelectedValue);

            if (error.Length > 0)
            {
                MessageBox.Show(error, "ERROR");
            }
            else
            {
                CargarImpuestos();
            }
        }

        private void uiProductosImpuesto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here

                oContext = new ERPProdEntities();

                int ID = int.Parse(uiProductosImpuesto["ID", e.RowIndex].Value.ToString());

                cat_productos_impuestos entity = oContext.cat_productos_impuestos
                    .Where(w => w.ProductoImpuestoId == ID).FirstOrDefault();

                oContext.cat_productos_impuestos.Remove(entity);
                oContext.SaveChanges();

                CargarImpuestos();

                //DataGridViewRow row = uiProductosImpuesto.Rows[e.RowIndex];

                //uiProductosImpuesto.Rows.Remove(row);
            }
        }

        private void uiCtoSinIVA_ValueChanged(object sender, EventArgs e)
        {
            /***REVISAR SI EL PRODUCTO TIENE UN IMPUESTO****/
            try
            {
                oContext = new ERPProdEntities();
                int clave = (int)nProductoId.Value;

                cat_productos entity = oContext.cat_productos.Where(w => w.ProductoId == clave).FirstOrDefault();

                if (entity != null)
                {

                    cat_productos_impuestos entityImpuesto = entity.cat_productos_impuestos
                        .Where(w => w.ImpuestoId == (int)Enumerados.impuestos.IVA).FirstOrDefault();

                    if (entityImpuesto != null)
                    {
                        decimal porc = (decimal)entityImpuesto.cat_impuestos.Porcentaje / 100;

                        uiImpuestos.Value = uiCtoSinIVA.Value * (porc);
                        uiCtoNeto.Value = uiCtoSinIVA.Value + uiImpuestos.Value;
                    }
                    else
                    {
                        uiImpuestos.Value = 0;
                        //MessageBox.Show("No fue posible obtener el Impuesto IVA para este producto", "ERROR");
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string clave = "";
                int id = (int)nProductoId.Value;
                try
                {
                   clave = txtClave.Text;
                }
                catch { }

                int numero = BuscarRegistro(id, clave);
                
                txtNomProducto.Focus();                
            }
        }

        private void txtNomProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtDescCorta.Focus();
            }
        }

        private void txtDescCorta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                cmbUnidadMedida.Focus();
            }
        }
        
        private void cmbUnidadMedida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                cmbMarca.Focus();
            }
        }

        private void cmbMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                uiFamilia.Focus();
            }
        }

        private void uiFamilia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                uiSubfamilia.Focus();
            }
        }

        private void uiSubfamilia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                uiLinea.Focus();
            }
        }

        private void uiLinea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                cmbInvetariadoPor.Focus();
            }
        }
        
        private void cmbInvetariadoPor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                cmbVendidoPor.Focus();
            }
        }

        private void cmbVendidoPor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                nDecimales.Focus();
            }
        }

        private void nDecimales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                nDescEmp.Focus();
            }
        }

        private void nDescEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                nConXCaja.Focus();
            }
        }

        private void nConXCaja_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                chkEstatusProducto.Focus();
            }
        }
        
        private void chkEstatusProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                chkProductoTerminado.Focus();
            }
        }

        private void chkProductoTerminado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                chkInventariable.Focus();
            }
        }

        private void chkInventariable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                chkMateriaPrima.Focus();
            }
        }

        private void chkMateriaPrima_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                chkProdParaVenta.Focus();
            }
        }

        private void chkProdParaVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                chkProdVtaBascula.Focus();
            }
        }

        private void chkProdVtaBascula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                chkSeriado.Focus();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Insertar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Buscar();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvAltaPersonal_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          
        }
        
        private void pbFoto_Click(object sender, EventArgs e)
        {
            //SeleccionarFoto();
        }

        private void lblEliminarFoto_Click(object sender, EventArgs e)
        {
            EliminarFoto();
        }


        #endregion
        #region imagenes
        private void vistaPrevia(int rowIndex)
        {
            try
            {
                if (rowIndex >= 0)
                {
                    oContext = new ERPProdEntities();
                    productoImagenId = 0;

                    productoImagenId = uiGridImagenes.Rows[rowIndex].Cells[0].Value != null
                        ? int.Parse(uiGridImagenes.Rows[rowIndex].Cells[0].Value.ToString())
                        : 0;

                    if (productoImagenId > 0)
                    {
                        cat_productos_imagenes entityPreview = oContext.cat_productos_imagenes
                            .Where(w => w.ProductoImageId == productoImagenId).FirstOrDefault();

                        if (entityPreview != null)
                        {
                            byte[] preview = entityPreview.FileByte;

                            Byte[] data = preview;
                            
                            MemoryStream mem = new MemoryStream(data);                           
                            
                            uiImagenDetalle.Image = Image.FromStream(mem);

                            if (entityPreview.Principal == true)
                            {
                                uiImagenPrincipal.Enabled = false;
                            }
                            else {
                                uiImagenPrincipal.Enabled =true;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                
            }
        }

        private void hacerPrincipal()
        {
            try
            {
                if (productoImagenId > 0)
                {
                    oContext.p_producto_imagen_principal_upd(productoImagenId);

                    uiImagenPrincipal.Enabled = false;
                    cargarGridImagenes();
                    MessageBox.Show("El proceso terminó con éxito", "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception)
            {

                
            }
        }
        #endregion

        private void HabilitarDeshabilitarNuevoPrecio()
        {
            if (uiUsarEstablecer.Checked)
            {
                uiEstablecerPrecio.Enabled = true;
                uiIncUtilidadPorc.Enabled = false;
                uiIncUtilidadPesos.Enabled = false;
                uiPrecioVenta.Value = 0;
            }
            if (uiUsarIncPesos.Checked)
            {
                uiEstablecerPrecio.Enabled = false;
                uiIncUtilidadPorc.Enabled = false;
                uiIncUtilidadPesos.Enabled = true;
                uiPrecioVenta.Value = 0;

            }
            if (uiUsarIncUtilidad.Checked)
            {
                uiEstablecerPrecio.Enabled = false;
                uiIncUtilidadPorc.Enabled = true;
                uiIncUtilidadPesos.Enabled = false;
                CalcularPrecioVenta();
            }
        }

        private void uiUsarIncUtilidad_CheckedChanged(object sender, EventArgs e)
        {

            HabilitarDeshabilitarNuevoPrecio();
            
        }

        private void uiUsarIncPesos_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarDeshabilitarNuevoPrecio();
        }

        private void uiUsarEstablecer_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarDeshabilitarNuevoPrecio();
        }

        private void uiSucursal_SelectedValueChanged(object sender, EventArgs e)
        {
            buscarExistencias();
        }

        private void uiIncUtilidadPesos_Validating(object sender, CancelEventArgs e)
        {
            CalcularPrecioVenta();
        }

        private void uiIncUtilidadPorc_Validating(object sender, CancelEventArgs e)
        {
            CalcularPrecioVenta();
        }

        private void uiEstablecerPrecio_Validating(object sender, CancelEventArgs e)
        {
            CalcularPrecioVenta();
        }

        private void tpGenerales_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarArchivo_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            string error = "";

            if (result == DialogResult.OK)
            {
                
                if (openFileDialog1.FileNames.Count() > 0 && productoId > 0)
                {
                    error = pI.importarImagenProducto(productoId, openFileDialog1.FileNames);

                    if (error.Length > 0)
                    {
                        MessageBox.Show(error,
                             "ERROR",
                              MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                    }
                    else
                    {
                        BuscarRegistro(productoId, "");
                        MessageBox.Show("El proceso terminó con éxito",
                             "AVISO",
                              MessageBoxButtons.OK,
                               MessageBoxIcon.Asterisk);

                    }
                }
            }
        }

        private void uiGridImagenes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void uiGridImagenes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            vistaPrevia(e.RowIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hacerPrincipal();
                }

        private void uiClonar_Click(object sender, EventArgs e)
        {
            try
            {
                if (productoId == 0)
                {
                    return;
                }
                if (
                    MessageBox.Show(
                        "Se creará un registro con la misma información del producto seleccionado,¿Está seguro de continuar?",
                        "AVISO",
                         MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question
                        ) == DialogResult.Yes
                    )
                {
                    ObjectParameter pProductoNuevoId = new ObjectParameter("pProductoNuevoId", 0);
                    oContext.p_productos_clonar(productoId, pProductoNuevoId);

                    MessageBox.Show("Se ha credo un nuevo producto con clave:" + pProductoNuevoId.Value.ToString(),
                        "OK",
                         MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR",
                     MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                                
            }
        }

        private void uiProduccion_Click(object sender, EventArgs e)
        {
            if(this.productoId > 0)
            {
                frmProduccionUpd frmo = frmProduccionUpd.GetInstance();

                if (!frmo.Visible)
                {
                    //frmo = new frmPuntoVenta();
                    
                    frmo.puntoVentaContext = this.puntoVentaContext;
                    frmo.WindowState = FormWindowState.Normal;
                    frmo.accion = ConexionBD.Enumerados.accionForm.actualizar;
                    frmo.id = this.productoId;
                    frmo.ShowDialog();

                }
            }
            
        }

        private void tpFotos_Click(object sender, EventArgs e)
        {

        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            if(esNuevo)
            {
                Insertar();
            }
            else
            {
                Editar();
            }
            
        }
    }
}
