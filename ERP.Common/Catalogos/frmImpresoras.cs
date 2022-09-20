using ConexionBD;
using ConexionBD.Models;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Catalogos
{
    public partial class frmImpresoras : Form
    {
        public PuntoVentaContext puntoVentaContext;
        ERPProdEntities oContext;
        ImpresorasBusiness oImpresora;

        private static frmImpresoras _instance;

        public static frmImpresoras GetInstance()
        {

            if (_instance == null) _instance = new frmImpresoras();
            else _instance.BringToFront();
            return _instance;
        }


        public frmImpresoras()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
            oImpresora = new ImpresorasBusiness();
        }

        public void llenarGrid()
        {
            try
            {
                uiGrid.DataSource = new BindingList<cat_impresoras>(oContext.cat_impresoras.Where(w=>w.SucursalId == puntoVentaContext.sucursalId).ToList());
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Ocurrió un error al obtener la información", "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
           
        }

        public void llenarCmbSucursal()
        {
            try
            {
                repLkpSucursal.DataSource = 
               oContext.cat_sucursales.ToList();
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Ocurrió un error al obtener la información", "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void frmImpresoras_Load(object sender, EventArgs e)
        {
           

            llenarCmbSucursal();
            PopulateInstalledPrintersCombo();
            llenarGrid();
        }

        private void uiGridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            cat_impresoras item = (cat_impresoras)e.Row;
            string error = "";

            item.SucursalId = (short)this.puntoVentaContext.sucursalId;

            if( (item.NombreImpresora==null ? "" : item.NombreImpresora).Trim() =="")
            {
                error = error + ".La impresora es requerida";
            }
            //if (item.SucursalId== 0)
            //{
            //    error = error + ".La sucursal es requerida";
            //}
            if ((item.NombreRed == null ? "" : item.NombreRed).Trim() == "")
            {
                error = error + ".La impresora es requerida";
            }

            if(error.Length > 0)
            {
                e.Valid = false;
                e.ErrorText = error;
                return;
            }

            if (item.ImpresoraId > 0)
            {
                error = oImpresora.Actualizar(item, this.puntoVentaContext);

               
            }
            else
            {
               
                error = oImpresora.Insertar(ref item, this.puntoVentaContext);

                uiGridView.SetRowCellValue(e.RowHandle,"ImpresoraId",item.ImpresoraId);

            }

            if (error.Length > 0)
            {
                e.Valid = false;
                e.ErrorText = error;

            }
            else
            {
                XtraMessageBox.Show("El proceso terminó con éxito", "AVISO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void frmImpresoras_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiGridView_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            cat_impresoras item = (cat_impresoras)e.Row;

            string error = oImpresora.Eliminar(item,this.puntoVentaContext);

            if (error.Length > 0)
            {
                XtraMessageBox.Show(error, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void PopulateInstalledPrintersCombo()
        {
            // Add list of installed printers found to the combo box.
            // The pkInstalledPrinters string will be used to provide the display string.
            String pkInstalledPrinters;
            List<impresora> lstImpresoras = new List<impresora>();

            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                impresora item = new impresora();
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                item.Nombre = pkInstalledPrinters;
                item.Clave = pkInstalledPrinters;
                lstImpresoras.Add(item);
                //comboInstalledPrinters.Items.Add(pkInstalledPrinters);
            }
            repLkpImpresora.DataSource = lstImpresoras;
            
        }

        private void uiGridView_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //if(this.puntoVentaContext != null)
            //{
            //    if(puntoVentaContext.sucursalId > 0)
            //    {
            //        uiGridView.SetRowCellValue(e.RowHandle, colSucursalId, puntoVentaContext.sucursalId);

            //    }
            //}
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {

        }
    }

    public class impresora
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
    }
}
