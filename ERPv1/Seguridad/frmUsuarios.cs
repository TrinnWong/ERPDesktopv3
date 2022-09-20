using ConexionBD;
using DevExpress.XtraEditors;
using ERP.Common.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPv1.Seguridad
{
    public partial class frmUsuarios : FormBaseWinForm
    {
        //ERPProdEntities oContext;
        ConexionBD.Usuarios oData;

        private static frmUsuarios _instance;
        public static frmUsuarios GetInstance()
        {

            if (_instance == null) _instance = new frmUsuarios();
            else _instance.BringToFront();
            return _instance;
        }

        public frmUsuarios()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
            oData = new Usuarios();
        }
        private void frmUsuarios_Load(object sender, EventArgs e)
        {

            ValidarAcceso(frmMenu.GetInstance().puntoVentaContext.usuarioId,
                frmMenu.GetInstance().puntoVentaContext.sucursalId,
                "frmUsuarios");
            LlenarCombo();
            Buscar();

            Limpiar();
        }

        private void LlenarCombo()
        {
            uiEmpleado.DataSource = oContext.rh_empleados.ToList();
            uiEmpleado.SelectedValue = 0;

            uiSucursal.DataSource = oContext.cat_sucursales.ToList();
            uiSucursal.SelectedValue = 0;

            
        }

        private void guardarSucursal(int usuarioId)
        {
            try
            {
                
                oContext = new ERPProdEntities();
                //borrar todo
                List<cat_usuarios_sucursales> lstDelete = oContext.cat_usuarios_sucursales
                    .Where(w => w.UsuarioId == usuarioId).ToList();

                foreach (cat_usuarios_sucursales itemDelete in lstDelete)
                {
                    oContext.cat_usuarios_sucursales.Remove(itemDelete);
                    oContext.SaveChanges();
                }
               
                int sucursalId = uiSucursal.SelectedValue != null ? (int)uiSucursal.SelectedValue : 0;
                cat_usuarios_sucursales entity = new cat_usuarios_sucursales();
                entity.UsuarioId = usuarioId;
                entity.SucursalId = sucursalId;
                entity.CreadoEl = DateTime.Now;
                oContext.cat_usuarios_sucursales.Add(entity);
                oContext.SaveChanges();


            }
            catch (Exception ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenu.GetInstance().puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private bool validar()
        {
            try
            {
                int? cajaId = uiCaja.EditValue == null ? null : (int?)Convert.ToInt32(uiCaja.EditValue.ToString());
                int usuarioId = (int)this.uiUsuarioId.Value;

                if(oContext.cat_usuarios
                    .Where(w=> w.CajaDefaultId == cajaId && cajaId > 0 && w.IdUsuario !=  usuarioId && w.Activo == true)
                    .Count() > 0
                    )
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("La caja ya está asiganda a otro usuario pero es posible continuar");
                    
                }

                return true;

            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                                    "ERP",
                                                    this.Name,
                                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);

                return false;
            }

           
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                if (!validar())
                {
                    return ;
                }

                cat_usuarios entity = new cat_usuarios();

                entity.IdUsuario = oContext.cat_usuarios.Count() > 0 ? 
                                oContext.cat_usuarios.Max(m=> m.IdUsuario) + 1 : 1;
                entity.Activo = chkEstatus.Checked;
                entity.NombreUsuario = uiUsuario.Text;
                entity.Password = uiPassword.Text;
                entity.IdEmpleado = uiEmpleado.SelectedValue != null ? (int)uiEmpleado.SelectedValue : 0;
                entity.CreadoEl = DateTime.Now;
                entity.EsSupervisor = uiEsSupervisor.Checked;
                entity.PasswordSupervisor = uiPasswordSupervisor.Text;
                entity.IdSucursal = uiSucursal.SelectedValue != null ? (int?)uiSucursal.SelectedValue : 0;
                entity.EsSupervisorCajero = uiEsSupCajero.Checked;
                entity.PasswordSupervisorCajero = uiPassSupCajero.Text;
                entity.Email = uiEmail.Text;
                entity.CajaDefaultId = uiCaja.EditValue == null ? null : (int?)Convert.ToInt32(uiCaja.EditValue.ToString());
                error = oData.Insertar(entity);

                

                if (error.Length > 0)
                {
                    MessageBox.Show(error, "Error");
                }
                else
                {
                    guardarSucursal(entity.IdUsuario);
                    MessageBox.Show("El registro se agregó correctamente");
                    Buscar();
                    Limpiar();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void Buscar()
        {
            string busqueda = txtBuscar.Text.Trim();

            dgvGrid.DataSource = oData.oContext.cat_usuarios.Where(
                w => w.NombreUsuario.Contains(busqueda)
                ||
                w.rh_empleados.Nombre.Contains(busqueda)
                ||
                busqueda == ""
                ).Select(
                    s=> new {
                        Clave = s.IdUsuario,
                        Usuario = s.NombreUsuario,
                        EsSupervisor = s.EsSupervisor,
                        UsuarioActivo = s.Activo
                    }
                ).ToList();
            dgvGrid.Refresh();
        }

        private void Limpiar()
        {

            this.nClave.Value = 0;
            this.uiUsuario.Text = "";
            uiPassword.Text = "";
            //uiPassword2.Text = "";
            this.chkEstatus.Checked = true;
            this.uiEmpleado.SelectedValue = 0;
            uiEsSupervisor.Checked = false;
            uiPasswordSupervisor.Text = "";
            uiPuesto.Text = "";
            uiDepartamento.Text = "";
            uiNombre.Text = "";
            uiSucursal.SelectedValue = 0;
            uiFoto.Image = null;
            uiUsuarioId.Value = 0;
            uiEmail.Text = "";

            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            uiEsSupCajero.Checked = false;
            uiPassSupCajero.Text = "";
            

            uiPasswordSupervisor.Enabled = uiEsSupervisor.Checked;
            if (!uiEsSupervisor.Checked)
            {
                uiPasswordSupervisor.Text = "";
            }

            uiPassSupCajero.Enabled = uiEsSupCajero.Checked;
            if (!uiEsSupCajero.Checked)
            {
                uiPassSupCajero.Text = "";
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            {

                if (!validar())
                {
                    return;
                }
                cat_usuarios entity = new cat_usuarios();

                entity.IdUsuario = (int)this.uiUsuarioId.Value;
                entity.Activo = chkEstatus.Checked;
                entity.NombreUsuario = uiUsuario.Text;
                entity.Password = uiPassword.Text;
                entity.IdEmpleado = (int)uiEmpleado.SelectedValue;
                entity.EsSupervisor = uiEsSupervisor.Checked;
                entity.PasswordSupervisor = uiPasswordSupervisor.Text;
                entity.IdSucursal = uiSucursal.SelectedValue != null ? (int?)uiSucursal.SelectedValue : 0;
                entity.PasswordSupervisorCajero = uiPassSupCajero.Text;
                entity.EsSupervisorCajero = uiEsSupCajero.Checked;
                entity.Email = uiEmail.Text;
                entity.CajaDefaultId = uiCaja.EditValue == null ? null : (int?)Convert.ToInt32(uiCaja.EditValue.ToString());
                // error = oData.Insertar(entity);

                error = oData.Actualizar(entity);

                if (error.Length > 0)
                {
                    MessageBox.Show(error, "Error");
                }
                else
                {
                    guardarSucursal((int)this.uiUsuarioId.Value);
                    MessageBox.Show("Registro Actualizado");
                    Buscar();
                    Limpiar();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException.Message, "Error");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                    MessageBox.Show("¿Está seguro de eliminar el registro", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes
                    )
                {
                    oData.Eliminar((int)this.uiUsuarioId.Value);
                    Buscar();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("No es posible eliminar el registro, ya que existen movimientos registrados con este usuario", "Error");
            }
        }

        private void BuscarRegistro(int clave)
        {
            oContext = new ERPProdEntities();
            cat_usuarios entity = oData.oContext.cat_usuarios
                .Where(w => w.IdUsuario == clave).FirstOrDefault();

            this.nClave.Value = entity.IdUsuario;
            this.uiUsuario.Text = entity.NombreUsuario;
            uiPassword.Text = entity.Password;
           // uiPassword2.Text = entity.Password;
            uiEmpleado.SelectedValue = entity.IdEmpleado;
            this.chkEstatus.Checked = entity.Activo ?? false;

            uiNombre.Text = entity.rh_empleados!= null? entity.rh_empleados.Nombre : "";
            uiSucursal.SelectedValue = entity.IdSucursal ?? 0;
            uiPuesto.Text = entity.rh_empleados != null ? entity.rh_empleados.rh_puestos != null ? entity.rh_empleados.rh_puestos.Descripcion : "" : "";
            uiDepartamento.Text = entity.rh_empleados != null ? entity.rh_empleados.rh_departamentos!= null ? entity.rh_empleados.rh_departamentos.Descripcion : "" : "";
            uiEsSupervisor.Checked = entity.EsSupervisor ?? false;
            uiPasswordSupervisor.Text = entity.PasswordSupervisor;
            uiUsuarioId.Value = entity.IdUsuario;
            uiEsSupCajero.Checked = entity.EsSupervisorCajero ?? false;
            uiPassSupCajero.Text = entity.PasswordSupervisorCajero;
            btnAgregar.Enabled = false;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            nClave.Enabled = false;
            uiEmail.Text = entity.Email;
            uiCaja.EditValue = entity.CajaDefaultId;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dgvGrid.Rows[rowIndex];
                try
                {
                    if ((int)row.Cells[0].Value > 0)
                    {
                        int clave = (int)row.Cells[0].Value;
                        if (clave > 0)
                        {
                            BuscarRegistro(clave);
                        }
                    }
                }
                catch(Exception ex) {
                    int err = ERP.Business.SisBitacoraBusiness.Insert(1,
                                                    "ERP",
                                                    this.Name,
                                                    ex);
                    ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
                }
            }

            
        }

        private void uiEsSupervisor_VisibleChanged(object sender, EventArgs e)
        {
            
           
            
        }

        private void uiEsSupervisor_CheckedChanged(object sender, EventArgs e)
        {
            uiPasswordSupervisor.Enabled = uiEsSupervisor.Checked;
            if (!uiEsSupervisor.Checked)
            {
                uiPasswordSupervisor.Text = "";
            }
        }

        private void uiEmpleado_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (uiEmpleado.SelectedValue == null)
                    return;
                int clave = (int)uiEmpleado.SelectedValue;

                oContext = new ERPProdEntities();

                uiFoto.Image = null;

                rh_empleados entiti = oContext.rh_empleados.Where(w => w.NumEmpleado == clave).FirstOrDefault();

                if (entiti != null)
                {
                    uiNombre.Text = entiti.Nombre;
                    if (entiti.Foto != null)
                    {
                        using (var ms = new MemoryStream(entiti.Foto))
                        {
                            uiFoto.Image = Image.FromStream(ms);
                        }
                    }
                   
                    
                    uiDepartamento.Text = entiti.rh_departamentos != null ?  entiti.rh_departamentos.Descripcion:"";
                    uiPuesto.Text = entiti.rh_puestos != null ? entiti.rh_puestos.Descripcion : "";
                    nClave.Value = entiti.NumEmpleado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void uiEsSupCajero_CheckedChanged(object sender, EventArgs e)
        {
            uiPassSupCajero.Enabled = uiEsSupCajero.Checked;
            if (!uiEsSupCajero.Checked)
            {
                uiPassSupCajero.Text = "";
            }
        }

        private void uiSucursal_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int sucursalId = uiSucursal.SelectedValue != null ? (int)uiSucursal.SelectedValue : 0;

                uiCaja.Properties.DataSource = oContext.cat_cajas
                    .Where(w => w.Sucursal == sucursalId).ToList();
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenu.GetInstance().puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }
    }
}
