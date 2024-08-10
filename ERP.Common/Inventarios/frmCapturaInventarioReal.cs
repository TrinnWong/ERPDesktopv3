using ConexionBD;
using DevExpress.XtraEditors;
using ERP.Business;
using ERP.Common.Base;
using ERP.Models;
using ERP.Reports.TacosAna;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Inventarios
{
    public partial class frmCapturaInventarioReal : FormBaseXtraForm
    {
        int err;

        ResultAPIModel error;

        private static frmCapturaInventarioReal _instance;
        public static frmCapturaInventarioReal GetInstance()
        {
            if (_instance == null) _instance = new frmCapturaInventarioReal();
            else _instance.BringToFront();
            return _instance;
        }

        public frmCapturaInventarioReal()
        {
            InitializeComponent();

            oContext = new ConexionBD.ERPProdEntities(true);
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            
            if (XtraMessageBox.Show("¿Está seguro(a) de continuar?, no será posible revertir los cambios", "AVISO",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                error = InventarioBusiness.GuardarInventarioReal(((List<doc_inventario_registro>)uiGrid.DataSource), puntoVentaContext.sucursalId,
                    puntoVentaContext.usuarioId, oContext);

                if (!error.ok)
                {
                    ERP.Utils.MessageBoxUtil.ShowError(error.error);
                }
                else
                {
                
                    ERP.Utils.MessageBoxUtil.ShowOk();
                }
            }

        }

        #region funciones
        public void llenarGrid()
        {
            try
            {
                uiGrid.DataSource = oContext.p_doc_inventario_registro_sel(this.puntoVentaContext.sucursalId, DateTime.Now)
                    .Select(
                        s => new doc_inventario_registro()
                        {
                             CantidadReal = s.CantidadReal??0,
                              CantidadTeorica = s.CantidadTeorica??0,
                               CreadoEl = s.CreadoEl??DateTime.Now,                                
                                 Diferencia = s.Diferencia??0,
                                  ProductoId = s.ProductoId,
                                   RegistroInventarioId = s.RegistroInventarioId??0,
                                    SucursalId = s.SucursalId ??0,
                                    cat_productos = new cat_productos()
                                    {
                                        DescripcionCorta = s.DescripcionCorta
                                    }
                        }
                    ).ToList();
                    
            }
            catch (Exception ex)
            {
                err = ERP.Business.SisBitacoraBusiness.Insert(
                    puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void imprimir()
        {
            try
            {
                ERP.Reports.TacosAna.rptInventarioReal oTicket2 = new ERP.Reports.TacosAna.rptInventarioReal();

                ERP.Common.Reports.ReportViewer oViewer = new ERP.Common.Reports.ReportViewer(puntoVentaContext.sucursalId,this.puntoVentaContext.cajaId, false);

                oTicket2.DataSource = oContext.p_doc_inventario_registro_sel(this.puntoVentaContext.sucursalId, DateTime.Now).ToList();

                oViewer.ShowTicket(oTicket2);
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                              "ERP",
                              this.Name,
                              ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }
        #endregion

        private void frmCapturaInventarioReal_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void frmCapturaInventarioReal_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiImprimir_Click(object sender, EventArgs e)
        {
            imprimir();
        }
    }
}
