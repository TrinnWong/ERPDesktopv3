using ConexionBD;
using ConexionBD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Catalogos
{
    public partial class frmConfiguracionTicketVenta : Form
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        private static frmConfiguracionTicketVenta _instance;
        public static frmConfiguracionTicketVenta GetInstance()
        {

            if (_instance == null) _instance = new frmConfiguracionTicketVenta();
            else _instance.BringToFront();
            return _instance;
        }

        public frmConfiguracionTicketVenta()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        private void buscar()
        {
            try
            {
                int sucursalId = int.Parse(uiSucursal.SelectedValue.ToString());
                oContext = new ERPProdEntities();


                cat_configuracion_ticket_venta entity = oContext.cat_configuracion_ticket_venta.Where(w => w.SucursalId == sucursalId).FirstOrDefault();

                if (entity != null)
                {
                    uiTextoCabecera1.Text = entity.TextoCabecera1;
                    uiTextoCabcecera2.Text = entity.TextoCabecera2;
                    uiTextoPie.Text = entity.TextoPie;
                    uiSerie.Text = entity.Serie;
                    uiID.Value = entity.ConfiguracionTicketVentaId;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrió un error al intentar obtner la información", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmConfiguracionTicketVenta_Load(object sender, EventArgs e)
        {
            uiSucursal.DataSource = oContext.cat_sucursales.Where(w => w.Estatus == true).ToList();

            uiSucursal.SelectedValue = puntoVentaContext.sucursalId;

            buscar();
        
        }

        private void guardar()
        {
            try
            {
                int sucursalId = int.Parse(uiSucursal.SelectedValue.ToString());
                ObjectParameter pId = new ObjectParameter("pConfiguracionTicketVentaId",uiID.Value);

                

                oContext.p_cat_configuracion_ticket_venta_ins_upd(
                    pId,
                    sucursalId,
                    uiTextoCabecera1.Text,
                    uiTextoCabcecera2.Text,
                    uiTextoPie.Text,
                    puntoVentaContext.usuarioId,
                    uiSerie.Text);

                uiID.Value = int.Parse(pId.Value.ToString());

                MessageBox.Show("Los datos se guardaron correctamente", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrió un error al intentar guardar la información", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void frmConfiguracionTicketVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }
    }


}
