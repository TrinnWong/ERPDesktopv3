using ERP.Models.Otros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TacosAna.Desktop
{
    public partial class frmItemsAdicionales : Form
    {
        int err = 0;
        int nBotones = 42;
        int i = 0;
        public List<ItemGenericModel> lstItems;
        public ItemGenericModel result;
        public frmItemsAdicionales()
        {
            InitializeComponent();

            result = new ItemGenericModel();


        }

        private void LlenarBotones()
        {
            try
            {
                i = 1;
                for (int i = 1; i <= nBotones; i++)
                {
                    Control controlA = Controls.Find("btnA_" + i.ToString(), true).FirstOrDefault();

                    if (controlA != null)
                    {
                        controlA.AccessibleName ="";
                        controlA.Text = "";
                        controlA.Enabled = false;
                    }
                }

                i = 1;
                foreach (var item in lstItems)
                {

                    Control controlA = Controls.Find("btnA_" + i.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        controlA.AccessibleName = item.Id.ToString();
                        controlA.Text = item.Descripcion;
                        controlA.Enabled = true;
                    }


                    i++;

                    if (i > nBotones)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                                      "ERP",
                                      this.Name,
                                      ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void frmItemsAdicionales_Load(object sender, EventArgs e)
        {
            LlenarBotones();
        }

        private void btnA_1_Click(object sender, EventArgs e)
        {
            result.Descripcion = ((Button)sender).Text; result.Id = Convert.ToInt32( ((Button)sender).AccessibleName);

            this.DialogResult = DialogResult.OK;
        }
    }
}
