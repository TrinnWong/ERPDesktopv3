using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Catalogos
{
    public partial class frmCajasImpresoras : XtraForm
    {
        ERPProdEntities oContext = new ERPProdEntities();
        public PuntoVentaContext puntoVentaContext;
        int cajaImpresoraId { get; set; }
        private static frmCajasImpresoras _instance;

        public static frmCajasImpresoras GetInstance()
        {

            if (_instance == null) _instance = new frmCajasImpresoras();
            else _instance.BringToFront();
            return _instance;
        }


        public frmCajasImpresoras()
        {
            InitializeComponent();
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                ImpresorasBusiness oImpresora = new ImpresorasBusiness();

                cat_cajas_impresora entity = new cat_cajas_impresora();

                entity.CajaImpresoraId = this.cajaImpresoraId;
                entity.CajaId = this.puntoVentaContext.cajaId;
                entity.ImpresoraId = uiImpresora.EditValue != null ? short.Parse(uiImpresora.EditValue.ToString()) : (short)0;

               string error= oImpresora.CajasImpresoraUpd(entity, this.puntoVentaContext);

                if (error.Length > 0)
                {
                    XtraMessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un error al buscar las impresoras", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void llenarLkpImpresora()
        {
            try
            {
                int sucursalId = puntoVentaContext.sucursalId;

                uiImpresora.Properties.DataSource = oContext.cat_impresoras
                    .Where(w=> w.SucursalId == sucursalId).ToList();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Ocurrió un error al buscar las impresoras", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCajasImpresoras_Load(object sender, EventArgs e)
        {
            int cajaId = this.puntoVentaContext.cajaId;
            cat_cajas_impresora entity = oContext.cat_cajas_impresora
                .Where(w => w.CajaId == cajaId).FirstOrDefault();

            if(entity != null)
            {
                cajaImpresoraId = entity.CajaImpresoraId;
                uiImpresora.EditValue = entity.ImpresoraId;
            }
            llenarLkpImpresora();
        }

        private void frmCajasImpresoras_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }
    }
}
