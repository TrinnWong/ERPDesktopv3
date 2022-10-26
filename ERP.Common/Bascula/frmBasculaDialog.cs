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
            

                //basculaControlador.cerrarBascula();


                basculaControlador.abrirBascula();

                if (basculaControlador.isOpen())
                {
                    //peso = rd.Next(100, 200);// basculaControlador.ObtenPeso();

                    uiCantidad.EditValue = basculaControlador.ObtenPesoBD();
                    //peso = .120M;

                   
                }


            
        }

        private void frmBasculaDialog_Load(object sender, EventArgs e)
        {
            uiTexto.Text = productoDescripcion;
            basculaConfiguracion = Business.BasculasBusiness.GetConfiguracionPCLocal(puntoVentaContext.usuarioId, puntoVentaContext.sucursalId);
            oBascula = new BasculasBusiness(puntoVentaContext.sucursalId);
            basculaControlador = new BasculaLectura(basculaConfiguracion, puntoVentaContext);

            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            leerBascula();
        }

        private void frmBasculaDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            if (basculaControlador.isOpen())
            {
                basculaControlador.cerrarBascula();


            }
            
        }
    }
}
