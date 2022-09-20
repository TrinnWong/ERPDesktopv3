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

namespace ERPv1.RH
{
    public partial class frmFormaPagoNomina : Form
    {
        Resultado resultado;
        FormaPagoNominaInterface fpnI;

        public frmFormaPagoNomina()
        {
            InitializeComponent();
            fpnI = new FormaPagoNominaInterface();
        }

        #region Metodos

        private void Buscar()
        {
            string busqueda = txtBuscar.Text.Trim();

            dgvFormaPagoNomina.DataSource = fpnI.ConsultarListado(busqueda);
            dgvFormaPagoNomina.Refresh();
        }

        private void LimpiarControles()
        {
            nClave.Enabled = true;
            nClave.Value = 0;
            txtNomFormaPagoNomina.Text = "";
            nudHorasDia.Value = 0;
            nudNumDias.Value = 0;
            chkEstatus.Checked = true;
        }

        private Resultado ValidarAgregar(int clave, string nomFormaPagoNmina, int numDias, int horasDia)
        {
            resultado = new Resultado();
            if (clave <= 0)
            {
                resultado.mensaje += "La clave debe ser mayor a cero. \n";
                resultado.ok = false;
            }
            else
            {
                DataTable dt = fpnI.ConsultarRegistro(clave, false);
                if (clave > 0 && dt != null && dt.Rows.Count > 0)
                {
                    resultado.mensaje += "La clave " + clave + " ya existe. \n";
                    resultado.ok = false;
                }
            }
            if (nomFormaPagoNmina == "")
            {
                resultado.mensaje += "Capture la Forma de Pago de la Nómina. \n";
                resultado.ok = false;
            }
            if (numDias <= 0)
            {
                resultado.mensaje += "El numero de Días debe ser mayor a cero. \n";
                resultado.ok = false;
            }
            if (horasDia <= 0)
            {
                resultado.mensaje += "Las horas del Día debe ser mayor a cero. \n";
                resultado.ok = false;
            }


            return resultado;
        }

        private Resultado ValidarEditar(int clave, string nomFormaPagoNmina, int numDias, int horasDia)
        {
            resultado = new Resultado();
            DataTable dt = fpnI.ConsultarRegistro(clave, false);
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
            if (nomFormaPagoNmina == "")
            {
                resultado.mensaje += "Capture la Forma de Pago de la Nómina. \n";
                resultado.ok = false;
            }
            if (numDias <= 0)
            {
                resultado.mensaje += "El numero de Días debe ser mayor a cero. \n";
                resultado.ok = false;
            }
            if (horasDia <= 0)
            {
                resultado.mensaje += "Las horas del Día debe ser mayor a cero. \n";
                resultado.ok = false;
            }
            return resultado;
        }

        private Resultado ValidarEliminar(int clave)
        {
            resultado = new Resultado();
            DataTable dt = fpnI.ConsultarRegistro(clave, false);
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
            string nomFormaPagoNmina = txtNomFormaPagoNomina.Text.Trim();
            int numDias = (int)nudNumDias.Value;
            int horasDia = (int)nudHorasDia.Value;
            bool estatus = chkEstatus.Checked ? true : false;
            int? empresa = null;
            int? sucursal = null;
            if (!ValidarAgregar(clave, nomFormaPagoNmina, numDias, horasDia).ok)
            {
                MessageBox.Show(resultado.mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            resultado = fpnI.Agregar(clave, nomFormaPagoNmina, numDias, horasDia, estatus, empresa, sucursal);
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
            string nomFormaPagoNmina = txtNomFormaPagoNomina.Text.Trim();
            int numDias = (int)this.nudNumDias.Value;
            int horasDia = (int)this.nudHorasDia.Value;
            bool estatus = chkEstatus.Checked ? true : false;
            if (!ValidarEditar(clave, nomFormaPagoNmina, numDias, horasDia).ok)
            {
                MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            resultado = fpnI.Actualizar(clave, nomFormaPagoNmina, numDias, horasDia, estatus);
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
                resultado = fpnI.Eliminar(clave);
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
            DataTable dt = fpnI.ConsultarRegistro(clave, false);
            if (dt.Rows != null && dt.Rows.Count > 0)
            {
                nClave.Enabled = false;
                nClave.Value = clave;
                txtNomFormaPagoNomina.Text = dt.Rows[0]["Descripcion"].ToString(); ;
                chkEstatus.Checked = int.Parse(dt.Rows[0]["Estatus"].ToString()) == 1 ? true :false;
                nudNumDias.Value = int.Parse(dt.Rows[0]["NumDias"].ToString());
                nudHorasDia.Value = int.Parse(dt.Rows[0]["HrasDia"].ToString());
            }
            return dt == null ? 0 : (dt.Rows == null ? 0 : dt.Rows.Count);
        }

        #endregion

        #region Eventos

        private void frmFormaPagoNomina_Load(object sender, EventArgs e)
        {
            dgvFormaPagoNomina.DefaultCellStyle.ForeColor = Color.Black;
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
                    txtNomFormaPagoNomina.Focus();
                }
            }
        }

        private void txtNomFormaPagoNomina_KeyPress(object sender, KeyPressEventArgs e)
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
                nudNumDias.Focus();
            }
        }

        private void nudNumDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                nudHorasDia.Focus();
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

        private void dgvFormaPagoNomina_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        #endregion

        private void dgvFormaPagoNomina_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dgvFormaPagoNomina.Rows[rowIndex];
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
                catch (Exception ex) { }
            }
        }
    }
}
