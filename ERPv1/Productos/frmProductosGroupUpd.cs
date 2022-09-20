using ConexionBD;
using ConexionBD.Forms;
using ConexionBD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPv1.Productos
{
    public partial class frmProductosGroupUpd : FormERP
    {
        public PuntoVentaContext puntoVentaContext;
        int productoBaseId;
        int productoBaseDetId;
        public int id;
        private static frmProductosGroupUpd _instance;
        ERPProdEntities oContext;
        ProductoInterface oProducto;
        ProductoAgrupadoBusiness oProductoAgrupado;

        public static frmProductosGroupUpd GetInstance()
        {
            if (_instance == null) _instance = new frmProductosGroupUpd();
            else _instance.BringToFront();
            return _instance;
        }

        public frmProductosGroupUpd()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
            oProductoAgrupado = new ProductoAgrupadoBusiness();
            oProducto = new ProductoInterface();
        }

        private void uiClave_Validated(object sender, EventArgs e)
        {
            try
            {
                string clave = uiClave.Text;

                cat_productos entity = oProducto.GetByClave(clave);

                if (entity != null)
                {
                    productoBaseId = entity.ProductoId;
                    uiProducto.Text = entity.Descripcion;
                    uiDescCorta.Text = entity.DescripcionCorta + entity.Color +"-"+entity.Color2 ;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            string error = oProductoAgrupado.guardarEnc(ref id, productoBaseId,uiEspecificaciones.Text,uiLiquidacion.Checked);

            if (error.Length > 0)
            {
                MessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                MessageBox.Show("El encabezado ha sido guardado con éxito","OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                grDetalle.Enabled = true;
            }
        }

        private void frmProductosGroupUpd_Load(object sender, EventArgs e)
        {
            try
            {
                if (id > 0)
                {
                    cat_productos_agrupados entity = oContext.cat_productos_agrupados
                        .Where(w => w.ProductoAgrupadoId == id).FirstOrDefault();

                    if (entity != null)
                    {
                        productoBaseId = entity.ProductoId;
                        uiClave.Text = entity.cat_productos.Clave;
                        uiProducto.Text = entity.cat_productos.Descripcion;
                        uiDescCorta.Text = entity.cat_productos.DescripcionCorta;
                        uiEspecificaciones.Text = entity.Especificaciones;
                        uiLiquidacion.Checked = entity.Liquidacion ?? false;
                        grDetalle.Enabled = true;

                        llenarGridDetalle();
                    }


                }
                else {
                    grDetalle.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar el formulario:"+ ex.Message,
                    "ERROR",
                     MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiClave2_Validated(object sender, EventArgs e)
        {
            try
            {
                string clave = uiClave2.Text;

                cat_productos entity = oProducto.GetByClave(clave);

                if (entity != null)
                {
                    productoBaseDetId = entity.ProductoId;
                    uiProducto2.Text = entity.Descripcion;
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string error = oProductoAgrupado.guardarDet(id, productoBaseDetId);

                if (error.Length > 0)
                {
                    MessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("El Detalle ha sido guardado con éxito", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    grDetalle.Enabled = true;
                    llenarGridDetalle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "ERROR",
                     MessageBoxButtons.OK,
                      MessageBoxIcon.Error
                    );
                throw;
            }
        }

        public void llenarGridDetalle()
        {
            try
            {
                uiGridDetalle.DataSource =

                oContext.cat_productos_agrupados_detalle
                    .Where(
                        w => w.ProductoAgrupadoId == id
                    ).Select(
                        s => new
                        {
                            ID = s.ProductoId,
                            Clave = s.cat_productos.Clave,
                            Descripcion = s.cat_productos.Descripcion,
                            DescripcionCorta = s.cat_productos.DescripcionCorta,
                            Color = s.cat_productos.Color,
                            Talla = s.cat_productos.Talla
                        }
                    ).ToList();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Eliminar()
        {
            try
            {
                if (MessageBox.Show("¿Está seguro de eliminar el registro?",
                     "Aviso",
                      MessageBoxButtons.YesNo,
                       MessageBoxIcon.Asterisk                       
                     
                    ) == DialogResult.No
                    )
                {
                    return;
                }

                int idDet = uiGridDetalle.SelectedRows[0].Cells["ID"].Value != null ?
                        int.Parse(uiGridDetalle.SelectedRows[0].Cells["ID"].Value.ToString()) : 0;

                if (idDet > 0)
                {
                    

                    cat_productos_agrupados_detalle entity = oContext.cat_productos_agrupados_detalle
                         .Where(w => w.ProductoId == idDet && w.ProductoAgrupadoId == id).FirstOrDefault();

                    if (entity.cat_productos_agrupados.ProductoId == idDet)
                    {
                        MessageBox.Show("No es posible eliminar el producto base", "ERROR",
                        MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                        return;
                    }

                    if (entity != null)
                    {
                        oContext.cat_productos_agrupados_detalle.Remove(entity);
                        oContext.SaveChanges();
                        llenarGridDetalle();
                        MessageBox.Show("Se ha eliminado el registro",
                            "OK",
                             MessageBoxButtons.OK,
                              MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR",
                     MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
            }
        }

        private void uiEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void frmProductosGroupUpd_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmProductosGroupMasivo oForm = new frmProductosGroupMasivo();
            oForm.id = this.id;
            oForm.ShowDialog();
        }
    }
}
