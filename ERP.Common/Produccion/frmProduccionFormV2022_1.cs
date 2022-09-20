using ConexionBD;
using DevExpress.XtraEditors;
using ERP.Business.Tools;
using ERP.Common.Base;
using ERP.Common.Inventarios;
using ERP.Common.PuntoVenta;
using ERP.Models;
using ERP.Models.Produccion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Produccion
{
    public partial class frmProduccionFormV2022_1 : FormBaseXtraForm
    {
        int err;
        List<ProduccionSucProductoModel> lstEntradas;
        List<cat_productos> lstProductosEntradasPre;
        List<ProduccionProductoConfig> lstProductosSalidasPre;
        List<ProduccionProductoConfig> lstProductosSalidasPre_listos;
        cat_productos productoTerminadoSeleccionado;
        cat_productos productoInsumoSeleccionado;
        List<Models.Produccion.ProduccionHistorialModel> lstProduccionHistorial;
        doc_produccion produccionSel;
        ResultAPIModel result;
        BasculaLectura basculaControlador;
        List<cat_productos_base_conceptos> lstConceptos;
        bool esCocimiento=false;
        bool soloHabilitarCocimiento = false;
        
        private static frmProduccionFormV2022_1 _instance;
        public static frmProduccionFormV2022_1 GetInstance()
        {
            if (_instance == null) _instance = new frmProduccionFormV2022_1();
            else _instance.BringToFront();
            return _instance;
        }
        public frmProduccionFormV2022_1()
        {
            InitializeComponent();
            
            uiPT_1.Click += new EventHandler(uiPT_Click);
            uiPT_2.Click += new EventHandler(uiPT_Click);
            uiPT_3.Click += new EventHandler(uiPT_Click);
            uiPT_4.Click += new EventHandler(uiPT_Click);
            uiPT_5.Click += new EventHandler(uiPT_Click);
            uiPT_6.Click += new EventHandler(uiPT_Click);
            uiPT_7.Click += new EventHandler(uiPT_Click);
            uiPT_8.Click += new EventHandler(uiPT_Click);
            uiPT_9.Click += new EventHandler(uiPT_Click);
            uiPT_10.Click += new EventHandler(uiPT_Click);
            uiPT_11.Click += new EventHandler(uiPT_Click);
            uiPT_12.Click += new EventHandler(uiPT_Click);
            uiPT_13.Click += new EventHandler(uiPT_Click);
            uiPT_14.Click += new EventHandler(uiPT_Click);
            uiPT_15.Click += new EventHandler(uiPT_Click);
            uiPT_16.Click += new EventHandler(uiPT_Click);


            uiPI_1.Click += new EventHandler(uiPI_Click);
            uiPI_2.Click += new EventHandler(uiPI_Click);
            uiPI_3.Click += new EventHandler(uiPI_Click);
            uiPI_4.Click += new EventHandler(uiPI_Click);
            uiPI_5.Click += new EventHandler(uiPI_Click);
            uiPI_6.Click += new EventHandler(uiPI_Click);
            uiPI_7.Click += new EventHandler(uiPI_Click);
            uiPI_8.Click += new EventHandler(uiPI_Click);
            uiPI_9.Click += new EventHandler(uiPI_Click);
            uiPI_10.Click += new EventHandler(uiPI_Click);
            uiPI_11.Click += new EventHandler(uiPI_Click);
            uiPI_12.Click += new EventHandler(uiPI_Click);
        }

        #region metodos

        private void SetSoloHabilitarCocimiento()
        {
            oContext = new ERPProdEntities();

            if (
                oContext.doc_cocimientos.Where(w => w.doc_produccion.SucursalId == puntoVentaContext.sucursalId
                && DbFunctions.TruncateTime(w.CreadoEl) == DbFunctions.TruncateTime(DateTime.Now)
                ).Count() == 0
            )
            {
                soloHabilitarCocimiento = true;
            }
            else
            {
                soloHabilitarCocimiento = false;
            }
        }
        private void GetBotonesProductoTerminado()
        {
            try
            {
                oContext = new ERPProdEntities();

                SetSoloHabilitarCocimiento();

                lstProductosEntradasPre = null;

                lstProductosEntradasPre = oContext.cat_productos
                   .Where(
                    w => w.cat_productos_base.Count() > 0 
                    && w.cat_produccion_productos_sucursal.Where(s2 => s2.SucursalId == puntoVentaContext.sucursalId && s2.ProductoId == w.ProductoId).Count() > 0
                    
                    && w.Estatus == true 
                    && w.cat_productos_base.Where(s1=> (s1.ParaCocina??false) == false ).Count()>0
                    )
                   .OrderBy(o => o.Descripcion).ToList();
               

                //Rellenar Botones de Entrada
                for (int i = 1; i <= 16; i++)
                {
                    if (lstProductosEntradasPre.Count >= i)
                    {
                        if (lstProductosEntradasPre[i - 1] != null)
                        {
                            Control controlA = Controls.Find("uiPT_" + i.ToString(), true).FirstOrDefault();
                            if (controlA != null)
                            {                              

                                FormatoDeseleccionBoton((SimpleButton)controlA);

                                controlA.AccessibleName = lstProductosEntradasPre[i - 1].ProductoId.ToString();
                                controlA.Text = lstProductosEntradasPre[i - 1].Descripcion;
                                if (soloHabilitarCocimiento)
                                {
                                    if (controlA.Text.ToUpper().Contains("COCIMIENTO"))
                                    {
                                        controlA.Enabled = true;
                                    }
                                    else
                                    {
                                        controlA.Enabled = false;
                                    }
                                }
                                else
                                {
                                    controlA.Enabled = true;
                                }
                                
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
       
        private void GetBotonesInsumos()
        {
            try
            {
                lstProductosSalidasPre_listos = new List<ProduccionProductoConfig>();
                lstProductosSalidasPre = new List<ProduccionProductoConfig>();
                LimpiarBotonesInsumos();
                oContext = new ERPProdEntities();

                lstProductosSalidasPre = null;

                

                lstProductosSalidasPre = oContext.cat_productos_base
                    .Where(w => w.ProductoId == productoTerminadoSeleccionado.ProductoId)
                    .Select(s => new ProduccionProductoConfig() {
                        descripcion = s.cat_productos1.DescripcionCorta,
                        orden = s.Orden ?? 0,
                        requerido = s.Requerido ?? false,
                        productoId = s.ProductoBaseId,
                        productoTerminadoId = productoTerminadoSeleccionado.ProductoId,
                        existe = false
                    }).OrderBy(o=> o.orden).ToList();

                int index = 0;
                lstProductosSalidasPre.ForEach(f=> f.index = index++);

                if (!productoTerminadoSeleccionado.DescripcionCorta.Contains("01") && !productoTerminadoSeleccionado.DescripcionCorta.Contains("02"))
                {
                    //Agregar item producto terminado
                    lstProductosSalidasPre.Add(
                        new ProduccionProductoConfig()
                        {
                            descripcion = productoTerminadoSeleccionado.DescripcionCorta,
                            orden = 100,
                            productoId = productoTerminadoSeleccionado.ProductoId,
                            requerido = true,
                            index = lstProductosSalidasPre.Count()
                        }
                        );

                }




                //Rellenar Botones de Entrada
                for (int i = 1; i <= 12; i++)
                {
                    Control controlA = Controls.Find("uiPI_" + i.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        if (lstProductosSalidasPre.Count >= i)
                        {
                            if (lstProductosSalidasPre[i - 1] != null)
                            {
                                controlA.Enabled = true;
                                controlA.AccessibleName = lstProductosSalidasPre[i - 1].productoId.ToString();
                                controlA.Text = lstProductosSalidasPre[i - 1].descripcion;
                            }
                            else
                            {
                                controlA.Enabled = false;
                            }
                        }
                        else
                        {
                            controlA.Enabled = false;
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

        private void BotonesInsumosDeshabilitar()
        {
            //Rellenar Botones de Entrada
            for (int i = 1; i <= 12; i++)
            {
                if (lstProductosSalidasPre.Count >= i)
                {
                    if (lstProductosSalidasPre[i - 1] != null)
                    {
                        Control controlA = Controls.Find("uiPI_" + i.ToString(), true).FirstOrDefault();
                        if (controlA != null)
                        {                           
                            if (lstProductosSalidasPre != null)
                            {
                                if (lstProduccionHistorial.Where(w =>
                                 w.ProductoId == lstProductosSalidasPre[i - 1].productoId
                                ).Count() == 0
                                &&
                                productoInsumoSeleccionado.ProductoId != lstProductosSalidasPre[i - 1].productoId
                                )
                                {
                                    int productoId = lstProductosSalidasPre[i - 1].productoId;
                                    if (
                                        lstProductosSalidasPre_listos.Where(w=> w.productoId == productoId).Count() > 0
                                        )
                                    {
                                        controlA.Enabled = true;
                                    }
                                    else
                                    {
                                        controlA.Enabled = false;
                                    }
                                    
                                }
                                else
                                {
                                    controlA.Enabled = true;
                                }
                            }
                        }
                    }
                }


            }
        }

        private void LimpiarBotonesInsumos()
        {
            try
            {
                for (int i = 1; i <= 15; i++)
                {
                    Control controlA = Controls.Find("uiPI_" + i.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        FormatoDeseleccionBoton((SimpleButton)controlA);
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

        private void FormatoSeleccionBoton(SimpleButton button)
        {
            button.LookAndFeel.UseDefaultLookAndFeel = false;
            button.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            button.Appearance.BackColor = Color.Blue;
            button.Appearance.ForeColor = Color.White;
            button.Padding = new Padding(5);
        }
        private void FormatoDeseleccionBoton(SimpleButton button)
        {
            button.LookAndFeel.UseDefaultLookAndFeel = false;
            button.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            button.Appearance.BackColor = Color.LightGray;
            button.Appearance.ForeColor = Color.Black;
            button.Padding = new Padding(5);
        }
        private void PT_Seleccion(string buttonName)
        {
            try
            {
                //Desmarcar todos los botones
                for (int i = 1; i <= 16; i++)
                {
                    Control controlA = Controls.Find("uiPT_" + i.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        FormatoDeseleccionBoton((SimpleButton)controlA);
                    }


                }

                Control controlb = Controls.Find(buttonName, true).FirstOrDefault();
                if (controlb != null)
                {
                    FormatoSeleccionBoton((SimpleButton)controlb);
                }
                
                Control button = Controls.Find(buttonName, true).FirstOrDefault();
                productoTerminadoSeleccionado = new cat_productos();
                productoTerminadoSeleccionado.ProductoId = Convert.ToInt32(button.AccessibleName);
                productoTerminadoSeleccionado.DescripcionCorta = controlb.Text;

                if (productoTerminadoSeleccionado.DescripcionCorta.ToUpper().Contains("COCIMIENTO"))
                {
                    esCocimiento = true;
                }
                else
                {
                    esCocimiento = false;
                }

                cat_productos entityProducto = ERP.Business.DataMemory.DataBucket.GetProductosMemory(false)
                    .Where(w => w.ProductoId == productoTerminadoSeleccionado.ProductoId).FirstOrDefault();

                //Deshabilitar/Habilitar
                gcCocimiento.Enabled = esCocimiento;
                uiTerminar.Enabled = !esCocimiento;
                
                LlenarGrid();
                GetConceptosAdicionales();
                GetBotonesInsumos();
                PI_Seleccion("uiPI_1");
                BotonesInsumosDeshabilitar();

                ObtenCocimientosDia();

            }
            catch (Exception ex)
            {

                 err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void PI_Seleccion(string buttonName)
        {
            try
            {
                uiProducto.Text = "";

                //Quitar seleccion de botones
                for (int i = 1; i <= 15; i++)
                {
                    Control controlA = Controls.Find("uiPI_" + i.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        FormatoDeseleccionBoton((SimpleButton)controlA);
                        
                    }


                }

                Control controlb = Controls.Find(buttonName, true).FirstOrDefault();
                if (controlb != null)
                {
                    FormatoSeleccionBoton((SimpleButton)controlb);
                    productoInsumoSeleccionado = new cat_productos();
                    productoInsumoSeleccionado.ProductoId = Convert.ToInt32(controlb.AccessibleName);

                    productoInsumoSeleccionado = ERP.Business.DataMemory.DataBucket.GetProductosMemory(false)
                   .Where(w => w.ProductoId == productoInsumoSeleccionado.ProductoId).FirstOrDefault();
                }

                if (productoInsumoSeleccionado != null)
                {
                    uiProducto.Text = productoInsumoSeleccionado.DescripcionCorta;

                    if (productoInsumoSeleccionado.ProdVtaBascula == true)
                    {
                        uiPeso.Enabled = true;
                        uiTimerBascula.Enabled = true;

                        if (puntoVentaContext.conectarConBascula)
                        {
                            try
                            {
                                basculaControlador.abrirBascula();
                            }
                            catch (Exception ex)
                            {
                                uiPeso.Enabled = true;
                                uiTimerBascula.Enabled = false;
                            }
                        }
                       

                    }
                    else
                    {
                        uiPeso.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void LlenarGrid()
        {
            try
            {
                oContext = new ERPProdEntities();
                produccionSel = oContext.doc_produccion
                    .Where(w => w.SucursalId == puntoVentaContext.sucursalId
                    && w.ProductoId == productoTerminadoSeleccionado.ProductoId
                    && w.Completado == false
                    ).FirstOrDefault();

                if (produccionSel != null)
                {
                    lstProduccionHistorial = oContext.doc_produccion_salida.Where(w => w.ProduccionId == produccionSel.ProduccionId)
                        .Select(s=> new Models.Produccion.ProduccionHistorialModel() {
                             Cantidad = s.Cantidad??0,
                              Descripcion = s.cat_productos.DescripcionCorta,
                               Fecha = s.CreadoEl,
                                Id = s.Id,
                                 ProduccionId = s.ProduccionId,
                                  ProductoId = s.ProductoId
                        })
                        .ToList();

                    //Obtener Configuracion
                    if(lstProductosSalidasPre != null)
                    {
                        lstProductosSalidasPre
                            .ForEach(f => f.existe =
                            lstProduccionHistorial.Where(w => w.ProductoId == f.productoId).Count() > 0 ? true : false);

                    }

                }
                else
                {
                    produccionSel = new doc_produccion();
                    produccionSel.Activo = true;
                    produccionSel.Completado = false;
                    produccionSel.CreadoEl = DateTime.Now;
                    produccionSel.CreadoPor = puntoVentaContext.usuarioId;
                    produccionSel.EstatusProduccionId = (int)ERP.Business.Enumerados.estatusProduccion.Registrada;
                    produccionSel.FechaHoraFin = null;
                    produccionSel.FechaHoraInicio = DateTime.Now;
                    produccionSel.ProductoId = productoTerminadoSeleccionado.ProductoId;
                    produccionSel.SucursalId = puntoVentaContext.sucursalId;
                    
                    result = ERP.Business.ProduccionBusiness.Guardar(ref produccionSel,puntoVentaContext.sucursalId);

                    if (!result.ok)
                    {
                        ERP.Utils.MessageBoxUtil.ShowError(result.error);
                        return;
                    }
                }

                oContext = new ERPProdEntities();
                lstProduccionHistorial = oContext.doc_produccion_entrada
                    .Where(w => w.ProduccionId == produccionSel.ProduccionId)
                    .Select(
                        s=> new ProduccionHistorialModel()
                        {
                             Cantidad = s.Cantidad,
                              Descripcion = s.cat_productos.DescripcionCorta,
                               Fecha = s.CreadoEl,
                                Id = s.Id,
                                 ProduccionId = s.ProduccionId,
                                  ProductoId = s.ProductoId
                        }
                    ).ToList();

                lstProduccionHistorial= lstProduccionHistorial.Union(
                    oContext.doc_produccion_salida
                    .Where(w => w.ProduccionId == produccionSel.ProduccionId)
                    .Select(
                        s => new ProduccionHistorialModel()
                        {
                            Cantidad = s.Cantidad ?? 0,
                            Descripcion = s.cat_productos.DescripcionCorta,
                            Fecha = s.CreadoEl,
                            Id = s.Id,
                            ProduccionId = s.ProduccionId,
                            ProductoId = s.ProductoId
                        }
                    )
                    ).ToList();

                uiGrid.DataSource = lstProduccionHistorial;

                HabilitarInsumo();
                HabilitarControlesCocimiento();


            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void GetConceptosAdicionales()
        {
            try
            {
                lstConceptos = oContext.cat_productos_base_conceptos
                    .Where(w => w.ProductoId == productoTerminadoSeleccionado.ProductoId).ToList();
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                  "ERP",
                                  this.Name,
                                  ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void Siguiente()
        {
            try
            {
                //Obtener el indice actual
                ProduccionProductoConfig itemActual = lstProductosSalidasPre.Where(w => w.productoId == productoInsumoSeleccionado.ProductoId)
                    .FirstOrDefault();

                //Validar si el item tiene
                if(lstProduccionHistorial.Where(w=> w.ProductoId == itemActual.productoId).Count() == 0
                    &&
                    itemActual.requerido
                    )
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("No es posible avanzar sin registrar el peso");
                }
                else
                {

                    if (lstProductosSalidasPre_listos.Count() == 0)
                    {
                        lstProductosSalidasPre_listos.Add(itemActual);
                    }

                    itemActual = lstProductosSalidasPre.Where(w => w.index == (itemActual.index + 1)).FirstOrDefault();
                    if (itemActual != null) {
                        lstProductosSalidasPre_listos.Add(itemActual);
                        BotonesInsumosDeshabilitar();
                        PI_Seleccion("uiPI_" + (itemActual.index + 1).ToString());
                    }
                    
                    
                }

            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void LimpiarSeccion2()
        {
            lstProduccionHistorial = new List<ProduccionHistorialModel>();            
            lstProductosSalidasPre_listos = new List<ProduccionProductoConfig>();
            uiGrid.DataSource = null;
            PT_Seleccion("uiPT_1");
        }
        #endregion



        #region eventos
        protected void uiPT_Click(object sender, EventArgs e)
        {
            SimpleButton button = sender as SimpleButton;
            PT_Seleccion(button.Name);
        }

        protected void uiPI_Click(object sender, EventArgs e)
        {
            SimpleButton button = sender as SimpleButton;
            PI_Seleccion(button.Name);
        }
        private void frmProduccionFormFast_Load(object sender, EventArgs e)
        {
            basculaControlador = new BasculaLectura(this.puntoVentaContext);
            GetBotonesProductoTerminado();
            LimpiarBotonesInsumos();
            HabilitarProduccion();
            ObtenCocimientosDia();
            if (soloHabilitarCocimiento)
            {
                PT_Seleccion("uiPT_1");
            }
        }

        private void frmProduccionFormFast_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }



        #endregion

        private void uiSiguiente_Click(object sender, EventArgs e)
        {
            Siguiente();
        }

        private void frmProduccionFormFast_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                #region VALIDACIONES
                if ((productoInsumoSeleccionado==null ? new cat_productos() : productoInsumoSeleccionado).ProductoId == 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Es necesario seleccionar un producto");
                    return;
                }
                if (uiPeso.Value <= 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Es necesario ingresar una cantidad para poder continuar");
                    return;
                }
                #endregion

                #region Nixtamal Sucio
                if(productoInsumoSeleccionado.DescripcionCorta.Contains("NIXTAMAL") && 
                    (productoInsumoSeleccionado.DescripcionCorta.Contains("SUCIO") || productoInsumoSeleccionado.DescripcionCorta.Contains("SOBRANTE")))
                {
                    doc_produccion_entrada entityEntradaSave = new doc_produccion_entrada();
                    entityEntradaSave.Cantidad = uiPeso.Value;
                    entityEntradaSave.CreadoEl = DateTime.Now;
                    entityEntradaSave.ProduccionId = produccionSel.ProduccionId;
                    entityEntradaSave.ProductoId = productoInsumoSeleccionado.ProductoId;
                    entityEntradaSave.UnidadId = productoInsumoSeleccionado.ClaveUnidadMedida ?? 0;

                    doc_produccion_salida entitySalidaSave = new doc_produccion_salida();
                    entitySalidaSave.Cantidad = uiPeso.Value;
                    entitySalidaSave.CreadoEl = DateTime.Now;
                    entitySalidaSave.ProduccionId = produccionSel.ProduccionId;
                    entitySalidaSave.ProductoId = productoInsumoSeleccionado.ProductoId;
                    entitySalidaSave.UnidadId = productoInsumoSeleccionado.ClaveUnidadMedida ?? 0;

                    if (productoInsumoSeleccionado.DescripcionCorta.Contains("SOBRANTE"))
                    {
                        result = ERP.Business.ProduccionBusiness.GuardarNixtamalSucio(ref entityEntradaSave, ref entitySalidaSave,
                           productoInsumoSeleccionado.ProdVtaBascula ?? false,
                           puntoVentaContext.usuarioId,
                           puntoVentaContext.sucursalId,
                           true);
                    }
                    else
                    {
                        result = ERP.Business.ProduccionBusiness.GuardarNixtamalSucio(ref entityEntradaSave, ref entitySalidaSave,
                           productoInsumoSeleccionado.ProdVtaBascula ?? false,
                           puntoVentaContext.usuarioId,
                           puntoVentaContext.sucursalId,
                           false);
                    }

                   

                    if (!result.ok)
                    {
                        ERP.Utils.MessageBoxUtil.ShowError(result.error);
                        return;
                    }

                }
                #endregion

                else
                {                
                    #region Nixtamal Sucio
                    if (productoInsumoSeleccionado.DescripcionCorta.Contains("NIXTAMAL") && (productoInsumoSeleccionado.DescripcionCorta.Contains("LIMPIO") || productoInsumoSeleccionado.DescripcionCorta.Contains("LAVADO")))
                    {
                        doc_produccion_salida entitySalidaSave = new doc_produccion_salida();
                        entitySalidaSave.Cantidad = uiPeso.Value;
                        entitySalidaSave.CreadoEl = DateTime.Now;
                        entitySalidaSave.ProduccionId = produccionSel.ProduccionId;
                        entitySalidaSave.ProductoId = productoInsumoSeleccionado.ProductoId;
                        entitySalidaSave.UnidadId = productoInsumoSeleccionado.ClaveUnidadMedida ?? 0;

                        result = ERP.Business.ProduccionBusiness.AgregarSalida(
                            ref entitySalidaSave,
                            productoInsumoSeleccionado.ProdVtaBascula ?? false,
                            puntoVentaContext.usuarioId,
                            puntoVentaContext.sucursalId
                            );
                        if (!result.ok)
                        {
                            ERP.Utils.MessageBoxUtil.ShowError(result.error);
                        }

                    }
                    #endregion
                    else
                    {
                        if (productoInsumoSeleccionado.ProductoId != productoTerminadoSeleccionado.ProductoId)
                        {
                            doc_produccion_entrada entityEntradaSave = new doc_produccion_entrada();
                            entityEntradaSave.Cantidad = uiPeso.Value;
                            entityEntradaSave.CreadoEl = DateTime.Now;
                            entityEntradaSave.ProduccionId = produccionSel.ProduccionId;
                            entityEntradaSave.ProductoId = productoInsumoSeleccionado.ProductoId;
                            entityEntradaSave.UnidadId = productoInsumoSeleccionado.ClaveUnidadMedida ?? 0;

                            result = ERP.Business.ProduccionBusiness.AgregarEntrada(
                                ref entityEntradaSave,
                                productoInsumoSeleccionado.ProdVtaBascula ?? false,
                                puntoVentaContext.usuarioId,
                                puntoVentaContext.sucursalId
                                );

                            if (!result.ok)
                            {
                                ERP.Utils.MessageBoxUtil.ShowError(result.error);
                            }

                        }
                        else
                        {
                            doc_produccion_salida entitySalidaSave = new doc_produccion_salida();
                            entitySalidaSave.Cantidad = uiPeso.Value;
                            entitySalidaSave.CreadoEl = DateTime.Now;
                            entitySalidaSave.ProduccionId = produccionSel.ProduccionId;
                            entitySalidaSave.ProductoId = productoInsumoSeleccionado.ProductoId;
                            entitySalidaSave.UnidadId = productoInsumoSeleccionado.ClaveUnidadMedida ?? 0;

                            result = ERP.Business.ProduccionBusiness.AgregarSalida(
                                ref entitySalidaSave,
                                productoInsumoSeleccionado.ProdVtaBascula ?? false,
                                puntoVentaContext.usuarioId,
                                puntoVentaContext.sucursalId
                                );
                            if (!result.ok)
                            {
                                ERP.Utils.MessageBoxUtil.ShowError(result.error);
                            }

                        }
                    }

                }



                LlenarGrid();

                uiPeso.Value = 0;

                ERP.Utils.MessageBoxUtil.ShowOk();
            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                     "ERP",
                                                     this.Name,
                                                     ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiTerminar_Click(object sender, EventArgs e)
        {
            try
            {

                if(
                    lstProduccionHistorial.Where(w=> w.ProductoId == productoTerminadoSeleccionado.ProductoId).Count() == 0 &&
                    !productoTerminadoSeleccionado.DescripcionCorta.Contains("01") && !productoTerminadoSeleccionado.DescripcionCorta.Contains("02")
                    )
                {
                    ERP.Utils.MessageBoxUtil.ShowError("No es posible terminar la producción, falta registro "+productoTerminadoSeleccionado.DescripcionCorta);
                    return;
                }

                if(XtraMessageBox.Show("¿Está seguro de continuar?, no será posible revertir los cambios", "Aviso", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    result = ERP.Business.ProduccionBusiness.TerminarProduccion(produccionSel.ProduccionId, this.puntoVentaContext);

                    if (!result.ok)
                    {
                        ERP.Utils.MessageBoxUtil.ShowError(result.error);
                    }
                    else
                    {
                        LimpiarSeccion2();
                        ERP.Utils.MessageBoxUtil.ShowOk();
                    }
                }

               
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                     "ERP",
                                                     this.Name,
                                                     ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiTimerBascula_Tick(object sender, EventArgs e)
        {
            try
            {
                if (puntoVentaContext.conectarConBascula)
                {
                    uiPeso.EditValue = basculaControlador.ObtenPeso();
                }
                else
                {
                    uiPeso.EditValue = basculaControlador.ObtenPesoBD();
                }
                
            }
            catch (Exception ex)
            {
                uiTimerBascula.Enabled = false;
                uiPeso.Enabled = true;
                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }

        }

        private void repBtnDel1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(XtraMessageBox.Show("¿Está seguro(a) de continuar?, no será posible revertir los cambios","Aviso",MessageBoxButtons.YesNo,MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    ProduccionHistorialModel gridRow = (ProduccionHistorialModel)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                    if(gridRow != null)
                    {
                        result = ERP.Business.ProduccionBusiness.EliminarDetalle(gridRow.Id, 
                            gridRow.ProductoId == productoTerminadoSeleccionado.ProductoId ? true : false, puntoVentaContext.usuarioId,
                            puntoVentaContext.sucursalId);

                        if (result.ok)
                        {
                            LlenarGrid();
                            ERP.Utils.MessageBoxUtil.ShowOk();
                        }
                        else
                        {
                            ERP.Utils.MessageBoxUtil.ShowError(result.error);
                        }
                    }

                    
                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                     "ERP",
                                     this.Name,
                                     ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiConceptos_Click(object sender, EventArgs e)
        {
            frmProduccionConceptos frm = new frmProduccionConceptos();
            frm.puntoVentaContext = this.puntoVentaContext;
            frm.lstConceptos = this.lstConceptos;
            frm.ProduccionID = this.produccionSel.ProduccionId;
            frm.ShowDialog();
        }

        private void uiFinalizarCocimiento_Click(object sender, EventArgs e)
        {
            try
            {
                #region validaciones cocimiento
                if(uiCocimientoAgua.Value <= 0 || uiCocimientoGas1.Value <=0 || uiCocimientoGas2.Value <= 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("No es posible continuar, complete la información de AGUA y GAS");
                    return;
                }
                #endregion

              
                if (XtraMessageBox.Show("¿Está seguro de continuar?, no será posible revertir los cambios", "Aviso", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    result = ERP.Business.ProduccionBusiness.TerminarCocimientoProduccion(produccionSel.ProduccionId, uiCocimientoAgua.Value,
                        uiCocimientoGas1.Value, uiCocimientoGas2.Value, this.puntoVentaContext);

                    if (!result.ok)
                    {
                        ERP.Utils.MessageBoxUtil.ShowError(result.error);
                    }
                    else
                    {
                        LimpiarCapturaCocimiento();
                        LimpiarSeccion2();
                        ERP.Utils.MessageBoxUtil.ShowOk();
                    }
                }


            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                     "ERP",
                                                     this.Name,
                                                     ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }   

        private void uiIniciarCocimiento_Click(object sender, EventArgs e)
        {
            ResultAPIModel result = ERP.Business.ProduccionBusiness.IniciarCocimientoProduccion(produccionSel.ProduccionId, this.puntoVentaContext);
            if (!result.ok)
            {
                ERP.Utils.MessageBoxUtil.ShowErrorBita(0);
            }
            else
            {
                produccionSel = oContext.doc_produccion
                    .Where(w => w.ProduccionId == produccionSel.ProduccionId).FirstOrDefault();
                gcInsumos.Enabled = true;
                HabilitarControlesCocimiento();
                SetSoloHabilitarCocimiento();
                HabilitarProduccion();
                GetBotonesProductoTerminado();
            }
        }

        private void HabilitarInsumo()
        {
            if (esCocimiento)
            {
                if (produccionSel.doc_cocimientos.Count() == 0)
                {
                    gcInsumos.Enabled = false;
                }
            }
            else
            {
                gcInsumos.Enabled = true;
            }
        }

        private void HabilitarControlesCocimiento()
        {
            if (esCocimiento)
            {
                if(produccionSel.doc_cocimientos.Count() > 0)
                {
                    uiIniciarCocimiento.Enabled = false;
                    uiFinalizarCocimiento.Enabled = true;
                }
                else
                {
                    uiIniciarCocimiento.Enabled = true;
                    uiFinalizarCocimiento.Enabled = false;
                }
             
                HabilitarProduccion();
            }
           
        }

        private void ObtenCocimientosDia()
        {
            try
            {
                oContext = new ERPProdEntities();
                uiCocimientosDia.EditValue = oContext.doc_cocimientos
                    .Where(w => w.doc_produccion.SucursalId == puntoVentaContext.sucursalId && w.FechaHabilitado == null &&
                    DbFunctions.TruncateTime(w.FechaCocimiento)== DbFunctions.TruncateTime(DateTime.Now) &&
                    w.FechaHoraFin != null).Select(S=> S.CocimientoId).Distinct().Count();
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                     "ERP",
                                                     this.Name,
                                                     ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void LimpiarCapturaCocimiento()
        {
            uiCocimientoAgua.EditValue = 0;
            uiCocimientoGas1.EditValue = 0;
            uiCocimientoGas2.EditValue = 0;
        }

        private void uiHabilitarCocimiento_Click(object sender, EventArgs e)
        {
            if(oContext.doc_cocimientos_grupos
                .Where(w=> DbFunctions.TruncateTime(w.CreadoEl) == DbFunctions.TruncateTime(DateTime.Now)).Count() > 0)
            {
                ERP.Utils.MessageBoxUtil.ShowWarning("Ya hay un grupo de cocimientos para el día");
                return;
            }
            ResultAPIModel result = ERP.Business.ProduccionBusiness.HabilitarCocimientos(this.puntoVentaContext.sucursalId,this.puntoVentaContext.usuarioId);
            if (result.ok)
            {
                ObtenCocimientosDia();
            }
        }

        private void uiFinalizarProduccion_Click(object sender, EventArgs e)
        {
            try
            {
                if(XtraMessageBox.Show("¿Está seguro(a) de continuar?, ya no será posible realizar movimientos de producción en el resto del día","Aviso",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    doc_produccion_finalizada entity = new doc_produccion_finalizada();

                    entity.SucursalId = puntoVentaContext.sucursalId;
                    entity.CreadoEl = DateTime.Now;
                    oContext.doc_produccion_finalizada.Add(entity);
                    oContext.SaveChanges();

                    HabilitarProduccion();
                }
               
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                      "ERP",
                                                      this.Name,
                                                      ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void HabilitarProduccion()
        {
            try
            {
                oContext = new ERPProdEntities();

                if(oContext.doc_produccion_finalizada.Where(
                    w=> w.SucursalId == puntoVentaContext.sucursalId &&
                     DbFunctions.TruncateTime(w.CreadoEl) == DbFunctions.TruncateTime(DateTime.Now)
                ).Count() > 0)
                {
                    uiGuardar.Enabled = false;
                    uiSiguiente.Enabled = false;
                    uiTerminar.Enabled = false;
                    uiFinalizarProduccion.Enabled = false;
                    gcInsumos.Enabled = false;
                    gcCocimiento.Enabled = false;
                }
                else
                {
                    uiGuardar.Enabled = true;
                    uiSiguiente.Enabled = true;
                    uiTerminar.Enabled = true;
                    uiFinalizarProduccion.Enabled = true;
                    gcInsumos.Enabled = true;
                    gcCocimiento.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                     "ERP",
                                                     this.Name,
                                                     ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiPedidosMayoreo_Click(object sender, EventArgs e)
        {
            frmBasculaExpress frmo = frmBasculaExpress.GetInstance();

            frmo.puntoVentaContext = this.puntoVentaContext;
            frmo.WindowState = FormWindowState.Normal;
            frmo.tipoForm = "PRODUCCION";
            frmo.ShowDialog();
        }

        private void uiMasaFria_Click(object sender, EventArgs e)
        {
            frmRecepcionProducto frmo = frmRecepcionProducto.GetInstance();
            if (!frmo.Visible)
            {                
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.tipoMovimiento = Enumerados.tipoMovsInventario.entradaDirecta;
                frmo.ClaveProductoDefault = "F0001";
                frmo.ShowDialog();
            }
        }

        private void uiDesperdicioMasa_Click(object sender, EventArgs e)
        {
            frmRecepcionProducto frmo = frmRecepcionProducto.GetInstance();
            if (!frmo.Visible)
            {
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.tipoMovimiento = Enumerados.tipoMovsInventario.desperdicioInventario;
                frmo.ClaveProductoDefault = "2";
                frmo.ShowDialog();
            }
        }

        private void uiDesperdicioTortilla_Click(object sender, EventArgs e)
        {
            frmRecepcionProducto frmo = frmRecepcionProducto.GetInstance();
            if (!frmo.Visible)
            {
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.tipoMovimiento = Enumerados.tipoMovsInventario.desperdicioInventario;
                frmo.ClaveProductoDefault = "1";
                frmo.ShowDialog();
            }
        }
    }
}
