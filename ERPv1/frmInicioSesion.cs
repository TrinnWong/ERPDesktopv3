using ConexionBD;
using ConexionBD.Models;
using ERP.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ERPv1
{
    public partial class frmInicioSesion : Form
    {
        string usuario = "";
        int err = 0;
        ERPProdEntities oContext;
        ConexionBD.Sistema oSistema;
        Login oLogin;
        SisCuentaBusiness oSisCuenta;
        
        public frmInicioSesion()
        {
            InitializeComponent();
            oLogin = new Login();
            oContext = new ERPProdEntities();
            oSistema = new Sistema();
            oSisCuenta = new SisCuentaBusiness();
        }

        private void iniciarSesion()
        {
            try
            {
                string usuario = txtUsuario.Text.Trim();
                string contraseña = txtContraseña.Text.Trim();

                PuntoVentaContext oerpContext = new PuntoVentaContext();

                string error = oLogin.validar(usuario, contraseña, ref oerpContext);

                if (error.Length == 0)
                {
                    oerpContext.nombreSucursal = uiSucursal.Text;
                    oerpContext.sucursalId = int.Parse(uiSucursal.SelectedValue.ToString());
                    this.Hide();

                    //En caso de cerrar sesion o cambiar sucursal, se borran estos campos
                    txtContraseña.Text="";
                    uiSucursal.Text="";

                    frmMenu frmo = frmMenu.GetInstance();

                    if (!frmo.Visible)
                    {
                        frmo.puntoVentaContext = oerpContext;
                        frmo.Text = "SISTEMA ERP [" + oerpContext.nombreSucursal.Trim() + "][" + usuario.Trim() + "]";
                        frmo.Show();
                    }
                }
                else
                {
                    MessageBox.Show(error, "Error");
                }
            }
            catch (Exception ex)
            {
                ERP.Utils.MessageBoxUtil.ShowError("Información incorrecta, verificar el usuario y contraseña");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            iniciarSesion();
        }

        private void pbImgSalir1_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Close();
           // Application.Exit();
        }

        private void pbSalir2_Click(object sender, EventArgs e)
        {
            this.Close();
           // Application.Exit();
        }

        private void frmInicioSesion_Load(object sender, EventArgs e)
        {
            try
            {
                //if (Licencia.ValidarLicencia())
                //{
                //    oContext = new ERPProdEntities();
                //    oSistema = new Sistema();
                //}
                //else
                //{
                //    Application.Exit();
                //}

                string error = oSistema.actualizarVersion(false);
                this.lblVersion.Text = Sistema.ObtenVersion();
                if (error.Length > 0)
                {
                    MessageBox.Show("Ocurrió un error al actualizar la versión del sistema, por favor avise al administrador. Puede seguir utilizando la aplicación" + error
                        , "ERROR"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
                }
                //uiSucursal.DataSource = oContext.cat_sucursales.ToList();

            }
            catch (Exception ex)
            {
                ERP.Utils.MessageBoxUtil.ShowError("Ocurrió un error al inciar el sistema");
            }
        }

        private void txtContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                iniciarSesion();
            }
        }

        private void txtUsuario_Validated(object sender, EventArgs e)
        {
            try
            {
                usuario = txtUsuario.Text;

                cat_usuarios oUsuario = oContext.cat_usuarios.Where(w => w.NombreUsuario == usuario).FirstOrDefault();
                if (usuario == "admin")
                {
                    uiSucursal.DataSource = oContext.cat_sucursales.ToList();
                }
                else
                {
                    if (usuario != "admin")
                    {
                        if (oUsuario != null)
                        {
                            uiSucursal.DataSource = oContext.cat_sucursales
                                .Where(w=> w.cat_usuarios_sucursales
                                .Where(s1=> s1.UsuarioId == oUsuario.IdUsuario).Count() >0).ToList();
                        }
                        else
                        {
                            uiSucursal.DataSource = new List<cat_sucursales>();
                            uiSucursal.SelectedValue = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(1,
                                              "ERP",
                                              this.Name,
                                              ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }
    }
}

