using ERPv1.Catalogos;
using ERPv1.Inventarios;
using ERPv1.Procesos;
using ERPv1.Productos;
using Productos;
using System;
using System.Linq;
using System.Windows.Forms;
using ERP.Common.Inventarios;
using ERP.Common.Catalogos;
using ERP.Common.Reports;
using ERP.Procesos;
using ERP.Common.Produccion;
using ERP.Common.Catalogos.Restaurante;
using ConexionBD;
using ERP.Common.Configuracion;
using ERPv1.Reports;
using ERPv1.Seguridad;
using ERPv1.Utilerias;
using ERP.Models;
using ERP.Common.Base;
using ERP.Common.Basculas;
using ERPv1.Clientes;
using ERP.Common.Pedido;
using ERPv1.Cargos;
using ERP.Common.Productos;
using ERP.Common.Precios;
using ERPv1.Reportes;
using ERP.Common.CorteCaja;
using ERP.Common.Sucursales;
using ERPv1.Gastos;

namespace ERPv1
{
    public partial class frmMenu : FormBaseWinForm
    {
        private static frmMenu _instance;

        public static frmMenu GetInstance()
        {
            if (_instance == null) _instance = new frmMenu();
            else _instance.BringToFront();
            return _instance;
        }

        public frmMenu()
        {
            InitializeComponent();
        }
        
        private  void frmMenu_Load(object sender, EventArgs e)
        {
            if (puntoVentaContext.giroPuntoVenta == Enumerados.systemGiro.REST.ToString())
            {
                uiMenuRestaurante.Visible = true;
            }
            else
            {
                uiMenuRestaurante.Visible = false;
            }

            oContext = new ERPProdEntities();
            bool configIni = oContext.p_cat_configuracion_ini_exis(puntoVentaContext.sucursalId).FirstOrDefault().Value;
            
            if(!configIni)
            {
                ConfigInicial frmo = ConfigInicial.GetInstance();

                if (!frmo.Visible)
                {
                    //frmo = new frmPuntoVenta();
                    frmo.MdiParent = this;
                    frmo.puntoVentaContext = this.puntoVentaContext;
                    frmo.WindowState = FormWindowState.Maximized;
                    frmo.Show();

                }
            }

            HabilitarDeshabilitarMenu();
        }

        private void HabilitarDeshabilitarMenu()
        {
            if(puntoVentaContext.usuarioId != 1)
            {
                tsCatalogos.Visible = false;
                tsRH.Visible = false;
                cargosToolStripMenuItem.Visible = false;
                tsConfiguracion.Visible = false;
                cambioDePreciosListadoToolStripMenuItem.Visible = false;
                cambioDePrecioIndividualToolStripMenuItem.Visible = false;

            }
        }

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #region Eventos

        #region Catálogos

        private void tsiEmpresas_Click(object sender, EventArgs e)
        {
            Catalogos.frmEmpresas frm = new Catalogos.frmEmpresas();
            frm.Show();
        }

        private void tsiSucursales_Click(object sender, EventArgs e)
        {
            Catalogos.frmSucursales frm = new Catalogos.frmSucursales();
            frm.Show();
        }

        private void familiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmFamilias frm = new Catalogos.frmFamilias();
            frm.Show();
        }
                
