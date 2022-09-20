using ConexionBD;
using ConexionBD.Forms;
using ConexionBD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace ERPv1.Inventarios
{
    public partial class CargaInicialUpd : FormERP
    {
        List<CargaInicialModel> lstCargaInicial;

        private static CargaInicialUpd _instance;

        

        public static CargaInicialUpd GetInstance()
        {

            if (_instance == null) _instance = new CargaInicialUpd();
            else _instance.BringToFront();
            return _instance;
        }

        public CargaInicialUpd()
        {
            InitializeComponent();

           
        }

        private void LlenarCombos()
        {
            uiFamilia.DataSource = oContext.cat_familias.ToList();
            uiSubFamilia.DataSource = oContext.cat_subfamilias.ToList();
            uiSucursal.DataSource = oContext.cat_sucursales.ToList();
                
        }

        private void LlenarGrid()
        {
            

            int? familia = uiFamilia.SelectedValue == null ? 0 : int.Parse(uiFamilia.SelectedValue.ToString());
            int? subFamilia = uiSubFamilia.SelectedValue == null ? 0 : int.Parse(uiSubFamilia.SelectedValue.ToString());
            int? sucursal = uiSucursal.SelectedValue == null ? 0 : int.Parse(uiSucursal.SelectedValue.ToString());

            lstCargaInicial = oContext.p_inv_carga_inicial_grd(sucursal,familia, subFamilia,uiVerListado.Checked)
               
                .Select(
                    s => new CargaInicialModel()
                    {
                         clave = s.Clave,
                          costoPromedio = s.CostoPromedio,
                           descripcion = s.Descripcion,
                            InventarioFisico = s.InventarioFisico,
                             productoId = s.ProductoId,
                              ultimoCosto = s.UltimoCosto,
                              tieneCargaInicial = s.TieneCargaInicial ?? false ,
                              cargaInventarioId = s.CargaInventarioId ?? 0
                              
                    }
                ).ToList();

            uiGrid.AutoGenerateColumns = false;

            uiGrid.DataSource = lstCargaInicial;

            //BOTON AUTORIZAR
            if (lstCargaInicial.Where(w => w.tieneCargaInicial == false).Count() == 0)
            {
                uiAutorizar.Enabled = false;
            }
            else {
                uiAutorizar.Enabled = true;
            }
            //BOTON GUARDAR
            if (lstCargaInicial.Where(w => w.tieneCargaInicial == true).Count() == lstCargaInicial.Count())
            {
                uiGuardar.Enabled = false;
               
            }
            else {
                uiGuardar.Enabled = true;
                
            }
            //BOTON CANCELAR
            if (lstCargaInicial.Where(w => w.tieneCargaInicial == false && w.cargaInventarioId > 0).Count()>0)
            {
                uiCancelar.Enabled = true;

            }
            else
            {
                uiCancelar.Enabled = false;

            }
            //BOTON AFECTAR
            if (lstCargaInicial.Where(w => w.tieneCargaInicial == true && w.cargaInventarioId > 0).Count() > 0)
            {
                uiCancelarInv.Enabled = true;

            }
            else
            {
                uiCancelarInv.Enabled = false;

            }
        }

        private void guardar(bool afectar)
        {
            try
            {
                ObjectParameter pCargaInventarioId = new ObjectParameter("pCargaInventarioId", 0);
                int? sucursal = uiSucursal.SelectedValue == null ? 0 : int.Parse(uiSucursal.SelectedValue.ToString());
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (CargaInicialModel item in lstCargaInicial)
                    {
                        if (item.tieneCargaInicial == false)
                        {
                            if (item.cargaInventarioId == 0)
                            {
                                oContext.p_inv_carga_inicial_ins(pCargaInventarioId, sucursal, item.productoId, item.InventarioFisico, item.costoPromedio, item.ultimoCosto, 1);
                            }
                            else
                            {
                                oContext.p_inv_carga_inicial_upd(item.cargaInventarioId, sucursal, item.productoId, item.InventarioFisico, item.costoPromedio, item.ultimoCosto, 1);
                            }
                        }   
                        
                    }

                    scope.Complete();
                }

                LlenarGrid();

                if (afectar)
                {
                    autorizar();
                }
                else {
                    MessageBox.Show("EL PROCESO TERMINÓ CON EXITO", "ERROR");
                }
                
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void cancelar()
        {
            try
            {
                ObjectParameter pCargaInventarioId = new ObjectParameter("pCargaInventarioId", 0);
                int? sucursal = uiSucursal.SelectedValue == null ? 0 : int.Parse(uiSucursal.SelectedValue.ToString());
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (CargaInicialModel item in lstCargaInicial)
                    {
                        if (item.tieneCargaInicial == false && item.cargaInventarioId > 0)
                        {
                            oContext.p_inv_carga_inicial_cancel(item.cargaInventarioId);                           
                        }
                    }

                    scope.Complete();
                }

                LlenarGrid();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void cancelarInv()
        {
            try
            {
                ObjectParameter pCargaInventarioId = new ObjectParameter("pCargaInventarioId", 0);
                int? sucursal = uiSucursal.SelectedValue == null ? 0 : int.Parse(uiSucursal.SelectedValue.ToString());
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (CargaInicialModel item in lstCargaInicial)
                    {
                        if (item.tieneCargaInicial == true && item.cargaInventarioId > 0)
                        {
                            oContext.p_inv_carga_inicia_cancel_inv(item.cargaInventarioId);
                        }
                    }

                    scope.Complete();
                }

                LlenarGrid();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {

            guardar(false);
        }

        private void panelSup_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        #region eventos de la forma
        private void CargaInicialUpd_Load(object sender, EventArgs e)
        {
            this.puntoVentaContext = frmMenu.GetInstance().puntoVentaContext;
            LlenarCombos();

            uiSucursal.SelectedValue = puntoVentaContext.sucursalId;
            LlenarGrid();

           
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void CargaInicialUpd_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void uiGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                decimal cantidad = 0;
                decimal.TryParse(uiGrid.Rows[e.RowIndex].Cells["InventarioFisico"].Value.ToString(),out cantidad);

                decimal costoPromedio = 0;
                decimal.TryParse(uiGrid.Rows[e.RowIndex].Cells["CostoPromedio"].Value.ToString(),out costoPromedio);

                decimal ultCosto = 0;
                decimal.TryParse(uiGrid.Rows[e.RowIndex].Cells["UltCosto"].Value.ToString(),out ultCosto);

                int productoId = 0;

                int.TryParse(uiGrid.Rows[e.RowIndex].Cells["ProductoId"].Value.ToString(),out productoId);

                lstCargaInicial.Find(w => w.productoId == productoId).InventarioFisico =cantidad;
                lstCargaInicial.Find(w => w.productoId == productoId).costoPromedio = costoPromedio;
                lstCargaInicial.Find(w => w.productoId == productoId).ultimoCosto = ultCosto;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void uiGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                int productoId = 0;

                productoId = int.Parse(uiGrid.Rows[e.RowIndex].Cells["ProductoId"].Value.ToString());

                if (
                    lstCargaInicial.Where(
                        w => w.productoId == productoId &&
                        w.tieneCargaInicial == true
                        ).Count() > 0
                    )
                {
                    e.Cancel = true;
                }

                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de afectar el inventario?, ya no será posible realizar cambios", "AVISO", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                guardar(true);
            }
            
        }

        private void autorizar()
        {


     
            try
            {
                oContext = new ERPProdEntities();
                ObjectParameter pMovimientoID = new ObjectParameter("pMovimientoId", 0);               

                int sucursalOrigen = uiSucursal.SelectedValue == null ? 0 : int.Parse(uiSucursal.SelectedValue.ToString());
                //int sucursalDestino = uiSucursalDestino.SelectedValue == null ? 0 : int.Parse(uiSucursalDestino.SelectedValue.ToString());
                DateTime fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                decimal total = 0;



               
               using (TransactionScope scope = new TransactionScope())
              {
                    if (
                    lstCargaInicial
                    .Where(w => w.tieneCargaInicial == false).Count() > 0
                    )
                    {
                        oContext.p_doc_inv_movimiento_ins(pMovimientoID, sucursalOrigen, "", (int)Enumerados.tipoMovsInventario.cargaInicial, fechaActual, fechaActual.TimeOfDay, "",
                       total, 1, true, fechaActual,sucursalOrigen, null, 1,null);

                        foreach (CargaInicialModel itemMov in lstCargaInicial)
                        {
                            if (itemMov.tieneCargaInicial == false)
                            {
                                ObjectParameter pMovimientoDetalleId = new ObjectParameter("pMovimientoDetalleId", 0);
                                oContext.p_inv_movimiento_detalle_ins(pMovimientoDetalleId, int.Parse(pMovimientoID.Value.ToString()), itemMov.productoId, 0, itemMov.InventarioFisico, itemMov.ultimoCosto, 0, itemMov.InventarioFisico, 1,itemMov.ultimoCosto,itemMov.costoPromedio,itemMov.ultimoCosto*itemMov.InventarioFisico,itemMov.ultimoCosto);
                            }

                        }

                        accionForm = (int)Enumerados.accionForm.actualizar;
                        idForm = int.Parse(pMovimientoID.Value.ToString());

                        scope.Complete();
                        MessageBox.Show("El movimiento ha sigo autorizado con éxito", "OK");
                        
                        this.Close();
                    }
                    else {
                        MessageBox.Show("No hay productos pendientes de afectar en el listado", "ERROR");
                    }
                    
                  

                }                   
                   


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        

    }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cancelar esta captura?", "AVISO", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cancelar();
            }
        }

        private void uiCancelarInv_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cancelar esta captura?, se afectará el inventario", "AVISO", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cancelarInv();
            }
        }
    }
}
