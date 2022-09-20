using ConexionBD;
using ConexionBD.Models;
using ERP.Common.Forms;
using ERP.Common.Reports;
using ERP.Reports;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.PuntoVenta
{
    public partial class frmAutorizacion : MetroFramework.Forms.MetroForm
    {
        public int proceso { get; set; }
        ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;
        public int opcionLlamado { get; set; }
        public frmAutorizacion()
        {
            InitializeComponent();
            oContext = new ERPProdEntities();
        }

        private void CorteCaja(bool permitirCorteCero)
        {
            try
            {
                oContext = new ERPProdEntities();
                DateTime fechaActual = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                ObjectParameter pCorteCajaId = new ObjectParameter("pCorteCajaId", 0);

                oContext.p_corte_caja_generacion(this.puntoVentaContext.cajaId, this.puntoVentaContext.usuarioId, fechaActual, pCorteCajaId, permitirCorteCero);

                MessageBox.Show("El corte de caja se generó con éxito", "AVISO");

                rptCorteCaja oCorte = new rptCorteCaja();
                ReportViewer oViewer = new ReportViewer();

                oCorte.DataSource = oContext.p_rpt_corte_caja_enc(int.Parse(pCorteCajaId.Value.ToString())).ToList();

                oViewer.ShowTicket(oCorte);

               // Application.Restart();
                
            }
            catch (Exception ex)
            {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show(message, "ERROR");
            }
        }

        private void continuar()
        {
            try
            {
                oContext = new ERPProdEntities();
                int numEmpleado;
                //if (int.TryParse(uiNumeroEmpleado.Text, out numEmpleado))
                //{
                    string password = uiClaveSupervisor.Text;

                    cat_usuarios entity = oContext.cat_usuarios.Where(
                            w =>
                              w.NombreUsuario == uiNumeroEmpleado.Text &&
                            (
                            (w.EsSupervisor == true &&                          
                            w.PasswordSupervisor == password)
                            ||
                            (
                            w.EsSupervisorCajero == true &&
                            w.PasswordSupervisorCajero == password
                            )
                            )
                        ).FirstOrDefault();

                    if (entity != null)
                    {

                      
                        if (opcionLlamado == 1)
                        {
                            frmRetiros frm = new frmRetiros();
                            frm.puntoVentaContext = this.puntoVentaContext;
                            frm.ShowDialog();
                        }
                        if (opcionLlamado == 2)
                        {
                        
                            //frmMenu.GetInstance().CorteCaja(null,false);
                        }

                        //if (opcionLlamado == 3)
                        //{
                        //    frmDeclaracionFondo frm = new frmDeclaracionFondo();
                        //    frm.puntoVentaContext = this.puntoVentaContext;

                        //    frm.ShowDialog();
                        //}
                        //permitir descuentos
                        if (opcionLlamado == 4)
                        {
                            frmPuntoVenta oPuntoVenta = frmPuntoVenta.GetInstance();
                            oPuntoVenta.habilitarDescuentosManuales();
                        }
                        if (opcionLlamado == (int)Enumerados.opcionesPV.reimpresionTicket)
                        {
                            frmReimprimirTicket frm = new frmReimprimirTicket();
                            frm.esReimpresion = true;
                            frm.MdiParent = this.MdiParent;
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.ShowDialog();
                        }
                        //if (opcionLlamado == (int)Enumerados.opcionesPV.cancelarTicket)
                        //{
                        //    frmMenu.GetInstance().cancelar();
                        //}
                        //if (opcionLlamado==(int)Enumerados.opcionesPV.registroGastos)
                        //{
                        //frmMenu.GetInstance().abrirGastos();
                        //}

                        //if (opcionLlamado == (int)Enumerados.opcionesPV.devoluciones)
                        //{
                        //    frmMenu.GetInstance().abrirDevoluciones();
                        //}

                        //if (opcionLlamado == (int)Enumerados.opcionesPV.apartados)
                        //{
                        //    frmMenu.GetInstance().abrirApartados();
                        //}

                        //if (opcionLlamado == (int)Enumerados.opcionesPV.existencias)
                        //{
                        //    frmMenu.GetInstance().abrirExistencias();
                        //}

                        this.Close();



                    }
                    else
                    {
                        MessageBox.Show("Clave no válida", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                //}
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            continuar();
        }

        private void uiClaveSupervisor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                continuar();
            }
        }

        private void frmAutorizacion_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }
    }
}
