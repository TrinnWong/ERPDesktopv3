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

namespace ERP.Common.Catalogos
{
    public partial class frmClienteForm : FormBaseXtraForm
    {
        public cat_clientes cliente { get; set; }
        public int clienteId { get; set; }
        int err;
        public frmClienteForm()
        {
            InitializeComponent();
        }

        private void uiGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                #region validaciones
                if(uiNombre.Text.Trim() == "")
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("El Nombre es requerido");
                    return;
                }
                if (uiTelefono.Text.Trim() == "" && uiTelefono2.Text.Trim()=="")
                {
                    ERP.Utils.MessageBoxUtil.ShowWarning("El Teléfono es requerido");
                    return;
                }
                //if (oContext.cat_clientes.Where(w => (w.Telefono == uiTelefono.Text.Trim() && uiTelefono.Text.Trim().Length > 0) ||
                //    (w.Telefono2 == uiTelefono2.Text.Trim() && uiTelefono2.Text.Trim().Length > 0) && w.ClienteId != clienteId).Count() > 0)
                //{
                //    ERP.Utils.MessageBoxUtil.ShowWarning("El Teléfono registrado ya existe para otro cliente");
                //    return;
                //}

                #endregion

                cat_clientes entityCliente = new cat_clientes();

                if(clienteId > 0)
                {
                    entityCliente = oContext.cat_clientes.Where(w => w.ClienteId == clienteId).FirstOrDefault();

                    entityCliente.Nombre = uiNombre.Text;
                    entityCliente.RFC = uiRFC.Text;
                    entityCliente.Colonia = uiColonia.Text;
                    entityCliente.Calle = uiCalle.Text;
                    entityCliente.NumeroExt = uiNumExterior.Text;
                    entityCliente.NumeroInt = uiNumeroInterior.Text;
                    entityCliente.CodigoPostal = uiCP.Text;
                    entityCliente.Telefono = uiTelefono.Text;
                    entityCliente.Telefono2 = uiTelefono2.Text;
                    entityCliente.Activo = true;
                    
                    oContext.SaveChanges();
                }
                else
                {
                    entityCliente = new cat_clientes();

                    entityCliente.ClienteId = (oContext.cat_clientes.Max(m => (int?)m.ClienteId) ?? 0) + 1;
                    entityCliente.Activo = true;
                    entityCliente.Nombre = uiNombre.Text;
                    entityCliente.RFC = uiRFC.Text;
                    entityCliente.Colonia = uiColonia.Text;
                    entityCliente.Calle = uiCalle.Text;
                    entityCliente.NumeroExt = uiNumExterior.Text;
                    entityCliente.NumeroInt = uiNumeroInterior.Text;
                    entityCliente.CodigoPostal = uiCP.Text;
                    entityCliente.Telefono = uiTelefono.Text;
                    entityCliente.Telefono2 = uiTelefono2.Text;
                    entityCliente.SucursalBaseId = this.puntoVentaContext.sucursalId;

                    oContext.cat_clientes.Add(entityCliente);

                    oContext.SaveChanges();
                }

                cliente = entityCliente;

                this.DialogResult = DialogResult.OK;
                this.Close();
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

        private void frmClienteForm_Load(object sender, EventArgs e)
        {
            oContext = new ERPProdEntities();
            BuscarRegistro();
        }

        private void BuscarRegistro()
        {
            try
            {
                oContext = new ERPProdEntities();

                if(clienteId > 0)
                {
                    cliente = oContext.cat_clientes
                        .Where(w => w.ClienteId == clienteId).FirstOrDefault();

                    uiNombre.Text = cliente.Nombre;
                    uiRFC.Text = cliente.RFC;
                    uiCalle.Text = cliente.Calle;
                    uiNumExterior.Text = cliente.NumeroExt;
                    uiNumeroInterior.Text = cliente.NumeroInt;
                    uiColonia.Text = cliente.Colonia;
                    uiCP.Text = cliente.CodigoPostal;
                    uiTelefono.Text = cliente.Telefono;
                    uiTelefono2.Text = cliente.Telefono2;
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
    }
}
