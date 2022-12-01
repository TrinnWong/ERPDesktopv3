using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;

using DevExpress.XtraReports.UI;
using ERP.Business;
using ERP.Business.Tools;
using ERP.Common.Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TacosAna.Desktop
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        /*
         * 0 Geral
         * 1 Tacoas Ana
         */
        
        int dia=0;
        int mes = 0;
        int anio = 0;
        ConexionBD.Sistema oSistema;
        ConexionBD.LoginCaja oLogin;
        ERPProdEntities oContext;
        public Login()
        {
            InitializeComponent();
            oSistema = new Sistema();
          

            string error = oSistema.actualizarVersion(false);

            if (error.Length > 0)
            {
                MessageBox.Show(
                    "Ocurrió un error al actualizar la versión del sistema, por favor avise al administrador. Puede seguir utilizando la aplicación"
                    + error
                    , "ERROR"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);

                return;
            }

            oContext = new ERPProdEntities();
            oLogin = new ConexionBD.LoginCaja();
            uiCaja.DataSource = null;// oContext.cat_cajas.ToList();
          
          
            
        }

        private void llenarSucursalesUsuario()
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            entrar();
           
        }

        public void entrarDemo()
        {

            try
            {
                cat_usuarios usuario = null;
                bool esSupervisor = false;


                if (uiSucursal.SelectedValue == null)
                {
                    MessageBox.Show("Es necesario ingresar la sucrusal", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (uiCaja.SelectedValue == null)
                {
                    MessageBox.Show("Es necesario ingresar la caja", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int sucursalId = (int)uiSucursal.SelectedValue;
                int cajaId = (int)uiCaja.SelectedValue;
                int sesionId = 0;

                string error = oLogin.validarLogin(uiUsuario.Text, uiPassword.Text, uiCaja.SelectedValue == null ? 0 : (int)uiCaja.SelectedValue, ref usuario, ref esSupervisor, ref sesionId);

                if (error.Length > 0)
                {
                    MessageBox.Show(error, "ERROR LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    cat_configuracion configPV = oContext.cat_configuracion.FirstOrDefault();
                    PuntoVentaContext puntoVentaContext;



                    puntoVentaContext = new ConexionBD.Models.PuntoVentaContext();
                    puntoVentaContext.usuarioId = usuario.IdUsuario;
                    puntoVentaContext.usuario = usuario.NombreUsuario;
                    puntoVentaContext.sucursalId = sucursalId;
                    puntoVentaContext.cajaId = cajaId;
                    puntoVentaContext.empresaId = 1;
                    puntoVentaContext.esSupervisor = esSupervisor;
                    puntoVentaContext.giroPuntoVenta = configPV != null ? configPV.Giro : ConexionBD.Enumerados.systemGiro.ESTANDAR.ToString();
                    puntoVentaContext.solicitarComanda = configPV.SolicitarComanda ?? false;
                    puntoVentaContext.tieneRec = configPV.TieneRec ?? false;



                    /***Insertar Sesion***/
                    ObjectParameter pSesionId = new ObjectParameter("pSesionId", "");
                    pSesionId.Value = sesionId;

                    oContext.p_doc_sesiones_punto_venta_ins(pSesionId, usuario.IdUsuario, cajaId, null, null, false, null, false, null);

                    puntoVentaContext.sesionId = int.Parse(pSesionId.Value.ToString()); ;

                    int idUsuario = usuario.IdUsuario;
                    cat_usuarios entityUsu = oContext.cat_usuarios.Where(w => w.IdUsuario == idUsuario).FirstOrDefault();

                    cat_sucursales entitySuc = oContext.cat_sucursales.Where(w => w.Clave == sucursalId).FirstOrDefault();

                    if (puntoVentaContext.giroPuntoVenta.ToString() == ConexionBD.Enumerados.systemGiro.REST.ToString())
                    {
                        #region impresora Caja
                        cat_cajas_impresora entityCaja = oContext.cat_cajas_impresora
                       .Where(w => w.CajaId == cajaId).FirstOrDefault();

                        if (entityCaja != null)
                        {
                            puntoVentaContext.nombreImpresoraCaja = entityCaja.cat_impresoras.NombreRed;
                        }
                        else
                        {
                            puntoVentaContext.nombreImpresoraCaja = "";
                        }
                        #endregion

                        #region impresora Comanda
                        cat_impresoras_comandas entityComanda = oContext.cat_impresoras_comandas
                       .Where(w => w.cat_impresoras.SucursalId == sucursalId && w.cat_impresoras.Activa).FirstOrDefault();

                        if (entityComanda != null)
                        {
                            puntoVentaContext.nombreImpresoraComanda = entityComanda.cat_impresoras.NombreRed;
                        }
                        else
                        {
                            puntoVentaContext.nombreImpresoraComanda = "";
                        }
                        #endregion

                       
                    }

                    frmMenuRestTA oMenu = frmMenuRestTA.GetInstance();
                    oMenu.puntoVentaContext = new ConexionBD.Models.PuntoVentaContext();
                    oMenu.puntoVentaContext = puntoVentaContext;

                    oMenu.Text = "Sistema de Punto de Venta " + "[Usuario:" + entityUsu.NombreUsuario + "]" + "[Sucursal:" + entitySuc.NombreSucursal + "]";
                    oMenu.Show();
                    this.Hide();

                    return;
                    //if (puntoVentaContext.giroPuntoVenta.ToString() != Enumerados.systemGiro.REST.ToString())
                    //{
                    //    frmMenuRestTA oMenu = frmMenuRestTA.GetInstance();
                    //    oMenu.puntoVentaContext = new ConexionBD.Models.PuntoVentaContext();
                    //    oMenu.puntoVentaContext = puntoVentaContext;

                    //    oMenu.Text = "Sistema de Punto de Venta " + "[Usuario:" + entityUsu.NombreUsuario + "]" + "[Sucursal:" + entitySuc.NombreSucursal + "]";
                    //    oMenu.Show();
                    //    this.Hide();
                    //    return;
                    //}








                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message, "ERROR SESION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public void entrar()
        {

            try
            {

              
                cat_usuarios usuario = null;
                bool esSupervisor = false;


                if (uiSucursal.SelectedValue == null)
                {
                    MessageBox.Show("Es necesario ingresar la sucrusal", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (uiCaja.SelectedValue == null)
                {
                    MessageBox.Show("Es necesario ingresar la caja", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int sucursalId = (int)uiSucursal.SelectedValue;
                int cajaId = (int)uiCaja.SelectedValue;
                int sesionId = 0;

                string error = oLogin.validarLogin(uiUsuario.Text, uiPassword.Text, uiCaja.SelectedValue == null ? 0 : (int)uiCaja.SelectedValue, ref usuario, ref esSupervisor, ref sesionId);

                if (error.Length > 0)
                {
                    MessageBox.Show(error, "ERROR LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    
                    //RecortadoBusiness oRecortado = new RecortadoBusiness();
                    //oRecortado.Iniciar(usuario.IdUsuario);

                    cat_configuracion configPV = oContext.cat_configuracion.FirstOrDefault();
                    PuntoVentaContext puntoVentaContext;



                    puntoVentaContext = new ConexionBD.Models.PuntoVentaContext();
                    puntoVentaContext.usuarioId = usuario.IdUsuario;
                    puntoVentaContext.usuario = usuario.NombreUsuario;
                    puntoVentaContext.sucursalId = sucursalId;
                    puntoVentaContext.cajaId = cajaId;
                    puntoVentaContext.empresaId = 1;
                    puntoVentaContext.esSupervisor = esSupervisor;
                    puntoVentaContext.giroPuntoVenta = configPV != null ? configPV.Giro : ConexionBD.Enumerados.systemGiro.ESTANDAR.ToString();
                    puntoVentaContext.solicitarComanda = configPV.SolicitarComanda ?? false;
                    puntoVentaContext.tieneRec = configPV.TieneRec??false;

                    dia = TimeTools.FechaActual().dia;
                    mes = TimeTools.FechaActual().mes;
                    anio = TimeTools.FechaActual().anio;


                    if (oContext.doc_corte_caja
                        .Where(w=> w.cat_cajas.Sucursal == puntoVentaContext.sucursalId &&
                        w.FechaCorte.Day == dia &&
                        w.FechaCorte.Month == mes &&
                        w.FechaCorte.Year == anio &&
                        puntoVentaContext.esSupervisor
                        ).Count() > 0 

                       )
                    {
                        if(XtraMessageBox.Show("¿Deseas imprimir corte caja de supervisor?","Aviso",
                            MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            imprimirCorteGeneral(puntoVentaContext.sucursalId,puntoVentaContext.cajaId);
                            ERP.Common.Reports.ReportPrint.imprimirProductoSobrante(puntoVentaContext.sucursalId, DateTime.Now,
                                puntoVentaContext.usuarioId, puntoVentaContext.cajaId);
                        }
                    }
                   
                   

                    /***Insertar Sesion***/
                    ObjectParameter pSesionId = new ObjectParameter("pSesionId", "");
                    pSesionId.Value = sesionId;

                    oContext.p_doc_sesiones_punto_venta_ins(pSesionId, usuario.IdUsuario, cajaId, null, null, false, null, false, null);

                    puntoVentaContext.sesionId = int.Parse(pSesionId.Value.ToString()); ;

                    int idUsuario = usuario.IdUsuario;
                    cat_usuarios entityUsu = oContext.cat_usuarios.Where(w => w.IdUsuario == idUsuario).FirstOrDefault();

                    cat_sucursales entitySuc = oContext.cat_sucursales.Where(w => w.Clave == sucursalId).FirstOrDefault();
                    puntoVentaContext.nombreSucursal = entitySuc.NombreSucursal;
                   
                        #region impresora Caja
                        cat_cajas_impresora entityCaja = oContext.cat_cajas_impresora
                       .Where(w => w.CajaId == cajaId).FirstOrDefault();

                        if (entityCaja != null)
                        {
                            puntoVentaContext.nombreImpresoraCaja = entityCaja.cat_impresoras.NombreRed;
                        }
                        else
                        {
                            puntoVentaContext.nombreImpresoraCaja = "";
                        }
                        #endregion

                        #region impresora Comanda
                        cat_impresoras_comandas entityComanda = oContext.cat_impresoras_comandas
                       .Where(w => w.cat_impresoras.SucursalId == sucursalId && w.cat_impresoras.Activa).FirstOrDefault();

                        if (entityComanda != null)
                        {
                            puntoVentaContext.nombreImpresoraComanda = entityComanda.cat_impresoras.NombreRed;
                        }
                        else
                        {
                            puntoVentaContext.nombreImpresoraComanda = "";
                        }
                    #endregion

                    if(oContext.doc_declaracion_fondo_inicial

                    .Where(w=> w.SucursalId == puntoVentaContext.sucursalId && w.CorteCajaId == null).Count() > 0)
                    {
                        frmMenuRestTA oMenu = frmMenuRestTA.GetInstance();
                        oMenu.puntoVentaContext = new ConexionBD.Models.PuntoVentaContext();
                        oMenu.puntoVentaContext = puntoVentaContext;
                        oMenu.WindowState = FormWindowState.Maximized;
                        oMenu.StartPosition = FormStartPosition.CenterScreen;
                        oMenu.Text = "Sistema de Punto de Venta " + "[Usuario:" + entityUsu.NombreUsuario + "]" + "[Sucursal:" + entitySuc.NombreSucursal + "]";
                        oMenu.Show();
                        this.Hide();
                        return;

                    }
                    else
                    {
                        ERP.Common.PuntoVenta.frmDeclaracionFondo oFormDeclaracionInicial = new ERP.Common.PuntoVenta.frmDeclaracionFondo();
                        oFormDeclaracionInicial.puntoVentaContext = puntoVentaContext;
                        oFormDeclaracionInicial.tipo = "fondoInicial";
                        if (oFormDeclaracionInicial.ShowDialog() == DialogResult.OK)
                        {
                            frmMenuRestTA oMenu = frmMenuRestTA.GetInstance();
                            oMenu.puntoVentaContext = new ConexionBD.Models.PuntoVentaContext();
                            oMenu.puntoVentaContext = puntoVentaContext;
                            oMenu.WindowState = FormWindowState.Maximized;
                            oMenu.StartPosition = FormStartPosition.CenterScreen;
                            oMenu.Text = "Sistema de Punto de Venta " + "[Usuario:" + entityUsu.NombreUsuario + "]" + "[Sucursal:" + entitySuc.NombreSucursal + "]";
                            oMenu.Show();
                            this.Hide();
                            return;

                        }
                        else
                        {
                            ERP.Utils.MessageBoxUtil.ShowError(oFormDeclaracionInicial.error);
                        }
                    }

                    












                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message, "ERROR SESION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        


        private void imprimirCorteGeneral(int sucursalId,int cajaId)
        {
            try
            {
                oContext = new ERPProdEntities();
                ImpresorasBusiness oImpresora = new ImpresorasBusiness();
                cat_impresoras entityImpresora;
                entityImpresora = oImpresora.ObtenerCajaImpresora(cajaId);
                ERP.Reports.TacosAna.rptCorteCaja oReport = new ERP.Reports.TacosAna.rptCorteCaja();
                oReport.DataSource = oContext.p_rpt_corte_caja_general(sucursalId, TimeTools.ConvertToTimeZoneDefault()).ToList();
                oReport.CreateDocument();
                cat_configuracion conf = oContext.cat_configuracion.FirstOrDefault();
                if (conf.vistaPreviaImpresion == true)
                {
                    oReport.ShowPreview();
                }
                else
                {
                    oReport.Print(entityImpresora.NombreRed);
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

        private void abrirMenu()
        {
            try
            {

            }
            catch (Exception )
            {

               
            }
        }

        private void uiPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                entrar();
            }
        }

        private void uiUsuario_Validated(object sender, EventArgs e)
        {
            uiSucursal.Text = "";
            uiCaja.Text = "";
            uiSucursal.DataSource = oContext.p_sucursales_usuario_sel(uiUsuario.Text).ToList();
        }

        private void Login_Load(object sender, EventArgs e)
        {
        //    if (Licencia.ValidarLicencia())
        //    {
        //        oContext = new ERPProdEntities();

        //        oSistema = new Sistema();

        //        //Importar Información Master
        //        SincronizacionBusiness oSinc = new SincronizacionBusiness();
        //        oSinc.Importar();
        //    }
        //    else
        //    {
        //        Application.Exit();
        //    }

        }

        private void uiSucursal_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int sucursalId = (int)uiSucursal.SelectedValue;
                var usuario = oContext.cat_usuarios.Where(w => w.NombreUsuario == uiUsuario.Text)
                    .FirstOrDefault();

                uiCaja.Text = "";
                
                if (usuario != null)
                {
                    uiCaja.DataSource = oContext.cat_cajas
                   .Where(w => w.Sucursal == sucursalId &&
                   w.cat_usuarios.Where(s1 => s1.IdUsuario == usuario.IdUsuario).Count() > 0).ToList();
                }
               
               
            }
            catch (Exception ex)
            {

                ERP.Utils.MessageBoxUtil.ShowError(ex.Message);
            }
        }
    }
}
