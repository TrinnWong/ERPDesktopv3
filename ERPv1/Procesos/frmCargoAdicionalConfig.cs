using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using ERP.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPv1.Procesos
{
    public partial class frmCargoAdicionalConfig : Form
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;

        private static frmCargoAdicionalConfig _instance;


        public static frmCargoAdicionalConfig GetInstance()
        {
            if (_instance == null) _instance = new frmCargoAdicionalConfig();
            else _instance.BringToFront();
            return _instance;
        }

        public frmCargoAdicionalConfig()
        {
            InitializeComponent();
        }

        public void llenarLkpSucursales()
        {
            try
            {
                uiSucursal.Properties.DataSource = oContext.cat_sucursales.ToList();
            }
            catch (Exception)
            {

               
            }
        }

        public void llenarLkpCargos()
        {
            try
            {
                repLkpCargosAdicionales.DataSource = oContext.cat_cargos_adicionales.ToList();
            }
            catch (Exception ex)
            {


            }
        }

        public void llenarGrid()
        {
            try
            {
                int sucursalId = uiSucursal.EditValue == null ? 0 : int.Parse(uiSucursal.EditValue.ToString());

                List<doc_cargo_adicional_config> lst = oContext.doc_cargo_adicional_config.Where(w=> w.SucursalId == sucursalId).ToList();
                uiGridCaptura.DataSource = new BindingList<doc_cargo_adicional_config>(lst);
            }
            catch (Exception)
            {

                
            }
        }

        private void frmCargoAdicionalConfig_Load(object sender, EventArgs e)
        {
            oContext = new ERPProdEntities();
            llenarLkpSucursales();
            llenarGrid();
            llenarLkpCargos();
        }

        private void uiSucursal_EditValueChanged(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void repEdit_Click(object sender, EventArgs e)
        {
            
        }

        private void frmCargoAdicionalConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiGridCaptura_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void uiGridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            doc_cargo_adicional_config entity = (doc_cargo_adicional_config)e.Row;

            if(entity==null)
            {
                e.Valid = false;
                e.ErrorText = "No fue posible obtener el registro";
            }
            else
            {
                //int id = (int)ERp.Business.Enumerados.CargoAdicional.EnvioUberEats;
                //int sucursalId = int.Parse(uiSucursal.EditValue.ToString());

                //doc_cargo_adicional_config entityUpd = oContext.doc_cargo_adicional_config
                //    .Where(w => w.CargoAdicionalId == id && w.SucursalId == sucursalId).FirstOrDefault();

                //if(entityUpd!= null)
                //{
                //    e.Valid = false;
                //    e.ErrorText = "Ya existe una configuración para este cargo/sucursal";
                //    return;
                //}

                if (Utils.isNull(entity.CargoAdicionalId) == 0 || (Utils.isNull(entity.MontoFijo) == 0 && Utils.isNull(entity.PorcentajeVenta) == 0 ))
                {
                    e.Valid = false;
                    e.ErrorText = "Es necesario capturar la información";
                    return;
                }
                if(uiSucursal.EditValue == null )
                {
                    e.Valid = false;
                    e.ErrorText = "Es necesario seleccionar una sucursal";
                    return;
                }

                if(entity.MontoFijo > 0 && entity.PorcentajeVenta> 0)
                {
                    e.Valid = false;
                    e.ErrorText = "El Monto fijo y el Porcentaje de venta no pueden ser mayor a cero al mismo tiempo";
                    return;
                }
                if(entity.PorcentajeVenta > 100)
                {
                    e.Valid = false;
                    e.ErrorText = "El porcentaje de venta no puede ser mayor a cero";
                    return;
                }
            }

        }

        private void uiGridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                doc_cargo_adicional_config entity = (doc_cargo_adicional_config)e.Row;

                int cargoAdicionalId = entity.CargoAdicionalId;
                int sucursalId = int.Parse(uiSucursal.EditValue.ToString());

                if (oContext.doc_cargo_adicional_config.Where(w=> w.CargoAdicionalId == cargoAdicionalId &&
                w.SucursalId == sucursalId).Count() == 0)
                {
                    entity.SucursalId = int.Parse(uiSucursal.EditValue.ToString());
                    entity.CargoAdicionalId = entity.CargoAdicionalId;
                    entity.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value.ToShortDateString();
                    entity.Activo = true;
                    oContext.doc_cargo_adicional_config.Add(entity);

                    oContext.SaveChanges();
                }
                else
                {
                    int id = (int)ERP.Business.Enumerados.CargoAdicional.EnvioUberEats;
                  

                    doc_cargo_adicional_config entityUpd = oContext.doc_cargo_adicional_config
                        .Where(w => w.CargoAdicionalId == id && w.SucursalId==sucursalId).FirstOrDefault();

                    entity.CargoAdicionalId = entity.CargoAdicionalId;
                    entity.SucursalId = int.Parse(uiSucursal.EditValue.ToString());
                    entityUpd.MontoFijo = entity.MontoFijo;
                    entityUpd.PorcentajeVenta = entity.PorcentajeVenta;

                    oContext.SaveChanges();
                }
                llenarGrid();

                XtraMessageBox.Show("Los cambios se guardaron correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error al guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }


        }

        private void repEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            uiGridView.ShowEditForm();
        }
    }
}
