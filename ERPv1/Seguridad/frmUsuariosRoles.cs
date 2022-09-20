using ConexionBD;
using ConexionBD.Models;
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

namespace ERPv1.Seguridad
{
    public partial class frmUsuariosRoles : FormBaseXtraForm
    {
        ERPProdEntities oContext;
        ERP.Business.SeguridadBusiness oSeguridad;
        private static frmUsuariosRoles _instance;
        public PuntoVentaContext puntoVentaContext;
        public static frmUsuariosRoles GetInstance()
        {
            if (_instance == null) _instance = new frmUsuariosRoles();
            else _instance.BringToFront();
            return _instance;
        }

        public frmUsuariosRoles()
        {
            InitializeComponent();
        }

        private void frmUsuariosRoles_Load(object sender, EventArgs e)
        {
            ValidarAcceso(frmMenu.GetInstance().puntoVentaContext.usuarioId, frmMenu.GetInstance().puntoVentaContext.sucursalId,
                "frmUsuariosRoles");
            oContext = new ERPProdEntities();
            oSeguridad = new ERP.Business.SeguridadBusiness();
            llenarLkpUsuarios();
            llenarLkpRoles();
            llenarLkpSucursales();
            llenarRepLkpRoles();
            llenarRepLkpSucursales();
        }

        #region funcionalidad
        public void llenarLkpUsuarios()
        {
            try
            {
                uiUsuarios.Properties.DataSource = oContext.cat_usuarios
                    .Where(w => w.Activo == true).ToList();
            }
            catch (Exception ex)
            {

                
            }
        }
        public void llenarLkpRoles()
        {
            try
            {
                uiRoles.Properties.DataSource = oContext.sis_roles.ToList();
            }
            catch (Exception ex)
            {

                
            }
        }

        public void llenarRepLkpRoles()
        {
            try
            {
                repLkpRoles.DataSource = oContext.sis_roles.ToList();
            }
            catch (Exception ex)
            {


            }
        }

        public void llenarLkpSucursales()
        {
            try
            {
                uiSucursales.Properties.DataSource = oContext.cat_sucursales.ToList();
            }
            catch (Exception)
            {
                
            }
        }

        public void llenarRepLkpSucursales()
        {
            try
            {
                repLkSucursal.DataSource = oContext.cat_sucursales.ToList();
            }
            catch (Exception)
            {

            }
        }

        public void llenarGridRoles()
        {
            try
            {
                int usuarioId = 0;

                int.TryParse(uiUsuarios.EditValue.ToString(), out usuarioId);
                List<sis_usuarios_roles> lst= oContext.sis_usuarios_roles
                    .Where(w => w.UsuarioId == usuarioId).ToList();

                uiGridRoles.DataSource = new BindingList<sis_usuarios_roles>(lst);
            }
            catch (Exception ex)
            {
                
            }
        }

        public void llenarGridSucursales()
        {
            try
            {
                int usuarioId = 0;

                int.TryParse(uiUsuarios.EditValue.ToString(), out usuarioId);

                uiGridSucursal.DataSource = oContext.cat_usuarios_sucursales
                    .Where(w => w.UsuarioId == usuarioId).ToList();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region eventos de controles
        private void uiRoles_EditValueChanged(object sender, EventArgs e)
        {
            llenarGridRoles();
            llenarGridSucursales();
        }

        private void frmUsuariosRoles_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiAgregarRol_Click(object sender, EventArgs e)
        {
            int usuarioId = 0;
            short rolId = 0;

            int.TryParse(uiUsuarios.EditValue.ToString(), out usuarioId);
            short.TryParse(uiRoles.EditValue.ToString(), out rolId);

            sis_usuarios_roles entity = new sis_usuarios_roles();

            entity.RolId = rolId;
            entity.UsuarioId = usuarioId;

            oSeguridad.InsertarUsuarioRol(entity, puntoVentaContext);

            llenarGridRoles();
        }

        private void uiAgregarSucursal_Click(object sender, EventArgs e)
        {
            int usuarioId = 0;
            int sucursalId = 0;

            int.TryParse(uiUsuarios.EditValue == null ? "0" : uiUsuarios.EditValue.ToString(), out usuarioId);
            int.TryParse(uiSucursales.EditValue == null ? "0" : uiSucursales.EditValue.ToString(), out sucursalId);

            cat_usuarios_sucursales entity = new cat_usuarios_sucursales();

            entity.SucursalId = sucursalId;
            entity.UsuarioId = usuarioId;

            oSeguridad.InsertarUsuarioSucursal(entity, puntoVentaContext);

            llenarGridSucursales();
        }

        #endregion

        private void repBtnDelRol_Click(object sender, EventArgs e)
        {
            int usuarioId = 0;
            short rolId = 0;

            int.TryParse(uiUsuarios.EditValue == null ? "0" : uiUsuarios.EditValue.ToString(), out usuarioId);
            short.TryParse(uiRoles.EditValue == null ? "0":uiRoles.EditValue.ToString(), out rolId);

            sis_usuarios_roles entity = new sis_usuarios_roles();

            entity.RolId = rolId;
            entity.UsuarioId = usuarioId;

            oSeguridad.EliminarUsuarioRol(entity, puntoVentaContext);

            llenarGridRoles();
        }

        private void repBtnDelSuc_Click(object sender, EventArgs e)
        {
            int usuarioId = 0;
            int sucursalId = 0;

            int.TryParse(uiUsuarios.EditValue.ToString(), out usuarioId);
            int.TryParse(uiRoles.EditValue.ToString(), out sucursalId);

            cat_usuarios_sucursales entity = new cat_usuarios_sucursales();

            entity.SucursalId = sucursalId;
            entity.UsuarioId = usuarioId;

            oSeguridad.EliminarUsuarioSucursal(entity, puntoVentaContext);

            llenarGridSucursales();
        }

        private void uiSucursales_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void uiUsuarios_EditValueChanged(object sender, EventArgs e)
        {
            llenarGridRoles();
            llenarGridSucursales();
        }
    }
}
