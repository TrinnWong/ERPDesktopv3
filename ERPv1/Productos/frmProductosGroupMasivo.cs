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

namespace ERPv1.Productos
{
    public partial class frmProductosGroupMasivo : Form
    {
        ERPProdEntities oCOntext;
        ProductoAgrupadoBusiness oBusiness;
        public int id;
        public frmProductosGroupMasivo()
        {
            InitializeComponent();
            oCOntext = new ERPProdEntities();
            oBusiness = new ProductoAgrupadoBusiness();
        }

        public void llenarGrid()
        {
            try
            {
                string texto = uiTextoBusca.Text;
                uiGrid.DataSource = oCOntext.cat_productos
                    .Where(
                    w => w.Clave.Contains(texto) ||
                    w.Descripcion.Contains(texto) ||
                    w.DescripcionCorta.Contains(texto) ||
                    texto == ""
                    )
                    .Select(
                        s => new
                        {
                           
                            ID = s.ProductoId,
                            Clave = s.Clave,
                            Descripcion = s.Descripcion,
                            DescripcionCorta = s.DescripcionCorta,
                            Talla = s.Talla,
                            Color = s.Color
                        }
                    ).ToList();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
        }

        private void uiBuscar_Click(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                int rowCount = uiGrid.RowCount;

                List<int> lst = new List<int>();

                for (int i = 0; i < rowCount; i++)
                {
                    bool select = uiGrid.Rows[i].Cells[0].Value != null ?
                        bool.Parse(uiGrid.Rows[i].Cells[0].Value.ToString()) : false;

                    if (select)
                    {
                        int productoId = uiGrid.Rows[i].Cells["ID"].Value != null ?
                        int.Parse(uiGrid.Rows[i].Cells["ID"].Value.ToString()) : 0;

                        if (productoId > 0)
                        {
                            lst.Add(productoId);
                        }
                    }
                }

              string error=  oBusiness.guardarMasivo(lst, id);

                if (error.Length > 0)
                {
                    MessageBox.Show(error,
                    "ERROR",
                     MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                }
                else {

                    frmProductosGroupUpd.GetInstance().llenarGridDetalle();

                    this.Close();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,
                    "ERROR",
                     MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
            }
            
        }
    }
}
