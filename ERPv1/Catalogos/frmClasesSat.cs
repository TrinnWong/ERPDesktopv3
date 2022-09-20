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
using ConexionBD;

namespace ERPv1.Catalogos
{
    public partial class frmClasesSat : Form
    {
        Resultado resultado;
        ClasesSatInterface cI;

        public frmClasesSat()
        {
            InitializeComponent();
            cI = new ClasesSatInterface();
        }

        #region Métodos

        private void Buscar()
        {
            string busqueda = txtBuscar.Text.Trim();

            dgvClaseSat.DataSource = cI.ConsultarListado(busqueda);
            dgvClaseSat.Refresh();
        }

        private void LimpiarControles()
        {
            nClave.Enabled = true;
            nClave.Value = 0;
            txtNombreClases.Text = "";
            uiCodigoSAT.Text = "";
        }

        private Resultado ValidarAgregar(int clave, string nomClase, string codigoSAT)
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
            if (nomClase == "")
            {
                resultado.mensaje += "Capture el nombre de la Clase.";
                resultado.ok = false;
            }

            if (codigoSAT == "")
            {
                resultado.mensaje += "El código SAT es requerido.";
                resultado.ok = false;
            }
            return resultado;
        }

        private Resultado ValidarEditar(int clave, string nomClase,string codigoSAT)
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
            if (nomClase == "")
            {
                resultado.mensaje += "Capture el nombre del Clase.";
                resultado.ok = false;
            }

            if (codigoSAT == "")
            {
                resultado.mensaje += "El código SAT es requerido.";
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
            string nomClase = txtNombreClases.Text.Trim();
            bool estatus = chkEstatus.Checked ? true : false;
            int? empresa = null;
            int? sucursal = null;
            if (!ValidarAgregar(clave, nomClase,uiCodigoSAT.Text).ok)
            {
                MessageBox.Show(resultado.mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            resultado = cI.Agregar(clave, nomClase, estatus, empresa, sucursal,uiCodigoSAT.Text);
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
            string nomClase = txtNombreClases.Text.Trim();
            bool estatus = chkEstatus.Checked ? true : false;
            if (!ValidarEditar(clave, nomClase,uiCodigoSAT.Text).ok)
            {
                MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            resultado = cI.Actualizar(clave, nomClase, estatus,uiCodigoSAT.Text);
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
                txtNombreClases.Text = dt.Rows[0]["Descripcion"].ToString();
                uiCodigoSAT.Text = dt.Rows[0]["CodigoSAT"].ToString();
                this.chkEstatus.Checked = bool.Parse(dt.Rows[0]["Estatus"].ToString());
            }
            return dt == null ? 0 : (dt.Rows == null ? 0 : dt.Rows.Count);
        }

        #endregion
        
        #region Eventos
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Buscar();
            }
        }

        private void dgvClaseSat_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dgvClaseSat.Rows[rowIndex];
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

        private void frmClasesSat_Load(object sender, EventArgs e)
        {
            dgvClaseSat.DefaultCellStyle.ForeColor = Color.Black;
            Buscar();
        }

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
                    txtNombreClases.Focus();
                }
            }
        }

        private void txtNombreClases_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                chkEstatus.Focus();
            }

        }
        #endregion

    }
}
