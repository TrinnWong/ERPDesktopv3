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

namespace ERPv1.Catalogos
{
    public partial class frmSucursalesDepartamentos : FormBaseXtraForm
    {
        private static frmSucursalesDepartamentos _instance;
        int err;
        cat_sucursales_departamentos row;
        public static frmSucursalesDepartamentos GetInstance()
        {
            if (_instance == null) _instance = new frmSucursalesDepartamentos();
            else _instance.BringToFront();
            return _instance;
        }
        public frmSucursalesDepartamentos()
        {
            InitializeComponent();
            oContext = new ConexionBD.ERPProdEntities();
        }

        private void uiAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if(uiSucursal.EditValue == null ||
                    uiDepartamento.EditValue == null
                    )
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("La información de Sucursal y Departamento es Requerida");
                }

                row = new cat_sucursales_departamentos();

                row.DepartamentoId = Convert.ToInt32(uiDepartamento.EditValue);
                row.SucursalId = Convert.ToInt32(uiSucursal.EditValue);
                row.CreadoEl = DateTime.Now;
                row.CreadoPor = puntoVentaContext.usuarioId;

                oContext = new ERPProdEntities();
                oContext.cat_sucursales_departamentos.Add(row);
                oContext.SaveChanges();

                LoadGrid();
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

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSucursalesDepartamentos_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }

        private void LoadCombo()
        {
            try
            {
                uiSucursal.Properties.DataSource = oContext
                    .cat_sucursales.ToList();
                uiDepartamento.Properties.DataSource = oContext
                    .cat_departamentos.ToList();
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
                oContext = new ERPProdEntities();   
                int sucursalId = Convert.ToInt32(uiSucursal.EditValue);
                uiGrid.DataSource = oContext
                    .cat_sucursales_departamentos.Where(w=> w.SucursalId == sucursalId).ToList();
               
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

        private void frmSucursalesDepartamentos_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void repBtnDel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (uiGridView.FocusedRowHandle >= 0)
                {
                    oContext = new ConexionBD.ERPProdEntities();

                    row = (cat_sucursales_departamentos)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                    row = oContext.cat_sucursales_departamentos
                        .Where(w => w.SucursalId == row.SucursalId
                        && w.DepartamentoId == row.DepartamentoId
                        ).FirstOrDefault();

                    oContext.cat_sucursales_departamentos.Remove(row);
                    oContext.SaveChanges();

                    LoadGrid();
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

        private void uiSucursal_EditValueChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }
    }
}
