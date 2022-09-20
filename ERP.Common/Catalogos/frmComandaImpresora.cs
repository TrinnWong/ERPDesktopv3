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
    public partial class frmComandaImpresora : XtraForm
    {
        ERPProdEntities oContext = new ERPProdEntities();
        public PuntoVentaContext puntoVentaContext;
        int cajaImpresoraId { get; set; }
        private static frmComandaImpresora _instance;

        public static frmComandaImpresora GetInstance()
        {

            if (_instance == null) _instance = new frmComandaImpresora();
            else _instance.BringToFront();
            return _instance;
        }


        public frmComandaImpresora()
        {
            InitializeComponent();
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                ImpresorasBusiness oImpresora = new ImpresorasBusiness();

                cat_impresoras_comandas entity = new cat_impresoras_comandas();

               
                entity.ImpresoraId = uiImpresora.EditValue != null ? short.Parse(uiImpresora.EditValue.ToString()) : (short)0;

               string error= oImpresora.ComandaImpresoraUpd(entity, this.puntoVentaContext);

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
            int sucursalId = this.puntoVentaContext.sucursalId;

            cat_impresoras_comandas entity = oContext.cat_impresoras_comandas
                .Where(w => w.cat_impresoras.SucursalId == sucursalId).FirstOrDefault();

            if(entity != null)
            {
                cajaImpresoraId = entity.ImpresoraId;
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
