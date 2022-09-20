using ConexionBD;
using ConexionBD.Models;
using ERP.Common.Procesos.Restaurante;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Procesos
{
    public partial class frmPuntoVentaCargo : Form
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        List<doc_pedidos_orden_cargos> lstCargos;

        public frmPuntoVentaCargo()
        {
            InitializeComponent();
        }

        private void frmPuntoVentaCargo_Load(object sender, EventArgs e)
        {
            oContext = new ERPProdEntities();
            llenarLkpCargo();

            lstCargos = frmPuntoVentaRest.GetInstance().lstCargos;

            marcarGrid();

        }

        public void llenarLkpCargo()
        {
            try
            {
                List<p_pv_cargos_adicionales_grd_Result> lst = oContext.p_pv_cargos_adicionales_grd(puntoVentaContext.sucursalId).ToList();

                uiGrid.DataSource = new BindingList<p_pv_cargos_adicionales_grd_Result>(lst);     }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrió un error al obtener los cargos", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void marcarGrid()
        {
            List<p_pv_cargos_adicionales_grd_Result> result = ((IEnumerable<p_pv_cargos_adicionales_grd_Result>)uiGrid.DataSource).ToList();

            for (int i = 0; i < result.Count; i++)
            {
                result[i].Seleccion = false;
            }

            foreach (var item1 in lstCargos)
            {
               
                    for (int i = 0; i < result.Count; i++)
                {
                    if(result[i].CargoAdicionalId == item1.CargoAdicionalId)
                    {
                        result[i].Seleccion = true;
                    }
                    
                }
            }

            uiGrid.DataSource = result;
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            try
            {
              List<p_pv_cargos_adicionales_grd_Result> result = ((IEnumerable<p_pv_cargos_adicionales_grd_Result>)uiGrid.DataSource).ToList();

                lstCargos = result.Where(w=> w.Seleccion == true).Select(s => new doc_pedidos_orden_cargos()
                {
                    CargoAdicionalId = s.CargoAdicionalId

                }
                ).ToList();

                frmPuntoVentaRest.GetInstance().asignarCargos(lstCargos);

                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrió un error al guardar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uiCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
