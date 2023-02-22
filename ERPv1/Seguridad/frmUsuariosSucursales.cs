using ConexionBD;
using DevExpress.XtraEditors;
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

namespace ERPv1.Seguridad
{
    public partial class frmUsuariosSucursales : FormBaseXtraForm
    {
        int err = 0;
        int usuarioId = 0;
        int sucursalId = 0;
        private static frmUsuariosSucursales _instance;
        public static frmUsuariosSucursales GetInstance()
        {
            if (_instance == null) _instance = new frmUsuariosSucursales();
            else _instance.BringToFront();
            return _instance;
        }
        public frmUsuariosSucursales()
        {
            InitializeComponent();
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void LoadUsuarios()
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();

                uiUsuario.Properties.DataSource = oContext.cat_usuarios.ToList();
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

        private void LoadSucursales()
        {
            try
            {
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

        private void LoadGrid()
        {
            try
            {
                usuarioId = Convert.ToInt32(uiUsuario.EditValue);

                uiGrid.DataSource = oContext.cat_usuarios_sucursales
                    .Where(w=> w.UsuarioId == usuarioId)
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

        private void frmUsuariosSucursales_Load(object sender, EventArgs e)
        {
            try
            {
                LoadUsuarios();
                LoadSucursales();
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

        private void uiGrid_Click(object sender, EventArgs e)
        {

        }

        private void Guardar()
        {
            try
            {
                var sucursales = uiSucursal.Properties.View.GetSelectedRows();
                List<cat_usuarios_sucursales> lstGrid = (List<cat_usuarios_sucursales>)uiGrid.DataSource;
                usuarioId = Convert.ToInt32(uiUsuario.EditValue);

                if(usuarioId > 0 && sucursales.Count() > 0)
                {
                    foreach (int itemSucursal in sucursales)
                    {
                        sucursalId = ((cat_sucursales)uiSucursal.Properties.View.GetRow(itemSucursal)).Clave;

                        if (lstGrid.Where(w => w.UsuarioId == usuarioId && w.SucursalId == sucursalId).Count() == 0)
                        {
                            cat_usuarios_sucursales entityNew = new cat_usuarios_sucursales();

                            entityNew.CreadoEl = DateTime.Now;
                            entityNew.SucursalId = sucursalId;
                            entityNew.UsuarioId = usuarioId;

                            oContext.cat_usuarios_sucursales.Add(entityNew);
                            oContext.SaveChanges();

                            LoadGrid();

                            uiSucursal.Properties.View.ClearSelection();
                        }
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

        private void repBtnDel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(uiGridView.FocusedRowHandle >= 0)
                {
                    if(XtraMessageBox.Show("¿Está seguro(a) de eliminar la sucursal?","Aviso", MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        cat_usuarios_sucursales row = (cat_usuarios_sucursales)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                        if (row != null)
                        {
                            cat_usuarios_sucursales entityDel = oContext.cat_usuarios_sucursales
                                .Where(w => w.UsuarioId == row.UsuarioId && w.SucursalId == row.SucursalId).FirstOrDefault();

                            oContext.cat_usuarios_sucursales.Remove(entityDel);
                            oContext.SaveChanges();
                            LoadGrid();
                            ERP.Utils.MessageBoxUtil.ShowOk();
                        }
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

        private void uiUsuario_EditValueChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void frmUsuariosSucursales_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }
    }
}
