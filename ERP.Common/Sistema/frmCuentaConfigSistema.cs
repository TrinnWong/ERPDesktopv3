using ConexionBD;
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

namespace ERP.Common.Sistema
{
    public partial class frmCuentaConfigSistema : FormBaseXtraForm
    {
        int err;
        ERP.Business.SisCuentaBusiness oSisCuenta;
        private static frmCuentaConfigSistema _instance;
        public static frmCuentaConfigSistema GetInstance()
        {
            if (_instance == null) _instance = new frmCuentaConfigSistema();
            else _instance.BringToFront();
            return _instance;
        }
        public frmCuentaConfigSistema()
        {
            InitializeComponent();
            oSisCuenta = new Business.SisCuentaBusiness();
            oContext = new ERPProdEntities();
        }

        private void frmCuentaConfigSistema_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            try
            {          
                if(uiEmail.Text.Trim() == "" || uiKey.Text.Trim() == "" || uiPassword.Text.Trim() == ""
                    || uiURL.Text.Trim()=="" || uiSucursal.Value <= 0)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("Toda la información es requerida");
                    return;
                }

                sis_cuenta cuenta = new sis_cuenta();
                cuenta.ClienteKey = uiKey.Text.Trim();
                cuenta.Email = uiEmail.Text.Trim();
                cuenta.Password = uiPassword.Text.Trim();
                cuenta.URLValidacion = uiURL.Text.Trim();
                cuenta.ClaveSucursal = Convert.ToInt32(uiSucursal.Value);
                oSisCuenta.GuardaArchivoConfiguracionCuenta(cuenta);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {

                ERP.Utils.MessageBoxUtil.ShowError(ex.Message);

                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        private void frmCuentaConfigSistema_Load(object sender, EventArgs e)
        {
            try
            {
                sis_cuenta cuenta = oSisCuenta.ObtieneArchivoConfiguracionCuenta();

                if (cuenta != null)
                {
                    uiKey.Text = cuenta.ClienteKey;
                    uiEmail.Text = cuenta.Email;
                    uiPassword.Text = cuenta.Password;
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
    }
}
