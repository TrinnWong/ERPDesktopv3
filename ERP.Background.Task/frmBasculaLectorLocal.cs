using ConexionBD;
using ConexionBD.Models;
using ERP.Business;
using ERP.Business.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Background.Task
{
    public partial class frmBasculaLectorLocal : Form
    {
        int err = 0;
        BasculaLectura basculaControlador;
        PuntoVentaContext puntoVentaContext;
        BasculasBusiness oBascula;
        cat_basculas_configuracion basculaConfiguracion;
        string localString = @"data source=(LocalDB)\localdb2014;attachdbfilename=c:\ERP\ERPProd_data.mdf;user id=pv;password=PV2018$;MultipleActiveResultSets=True;App=EntityFramework&quot;" ;
        ERPProdEntities oContext;
        decimal peso=0;
        decimal ultimoPesoOcupadoPorApp = 0;
        decimal ultimoIndefinido = 0;
        decimal ultimoPeso = 0;
        public frmBasculaLectorLocal()
        {
            InitializeComponent();

            puntoVentaContext = new PuntoVentaContext();
            
           

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            PlaceLowerRight();
            Hide();
            configApp();
        }

        private void PlaceLowerRight()
        {
            //Determine "rightmost" screen
            Screen rightmost = Screen.AllScreens[0];
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.Right > rightmost.WorkingArea.Right)
                    rightmost = screen;
            }

            this.Left = rightmost.WorkingArea.Right - this.Width;
            this.Top = rightmost.WorkingArea.Bottom - this.Height;
        }

        private void configApp()
        {
            try
            {
                string path = Directory.GetCurrentDirectory();
                string text = System.IO.File.ReadAllText(path + @"\config.txt");

                string[] fileValues = text.Split(',');

                puntoVentaContext.empresaId = Convert.ToInt32(fileValues[0]);
                puntoVentaContext.sucursalId = Convert.ToInt32(fileValues[1]);
                puntoVentaContext.usuarioId = 1;
                basculaConfiguracion = Business.BasculasBusiness.GetConfiguracionPCLocal(puntoVentaContext.usuarioId,puntoVentaContext.sucursalId);
                oBascula = new BasculasBusiness(puntoVentaContext.sucursalId);
                basculaControlador = new BasculaLectura(basculaConfiguracion,puntoVentaContext);
               this.TXThdid.Text = EquipoComputoBusiness.GetProcessorID();

            }
            catch (Exception ex)
            {

                Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
               
                Random rd = new Random();
                if (basculaControlador == null)
                    return;
                try
                {

                    //basculaControlador.cerrarBascula();

                    ERPProdEntities ContextLocal = new ERPProdEntities(localString);
                    basculaControlador.abrirBascula();

                    if (basculaControlador.isOpen())
                    {
                        //peso = rd.Next(100, 200);// basculaControlador.ObtenPeso();

                        peso =  basculaControlador.ObtenPeso();
                        //peso = .120M;

                        uiPeso.Value = peso;
                        string queryString = String.Format("UPDATE cat_configuracion Set SuperEmail4 = '{0}'  where ConfiguradorId = 1", peso.ToString());
                        ContextLocal.Database.ExecuteSqlCommand(queryString);
                        
                        



                    }


                }
                catch (Exception ex)
                {
                    uiMemo.Text =String.Format("[{0}:{1}:{2}:{3}:{4}]",basculaConfiguracion.PortName,basculaConfiguracion.WriteBufferSize,basculaConfiguracion.ReadBufferSize,basculaConfiguracion.BaudRate, localString) + ex.Message + "-"+"-"+(ex.InnerException == null ?"": ex.InnerException.Message) + ex.StackTrace;

                }
                

          
                



            }
            catch (Exception ex)
            {               

                err = ERP.Business.SisBitacoraBusiness.Insert(this.puntoVentaContext.usuarioId,
                                    "ERP.Background.Task (Lector de Báscula Automático)",
                                    this.Name,
                                    ex);

                uiMemo.Text = String.Format("[{0}:{1}:{2}:{3}]", basculaConfiguracion.PortName, basculaConfiguracion.WriteBufferSize, basculaConfiguracion.ReadBufferSize, basculaConfiguracion.BaudRate) + ex.Message + "-" + "-" + (ex.InnerException == null ? "" : ex.InnerException.Message) + ex.StackTrace+ "|" + err;


            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(basculaControlador != null)
            {
                basculaControlador.cerrarBasculaTarea();
            }
          
            //Application.Restart();
            //Environment.Exit(0);
        }

        private void uiPausarActivar_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
            }
            else
            {
                timer1.Enabled = true;
            }
            
        }
    }
}
