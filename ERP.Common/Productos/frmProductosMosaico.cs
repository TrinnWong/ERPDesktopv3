using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using ERP.Business.DataMemory;
using ERP.Business.Tools;
using ERP.Common.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ERP.Business.Enumerados;

namespace ERP.Common.Productos
{
    public partial class frmProductosMosaico : FormBaseXtraForm
    {
        int numBotonesFam = 10;
        int numBotonesProd = 20;
        int idProductoSel = 0;
        public int? ClienteId = 0;
        public ERP.Business.Enumerados.tipoModalProducto? tipoModal { get; set; }
        cat_productos productoSeleccionado;
        BasculaLectura basculaControlador;
        cat_basculas_configuracion basculaConfiguracion;
        public ERP.Models.Pedidos.PedidoDetalleModel resultForm { get; set; }
        static bool isLoaded = false;
        public string ClaveProductoDefault { get; set; }
        private static frmProductosMosaico _instance;
        public static frmProductosMosaico GetInstance(PuntoVentaContext _puntoVentaContext, tipoModalProducto _tipoModal,bool reload=false)
        {
            if (_instance == null) _instance = new frmProductosMosaico(_puntoVentaContext, _tipoModal);
            else {

                _instance.BringToFront();

                if((_tipoModal != _instance.tipoModal) && reload)
                {
                    _instance.LlenarBotonesFamilias();
                    _instance.LlenarBotonesProducto("uiBtnCat1");
                }
            };
            return _instance;
        }

        public frmProductosMosaico(PuntoVentaContext _puntoVentaContext, tipoModalProducto? _tipoModal)
        {
            InitializeComponent();
            this.puntoVentaContext = _puntoVentaContext;

            //Eventos botones Categorias
            uiBtnCat1.Click += new EventHandler(uiBtnCat1_Click);
            uiBtnCat2.Click += new EventHandler(uiBtnCat1_Click);
            uiBtnCat3.Click += new EventHandler(uiBtnCat1_Click);
            uiBtnCat4.Click += new EventHandler(uiBtnCat1_Click);
            uiBtnCat5.Click += new EventHandler(uiBtnCat1_Click);
            uiBtnCat6.Click += new EventHandler(uiBtnCat1_Click);
            uiBtnCat7.Click += new EventHandler(uiBtnCat1_Click);
            uiBtnCat8.Click += new EventHandler(uiBtnCat1_Click);
            uiBtnCat9.Click += new EventHandler(uiBtnCat1_Click);
            uiBtnCat10.Click += new EventHandler(uiBtnCat1_Click);

            //Eventos botones Productos
            uiBtnProd1.Click += new EventHandler(uiBtnProd1_Click);
            uiBtnProd2.Click += new EventHandler(uiBtnProd1_Click);
            uiBtnProd3.Click += new EventHandler(uiBtnProd1_Click);
            uiBtnProd4.Click += new EventHandler(uiBtnProd1_Click);
            uiBtnProd5.Click += new EventHandler(uiBtnProd1_Click);
            uiBtnProd6.Click += new EventHandler(uiBtnProd1_Click);
            uiBtnProd7.Click += new EventHandler(uiBtnProd1_Click);
            uiBtnProd8.Click += new EventHandler(uiBtnProd1_Click);
            uiBtnProd9.Click += new EventHandler(uiBtnProd1_Click);
            uiBtnProd10.Click += new EventHandler(uiBtnProd1_Click);
            uiBtnProd11.Click += new EventHandler(uiBtnProd1_Click);
            uiBtnProd12.Click += new EventHandler(uiBtnProd1_Click);
            uiBtnProd13.Click += new EventHandler(uiBtnProd1_Click);
            uiBtnProd14.Click += new EventHandler(uiBtnProd1_Click);
            uiBtnProd15.Click += new EventHandler(uiBtnProd1_Click);
            uiBtnProd16.Click += new EventHandler(uiBtnProd1_Click);
            uiBtnProd17.Click += new EventHandler(uiBtnProd1_Click);
            uiBtnProd18.Click += new EventHandler(uiBtnProd1_Click);
            uiBtnProd19.Click += new EventHandler(uiBtnProd1_Click);
            uiBtnProd20.Click += new EventHandler(uiBtnProd1_Click);

          
            resultForm = new Models.Pedidos.PedidoDetalleModel();
            basculaConfiguracion = Business.BasculasBusiness.GetConfiguracionPCLocal(puntoVentaContext.usuarioId,
                puntoVentaContext.sucursalId);

            if(basculaConfiguracion != null)
            {
                if (puntoVentaContext.conectarConBascula)
                {
                    basculaControlador = new BasculaLectura(this.puntoVentaContext);
                }
                else
                {
                    basculaControlador = new BasculaLectura(basculaConfiguracion);
                }
            }
           
            
            ConfigurarColoresBotones();

           
            if (_tipoModal == null)
            {
                tipoModal = tipoModalProducto.venta;
            }
            else
            {
                tipoModal = _tipoModal;
            }

            switch (tipoModal)
            {
                case tipoModalProducto.sobranteProducto:
                    {
                        uiTitulo.Text = "PRODUCTO SOBRANTE";
                        break;
                    }
                default:
                    {
                        uiTitulo.Text = "MOSAICO DE PRODUCTOS";
                        break;
                    }
            }


          
            LlenarBotonesFamilias();
            LlenarBotonesProducto("uiBtnCat1");


          
        }

