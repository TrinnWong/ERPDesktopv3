using ConexionBD;
using DevExpress.XtraEditors;
using ERP.Business.Tools;
using ERP.Common.Base;
using ERP.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Productos
{
    public partial class frmSobrantesRegistro : FormBaseXtraForm
    {
        public DateTime? dtProcess { get; set; }
        List<p_productos_sobrantes_grd_Result> lstGrid;
        doc_productos_sobrantes_registro productoSobrante;
        public bool habilitarFecha = false;
        int err = 0;
        public frmSobrantesRegistro()
        {
            InitializeComponent();
        }

        private void uiSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void guardar()
        {
            try
            {
                
                uiGuardar.Text = "ESPERE......";
                
                Thread.Sleep(2000);
                lstGrid = (List<p_productos_sobrantes_grd_Result>)uiGrid.DataSource;
                oContext = new ERPProdEntities();

                oContext.Database.ExecuteSqlCommand(@"DELETE doc_productos_sobrantes_registro 
                                                    WHERE CONVERT(VARCHAR,CreadoEl,112)=CONVERT(VARCHAR,{0},112) AND 
                                                        SucursalId={1}", uiFecha.DateTime, puntoVentaContext.sucursalId);

                foreach (p_productos_sobrantes_grd_Result itemGrid in lstGrid)
                {
                    productoSobrante = new doc_productos_sobrantes_registro();

                    productoSobrante.CantidadSobrante = Convert.ToDouble(itemGrid.CantidadSobrante);
                    productoSobrante.CreadoEl = uiFecha.DateTime;
                    productoSobrante.CreadoPor = puntoVentaContext.usuarioId;
                    productoSobrante.Id = (oContext.doc_productos_sobrantes_registro.Max(m => (int?)m.Id) ?? 0) + 1;
                    productoSobrante.ProductoId = itemGrid.ProductoId;
                    productoSobrante.SucursalId = puntoVentaContext.sucursalId;

                    oContext.doc_productos_sobrantes_registro.Add(productoSobrante);
                    oContext.SaveChanges();

                }

                llenarGrid();

                ERP.Utils.MessageBoxUtil.ShowOk();

                uiGuardar.Text = "GUARDAR";

               

            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }
        private void llenarGrid()
        {
            oContext = new ERPProdEntities();
            uiGrid.DataSource = oContext.p_productos_sobrantes_grd(puntoVentaContext.sucursalId, uiFecha.DateTime).ToList();

        }

        private void frmSobrantesRegistro_Load(object sender, EventArgs e)
        {
            try
            {
                oContext = new ERPProdEntities();
                if(dtProcess == null)
                {
                    dtProcess = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                }
                uiFecha.Enabled = habilitarFecha;
                uiFecha.DateTime = dtProcess?? DateTime.MinValue    ;
                
                llenarGrid();
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
           
        }

        private void uiTerminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("¿Está seguro(a) de continuar?, YA NO SERÁ POSIBLE REALIZAR CAMBIOS Y SE ACTUALIZARÁ EL INVENTARIO DE ACUERDO A LO CAPTURADO.EL PROCESO PUEDE TARDAR ALGUNOS MINUTOS.....",
                "Aviso",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oContext = new ERPProdEntities();

                    guardar();

                    ObjectParameter pError = new ObjectParameter("pError", "");
                    oContext.p_doc_sobrantes_ajustes_inventario(this.puntoVentaContext.sucursalId,
                        uiFecha.DateTime, puntoVentaContext.usuarioId, pError);

                    if (pError.Value.ToString().Length > 0)
                    {
                        ERP.Utils.MessageBoxUtil.ShowError(pError.Value.ToString());
                    }
                    else
                    {
                        ERP.Utils.MessageBoxUtil.ShowOk();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(puntoVentaContext.usuarioId,
                                    "ERP",
                                    this.Name,
                                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
            
        }
    }
}
