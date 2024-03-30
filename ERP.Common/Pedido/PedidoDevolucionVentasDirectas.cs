using ERP.Common.Base;
using ERP.Models.Pedidos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Pedido
{
    public partial class PedidoDevolucionVentasDirectas : FormBaseXtraForm
    {
        int err = 0;
        DateTime fechaActual;
        List<Models.Pedidos.PedidoDevolucionVentaDirectaMasaTortilla> lstDevoluciones;
        private void PedidoDevolucionVentasDirectas_Load(object sender, EventArgs e)
        {
            oContext = new ConexionBD.ERPProdEntities(true);
            this.fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

            LoadGrid();
        }

        public PedidoDevolucionVentasDirectas()
        {
            InitializeComponent();
        }

        public void LoadGrid()
        {
            try
            {
                oContext = new ConexionBD.ERPProdEntities(true);

                this.fechaActual = this.fechaActual.AddDays(-1);

               this.lstDevoluciones =  oContext.doc_ventas_detalle.Where( w=>
                        w.doc_ventas.ClienteId != null &&
                        w.doc_ventas.Activo == true && 
                        w.doc_ventas.SucursalId == puntoVentaContext.sucursalId &&
                        DbFunctions.TruncateTime(w.doc_ventas.Fecha) >= DbFunctions.TruncateTime(fechaActual) &&
                        (w.ProductoId == (int)ERP.Business.Enumerados.productosSistema.tortilla || w.ProductoId == (int)ERP.Business.Enumerados.productosSistema.masa) )
                 .Select(s=> new PedidoDevolucionVentaDirectaMasaTortilla() { 
                      cliente = s.doc_ventas.cat_clientes.Nombre,
                       clienteId = s.doc_ventas.ClienteId??0,
                        devolucionMasa = 0,
                        devolucionTortilla = 0,
                         fecha = s.doc_ventas.Fecha,
                          folio = s.doc_ventas.Folio,
                           precioMasa = s.ProductoId == (int)ERP.Business.Enumerados.productosSistema.masa ? s.PrecioUnitario : 0,
                           precioTortilla = s.ProductoId == (int)ERP.Business.Enumerados.productosSistema.tortilla ? s.PrecioUnitario : 0,
                            ventaId = s.VentaId

                 }).ToList();

                uiGrid.DataSource = this.lstDevoluciones;
                uiGridView.ExpandAllGroups();
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
    }
}
