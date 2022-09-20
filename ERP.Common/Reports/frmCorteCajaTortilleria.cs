using ConexionBD;
using ERP.Common.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Reports
{
    public partial class frmCorteCajaTortilleria : FormBaseXtraForm
    {
        private static frmCorteCajaTortilleria _instance;
        string error = "";
        int err = 0;
        public frmCorteCajaTortilleria()
        {
            InitializeComponent();
        }

        public static frmCorteCajaTortilleria GetInstance()
        {
            if (_instance == null) _instance = new frmCorteCajaTortilleria();
            else _instance.BringToFront();
            return _instance;
        }

        private void uiBuscar_Click(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void llenarGrid()
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();

                uiGrid.DataSource = oContext.p_corte_caja_inventario_generacion(puntoVentaContext.sucursalId,
                    uiFechaIni.DateTime, uiFechaIni.DateTime).ToList();

                if(((List<p_corte_caja_inventario_generacion_Result>)uiGrid.DataSource).Count() > 0)
                {
                    uiTotalAnalisis.EditValue = ((List<p_corte_caja_inventario_generacion_Result>)uiGrid.DataSource).FirstOrDefault().TotalAnalisisCorteCaja;
                    uiTotalEntregado.EditValue = ((List<p_corte_caja_inventario_generacion_Result>)uiGrid.DataSource).FirstOrDefault().TotalEntregadoSucursal;
                    uiTotalDescuentos.EditValue = ((List<p_corte_caja_inventario_generacion_Result>)uiGrid.DataSource).FirstOrDefault().TotalDescuentos;
                    uiDiferencia.EditValue = ((List<p_corte_caja_inventario_generacion_Result>)uiGrid.DataSource).FirstOrDefault().Diferencia;

                    uiGridView.ExpandAllGroups();

                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                               "ERP",
                                               this.Name,
                                               ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void frmCorteCajaTortilleria_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }
    }
}
