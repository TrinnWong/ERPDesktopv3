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
    public partial class frmMonedas : Form
    {
        Resultado resultado;
        MonedasInterface aI;
        ERPProdEntities oContext;

        public frmMonedas()
        {
            InitializeComponent();
            aI = new MonedasInterface();
            oContext = new ERPProdEntities();

            uiCodigoSAT.DataSource = oContext.cat_monedas_abreviaturas.ToList();
            uiCodigoSAT.SelectedValue = 0;
        }

        #region Métodos

        private void Buscar()
        {
            string busqueda = txtBuscar.Text.Trim();

            dgvMoneda.DataSource = aI.ConsultarListado(busqueda);
            dgvMoneda.Refresh();
        }

        private void LimpiarControles()
        {
            nClave.Enabled = true;
            nClave.Value = 0;
            txtNombreMoneda.Text = "";
            //txtAbreviacion.Text = "";
            uiCodigoSAT.SelectedValue = 0;
            nudTipoCambio.Value = 0;
            chkEstatus.Checked = true;
        }

        private Resultado ValidarAgregar(int clave, string nommoneda, string abreviatura, 
            decimal tipoCambio,int IdMonedaAbreviatura)
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
            //if (abreviatura == "")
            //{
            //    resultado.mensaje += "Capture la Abreviatura.";
            //    resultado.ok = false;
            //}
            if (tipoCambio <= 0)
            {
                resultado.mensaje += "Capture el Tipo de Cambio.";
                resultado.ok = false;
            }
            if (IdMonedaAbreviatura <= 0)
            {
                resultado.mensaje += "El código SAT es requerido";
                resultado.ok = false;
            }
            return resultado;
        }

        private Resultado ValidarEditar(int clave, string nommoneda, string abreviatura, decimal tipoCambio,int IdMonedaAbreviatura)
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
            //if (abreviatura == "")
            //{
            //    resultado.mensaje += "Capture la Abreviatura.";
            //    resultado.ok = false;
            //}
            if (tipoCambio <= 0)
            {
                resultado.mensaje += "Capture el Tipo de Cambio.";
                resultado.ok = false;
            }
            if (IdMonedaAbreviatura <= 0)
            {
                resultado.mensaje += "El código SAT es requerido";
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
            string nomMoneda = txtNombreMoneda.Text.Trim();
            string avreviación = "";
            decimal tipoCambio = nudTipoCambio.Value;
            bool estatus = chkEstatus.Checked ? true : false;
            int? empresa = null;
            int? sucursal = null;
            int? IdMonedaAbreviatura = (int?)uiCodigoSAT.SelectedValue;
            if (!ValidarAgregar(clave, nomMoneda, avreviación, tipoCambio,IdMonedaAbreviatura ?? 0).ok)
            {
                MessageBox.Show(resultado.mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            resultado = aI.Agregar(clave, nomMoneda, avreviación, tipoCambio, estatus, empresa, sucursal,IdMonedaAbreviatura);
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
            string nomMoneda = txtNombreMoneda.Text.Trim();
            string avreviatura = "";
            decimal tipoCambio = nudTipoCambio.Value;
            int? IdMonedaAbreviatura = (int?)uiCodigoSAT.SelectedValue;
            bool estatus = chkEstatus.Checked ? true : false;
            if (!ValidarEditar(clave, nomMoneda, avreviatura, tipoCambio, IdMonedaAbreviatura ?? 0).ok)
            {
                MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            resultado = aI.Actualizar(clave, nomMoneda, avreviatura, tipoCambio, estatus,IdMonedaAbreviatura??0);
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
                txtNombreMoneda.Text = dt.Rows[0]["Moneda"].ToString();
                //txtAbreviacion.Text = dt.Rows[0]["Abreviación"].ToString();
                nudTipoCambio.Value = decimal.Parse(dt.Rows[0]["TipoCambio"].ToString());
                chkEstatus.Checked = bool.Parse(dt.Rows[0]["Estatus"].ToString()); ;
                uiCodigoSAT.SelectedValue = int.Parse(dt.Rows[0]["IdMonedaAbreviatura"].ToString());
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
                    txtNombreMoneda.Focus();
                }
            }
        }

        private void txtNombreMoneda_KeyPress(object sender, KeyPressEventArgs e)
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
                //txtAbreviacion.Focus();
                uiCodigoSAT.Focus();
            }
        }

        private void txtAbreviacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                nudTipoCambio.Focus();
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
        
        private void frmMonedas_Load(object sender, EventArgs e)
        {
            dgvMoneda.DefaultCellStyle.ForeColor = Color.Black;
            Buscar();
        }
        
        private void dgvMoneda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dgvMoneda.Rows[rowIndex];
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

        #endregion
    }
}