        private void frmProductosMosaico_Load(object sender, EventArgs e)
        {
            limpiarCaptura();
            
            if(ClaveProductoDefault != null)
            {


                LlenarBotonesFamilias();
                LlenarBotonesProducto("uiBtnCat1");                
                SeleccionProducto("uiBtnProd1");
            }
           
        }

     

        private void ConfigurarColoresBotones()
        {
            try
            {

                for (int i = 1; i <= numBotonesFam; i++)
                {
                    Control controlA = Controls.Find("uiBtnCat" + i.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        SimpleButton btnFam = (SimpleButton)controlA;

                        btnFam.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                        btnFam.LookAndFeel.UseDefaultLookAndFeel = false;
                        btnFam.BackColor = Color.LightSkyBlue;
                        btnFam.Padding = new Padding(5);
                    }
                }
                for (int i = 1; i <= numBotonesProd; i++)
                {
                    Control controlA = Controls.Find("uiBtnProd" + i.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        SimpleButton btnFam = (SimpleButton)controlA;

                        btnFam.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                        btnFam.LookAndFeel.UseDefaultLookAndFeel = false;
                        btnFam.BackColor = Color.LightSalmon;
                        btnFam.Padding = new Padding(5);
                        btnFam.Text = "";
                    }
                }

            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                     "ERP",
                                     this.Name,
                                     ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }

        }

