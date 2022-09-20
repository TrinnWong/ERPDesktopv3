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
using ConexionBD;
using System.IO;
using System.Drawing.Imaging;

namespace ERPv1.Catalogos
{
    public partial class frmEmpresas : Form
    {
        Resultado resultado;
        EmpresasInterface eI;

        public frmEmpresas()
        {
            InitializeComponent();
            eI = new EmpresasInterface();
        }

        #region Métodos

        private void Buscar()
        {
            string busqueda = txtBuscar.Text.Trim();

            dgvEmpresa.DataSource = eI.ConsultarListado(busqueda);
            dgvEmpresa.Refresh();
        }

        private void LimpiarControles()
        {
            nClave.Enabled = true;
            nClave.Value = 0;
            txtNombreComercial.Text = "";
            txtNombreEmpresa.Text = "";
            txtNombreComercial.Text = "";
            txtRFC.Text = "";
            chkEstatus.Checked = true;
            txtRegimenFiscal.Text = "";
            txtCorreoElectronico.Text = "";
            txtCalle.Text = "";
            txtColonia.Text = "";
            txtNumExt.Text = "";
            txtNumInt.Text = "";
            txtCPo.Text = "";
            txtCiudad.Text = "";
            txtEstado.Text = "";
            txtPais.Text = "";
            txtTelefono1.Text = "";
            txtTelefono2.Text = "";
            pbFoto.Enabled = false;
            pbFoto.Image = null;
        }

        private Resultado ValidarAgregar(int clave, string nomEmpresa)
        {
            resultado = new Resultado();
            if (clave <= 0)
            {
                resultado.mensaje += "La clave debe ser mayor a cero. \n";
                resultado.ok = false;
            }
            else
            {
                DataTable dt = eI.ConsultarRegistro(clave, false);
                if (clave > 0 && dt != null && dt.Rows.Count > 0)
                {
                    resultado.mensaje += "La clave " + clave + " ya existe. \n";
                    resultado.ok = false;
                }
            }
            if (nomEmpresa == "")
            {
                resultado.mensaje += "Capture el nombre de la Empresa.";
                resultado.ok = false;
            }
            return resultado;
        }

        private Resultado ValidarEditar(int clave, string nomEmpresa)
        {
            resultado = new Resultado();
            DataTable dt = eI.ConsultarRegistro(clave, false);
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
            if (nomEmpresa == "")
            {
                resultado.mensaje += "Capture el nombre de la Empresa.";
                resultado.ok = false;
            }
            return resultado;
        }

