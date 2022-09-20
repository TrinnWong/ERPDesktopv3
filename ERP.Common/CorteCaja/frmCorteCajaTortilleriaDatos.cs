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

namespace ERP.Common.CorteCaja
{
    public partial class frmCorteCajaTortilleriaDatos : FormBaseXtraForm
    {
        int err=0;
        doc_corte_caja_datos_entrada oRegistro ;
        private static frmCorteCajaTortilleriaDatos _instance;
        private int dia;
        private int mes;
        private int anio;

        public static frmCorteCajaTortilleriaDatos GetInstance()
        {
            if (_instance == null) _instance = new frmCorteCajaTortilleriaDatos();
            else _instance.BringToFront();
            return _instance;
        }

        public frmCorteCajaTortilleriaDatos()
        {
            InitializeComponent();
        }

        private void frmCorteCajaTortilleriaDatos_Load(object sender, EventArgs e)
        {
            uiFecha.EditValue = DateTime.Now;
            oRegistro = new doc_corte_caja_datos_entrada();

            loadGrid();
        }

        private void frmCorteCajaTortilleriaDatos_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        public void loadGrid()
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities();

                uiGrid.DataSource = oContext.doc_corte_caja_datos_entrada
                    .Where(w=> w.SucursalId == puntoVentaContext.sucursalId)
                    .OrderByDescending(o=> o.CreadoEl).ToList();


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

        public void Limpiar()
        {
            uiTiradasTortilla.EditValue = 0;
            uiMasaKg.EditValue = 0;
            uiFecha.DateTime = DateTime.Now;
            oRegistro = new doc_corte_caja_datos_entrada();
        }

        private void uiLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void uiGrid_Click(object sender, EventArgs e)
        {

        }

        public void Guardar()
        {
            try
            {
                string valor = "";

                //Obtener Equivalencia Tirada Tortilla
                ERP.Business.PreferenciaBusiness.AplicaPreferencia(this.puntoVentaContext.empresaId,
                    this.puntoVentaContext.sucursalId, "EquivalenciaTiradaMasaTortillaKg",
                    this.puntoVentaContext.usuarioId, ref valor);

                oContext = new ConexionBD.ERPProdEntities();
                doc_corte_caja_datos_entrada oEntityUpd;
                

                if((valor==null ? "" : valor).Length  > 0)
                {
                    decimal TortillasKgPorTirada = Convert.ToDecimal(valor);

                    dia = uiFecha.DateTime.Day;
                    mes = uiFecha.DateTime.Month;
                    anio = uiFecha.DateTime.Year;

                    if(oContext.doc_corte_caja_datos_entrada
                        .Where(
                            w=> w.SucursalId == puntoVentaContext.sucursalId &&
                            w.CreadoEl.Day == dia &&
                            w.CreadoEl.Month == mes &&
                            w.CreadoEl.Year == anio &&
                            w.Id != oRegistro.Id
                        ).Count() > 0)
                    {
                        ERP.Utils.MessageBoxUtil.ShowWarning("Ya existe un registro para el día seleccionado");
                        return;
                    }

                    if (oRegistro.Id == 0)
                    {
                        oEntityUpd = new doc_corte_caja_datos_entrada();



                        oEntityUpd.CreadoEl = uiFecha.DateTime;
                        oEntityUpd.CreadoPor = puntoVentaContext.usuarioId;
                        oEntityUpd.SucursalId = puntoVentaContext.sucursalId;
                        oEntityUpd.MasaKg = uiMasaKg.Value;
                        oEntityUpd.TiradaTortilla = uiTiradasTortilla.Value;
                        oEntityUpd.TiradaTortillaKg = TortillasKgPorTirada * oEntityUpd.TiradaTortilla;

                        oContext.doc_corte_caja_datos_entrada.Add(oEntityUpd);
                        oContext.SaveChanges();
                    }
                    else
                    {
                        oEntityUpd = oContext.doc_corte_caja_datos_entrada
                             .Where(w => w.Id == oRegistro.Id).FirstOrDefault();

                        oEntityUpd.CreadoEl = uiFecha.DateTime;
                        oEntityUpd.CreadoPor = puntoVentaContext.usuarioId;
                        oEntityUpd.SucursalId = puntoVentaContext.sucursalId;
                        oEntityUpd.MasaKg = uiMasaKg.Value;
                        oEntityUpd.TiradaTortilla = uiTiradasTortilla.Value;
                        oEntityUpd.TiradaTortillaKg = TortillasKgPorTirada * oEntityUpd.TiradaTortilla;

                        oContext.SaveChanges();
                    }

                    Limpiar();
                    loadGrid();


                }
                else
                {
                    ERP.Utils.MessageBoxUtil.ShowError("No existe preferencia de equivalencia de Tirada");
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

        private void repBtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if(uiGridView.FocusedRowHandle >= 0)
                {
                    doc_corte_caja_datos_entrada oRowView = (doc_corte_caja_datos_entrada)uiGridView.GetFocusedRow();

                    if(oRowView.Id  > 0)
                    {
                        uiTiradasTortilla.EditValue = oRowView.TiradaTortilla;
                        uiFecha.EditValue = oRowView.CreadoEl;
                        uiMasaKg.EditValue = oRowView.MasaKg;
                        oRegistro = oRowView;
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

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
    }
}
