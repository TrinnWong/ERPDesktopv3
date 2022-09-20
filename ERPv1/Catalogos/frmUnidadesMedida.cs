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
using ConexionBD.Utilerias;
using System.Data;
using ConexionBD;

namespace ERPv1.Catalogos
{
    public partial class frmUnidadesMedida : Form
    {
        Resultado resultado;
        UnidadesMedidaInterface aI;
        ERPProdEntities oContext;
        public frmUnidadesMedida()
        {
            InitializeComponent();
            aI = new UnidadesMedidaInterface();
            oContext = new ERPProdEntities();
            uiCodigoSAT.DataSource = oContext.cat_unidades_medida_SAT.ToList();
            uiCodigoSAT.SelectedValue = 0;

            
        }

        #region Métodos

        private void Buscar()
        {
            string busqueda = txtBuscar.Text.Trim();
            dgvUnidadesMedida.DataSource = aI.ConsultarListado(busqueda);
            dgvUnidadesMedida.Refresh();
        }

        private void LimpiarControles()
        {
            nClave.Enabled = true;
            nClave.Value = 0;
            txtNomUnidadMedida.Text = "";
            txtNomCorto.Text = "";
            nudDecimales.Value = 0;
            chkEstatus.Checked = true;
            uiCodigoSAT.SelectedValue = 0;
        }

        private Resultado ValidarAgregar(int clave, string nommoneda, string nomCorto, int  decimales,int idUnidadMedidaSAT)
        {
            resultado = new Resultado();
            if (clave <= 0)
            {
                resultado.mensaje += "La clave debe ser mayor a cero. \n";
                resultado.ok = false;
            }
            else
            {
                DataTable dt = aI.ConsultarRegistro(clave, false);
                if (clave > 0 && dt != null && dt.Rows.Count > 0)
                {
                    resultado.mensaje += "La clave " + clave + " ya existe. \n";
                    resultado.ok = false;
                }
            }
            if (nommoneda == "")
            {
                resultado.mensaje += "Capture el nombre de la Moneda.";
                resultado.ok = false;
            }
            if (nomCorto == "")
            {
                resultado.mensaje += "Capture el Nombre Corto.";
                resultado.ok = false;
            }
            if (decimales < 0)
            {
                resultado.mensaje += "Capture  el número de los Decimales.";
                resultado.ok = false;
            }
            if (idUnidadMedidaSAT <= 0)
            {
                resultado.mensaje += "El código SAT es requerido.";
                resultado.ok = false;
            }
            return resultado;
        }

        private Resultado ValidarEditar(int clave, string nommoneda, string nomCorto, int decimales, int idCodigoSAT)
        {
            resultado = new Resultado();
            DataTable dt = aI.ConsultarRegistro(clave, false);
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
            if (nommoneda == "")
            {
                resultado.mensaje += "Capture el nombre de la Moneda.";
                resultado.ok = false;
            }
            if (nomCorto == "")
            {
                resultado.mensaje += "Capture el Nombre Corto.";
                resultado.ok = false;
            }
            if (decimales < 0)
            {
                resultado.mensaje += "Capture el número de los Decimales.";
                resultado.ok = false;
            }
            if (idCodigoSAT <= 0)
            {
                resultado.mensaje += "El código SAT es requerido.";
                resultado.ok = false;
            }
            return resultado;
        }

        private Resultado ValidarEliminar(int clave)
        {
            resultado = new Resultado();
            DataTable dt = aI.ConsultarRegistro(clave, false);
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
            string nomMoneda = txtNomUnidadMedida.Text.Trim();
            string nomCorto = txtNomCorto.Text.Trim();
            int decimales = (int)nudDecimales.Value;
            bool estatus = chkEstatus.Checked ? true : false;
            int? empresa = null;
            int? sucursal = null;
            int idUnidadMedidaSAT = (int?)uiCodigoSAT.SelectedValue ?? 0;
            if (!ValidarAgregar(clave, nomMoneda, nomCorto, decimales, idUnidadMedidaSAT).ok)
            {
                MessageBox.Show(resultado.mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            resultado = aI.Agregar(clave, nomMoneda, nomCorto, decimales, estatus, empresa, sucursal,idUnidadMedidaSAT);
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
            string nomMoneda = txtNomUnidadMedida.Text.Trim();
            string nomCorto = txtNomCorto.Text.Trim();
            int decimales = (int)nudDecimales.Value;
            bool estatus = chkEstatus.Checked ? true : false;
            int idCodigoSAT = uiCodigoSAT.SelectedValue == null ? 0 : (int)uiCodigoSAT.SelectedValue;
                        
            if (!ValidarEditar(clave, nomMoneda, nomCorto, decimales,idCodigoSAT).ok)
            {
                MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            resultado = aI.Actualizar(clave, nomMoneda, nomCorto, decimales, estatus,idCodigoSAT);
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
                resultado = aI.Eliminar(clave);
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
            DataTable dt = aI.ConsultarRegistro(clave, false);
            if (dt.Rows != null && dt.Rows.Count > 0)
            {
                nClave.Enabled = false;
                nClave.Value = clave;
                txtNomUnidadMedida.Text = dt.Rows[0]["Nombre Unidad Medida"].ToString();
                txtNomCorto.Text = dt.Rows[0]["Nombre Corto"].ToString();
                nudDecimales.Value = int.Parse(dt.Rows[0]["Decimales"].ToString());
                chkEstatus.Checked = bool.Parse(dt.Rows[0]["Estatus"].ToString());
                uiCodigoSAT.SelectedValue = int.Parse(dt.Rows[0]["IdCodigoSAT"].ToString());
            }
            return dt == null ? 0 : (dt.Rows == null ? 0 : dt.Rows.Count);
        }
        #endregion

        #region Eventos

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
                    txtNomUnidadMedida.Focus();
                }
            }
        }

        private void txtNomUnidadMedida_KeyPress(object sender, KeyPressEventArgs e)
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
                txtNomCorto.Focus();
            }
        }

        private void txtNomCorto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                nudDecimales.Focus();
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

        private void dgvUnidadesMedida_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dgvUnidadesMedida.Rows[rowIndex];
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

        private void frmUnidadesMedida_Load(object sender, EventArgs e)
        {
            dgvUnidadesMedida.DefaultCellStyle.ForeColor = Color.Black;
            Buscar();
        }

        #endregion
    }
}
