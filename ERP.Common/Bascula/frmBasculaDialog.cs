using ConexionBD;
using ERP.Business;
using ERP.Business.Tools;
using ERP.Common.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Bascula
{
    public partial class frmBasculaDialog : FormBaseXtraForm
    {
        int err = 0;
        BasculaLectura basculaControlador;
        BasculasBusiness oBascula;
        cat_basculas_configuracion basculaConfiguracion;
        public decimal cantidad { get; set; }
        private static frmBasculaDialog _instance;
        bool pesoInteligenteLecturaLocal = false;
        string error = "";
        public static frmBasculaDialog GetInstance()
        {
            if (_instance == null) _instance = new frmBasculaDialog();
            else _instance.BringToFront();
            return _instance;
        }

        public string productoDescripcion { get; set; }
        
        public frmBasculaDialog()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;

                cantidad = uiCantidad.Value;

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

        private void leerBascula()
        {
            oContext = new ERPProdEntities();
            Random rd = new Random();
            if (basculaControlador == null)
                return;


            if (puntoVentaContext.conectarConBascula)
            {
                basculaControlador.abrirBascula();

                if (basculaControlador.isOpen())
                {                  

                    uiCantidad.EditValue = basculaControlador.ObtenPeso();

                }
            }
            else
            {
                if (pesoInteligenteLecturaLocal)
                {
                    uiCantidad.EditValue = basculaControlador.ObtenPesoBDLocal();
                }
                else
                {
                    uiCantidad.EditValue = basculaControlador.ObtenPesoBD();
                }
                
            }

                


            
        }

        private void frmBasculaDialog_Load(object sender, EventArgs e)
        {
            uiTexto.Text = productoDescripcion;
            basculaConfiguracion = Business.BasculasBusiness.GetConfiguracionPCLocal(puntoVentaContext.usuarioId, puntoVentaContext.sucursalId);
            oBascula = new BasculasBusiness(puntoVentaContext.sucursalId);
            basculaControlador = new BasculaLectura(basculaConfiguracion, puntoVentaContext);

            timer1.Enabled = true;

            if (ERP.Business.PreferenciaBusiness.AplicaPreferencia(puntoVentaContext.empresaId,
               puntoVentaContext.sucursalId, "UsarPesoInteligente", puntoVentaContext.usuarioId, ref error))
            {
                if (error.ToUpper() == "LOCAL")
                {
                    pesoInteligenteLecturaLocal = true;
                }
                
            }
            else
            {
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            leerBascula();
        }

        private void frmBasculaDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            if (puntoVentaContext.conectarConBascula)
            {
                if (basculaControlador.isOpen())
                {
                    basculaControlador.cerrarBascula();


                }
            }
            
            
        }
    }
}
