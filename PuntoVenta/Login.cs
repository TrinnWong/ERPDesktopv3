using ConexionBD;
using ConexionBD.Models;
using ERP.Business;
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

namespace PuntoVenta
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        /*
         * 0 Geral
         * 1 Tacoas Ana
         */
        private int tipoCliente = 1;
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
            EquipoComputoBusiness.RegistrarEquipo();
            oContext = new ERPProdEntities();
            oLogin = new ConexionBD.LoginCaja();
            uiCaja.DataSource = oContext.cat_cajas.ToList();
          
          
            
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
                        //if(tipoCliente == 1)
                        //{
                        //    frmMenuRestTA oMenu = frmMenuRestTA.GetInstance();
                        //    oMenu.puntoVentaContext = new ConexionBD.Models.PuntoVentaContext();
                        //    oMenu.puntoVentaContext = puntoVentaContext;

                        //    oMenu.Text = "Sistema de Punto de Venta " + "[Usuario:" + entityUsu.NombreUsuario + "]" + "[Sucursal:" + entitySuc.NombreSucursal + "]";
                        //    oMenu.Show();
                        //    this.Hide();
                        //}
                        
                            frmMenuRest oMenu = frmMenuRest.GetInstance();
                            oMenu.puntoVentaContext = new ConexionBD.Models.PuntoVentaContext();
                            oMenu.puntoVentaContext = puntoVentaContext;

                            oMenu.Text = "Sistema de Punto de Venta " + "[Usuario:" + entityUsu.NombreUsuario + "]" + "[Sucursal:" + entitySuc.NombreSucursal + "]";
                            oMenu.Show();
                            this.Hide();
                      
                       

                        return;
                    }


                    if (puntoVentaContext.giroPuntoVenta.ToString() != ConexionBD.Enumerados.systemGiro.REST.ToString())
                    {
                        frmMenu oMenu = frmMenu.GetInstance();
                        oMenu.puntoVentaContext = new ConexionBD.Models.PuntoVentaContext();
                        oMenu.puntoVentaContext = puntoVentaContext;

                        oMenu.Text = "Sistema de Punto de Venta " + "[Usuario:" + entityUsu.NombreUsuario + "]" + "[Sucursal:" + entitySuc.NombreSucursal + "]";
                        oMenu.Show();
                        this.Hide();
                        return;
                    }                
                  
                  

                 
                    
                    
                   

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message, "ERROR SESION", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            uiSucursal.DataSource = oContext.p_sucursales_usuario_sel(uiUsuario.Text).ToList();
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }
    }
}
