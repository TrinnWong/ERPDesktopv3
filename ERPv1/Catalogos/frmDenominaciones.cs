using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConexionBD;
using ConexionBD.Utilerias;

namespace ERPv1.Catalogos
{
    public partial class frmDenominaciones : Form
    {
        Resultado resultado;
        DenominacionesInterface dI;

        public frmDenominaciones()
        {
            InitializeComponent();
            dI = new DenominacionesInterface();
        }

        #region Métodos

        private void Buscar()
        {
            string busqueda = txtBuscar.Text.Trim();

            dgvDenominacion.DataSource = dI.ConsultarListado(busqueda);
            dgvDenominacion.Refresh();
        }

        private void LimpiarControles()
        {
            nClave.Enabled = true;
            nClave.Value = 0;
            txtDenominacion.Text = "";
            nudValor.Value = 0;
            nudOrden.Value = 0;
            chkEstatus.Checked = true;
        }

        private Resultado ValidarAgregar(int clave, string denominacion, decimal valor, int orden)
        {
            resultado = new Resultado();
            if (clave <= 0)
            {
                resultado.mensaje += "La clave debe ser mayor a cero. \n";
                resultado.ok = false;
            }
            else
            {
                DataTable dt = dI.ConsultarRegistro(clave, false);
                if (clave > 0 && dt != null && dt.Rows.Count > 0)
                {
                    resultado.mensaje += "La clave " + clave + " ya existe. \n";
                    resultado.ok = false;
                }
            }
            if (denominacion == "")
            {
                resultado.mensaje += "Capture el nombre de la Denominación.";
                resultado.ok = false;
            }
            if (valor <= 0)
            {
                resultado.mensaje += "El Valor debe ser mayor a cero.";
                resultado.ok = false;
            }
            if (orden <= 0)
            {
                resultado.mensaje += "El Orden debe ser mayor a cero.";
                resultado.ok = false;
            }
            return resultado;
        }

        private Resultado ValidarEditar(int clave, string denominacion, decimal valor, int orden)
        {
            resultado = new Resultado();
            DataTable dt = dI.ConsultarRegistro(clave, false);
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
            if (denominacion == "")
            {
                resultado.mensaje += "Capture el nombre de la Denominación.";
                resultado.ok = false;
            }
            if (valor <= 0)
            {
                resultado.mensaje += "El Valor debe ser mayor a cero.";
                resultado.ok = false;
            }
            if (orden <= 0)
            {
                resultado.mensaje += "El Orden debe ser mayor a cero.";
                resultado.ok = false;
            }
            return resultado;
        }

        private Resultado ValidarEliminar(int clave)
        {
            resultado = new Resultado();
            DataTable dt = dI.ConsultarRegistro(clave, false);
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
            string denominacion = txtDenominacion.Text.Trim();
            decimal valor = nudValor.Value;
            int orden = (int)nudOrden.Value;
            bool estatus = chkEstatus.Checked ? true : false;
            int? empresa = null;
            int? sucursal = null;
            if (!ValidarAgregar(clave, denominacion, valor, orden).ok)
            {
                MessageBox.Show(resultado.mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            resultado = dI.Agregar(clave, denominacion, valor, orden, estatus, empresa, sucursal);
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
            string denominacion = txtDenominacion.Text.Trim();
            decimal valor = nudValor.Value;
            int orden = (int)nudOrden.Value;
            bool estatus = chkEstatus.Checked ? true : false;
            if (!ValidarEditar(clave, denominacion, valor, orden).ok)
            {
                MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            resultado = dI.Actualizar(clave, denominacion, valor, orden, estatus);
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
                resultado = dI.Eliminar(clave);
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
            DataTable dt = dI.ConsultarRegistro(clave, false);
            if (dt.Rows != null && dt.Rows.Count > 0)
            {
                nClave.Enabled = false;
                nClave.Value = clave;
                txtDenominacion.Text = dt.Rows[0]["Descripcion"].ToString();
                nudValor.Value = decimal.Parse(dt.Rows[0]["Valor"].ToString());
                nudOrden.Value = int.Parse(dt.Rows[0]["Orden"].ToString());
                chkEstatus.Checked = bool.Parse(dt.Rows[0]["Estatus"].ToString());
            }
            return dt == null ? 0 : (dt.Rows == null ? 0 : dt.Rows.Count);
        }
        #endregion

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
                    txtDenominacion.Focus();
                }
            }
        }

        private void txtDenominacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                nudValor.Focus();
            }
        }

        private void nudValor_KeyPress(object sender, KeyPressEventArgs e)
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
                nudOrden.Focus();
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
                Buscar();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvDenominacion_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dgvDenominacion.Rows[rowIndex];
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

        private void frmDenominaciones_Load(object sender, EventArgs e)
        {            
            dgvDenominacion.DefaultCellStyle.ForeColor = Color.Black;
            Buscar();
        }
    }
}