        private void LlenarBotonesFamilias()
        {
            try
            {
                
                int i = 1;
                List<cat_familias> familias=new List<cat_familias>();

                #region ObtenerFamilias
                if(tipoModal == tipoModalProducto.sobranteProducto && ClaveProductoDefault == null)
                {
                    familias.Add(new cat_familias() { Clave = 0, Descripcion = "PRODUCTO SOBRANTE" });
                    familias = familias.OrderBy(o => o.Clave).ToList();
                }
                else
                {
                    if(ClaveProductoDefault == null)
                    {
                        familias = DataBucket.GetFamiliasMemory(false).Where(
                        w => w.Estatus == true &&
                        w.cat_productos.Where(s => s.ProdParaVenta == true && w.Estatus == true).Count() > 0
                        ).ToList();

                        familias.Add(new cat_familias() { Clave = 0, Descripcion = "PRINCIPALES" });
                        familias = familias.OrderBy(o => o.Clave).ToList();
                    }
                    else
                    {
                        familias = DataBucket.GetFamiliasMemory(false).Where(
                               w =>
                                w.cat_productos.Where(s => s.Clave == ClaveProductoDefault).Count() > 0
                               ).ToList();
                    }
                }              

                #endregion

                foreach (var item in familias)
                {
                    Control controlA = Controls.Find("uiBtnCat" + i.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        controlA.AccessibleName = item.Clave.ToString();
                        controlA.Text = item.Descripcion;
                    }
                    i++;
                }

                /****Habilitar todos los botones****/
                for (int j = 1; j <= numBotonesFam; j++)
                {
                    Control controlA = Controls.Find("uiBtnCat" + j.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        controlA.Enabled = true;

                    }
                }

                

                /*Deshabilitar botones sin productos*/
                if ((familias.Count() + 1) <= numBotonesFam)
                {
                    for (int j = (familias.Count() + 1); j <= numBotonesFam; j++)
                    {
                        Control controlA = Controls.Find("uiBtnCat" + j.ToString(), true).FirstOrDefault();
                        if (controlA != null)
                        {
                            controlA.Enabled = false;
                            controlA.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(
                    puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void LlenarBotonesProducto(string btnFamilia)
        {
            try
            {
                Control controlBTtnFam = Controls.Find(btnFamilia, true).FirstOrDefault();

                if (controlBTtnFam == null)
                    return;

                int FamiliaId = Convert.ToInt32(controlBTtnFam.AccessibleName);
                List<cat_productos> lstProds;

                if (FamiliaId > 0)
                {
                    lstProds = DataBucket.GetProductosMemory(false).Where(w => w.Estatus == true && 
                    ((w.ProdParaVenta == true && tipoModal== tipoModalProducto.venta ) || tipoModal != tipoModalProducto.venta) &&
                    w.ClaveFamilia == FamiliaId &&
                    (w.Clave == ClaveProductoDefault || ClaveProductoDefault 
                    == null)).OrderBy(o => o.DescripcionCorta).ToList();

                }
                else
                {
                    lstProds = new List<cat_productos>();
                    oContext = new ERPProdEntities();
                    if (tipoModal == tipoModalProducto.sobranteProducto)
                    {
                        int[] idsProdSobrantes = oContext.doc_productos_sobrantes_config.Select(s => s.ProductoSobranteId).ToArray();
                        lstProds = DataBucket.GetProductosMemory(false)
                            .Where(w=> idsProdSobrantes.Contains(w.ProductoId))
                             .OrderBy(o => o.DescripcionCorta).ToList();
                    }
                    else
                    {
                        lstProds = DataBucket.GetProductosMemory(false).Where(w => w.Estatus == true && w.ProdParaVenta == true &&
                        (
                            w.Descripcion.ToUpper().Contains("TORTILLA") ||
                            w.Descripcion.ToUpper().Contains("MASA")
                        )
                        ).OrderBy(o => o.DescripcionCorta).ToList();
                    }
                    
                }

                int i = 1;
                foreach (var item in lstProds)
                {
                    Control controlA = Controls.Find("uiBtnProd" + i.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        controlA.AccessibleName = item.ProductoId.ToString();
                        controlA.Text = String.Format("{0}", item.DescripcionCorta);
                    }
                    i++;
                }

                /****Habilitar todos los botones****/
                for (int j = 1; j <= numBotonesProd; j++)
                {
                    Control controlA = Controls.Find("uiBtnProd" + j.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        controlA.Enabled = true;
                    }
                }




                /*Deshabilitar botones sin productos*/
                if ((lstProds.Count() + 1) <= numBotonesProd)
                {
                    for (int j = (lstProds.Count() + 1); j <= numBotonesProd; j++)
                    {
                        Control controlA = Controls.Find("uiBtnProd" + j.ToString(), true).FirstOrDefault();
                        if (controlA != null)
                        {
                            controlA.Enabled = false;
                            controlA.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(
                    puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiBtnCat1_Click(object sender, EventArgs e)
        {
            LlenarBotonesProducto(((SimpleButton)sender).Name);
        }

        private void SeleccionProducto(string btnName, int idProducto = 0)
        {
            try
            {
                Control controlBTtn = null;
                if (idProducto == 0)
                {
                    if (btnName.Length > 0)
                    {
                        controlBTtn = Controls.Find(btnName, true).FirstOrDefault();

                        if (controlBTtn == null)
                            return;

                        idProductoSel = Convert.ToInt32(controlBTtn.AccessibleName);
                    }

                }
                else
                {
                    idProductoSel = idProducto;
                }

                buscarProducto();
                
                uiCantidad.Focus();
                uiCantidad.SelectAll();
            }
            catch (Exception ex)
            {


                int err = ERP.Business.SisBitacoraBusiness.Insert(
                    puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

       
        private void buscarProducto()
        {
            try
            {
                productoSeleccionado = DataBucket.GetProductosMemory(false)
                    .Where(
                    w =>
                    w.ProductoId == idProductoSel                    
                    &&
                    w.ProductoId > 0
                    ).FirstOrDefault();

                if (productoSeleccionado != null)
                {
                    uiProducto.Text = productoSeleccionado.Descripcion;
                    uiUnidad.Text = productoSeleccionado.cat_unidadesmed.Descripcion;
                    uiPrecio.EditValue = ClienteId == null ?
                    ERP.Business.ProductoBusiness.ObtenerPrecio(idProductoSel, tipoPrecioProducto.PublicoGeneral, puntoVentaContext.usuarioId,puntoVentaContext.sucursalId) :
                    ERP.Business.ProductoBusiness.ObtenerPrecioPorCliente(idProductoSel, Convert.ToInt32(ClienteId == null?0:ClienteId), puntoVentaContext.usuarioId,puntoVentaContext.sucursalId) ?? 0;

                    if (puntoVentaContext.conectarConBascula)
                    {
                        if (productoSeleccionado.ProdVtaBascula == true)
                        {
                            uiCantidad.ReadOnly = true;
                            basculaControlador.abrirBascula();
                            timerBascula.Enabled = true;


                        }
                        else
                        {
                            timerBascula.Enabled = false;
                            basculaControlador.cerrarBascula();
                            uiCantidad.ReadOnly = false;
                        }
                    }
                    else
                    {
                        timerBascula.Enabled = productoSeleccionado.ProdVtaBascula??false;                        
                        uiCantidad.ReadOnly = (productoSeleccionado.ProdVtaBascula ?? false);
                    }

                }
                else
                {
                    limpiarCaptura();
                }



            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                      "ERP",
                                      this.Name,
                                      ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

       

        private void limpiarCaptura()
        {
            productoSeleccionado = new cat_productos();
            uiProducto.Text = "";
            uiPrecio.EditValue = 0;
            uiCantidad.EditValue = 0;
            uiTotal.EditValue = 0;
            uiUnidad.Text = "";
        }

        private void uiContinuar_Click(object sender, EventArgs e)
        {
            try
            {
                if (productoSeleccionado != null)
                {
                    resultForm.productoId = productoSeleccionado.ProductoId;
                    resultForm.cantidad = uiCantidad.Value;
                    resultForm.descripcion = productoSeleccionado.Descripcion;
                    resultForm.clave = productoSeleccionado.Clave;
                    resultForm.unidadId = productoSeleccionado.ClaveUnidadMedida??0;
                    resultForm.unidad = productoSeleccionado.cat_unidadesmed.DescripcionCorta;
                    resultForm.requiereBascula = productoSeleccionado.ProdVtaBascula ?? false;
                }
                else
                {
                    resultForm = new Models.Pedidos.PedidoDetalleModel();
                }

                this.DialogResult = DialogResult.OK;
                this.Hide();

            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                     "ERP",
                                     this.Name,
                                     ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void timerBascula_Tick(object sender, EventArgs e)
        {
            try
            {
                if (puntoVentaContext.conectarConBascula)
                {
                    uiCantidad.EditValue = basculaControlador.ObtenPesoSinDefault();
                }
                else
                {
                    uiCantidad.EditValue = basculaControlador.ObtenPesoBD(false);
                }
                
            }
            catch (Exception ex)
            {
                timerBascula.Enabled = false;

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiBtnProd1_Click(object sender, EventArgs e)
        {
            SeleccionProducto(((SimpleButton)sender).Name);
        }

        private void frmProductosMosaico_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClaveProductoDefault = null;
        }
    }
}
