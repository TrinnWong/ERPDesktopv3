using ConexionBD;
using ConexionBD.Models;
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

namespace ERP.Common.Traspasos
{
    public partial class frmTraspasosSalidaExpressUpd : Form
    {
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        List<cat_productos> lstProductos;
        private static frmTraspasosSalidaExpressUpd _instance;
        public static frmTraspasosSalidaExpressUpd GetInstance()
        {
            if (_instance == null) _instance = new frmTraspasosSalidaExpressUpd();
            else _instance.BringToFront();
            return _instance;
        }

        public frmTraspasosSalidaExpressUpd()
        {

        }

        private void frmTraspasosSalidaExpressUpd_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            _instance = null;
        }

        #region Funcionalidad

        private void LlenarBotones()
        {
            try
            {
                int i = 1;
                foreach (var item in lstProductos.OrderBy(o=> o.Descripcion))
                {
                    Control controlA = Controls.Find("uiProducto" + i.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        controlA.AccessibleName = item.ProductoId.ToString();
                        controlA.Text = item.DescripcionCorta;
                    }
                    i++;
                }

                /****Habilitar todos los botones****/
                for (int j = 1; j <= 8; j++)
                {
                    Control controlA = Controls.Find("uiProducto" + j.ToString(), true).FirstOrDefault();
                    if (controlA != null)
                    {
                        controlA.Enabled = true;
                    }
                }


               

                /*Deshabilitar botones sin productos*/
                if ((lstProductos.Count + 1) <= 8)
                {
                    for (int j = (lstProductos.Count + 1); j <= 8; j++)
                    {
                        Control controlA = Controls.Find("uiProducto" + j.ToString(), true).FirstOrDefault();
                        if (controlA != null)
                        {
                            controlA.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(
                    puntoVentaContext.usuarioId,
                           "ERP",
                           this.Name,
                           ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }


        public void LoadDestinos()
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();

                int sucursalOrigenId = this.puntoVentaContext.sucursalId;

                uiDestino1.Properties.DataSource = oContext
                    .cat_sucursales
                    .Where(w => w.Estatus == true &&
                    w.Clave != sucursalOrigenId).ToList();
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
        #endregion

        private void frmTraspasosSalidaExpressUpd_Load(object sender, EventArgs e)
        {
            try
            {
                oContext = new ERPProdEntities();
                lstProductos = oContext
                    .cat_productos
                    .Where(w => w.Estatus == true)
                    .ToList();
                LoadDestinos();
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
