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
    public partial class frmPreferenciaEmpresaUpd : FormBaseXtraForm
    {
        int sucursalId;
        int err = 0;
        int preferenciaId = 0;
        
        sis_preferencias_empresa oRegistro;
        private static frmPreferenciaEmpresaUpd _instance;
        public static frmPreferenciaEmpresaUpd GetInstance()
        {
            if (_instance == null) _instance = new frmPreferenciaEmpresaUpd();
            else _instance.BringToFront();
            return _instance;
        }
        public frmPreferenciaEmpresaUpd()
        {
            InitializeComponent();
        }

        private void LoadSucursales()
        {
            try
            {
                uiEmpresa.Properties.DataSource = oContext.cat_empresas.ToList();

               
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    "frmPreferenciaEmpresaUpd.LoadSucursales",
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
                                     "frmPreferenciaEmpresaUpd.LoadPreferencias",
                                     ex);

                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }
        private void LoadGrid()
        {
            try
            {
                sucursalId = Convert.ToInt32(uiEmpresa.EditValue);
                oContext = new ConexionBD.ERPProdEntities();
                uiGrid.DataSource = oContext.sis_preferencias_empresa
                    .Where(w=> w.EmpresaId == sucursalId)
                    .ToList();
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    "frmPreferenciaEmpresaUpd.LoadGrid",
                                    ex);

                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void frmPreferenciaSucursalUpd_Load(object sender, EventArgs e)
        {
            oContext = new ConexionBD.ERPProdEntities();
            oRegistro = new sis_preferencias_empresa();
            LoadSucursales();
            LoadPreferencias();
            LoadGrid();
        }

        private void repBtnEliminar_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                sis_preferencias_empresa oRow = (sis_preferencias_empresa)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                if(oRow!= null)
                {
                    if(XtraMessageBox.Show("¿Está seguro(a) de eliminar este registro?","Aviso",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question)== DialogResult.Yes)
                    {
                        sis_preferencias_empresa oRowDelete = oContext.sis_preferencias_empresa
                            .Where(w => w.Id == oRow.Id).FirstOrDefault();

                        oContext.sis_preferencias_empresa.Remove(oRowDelete);
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
                sucursalId = Convert.ToInt32(uiEmpresa.EditValue);
                preferenciaId = Convert.ToInt32(uiPreferencia.EditValue);

                oContext = new ERPProdEntities();
                if(uiEmpresa.EditValue == null || uiPreferencia.EditValue == null)
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("La sucursal y la preferencia es requerida");
                    return;
                }
                sis_preferencias_empresa oEntityUpd;
                if (oRegistro.Id == 0)
                {
                    if(oContext.sis_preferencias_empresa.Where(w=> w.EmpresaId == sucursalId
                    && w.PreferenciaId == preferenciaId).Count() > 0)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("Ya existe un registro para la preferencia y sucursal. Busque la preferencia en el listado y seleccione EDITAR");
                        return;
                    }
                    oEntityUpd = new sis_preferencias_empresa() { CreadoEl = DateTime.Now };

                    oEntityUpd.Id = (oContext.sis_preferencias_sucursales
                        .Max(m => (int?)m.Id) ?? 0) + 1;
                    oEntityUpd.PreferenciaId = Convert.ToInt32(uiPreferencia.EditValue);
                    oEntityUpd.EmpresaId = Convert.ToInt32(uiEmpresa.EditValue);
                    oEntityUpd.Valor = uiValor.Text;
                    oEntityUpd.CreadoEl = DateTime.Now;
                    oContext.sis_preferencias_empresa.Add(oEntityUpd);
                    oContext.SaveChanges();
                }
                else
                {
                    oEntityUpd = oContext
                        .sis_preferencias_empresa
                        .Where(w => w.Id == oRegistro.Id).FirstOrDefault();

                    oEntityUpd.PreferenciaId = Convert.ToInt32(uiPreferencia.EditValue);
                    oEntityUpd.EmpresaId = Convert.ToInt32(uiEmpresa.EditValue);
                    oEntityUpd.Valor = uiValor.Text;
                    oContext.SaveChanges();
                }

                Limpiar();
                uiEmpresa.EditValue = oEntityUpd.EmpresaId;
                LoadGrid();
                

            }
            catch (Exception ex)
            {
                Limpiar();
                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    "frmPreferenciaEmpresalUpd.repBtnEliminar_ButtonClick",
                                    ex);

                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void repBtnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                oRegistro = (sis_preferencias_empresa)uiGridView.GetRow(uiGridView.FocusedRowHandle);

                if (oRegistro != null)
                {
                    uiEmpresa.EditValue = oRegistro.EmpresaId;
                    uiPreferencia.EditValue = oRegistro.PreferenciaId;
                    uiValor.Text = oRegistro.Valor;
                }
                else
                {
                    oRegistro = new sis_preferencias_empresa();
                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP",
                                    "frmPreferenciaEmpresaUpd.repBtnEliminar_ButtonClick",
                                    ex);

                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void Limpiar()
        {
            uiEmpresa.EditValue = puntoVentaContext.sucursalId;
            uiPreferencia.EditValue = null;
            uiValor.Text = "";
            oRegistro = new sis_preferencias_empresa();
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

        private void uiEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }
    }
}
