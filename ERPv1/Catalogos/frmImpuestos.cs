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
    public partial class frmImpuestos : Form
    {
        ERPProdEntities oContext;
        Impuestos oData;
        
        public frmImpuestos()
        {
            oContext = new ERPProdEntities();
            oData = new Impuestos();
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       
        private void frmImpuestos_Load(object sender, EventArgs e)
        {
            uiAbreviatura.DataSource = oContext.cat_abreviaturas_SAT.ToList();
            uiClasificacion.DataSource = oContext.cat_clasificacion_impuestos.ToList();
            uiTipoFactor.DataSource = oContext.cat_tipo_factor_SAT.ToList();

            LimpiarCombos();

            Buscar();
           

        }

       

       
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string error = "";

            try
            {
                cat_impuestos entity = new cat_impuestos();

                entity.Clave = (int)nClave.Value;
                entity.AgregarImpPrecioVta = uiAgregarImpPVta.Checked;
                entity.CodigoSAT = uiCondigoSAT.Text;
                entity.CuotaFija = uiCuotaFija.Value;
                entity.DecimalesPorcCuota = (byte?)uiDecimales.Value;
                entity.Descripcion = uiDescripcion.Text;
                entity.DesglosarImpPrecioVta = uiDesglosarImpPVta.Checked;
                entity.IdAbreviatura = uiAbreviatura.SelectedValue != null ? int.Parse(uiAbreviatura.SelectedValue.ToString()): -1;
                entity.IdClasificacionImpuesto = uiClasificacion.SelectedValue != null ?
                    int.Parse(uiClasificacion.SelectedValue.ToString()) : -1;
                entity.IdTipoFactor = uiTipoFactor.SelectedValue!=null ?
                        int.Parse(uiTipoFactor.SelectedValue.ToString()):-1;
                entity.OrdenImpresion = (byte)uiOrden.Value;
                entity.Porcentaje = (decimal?)uiPorcentaje.Value;

               

               error= oData.Insertar(entity);

                if (error.Length > 0)
                {
                    MessageBox.Show(error, "Error");
                }
                else {
                    MessageBox.Show("La información se ha guardado correctamente", "Error");
                    Limpiar();
                    Buscar();
                }


              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
            }
            
        }

        private void gbDatos_Enter(object sender, EventArgs e)
        {

        }

        #region funciones

        private void LimpiarCombos()
        {
            uiAbreviatura.SelectedIndex = -1;
            uiAbreviatura.Text = "(Seleccionar)";
            uiClasificacion.SelectedIndex = -1;
            uiClasificacion.Text = "(Seleccionar)";
            uiTipoFactor.SelectedIndex = -1;
            uiTipoFactor.Text = "(Seleccionar)";
        }
        private void Limpiar()
        {
            nClave.Enabled = true;
            nClave.Value = 0;
            uiAgregarImpPVta.Checked = false;
            uiCondigoSAT.Text = "";
            uiCuotaFija.Value = 0;
            uiDecimales.Value = 0;
            uiDescripcion.Text = "";
            uiDesglosarImpPVta.Checked = false;
            uiAbreviatura.SelectedValue = 0;
            uiClasificacion.SelectedValue = 0;
            uiTipoFactor.SelectedValue = 0;
            uiOrden.Value = 0;
            uiPorcentaje.Value = 0;

            LimpiarCombos();
        }

        private void Buscar()
        {
            uiGrid.DataSource = oContext.p_cat_impuestos_grd(txtBuscar.Text);
            //var dt = oContext.p_cat_impuestos_grd(txtBuscar.Text);
            //if (dt.Count() > 0)
            //{
            //    //nClave.Enabled = false;
            //    //nClave.Value = dt.FirstOrDefault().Clave;
            //    //uiAbreviatura.Text = dt.FirstOrDefault().Abreviatura;
            //    //uiAgregarImpPVta.Checked = dt.FirstOrDefault().AgregarImpPrecioVta ?? false;
            //    //uiClasificacion.SelectedItem = dt.FirstOrDefault().Clasificacion;
            //    //uiCondigoSAT.Text = dt.FirstOrDefault().CodigoSAT;
            //    //uiCuotaFija.Value = dt.FirstOrDefault().CuotaFija ?? 0;
            //    //uiDecimales.Value = dt.FirstOrDefault().DecimalesPorcCuota ?? 0;
            //    //uiDescripcion.Text = dt.FirstOrDefault().Descripcion;
            //    //uiDesglosarImpPVta.Checked = dt.FirstOrDefault().DesglosarImpPrecioVta ?? false;

            //}

        }

        private void BuscarRegistro(int clave)
        {
            oContext = new ERPProdEntities();
            if (clave > 0)
            {
                var reg = oContext.cat_impuestos.Where(w => w.Clave == clave).FirstOrDefault();


                // List<cat_impuestos> dt = oContext.cat_impuestos.Where(w => w.Clave == clave).ToList();
                if (reg!= null)
                {
                    nClave.Enabled = false;
                    nClave.Value = reg.Clave;
                    uiAbreviatura.SelectedValue = reg.IdAbreviatura;

                    uiClasificacion.SelectedValue = reg.IdClasificacionImpuesto;
                    uiCondigoSAT.Text = reg.CodigoSAT;
                    uiCuotaFija.Value = reg.CuotaFija ?? 0;
                    uiDecimales.Value = reg.DecimalesPorcCuota ?? 0;
                    uiDescripcion.Text = reg.Descripcion;
                    uiTipoFactor.SelectedValue = reg.IdTipoFactor;
                    //uiAgregarImpPVta.Checked = dt.FirstOrDefault().AgregarImpPrecioVta ?? false;
                    uiOrden.Value = reg.OrdenImpresion;
                    uiPorcentaje.Value = reg.Porcentaje ?? 0;

                    if (reg.DesglosarImpPrecioVta == true)
                    {
                        uiDesglosarImpPVta.Checked = true;
                        uiAgregarImpPVta.Checked = false;
                    }
                    else
                    {
                        uiAgregarImpPVta.Checked = true;
                        uiDesglosarImpPVta.Checked = false;
                    }

                }
            }
          
        }

       

        #endregion

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string error = "";

            try
            {
                cat_impuestos entity = new cat_impuestos();

                entity.Clave = (int)nClave.Value;
                entity.AgregarImpPrecioVta = uiAgregarImpPVta.Checked;
                entity.CodigoSAT = uiCondigoSAT.Text;
                entity.CuotaFija = uiCuotaFija.Value;
                entity.DecimalesPorcCuota = (byte?)uiDecimales.Value;
                entity.Descripcion = uiDescripcion.Text;
                entity.DesglosarImpPrecioVta = uiDesglosarImpPVta.Checked;
                entity.IdAbreviatura = int.Parse(uiAbreviatura.SelectedValue.ToString());
                entity.IdClasificacionImpuesto = int.Parse(uiClasificacion.SelectedValue.ToString());
                entity.IdTipoFactor = int.Parse(uiTipoFactor.SelectedValue.ToString());
                entity.OrdenImpresion = (byte)uiOrden.Value;
                entity.Porcentaje = (decimal?)uiPorcentaje.Value;



                error = oData.Actualizar(entity);

                if (error.Length > 0)
                {
                    MessageBox.Show(error, "Error");
                }
                else
                {
                    MessageBox.Show("La información se ha guardado correctamente", "Error");
                    Limpiar();
                    Buscar();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (nClave.Value > 0)
                {

                    if (MessageBox.Show("¿Está seguro de eliminar el registro?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        oData.Eliminar((int)nClave.Value);
                        Limpiar();
                        Buscar();

                        MessageBox.Show("El registro se eliminó correctamente", "Aviso");
                    }
                }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void uiGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = uiGrid.Rows[rowIndex];
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

        private void uiGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void uiCuotaFija_ValueChanged(object sender, EventArgs e)
        {
            if (uiCuotaFija.Value > 0)
            {
                uiPorcentaje.Value = 0;
            }
        }

        private void uiPorcentaje_ValueChanged(object sender, EventArgs e)
        {
            if (uiPorcentaje.Value > 0)
            {
                uiCuotaFija.Value = 0;
            }
        }
    }
}
