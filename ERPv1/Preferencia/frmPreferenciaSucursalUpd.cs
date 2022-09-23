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

namespace ERPv1.Preferencia
{
    public partial class frmPreferenciaSucursalUpd : FormBaseXtraForm
    {
        int sucursalId;
        int err = 0;
        
        sis_preferencias_sucursales oRegistro;
        private static frmPreferenciaSucursalUpd _instance;
        public static frmPreferenciaSucursalUpd GetInstance()
        {
            if (_instance == null) _instance = new frmPreferenciaSucursalUpd();
            else _instance.BringToFront();
            return _instance;
        }
        public frmPreferenciaSucursalUpd()
        {
            InitializeComponent();
        }

        private void LoadSucursales()
        {
            try
            {
                uiSucursal.Properties.DataSource = ERP.Business.SucursalBusiness.ObtenSucursalesPorUsuario(this.puntoVentaContext.empresaId,
                    this.puntoVentaContext.usuarioId);

               
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    "frmPreferenciaSucursalUpd.LoadSucursales",
                                    ex);

                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void LoadPreferencias()
        {
            try
            {
                uiPreferencia.Properties.DataSource = oContext.sis_preferencias.ToList();
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                     "ERP",
                                     "frmPreferenciaSucursalUpd.LoadPreferencias",
                                     ex);

                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }
        private void LoadGrid()
        {
            try
            {
                sucursalId = Convert.ToInt32(uiSucursal.EditValue);
                oContext = new ConexionBD.ERPProdEntities();
                uiGrid.DataSource = oContext.sis_preferencias_sucursales
                    .Where(w=> w.cat_sucursales.Empresa == puntoVentaContext.empresaId && w.SucursalId == sucursalId)
                    .ToList();
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    "frmPreferenciaSucursalUpd.LoadGrid",
                                    ex);

                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void frmPreferenciaSucursalUpd_Load(object sender, EventArgs e)
        {
            oContext = new ConexionBD.ERPProdEntities();
            oRegistro = new sis_preferencias_sucursales();
           LoadSucursales();
            LoadPreferencias();
            LoadGrid();
        }

        private void repBtnEliminar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                sis_preferencias_sucursales oRow = (sis_preferencias_sucursales)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                if(oRow!= null)
                {
                    if(XtraMessageBox.Show("¿Está seguro(a) de eliminar este registro?","Aviso",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question)== DialogResult.Yes)
                    {
                        sis_preferencias_sucursales oRowDelete = oContext.sis_preferencias_sucursales
                            .Where(w => w.Id == oRow.Id).FirstOrDefault();

                        oContext.sis_preferencias_sucursales.Remove(oRowDelete);
                        oContext.SaveChanges();

                        LoadGrid();
                    }
                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    "frmPreferenciaSucursalUpd.repBtnEliminar_ButtonClick",
                                    ex);

                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void Guardar()
        {
            try
            {
                oContext = new ERPProdEntities();
                if(uiSucursal.EditValue == null || uiPreferencia.EditValue == null)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("La sucursal y la preferencia es requerida");
                    return;
                }
                sis_preferencias_sucursales oEntityUpd;
                if (oRegistro.Id == 0)
                {
                    oEntityUpd = new sis_preferencias_sucursales() { CreadoEl = DateTime.Now };

                    oEntityUpd.Id = (oContext.sis_preferencias_sucursales
                        .Max(m => (int?)m.Id) ?? 0) + 1;
                    oEntityUpd.PreferenciaId = Convert.ToInt32(uiPreferencia.EditValue);
                    oEntityUpd.SucursalId = Convert.ToInt32(uiSucursal.EditValue);
                    oEntityUpd.Valor = uiValor.Text;
                    oEntityUpd.CreadoEl = DateTime.Now;
                    oContext.sis_preferencias_sucursales.Add(oEntityUpd);
                    oContext.SaveChanges();
                }
                else
                {
                    oEntityUpd = oContext
                        .sis_preferencias_sucursales
                        .Where(w => w.Id == oRegistro.Id).FirstOrDefault();

                    oEntityUpd.PreferenciaId = Convert.ToInt32(uiPreferencia.EditValue);
                    oEntityUpd.SucursalId = Convert.ToInt32(uiSucursal.EditValue);
                    oEntityUpd.Valor = uiValor.Text;
                    oContext.SaveChanges();
                }

                Limpiar();
                uiSucursal.EditValue = oEntityUpd.SucursalId;
                LoadGrid();
                

            }
            catch (Exception ex)
            {
                Limpiar();
                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    "frmPreferenciaSucursalUpd.repBtnEliminar_ButtonClick",
                                    ex);

                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void repBtnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                oRegistro = (sis_preferencias_sucursales)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                if (oRegistro != null)
                {
                    uiSucursal.EditValue = oRegistro.SucursalId;
                    uiPreferencia.EditValue = oRegistro.PreferenciaId;
                    uiValor.Text = oRegistro.Valor;
                }
                else
                {
                    oRegistro = new sis_preferencias_sucursales();
                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    "frmPreferenciaSucursalUpd.repBtnEliminar_ButtonClick",
                                    ex);

                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void Limpiar()
        {
            uiSucursal.EditValue = puntoVentaContext.sucursalId;
            uiPreferencia.EditValue = null;
            uiValor.Text = "";
            oRegistro = new sis_preferencias_sucursales();
        }

        private void uiLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void uiPreferencia_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                sis_preferencias oPreferencia = (sis_preferencias)uiPreferencia.GetSelectedDataRow();

                if(oPreferencia != null)
                {
                    lblDescripcion.Text = oPreferencia.Descripcion;
                }
                else
                {
                    lblDescripcion.Text = "";
                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    "frmPreferenciaSucursalUpd.repBtnEliminar_ButtonClick",
                                    ex);

                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void uiSucursal_EditValueChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void frmPreferenciaSucursalUpd_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }
    }
}
