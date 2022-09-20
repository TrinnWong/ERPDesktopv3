using ConexionBD;
using DevExpress.XtraEditors;
using ERP.Business.Tools;
using ERP.Common.Base;
using ERP.Models;
using ERP.Models.Produccion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Produccion
{
    public partial class frmProduccionSucursalUpd : FormBaseXtraForm
    {
        public int ID { get; set; }
        List<ProduccionSucProductoModel> lstEntradas;
        List<ProduccionSucProductoModel> lstSalidas;
        List<cat_productos> lstProductosEntradasPre;
        List<cat_productos> lstProductosSalidasPre;
        List<cat_productos_base_conceptos> lstConceptos;
        BasculaLectura basculaControlador;
        int productoEntradaSel;
        int productoSalidaSel;
        int productoId;
        private static frmProduccionSucursalUpd _instance;
        public static frmProduccionSucursalUpd GetInstance()
        {
            if (_instance == null) _instance = new frmProduccionSucursalUpd();
            else _instance.BringToFront();
            return _instance;
        }

        public frmProduccionSucursalUpd()
        {
            InitializeComponent();
        }

        private void frmProduccionSucursalUpd_Load(object sender, EventArgs e)
        {
            oContext = new ConexionBD.ERPProdEntities();
            basculaControlador = new BasculaLectura(this.puntoVentaContext);
            if(this.ID == 0)
            {
                Inicializar();
            }
            else
            {

                LlenarForma();
            }
            
          
        }

        #region funcionalidad
        private void Inicializar()
        {
            this.ID = 0;
            productoEntradaSel = 0;
            productoSalidaSel = 0;
            LoadLkpProductos();
            uiLayoutGSalidas.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            uiLayoutGEntradas.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lstEntradas = new List<ProduccionSucProductoModel>();
            lstSalidas = new List<ProduccionSucProductoModel>();
            lstProductosEntradasPre = new List<cat_productos>();
            lstProductosSalidasPre = new List<cat_productos>();
            LimpiarBotones();
        }
        private void LimpiarBotones()
        {
            try
            {
                for (int i = 1; i <= 6; i++)
                {
                    Control controlA = Controls.Find("uiEntrada" + i.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        controlA.AccessibleName = "";
                        controlA.Text = "";
                    }


                }
                for (int i = 1; i <= 6; i++)
                {
                    Control controlA = Controls.Find("uiSalida" + i.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        controlA.AccessibleName = "";
                        controlA.Text = "";
                    }


                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                   "ERP",
                                   this.Name,
                                   ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }
        private void LoadLkpProductos()
        {
            try
            {
                uiProductoProduccion.Properties.DataSource = null;
                uiProductoProduccion.Properties.DataSource = ERP.Business.DataMemory.DataBucket.GetProductosProduccionMemory(false, Business.Enumerados.tipoProductoProduccion.OTRO).ToList();
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        #region Entradas
        private void GetBotonesEntradas()
        {
            try
            {
                oContext = new ERPProdEntities();

                int productoProdId = uiProductoProduccion.EditValue != null ? Convert.ToInt32(uiProductoProduccion.EditValue) : 0;
                lstProductosEntradasPre = null;

                lstProductosEntradasPre = oContext.cat_productos
                   .Where(w => w.cat_productos_base1.Where(s1 => s1.ProductoId == productoProdId)                  
                   .Count() > 0 && w.Estatus == true).OrderBy(o=> o.Descripcion).ToList();

               
               
                //Rellenar Botones de Entrada
                for (int i = 1; i <= 6; i++)
                {
                    if(lstProductosEntradasPre.Count >= i)
                    {
                        if (lstProductosEntradasPre[i-1] != null)
                        {
                            Control controlA = Controls.Find("uiEntrada" + i.ToString(), true).FirstOrDefault();
                            if (controlA != null)
                            {
                                controlA.AccessibleName = lstProductosEntradasPre[i-1].ProductoId.ToString();
                                controlA.Text = lstProductosEntradasPre[i-1].Descripcion;
                            }
                        }
                    }
                    
                    
                }
                //Rellenar Botones de Salida
                for (int i = 1; i <= 6; i++)
                {
                    if (lstProductosSalidasPre.Count >= i)
                    {
                        if (lstProductosSalidasPre[i - 1] != null)
                        {
                            Control controlA = Controls.Find("uiSalida" + i.ToString(), true).FirstOrDefault();
                            if (controlA != null)
                            {
                                controlA.AccessibleName = lstProductosSalidasPre[i - 1].ProductoId.ToString();
                                controlA.Text = lstProductosSalidasPre[i - 1].Descripcion;
                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                     "ERP",
                                     this.Name,
                                     ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void EntradaSeleccion(string buttonName)
        {
            try
            {
                Control button = Controls.Find(buttonName, true).FirstOrDefault();

                productoEntradaSel = Convert.ToInt32(button.AccessibleName);

                cat_productos entityProducto = ERP.Business.DataMemory.DataBucket.GetProductosMemory(false)
                    .Where(w => w.ProductoId == productoEntradaSel).FirstOrDefault();

                if(entityProducto != null)
                {
                    uiProductoEntradaSel.Text = entityProducto.Clave +"-"+ entityProducto.Descripcion;
                    if(entityProducto.ProdVtaBascula == true)
                    {
                        uiPesoEntrada.Enabled = false;
                        timerBasculaEntrada.Enabled = true;
                        try
                        {
                            basculaControlador.abrirBascula();
                        }
                        catch (Exception)
                        {
                            uiPesoEntrada.Enabled = true;
                            timerBasculaEntrada.Enabled = false;

                        }
                       
                    }
                    else
                    {
                        uiPesoEntrada.Enabled = true;
                    }
                }

            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void SalidaSeleccion(string buttonName)
        {
            try
            {
                Control button = Controls.Find(buttonName, true).FirstOrDefault();

                 productoSalidaSel = Convert.ToInt32(button.AccessibleName);

                cat_productos entityProducto = ERP.Business.DataMemory.DataBucket.GetProductosMemory(false)
                    .Where(w => w.ProductoId == productoSalidaSel).FirstOrDefault();

                if (entityProducto != null)
                {
                    uiProductoSalidaSel.Text = entityProducto.DescripcionCorta;
                    if (entityProducto.ProdVtaBascula == true)
                    {
                        uiPesoSalida.Enabled = false;
                        timerBasculaSalida.Enabled = true;
                        try
                        {
                            basculaControlador.abrirBascula();
                        }
                        catch (Exception ex)
                        {
                            uiPesoSalida.Enabled = true;
                            timerBasculaSalida.Enabled = false;
                        }
                        
                    }
                    else
                    {
                        uiPesoSalida.Enabled = true;
                    }
                }

            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void limpiarSeccionEntrada()
        {
            uiProductoEntradaSel.Text = "";
            uiPesoEntrada.EditValue = 0;
            productoEntradaSel = 0;

        }
        private void limpiarSeccionSalida()
        {

            uiPesoSalida.EditValue = 0;


        }
        #endregion

       

        private void RefreshEntradas()
        {
            uiGridEntradas.DataSource = lstEntradas;
            uiGridViewEntradas.RefreshData();
        }

        private void RefreshSalidas()
        {
            uiGridSalidas.DataSource = lstSalidas;
            uiGridViewSalidas.RefreshData();
        }
        private void LlenarForma()
        {
            try
            {

                if (this.ID == 0)
                    return;

                LoadLkpProductos();
                oContext = new ERPProdEntities();

                doc_produccion entityProduccion = oContext
                    .doc_produccion.Where(w => w.ProduccionId == this.ID).FirstOrDefault();

                if(entityProduccion != null)
                {
                    uiFin.EditValue = entityProduccion.FechaHoraFin;
                    uiInicio.EditValue = entityProduccion.FechaHoraInicio;
                    uiProductoProduccion.EditValue = entityProduccion.ProductoId;
                    uiSucursal.Text = entityProduccion.cat_sucursales.NombreSucursal;
                    uiID.EditValue = this.ID;
                    lstEntradas = entityProduccion.doc_produccion_entrada
                        .Select(s => new ProduccionSucProductoModel() {
                             cantidad = s.Cantidad,
                              clave = s.cat_productos.Clave,
                               descripcionProducto = s.cat_productos.Descripcion,
                                productoId = s.ProductoId,
                                 unidadId = s.UnidadId 
                        }).ToList();

                    productoId = Convert.ToInt32(uiProductoProduccion.EditValue);
                    lstConceptos = oContext.cat_productos_base_conceptos
                        .Where(w => w.ProductoId == productoId).ToList();

                   
                    RefreshEntradas();

                    lstSalidas = entityProduccion.doc_produccion_salida
                        .Select(s => new ProduccionSucProductoModel()
                        {
                            cantidad = s.Cantidad ?? 0,
                            clave = s.cat_productos.Clave,
                            descripcionProducto = s.cat_productos.Descripcion,
                            productoId = s.ProductoId,
                            unidadId = s.UnidadId ?? 0
                        }).ToList();


                    uiProductoProduccion.EditValue = entityProduccion.ProductoId;

                    lstProductosSalidasPre = new List<cat_productos>();
                    lstProductosSalidasPre.Add(entityProduccion.cat_productos);

                    RefreshSalidas();

                    uiActivo.Checked = entityProduccion.Activo;
                    uiCompletado.Checked = entityProduccion.Completado;

                    GetBotonesEntradas();

                    if(entityProduccion.EstatusProduccionId == (int)ERP.Business.Enumerados.estatusProduccion.En_Produccion)
                    {
                        ConfigvistaEnProduccion();
                    }
                    if (entityProduccion.EstatusProduccionId == (int)ERP.Business.Enumerados.estatusProduccion.Produccion_Terminada)
                    {
                        ConfigvistaTerminado();
                    }

                }
                else
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Ocurrió un problema al intentar obtener la información de producción");
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                   "ERP",
                                   this.Name,
                                   ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }
        #endregion

        #region eventos
        private void uiContinuar0_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(uiProductoProduccion.EditValue) > 0)
            {
                uiLayoutGEntradas.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                productoId = Convert.ToInt32(uiProductoProduccion.EditValue);
                lstConceptos = oContext.cat_productos_base_conceptos
                    .Where(w => w.ProductoId == productoId).ToList();
                GetBotonesEntradas();
            }
            else
            {
                ERP.Utils.MessageBoxUtil.ShowWarning("Selecciona el producto a producir");
            }

        }

        public void HabilitarBotonConcepto()
        {
            if(lstConceptos.Count > 0)
            {
                uiConceptos.Enabled = true;
            }
        }

        private void timerBascula_Tick(object sender, EventArgs e)
        {
            try
            {
                uiPesoEntrada.EditValue = basculaControlador.ObtenPeso();
            }
            catch (Exception ex)
            {
                timerBasculaEntrada.Enabled = false;
                uiPesoEntrada.Enabled = true;
                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }

        }


        private void uiAgregarEntrada_Click(object sender, EventArgs e)
        {
            try
            {
              
                //Validar peso 0
                if (Convert.ToDecimal(uiPesoEntrada.EditValue) <= 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("El peso no puede ser 0");
                    return;
                }

                
                if (productoEntradaSel > 0)
                {
                    timerBasculaEntrada.Enabled = false;
                    basculaControlador.cerrarBascula();
                    ProduccionSucProductoModel nuevaEntrada = new ProduccionSucProductoModel();
                    nuevaEntrada.cantidad = Convert.ToDecimal(uiPesoEntrada.EditValue);
                    nuevaEntrada.descripcionProducto = lstProductosEntradasPre
                        .Find(f => f.ProductoId == productoEntradaSel).Descripcion;
                    nuevaEntrada.productoId = productoEntradaSel;
                    nuevaEntrada.clave = lstProductosEntradasPre
                        .Find(f => f.ProductoId == productoEntradaSel).Clave;
                    nuevaEntrada.unidadId = lstProductosEntradasPre
                        .Find(f => f.ProductoId == productoEntradaSel).ClaveUnidadMedida ?? 0;
                    nuevaEntrada.UsoBascula = lstProductosEntradasPre
                        .Find(f => f.ProductoId == productoEntradaSel).ProdVtaBascula??false;
                    lstEntradas.Add(nuevaEntrada);

                    uiGridEntradas.DataSource = lstEntradas;
                    uiGridEntradas.Refresh();
                    uiGridViewEntradas.RefreshData();

                    basculaControlador.cerrarBascula();
                    limpiarSeccionEntrada();
                }
                else
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Seleccione un producto de entrada");
                }


            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                   "ERP",
                                   this.Name,
                                   ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);

            }

        }

        private void uiEntrada1_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiEntrada1");
        }

        private void uiEntrada2_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiEntrada2");
        }

        private void uiEntrada3_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiEntrada3");
        }

        private void uiEntrada4_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiEntrada4");
        }

        private void uiEntrada5_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiEntrada5");
        }

        private void uiEntrada6_Click(object sender, EventArgs e)
        {
            EntradaSeleccion("uiEntrada6");
        }

       
        private void ConfigvistaEnProduccion()
        {
            uiLayoutGEntradas.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            uiLayoutGSalidas.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            uiEntrada1.Enabled = false;
            uiEntrada2.Enabled = false;
            uiEntrada3.Enabled = false;
            uiEntrada4.Enabled = false;
            uiEntrada5.Enabled = false;
            uiEntrada6.Enabled = false;
            uiSalida1.Enabled = true;
            uiSalida2.Enabled = true;
            uiSalida3.Enabled = true;
            uiSalida4.Enabled = true;
            uiSalida5.Enabled = true;
            uiSalida6.Enabled = true;
            uiAgregarEntrada.Enabled = false;
            uiProductoProduccion.Enabled = false;
            colDelEntrada.OptionsColumn.AllowEdit = false;
            repBtnEntradaDel.ReadOnly = true;
            uiContinuar1.Enabled = false;
            uiContinuar0.Enabled = false;
            HabilitarBotonConcepto();


        }
        private void ConfigvistaTerminado()
        {
            uiLayoutGEntradas.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            uiLayoutGSalidas.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            uiEntrada1.Enabled = false;
            uiEntrada2.Enabled = false;
            uiEntrada3.Enabled = false;
            uiEntrada4.Enabled = false;
            uiEntrada5.Enabled = false;
            uiEntrada6.Enabled = false;
            uiSalida1.Enabled = false;
            uiSalida2.Enabled = false;
            uiSalida3.Enabled = false;
            uiSalida4.Enabled = false;
            uiSalida5.Enabled = false;
            uiSalida6.Enabled = false;
            uiAgregarEntrada.Enabled = false;
            uiProductoProduccion.Enabled = false;
            colDelEntrada.OptionsColumn.AllowEdit = false;
            repBtnEntradaDel.ReadOnly = true;
            uiContinuar1.Enabled = false;
            uiContinuar0.Enabled = false;
            uiAgregarSalida.Enabled = false;
            uiTerminarProduccion.Enabled = false;
            uiConceptos.Enabled = false;
            colRegistrarSalida.OptionsColumn.ReadOnly = true;
        }

        private void uiContinuar1_Click(object sender, EventArgs e)
        {
            try
            {
                if(XtraMessageBox.Show("¿Estás seguro(a) de continuar?, no será posible realizar cambios en las Entradas","Atención",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.No)
                {
                    return;
                }
                if (lstEntradas.Count > 0)
                {
                    cat_productos entityProdSalida = (cat_productos)uiProductoProduccion.GetSelectedDataRow();

                    if(entityProdSalida == null)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("Seleccione el producto a producir");
                        return;
                    }
                    //lstSalidas = new List<ProduccionSucProductoModel>();
                    //lstSalidas.Add(new ProduccionSucProductoModel() { cantidad = 0, clave = entityProdSalida.Clave,
                    //    descripcionProducto = entityProdSalida.Descripcion , productoId = entityProdSalida.ProductoId,
                    //    unidadId = entityProdSalida.ClaveUnidadMedida ?? 0});

                    doc_produccion entityProduccion = new doc_produccion();
                    entityProduccion.ProductoId = Convert.ToInt32( uiProductoProduccion.EditValue);

                    ResultAPIModel result = ERP.Business.ProduccionBusiness.IniciarProduccion(ref entityProduccion,
                        lstEntradas, lstSalidas, this.puntoVentaContext);

                    if (!result.ok)
                    {
                        ERP.Utils.MessageBoxUtil.ShowError(result.error);
                        return;
                    }
                    if (entityProduccion.ProduccionId == 0)
                    {
                        ERP.Utils.MessageBoxUtil.ShowError("Ocurrió un error inesperado");
                        return;
                    }
                    uiLayoutGSalidas.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    this.ID = entityProduccion.ProduccionId;

                    LlenarForma();
                    

                }
                else
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Es necesario agregar productos de entrada");
                }


            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                   "ERP",
                                   this.Name,
                                   ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void timerBasculaSalida_Tick(object sender, EventArgs e)
        {

            try
            {
                uiPesoSalida.EditValue = basculaControlador.ObtenPeso();
            }
            catch (Exception ex)
            {
                timerBasculaSalida.Enabled = false;
                uiPesoSalida.Enabled = true;
                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }

        }

        private void uiAgregarSalida_Click(object sender, EventArgs e)
        {
            try
            {
                if (productoSalidaSel == 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Seleccione primero el producto de Salida");
                    return;
                }
                if (Convert.ToDecimal(uiPesoSalida.EditValue) <= 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("El peso no puede ser 0");
                    return;
                }
               
                var producto = ERP.Business.DataMemory.DataBucket.GetProductosMemory(false)
                     .Where(w => w.ProductoId == productoSalidaSel).FirstOrDefault();

                if(lstSalidas == null)
                {
                    lstSalidas = new List<ProduccionSucProductoModel>();
                }

                timerBasculaSalida.Enabled = false;
                basculaControlador.cerrarBascula();

                doc_produccion_salida entitySalida = new doc_produccion_salida();

                entitySalida.Cantidad = Convert.ToDecimal(uiPesoSalida.EditValue);
                entitySalida.ProduccionId = this.ID;
                entitySalida.ProductoId = productoSalidaSel;
                entitySalida.UnidadId = producto.ClaveUnidadMedida ?? 0;

                ResultAPIModel result = ERP.Business.ProduccionBusiness
                    .AgregarSalida(ref entitySalida, producto.ProdVtaBascula ??false,
                    puntoVentaContext.usuarioId, puntoVentaContext.sucursalId);

                if (result.ok)
                {
                    lstSalidas.Add(new ProduccionSucProductoModel() {
                         cantidad = entitySalida.Cantidad ?? 0,
                          clave = producto.Clave,
                           descripcionProducto = producto.DescripcionCorta,
                            productoId = producto.ProductoId,
                             unidadId = producto.ClaveUnidadMedida ?? 0,
                              UsoBascula = producto.ProdVtaBascula ?? false
                    });
                    uiGridSalidas.DataSource = lstSalidas;
                    uiGridSalidas.Refresh();
                    uiGridViewSalidas.RefreshData();

                    basculaControlador.cerrarBascula();
                    limpiarSeccionSalida();

                    productoSalidaSel = 0;
                    uiProductoSalidaSel.Text = "";
                }
                else
                {
                    ERP.Utils.MessageBoxUtil.ShowError(result.error);
                }

                
               


            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                   "ERP",
                                   this.Name,
                                   ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);

            }
        }

        private void uiSalida1_Click(object sender, EventArgs e)
        {
            SalidaSeleccion("uiSalida1");
        }

        private void uiSalida2_Click(object sender, EventArgs e)
        {
            SalidaSeleccion("uiSalida2");
        }

        private void uiSalida3_Click(object sender, EventArgs e)
        {
            SalidaSeleccion("uiSalida3");
        }

        private void uiSalida4_Click(object sender, EventArgs e)
        {
            SalidaSeleccion("uiSalida4");
        }

        private void uiSalida5_Click(object sender, EventArgs e)
        {
            SalidaSeleccion("uiSalida5");
        }

        private void uiSalida6_Click(object sender, EventArgs e)
        {
            SalidaSeleccion("uiSalida6");
        }

        private void frmProduccionSucursalUpd_FormClosing(object sender, FormClosingEventArgs e)
        {
            basculaControlador.cerrarBascula();
            _instance = null;
        }

        private void repBtnEntradaDel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                ProduccionSucProductoModel row = (ProduccionSucProductoModel)uiGridViewEntradas
                    .GetRow(uiGridViewEntradas.FocusedRowHandle);

                if (row != null)
                {
                    lstEntradas.Remove(row);

                    uiGridEntradas.DataSource = lstEntradas;
                    uiGridViewEntradas.RefreshData();
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void repBtnSalidaDel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                ProduccionSucProductoModel row = (ProduccionSucProductoModel)uiGridViewSalidas
                    .GetRow(uiGridViewSalidas.FocusedRowHandle);

                if (row != null)
                {
                    lstSalidas.Remove(row);

                    uiGridSalidas.DataSource = lstSalidas;
                    uiGridViewSalidas.RefreshData();
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        #endregion

        private void repBtnRegistrarSalida_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                ProduccionSucProductoModel row = (ProduccionSucProductoModel)uiGridViewSalidas
                    .GetRow(uiGridViewSalidas.FocusedRowHandle);

                if (row != null)
                {
                    productoSalidaSel = row.productoId;

                    cat_productos entityProducto = ERP.Business.DataMemory.DataBucket.GetProductosMemory(false)
                        .Where(w => w.ProductoId == productoSalidaSel).FirstOrDefault();

                    if (entityProducto != null)
                    {
                        if (entityProducto.ProdVtaBascula == true)
                        {
                            uiPesoSalida.Enabled = false;
                            timerBasculaSalida.Enabled = true;
                            basculaControlador.abrirBascula();
                        }
                        else
                        {
                            uiPesoSalida.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                   "ERP",
                                   this.Name,
                                   ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiTerminarProduccion_Click(object sender, EventArgs e)
        {
            if(lstConceptos.Count > 0)
            {
                if(oContext.doc_produccion_conceptos.Where(w=> w.ProduccionId == this.ID).Count() == 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Es necesario completar la información de conceptos adicionales");
                    return;
                }
            }


            if(MessageBox.Show("¿Está seguro de continuar?, ya no será posible agregar salidas de producción para este folio",
                 "Aviso", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            ResultAPIModel result = ERP.Business.ProduccionBusiness
                .TerminarProduccion(this.ID, lstEntradas, lstSalidas,
                this.puntoVentaContext);

            if (!result.ok)
            {
                ERP.Utils.MessageBoxUtil.ShowError(result.error);
            }
            else
            {

                ERP.Utils.MessageBoxUtil.ShowOk();
                LlenarForma();
            }
        }

        public void Nuevo()
        {
            Inicializar();
        }

        private void uiConceptos_Click(object sender, EventArgs e)
        {
            frmProduccionConceptos frm = new frmProduccionConceptos();
            frm.puntoVentaContext = this.puntoVentaContext;
            frm.lstConceptos = this.lstConceptos;
            frm.ProduccionID = this.ID;
            frm.ShowDialog();
        }
    }
}
