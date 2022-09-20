using ConexionBD;
using DevExpress.XtraEditors;
using ERP.Business;
using ERP.Common.Base;
using ERP.Models.ProduccionSolicitud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Produccion.Desktop
{
    public partial class frmProduccionSolicitudList :  FormBaseXtraForm
    {
        private static frmProduccionSolicitudList _instance;
        ProduccionSolicitudBusiness oProduccionSolicitud;
        string error = "";
        public static frmProduccionSolicitudList GetInstance()
        {
            if (_instance == null) _instance = new frmProduccionSolicitudList();
            return _instance;
        }

        public frmProduccionSolicitudList()
        {
            InitializeComponent();
            oContext = new ConexionBD.ERPProdEntities();
            oProduccionSolicitud = new ProduccionSolicitudBusiness();
        }


        private void uiAgregar_Click(object sender, EventArgs e)
        {
            frmProduccionSolicitudUpd frmo = frmProduccionSolicitudUpd.GetInstance();

            if (!frmo.Visible)
            {
                //frmo = new frmPuntoVenta();
                frmo.idForm = 0;
                frmo.MdiParent = frmMain.GetInstance();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;

                frmo.Show();

            }
        }

        private void LoadGrid()
        {
            try
            {
                uiGrid.DataSource = oContext.doc_produccion_solicitud
                    .Select(
                        s=> new ERP.Models.ProduccionSolicitud.ProduccionSolicitudGridModel()
                        {
                             activa = s.Activa,
                              completada = s.Terminada??false,
                               CreadoEl = s.CreadoEl,
                                deSucursal = s.cat_sucursales.NombreSucursal,
                                paraSucursal = s.cat_sucursales1.NombreSucursal,
                                 produccionSolicitudId = s.ProduccionSolicitudId
                        }
                    ).ToList();

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

        private void frmProduccionSolicitudList_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void repBtnDel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
               
               

                if (uiGridView.FocusedRowHandle >= 0)
                {
                    ERP.Models.ProduccionSolicitud.ProduccionSolicitudGridModel focusedRow = (ERP.Models.ProduccionSolicitud.ProduccionSolicitudGridModel)uiGridView.GetRow(uiGridView.FocusedRowHandle);


                    var entity = oContext.doc_produccion_solicitud
                        .Where(w => w.ProduccionSolicitudId == focusedRow.produccionSolicitudId).FirstOrDefault();

                    if(entity.Enviada == true)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("La solicitud está enviada ,no es posible eliminar");
                        return;
                    }

                    if (XtraMessageBox.Show("¿Está seguro(a) de eliminar el registro?", "Aviso",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }
                   

                    error = oProduccionSolicitud.Eliminar(focusedRow.produccionSolicitudId,puntoVentaContext.usuarioId,puntoVentaContext.sucursalId);

                    if(error.Length > 0)
                    {
                        ERP.Utils.MessageBoxUtil.ShowError(error);
                    }
                    else
                    {
                        LoadGrid();
                        ERP.Utils.MessageBoxUtil.ShowOk();
                    }

                }

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

        private void frmProduccionSolicitudList_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void repBtnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ProduccionSolicitudGridModel model = (ProduccionSolicitudGridModel)uiGridView.GetRow(uiGridView.FocusedRowHandle);
            frmProduccionSolicitudUpd frmo = frmProduccionSolicitudUpd.GetInstance();

            if (!frmo.Visible)
            {
               
                frmo.idForm = model.produccionSolicitudId;
                frmo.MdiParent = frmMain.GetInstance();
                frmo.puntoVentaContext = this.puntoVentaContext;
                frmo.WindowState = FormWindowState.Maximized;

                frmo.Show();

            }
        }

        private void uiRefresh_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
    }
}