        private void divisiónSATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmDivisionesSat frm = new Catalogos.frmDivisionesSat();
            frm.Show();
        }

        private void gruposSATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmGruposSat frm = new Catalogos.frmGruposSat();
            frm.Show();
        }

        private void clasesSATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmClasesSat frm = new Catalogos.frmClasesSat();
            frm.Show();
        }

        private void subClasesSATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmSubClasesSat frm = new Catalogos.frmSubClasesSat();
            frm.Show();
        }

        private void tsiSubFamilias_Click(object sender, EventArgs e)
        {
            Catalogos.frmSubFamilias frm = new Catalogos.frmSubFamilias();
            frm.Show();
        }
        
        private void almacenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void anaquelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmAnaqueles frm = new Catalogos.frmAnaqueles();
            frm.Show();
        }

        private void andenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmAndenes frm = new Catalogos.frmAndenes();
            frm.Show();
        }

        private void centroDeCostosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Catalogos.frmCentroCostos frm = new Catalogos.frmCentroCostos();
            //frm.Show();
        }

        private void denominacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmDenominaciones frm = new Catalogos.frmDenominaciones();
            frm.Show();
        }

        private void girosDeNegocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmGirosNegocio frm = new Catalogos.frmGirosNegocio();
            frm.Show();
        }

        private void lotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmLotes frm = new Catalogos.frmLotes();
            frm.Show();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmMarca frm = new Catalogos.frmMarca();
            frm.Show();
        }

        private void monedasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmMonedas frm = new Catalogos.frmMonedas();
            frm.Show();
        }

        private void unidadesDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmUnidadesMedida frm = new Catalogos.frmUnidadesMedida();
            frm.Show();
        }

        private void tsiCajas_Click(object sender, EventArgs e)
        {
            Catalogos.frmCajas frm = new Catalogos.frmCajas();
            frm.puntoVentaContext = this.puntoVentaContext;
            frm.Show();
        }

        private void tsiRubros_Click(object sender, EventArgs e)
        {
            Catalogos.frmRubros frm = new Catalogos.frmRubros();
            frm.Show();
        }

        private void tsiLineas_Click(object sender, EventArgs e)
        {
        }

        private void tsmGastos_Click(object sender, EventArgs e)
        {
            Catalogos.frmGastos frm = new Catalogos.frmGastos();
            frm.Show();
        }

        #endregion

        #region R.H.

        private void tsiDepartamentos_Click(object sender, EventArgs e)
        {
            RH.frmDepartamentos frm = new RH.frmDepartamentos();
            frm.Show();
        }

        private void tsiEstatusEmpleado_Click(object sender, EventArgs e)
        {
            RH.frmEstatusEmpleado frm = new RH.frmEstatusEmpleado();
            frm.Show();
        }

        private void tsiTipoContrato_Click(object sender, EventArgs e)
        {
            RH.frmTipoContrato frm = new RH.frmTipoContrato();
            frm.Show();
        }

        private void tsiAltaPersonal_Click(object sender, EventArgs e)
        {
            RH.frmAltaPersonal frm = new RH.frmAltaPersonal();
            frm.puntoVentaContext = this.puntoVentaContext;
            frm.Show();
        }

        private void tsiPuestos_Click(object sender, EventArgs e)
        {
            RH.frmPuestos frm = new RH.frmPuestos();
            frm.Show();
        }

        private void tsiUsuarioSistema_Click(object sender, EventArgs e)
        {
            frmUsuarios frmo = frmUsuarios.GetInstance();

            if (!frmo.Visible)
            {
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.ShowDialog();
            }
        }

        private void tsiFormaPago_Click(object sender, EventArgs e)
        {
            RH.frmFormaPagoNomina frm = new RH.frmFormaPagoNomina();
            frm.Show();
        }


        #endregion

        #region Productos

        private void tsiCatProductos_Click(object sender, EventArgs e)
        {
            //Productos.frmPoductos frm = new Productos.frmPoductos();
            //frm.puntoVentaContext = this.puntoVentaContext;
            //frm.Show();

       

            ERP.Common.Catalogos.frmProductos frmo = ERP.Common.Catalogos.frmProductos.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();

            }
        }

        #endregion

        #endregion

        private void clasificaciónSATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmClasificacionImpuesto frm = new Catalogos.frmClasificacionImpuesto();
            frm.Show();
        }

        private void tipoFactorSATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmTipoFactorSAT frm = new Catalogos.frmTipoFactorSAT();
            frm.Show();
        }

        private void abreviaturasSATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmAbreviaturaSAT frm = new Catalogos.frmAbreviaturaSAT();
            frm.Show();
        }

        private void impuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmImpuestos frm = new Catalogos.frmImpuestos();
            frm.Show();
        }

        private void monedasAbreviaturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmMonedasAbreviaturas frm = new Catalogos.frmMonedasAbreviaturas();
            frm.Show();
        }

        private void unidadesMedidaSATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmUnidadesMedidaSAT frm = new Catalogos.frmUnidadesMedidaSAT();
            frm.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Seguridad.frmUsuarios frm = new Seguridad.frmUsuarios();
            frm.Show();

        }

        private void tsClientes_Click(object sender, EventArgs e)
        {
            //Catalogos.frmClientes frm = new Catalogos.frmClientes();
            //frm.Show();
        }

        private void tsProveedores_Click(object sender, EventArgs e)
        {
            Catalogos.frmProveedores frm = new Catalogos.frmProveedores();
            frm.Show();
        }

        private void tsTiposDocumento_Click(object sender, EventArgs e)
        {
            Catalogos.frmTiposDocumento frm = new Catalogos.frmTiposDocumento();
            frm.Show();
        }

        private void tsFormasPago_Click(object sender, EventArgs e)
        {
            Catalogos.frmFormasPago frm = new Catalogos.frmFormasPago();
            frm.Show();
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductosCompra frmo = frmProductosCompra.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;

                frmo.Show();

            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmClientes frm = new Catalogos.frmClientes();
            frm.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmProveedores frm = new Catalogos.frmProveedores();
            frm.Show();
        }

        private void girosDeNegocioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Catalogos.frmGirosNegocio frm = new Catalogos.frmGirosNegocio();
            frm.Show();
        
        }

        private void líneasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmLineas frm = new Catalogos.frmLineas();
            frm.Show();
        }

        private void familiasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Catalogos.frmFamilias frm = new Catalogos.frmFamilias();
            frm.Show();
        }

        private void subfamiliasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmSubFamilias frm = new Catalogos.frmSubFamilias();
            frm.Show();
        }

        private void almacenesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Catalogos.frmAlmacenes frm = new Catalogos.frmAlmacenes();
            frm.Show();
        }

        private void anaquelesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Catalogos.frmAnaqueles frm = new Catalogos.frmAnaqueles();
            frm.Show();
        }

        private void andenesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Catalogos.frmAndenes frm = new Catalogos.frmAndenes();
            frm.Show();
        }

        private void centroDeCostosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Catalogos.frmCentroCostos frm = new Catalogos.frmCentroCostos();
            frm.Show();
        }

        private void gastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmGastos frm = new Catalogos.frmGastos();
            frm.Show();
        }

        private void promocionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPromocionesList frmo = frmPromocionesList.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void configuradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfigurador frmo = frmConfigurador.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void cargaInicialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargaInicialUpd frmo = CargaInicialUpd.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void salidaPorTraspasoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void entradaPorTraspasoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEntradaTraspasoList frmo = frmEntradaTraspasoList.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void entradaPorCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductosCompra frmo = frmProductosCompra.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.Show();
            }
        }

        private void ajustesPorEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmAjusteEntradaList frmo = frmAjusteEntradaList.GetInstance();

            //if (!frmo.Visible)
            //{
            //    //frmo = new frmPuntoVenta();
            //    frmo.MdiParent = this;
            //    frmo.puntoVentaContext = this.puntoVentaContext;
            //    frmo.Show();
            //}

            frmInventarioMovList frmo = frmInventarioMovList.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.tipoMovimientoInv = ERP.Business.Enumerados.tipoMovimientoInventario.AjustePorEntrada;
                frmo.Show();
            }
        }

        private void ajustePorSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void entradaDirectaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEntradaDirectaList frmo = frmEntradaDirectaList.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void kardexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductoKardex frmo = frmProductoKardex.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void frmMenu_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void frmMenu_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void existenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExistenciasV2 frmo = frmExistenciasV2.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void importarExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigInicial frmo = ConfigInicial.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void configuradorTicketVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfiguracionTicketVenta frmo = frmConfiguracionTicketVenta.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void configuradorTicketApartadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfiguracionTicketApartado frmo = frmConfiguracionTicketApartado.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void existenciasAgrupadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExistenciasAgrupado frmo = frmExistenciasAgrupado.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void notasDeVentaResumidoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmRptNotasVentaResumido frmo = frmRptNotasVentaResumido.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void notasDeVentaDetalladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptNotasVentaDetallado frmo = frmRptNotasVentaDetallado.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void corteDeCajaResumidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptCorteCajaResumido frmo = frmRptCorteCajaResumido.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void corteDeCajaDetalladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptCorteCajaDetallado frmo = frmRptCorteCajaDetallado.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void ventasVendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptVentasVendedor frmo = frmRptVentasVendedor.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void productosVendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptProductosVendidos frmo = frmRptProductosVendidos.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void corteCajaReimpresiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCorteCaja frmo = frmCorteCaja.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRptClientesApartado frmo = frmRptClientesApartado.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void apartadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApartados frmo = frmApartados.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void existenciasValuoAgrupadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExistenciasValuoAgrupado frmo = frmExistenciasValuoAgrupado.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void importarFotosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportarFotos frmo = frmImportarFotos.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void agruparProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductosGrouplist frmo = frmProductosGrouplist.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void producciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduccionUpd frmo = frmProduccionUpd.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.accion = ConexionBD.Enumerados.accionForm.agregar;
                frmo.Show();
            }
        }

        private void uiMenuRestaurante_Click(object sender, EventArgs e)
        {

        }

        private void mesasToolStripMesas_Click(object sender, EventArgs e)
        {
            frmMesas frmo = frmMesas.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;                
                frmo.Show();
            }
        }

        private void comandasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmComandas frmo = frmComandas.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void adicionalesEnPlatillosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPlatillosAdicionalesEdit frmo = frmPlatillosAdicionalesEdit.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void impresorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImpresoras frmo = frmImpresoras.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void configuraciónInicialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigInicial frmo = ConfigInicial.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void reporteDeVentasPorMesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptNotasVentaResumido_Mesa frmo = frmRptNotasVentaResumido_Mesa.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.Show();
            }
        }

        private void promocionesCompraMínimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPromocionesCMList frmo = frmPromocionesCMList.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void usuariosYRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmUsuariosRoles frmo = frmUsuariosRoles.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void cargosAdicionalesConfiguraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCargoAdicionalConfig frmo = frmCargoAdicionalConfig.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void respaldosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRespaldos frm = new frmRespaldos();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void timerMinimos_Tick(object sender, EventArgs e)
        {
            ERP.Business.ProductoBusiness oProducto = new ERP.Business.ProductoBusiness();
            ResultAPIModel oResult =  oProducto.GenerarAvisoMinMax();
        }

        private void máximosYMInimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ERP.Common.Productos.frmMaximosMinimos frmo = ERP.Common.Productos.frmMaximosMinimos.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void tsPoliticas_Click(object sender, EventArgs e)
        {

        }

        private void salidasPorTraspasoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventarioMovList frmo = frmInventarioMovList.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.tipoMovimientoInv = ERP.Business.Enumerados.tipoMovimientoInventario.SalidaPorTraspaso;
                frmo.Show();
            }
            //frmSalidaTraspasoList frmo = frmSalidaTraspasoList.GetInstance();

            //if (!frmo.Visible)
            //{
            //    //frmo = new frmPuntoVenta();
            //    frmo.MdiParent = this;
            //    frmo.puntoVentaContext = this.puntoVentaContext;
            //    frmo.Show();

            //}
        }

        private void salidaPorAjusteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmAjusteSalidaList frmo = frmAjusteSalidaList.GetInstance();

            //if (!frmo.Visible)
            //{
            //    //frmo = new frmPuntoVenta();
            //    frmo.MdiParent = this;
            //    frmo.puntoVentaContext = this.puntoVentaContext;
            //    frmo.Show();

            //}

            frmInventarioMovList frmo = frmInventarioMovList.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.tipoMovimientoInv = ERP.Business.Enumerados.tipoMovimientoInventario.AjustePorSalida;
                frmo.Show();
            }
        }

        private void guisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGuisos frmo = frmGuisos.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;

                frmo.Show();
            }
        }

        private void productosGuisisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductosGuisos frmo = frmProductosGuisos.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;

                frmo.Show();
            }
        }

        private void bitácoraDeExcepcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBitacoraExcepciones frmo = frmBitacoraExcepciones.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;

                frmo.Show();
            }
        }

        private void empresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmEmpresas frm = new Catalogos.frmEmpresas();
            frm.Show();
        }

        private void sucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmSucursales frm = new Catalogos.frmSucursales();
            frm.Show();
        }

        private void políticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPoliticas frmo = frmPoliticas.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmBasculaList frmo = frmBasculaList.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void configuracionBasculaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasculaConfiguracion frmo = BasculaConfiguracion.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void bitácoraBásculasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBasculaBitacora frmo = frmBasculaBitacora.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void cambiarSucursalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.OpenForms["frmInicioSesion"].Show();
            //frmSucursalSeleccion frmo = new frmSucursalSeleccion();
            //frmo.puntoVentaContext = this.puntoVentaContext;
            //frmo.ShowDialog();
        }

        private void productosRecepciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSucursalProductoRecepcion2 frmo = frmSucursalProductoRecepcion2.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void preciosPorClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientesPrecios frmo = frmClientesPrecios.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void pedidosPorClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPedidosClientesList frmo = frmPedidosClientesList.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void uiMenuSesion_Click(object sender, EventArgs e)
        {
            
        }

        private void cargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCargosList frmo = frmCargosList.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void sucursalesDepartamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSucursalesDepartamentos frmo = frmSucursalesDepartamentos.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void tiposDeDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogos.frmTiposDocumento frm = new Catalogos.frmTiposDocumento();
            frm.Show();
        }

        private void tiposMermaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTiposMerma frmo = frmTiposMerma.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void productosProducciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSucursalProductoProduccion frmo = frmSucursalProductoProduccion.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void descuentosEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpleadosDescuentos frmo = frmEmpleadosDescuentos.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void registroExpressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductoInventarioForm oForm = new frmProductoInventarioForm();
            oForm.puntoVentaContext = this.puntoVentaContext;
            oForm.ShowDialog();
        }

        private void cambioDePrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductoInventarioForm oForm = new frmProductoInventarioForm();
            oForm.esParaCambioPrecio = true;
            oForm.puntoVentaContext = this.puntoVentaContext;
            oForm.ShowDialog();
        }

        private void registroDeInevntarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventarioRegistro oForm = new frmInventarioRegistro();
            oForm.puntoVentaContext = this.puntoVentaContext;
            oForm.StartPosition = FormStartPosition.CenterScreen;
            oForm.ShowDialog();
        }

        private void salidaDirectaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRecepcionProducto frmo = frmRecepcionProducto.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.tipoMovimiento = Enumerados.tipoMovsInventario.ajustePorSalida;
                frmo.Show();
            }
        }

        private void gruposDePreciosEspecialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPreciosEspeciales frmo = frmPreciosEspeciales.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                
                frmo.Show();
            }
        }

        private void estadoDeCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstadoCuenta frmo = frmEstadoCuenta.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;

                frmo.Show();
            }
        }

        private void registroDiarioDeTiradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCorteCajaTortilleriaDatos frmo = frmCorteCajaTortilleriaDatos.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;

                frmo.Show();
            }
        }

        private void registroSobrantesConsultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPreferenciaSucursal frmo = frmPreferenciaSucursal.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;

                frmo.Show();
            }
        }

        private void preferenciasPorSucursalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ERPv1.Preferencia.frmPreferenciaSucursalUpd frmo = ERPv1.Preferencia.frmPreferenciaSucursalUpd.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;

                frmo.Show();
            }
        }

        private void corteDeCajaParaTortilleriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ERP.Common.Reports.frmCorteCajaTortilleria frmo = ERP.Common.Reports.frmCorteCajaTortilleria.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;

                frmo.Show();
            }
        }

        private void cambioDePrecioIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductoInventarioForm oForm = new frmProductoInventarioForm();
            oForm.esParaCambioPrecio = true;
            oForm.puntoVentaContext = this.puntoVentaContext;
            oForm.ShowDialog();
        }

        private void gruposDePreciosEspecialesConVigenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPreciosEspeciales frmo = frmPreciosEspeciales.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;

                frmo.Show();
            }
        }

        private void cambioDePreciosListadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCambioPrecioList frmo = frmCambioPrecioList.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;

                frmo.Show();
            }
        }

        private void configuraciónProducciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduccionUpd frmo = frmProduccionUpd.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();

                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.MdiParent = this;
                frmo.accion = ConexionBD.Enumerados.accionForm.actualizar;
                frmo.id = 0;
                frmo.habilitarCambioProducto = true;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void productosPorSucursalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSucursalesProductos frmo = frmSucursalesProductos.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();

                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.MdiParent = this;             
                
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void salidasPorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void corteDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gastosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmGastosNegocioList frmo = frmGastosNegocioList.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();

                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.MdiParent = this;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void estadoDeCuentaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEstadoCuenta frmo = frmEstadoCuenta.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void productosEdiciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductoListEdit frmo = frmProductoListEdit.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void registroDiarioMaizMolinoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCorteCajaMaizDiario frmo = frmCorteCajaMaizDiario.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void registroDiarioDeConsumoDeMaizYMasecaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistroMaizMaseca frmo = frmRegistroMaizMaseca.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void entradaPorDevolucionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventarioMovList frmo = frmInventarioMovList.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.tipoMovimientoInv = ERP.Business.Enumerados.tipoMovimientoInventario.SalidaPorTraspasoDev;
                frmo.Show();
            }
        }

        private void tsRH_Click(object sender, EventArgs e)
        {

        }

        private void usuariosSucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuariosSucursales frmo = frmUsuariosSucursales.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();

                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.MdiParent = this;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void toolStripDropDownButton3_Click(object sender, EventArgs e)
        {

        }

        private void preferenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void preferenciasPorEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ERPv1.Preferencia.frmPreferenciaEmpresaUpd frmo = ERPv1.Preferencia.frmPreferenciaEmpresaUpd.GetInstance();
            if (!frmo.Visible)
            {
                frmo.MdiParent = this;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.StartPosition = FormStartPosition.CenterScreen;
                frmo.WindowState = FormWindowState.Maximized;
                frmo.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
