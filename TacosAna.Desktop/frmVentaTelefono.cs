using ConexionBD;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TacosAna.Desktop
{
    public partial class frmVentaTelefono : Form
    {
        int err;
        public doc_pedidos_orden_programacion programacion { get; set; }
        public bool esVentaPorTelefono { get; set; }
        private ERPProdEntities oContext;
        public frmVentaTelefono(bool _esVentaPorTelefono)
        {
            InitializeComponent();
            oContext = new ERPProdEntities();

            esVentaPorTelefono = _esVentaPorTelefono;

            if (esVentaPorTelefono)
            {
                this.Text = "Venta por Teléfono";
                uiTitulo.Text= "Venta por Teléfono";
            }
            else
            {
                this.Text = "Pedido";
                uiTitulo.Text = "Pedido";
            }
        }

        private void uiCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                DateTime fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                if (uiFecha.DateTime.Date < fechaActual.Date)
                {
                    XtraMessageBox.Show("La fecha programada debe de ser mayor a la fecha actual", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (
                    uiFecha.DateTime.Date == fechaActual.Date &&
                    uiHora.Time.TimeOfDay <= fechaActual.TimeOfDay
                    )
                {
                    XtraMessageBox.Show("La hora debe de ser mayor a la hora actual", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (
                    uiNombre.Text.Trim().Length == 0 ||
                    uiTelefono.Text.Trim().Length == 0 ||
                    uiFecha == null ||
                    uiHora == null
                    )
                {
                    XtraMessageBox.Show("Nombre, fecha, teléfono y hora son requeridos", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (programacion == null)
                {
                    programacion = new doc_pedidos_orden_programacion();
                    programacion.cat_clientes = new cat_clientes();
                }

                cat_clientes existeCliente = oContext.cat_clientes.Where(w => w.Telefono == uiTelefono.Text).FirstOrDefault();
                if(existeCliente != null)
                {
                    programacion.cat_clientes.ClienteId = existeCliente.ClienteId;
                    programacion.ClienteId = existeCliente.ClienteId;

                }
                else
                {
                    programacion.cat_clientes.ClienteId = 0;
                    programacion.ClienteId = 0;
                }
                
                programacion.cat_clientes.Nombre = uiNombre.Text;
                programacion.cat_clientes.Telefono = uiTelefono.Text;
                
                
                
                programacion.FechaProgramada = uiFecha.DateTime;
                programacion.HoraProgramada = uiHora.Time.TimeOfDay;

                if(programacion.doc_pedidos_orden == null)
                {
                    programacion.doc_pedidos_orden = new doc_pedidos_orden();
                }
                programacion.doc_pedidos_orden.Notas = uiNotas.Text;

                Actualizar();

                frmPuntoVenta.GetInstance().programacion = programacion;

                frmPuntoVenta.GetInstance().refrescarAvisoVentaTelefono();

                if (esVentaPorTelefono)
                {
                    frmPuntoVenta.GetInstance().guardarTemporal(uiNotas.Text.Length > 0 ? uiNotas.Text : frmPuntoVenta.GetInstance().notas, ERP.Business.Enumerados.tipoPedido.PedidoTelefono);
                }
                else
                {
                    frmPuntoVenta.GetInstance().mostrarSaldoPedido();
                }
                

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception  ex)
            {
                int err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                    "ERP",
                    this.Name,
                    ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
            
        }


        private void Actualizar()
        {
            try
            {
                if(programacion.PedidoProgramacionId > 0)
                {
                    oContext = new ERPProdEntities();
                    doc_pedidos_orden_programacion entityUpd = oContext
                        .doc_pedidos_orden_programacion
                        .Where(w => w.PedidoProgramacionId == programacion.PedidoProgramacionId).FirstOrDefault();

                    entityUpd.FechaProgramada = programacion.FechaProgramada;
                    entityUpd.HoraProgramada = programacion.HoraProgramada;
                    entityUpd.ClienteId = programacion.ClienteId;

                    oContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                err = ERP.Business.SisBitacoraBusiness.Insert(frmMenuRestTA.GetInstance().puntoVentaContext.usuarioId,
                     "ERP",
                     this.Name,
                     ex);
                ERP.Utils.MessageBoxUtil.ShowErrorBita(err);
            }
        }

        private void frmVentaTelefono_Load(object sender, EventArgs e)
        {
            if(programacion != null)
            {
                if(programacion.cat_clientes != null)
                {
                    uiNombre.Text = programacion.cat_clientes.Nombre;
                    uiTelefono.Text = programacion.cat_clientes.Telefono;
                }

                if(programacion.FechaProgramada.Year > 2000)
                {
                    uiFecha.DateTime = programacion.FechaProgramada;
                    uiHora.EditValue = programacion.HoraProgramada;
                }
                else
                {
                    uiFecha.DateTime = DateTime.Now;
                    uiHora.EditValue = DateTime.Now.TimeOfDay;
                }

                uiNotas.Text = programacion.doc_pedidos_orden != null ? programacion.doc_pedidos_orden.Notas:"";
                
            }
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void uiTelefono_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void uiTelefono_Leave(object sender, EventArgs e)
        {
            try
            {
                string telefono = uiTelefono.Text;
                cat_clientes cliente = oContext.cat_clientes
                    .Where(w => w.Telefono == telefono).FirstOrDefault();

                if (cliente != null)
                {
                    uiNombre.Text = cliente.Nombre;
                }
            }
            catch (Exception ex)
            {

                
            }
        }
    }
}
