using ConexionBD;
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
    public partial class frmSucursales : Form
    {

        ERPProdEntities model;
        public frmSucursales()
        {
            InitializeComponent();

            model = new ERPProdEntities();
        }

        private void frmSucursales_Load(object sender, EventArgs e)
        {
            cmbEmpresa.DataSource = model.cat_empresas.ToList();
            cmbEmpresa.SelectedValue = 0;
            LlenarGrid();

            Limpiar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                int empresa = cmbEmpresa.SelectedValue != null ? (int)cmbEmpresa.SelectedValue : 0;
                int clave = (int)nClave.Value;
                if (nClave.Value <= 0)
                {
                    MessageBox.Show("La clave debe de ser mayor a cero");
                    return;
                }
                if (txtNombreFamilia.Text == "")
                {
                    MessageBox.Show("El nombre de familia es requerido");
                    return;
                }

                if (
                    model.cat_sucursales.Where(w => w.Clave == clave).Count() > 0
                    )
                {
                    MessageBox.Show("La clave ya existe");
                    return;
                }


                if (
                  empresa <= 0
                   )
                {
                    MessageBox.Show("La EMPRESA es requerida");
                    return;
                }


                model.p_cat_sucursales_ins((int)nClave.Value, (int)cmbEmpresa.SelectedValue,txtCalle.Text,txtColonia.Text, txtNumExt.Text, txtNumInt.Text,
                     txtCiudad.Text,txtEstado.Text,txtPais.Text, txtTelefono1.Text,txtTelefono2.Text,null, chkEstatus.Checked, txtNombreFamilia.Text, txtCPo.Text,
                     uiSMTP.Text, uiCorreo.Text, short.Parse(uiPuerto.Value.ToString()), uiPassword.Text);

                MessageBox.Show("El registro se agregó correctamente", "OK");
                Limpiar();
                LlenarGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void Limpiar()
        {
            nClave.Value = 0;
            txtNombreFamilia.Text = "";
            chkEstatus.Checked = true;
            cmbEmpresa.SelectedValue = 0;
            txtCalle.Text = "";
            txtColonia.Text = "";
            txtNumExt.Text = "";
            txtNumInt.Text = "";
            txtCiudad.Text = "";
            txtEstado.Text = "";
            txtPais.Text = "";
            txtTelefono2.Text = "";
            txtTelefono1.Text = "";
            txtCPo.Text = "";
            uiSMTP.Text = "";
            uiCorreo.Text = "";
            uiPuerto.Value = 0;
            uiPassword.Text = "";

            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void LlenarGrid()
        {
            dgvFamilia.AutoGenerateColumns = false;
            dgvFamilia.DataSource = model.p_cat_sucursales_grd(txtBuscar.Text);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LlenarGrid();


        }

        private void BuscarRegistro(int clave)
        {
           var reg = model.p_cat_sucursales_grd(clave.ToString()).ToList();

            if(reg.Count() > 0)
            {
                var reg1 = reg.ToList()[0];
                this.nClave.Value = reg1.Clave;
                txtNombreFamilia.Text = reg1.NombreSucursal;
                chkEstatus.Checked = reg1.Estatus ?? false;
                cmbEmpresa.SelectedValue = reg1.Empresa;
                txtCalle.Text = reg1.Calle;
                txtColonia.Text = reg1.Colonia;
                txtNumExt.Text = reg1.NoExt;
                txtNumInt.Text = reg1.NoInt;
                txtCiudad.Text = reg1.Ciudad;
                txtEstado.Text = reg1.Estado;
                txtPais.Text = reg1.Pais;
                txtTelefono1.Text = reg1.Telefono1;
                txtTelefono2.Text = reg1.Telefono2;
                txtCPo.Text = reg1.cp;
                uiSMTP.Text = reg1.ServidorMailSMTP;
                uiCorreo.Text = reg1.ServidorMailFrom;
                uiPuerto.Value = short.Parse(reg1.ServidorMailPort.ToString());
                uiPassword.Text = reg1.ServidorMailPassword;
            }
           
        }

        private void dgvFamilia_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = this.dgvFamilia.Rows[rowIndex];
                try
                {
                    if ((int)row.Cells[0].Value > 0)
                    {
                        int clave = (int)row.Cells[0].Value;
                        if (clave > 0)
                        {
                           this.nClave.Value = clave;
                            BuscarRegistro(clave);
                        }
                        else
                        {
                            nClave.Value = 0;
                        }
                    }
                }
                catch (Exception ex) { }
            }

            btnAgregar.Enabled = false;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           



            if (MessageBox.Show("¿Está seguro de eliminar el registro?", "Mensaje", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int clave = (int)this.nClave.Value;
                cat_sucursales entity = model.cat_sucursales.Where(w => w.Clave == clave).FirstOrDefault();

                try
                {
                    this.model.cat_sucursales.Remove(entity);
                    this.model.SaveChanges();
                }
                catch (Exception)
                {
                    entity.Estatus = false;
                    this.model.SaveChanges();
                }
                //entity.Estatus = false;
               
                Limpiar();
                LlenarGrid();
            }
           
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int empresa = cmbEmpresa.SelectedValue != null ? (int)cmbEmpresa.SelectedValue : 0;
                int clave = (int)nClave.Value;
                if (nClave.Value <= 0)
                {
                    MessageBox.Show("La clave debe de ser mayor a cero");
                    return;
                }
                if (txtNombreFamilia.Text == "")
                {
                    MessageBox.Show("El nombre de familia es requerido");
                    return;
                }

                if (
                empresa <= 0
                 )
                {
                    MessageBox.Show("La EMPRESA es requerida");
                    return;
                }




                model.p_cat_sucursales_upd((int)nClave.Value, (int)cmbEmpresa.SelectedValue,txtCalle.Text, txtColonia.Text,txtNumExt.Text,txtNumInt.Text,
                     txtCiudad.Text,txtEstado.Text,txtPais.Text,txtTelefono1.Text, txtTelefono2.Text,null, chkEstatus.Checked, txtNombreFamilia.Text,txtCPo.Text,
                     uiSMTP.Text,uiCorreo.Text,short.Parse(uiPuerto.Value.ToString()),uiPassword.Text);

                MessageBox.Show("El registro se editó correctamente", "OK");
                Limpiar();
                LlenarGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void dgvFamilia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
