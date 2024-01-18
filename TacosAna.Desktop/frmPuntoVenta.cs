using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using ERP.Common.Dialogos;
using ERP.Common.Procesos;
using ERP.Common.Procesos.Restaurante;
using ERP.Common.PuntoVenta;
using ERP.Common.Seguridad;
using ERP.Common.Utils;
using ERP.Models.Pedidos;
using ERP.Models.Producto;
using ERP.Reports.TacosAna;
using GrapeCity.ActiveReports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TacosAna.Desktop
{
    public partial class frmPuntoVenta : XtraForm
    {
        cat_configuracion conf ;
        int err;
        string botonSeleccionado;
        decimal retiroAcumulado = 0;
        decimal cantidadLimiteRetiro = 0;
        public enum famProductos
        {
            vaso=100,
            litro=101,
            agua_nat=102,
            jugo=103,
            refresco=104
        }
        public enum productosTacosAna
        {
            SURTIDO = 1,
            ESPECIAL=2,
            CARNE=3,
            P1_2SURTIDO=4,
            P1_2ESPECIAL=5,
            P1_2CARNE=6
        }
       
        public enum guisosTacosAna
        {
            CARNE=37,
            CHICH=35,
            H_VERDE=33,
            H_ROJO=38,
            FRIJOL=36,
            PAPA=34
        }
        PedidoOrdenBusiness oPedidoOrden;
        ERPProdEntities oContext;
        private doc_pedidos_orden pedido { get; set; }
        public doc_pedidos_orden_programacion programacion { get; set; }
        public int pedidoId { get; set; }
        public int ventaId { get; set; }
        public string notas { get; set; }
        private static frmPuntoVenta _instance;
        public PuntoVentaContext puntoVentaContext;
        private List<PedidoDetalleModel> lstPedido;
        private List<cat_productos> lstProductos;
        private List<cat_productos> lstGuisos;
        private List<cat_subfamilias> lstSubFamBebidas;
        private List<cat_productos> lstBebidas;
        private List<cat_productos> lstBebidasFiltro;        
        private List<cat_productos> itemSin;
        private List<cat_productos> itemPor;
        private List<cat_productos> itemCon;
        private List<cat_productos> itemMitad;        
        private cat_productos itemOtros;
        private List<string> lstPaqueteDetalle;
        private List<cat_productos_imagenes> lstProductosImg;
        public decimal porcDescEmpleado;
        private decimal porcAnticipoPedido;
        public   bool esVentaPorTelefono;
        public bool esPedidoConAnticipo;

        private bool cobrando=false;
        private bool cobrandoAnticipo = false;

        private bool btnSin;
        private bool btnPor;
        private bool btnCon;
        private bool btnMitad;
        private int famBebida;

        /**variables para saber cuantos botones hay disponibles por sección*/
        private static int numBtnProds = 11;
        private static int numBtnGuisos = 16;
        private static int numBtnBebidas1 = 8;
        private static int numBtnBebidas2 = 16;
        
        
        /**variables para saber cuantos botones se usarán por sección*/
        private  int numBtnProds_u = 0;
        private  int numBtnGuisos_u = 0;
        private int numBtnBebidas1_u = 0;
        private int numBtnBebidas2_u = 0;
        
        /***Variables de cobro*/
        private decimal valorCalc = 0;
        private decimal valorRecibi = 0;
        private decimal valorCambio = 0;
        private decimal valorTotal = 0;
        private decimal valorFaltan = 0;
        private decimal cantidadAnticipo = 0;



        private int productoIdSel { get; set; }
        List<FormaPagoModel> lstFormasPago;
        private short cantidadPaquete { get; set; }
        private short limiteMaxGuisoSeleccion { get; set; }
        private short limiteCarneChicharron { get; set; }
        private bool limiteMaxGuisoSeleccionValidar = false;
        string error;
        private int cantidadPaquetesInicial = 0;
        decimal descuentoEmpleado { get; set; }
        cat_configuracion entityConfiguracion;
        cat_impresoras entityImpresoraComanda;
        public static frmPuntoVenta GetInstance()
        {
            if (_instance == null) _instance = new frmPuntoVenta();
            else _instance.BringToFront();
            return _instance;
        }
        public frmPuntoVenta()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();

            porcDescEmpleado = oContext.cat_configuracion.FirstOrDefault().EmpleadoPorcDescuento??0;

            
        }


        private void PVTacosAna_Load(object sender, EventArgs e)
        {
            /*
             btnG2_1.Click += btnG2_1_Click;
             btnG2_2.Click += btnG2_1_Click;
             btnG2_3.Click += btnG2_1_Click;
             btnG2_4.Click += btnG2_1_Click;
             */
            entityConfiguracion = oContext.cat_configuracion.FirstOrDefault();

            porcAnticipoPedido = entityConfiguracion.PedidoAnticipoPorc??0;

            ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,
                this.puntoVentaContext.sucursalId,
                "PV-RetiroAutomatico", this.puntoVentaContext.usuarioId, ref error);

            if(error.Length > 0)
            {
                cantidadLimiteRetiro = Convert.ToDecimal(error);
            }

            ImpresorasBusiness oImpresora = new ImpresorasBusiness();
            ERP.Business.DataMemory.DataBucket.GetImpresoraComanda(this.puntoVentaContext.sucursalId, true);
            ERP.Business.DataMemory.DataBucket.GetImpresoraCaja(this.puntoVentaContext.cajaId, true);
            entityImpresoraComanda = oImpresora.ObtenerComandaImpresora(this.puntoVentaContext.sucursalId);
            ERP.Business.DataMemory.DataBucket.GetConfiguracion(true);

            this.lstProductosImg = oContext.cat_productos_imagenes.ToList();
            Inicializar();

           
        }

        private void PVTacosAna_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        #region funciones
        public void Inicializar()
        {
            lstFormasPago = new List<FormaPagoModel>();
            lstPaqueteDetalle = new List<string>();
            limiteMaxGuisoSeleccion = 3;
            uiPedidoRefresh.Visible = false;
            uiPedido.Text = "";
            uiPedidoSaldo.Text = "";
            cobrandoAnticipo = false;
            cantidadAnticipo = 0;
            uiAnticipo.Enabled = false;
           
            uiPedidoResumen.Enabled = false;
            ventaId = 0;
            programacion = new doc_pedidos_orden_programacion();
            pedido = new doc_pedidos_orden();
            programacion.cat_clientes = new cat_clientes();
            notas = "";
            pedidoId = 0;
            lblNotas.Text = "";
            cobrando = false;
            
            grProducto.DataSource = null;
            EnableCalculadora(true);
            uiEnter.Enabled = true;
            colRepo.Visible = true;
            itemSin = new List<cat_productos>();
            itemPor = new List<cat_productos>();
            itemCon = new List<cat_productos>();
            itemMitad = new List<cat_productos>();
            lstPedido = new List<PedidoDetalleModel>();
            GetSubFamBebidas();
            LlenarBotonesBebidasSubFam();
            Getproductos();
            LLenarBotonesProd();
            GetGuisos();
            LlenarBotonesGuisos();
            GetAllBebidas();           
            LimpiarBotones();
            uiRecibi.EditValue = 0;
            uiTotal.EditValue = 0;
            uiCambio.EditValue = 0;
            uiFaltan.EditValue = 0;
            CalcularTotales();
            LlenarLkpEmpleado();
            uiMesa.Enabled = true;
            uiLlevar.Enabled = true;
            uiCortesia.Enabled = true;
            uiConsumo.Enabled = true;
            uiPrecioEmp.Enabled = true;
            uiMesa.Checked = false;
            uiLlevar.Checked = false;
            uiCortesia.Checked = false;
            uiConsumo.Checked = false;
            uiPrecioEmp.Checked = false;
            uiFactura.Checked = false;
            refrescarAvisoVentaTelefono();
            frmMenuRestTA.GetInstance().EnableMenu(true, true, true, true, true);

            validarMaxMinimos();

        }
        private void Getproductos()
        {
            try
            {
                lstProductos = oContext.cat_productos
                    .Where(w => w.ProdParaVenta == true && w.Estatus == true).OrderBy(o=> o.ProductoId).ToList();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
        }

        private void LLenarBotonesProd()
        {
            try
            {
                int botonSinProd = 0;
                List<cat_productos> lstProdBotones = lstProductos
                    .Where(
                        w =>
                            w.cat_familias.Descripcion.ToUpper().Contains("TACOS")
                    ).OrderBy(o => o.ProductoId).ToList();

                botonSinProd = lstProdBotones.Count+1;//ojo aqui tenia lstProdBotones.Count +1
                numBtnProds_u = lstProdBotones.Count;
          
                /*Deshabilitar botones son productos*/
                if (botonSinProd <= numBtnProds)
                {
                    for (int j = botonSinProd; j <= numBtnProds; j++)
                    {
                        Control controlA = Controls.Find("btnProd" + j.ToString(), true).FirstOrDefault();
                        if (controlA != null)
                        {
                            controlA.Enabled = false;                            
                        }
                    }
                }


                /**Habilitar deshabilitar boton "mas prod"..*/
                //if (lstProdBotones.Count > numBtnProds)
                //{
                //    btnProdMas.Enabled = true;
                //}
                //else
                //{
                //    btnProdMas.Enabled = false;
                //}


                int i = 1;
                foreach (var item in lstProdBotones)                
                {

                    Control controlA = Controls.Find("btnProd" + i.ToString(), true).FirstOrDefault();
                    if(controlA != null)
                    {
                        controlA.AccessibleName = item.ProductoId.ToString();
                        controlA.Text = item.DescripcionCorta;
                    }
                    

                    i++;
                }
            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                                      "ERP",
                                      this.Name,
                                      ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void SeleccionarProducto(string id,string text)
        {
            try
            {
                int id2;
                int.TryParse(id, out id2 );

                productoIdSel = id2;

                PedidoActualUpd(0,text);

                GetGuisos();
                LlenarBotonesGuisos();

                botonSeleccionado = text;
            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                                      "ERP",
                                      this.Name,
                                      ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void EnableBtnProd(bool enable)
        {
            btnProd1.Enabled = enable;
            btnProd2.Enabled = enable;
            btnProd3.Enabled = enable;
            btnProd4.Enabled = enable;
            btnProd5.Enabled = enable;
            btnProd6.Enabled = enable;
            btnProd7.Enabled = enable;
            btnProd8.Enabled = enable;
            btnProd9.Enabled = enable;
            btnProd10.Enabled = enable;
            btnProd11.Enabled = enable;
            
        }

        private void EnableBtnG2(bool sin,bool por,bool con,bool mitad)
        {
            btnG2_1.Enabled = sin;
            btnG2_2.Enabled = por;
            btnG2_3.Enabled = con;
            btnG2_4.Enabled = mitad;
        }
        private void EnableBtnG3(bool enable)
        {
            for (int i = 1; i <= numBtnGuisos; i++)
            {
                Control controlA = Controls.Find("btnG3_" + i.ToString(), true).FirstOrDefault();
                if (controlA != null)
                {
                    if(i<=numBtnGuisos_u)
                    {
                        controlA.Enabled = enable;
                    }
                    else
                    {
                        controlA.Enabled = false;
                    }

                    if(botonSeleccionado == "ESP"  && btnCon)
                    {
                        if(uiPedido.Text.Replace("ESP", "").Length == 0)
                        {
                            if ((controlA.Text == "C" || controlA.Text == "CH"))
                            {
                                controlA.Enabled = true;
                            }
                            else
                            {
                                controlA.Enabled = true;
                            }
                        }
                        else
                        {
                            if(itemCon.Where(w=> w.Descripcion == "C").Count() > 0 && controlA.Text == "CH")
                            {
                                controlA.Enabled = false;
                            }
                            if (itemCon.Where(w => w.Descripcion == "CH").Count() > 0 && controlA.Text == "C")
                            {
                                controlA.Enabled = false;
                            }
                        }
                      
                    }

                    if (botonSeleccionado == "CARNE" && btnCon)
                    {
                        if(uiPedido.Text.Replace("CARNE", "").Length > 0)
                        {
                            if (itemCon.Where(w => w.Descripcion == "C").Count() > 0 && controlA.Text == "CH")
                            {
                                controlA.Enabled = false;
                            }
                            if (itemCon.Where(w => w.Descripcion == "CH").Count() > 0 && controlA.Text == "C")
                            {
                                controlA.Enabled = false;
                            }
                        }
                       

                    }



                }
            }
           
           
           
        }
        private void EnableBtnG4(bool enable)
        {
            for (int i = 1; i <= numBtnBebidas1; i++)
            {
                Control controlA = Controls.Find("btnG4_" + i.ToString(), true).FirstOrDefault();
                if (controlA != null)
                {
                    if (i <= numBtnBebidas1_u)
                    {
                        controlA.Enabled = enable;
                    }
                    else
                    {
                        controlA.Enabled = false;
                    }


                }
            }

        }

        private void EnableBtnG5(bool enable)
        {
            for (int i = 1; i <= numBtnBebidas2_u; i++)
            {
                Control controlA = Controls.Find("btnG5_" + i.ToString(), true).FirstOrDefault();
                if (controlA != null)
                {
                    if (i <= numBtnBebidas2_u)
                    {
                        controlA.Enabled = enable;
                    }
                    else
                    {
                        controlA.Enabled = false;
                    }


                }
            }
        }

      
       

        private void PedidoActualUpd(int cantidad,string textadd)
        {
            try
            {
                //Producto
                cat_productos itemProd = new cat_productos();
                if (itemOtros == null)
                {
                    itemProd = lstProductos.Where(w => w.ProductoId == productoIdSel).FirstOrDefault();
                }
                else
                {
                    itemProd = itemOtros;
                }

                    if (itemProd != null)
                    {
                        uiPedido.Text = itemProd.DescripcionCorta;
                    }
                if (itemCon.Count > 0)
                {
                    uiPedido.Text = uiPedido.Text.Length == 0 ? uiPedido.Text + " " : uiPedido.Text + " ";
                    if (uiPedido.Text.Contains("LIBRE"))
                    {
                        foreach (var i in itemCon)
                        {
                            uiPedido.Text = uiPedido.Text + " " + (i.ClaveLote > 0 ? (i.ClaveLote.ToString()) : "") + i.Descripcion;
                        }
                    }
                    else
                    {
                        foreach (var i in itemCon)
                        {
                            uiPedido.Text = uiPedido.Text + " " + (i.ClaveLote > 1 ? (i.ClaveLote.ToString()) : "") + i.Descripcion;
                        }
                    }

                }
                if (itemSin.Count > 0)
                    {
                        uiPedido.Text = uiPedido.Text + " S/";

                        foreach (var i in itemSin)
                        {
                            uiPedido.Text = uiPedido.Text + " " + i.Descripcion;
                        }
                    }

                    if (itemPor.Count > 0)
                    {
                        uiPedido.Text = uiPedido.Text + " X ";

                        foreach (var i in itemPor)
                        {
                            uiPedido.Text = uiPedido.Text + " " + i.Descripcion;
                        }
                    }
                    
                    if (itemMitad.Count > 0)
                    {
                        uiPedido.Text = uiPedido.Text + " //";

                        foreach (var i in itemMitad)
                        {
                            uiPedido.Text = uiPedido.Text + " " + i.Descripcion;
                        }
                    }

                
                

            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                                      "ERP",
                                      this.Name,
                                      ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void GetGuisos()
        {
            try
            {
                LimpiarBotonesGuisos();

                //lstGuisos = oContext.cat_productos
                //            .Where(w => w.ClaveFamilia == (int)Enumerados.Enumerados.familias.guisos).OrderBy(o => o.ProductoId).ToList();

                var guisos = oContext.cat_productos_guisos
                    .Where(w => w.ProductoId == productoIdSel && w.cat_guisos != null)
                    .Select(s => new
                    {
                        ProductoId = s.cat_guisos.cat_productos.ProductoId,
                        Descripcion = s.cat_guisos.cat_productos.Descripcion,
                        DescripcionCorta = s.cat_guisos.cat_productos.DescripcionCorta,
                        Clave = s.cat_guisos.cat_productos.Clave
                    }).ToList();

                lstGuisos = guisos.Select(
                        s => new cat_productos()
                        {
                            ProductoId = s.ProductoId,
                            Descripcion = s.Descripcion,
                            DescripcionCorta = s.DescripcionCorta,
                            Clave = s.Clave
                        }
                    ).ToList();



                if(lstGuisos.Count == 0)
                {
                    lstGuisos = oContext.cat_productos
                                .Where(w => w.ClaveFamilia == (int)Enumerados.Enumerados.familias.guisos).OrderBy(o => o.ProductoId).ToList();

                }

            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                                      "ERP",
                                      this.Name,
                                      ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void LlenarBotonesGuisos()
        {
            try
            {
                int i = 1;
                foreach (var item in lstGuisos)
                {
                    Control controlA = Controls.Find("btnG3_" + i.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        controlA.AccessibleName = item.ProductoId.ToString();
                        controlA.Text = item.DescripcionCorta;
                    }
                    i++;
                }

                numBtnGuisos_u = lstGuisos.Count;

                /*Deshabilitar botones son productos*/
                if ((lstGuisos.Count +1) <= numBtnGuisos)
                {
                    for (int j = (lstGuisos.Count + 1); j <= numBtnGuisos; j++)
                    {
                        Control controlA = Controls.Find("btnG3_" + j.ToString(), true).FirstOrDefault();
                        if (controlA != null)
                        {
                            controlA.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                             "ERP",
                             this.Name,
                             ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void LimpiarBotonesGuisos()
        {
            try
            {
                
                for (int i=0; i < numBtnGuisos; i++)
                {
                    Control controlA = Controls.Find("btnG3_" + i.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        controlA.Enabled = false;
                        controlA.Text = "";
                        controlA.AccessibleName = "";
                    }
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                            "ERP",
                            this.Name,
                            ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }
        private void LlenarBotonesBebidas()
        {
            Image img = null;
            try
            {
                int i = 1;
                foreach (var item in lstBebidasFiltro)
                {
                    Control controlA = Controls.Find("btnG5_" + i.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        controlA.AccessibleName = item.ProductoId.ToString();
                        controlA.Text = item.DescripcionCorta.ToUpper();
                        //img = GetImage(item.ProductoId);
                        //if(img!= null)
                        //{
                            
                        //    ((Button)controlA).BackgroundImage = img;
                        //    ((Button)controlA).BackgroundImageLayout = ImageLayout.Zoom;
                        //    ((Button)controlA).TextAlign = ContentAlignment.BottomLeft;
                        //}
                        //else
                        //{
                        //    controlA.BackgroundImage = null;
                        //}
                    }
                    i++;
                }

                /****Habilitar todos los botones****/
                for (int j = 1; j <= numBtnBebidas2; j++)
                {
                    Control controlA = Controls.Find("btnG5_" + j.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        controlA.Enabled = true;
                    }
                }


                numBtnBebidas2_u = lstBebidasFiltro.Count;

                /*Deshabilitar botones son productos*/
                if ((lstBebidasFiltro.Count + 1) <= numBtnBebidas2)
                {
                    for (int j = (lstBebidasFiltro.Count + 1); j <= numBtnBebidas2; j++)
                    {
                        Control controlA = Controls.Find("btnG5_" + j.ToString(), true).FirstOrDefault();
                        if (controlA != null)
                        {
                            controlA.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private Image GetImage(int prodctoId)
        {
            var imagenProd = lstProductosImg.Where(w => w.ProductoId == prodctoId && w.Principal == true).FirstOrDefault();
            if(imagenProd!= null)
            {
                using (var ms = new MemoryStream(imagenProd.FileByte))
                {
                    return Image.FromStream(ms);
                }
            }

            return null;

           
        }
        private void LimpiarBotones()
        {
            cantidadPaquetesInicial = 0;
            limiteMaxGuisoSeleccionValidar = false;
            limiteMaxGuisoSeleccion = 3;
            lstPaqueteDetalle = new List<string>();
            productoIdSel = 0;
            cobrandoAnticipo = false;
            uiCalculadora.Text="";
            btnCon = false;
            btnPor = false;
            btnSin = false;
            btnMitad = false;
            famBebida = 0;
            uiPedido.Text = "";
            itemSin = new List<cat_productos>();
            itemPor = new List<cat_productos>();
            itemCon = new List<cat_productos>();
            itemMitad = new List<cat_productos>();
            itemOtros = null;
            EnableBtnProd(true);
            EnableBtnG2(false, false, false, false);
            EnableBtnG3(false);
            EnableBtnG4(true);
            EnableBtnG5(false);
           
            btnG3_1.BackColor = Color.FromArgb(255,128,0);
            btnG3_2.BackColor = Color.FromArgb(255, 128, 0);
            btnG3_3.BackColor = Color.FromArgb(255, 128, 0);
            btnG3_4.BackColor = Color.FromArgb(255, 128, 0);
            btnG3_5.BackColor = Color.FromArgb(255, 128, 0);
            btnG3_6.BackColor = Color.FromArgb(255, 128, 0);
            btnG3_7.BackColor = Color.FromArgb(255, 128, 0);
            btnG3_8.BackColor = Color.FromArgb(255, 128, 0);
            btnG3_9.BackColor = Color.FromArgb(255, 128, 0);
            btnG3_10.BackColor = Color.FromArgb(255, 128, 0);
            btnG3_11.BackColor = Color.FromArgb(255, 128, 0);
            btnG3_12.BackColor = Color.FromArgb(255, 128, 0);
            btnG3_13.BackColor = Color.FromArgb(255, 128, 0);
            btnG3_14.BackColor = Color.FromArgb(255, 128, 0);
            btnG3_15.BackColor = Color.FromArgb(255, 128, 0);
            btnG3_16.BackColor = Color.FromArgb(255, 128, 0);
            btnG5_1.Text = "";
            btnG5_2.Text = "";
            btnG5_3.Text = "";
            btnG5_4.Text = "";
            btnG5_5.Text = "";
            btnG5_6.Text = "";
            btnG5_7.Text = "";
            btnG5_8.Text = "";
            btnG5_9.Text = "";
            btnG5_10.Text = "";
            btnG5_11.Text = "";
            btnG5_12.Text = "";
            btnG5_13.Text = "";
            btnG5_14.Text = "";
            btnG5_15.Text = "";
            btnG5_16.Text = "";

            GetGuisos();
            
            LlenarBotonesGuisos();

        }

        private void MarcarBoton(ref Button button)
        {
            button.BackColor = Color.Green;
        }


        private void ReajusteTextoPedido()
        {
            try
            {
                string descripcionPartida = uiPedido.Text + " ";

                if(botonSeleccionado == "SUR" && !descripcionPartida.Contains("S/"))
                {
                    if (descripcionPartida.Contains(" C ") && descripcionPartida.Contains(" CH "))
                    {
                        descripcionPartida = descripcionPartida.Replace(" C ", " 2C ");
                        descripcionPartida = descripcionPartida.Replace(" CH ", " 2CH ");
                    }
                    if (descripcionPartida.Contains(" C ") && !descripcionPartida.Contains(" CH "))
                    {
                        descripcionPartida = descripcionPartida.Replace(" C ", " C ");
                    }
                    if (!descripcionPartida.Contains(" C ") && descripcionPartida.Contains(" CH "))
                    {
                        descripcionPartida = descripcionPartida.Replace(" CH ", " CH ");
                    }

                }

                if (botonSeleccionado == "CARNE" &&
                    descripcionPartida.Trim().Length <= 11)
                {
                    if (descripcionPartida.Contains(" C ") && descripcionPartida.Contains(" CH "))
                    {
                        descripcionPartida = descripcionPartida.Replace(" C ", " 5C ");
                        descripcionPartida = descripcionPartida.Replace(" CH ", " 5CH ");
                    }
                    if (descripcionPartida.Contains(" C ") && !descripcionPartida.Contains(" CH "))
                    {
                        descripcionPartida = descripcionPartida.Replace(" C ", " 10C ");
                    }
                    if (!descripcionPartida.Contains(" C ") && descripcionPartida.Contains(" CH "))
                    {
                        descripcionPartida = descripcionPartida.Replace(" CH ", " CH ");
                    }

                }

                uiPedido.Text = descripcionPartida;
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void Sin(Button btn)
        {
            

            string id = btn.AccessibleName;

            //Si es un nuevo item, agregar y marcarel botón
            cat_productos item_clic = itemSin.Where(w => w.ProductoId.ToString() == id).FirstOrDefault();
            if (item_clic != null)
            {
                btn.BackColor = Color.FromArgb(255,128,0);
                itemSin.Remove(item_clic);
            }
            else
            {
                if(itemSin.Count <this.limiteMaxGuisoSeleccion)
                {
                    btn.BackColor = Color.Green;
                    itemSin.Add(new cat_productos() { ProductoId = Convert.ToInt32(id),Descripcion= btn.Text });
                   
                }
               
            }

            if (botonSeleccionado.Contains("ESP"))
            {
                EnableBtnG2(false, true, false, false);
            }
            else
            {
                if (itemSin.Count() > this.limiteMaxGuisoSeleccion)
                {
                    EnableBtnG2(false, false, false, false);
                }
                else
                {
                    EnableBtnG2(false, true, false, false);
                }
            }
            

            PedidoActualUpd(0,btn.Text);
            EnableBtnG4(false);
            EnableBtnG5(false);
           

        }

        private void Por(Button btn)
        {
            //string id = btn.AccessibleName;
            //int id_int = Convert.ToInt32(btn.AccessibleName);
            //itemPor = new List<cat_productos>();
            //itemPor.Add(new cat_productos() { ProductoId = id_int, Descripcion = btn.Text });
            //PedidoActualUpd(0,btn.Text);
            //EnableBtnG2(false, false, false, false);
            //EnableBtnG3(false);
            //EnableBtnG4(false);
            //EnableBtnG5(false);

            //btnPor = false;


            string id = btn.AccessibleName;

            //Si es un nuevo item, agregar y marcarel botón
            cat_productos item_clic = itemPor.Where(w => w.ProductoId.ToString() == id).FirstOrDefault();
            if (item_clic != null)
            {
                btn.BackColor = Color.FromArgb(255, 128, 0);
                itemPor.Remove(item_clic);
            }
            else
            {
                if (itemPor.Count < this.limiteMaxGuisoSeleccion)
                {
                    btn.BackColor = Color.Green;
                    itemPor.Add(new cat_productos() { ProductoId = Convert.ToInt32(id), Descripcion = btn.Text });

                }

            }
            EnableBtnG2(false, false, false, false);
            if (itemPor.Count() == this.limiteMaxGuisoSeleccion)
            {
                EnableBtnG3(false);
            }
            else
            {
                EnableBtnG3(true);
            }

            PedidoActualUpd(0,btn.Text);
            
            EnableBtnG4(false);
            EnableBtnG5(false);
            btnG3_1.Enabled = false;
            btnG3_2.Enabled = false;
            //btnPor = false;
        }
        private void Con(Button btn)
        {

            int cantidad = 0;
            string id = btn.AccessibleName;
            cantidad = uiCalculadora.Text.Length > 0 ? Convert.ToInt32(uiCalculadora.Text) : 0;           

            //Si es un nuevo item, agregar y marcarel botón
            cat_productos item_clic = itemCon.Where(w => w.ProductoId.ToString() == id).FirstOrDefault();
            if (item_clic != null)
            {
                btn.BackColor = Color.FromArgb(255, 128, 0);
                itemCon.Remove(item_clic);
               List<int> iRemove = new List<int>();
                //borrar de detalle
                for (int i = 0; i < lstPaqueteDetalle.Count; i++)
                {
                    if(lstPaqueteDetalle[i] == btn.Text)
                    {
                        iRemove.Add(i);
                    }
                }

                foreach (var item in iRemove)
                {
                    lstPaqueteDetalle.Remove(btn.Text);
                }
            }
            else
            {
                if(
                        (
                            //Asegurarse que el numero de guisos no sobrepase lo permitido
                            (
                               itemCon.Count < this.limiteMaxGuisoSeleccion                        
                            )
                            &&
                            (
                                lstPaqueteDetalle.Select(s=> s).Distinct().Count() 

                            ) <= this.limiteMaxGuisoSeleccion
                            &&
                            //Asegurarse que el numero de tacos en el pedido no sobrepase lo permitido
                            ((lstPaqueteDetalle.Count() + (cantidad == 0 ? 1 : cantidad) <= cantidadPaquete && cantidadPaquete>0) || cantidadPaquete == 0)
                            &&
                            //Asegurarse que el numero de tacos de Carne y Chicharron no sopbrepase lo permitido
                            (lstPaqueteDetalle.Where(w=> w == "C" || w=="CH").Count() <= limiteCarneChicharron) 
                        )
                        

                )
                {
                    btn.BackColor = Color.Green;
                    itemCon.Add(new cat_productos() { ProductoId = Convert.ToInt32(id),Descripcion = btn.Text, ClaveLote = (cantidad==0?1:cantidad) });
                    //Agregar a detalle
                    for (int i = 0; i < (cantidad == 0 ? 1 : cantidad) ; i++)
                    {
                        lstPaqueteDetalle.Add(btn.Text);
                    }

                }

            }       

            uiCalculadora.Text = "";

            PedidoActualUpd(cantidad,btn.Text);
            if(botonSeleccionado.Contains("ESP") && !uiPedido.Text.Contains("S/"))
            {
                EnableBtnG2(true, false, false, false);
            }
            
            EnableBtnG4(false);
            EnableBtnG5(false);

            if (!ValidarConsumoInterno(uiConsumo.Checked))
            {
                return;
            }

        }

        private void Mitad(Button btn)
        {


            string id = btn.AccessibleName;

            //Si es un nuevo item, agregar y marcarel botón
            cat_productos item_clic = itemMitad.Where(w => w.ProductoId.ToString() == id).FirstOrDefault();
            if (item_clic != null)
            {
                btn.BackColor = Color.FromArgb(255, 128, 0);
                itemMitad.Remove(item_clic);
            }
            else
            {
                if (
                    (itemMitad.Count < 2 && productoIdSel==1)
                    ||
                    (itemMitad.Count < 3 && productoIdSel != 1)
                    )
                {
                    btn.BackColor = Color.Green;
                    itemMitad.Add(new cat_productos() { ProductoId = Convert.ToInt32(id), Descripcion = btn.Text });

                }

            }

            

            PedidoActualUpd(0,btn.Text);
            EnableBtnG4(false);
            EnableBtnG5(false);
            

        }

        private void CalcularImpuestosProd()
        {
            try
            {
                for (int i = 0; i < lstPedido.Count; i++)
                {
                    int prodId = lstPedido[i].productoId;
                    cat_productos prodEntity = oContext.cat_productos.Where(w => w.ProductoId == prodId).FirstOrDefault();

                    if (prodEntity != null)
                    {
                        decimal? porcImpuestos = prodEntity.cat_productos_impuestos.Count > 0 ?
                            prodEntity.cat_productos_impuestos.Sum(w => w.cat_impuestos.Porcentaje) : 0;

                        lstPedido[i].porcImpuestos = porcImpuestos??0;
                        lstPedido[i].totalImpuestos = ERP.Utils.CalculosContaTool.DesgloceIVA(lstPedido[i].total, porcImpuestos??0).impuestos;
                    }
                }
                
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void Calculadora(string digit)
        {
            try
            {
                if (uiCalculadora.Text.Contains(".") && digit.Contains("."))
                    return;

                string value = uiCalculadora.Text.ToString();
                value = value + digit;


                uiCalculadora.Text = value;

                if(cobrando && !cobrandoAnticipo )
                {
                    cobrandoCalc();
                }
                if (cobrando && cobrandoAnticipo)
                {
                    cobrandoCalcAnticipo();
                }
            }
            catch (Exception)
            {

                
            }
        }

        private void GetSubFamBebidas()
        {
            try
            {
                /***Obtener las subfanilias del tipo familia BEBIDA*/

                if(lstSubFamBebidas == null)
                {
                    lstSubFamBebidas = oContext.cat_subfamilias
                        .Where(
                        w =>                         
                        w.cat_productos.Where(p=> p.Estatus == true && p.ProdParaVenta == true).Count() > 0 &&
                        (w.cat_familias.Descripcion.ToUpper().Contains("BEBIDA") ||
                        w.cat_familias.Descripcion.ToUpper().Contains("REFRESCO") ||
                        w.cat_familias.Descripcion.ToUpper().Contains("INDIVIDUAL") ||
                        w.cat_familias.Descripcion.ToUpper().Contains("SALSA") )
                        ).ToList();

                    numBtnBebidas1_u = lstSubFamBebidas.Count;
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                            "ERP",
                            this.Name,
                            ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void GetAllBebidas()
        {
            try
            {
                /***Obtenertodas las bebidas*/

                if (lstBebidas == null)
                {

                    lstBebidas = oContext.cat_productos.Where(w => (w.ClaveFamilia == (int)Enumerados.Enumerados.familias.bebidas))
                                    .ToList();

                    numBtnBebidas1_u = lstSubFamBebidas.Count;
                }
               
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                            "ERP",
                            this.Name,
                            ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }
        private void GetBebidasBySubFam(int subFam)
        {
            try
            {
                /***Obtener las subfanilias del tipo familia BEBIDA*/
                oContext = new ERPProdEntities();
                lstBebidasFiltro = oContext.cat_productos.Where(w => w.ClaveSubFamilia == subFam )
                                .ToList();              

                LlenarBotonesBebidas();

            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                                      "ERP",
                                      this.Name,
                                      ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void LlenarBotonesBebidasSubFam()
        {
            try
            {
                int i = 1;
                foreach (var item in lstSubFamBebidas)
                {
                    Control controlA = Controls.Find("btnG4_" + i.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        controlA.AccessibleName = item.Clave.ToString();
                        controlA.Text = item.Descripcion;
                    }
                    i++;
                }

                

                /*Deshabilitar botones son productos*/
                if ((lstSubFamBebidas.Count + 1) <= numBtnBebidas1)
                {
                    for (int j = (lstSubFamBebidas.Count + 1); j <= numBtnBebidas1; j++)
                    {
                        Control controlA = Controls.Find("btnG4_" + j.ToString(), true).FirstOrDefault();
                        if (controlA != null)
                        {
                            controlA.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                          "ERP",
                          this.Name,
                          ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }    

       


        private void CalcularTotales()
        {
            try
            {
                if (cobrandoAnticipo)
                {
                    uiTotal.Text = cantidadAnticipo.ToString("c2");
                }
                else
                {
                    uiTotal.Text = lstPedido.Sum(s => s.total).ToString("c2");
                }
                
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                          "ERP",
                          this.Name,
                          ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        

        private void Checks(bool paraMesa, bool paraLlevar, bool cortesia, bool consumo, bool precioEmp)
        {
            try
            {
                
                if (paraMesa)
                {
                    uiLlevar.Checked = false; ;

                    for (int i = 0; i < lstPedido.Count; i++)
                    {
                        lstPedido[i].paraMesa = uiMesa.Checked;
                        lstPedido[i].paraLlevar = false;
                    }

                    grProducto.DataSource = lstPedido;
                    gvProducto.RefreshData();
                }
                if (paraLlevar)
                {
                    uiMesa.Checked = false;

                    for (int i = 0; i < lstPedido.Count; i++)
                    {
                        lstPedido[i].paraLlevar = uiLlevar.Checked;
                        lstPedido[i].paraMesa = false;
                    }

                    grProducto.DataSource = lstPedido;
                    gvProducto.RefreshData();
                }
                if (cortesia)
                {
                    for (int i = 0; i < lstPedido.Count; i++)
                    {
                        lstPedido[i].cortesia = uiCortesia.Checked;                       

                    }
                    grProducto.DataSource = lstPedido;
                    gvProducto.RefreshData();

                   
                }
                if (consumo)
                {
                    uiCortesia.Checked = false;
                    uiCortesia.Enabled = !uiConsumo.Checked;
                    uiPrecioEmp.Checked = false;
                    uiPrecioEmp.Enabled = !uiConsumo.Checked;
                    uiEmpleado.Visible = uiConsumo.Checked;
                    for (int i = 0; i < lstPedido.Count; i++)
                    {
                        lstPedido[i].cortesia = false;
                        lstPedido[i].consumoInterno = uiConsumo.Checked;

                    }
                    grProducto.DataSource = lstPedido;
                    gvProducto.RefreshData();

                }
                if (precioEmp)
                {
                    uiEmpleado.Visible = uiPrecioEmp.Checked;

                    uiConsumo.Enabled = !uiPrecioEmp.Checked;
                    uiCortesia.Enabled = !uiPrecioEmp.Checked;
                    uiConsumo.Checked = false;
                    uiCortesia.Checked = false;

                    for (int i = 0; i < lstPedido.Count; i++)
                    {
                        lstPedido[i].cortesia = false;
                        lstPedido[i].consumoInterno = false;
                        lstPedido[i].precioEmpleado = uiPrecioEmp.Checked;

                    }
                    grProducto.DataSource = lstPedido;
                    gvProducto.RefreshData();
                }


                for (int i = 0; i < lstPedido.Count; i++)
                {
                    if ( uiConsumo.Checked || uiCortesia.Checked || uiPrecioEmp.Checked)
                    {
                        if (uiConsumo.Checked)
                        {
                            lstPedido[i].totalDescuento = (lstPedido[i].precioUnitario * lstPedido[i].cantidad) ;
                            lstPedido[i].total = 0;
                            lstPedido[i].porcDescuento = 100;
                        }
                        if (uiCortesia.Checked)
                        {
                            lstPedido[i].totalDescuento = lstPedido[i].precioOriginal * lstPedido[i].cantidad;
                            lstPedido[i].total = 0;
                        }
                        if (uiPrecioEmp.Checked)
                        {
                            descuentoEmpleado= ERP.Business.ProductoBusiness.ObtenerDescuentoEmpleado(lstPedido[i].productoId, puntoVentaContext.sucursalId, ref error);

                            lstPedido[i].totalDescuento = (descuentoEmpleado * lstPedido[i].cantidad);
                            lstPedido[i].total = (lstPedido[i].precioOriginal * lstPedido[i].cantidad) - lstPedido[i].totalDescuento;
                            lstPedido[i].porcDescuento = 0;
                        }

                    }
                    else
                    {
                        lstPedido[i].porcDescuento = 0;
                        lstPedido[i].totalDescuento =0;
                        lstPedido[i].total = (lstPedido[i].precioUnitario * lstPedido[i].cantidad);
                    }

                }
                
                CalcularTotales();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
        }

        private void ChecksGrid(bool paraMesa, bool paraLlevar, bool cortesia, bool consumo, int rowHandle)
        {
            try
            {
                
                if (paraMesa)
                {
                    gvProducto.SetRowCellValue(rowHandle, "paraLlevar", false);
                    gvProducto.SetRowCellValue(rowHandle, "paraMesa", true);
                }
                if (paraLlevar)
                {
                    gvProducto.SetRowCellValue(rowHandle, "paraMesa", false);
                    gvProducto.SetRowCellValue(rowHandle, "paraLlevar", true);
                }
                if (cortesia)
                {
                    gvProducto.SetRowCellValue(rowHandle, "consumoInterno", false);

                }

                if (consumo)
                {
                    gvProducto.SetRowCellValue(rowHandle, "cortesia", false);

                }

                PedidoDetalleModel row = (PedidoDetalleModel)gvProducto.GetRow(rowHandle);
                cortesia = paraLlevar || paraMesa ? Convert.ToBoolean(gvProducto.GetRowCellValue(rowHandle, "cortesia")): cortesia;
                consumo = paraLlevar || paraMesa ? Convert.ToBoolean(gvProducto.GetRowCellValue(rowHandle, "consumoInterno")):consumo;

                if (cortesia || consumo)
                {
                    if(cortesia)
                    {
                        gvProducto.SetRowCellValue(rowHandle, "totalDescuento", row.precioOriginal * row.cantidad);
                        gvProducto.SetRowCellValue(rowHandle, "total", 0);
                    }
                    if(consumo)
                    {
                        gvProducto.SetRowCellValue(rowHandle, "totalDescuento", (row.precioOriginal * row.cantidad));
                        gvProducto.SetRowCellValue(rowHandle, "total", 0);
                        gvProducto.SetRowCellValue(rowHandle, "porcDescuento", 100);
                    }
                    
                }
                else
                {
                    if (Convert.ToBoolean(gvProducto.GetRowCellValue(rowHandle, "precioEmpleado")))
                    {
                        descuentoEmpleado = ERP.Business.ProductoBusiness.ObtenerDescuentoEmpleado(
                            Convert.ToInt32(gvProducto.GetRowCellValue(rowHandle, "productoId")), puntoVentaContext.sucursalId, ref error) * row.cantidad;

                        gvProducto.SetRowCellValue(rowHandle, "totalDescuento", descuentoEmpleado );
                        gvProducto.SetRowCellValue(rowHandle, "total", (row.precioOriginal * row.cantidad) - descuentoEmpleado);
                        gvProducto.SetRowCellValue(rowHandle, "porcDescuento", 0);
                    }
                    else
                    {
                        gvProducto.SetRowCellValue(rowHandle, "totalDescuento", 0);
                        gvProducto.SetRowCellValue(rowHandle, "total", row.precioOriginal * row.cantidad);
                    }
                    
                }

                CalcularTotales();



            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
        }

        private void actualizar(int rowHandle,decimal cantidad)
        {
            try
            {
                bool cortesia;
                bool consumo;
                bool precioEmpleado;
                decimal precioOriginal = Convert.ToDecimal(gvProducto.GetRowCellValue(rowHandle, "precioOriginal"));
                decimal porcDescEmpleado=entityConfiguracion.EmpleadoPorcDescuento ?? 0;
                
                cortesia =Convert.ToBoolean( gvProducto.GetRowCellValue(rowHandle, "cortesia"));
                consumo = Convert.ToBoolean(gvProducto.GetRowCellValue(rowHandle, "consumoInterno"));
                precioEmpleado = Convert.ToBoolean(gvProducto.GetRowCellValue(rowHandle, "precioEmpleado"));

                gvProducto.SetRowCellValue(rowHandle, "totalDescuento",0);
                gvProducto.SetRowCellValue(rowHandle, "total", (precioOriginal * cantidad) );
                gvProducto.SetRowCellValue(rowHandle, "porcDescuento", 0);

                if (cortesia)
                {
                    gvProducto.SetRowCellValue(rowHandle, "totalDescuento", precioOriginal * cantidad);
                    gvProducto.SetRowCellValue(rowHandle, "total", 0);
                }
                if (consumo)
                {
                    gvProducto.SetRowCellValue(rowHandle, "totalDescuento", (precioOriginal * cantidad));
                    gvProducto.SetRowCellValue(rowHandle, "total", 0);
                    gvProducto.SetRowCellValue(rowHandle, "porcDescuento", 100);
                }

                if (precioEmpleado)
                {
                    gvProducto.SetRowCellValue(rowHandle, "totalDescuento", (precioOriginal * cantidad) * (porcDescEmpleado / 100));
                    gvProducto.SetRowCellValue(rowHandle, "total", (precioOriginal * cantidad) - (precioOriginal * cantidad) * (porcDescEmpleado / 100));
                    gvProducto.SetRowCellValue(rowHandle, "porcDescuento", porcDescEmpleado);
                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }


        private void LlenarLkpEmpleado()
        {
            try
            {
                uiEmpleado.Properties.DataSource = oContext.rh_empleados.ToList();

            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void cobrar()
        {
            try
            {
                if(((List<PedidoDetalleModel>)grProducto.DataSource).Where(
                    f=> f.paraLlevar == false && f.paraMesa == false).Count() ==
                    ((List<PedidoDetalleModel>)grProducto.DataSource).Count())
                {
                    uiLlevar.Checked = true;
                }

                if (uiConsumo.Checked && uiEmpleado.EditValue == null)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("EL EMPLEADO ES REQUERIDO");
                    return;
                }
                #region marcar para Llevar si es pedido
                if (esPedidoConAnticipo)
                {
                    for (int i = 0; i < lstPedido.Count; i++)
                    {
                        lstPedido[i].paraLlevar = true;
                        lstPedido[i].paraMesa = false;
                    }
                }
                #endregion
                #region validar
                lstPedido = (List<PedidoDetalleModel>)grProducto.DataSource;

                if (lstPedido.Count == 0)
                {
                    XtraMessageBox.Show("NO HAY PRODUCTOS QUE COBRAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (lstPedido.Where(w => !w.paraLlevar && !w.paraMesa).Count() > 0)
                {
                    XtraMessageBox.Show("UNA O MAS PARTIDAS NO TIENEN SELECCIONADO EL TIPO DE SERVICIO(PARA LLEVAR O MESA)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(!paqTacoIndividualCompleto())
                {
                    XtraMessageBox.Show("LOS PAQUETES DE TACO INDIVIDUAL ESTÁN INCOMPLETOS. TACOS INDIVIDUALES:" +
                           lstPedido.Where(w => w.nombreFamilia.Contains("TACO INDIVIDUAL")).Sum(s => s.cantidad).ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion
                cobrando = true;
                EnableBtnProd(false);
                EnableBtnG2(false, false, false, false);
                EnableBtnG3(false);
                EnableBtnG4(false);
                EnableBtnG5(false);
               
                
                button49.Enabled = false;
                btnClr.Enabled = false;
                uiAnticipo.Enabled = false;
                uiEnter.Enabled = true;
                if (cobrando && !cobrandoAnticipo)
                {
                    frmVentaFormasPagoDialog oFormasPago = new frmVentaFormasPagoDialog();

                    oFormasPago.lstFormasPago = this.lstFormasPago;
                    oFormasPago.totalVenta = lstPedido.Sum(s => s.total);
                    oFormasPago.StartPosition = FormStartPosition.CenterScreen;
                    var resultDailog = oFormasPago.ShowDialog();

                    if(resultDailog == DialogResult.OK)
                    {
                        abrirCajon();
                        retiroAcumulado = retiroAcumulado + lstPedido.Sum(s => s.total);
                        this.lstFormasPago = oFormasPago.lstFormasPago;
                        uiCalculadora.EditValue = lstFormasPago.Sum(s => s.cantidad);

                        cobrandoCalc();

                        ConfirmarPago();

                        aplicarRetiroAutomatico();
                    }
                    else {
                        cobrandoCalc();
                    }

                    
                }
                if (cobrando && cobrandoAnticipo)
                {
                    cobrandoCalcAnticipo();
                }
                
                
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }
        private void abrirCajon()
        {
            string error = RawPrinterHelper.AbreCajon(this.puntoVentaContext.nombreImpresoraCaja);

            if (error.Length > 0)
            {
                XtraMessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cobrarDeshabilitar()
        {
            cobrando = false;
           
            button49.Enabled = true;
            btnClr.Enabled = true;
            itemSin = new List<cat_productos>();
            itemPor = new List<cat_productos>();
            itemCon = new List<cat_productos>();
            itemMitad = new List<cat_productos>();
            LimpiarBotones();
            CalcularTotales();
            uiRecibi.Text = "$0.00";
            uiCambio.Text = "$0.00";
            uiFaltan.Text = "$0.00";


        }

        private void cobrandoCalc()
        {
            try
            {
                 valorCalc = 0;
                 valorRecibi = 0;
                 valorCambio = 0;
                 valorTotal = 0;
                 valorFaltan = 0;

                decimal.TryParse(uiCalculadora.Text, out valorCalc);

                valorTotal = lstPedido.Sum(s => (s.total - s.totalDescuento) <0 ? 0 : (s.total - s.totalDescuento));

                valorRecibi = valorCalc;

                valorCambio = valorRecibi - valorTotal < 0 ? 0 : valorRecibi - valorTotal;

                valorFaltan = valorTotal - valorRecibi <0 ? 0 : valorTotal - valorRecibi;

                uiRecibi.Text = valorRecibi.ToString("c2");
                uiCambio.Text = valorCambio.ToString("c2");
                uiFaltan.Text = valorFaltan.ToString("c2");


            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void cobrandoCalcAnticipo()
        {
            try
            {
                valorCalc = 0;
                valorRecibi = 0;
                valorCambio = 0;
                valorTotal = 0;
                valorFaltan = 0;

                decimal.TryParse(uiCalculadora.Text, out valorCalc);

                valorTotal = cantidadAnticipo;

                valorRecibi = valorCalc;

                valorCambio = valorRecibi - valorTotal < 0 ? 0 : valorRecibi - valorTotal;

                valorFaltan = valorTotal - valorRecibi < 0 ? 0 : valorTotal - valorRecibi;

                uiRecibi.Text = valorRecibi.ToString("c2");
                uiCambio.Text = valorCambio.ToString("c2");
                uiFaltan.Text = valorFaltan.ToString("c2");


            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                         "ERP",
                         this.Name,
                         ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }
        private void clicBebida(Button btn)
        {
            try
            {
                EnableBtnProd(false);
                EnableBtnG2(false, false, false, false);
                EnableBtnG3(false);
                EnableBtnG4(false);
                EnableBtnG5(true);
               
                famBebida = Convert.ToInt32(btn.AccessibleName);

                GetBebidasBySubFam(famBebida);
            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void clicBebida2(Button btn)
        {
            try
            {
                
                productoIdSel = Convert.ToInt32(btn.AccessibleName);

                itemOtros = lstBebidasFiltro.Where(w => w.ProductoId == productoIdSel).FirstOrDefault();
                PedidoActualUpd(0,itemOtros.DescripcionCorta);

            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                         "ERP",
                         this.Name,
                         ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void clicOtros(Button btn)
        {
            try
            {
                int id;
                int.TryParse(btn.AccessibleName, out id);
                productoIdSel = id;

                itemOtros = new cat_productos() { Clave = id.ToString(), ProductoId = id, Descripcion = btn.Text };

                EnableBtnProd(false);
                EnableBtnG2(false, false, false, false);
                EnableBtnG3(false);
                EnableBtnG4(false);
                EnableBtnG5(false);
               
                PedidoActualUpd(0,"");
            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                            "ERP",
                            this.Name,
                            ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }           
           
        }

        public string guardarTemporal(string notas, ERP.Business.Enumerados.tipoPedido tipoPedido)
        {
            try
            {
                if(lstPedido.Count == 0)
                {
                    XtraMessageBox.Show("No tiene productos agregados", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
                string error = "";

                ConexionBD.PedidoOrdenBusiness ordenB = new PedidoOrdenBusiness();


                #region orden
                doc_pedidos_orden orden = new doc_pedidos_orden();

                orden.PedidoId = pedidoId;
                orden.Activo = true;
                orden.ClienteId = programacion.cat_clientes.ClienteId;
                orden.ComandaId = null;
                orden.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                orden.CreadoPor = puntoVentaContext.usuarioId;
                orden.Descuento = 0;
                orden.FechaApertura = orden.CreadoEl;
                orden.FechaCierre = orden.CreadoEl;
                orden.Impuestos = 0;
                orden.MotivoCancelacion = "";
                orden.PedidoId = lstPedido.Count == 0 ? 0 : lstPedido.FirstOrDefault().pedidoId;
                orden.Personas = 1;
                orden.PorcDescuento = 0;
                orden.Subtotal = 0;
                orden.SucursalId = puntoVentaContext.sucursalId;
                orden.Total = 0;
                orden.Para = "";
                orden.Notas = notas;
                orden.TipoPedidoId = (int)tipoPedido;
                #endregion

                #region ordenDetalle   
                lstPedido = (List<PedidoDetalleModel>)gvProducto.DataSource;
                List<doc_pedidos_orden_detalle> lstPedidoDetalle = new List<doc_pedidos_orden_detalle>();
                foreach (var itemPedido in lstPedido)
                {
                    doc_pedidos_orden_detalle ordenDet = new doc_pedidos_orden_detalle();


                    ordenDet.Cantidad = itemPedido.cantidad;
                    ordenDet.CreadoEl = orden.CreadoEl;
                    ordenDet.CreadoPor = puntoVentaContext.usuarioId;
                    ordenDet.Descuento = itemPedido.totalDescuento;
                    ordenDet.Impuestos = itemPedido.totalImpuestos;
                    ordenDet.Notas = "";
                    ordenDet.PorcDescuento = itemPedido.porcDescuento; ;
                    ordenDet.PrecioUnitario = 0;
                    ordenDet.ProductoId = itemPedido.productoId;
                    ordenDet.TasaIVA = 0;
                    ordenDet.Total = 0;
                    ordenDet.TipoDescuentoId = itemPedido.cortesia ? (byte)ERP.Business.Enumerados.tipoDescuento.cortesia :
                                                            itemPedido.consumoInterno ? (byte)ERP.Business.Enumerados.tipoDescuento.descuentoEmpleado : (byte)0;

                    ordenDet.Parallevar = itemPedido.paraLlevar;
                    ordenDet.PedidoDetalleId = itemPedido.pedidoDetalleId;
                    ordenDet.Descripcion = itemPedido.descripcion;
                    lstPedidoDetalle.Add(ordenDet);
                }
                
               

                
                
                #endregion

                int meseroId = 1;

                List<int> lstSinIngredientes = new List<int>();
               
               
                List<int> adicionalesId = new List<int>();

                int comandaId = 0;

              

                error = ordenB.GuardarOrdenCompleta(ref orden, ref lstPedidoDetalle,programacion, null, 0, lstSinIngredientes.ToArray(),
                       adicionalesId.ToArray(), ref comandaId, false, puntoVentaContext);


                

                if (error.Length > 0)
                {
                    XtraMessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return error;
                }
                else
                {
                    imprimirComanda(orden.PedidoId);

                    //XtraMessageBox.Show("OK. El registro se guardó correctamente", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Inicializar();
                    return "";
                }
               

            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                      "ERP",
                      this.Name,
                      ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
                throw;
            }
        }



        public void registrarPedidoConAnticipo()
        {
            try
            {
                int pagoId=0;
                if (lstPedido.Count == 0)
                {
                    XtraMessageBox.Show("No tiene productos agregados", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return ;
                }
                #region validar lo recibido
                if(cantidadAnticipo > 0)
                {
                    if(uiCalculadora.Text.Trim() == "")
                    {
                        XtraMessageBox.Show("Falta ingresar la cantidad recibida en la calculadora", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (valorFaltan > 0)
                        {

                            XtraMessageBox.Show("La cantidad recibida no cubre el pago especificado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                
                #endregion


                string error = "";

                ConexionBD.PedidoOrdenBusiness ordenB = new PedidoOrdenBusiness();


                #region nueva orden
                doc_pedidos_orden orden;
                lstPedido = (List<PedidoDetalleModel>)gvProducto.DataSource;
                List<doc_pedidos_orden_detalle> lstPedidoDetalle = new List<doc_pedidos_orden_detalle>();
                if (this.pedidoId == 0)
                {
                    orden = new doc_pedidos_orden();

                    orden.PedidoId = pedidoId;
                    orden.Activo = true;
                    orden.ClienteId = programacion.cat_clientes.ClienteId;
                    orden.ComandaId = null;
                    orden.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                    orden.CreadoPor = puntoVentaContext.usuarioId;
                    orden.Descuento = 0;
                    orden.FechaApertura = orden.CreadoEl;
                    orden.FechaCierre = orden.CreadoEl;
                    orden.Impuestos = 0;
                    orden.MotivoCancelacion = "";
                    orden.PedidoId = lstPedido.Count == 0 ? 0 : lstPedido.FirstOrDefault().pedidoId;
                    orden.Personas = 1;
                    orden.PorcDescuento = 0;
                    orden.Subtotal = 0;
                    orden.SucursalId = puntoVentaContext.sucursalId;
                    orden.Total = 0;
                    orden.Para = "";
                    orden.Notas = notas;
                    orden.TipoPedidoId = (int)ERP.Business.Enumerados.tipoPedido.PedidoClienteMayoreo;
                    orden.Facturar = uiFactura.Checked;
                    #region ordenDetalle   
                    
                    lstPedidoDetalle = new List<doc_pedidos_orden_detalle>();
                    foreach (var itemPedido in lstPedido)
                    {
                        doc_pedidos_orden_detalle ordenDet = new doc_pedidos_orden_detalle();


                        ordenDet.Cantidad = itemPedido.cantidad;
                        ordenDet.CreadoEl = orden.CreadoEl;
                        ordenDet.CreadoPor = puntoVentaContext.usuarioId;
                        ordenDet.Descuento = itemPedido.totalDescuento;
                        ordenDet.Impuestos = itemPedido.totalImpuestos;
                        ordenDet.Notas = "";
                        ordenDet.PorcDescuento = itemPedido.porcDescuento; ;
                        ordenDet.PrecioUnitario = itemPedido.precioUnitario;
                        ordenDet.ProductoId = itemPedido.productoId;
                        ordenDet.TasaIVA = 0;
                        ordenDet.Total = itemPedido.total;
                        ordenDet.TipoDescuentoId = itemPedido.cortesia ? (byte)ERP.Business.Enumerados.tipoDescuento.cortesia :
                                                                itemPedido.consumoInterno ? (byte)ERP.Business.Enumerados.tipoDescuento.descuentoEmpleado : (byte)0;

                        ordenDet.Parallevar = itemPedido.paraLlevar;
                        ordenDet.PedidoDetalleId = itemPedido.pedidoDetalleId;
                        ordenDet.Descripcion = itemPedido.descripcion;
                        lstPedidoDetalle.Add(ordenDet);
                    }





                    #endregion
                }

                #endregion

                else
                {
                    orden = this.pedido;
                    lstPedidoDetalle = this.pedido.doc_pedidos_orden_detalle.ToList();
                }



                int meseroId = 1;

                List<int> lstSinIngredientes = new List<int>();


                List<int> adicionalesId = new List<int>();

                int comandaId = 0;



                error = ordenB.GuardarPedidoAnticipo(ref orden, ref lstPedidoDetalle, programacion, null, 0, lstSinIngredientes.ToArray(),
                       adicionalesId.ToArray(), ref comandaId, false, cantidadAnticipo,ref pagoId, puntoVentaContext);

                if (error.Length > 0)
                {
                    XtraMessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    #region venta
                    int cargoId = orden.CargoId??0;
                    oContext = new ERPProdEntities();

                    doc_cargos oCargo = oContext.doc_cargos.Where(w => w.CargoId == cargoId).FirstOrDefault();

                    if (oCargo.Saldo == 0)
                    {



                        long ventaId = 0;
                        CalcularImpuestosProd();

                        List<ProductoModel0> lstProductosPago = new List<ProductoModel0>();

                        int i = 1;
                        foreach (var itemPedido in lstPedido)
                        {
                            ProductoModel0 itemProdPago = new ProductoModel0();

                            itemProdPago.cantidad = itemPedido.cantidad;
                            itemProdPago.clave = itemPedido.clave;
                            itemProdPago.descripcion = itemPedido.descripcion;
                            itemProdPago.impuestos = itemPedido.totalImpuestos;
                            itemProdPago.montoDescuento = itemPedido.totalDescuento;
                            itemProdPago.partida = i;
                            itemProdPago.porcDescuento = 0;
                            itemProdPago.porcDescuentoPartida = itemPedido.porcDescuento;
                            itemProdPago.porcDescunetoVta = 0;
                            itemProdPago.porcImpuestos = itemPedido.porcImpuestos;
                            itemProdPago.precioUnitario = itemPedido.precioUnitario;
                            itemProdPago.productoId = itemPedido.productoId;
                            itemProdPago.tipoDescuentoId = (int)ConexionBD.Enumerados.tipoDescuento.DESCUENTO_EMPLEADO;
                            itemProdPago.total = itemPedido.total;
                            itemProdPago.unidadId = itemPedido.unidadId;
                            pedidoId = pedidoId > 0 ? pedidoId : itemPedido.pedidoId;
                            i++;

                            lstProductosPago.Add(itemProdPago);
                        }

                        lstFormasPago = new List<FormaPagoModel>();
                        FormaPagoModel itemFormaPago = new FormaPagoModel();
                        itemFormaPago.cantidad = valorRecibi;
                        itemFormaPago.id = 1;
                        lstFormasPago.Add(itemFormaPago);

                        ConexionBD.PuntoVenta puntoVenta = new ConexionBD.PuntoVenta();

                        error = puntoVenta.pagar(ref ventaId, null, "", 0, 0, lstPedido.Sum(s => s.totalDescuento), lstPedido.Sum(s => s.totalImpuestos),
                            lstPedido.Sum(s => s.total) - lstPedido.Sum(s => s.totalImpuestos),
                            lstPedido.Sum(s => s.total),
                            lstPedido.Sum(s => s.total), 0, false,
                            puntoVentaContext.sucursalId,
                            puntoVentaContext.usuarioId,
                            puntoVentaContext.cajaId,
                            lstProductosPago,
                            lstFormasPago,
                            new List<ValeFPModel>(),
                            pedidoId,
                            uiFactura.Checked);

                        if (error.Length > 0)
                        {
                            XtraMessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                            
                        }
                        else
                        {
                           

                            #region imprimir ticket de venta
                            cat_configuracion entity = entityConfiguracion;

                            if (lstPedido.Sum(s => s.total) >= (entity.MontoImpresionTicket ?? 0))
                            {
                                imprimirTicket((int)ventaId);
                                imprimirTicket((int)ventaId);
                            }
                            #endregion
                        }
                    }
                    #endregion

                   
                    ERP.Reports.rptPedidoPagoTicket oTicket2 = new ERP.Reports.rptPedidoPagoTicket();

                    List<p_rpt_pedido_pago_ticket_Result> resultPedidoTicket = oContext.p_rpt_pedido_pago_ticket(pagoId, orden.PedidoId).ToList();

                    ERP.Common.Reports.ReportViewer oViewer = new ERP.Common.Reports.ReportViewer(this.puntoVentaContext.cajaId);
                    oContext = new ERPProdEntities();
                    oTicket2.DataSource = resultPedidoTicket;

                     oViewer.ShowTicket(oTicket2);
                    oViewer = new ERP.Common.Reports.ReportViewer(this.puntoVentaContext.cajaId);
                    oTicket2.DataSource = resultPedidoTicket;
                    oViewer.ShowTicket(oTicket2);
                
                    
                    //imprimirComanda(orden.PedidoId);

                     XtraMessageBox.Show("OK. El pedido y anticipo se guardaron correctamente", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    Inicializar();
                        
                   

                  
                }

                frmMenuRestTA.GetInstance().selectTabPuntoVenta();
            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                         "ERP",
                         this.Name,
                         ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
                uiEnter.Enabled = true;

            }
        }


        public string obtenerCuenta(int cuentaId)
        {
            try
            {
                uiCalculadora.Text = "";
                oContext = new ERPProdEntities();
                doc_pedidos_orden orden = oContext.doc_pedidos_orden
                    .Where(w => w.PedidoId == cuentaId).FirstOrDefault();
                this.pedido = orden;

                lstPedido = new List<PedidoDetalleModel>();

                foreach (var item in orden.doc_pedidos_orden_detalle)
                {
                    PedidoDetalleModel d = new PedidoDetalleModel();

                    d.cantidad = item.Cantidad;
                    d.clave = item.cat_productos.Clave;
                    d.consumoInterno = item.TipoDescuentoId == (int)ERP.Business.Enumerados.tipoDescuento.descuentoEmpleado ? true : false;
                    d.cortesia = item.TipoDescuentoId == (int)ERP.Business.Enumerados.tipoDescuento.cortesia ? true : false;                    
                    d.paraLlevar = item.Parallevar??false;
                    d.paraMesa = !d.paraLlevar;
                    d.pedidoDetalleId = item.PedidoDetalleId;
                    d.pedidoId = item.PedidoId;
                    d.porcDescuento = item.PorcDescuento;
                    d.porcImpuestos = 0;
                    d.precioOriginal = item.PrecioUnitario;
                    d.precioUnitario = item.PrecioUnitario;
                    d.productoId = item.ProductoId;
                    d.total = item.Total;
                    d.totalDescuento = item.Total * (d.porcDescuento / 100);
                    d.totalImpuestos = item.Impuestos;
                    d.unidad = item.cat_productos.cat_unidadesmed.Descripcion;
                    d.unidadId = item.cat_productos.ClaveUnidadMedida??0;
                    d.descripcion = item.Descripcion;

                    lstPedido.Add(d);
                }

                grProducto.DataSource = lstPedido;
                grProducto.Refresh();
                gvProducto.RefreshData();

                lblNotas.Text = orden.Notas;
                notas = orden.Notas;
                CalcularTotales();

                pedidoId = orden.PedidoId;

                if(orden.doc_pedidos_orden_programacion != null)
                {
                    programacion = orden.doc_pedidos_orden_programacion.FirstOrDefault();

                    refrescarAvisoVentaTelefono();
                }

                if(orden.CargoId > 0)
                {
                    esPedidoConAnticipo = true;
                    esVentaPorTelefono = false;
                    DisableAll();
                    uiPedidoResumen.Enabled = true;
                    uiAnticipo.Enabled = true;
                    EnableCalculadora(true);
                  
                    button51.Enabled = false;
                    button49.Enabled = false;
                    btnClr.Enabled = false;
                    uiPedidoRefresh.Visible = true;
                    mostrarSaldoPedido();
                }
                else
                {
                    esPedidoConAnticipo = false;
                    esVentaPorTelefono = true;
                }

                frmMenuRestTA.GetInstance().EnableMenu(true, true, true, true, true);
                return "";
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                      "ERP",
                      this.Name,
                      ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
                return ex.Message;
            }
        }

        public void removeDet()
        {
            try
            {
                int rowHandle = gvProducto.FocusedRowHandle;
                if(rowHandle >= 0)
                {
                    if (XtraMessageBox.Show("¿Está seguro(a) de continuar?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                          PedidoDetalleModel entityDel = (PedidoDetalleModel)gvProducto.GetRow(rowHandle);

                            if (entityDel != null)
                            {
                                if (entityDel.pedidoDetalleId > 0)
                                {
                                    int id = entityDel.pedidoDetalleId;
                                    doc_pedidos_orden_detalle entityDet = oContext.doc_pedidos_orden_detalle
                                        .Where(w => w.PedidoDetalleId == id).FirstOrDefault();


                                    oContext.doc_pedidos_orden_detalle.Remove(entityDet);
                                    oContext.SaveChanges();
                                }



                                gvProducto.DeleteRow(rowHandle);

                                lstPedido = (List<PedidoDetalleModel>)gvProducto.DataSource;

                                CalcularTotales();
                            }

                       
                    }

                }



            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                                      "ERP",
                                      this.Name,
                                      ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        public void obtenerVenta(int _ventaId)
        {
            try
            {
                ventaId = _ventaId;
                doc_ventas venta = oContext.doc_ventas
                    .Where(w => w.VentaId == ventaId).FirstOrDefault();

                if(venta != null)
                { 

                    lstPedido = new List<PedidoDetalleModel>();
                    uiFactura.Checked = venta.Facturar??false;
                    if(venta.doc_pedidos_orden.Count == 0)
                    {
                        foreach (var item in venta.doc_ventas_detalle)
                        {
                            PedidoDetalleModel d = new PedidoDetalleModel();

                            d.cantidad = item.Cantidad ?? 0;
                            d.clave = item.cat_productos.Clave;
                            d.consumoInterno = item.TipoDescuentoId == (int)ERP.Business.Enumerados.tipoDescuento.descuentoEmpleado ? true : false;
                            d.cortesia = item.TipoDescuentoId == (int)ERP.Business.Enumerados.tipoDescuento.cortesia ? true : false;
                            d.descripcion = item.Descripcion != null ? item.Descripcion : item.cat_productos.DescripcionCorta;
                            d.paraMesa = !d.paraLlevar;

                            d.pedidoId = venta.doc_pedidos_orden.Count > 0 ? venta.doc_pedidos_orden.FirstOrDefault().PedidoId : 0;
                            d.porcDescuento = item.PorcDescuneto;
                            d.porcImpuestos = 0;
                            d.precioOriginal = item.PrecioUnitario;
                            d.precioUnitario = item.PrecioUnitario;
                            d.productoId = item.ProductoId;
                            d.total = item.Total;
                            d.totalDescuento = item.Total * (d.porcDescuento / 100);
                            d.totalImpuestos = item.Impuestos;
                            d.unidad = item.cat_productos.cat_unidadesmed.Descripcion;
                            d.unidadId = item.cat_productos.ClaveUnidadMedida ?? 0;

                            lstPedido.Add(d);
                        }

                        grProducto.DataSource = lstPedido;
                        grProducto.Refresh();
                        gvProducto.RefreshData();
                        
                        CalcularTotales();
                    }
                    else
                    {
                        obtenerCuenta(venta.doc_pedidos_orden.FirstOrDefault().PedidoId);
                    }

                    DisableAll();
                    frmMenuRestTA.GetInstance().EnableMenu(true, false, true, true, true);
                }
                else
                {
                    XtraMessageBox.Show("No fue posible obtener la venta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                       "ERP",
                       this.Name,
                       ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void EnableCalculadora(bool enable)
        {
            btnRegresar.Enabled = enable;
            btn0.Enabled = enable;
            btn1.Enabled = enable;
            btn2.Enabled = enable;
            btn3.Enabled = enable;
            btn4.Enabled = enable;
            btn5.Enabled = enable;
            btn6.Enabled = enable;
            btn7.Enabled = enable;
            btn8.Enabled = enable;
            btn9.Enabled = enable;
            button47.Enabled = enable;
            btnClr.Enabled = enable;
            button49.Enabled = enable;
            
            button51.Enabled = enable;
            
        }

        private void DisableAll()
        {
            try
            {
                EnableBtnG2(false,false,false,false);
                EnableBtnG3(false);
                EnableBtnG4(false);
                EnableBtnG5(false);
              
                EnableBtnProd(false);
                colRepo.Visible = false;
                uiEnter.Enabled = false;
                EnableCalculadora(false);
                uiMesa.Enabled = false;
                uiLlevar.Enabled = false;
                uiCortesia.Enabled = false;
                uiConsumo.Enabled = false;
                uiAnticipo.Enabled = false;
                uiPedidoResumen.Enabled = false;

            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                      "ERP",
                      this.Name,
                      ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        public void cancelarCuenta()
        {
            try
            {
                if(pedidoId == 0)
                {
                    XtraMessageBox.Show("No hay ninguna cuenta seleccionada", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    frmAdminPass oAdmin = new frmAdminPass();
                    oAdmin.StartPosition = FormStartPosition.CenterScreen;
                    oAdmin.ShowDialog();

                    if (oAdmin.DialogResult == DialogResult.OK)
                    {
                        frmPedidoCancelacion oform = new frmPedidoCancelacion();
                        oform.pedidoId = pedidoId;
                        oform.nuevaComanda = false;
                        oform.puntoVentaContext = this.puntoVentaContext;
                        oform.StartPosition = FormStartPosition.CenterParent;
                        oform.ShowDialog();
                        
                        if(oform.DialogResult == DialogResult.OK)
                        {
                            Inicializar();
                        }
                    }
                }
            }
            catch (Exception )
            {

                XtraMessageBox.Show("Ocurrió un error inesperado (cancelarCuenta)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void abrirVentaPOrTelefono()
        {
            if(lstPedido.Count > 0)
            {
                esPedidoConAnticipo = false;
                esVentaPorTelefono = true;

                frmVentaTelefono oForm = new frmVentaTelefono(true);
                oForm.programacion = this.programacion;
                oForm.StartPosition = FormStartPosition.CenterParent;
                oForm.ShowDialog();

                uiAnticipo.Enabled = false;
                
            }
            else
            {
                XtraMessageBox.Show("No hay productos agregados para venta", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        public void abrirPedido()
        {
            if(porcAnticipoPedido <=0)
            {
                XtraMessageBox.Show("No hay porcentaje de anticipo configurado, no es posible crear un pedido. Es necesario avisar al Administrador",
                    "Aviso", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
                return;
            }
            if (lstPedido.Count > 0)
            {
                esPedidoConAnticipo = true;
                esVentaPorTelefono = false;
                frmVentaTelefono oForm = new frmVentaTelefono(false);
                oForm.programacion = this.programacion;
                oForm.StartPosition = FormStartPosition.CenterParent;
                oForm.ShowDialog();
                uiAnticipo.Enabled = true;
                

            }
            else
            {
                XtraMessageBox.Show("No hay productos agregados para venta", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        public void refrescarAvisoVentaTelefono()
        {
            try
            {
                string aviso = "";

               
                if (programacion.doc_pedidos_orden != null && programacion.doc_pedidos_orden.Notas.Length > 0)
                {
                    uiPedido.Text = programacion.doc_pedidos_orden.Notas;
                    notas = programacion.doc_pedidos_orden.Notas;
                }
                else
                {
                    if (programacion.FechaProgramada.Year > 2000)
                    {
                        aviso = "PEDIDO: ";
                        aviso = aviso + programacion.cat_clientes.Nombre;
                        aviso = aviso + " " + programacion.FechaProgramada.ToShortDateString();
                        aviso = aviso + " " + programacion.HoraProgramada.ToString(@"hh\:mm");

                        uiPedido.Text = aviso;
                        notas = notas.Length == 0 ? aviso : notas;
                    }
                    else
                    {
                        uiPedido.Text = "";
                    }
                }
                
            }
            catch (Exception)
            {

               
            }
            
        }


        public void cancelarTicket()
        {
            try
            {
                oContext = new ERPProdEntities();

                

                if (ventaId == 0)
                {
                    MessageBox.Show("Es necesario buscar primero una venta", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                doc_ventas venta = oContext.doc_ventas.Where(w => w.VentaId == ventaId).FirstOrDefault();

                if (!venta.Activo)
                {
                    MessageBox.Show("NO ES POSIBLE VOLVER A CANCELAR EL TICKET", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                

                frmCancelarTicket oFrm = new frmCancelarTicket();
                oFrm.ventaId = ventaId;
                oFrm.StartPosition = FormStartPosition.CenterParent;
                oFrm.puntoVentaContext = this.puntoVentaContext;
                oFrm.ShowDialog();

                if(oFrm.DialogResult == DialogResult.OK)
                {
                    imprimirTicket(ventaId);
                    Inicializar();
                }

            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }

        }

        #endregion

        #region eventos

        private void guardarCantidadInicial()
        {
            if(uiCalculadora.Text != "")
            {
                cantidadPaquetesInicial = Convert.ToInt32(uiCalculadora.Text);

                uiCalculadora.Text = "";
            }
            
        }

        private void btnProd1_Click(object sender, EventArgs e)
        {
            guardarCantidadInicial();

            SeleccionarProducto(((Button)sender).AccessibleName, ((Button)sender).Text);
            if (uiConsumo.Checked)
            {
                if (!botonSeleccionado.Contains("SUR") && !botonSeleccionado.Contains("LIBRE"))
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("SOLO SE PERMITE SUR Y LIBRE PARA CONSUMO INTERNO");
                    return;
                }
            }

            EnableBtnProd(false);
            EnableBtnG2(true, false, true, false);

            //SeleccionarProducto(((Button)sender).AccessibleName, ((Button)sender).Text);
            //EnableBtnProd(false);
            //EnableBtnG2(false, false, false, false);
            EnableBtnG3(false);
            EnableBtnG4(false);
            EnableBtnG5(false);

            limiteMaxGuisoSeleccion = 3;
            limiteCarneChicharron = 4;
            cantidadPaquete = 10;

        }

        private void ClicProducto(object sender)
        {
            
        
            if (btnSin)
            {

                Sin((Button)sender);
            }
            if (btnPor)
            {
                Por(((Button)sender));
            }
            if (btnCon)
            {
                if (botonSeleccionado.Contains("ESP"))
                {
                    if (((Button)sender).Text != "C" && ((Button)sender).Text != "CH" && uiPedido.Text.Replace(botonSeleccionado, "") == "")
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("PRIMERO SELECCIONE CARNE O CHICHARRON");
                        return;
                    }
                }
                Con(((Button)sender));
            }
            if (btnMitad)
            {
                Mitad(((Button)sender));
            }
            if (botonSeleccionado.Contains("ESP") && uiPedido.Text == "ESP")
            {
                uiPedido.Text = uiPedido.Text + " "+ ((Button)sender).Text;
                EnableBtnG2(true, false, true, false);
                btnG3_1.Enabled = false;
                btnG3_2.Enabled = false;
                itemCon.Add(new cat_productos() { Descripcion = ((Button)sender).Text ,DescripcionCorta = ((Button)sender).Text });
            }
            
        }

        private void btnG3_1_Click(object sender, EventArgs e)
        {

            ClicProducto(sender);


        }

        private void btnProd3_Click(object sender, EventArgs e)
        {
            guardarCantidadInicial();
            limiteMaxGuisoSeleccion = 3;
            limiteMaxGuisoSeleccionValidar = false;
            SeleccionarProducto(((Button)sender).AccessibleName, ((Button)sender).Text);
            if (uiConsumo.Checked)
            {
                if (!botonSeleccionado.Contains("SUR") && !botonSeleccionado.Contains("LIBRE"))
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("SOLO SE PERMITE SUR Y LIBRE PARA CONSUMO INTERNO");
                    return;
                }
            }
            EnableBtnProd(false);
            EnableBtnG2(false,false,true,false);
            EnableBtnG3(false);
            EnableBtnG4(false);
            EnableBtnG5(false);
           
        }

       

        private void btnProd4_Click(object sender, EventArgs e)
        {
            guardarCantidadInicial();
            SeleccionarProducto(((Button)sender).AccessibleName, ((Button)sender).Text);
            if (uiConsumo.Checked)
            {
                if (!botonSeleccionado.Contains("SUR") && !botonSeleccionado.Contains("LIBRE"))
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("SOLO SE PERMITE SUR Y LIBRE PARA CONSUMO INTERNO");
                    return;
                }
            }
            EnableBtnProd(false);
            EnableBtnG2(true, false, true, false);
            EnableBtnG3(false);
            EnableBtnG4(false);
            EnableBtnG5(false);

            limiteMaxGuisoSeleccion = 2;
        }

        private void btnProd5_Click(object sender, EventArgs e)
        {
            guardarCantidadInicial();
            SeleccionarProducto(((Button)sender).AccessibleName, ((Button)sender).Text);
            if (uiConsumo.Checked)
            {
                if (!botonSeleccionado.Contains("SUR") && !botonSeleccionado.Contains("LIBRE"))
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("SOLO SE PERMITE SUR Y LIBRE PARA CONSUMO INTERNO");
                    return;
                }
            }

            EnableBtnProd(false);
            EnableBtnG2(true, false, true, true);
            EnableBtnG3(false);
            EnableBtnG4(false);
            EnableBtnG5(false);

            limiteMaxGuisoSeleccion = 2;
        }    
       

        private void button46_Click(object sender, EventArgs e)
        {
            LimpiarBotones();
        }

        private void btnProd6_Click(object sender, EventArgs e)
        {
            guardarCantidadInicial();
            SeleccionarProducto(((Button)sender).AccessibleName, ((Button)sender).Text);
            if (uiConsumo.Checked)
            {
                if (!botonSeleccionado.Contains("SUR") && !botonSeleccionado.Contains("LIBRE"))
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("SOLO SE PERMITE SUR Y LIBRE PARA CONSUMO INTERNO");
                    return;
                }
            }
            EnableBtnG2(false, false, false, false);
            EnableBtnG3(false);
            EnableBtnG4(false);
            EnableBtnG5(false);
           
        }

        private void btnProd2_Click(object sender, EventArgs e)
        {
            guardarCantidadInicial();
            limiteMaxGuisoSeleccionValidar = false;
            SeleccionarProducto(((Button)sender).AccessibleName, ((Button)sender).Text);
            if (uiConsumo.Checked)
            {
                if (!botonSeleccionado.Contains("SUR") && !botonSeleccionado.Contains("LIBRE"))
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("SOLO SE PERMITE SUR Y LIBRE PARA CONSUMO INTERNO");
                    return;
                }
            }

            EnableBtnProd(false);
            EnableBtnG2(false, false, false, false);
            EnableBtnG3(false);
            EnableBtnG4(false);
            EnableBtnG5(false);

            limiteMaxGuisoSeleccion = 6;
            limiteCarneChicharron = 6;
            cantidadPaquete = 10;
            btnG3_1.Enabled = true;
            btnG3_2.Enabled = true;

        }

        private void btnG2_1_Click_1(object sender, EventArgs e)
        {
            btnSin = true;
            btnCon = false;


            PedidoActualUpd(0,((Button)sender).Text);
            EnableBtnG2(false, true, false, false);
            EnableBtnG3(true);

            if (productoIdSel == (int)productosTacosAna.ESPECIAL ||
                productoIdSel == (int)productosTacosAna.P1_2ESPECIAL
                )
            {
                btnG3_1.Enabled = false;
            }
            if(botonSeleccionado == "ESP")
            {
                btnG3_1.Enabled = false;
                //btnG3_2.Enabled = false;
            }
        }

        private void btnG2_2_Click(object sender, EventArgs e)
        {

            btnPor = true;
            PedidoActualUpd(0,((Button)sender).Text);
            if (btnSin)
            {
                ((Button)sender).Enabled = false;

                if(itemSin.Count == 1)
                {
                    //Deshabilitar boton seleccionado en el Sin
                    for (int i = 1; i < 6; i++)
                    {
                        Control controlA = Controls.Find("btnG3_" + i.ToString(), true).FirstOrDefault();

                        if(controlA.AccessibleName == itemSin[0].ProductoId.ToString())
                        {
                            controlA.Enabled = false;
                            break;
                        }
                    }
                }

                btnSin = false;
            }
            else
            {
                EnableBtnG2(false, false, false, false);
                EnableBtnG3(true);
            }

            if (botonSeleccionado.Contains("SUR"))
            {
                btnG3_1.Enabled = false;
                btnG3_2.Enabled = false;
            }
            
            
           
        }

        private void btnG2_3_Click(object sender, EventArgs e)
        {
            btnCon = true;
            
            EnableBtnG2(false, false, false, false);
            EnableBtnG3(true);
            EnableBtnG4(false);
            EnableBtnG5(false);

            if(this.botonSeleccionado == "ESP")
            {
                btnG3_1.Enabled = false;
                btnG3_2.Enabled = false;
            }
            else
            {
                PedidoActualUpd(0, ((Button)sender).Text);
            }
           
        }

        private void btnG2_4_Click(object sender, EventArgs e)
        {
            btnMitad = true;
            PedidoActualUpd(0,((Button)sender).Text);
            EnableBtnG2(false, false, false, false);
            EnableBtnG3(true);
            btnG3_1.Enabled = false;
            EnableBtnG4(false);
            EnableBtnG5(false);
           

            if (productoIdSel == (int)productosTacosAna.ESPECIAL
                || productoIdSel == (int)productosTacosAna.P1_2ESPECIAL)
            {
                btnG3_1.Enabled = false;
            }
        }

        private void btnG3_2_Click(object sender, EventArgs e)
        {
            ClicProducto(sender);
        }

        private void btnG3_3_Click(object sender, EventArgs e)
        {
            ClicProducto(sender);
        }

        private void btnG3_4_Click(object sender, EventArgs e)
        {
            ClicProducto(sender);
        }

        private void btnG3_5_Click(object sender, EventArgs e)
        {
            ClicProducto(sender);
        }

        private void btnG3_6_Click(object sender, EventArgs e)
        {
            ClicProducto(sender);
        }
        
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                
                if(cobrandoAnticipo)
                {
                    registrarPedidoConAnticipo();
                }
                else
                {
                    ReajusteTextoPedido();
                    //Validaciones de Consumo Interno
                    if (!ValidarConsumoInterno(uiConsumo.Checked))
                    {
                        return;
                    }
                    
                    if (cobrando && !cobrandoAnticipo)
                    {

                        //Confirmar Pago
                        ConfirmarPago();
                   


                    }
                    else
                    {


                        if (productoIdSel == 0)
                            return;
                        PedidoDetalleModel item = new PedidoDetalleModel();
                        cat_productos prodSel = lstProductos.Where(w => w.ProductoId == productoIdSel).FirstOrDefault();

                        if(limiteMaxGuisoSeleccion > 3 && limiteMaxGuisoSeleccionValidar)
                        {
                            if(lstPaqueteDetalle.Count() != limiteMaxGuisoSeleccion)
                            {
                                ERP.Utils.MessageBoxUtil.ShowError(String.Format("El paquete debe de ser de {0}",limiteMaxGuisoSeleccion));
                                return;
                            }
                        }
                        if(lstPaqueteDetalle.Where(w=> w=="C" || w=="CH").Count() > limiteCarneChicharron && limiteCarneChicharron > 0)
                        {
                            ERP.Utils.MessageBoxUtil.ShowError("El paquete excede el limite de tacos de carne y chicharron");
                            return;
                        }

                        if (itemOtros != null)
                        {
                            prodSel.Descripcion = "";
                            prodSel.DescripcionCorta = "";
                        }


                        decimal cantidad;

                        decimal.TryParse(uiCalculadora.EditValue.ToString(), out cantidad);


                        item.key = lstPedido.Count + 1;
                        item.cantidad = cantidadPaquetesInicial == 0 ? (cantidad == 0 ? 1 : cantidad) : cantidadPaquetesInicial;
                        item.clave = prodSel.Clave;
                        item.descripcion = uiPedido.Text;
                        item.familiaId = prodSel.ClaveFamilia??0;
                        item.nombreFamilia = prodSel.cat_familias.Descripcion;
                        if (prodSel.cat_productos_precios.Count == 0)
                        {
                            XtraMessageBox.Show("El producto no tiene precio", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        item.precioUnitario = prodSel.cat_productos_precios.FirstOrDefault().Precio;
                        item.productoId = prodSel.ProductoId;

                        item.unidad = prodSel.cat_unidadesmed.Descripcion;
                        item.precioOriginal = item.precioUnitario;
                        item.unidadId = prodSel.cat_unidadesmed.Clave;

                        if (uiPrecioEmp.Checked)
                        {
                            item.totalDescuento =
                                 ERP.Business.ProductoBusiness.ObtenerDescuentoEmpleado(item.productoId,puntoVentaContext.sucursalId,ref error)* item.cantidad;
                        }
                        if (uiConsumo.Checked)
                        {
                            item.totalDescuento = (item.precioUnitario * item.cantidad) ;
                        }

                        item.total = (item.cantidad * item.precioUnitario) - item.totalDescuento;
                        item.paraLlevar = esPedidoConAnticipo ?true : item.paraLlevar;
                        item.paraMesa = esPedidoConAnticipo ? false : item.paraMesa;
                        item.precioEmpleado = uiPrecioEmp.Checked;
                        item.consumoInterno = uiConsumo.Checked;
                        lstPedido.Add(item);

                        grProducto.DataSource = lstPedido;
                        grProducto.Refresh();
                        gvProducto.RefreshData();
                        cobrandoAnticipo = false;
                        cantidadAnticipo = 0;
                        CalcularTotales();
                        LimpiarBotones();

                        if(item.nombreFamilia.Contains("TACO INDIVIDUAL"))
                        {
                            SeleccionarTacoIndividual();
                        }
                        
                    
                    }
                }
                uiKeyCatch.Focus();
            }
            catch (Exception ex)
            {
                uiKeyCatch.Focus();
                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                             "ERP",
                             this.Name,
                             ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void ConfirmarPago()
        {
            int empleadoId = Convert.ToInt32(uiEmpleado.EditValue);

            int? clienteId = empleadoId == 0 ? null : (int?)oContext.rh_empleados
                .Where(w => w.NumEmpleado == empleadoId).FirstOrDefault().cat_clientes.FirstOrDefault().ClienteId;

            if (valorFaltan > 0)
            {
                XtraMessageBox.Show("No se ha recibido el total de la venta", "AVISO",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ConexionBD.PuntoVenta puntoVenta = new ConexionBD.PuntoVenta();
            int pedidoId = 0;

            if (valorFaltan > 0)
            {
                XtraMessageBox.Show("Faltan " + valorFaltan.ToString("c2"), "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                string error = "";

                #region validar comsumo interno
                if (
                    Convert.ToInt32(uiEmpleado.EditValue == null ? 0 : uiEmpleado.EditValue) == 0
                        && (uiPrecioEmp.Checked || uiConsumo.Checked)
                    )
                {
                    XtraMessageBox.Show("No se ha seleccionado el empleado apra el consumo interno", "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return;
                }
                #endregion
                long ventaId = 0;
                //CalcularImpuestosProd();

                List<ProductoModel0> lstProductosPago = new List<ProductoModel0>();
                                
                pedidoId = pedidoId > 0 ? pedidoId : lstPedido.Max(m=> m.pedidoId);

                lstProductosPago = lstPedido.Select(s => new ProductoModel0() {
                        cantidad = s.cantidad,
                    clave = s.clave,
                    descripcion = s.descripcion,
                    impuestos = s.totalImpuestos,
                    montoDescuento = s.totalDescuento,
                    partida = 1,
                    porcDescuento = 0,
                    porcDescuentoPartida = s.porcDescuento,
                    porcDescunetoVta = 0,
                    porcImpuestos = s.porcImpuestos,
                    precioUnitario = s.precioUnitario,
                    productoId = s.productoId,
                    tipoDescuentoId = (int)ConexionBD.Enumerados.tipoDescuento.DESCUENTO_EMPLEADO,
                    total = s.total,
                    unidadId = s.unidadId,
                    paraLlevar = s.paraLlevar,
                    paraMesa = s.paraMesa
                }).ToList();

                if (lstFormasPago.Count() == 0)
                {
                    lstFormasPago = new List<FormaPagoModel>();

                    FormaPagoModel itemFormaPago = new FormaPagoModel();
                    itemFormaPago.cantidad = valorRecibi;
                    itemFormaPago.id = 1;
                    lstFormasPago.Add(itemFormaPago);
                }




                #region nueva orden
                doc_pedidos_orden orden = null;
                lstPedido = (List<PedidoDetalleModel>)gvProducto.DataSource;
                List<doc_pedidos_orden_detalle> lstPedidoDetalle = new List<doc_pedidos_orden_detalle>();
                if (this.pedidoId == 0)
                {
                    orden = new doc_pedidos_orden();

                    orden.PedidoId = pedidoId;
                    orden.Activo = true;
                    orden.ClienteId = null;
                    orden.ComandaId = null;
                    orden.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                    orden.CreadoPor = puntoVentaContext.usuarioId;
                    orden.Descuento = 0;
                    orden.FechaApertura = orden.CreadoEl;
                    orden.FechaCierre = orden.CreadoEl;
                    orden.Impuestos = 0;
                    orden.MotivoCancelacion = "";
                    orden.PedidoId = lstPedido.Count == 0 ? 0 : lstPedido.FirstOrDefault().pedidoId;
                    orden.Personas = 1;
                    orden.PorcDescuento = 0;
                    orden.Subtotal = 0;
                    orden.SucursalId = puntoVentaContext.sucursalId;
                    orden.Total = 0;
                    orden.Para = "";
                    orden.Notas = notas;
                    orden.TipoPedidoId = (int)ERP.Business.Enumerados.tipoPedido.PedidoVentaCaja;
                    orden.Facturar = uiFactura.Checked;
                    #region ordenDetalle   

                    lstPedidoDetalle = new List<doc_pedidos_orden_detalle>();
                    foreach (var itemPedido in lstPedido)
                    {
                        doc_pedidos_orden_detalle ordenDet = new doc_pedidos_orden_detalle();


                        ordenDet.Cantidad = itemPedido.cantidad;
                        ordenDet.CreadoEl = orden.CreadoEl;
                        ordenDet.CreadoPor = puntoVentaContext.usuarioId;
                        ordenDet.Descuento = itemPedido.totalDescuento;
                        ordenDet.Impuestos = itemPedido.totalImpuestos;
                        ordenDet.Notas = "";
                        ordenDet.PorcDescuento = itemPedido.porcDescuento; ;
                        ordenDet.PrecioUnitario = itemPedido.precioUnitario;
                        ordenDet.ProductoId = itemPedido.productoId;
                        ordenDet.TasaIVA = 0;
                        ordenDet.Total = itemPedido.total;
                        ordenDet.TipoDescuentoId = itemPedido.cortesia ? (byte)ERP.Business.Enumerados.tipoDescuento.cortesia :
                                                                itemPedido.consumoInterno ? (byte)ERP.Business.Enumerados.tipoDescuento.descuentoEmpleado : (byte)0;

                        ordenDet.Parallevar = itemPedido.paraLlevar;
                        ordenDet.PedidoDetalleId = itemPedido.pedidoDetalleId;
                        ordenDet.Descripcion = itemPedido.descripcion;
                        lstPedidoDetalle.Add(ordenDet);
                    }





                    #endregion


                    int meseroId = 1;

                    List<int> lstSinIngredientes = new List<int>();
                    List<int> lstMesas = new List<int>();

                    List<int> adicionalesId = new List<int>();

                    int comandaId = 0;
                    oPedidoOrden = new PedidoOrdenBusiness();
                    error = oPedidoOrden.GuardarPedido(ref orden, ref lstPedidoDetalle, programacion, lstMesas.ToArray(), 0, lstSinIngredientes.ToArray(),
                    adicionalesId.ToArray(), ref comandaId, false, puntoVentaContext);

                    if (error.Length > 0)
                    {
                        XtraMessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    

                    pedidoId = orden.PedidoId;
                }

                #endregion


                error = puntoVenta.pagar(ref ventaId, clienteId, "", 0, 0, lstPedido.Sum(s => s.totalDescuento), lstPedido.Sum(s => s.totalImpuestos),
                   lstPedido.Sum(s => s.total) - lstPedido.Sum(s => s.totalImpuestos),
                   lstPedido.Sum(s => s.total),
                   valorRecibi, valorCambio, false,
                   puntoVentaContext.sucursalId,
                   puntoVentaContext.usuarioId,
                   puntoVentaContext.cajaId,
                   lstProductosPago,
                   lstFormasPago,
                   new List<ValeFPModel>(),
                   pedidoId,
                   uiFactura.Checked);

                if (error.Length > 0)
                {
                    XtraMessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    
                    cat_configuracion entity =entityConfiguracion;

                    if (pedido.TipoPedidoId == (int)ERP.Business.Enumerados.tipoPedido.PedidoClienteMayoreo || pedido.TipoPedidoId == null)
                    {
                        imprimirComanda(pedidoId);
                    }

                    

                    if (lstPedido.Sum(s => s.total) >= (entity.MontoImpresionTicket ?? 0))
                    {                        

                        imprimirTicket((int)ventaId);   

                    }


                    Inicializar();
                    abrirCajon();



                }


            }
        }

        private void imprimirTicket(int ventaId)
        {
            try
            {
                ERP.Reports.TacosAna.rptVentaTicket oTicket2 = new ERP.Reports.TacosAna.rptVentaTicket(ventaId);

                

                //ERP.Common.Reports.ReportViewer oViewer = new ERP.Common.Reports.ReportViewer(puntoVentaContext.sucursalId,this.puntoVentaContext.cajaId,false);

                oTicket2.DataSource = oContext.p_rpt_VentaTicket(ventaId).ToList();

                //oViewer.ShowTicket(oTicket2);



                // Configura la impresora
                PrinterSettings printerSettings = new PrinterSettings();
                printerSettings.PrinterName = ERP.Business.DataMemory.DataBucket.entityImpresoraCaja.NombreRed;
                //printerSettings.DefaultPageSettings.PaperSize = new PaperSize("Custom", 800, 32767); // 80mm x 32767mm (altura máxima)

                // Crea un objeto PrintDocument
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrinterSettings = printerSettings;

                // Asocia el informe con el PrintDocument
                oTicket2.Run();
                printDocument.PrintPage += (sender, e) =>
                {
                    e.HasMorePages = false; // Establece esto en false para imprimir una sola página

                    oTicket2.Document.Print(false);

                };

                // Imprime el informe
                printDocument.Print();

               

            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                               "ERP",
                               this.Name,
                               ex);

                //Si hubo un error al reimprimir , REINTENTAR
                if (XtraMessageBox.Show("¿REINTENTAR REIMPRIMIR TICKET?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    imprimirTicket(ventaId);
                }
                else
                {
                    ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
                }
            }
        }

        private void imprimirComanda(int pedidoId)
        {
            try
            {
               
                rptComanda oReport = new rptComanda();
                oReport.DataSource = oContext.p_rpt_Comanda(pedidoId, 0, true, "").ToList();
                oReport.CreateDocument();
                conf = entityConfiguracion;
                if (conf.vistaPreviaImpresion == true)
                {
                    oReport.ShowPreview();
                }
                else
                {
                    oReport.Print(entityImpresoraComanda.NombreRed);
                }

            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                              "ERP",
                              this.Name,
                              ex);

                //Si hubo un error al reimprimir , REINTENTAR
                if (XtraMessageBox.Show("¿REINTENTAR REIMPRIMIR COMANDA?","Aviso", MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    imprimirComanda(pedidoId);
                }
                else
                {
                    ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
                }

                
               
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            Calculadora("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            Calculadora("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            Calculadora("9");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            Calculadora("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            Calculadora("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            Calculadora("6");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Calculadora("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Calculadora("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            Calculadora("3");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            Calculadora("0");
        }

        private void button47_Click(object sender, EventArgs e)
        {
            Calculadora(".");
        }

        private void button52_Click(object sender, EventArgs e)
        {
            Inicializar();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            if(uiCalculadora.Text.Length > 0)
            {
                uiCalculadora.Text = uiCalculadora.Text.Remove(uiCalculadora.Text.Length - 1, 1);
            }



            if (cobrando && !cobrandoAnticipo)
            {
                cobrandoCalc();
            }
            if (cobrando && cobrandoAnticipo)
            {
                cobrandoCalcAnticipo();
            }
        }

       

        private void btnG4_1_Click(object sender, EventArgs e)
        {

            clicBebida((Button)sender);
            
        }

        private void btnG4_2_Click(object sender, EventArgs e)
        {
            clicBebida((Button)sender);

        }

       

        private void btnG5_1_Click(object sender, EventArgs e)
        {

            clicBebida2((Button)sender);
                
        }

        private void btnG5_2_Click(object sender, EventArgs e)
        {
            clicBebida2((Button)sender);
        }

        private void btnG5_3_Click(object sender, EventArgs e)
        {
            clicBebida2((Button)sender);
        }

        private void btnG4_3_Click(object sender, EventArgs e)
        {
            clicBebida((Button)sender);

        }

        private void btnG4_4_Click(object sender, EventArgs e)
        {
            clicBebida((Button)sender);

        }

        private void btnG4_5_Click(object sender, EventArgs e)
        {
           
            clicBebida((Button)sender);

        }

      

        #endregion

        private void uiMesa_CheckedChanged(object sender, EventArgs e)
        {
            Checks(true,false,false,false,false);
        }

        private void uiLlevar_CheckedChanged(object sender, EventArgs e)
        {
            Checks(false, true, false, false, false);
        }

        private void uiConsumo_CheckedChanged(object sender, EventArgs e)
        {
            Checks(false, false, false, true, false);
        }

        private void uiCortesia_CheckedChanged(object sender, EventArgs e)
        {
            Checks(false, false, true, false, false);
        }

        private void uiEmpleado_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void uiPrecioEmp_CheckedChanged(object sender, EventArgs e)
        {
            Checks(false, false, false, false, true);
        }

       

       

        private void gvProducto_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
            if(e.Column.FieldName =="paraLlevar")
            {   
                ChecksGrid(false,Convert.ToBoolean(e.Value), false, false, e.RowHandle);
            }
            if (e.Column.FieldName == "paraMesa")
            {
                ChecksGrid(Convert.ToBoolean(e.Value), false, false, false, e.RowHandle);
            }
            if (e.Column.FieldName == "cortesia")
            {
                ChecksGrid(false, false, Convert.ToBoolean(e.Value), false, e.RowHandle);
            }
            if (e.Column.FieldName == "consumoInterno")
            {
                ChecksGrid(false, false, false, Convert.ToBoolean(e.Value), e.RowHandle);
            }

            if (e.Column.FieldName == "precioEmpleado")
            {
                ChecksGrid(false, false, false, false, e.RowHandle);
            }

            if (e.Column.FieldName == "cantidad")
            {
                actualizar(e.RowHandle,Convert.ToDecimal(e.Value==""?"0":e.Value));
            }


        }

        private void button51_Click(object sender, EventArgs e)
        {
            cobrar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cobrarDeshabilitar();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            try
            {
                int rowHandle = gvProducto.FocusedRowHandle;

                if (rowHandle < 0)
                {
                    XtraMessageBox.Show("SELECCIONE UNA PARTIDA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    gvProducto.DeleteRow(rowHandle);
                    CalcularTotales();
                }
            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                                      "ERP",
                                      this.Name,
                                      ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void btnProd7_Click(object sender, EventArgs e)
        {
            guardarCantidadInicial();
            SeleccionarProducto(((Button)sender).AccessibleName, ((Button)sender).Text);
            if (uiConsumo.Checked)
            {
                if (!botonSeleccionado.Contains("SUR") && !botonSeleccionado.Contains("LIBRE"))
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("SOLO SE PERMITE SUR Y LIBRE PARA CONSUMO INTERNO");
                    return;
                }
            }
            EnableBtnProd(false);
            EnableBtnG2(false, false, true, false);
            EnableBtnG3(false);
            EnableBtnG4(false);
            EnableBtnG5(false);
           
        }

        private void btnProd8_Click(object sender, EventArgs e)
        {
            guardarCantidadInicial();
            SeleccionarProducto(((Button)sender).AccessibleName, ((Button)sender).Text);
            if (uiConsumo.Checked)
            {
                if (!botonSeleccionado.Contains("SUR") && !botonSeleccionado.Contains("LIBRE"))
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("SOLO SE PERMITE SUR Y LIBRE PARA CONSUMO INTERNO");
                    return;
                }
            }

            EnableBtnG2(false, false, false, false);
            EnableBtnG3(false);
            EnableBtnG4(false);
            EnableBtnG5(false);
           
        }

        private void SolicitaCantidadCortesia(int cantidadMaxima)
        {
            if (uiCortesia.Checked || uiConsumo.Checked)
            {
                frmSolicitaCantidadDialog oForm = new frmSolicitaCantidadDialog();
                oForm.titulo = "Por favor ingresa la cantidad a surtir para este paquete";
                oForm.cantidadMaxima = cantidadMaxima;
                oForm.StartPosition = FormStartPosition.CenterScreen;
                oForm.ShowDialog();
                if (oForm.DialogResult == DialogResult.OK)
                {
                    limiteMaxGuisoSeleccion = (short)oForm.cantidad;
                }
                else
                {
                    limiteMaxGuisoSeleccion = 0;
                }
            }
            else
            {
                limiteMaxGuisoSeleccion = (short)cantidadMaxima;
            }
        }

        private void btnProd9_Click(object sender, EventArgs e)
        {
            guardarCantidadInicial();
            SolicitaCantidadCortesia(10);
            limiteCarneChicharron = 10;
            limiteMaxGuisoSeleccionValidar = true;
            SeleccionarProducto(((Button)sender).AccessibleName, ((Button)sender).Text);
            if (uiConsumo.Checked)
            {
                if (!botonSeleccionado.Contains("SUR") && !botonSeleccionado.Contains("LIBRE"))
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("SOLO SE PERMITE SUR Y LIBRE PARA CONSUMO INTERNO");
                    return;
                }
            }
            EnableBtnG2(false, false, true, false);
            EnableBtnG3(false);
            EnableBtnG4(false);
            EnableBtnG5(false);
           
        }

        private void btnProd10_Click(object sender, EventArgs e)
        {
            guardarCantidadInicial();
            SolicitaCantidadCortesia(5);
            limiteMaxGuisoSeleccionValidar = true;
            limiteCarneChicharron = 5;
            SeleccionarProducto(((Button)sender).AccessibleName, ((Button)sender).Text);
            if (uiConsumo.Checked)
            {
                if (!botonSeleccionado.Contains("SUR") && !botonSeleccionado.Contains("LIBRE"))
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("SOLO SE PERMITE SUR Y LIBRE PARA CONSUMO INTERNO");
                    return;
                }
            }
            EnableBtnG2(false, false, true, false);
            EnableBtnG3(false);
            EnableBtnG4(false);
            EnableBtnG5(false);
           
        }

        private void btnProd11_Click(object sender, EventArgs e)
        {
            guardarCantidadInicial();
            SeleccionarProducto(((Button)sender).AccessibleName, ((Button)sender).Text);
            if (uiConsumo.Checked)
            {
                if (!botonSeleccionado.Contains("SUR") && !botonSeleccionado.Contains("LIBRE"))
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("SOLO SE PERMITE SUR Y LIBRE PARA CONSUMO INTERNO");
                    return;
                }
            }
            EnableBtnG2(false, false, false, false);
            EnableBtnG3(false);
            EnableBtnG4(false);
            EnableBtnG5(false);
            
        }

        private void btnG3_8_Click(object sender, EventArgs e)
        {
            ClicProducto(sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClicProducto(sender);
        }

        private void btnG3_8_Click_1(object sender, EventArgs e)
        {
            ClicProducto(sender);
        }

        private void btnG3_9_Click(object sender, EventArgs e)
        {
            ClicProducto(sender);
        }

        private void btnG3_10_Click(object sender, EventArgs e)
        {
            ClicProducto(sender);
        }

        private void btnG3_11_Click(object sender, EventArgs e)
        {
            ClicProducto(sender);
        }

        private void btnG3_12_Click(object sender, EventArgs e)
        {
            ClicProducto(sender);
        }

        private void btnG3_13_Click(object sender, EventArgs e)
        {
            ClicProducto(sender);
        }

        private void btnG3_14_Click(object sender, EventArgs e)
        {
            ClicProducto(sender);
        }

        private void btnG3_16_Click(object sender, EventArgs e)
        {
            ClicProducto(sender);
        }

        private void btnG5_4_Click(object sender, EventArgs e)
        {
            clicBebida2((Button)sender);
        }

        private void btnG5_6_Click(object sender, EventArgs e)
        {
            clicBebida2((Button)sender);
        }

        private void btnG4_6_Click(object sender, EventArgs e)
        {
            clicBebida((Button)sender);

        }

        private void btnG4_7_Click(object sender, EventArgs e)
        {
            clicBebida((Button)sender);

        }

        private void btnG4_8_Click(object sender, EventArgs e)
        {
            clicBebida((Button)sender);

        }

        private void btnG5_5_Click(object sender, EventArgs e)
        {
            clicBebida2((Button)sender);
        }

        private void btnG5_7_Click(object sender, EventArgs e)
        {
            clicBebida2((Button)sender);
        }

        private void btnG5_8_Click(object sender, EventArgs e)
        {
            clicBebida2((Button)sender);
        }       


        private void gvProducto_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void gvProducto_Click(object sender, EventArgs e)
        {
            
        }

        private void repDel_Click(object sender, EventArgs e)
        {
            removeDet();
        }

        private void gvProducto_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                removeDet();
            }
        }

        public void anticipoBoton()
        {
            if (programacion.cat_clientes == null)
            {
                XtraMessageBox.Show("No has completado la captura del pedido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.uiAnticipo.Enabled = false;
                return;
            }


            cobrandoAnticipo = false;
            if (programacion.cat_clientes.Nombre.Trim().Length == 0)
            {
                XtraMessageBox.Show("Los datos del pedido no están completos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                decimal cantidad;
                decimal.TryParse(uiCalculadora.EditValue.ToString(), out cantidad);

                //Es anticipo
                if (this.pedido.CargoId == null)
                {


                    decimal anticipoRequerido = lstPedido.Sum(s => s.total) * (porcAnticipoPedido / 100);
                    if (cantidad <= 0)
                    {

                        if (XtraMessageBox.Show("No ha ingresado la cantidad de anticipo en la calculadora, anticipo mínimo:" + anticipoRequerido.ToString("c2") + " .Colocar automáticamente en calculadora? (SI) Capturar Manualmente (NO)",
                            "ERROR",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            uiCalculadora.Text = anticipoRequerido.ToString();
                            anticipoBoton();
                        }


                        return;
                    }
                    {
                        if (cantidad < anticipoRequerido)
                        {
                            XtraMessageBox.Show("El anticipo debe de ser como mínimo:" + anticipoRequerido.ToString("c2"), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else
                        {
                            if (cantidad > lstPedido.Sum(s => s.total))
                            {
                                XtraMessageBox.Show("El anticipo no puede ser mayor al total del pedido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            else
                            {
                                cobrandoAnticipo = true;
                                cantidadAnticipo = cantidad;
                                CalcularTotales();
                                //uiCalculadora.Text = "";
                                cobrar();

                            }



                        }
                    }
                }
                #region es abono o liquidación
                //Es abono liquidación
                else
                {
                    if (cantidad <= 0)
                    {

                        //XtraMessageBox.Show("Es necesario ingresar una cantidad en la calculadora, máximo:" + (this.pedido.doc_cargos.Saldo ?? 0).ToString("c2"), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        if (XtraMessageBox.Show("No ha ingresado la cantidad de abono o liquidación , para liquidar:" + (this.pedido.doc_cargos.Saldo ?? 0).ToString("c2") + " .Colocar automáticamente en calculadora? (SI) Capturar Manualmente (NO)",
                                                   "ERROR",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            uiCalculadora.Text = (this.pedido.doc_cargos.Saldo ?? 0).ToString();
                            anticipoBoton();
                        }
                        return;
                    }
                    else
                    {
                        if (cantidad > this.pedido.doc_cargos.Saldo)
                        {

                            XtraMessageBox.Show("La cantidad no puede ser mayor a:" + (this.pedido.doc_cargos.Saldo ?? 0).ToString("c2"), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else
                        {
                            cobrandoAnticipo = true;
                            cantidadAnticipo = cantidad;
                            CalcularTotales();
                           // uiCalculadora.Text = "";

                            cobrar();
                        }
                    }

                }
                #endregion
            }
        }

        public void mostrarSaldoPedido()
        {
            decimal anticipoRequerido = 0;
            if((this.pedido.CargoId ??0)== 0)
            {
                anticipoRequerido = lstPedido.Sum(s => s.total) * (porcAnticipoPedido / 100);

                uiPedidoSaldo.Text = "ANTICIPO MIN. "+ anticipoRequerido.ToString("c2");
            }
            else
            {
                anticipoRequerido = this.pedido.doc_cargos.Saldo??0;

                uiPedidoSaldo.Text = "PARA LIQUIDAR " + anticipoRequerido.ToString("c2");
            }

           
           
        }

        private void uiAnticipo_Click(object sender, EventArgs e)
        {
            anticipoBoton();   
        }

        public void pedidoResumen()
        {
            try
            {
                frmPedidoKardex oForm = new frmPedidoKardex();
                oForm.pedidoId = this.pedidoId;
                oForm.StartPosition = FormStartPosition.CenterParent;
                oForm.WindowState = FormWindowState.Maximized;

                oForm.ShowDialog();
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                                "ERP",
                                this.Name,
                                ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiPedidoResumen_Click(object sender, EventArgs e)
        {
            pedidoResumen();
        }

        private void uiCalculadora_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void uiPedidoRefresh_Click(object sender, EventArgs e)
        {
            RefrescarPedido();
        }

        private void RefrescarPedido() {
            int pedidoId = this.pedido.PedidoId;
            Inicializar();
            obtenerCuenta(pedidoId);
        }

        private void btnG5_9_Click(object sender, EventArgs e)
        {
            clicBebida2((Button)sender);
        }

        private void btnG5_10_Click(object sender, EventArgs e)
        {
            clicBebida2((Button)sender);
        }

        private void btnG5_11_Click(object sender, EventArgs e)
        {
            clicBebida2((Button)sender);
        }

        private void btnG5_12_Click(object sender, EventArgs e)
        {
            clicBebida2((Button)sender);
        }

        private void btnG5_13_Click(object sender, EventArgs e)
        {
            clicBebida2((Button)sender);
        }

        private void btnG5_14_Click(object sender, EventArgs e)
        {
            clicBebida2((Button)sender);
        }

        private void btnG5_15_Click(object sender, EventArgs e)
        {
            clicBebida2((Button)sender);
        }

        private void btnG5_16_Click(object sender, EventArgs e)
        {
            clicBebida2((Button)sender);
        }

        private bool paqTacoIndividualCompleto()
        {
            try
            {
                if (lstPedido.Where(w => (w.nombreFamilia==null?"":w.nombreFamilia).Contains("TACO INDIVIDUAL")).Count() > 0)
                {
                    if ((lstPedido.Where(w => w.nombreFamilia.Contains("TACO INDIVIDUAL")).Sum(s => s.cantidad) % 10) > 0)
                    {                        
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                                "ERP",
                                this.Name,
                                ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);

                return false;
            }
        }

        private void SeleccionarTacoIndividual()
        {
            try
            {
                if (!paqTacoIndividualCompleto())
                {
                    int i = 1;
                    foreach (var item in lstSubFamBebidas)
                    {
                        Control controlA = Controls.Find("btnG4_" + i.ToString(), true).FirstOrDefault();
                        if (controlA != null)
                        {
                            if (controlA.Text.Contains("TACO INDIVIDUAL"))
                            {
                                clicBebida((Button)controlA);
                            }
                        }
                        i++;
                    }

                }


            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                               "ERP",
                               this.Name,
                               ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiCortesia_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        { 
            if((bool)e.NewValue == true)
            {
                if (!SeguridadCommon.ShowAdminPass())
                {
                    e.Cancel = true;
                }
            }
            
        }

        private void uiConsumo_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if ((bool)e.NewValue == true)
            {                
                if (ValidarConsumoInterno(true))
                {
                    if (!SeguridadCommon.ShowAdminPass())
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
                
            }
        }

        private void uiPrecioEmp_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if ((bool)e.NewValue == true)
            {
                if (!SeguridadCommon.ShowAdminPass())
                {
                    e.Cancel = true;
                }
            }
        }

        private void chkCortesia_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if ((bool)e.NewValue == true)
            {
                if (!SeguridadCommon.ShowAdminPass())
                {
                    e.Cancel = true;
                }
            }
        }

        private void chkConsumoInterno_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if ((bool)e.NewValue == true)
            {
                if (!SeguridadCommon.ShowAdminPass())
                {
                    e.Cancel = true;
                }
            }
        }

        private void chkPrecioEmpleado_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if ((bool)e.NewValue == true)
            {
                if (!SeguridadCommon.ShowAdminPass())
                {
                    e.Cancel = true;
                }
            }
        }

        private bool ValidarConsumoInterno(bool esConsumoInterno)
        {
            try
            {
                int productoLibreId = 0;
                

                //Consumo Interno
                if(this.lstPedido.Where(w=> w.consumoInterno).Count() > 0 || esConsumoInterno)
                {
                    productoLibreId = ERP.Business.DataMemory.DataBucket.GetProductosMemory(false)
                        .Where(W => W.DescripcionCorta == "LIBRE").FirstOrDefault().ProductoId;

                    if(lstPedido.Where(w=> w.productoId != productoLibreId && !w.descripcion.Contains("SUR")).Count() > 0)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("Solo se permite seleccionar paquete Libre para consumo Interno");
                        return false;
                    }

                    if(
                       lstPaqueteDetalle.Where(s=> s=="C" || s=="CH").Count() > 2
                    )
                    {                        
                        ERP.Utils.MessageBoxUtil.ShowWarning("Solo se permite como máximo hasta 2 de CARNE o 2 de CHICHARRON");
                        return false;
                    }

                }

                return true;
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                               "ERP",
                               this.Name,
                               ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);

                return false;
            }

            return true;
        }

        private void validarMaxMinimos()
        {
            try
            {
                ERP.Business.ProductoBusiness oProducto = new ERP.Business.ProductoBusiness();

                ProductoMinMaxListModel result = oProducto.GetMaxMinResumen(this.puntoVentaContext.sucursalId);

                if(result.lstProductos.Where(w=> w.solicitar > 0).Count() >0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("*******REVISAR MAXIMOS Y MINIMOS*********");
                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                               "ERP",
                               this.Name,
                               ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiKeyCatch_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.F2)
            {
                cobrar();
            }
        }

        private void aplicarRetiroAutomatico()
        {
            try
            {
                if (cantidadLimiteRetiro > 0)
                {
                    oContext = new ERPProdEntities();

                    p_retiro_automatico_SiNo_Result result = ERP.Business.RetiroBusiness.p_retiro_automatico_SiNo(this.puntoVentaContext.sucursalId,
                        this.puntoVentaContext.cajaId);

                    if(result != null)
                    {
                        if(result.AplicaSiNo == true)
                        {
                            frmRetiroAutomatico oFormRetiro = new frmRetiroAutomatico();
                            oFormRetiro.puntoVentaContext = this.puntoVentaContext;
                            oFormRetiro.cantidadRetiro = this.cantidadLimiteRetiro;
                            oFormRetiro.StartPosition = FormStartPosition.CenterParent;
                            var resultRetiro = oFormRetiro.ShowDialog();

                            if(resultRetiro == DialogResult.OK)
                            {
                                retiroAcumulado = 0;
                            }
                        }
                    }





                }
            }
            catch (Exception ex)
            {


                err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                               "ERP",
                               this.Name,
                               ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void btnProdMas_Click(object sender, EventArgs e)
        {

        }
    }
}
