using ConexionBD;
using ConexionBD.Models;
using ERP.Business;
using ERP.Common.Base;
using ERP.Models;
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
    public partial class frmBasculaUpd : FormBaseXtraForm
    {
        public PuntoVentaContext puntoVentaContext;
        public int idForm { get; set; }
        private static frmBasculaUpd _instance;
        private BasculasBusiness oBasculas;

        public static frmBasculaUpd GetInstance()
        {

            if (_instance == null) _instance = new frmBasculaUpd();
            else _instance.BringToFront();
            return _instance;
        }
        public frmBasculaUpd()
        {
            InitializeComponent();
            
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ResultAPIModel result;
                cat_basculas entity = new cat_basculas();

                entity.BasculaId = idForm;
                entity.Activo = uiActivo.Checked;
                entity.Alias = uiAlias.Text.Trim();
                entity.Marca = uiMarca.Text.Trim();
                entity.Modelo = uiModelo.Text.Trim();
                entity.Serie = uiSerie.Text.Trim();
                entity.EmpresaId = puntoVentaContext.empresaId;
                entity.SucursalAsignadaId = Convert.ToInt32(uiSucursal.EditValue);

                if(idForm == 0)
                {
                    result = oBasculas.Insert(ref entity, puntoVentaContext.usuarioId);
                }
                else
                {
                    result = oBasculas.Update(entity, puntoVentaContext.usuarioId);
                }                

                if (!result.ok) {
                    ERP.Utils.MessageBoxUtil.ShowError(result.error);
                }
                else
                {
                    idForm = entity.BasculaId;
                    frmBasculaList.GetInstance().LoadGrid();
                    ERP.Utils.MessageBoxUtil.ShowOk();
                    this.Close();
                   
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

        private void frmBasculaUpd_Load(object sender, EventArgs e)
        {
            try
            {
                oBasculas = new BasculasBusiness(puntoVentaContext.sucursalId);
                LoadComboSucursales();
                if (idForm == 0)
                {
                    uiActivo.Checked = true;
                }
                else
                {
                    cat_basculas entityLoad = oContext.cat_basculas.Where(w => w.BasculaId == idForm).FirstOrDefault();

                    uiActivo.Checked = entityLoad.Activo;
                    uiAlias.Text = entityLoad.Alias;
                    uiID.EditValue = entityLoad.BasculaId;
                    uiMarca.Text = entityLoad.Marca;
                    uiModelo.Text = entityLoad.Modelo;
                    uiSerie.Text = entityLoad.Serie;
                    uiSucursal.EditValue = entityLoad.SucursalAsignadaId;
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

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBasculaUpd_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void LoadComboSucursales()
        {
            try
            {
                oContext = new ERPProdEntities();
                uiSucursal.Properties.DataSource = oContext.cat_sucursales
                    .Where(w => w.Estatus == true && w.Empresa == puntoVentaContext.empresaId).ToList();
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
    }
}
