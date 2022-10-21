using ConexionBD;
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
using System.IO.Ports;
namespace ERP.Common.Basculas
{
    public partial class BasculaConfiguracion : FormBaseXtraForm
    {
        private static BasculaConfiguracion _instance;
        cat_basculas_configuracion entity;
        public static BasculaConfiguracion GetInstance()
        {

            if (_instance == null) _instance = new BasculaConfiguracion();
            else _instance.BringToFront();
            return _instance;
        }
        public BasculaConfiguracion()
        {
            InitializeComponent();
            
        }

        private void BasculaConfiguracion_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void BasculaConfiguracion_Load(object sender, EventArgs e)
        {
            try
            {
                oContext = new ERPProdEntities();
                LoadComboBasculas();
                LoadPuertos();
                entity = ERP.Business.BasculasBusiness.GetConfiguracionPCLocal(puntoVentaContext.usuarioId,this.puntoVentaContext.sucursalId);

                if(entity != null)
                {
                    uiBascula1.EditValue = entity.BasculaId;
                    uiBaudRate.EditValue = entity.BaudRate;
                    uiPCName.Text = entity.cat_equipos_computo.PCName;
                    uiPortName.Text = entity.PortName;
                    uiReadBufferSize.EditValue = entity.ReadBufferSize;
                    uiWriteBufferSize.EditValue = entity.WriteBufferSize;
                    uiPesoDefault.EditValue = entity.PesoDefault;
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);

                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                cat_basculas_configuracion entity = new cat_basculas_configuracion();
                entity.BasculaId = Convert.ToInt32(uiBascula1.EditValue);
                entity.BaudRate = Convert.ToInt32(uiBaudRate.EditValue);
                entity.PortName = uiPortName.Text;
                entity.ReadBufferSize = Convert.ToInt32(uiReadBufferSize.EditValue);
                entity.WriteBufferSize = Convert.ToInt32(uiWriteBufferSize.EditValue);
                entity.PesoDefault = Convert.ToDecimal( uiPesoDefault.EditValue);
                entity.SucursalId = puntoVentaContext.sucursalId;
                ResultAPIModel result = BasculasBusiness.InsertUpdateLocalConfig(entity, puntoVentaContext.usuarioId);

                if (!result.ok)
                {
                    ERP.Utils.MessageBoxUtil.ShowError(result.error);
                }
                else
                {
                    ERP.Utils.MessageBoxUtil.ShowOk();
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                     "ERP",
                                     this.Name,
                                     ex);

                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void LoadComboBasculas()
        {
            try
            {
                int sucursalId = puntoVentaContext.sucursalId;
                uiBascula1.Properties.DataSource = oContext.cat_basculas
                    .Where(w => w.SucursalAsignadaId == sucursalId && w.Activo).ToList();

                
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                   "ERP",
                                   this.Name,
                                   ex);

                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void LoadPuertos()
        {
            try
            {
                string[] ports = SerialPort.GetPortNames();

                foreach (var item in ports)
                {
                    uiPortName.Properties.Items.Add(item);
                }

            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
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
    }
}
