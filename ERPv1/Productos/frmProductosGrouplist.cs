using ConexionBD;
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
    public partial class frmProductosGrouplist : Form
    {
        ERPProdEntities oContext;
        private static frmProductosGrouplist _instance;
        public PuntoVentaContext puntoVentaContext;

        public static frmProductosGrouplist GetInstance()
        {
            if (_instance == null) _instance = new frmProductosGrouplist();
            else _instance.BringToFront();
            return _instance;
        }

        public frmProductosGrouplist()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        private void frmProductosGrouplist_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void frmProductosGrouplist_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void llenarGrid()
        {
            try
            {
                string text = uiTextBuscar.Text;
                uiGrid.DataSource = oContext.cat_productos_agrupados
                    .Where(
                        w => w.cat_productos.Clave.Contains(text) ||
                        w.cat_productos.Descripcion.Contains(text) ||
                        w.cat_productos.DescripcionCorta.Contains(text)||
                        text == ""
                    )
                    .Select(
                        s=> new {
                            ID = s.ProductoAgrupadoId,
                            Clave = s.cat_productos.Clave,
                            Descripcion = s.cat_productos.Descripcion,
                            DescripcionCorta = s.cat_productos.DescripcionCorta

                        }
                    )
                    .ToList();

                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }
        }

        private void uiBuscar_Click(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void uiAgregar_Click(object sender, EventArgs e)
        {

            frmProductosGroupUpd frmo = frmProductosGroupUpd.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.MdiParent = this.MdiParent; ;
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.accionForm = (int)Enumerados.accionForm.agregar;
                //frmo.tipoMovimientoForm = (int)Enumerados.tipoMovsInventario.ajustePorSalida;
                frmo.Show();

            }
        }

        private void uiEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = uiGrid.SelectedRows[0].Cells["ID"].Value == null ?
                    int.Parse(uiGrid.SelectedRows[0].Cells["ID"].Value.ToString()) : 0;


            }
            catch (Exception ex)
            {

                MessageBox.Show(
                    ex.Message,
                    "ERROR",
                     MessageBoxButtons.OK,
                      MessageBoxIcon.Asterisk
                    );
            }
        }

        private void uiGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex >= 0)
                {
                    int movimientoId = int.Parse(uiGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString());

                    if (movimientoId > 0)
                    {
                        frmProductosGroupUpd frmo = frmProductosGroupUpd.GetInstance();

                        if (!frmo.Visible)
                        {
                            //frmo = new frmPuntoVenta();
                            frmo.MdiParent = this.MdiParent; ;
                            frmo.puntoVentaContext = this.puntoVentaContext;
                            frmo.accionForm = (int)Enumerados.accionForm.actualizar;
                            frmo.idForm = movimientoId;
                            frmo.id = movimientoId;
                            //frmo.tipoMovimientoForm = (int)Enumerados.tipoMovsInventario.entradaDirecta;
                            frmo.Show();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR",
                     MessageBoxButtons.OK,
                      MessageBoxIcon.Asterisk);
            }
        }

        private void uiEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                    MessageBox.Show("¿Está seguro de eliminar el registro",
                    "AVISO",
                     MessageBoxButtons.YesNo,
                      MessageBoxIcon.Asterisk) == DialogResult.No
                    )
                {
                    return;
                }

                int id = uiGrid.SelectedRows[0].Cells["ID"].Value != null ?
                    int.Parse(uiGrid.SelectedRows[0].Cells["ID"].Value.ToString()) : 0;

                cat_productos_agrupados entity = oContext.cat_productos_agrupados
                    .Where(w => w.ProductoAgrupadoId == id).FirstOrDefault();

                List<cat_productos_agrupados_detalle> lstDel = entity.cat_productos_agrupados_detalle.ToList();

                foreach (var itemDet in lstDel)
                {
                    oContext.cat_productos_agrupados_detalle.Remove(itemDet);
                }

                oContext.cat_productos_agrupados.Remove(entity);

                oContext.SaveChanges();

                llenarGrid();
                    
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR",
                     MessageBoxButtons.OK,
                      MessageBoxIcon.Asterisk);
            }
        }
    }
}
