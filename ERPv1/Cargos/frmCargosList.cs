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

namespace ERPv1.Cargos
{
    public partial class frmCargosList : FormBaseXtraForm
    {
        private static frmCargosList _instance;
        int err = 0;
       
        int clienteId = 0;
        int sucursalId = 0;
        public static frmCargosList GetInstance()
        {
            if (_instance == null) _instance = new frmCargosList();
            else _instance.BringToFront();
            return _instance;
        }
        public frmCargosList()
        {
            oContext = new ConexionBD.ERPProdEntities();
            InitializeComponent();
        }

        
        private void LoadClientes()
        {
            try
            {
                uiCliente.Properties.DataSource = oContext.cat_clientes
                    .OrderBy(o=> o.Nombre)
                    .ToList();
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

        private void LoadGrid()
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();
                clienteId = uiCliente.EditValue == null ? 0 : Convert.ToInt32(uiCliente.EditValue);
                sucursalId = uiSucursal.EditValue == null ? 0 : Convert.ToInt32(uiSucursal.EditValue);

                uiGrid.DataSource = oContext.doc_cargos
                    .Where(
                        w => (w.ClienteId == clienteId || clienteId == 0) && w.Activo == true &&
                        (sucursalId == 0 || w.doc_pedidos_cargos.Where(s1=> s1.doc_pedidos_orden.SucursalId == sucursalId).Count() > 0)
                     )
                    .OrderByDescending(o => o.Saldo).ToList();

                uiGridView.ExpandAllGroups();
               
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
        private void frmCargosList_Load(object sender, EventArgs e)
        {
           
            LoadClientes();
            LoadSucursales();
        }

        private void uiCliente_EditValueChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void frmCargosList_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void repDetalle_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(uiGridView.FocusedRowHandle >= 0)
                {
                    doc_cargos entity = (doc_cargos)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                    if(entity != null)
                    {
                        frmCargoDetalleList frm = new frmCargoDetalleList();

                        frm.cargoId = entity.CargoId;
                        frm.WindowState = FormWindowState.Normal;
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.puntoVentaContext = this.puntoVentaContext;
                        frm.ShowDialog();
                    }
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

        private void uiRefrescar_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadSucursales()
        {
            try
            {
                oContext = new ERPProdEntities();
                uiSucursal.Properties.DataSource = oContext.cat_sucursales
                    .ToList();
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

       
    }
}