        private Resultado ValidarEliminar(int clave)
        {
            resultado = new Resultado();
            DataTable dt = eI.ConsultarRegistro(clave, false);
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
            string nomEmpresa = txtNombreEmpresa.Text.Trim();
            string nombreComercial = txtNombreComercial.Text.Trim();
            string nomComercial = txtNombreComercial.Text.Trim();
            string rfc = txtRFC.Text.Trim();
            bool estatus = chkEstatus.Checked;
            string regFiscal = txtRegimenFiscal.Text.Trim();
            string correoElectronico = txtCorreoElectronico.Text.Trim();
            string calle = txtCalle.Text.Trim();
            string colonia = txtColonia.Text.Trim();
            string numExt = txtNumExt.Text.Trim();
            string numint = txtNumInt.Text.Trim();
            string cp = txtCPo.Text.Trim();
            string cd = txtCiudad.Text.Trim();
            string estado = txtEstado.Text.Trim();
            string pais = txtPais.Text.Trim();
            string tel1 = txtTelefono1.Text.Trim();
            string tel2 = txtTelefono2.Text.Trim();
            
            if (!ValidarAgregar(clave, nomEmpresa).ok)
            {
                MessageBox.Show(resultado.mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            resultado = eI.Agregar(clave, nomEmpresa, nomComercial, regFiscal, rfc, calle, colonia, numExt, numint, cp, cd, estado, pais, tel1, tel2, correoElectronico, estatus);
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
            string nomEmpresa = txtNombreEmpresa.Text.Trim();
            string nombreComercial = txtNombreComercial.Text.Trim();
            string rfc = txtRFC.Text.Trim();
            bool estatus = chkEstatus.Checked;
            string regFiscal = txtRegimenFiscal.Text.Trim();
            string correoElectronico = txtCorreoElectronico.Text.Trim();
            string calle = txtCalle.Text.Trim();
            string colonia = txtColonia.Text.Trim();
            string numExt = txtNumExt.Text.Trim();
            string numint = txtNumInt.Text.Trim();
            string cp = txtCPo.Text.Trim();
            string cd = txtCiudad.Text.Trim();
            string estado = txtEstado.Text.Trim();
            string pais = txtPais.Text.Trim();
            string tel1 = txtTelefono1.Text.Trim();
            string tel2 = txtTelefono2.Text.Trim();
            
            if (!ValidarEditar(clave, nomEmpresa).ok)
            {
                MessageBox.Show(resultado.mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            resultado = eI.Actualizar(clave, nomEmpresa, nombreComercial, regFiscal, rfc, calle, colonia, numExt, numint, cp, cd, estado, pais, tel1, tel2, correoElectronico, estatus);

            ERPProdEntities oContext = new ERPProdEntities();
            cat_empresas entity = oContext.cat_empresas.Where(w => w.Clave == clave).FirstOrDefault();

            if (pbFoto.Image != null)
            {
                using (var ms = new MemoryStream())
                {
                    string fileFoto = AppDomain.CurrentDomain.BaseDirectory + "logo.jpg";

                    pbFoto.Image.Save(ms, pbFoto.Image.RawFormat);

                    Image logo = Image.FromStream(ms);

                    if (System.IO.File.Exists(fileFoto))
                    {
                        System.IO.File.Delete(fileFoto);
                        logo.Save(fileFoto, ImageFormat.Jpeg);

                    }
                    
                    entity.Logo = ms.ToArray();
                }
            }
            else {
                entity.Logo = null;
            }
            

            oContext.SaveChanges();



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
                resultado = eI.Eliminar(clave);
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
            DataTable dt = eI.ConsultarRegistro(clave, false);
            if (dt.Rows != null && dt.Rows.Count > 0)
            {
                nClave.Enabled = false;
                nClave.Value = clave;
                txtNombreEmpresa.Text = dt.Rows[0]["Nombre"].ToString();
                txtNombreComercial.Text = dt.Rows[0]["NombreComercial"].ToString();
                txtRFC.Text = dt.Rows[0]["RFC"].ToString();
                chkEstatus.Checked = bool.Parse(dt.Rows[0]["Estatus"].ToString());
                txtRegimenFiscal.Text = dt.Rows[0]["RegimenFiscal"].ToString();
                txtCorreoElectronico.Text = dt.Rows[0]["Email"].ToString();
                txtCalle.Text = dt.Rows[0]["Calle"].ToString();
                txtColonia.Text = dt.Rows[0]["Colonia"].ToString();
                txtNumExt.Text = dt.Rows[0]["NoExt"].ToString();
                txtNumInt.Text = dt.Rows[0]["NoInt"].ToString();
                txtCPo.Text = dt.Rows[0]["CP"].ToString();
                txtCiudad.Text = dt.Rows[0]["Ciudad"].ToString();
                txtEstado.Text = dt.Rows[0]["Estado"].ToString();
                txtPais.Text = dt.Rows[0]["Pais"].ToString();
                txtTelefono1.Text = dt.Rows[0]["Telefono1"].ToString();
                txtTelefono2.Text = dt.Rows[0]["Telefono2"].ToString();
                ERPProdEntities oContext = new ERPProdEntities();
                cat_empresas entity = oContext.cat_empresas.Where(w => w.Clave == clave).FirstOrDefault();
                pbFoto.Enabled = true;
                if (entity != null)
                {
                    if (entity.Logo != null)
                    {
                        using (var ms = new MemoryStream(entity.Logo))
                        {
                            pbFoto.Image = Image.FromStream(ms);
                        }
                        
                    }
                }
            }
            return dt == null ? 0 : (dt.Rows == null ? 0 : dt.Rows.Count);
        }

        private void SeleccionarFoto()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "images| *.JPG; *.PNG; *.GJF";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image logo = Image.FromFile(ofd.FileName);
                pbFoto.Image = logo;

                if (logo.Size.Width > 200 || logo.Size.Height > 200)
                {
                    pbFoto.Image = null;
                    MessageBox.Show("El logo no puede exceder los 200 X 200 pix");
                    return;
                }
            }
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
                    txtNombreEmpresa.Focus();
                }
            }
        }

        private void txtNombreEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtRFC.Focus();
            }
        }

        private void txtRFC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtNombreComercial.Focus();
            }
        }

        private void txtNombreComercial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtRegimenFiscal.Focus();
            }
        }

        private void txtRegimenFiscal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtCorreoElectronico.Focus();
            }
        }

        private void txtCorreoElectronico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                tcDatos.SelectedTab = tcDatos.TabPages[1];
                tcDatos.TabPages[1].Focus();
                txtCalle.Focus();
            }
        }

        private void txtCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtColonia.Focus();
            }
        }

        private void txtColonia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtNumExt.Focus();
            }
        }

        private void txtNumExt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtNumInt.Focus();
            }
        }

        private void txtNumInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtCPo.Focus();
            }
        }

        private void txtCPo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtCiudad.Focus();
            }
        }

        private void txtCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtEstado.Focus();
            }
        }

        private void txtEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtPais.Focus();
            }
        }

        private void txtPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtTelefono1.Focus();
            }
        }

        private void txtTelefono1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtTelefono2.Focus();
            }
        }
        
        private void dgvEmpresa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dgvEmpresa.Rows[rowIndex];
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

                }
            }
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

        private void frmEmpresas_Load(object sender, EventArgs e)
        {
            dgvEmpresa.DefaultCellStyle.ForeColor = Color.Black;
            Buscar();
            pbFoto.Enabled = false;
        }

        #endregion

        private void pbFoto_Click(object sender, EventArgs e)
        {
            SeleccionarFoto();
        }

        private void uiSubirFoto_Click(object sender, EventArgs e)
        {
            SeleccionarFoto();
        }
    }
}
