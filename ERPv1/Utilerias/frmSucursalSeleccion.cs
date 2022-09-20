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

namespace ERPv1.Utilerias
{
    public partial class frmSucursalSeleccion : Form
    {
        public ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        public frmSucursalSeleccion()
        {
            InitializeComponent();
        }

        private void LoadSucursales()
        {
            try
            {
                oContext = new ERPProdEntities();
                uiSucursal.Properties
                    .DataSource = oContext.cat_sucursales
                    .Where(w => w.cat_usuarios_sucursales.Where(s1 => s1.SucursalId == this.puntoVentaContext.sucursalId).Count() > 0)
                    .ToList();
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                   "ERP",
                                   this.Name,
                                   ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void frmSucursalSeleccion_Leave(object sender, EventArgs e)
        {

        }

        private void frmSucursalSeleccion_Load(object sender, EventArgs e)
        {
            LoadSucursales();
        }
    }
}
