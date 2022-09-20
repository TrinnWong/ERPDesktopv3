using ConexionBD;
using ConexionBD.Models;
using ConexionBD.Utilerias;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPv1.Catalogos
{
    public partial class frmCajas : Form
    {
        public PuntoVentaContext puntoVentaContext;
        Resultado resultado;
        CajasInterface cI;
        ERPProdEntities oContext;

        public frmCajas()
        {
            InitializeComponent();
            cI = new CajasInterface();
            oContext = new ERPProdEntities();
        }

        #region Métodos

        private void Buscar()
        {
            string busqueda = txtBuscar.Text.Trim();

            dgvCaja.DataSource = cI.ConsultarListado(busqueda);
            dgvCaja.Refresh();
        }

        private void LimpiarControles()
        {
            nClave.Enabled = true;
            nClave.Value = 0;
            txtNombreCaja.Text = "";
            txtUbicación.Text = "";
            chkEstatus.Checked = true;
            uiTipoCaja.EditValue = null;
            uiSucursal.EditValue = null;
        }

        private Resultado ValidarAgregar(int clave, string nomCaja)
        {
            resultado = new Resultado();
            if (clave <= 0)
            {
                resultado.mensaje += "La clave debe ser mayor a cero. \n";
                resultado.ok = false;
            }
            else
            {
                DataTable dt = cI.ConsultarRegistro(clave, false);
                if (clave > 0 && dt != null && dt.Rows.Count > 0)
                {
                    resultado.mensaje += "La clave " + clave + " ya existe. \n";
                    resultado.ok = false;
                }
            }
            if (nomCaja == "")
            {
                resultado.mensaje += "Capture el nombre de la Caja.";
                resultado.ok = false;
            }
            return resultado;
        }

        private Resultado ValidarEditar(int clave, string nomCaja)
        {
            resultado = new Resultado();
            DataTable dt = cI.ConsultarRegistro(clave, false);
            if (clave <= 0)
            {
                resultado.mensaje += "La clave debe ser mayor a cero. \n";
                resultado.ok = false;
            }
            if (clave > 0 && (dt == null || dt.Rows.Count <= 0))
            {
                resultado.mensaje += "La clave " + clave + " no existe. \n";
                resultado.ok = false;
            }
            if (nomCaja == "")
            {
                resultado.mensaje += "Capture el nombre de la Caja.";
                resultado.ok = false;
            }
            return resultado;
        }

        private Resultado ValidarEliminar(int clave)
        {
            resultado = new Resultado();
            DataTable dt = cI.ConsultarRegistro(clave, false);
            if (clave <= 0)
            {
                resultado.mensaje += "La clave debe ser mayor a cero. \n";
                resultado.ok = false;
            }
            if (clave > 0 && (dt == null || dt.Rows.Count <= 0))
            {
                resultado.mensaje += "La clave " + clave + " no existe. \n";
                resultado.ok = false;
            }
            return resultado;
        }

        private void Insertar()
        {
            resultado = new Resultado();
            int clave = (int)nClave.Value;
            string nomCaja = txtNombreCaja.Text.Trim();
            string nomUbiacion = txtUbicación.Text.Trim();
            bool estatus = chkEstatus.Checked ? true : false;
            int? empresa = puntoVentaContext.empresaId;
            int? sucursal = uiSucursal.EditValue == null ? null : (int?)Convert.ToInt32(uiSucursal.EditValue.ToString());
            if (!ValidarAgregar(clave, nomCaja).ok)
            {
                MessageBox.Show(resultado.mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            resultado = cI.Agregar(clave, nomCaja, nomUbiacion, estatus, empresa, sucursal,
                Convert.ToInt32(uiTipoCaja.EditValue == null ? "0" : uiTipoCaja.EditValue));
            MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (resultado.ok)
            {
                LimpiarControles();
                Buscar();
            }
        }

        private void Editar()
        {
            resultado = new Resultado();
            int clave = (int)nClave.Value;
            string nomCaja = txtNombreCaja.Text.Trim();
            string nomUbiacion = txtUbicación.Text.Trim();
            bool estatus = chkEstatus.Checked ? true : false;
            int? empresa = puntoVentaContext.empresaId;
            int? sucursal = uiSucursal.EditValue == null ? null : (int?)Convert.ToInt32(uiSucursal.EditValue.ToString()); ;
            if (!ValidarEditar(clave, nomCaja).ok)
            {
                MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            resultado = cI.Actualizar(clave, nomCaja, nomUbiacion, estatus, empresa, sucursal,
                Convert.ToInt32(uiTipoCaja.EditValue == null ? "0" : uiTipoCaja.EditValue));
            MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (resultado.ok)
            {
                LimpiarControles();
                Buscar();
            }
        }

        private void Eliminar()
        {
            int clave = (int)nClave.Value;
            if (!ValidarEliminar(clave).ok)
            { 
                MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var opcion = MessageBox.Show("¿Seguro que desea eliminar el registro " + clave + "?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (opcion == DialogResult.OK)
            {
                resultado = new Resultado();
                resultado = cI.Eliminar(clave);
                MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (resultado.ok)
                {
                    LimpiarControles();
                    Buscar();
                }
            }
        }

        private int BuscarRegistro(int clave)
        {
            DataTable dt = cI.ConsultarRegistro(clave, false);
            if (dt.Rows != null && dt.Rows.Count > 0)
            {
                nClave.Enabled = false;
                nClave.Value = clave;
                txtNombreCaja.Text = dt.Rows[0]["Caja"].ToString();
                txtUbicación.Text = dt.Rows[0]["Ubicación"].ToString();
                chkEstatus.Checked = bool.Parse(dt.Rows[0]["Estatus"].ToString()); ;
                uiTipoCaja.EditValue = dt.Rows[0]["TipoCajaId"] == DBNull.Value ? null : dt.Rows[0]["TipoCajaId"];

                uiSucursal.EditValue = dt.Rows[0]["Sucursal"] == DBNull.Value ? null : dt.Rows[0]["Sucursal"];
            }
            return dt == null ? 0 : (dt.Rows == null ? 0 : dt.Rows.Count);
        }

        private void LoadSucursales()
        {
            try
            {
                uiSucursal.Properties.DataSource = oContext
                    .cat_sucursales.Where(w=> w.Estatus == true).ToList();
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

        private void LoadTipos()
        {
            try
            {
                uiTipoCaja.Properties.DataSource = oContext
                    .cat_tipos_cajas.ToList();
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
        #endregion

        #region

        private void nClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                int clave = 0;
                try
                {
                    clave = (int)nClave.Value;
                }
                catch { }

                int numero = BuscarRegistro(clave);
                if (numero == 0)
                {
                    txtNombreCaja.Focus();
                }
            }
        }

        private void txtNombreCaja_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                chkEstatus.Focus();
            }
        }

        private void chkEstatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtUbicación.Focus();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            
            Insertar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtUbicación.Focus();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvCaja_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dgvCaja.Rows[rowIndex];
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
                catch { }
            }
        }

        private void frmCajas_Load(object sender, EventArgs e)
        {
            dgvCaja.DefaultCellStyle.ForeColor = Color.Black;
            LoadTipos();
            LoadSucursales();
            Buscar();
        }

        #endregion
    }
}
