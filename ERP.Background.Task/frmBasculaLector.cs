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
    public partial class frmBasculaLector : Form
    {
        int err = 0;
        BasculaLectura basculaControlador;
        PuntoVentaContext puntoVentaContext;
        BasculasBusiness oBascula;
        cat_basculas_configuracion basculaConfiguracion;
        ERPProdEntities oContext;
        decimal peso=0;
        decimal ultimoPesoOcupadoPorApp = 0;
        decimal ultimoIndefinido = 0;
        decimal ultimoPeso = 0;
        public frmBasculaLector()
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
                oContext = new ERPProdEntities();
                Random rd = new Random();
                string pesoRef = "";
                if (basculaControlador == null)
                    return;
                try
                {
                    
                    //basculaControlador.cerrarBascula();

                   
                    basculaControlador.abrirBascula();

                    if (basculaControlador.isOpen())
                    {
                        //peso = rd.Next(100, 200);// basculaControlador.ObtenPeso();

                        peso =  basculaControlador.ObtenPeso();
                        //peso = .120M;

                        uiPeso.Value = peso;                        

                        doc_equipo_computo_bascula_registro registro = oContext.doc_equipo_computo_bascula_registro
                                .Where(w => w.EquipoConputoId == basculaConfiguracion.EquipoComputoId && w.SucursalId == puntoVentaContext.sucursalId).FirstOrDefault();

                        if(registro != null)
                        {
                                registro.Peso = (double)peso;
                                registro.CreadoEl = DateTime.Now;
                                oContext.SaveChanges();
                        }
                        else
                        {
                                registro = new doc_equipo_computo_bascula_registro();

                                registro.Id = (oContext.doc_equipo_computo_bascula_registro.Max(m => (long?)m.Id) ?? 0) + 1;
                                registro.CreadoEl = DateTime.Now;
                                registro.Peso = (double)peso;
                                registro.EquipoConputoId = basculaConfiguracion.EquipoComputoId;
                                registro.SucursalId = puntoVentaContext.sucursalId;
                                oContext.doc_equipo_computo_bascula_registro.Add(registro);
                                oContext.SaveChanges();
                        }
                        //Registrar Indefinido
                        if ((registro.OcupadaPorApp??false) == false && peso > 0)
                        {
                            ultimoPesoOcupadoPorApp = 0;                          


                            

                            if(peso != ultimoIndefinido && Math.Abs((peso-ultimoIndefinido)) > .01M )
                            {
                                ultimoIndefinido = peso;

                                var result = Business.BasculasBusiness.InsertBitacora(basculaConfiguracion.BasculaId, puntoVentaContext.sucursalId,
                                puntoVentaContext.usuarioId, peso, (int)Business.Enumerados.tipoBasculaBitacora.Indefinido,
                                null, null);
                            }
                            

                        }

                        if((registro.OcupadaPorApp ?? false) && peso > 0)
                        {
                            ultimoPesoOcupadoPorApp = peso;
                            
                        }

                        if ((registro.OcupadaPorApp ?? false) && peso <= 0 && ultimoPesoOcupadoPorApp > 0 && Math.Abs(peso) > .01M)
                        {


                            var result = Business.BasculasBusiness.InsertBitacora(basculaConfiguracion.BasculaId, puntoVentaContext.sucursalId,
                                puntoVentaContext.usuarioId, ultimoPesoOcupadoPorApp, (int)Business.Enumerados.tipoBasculaBitacora.Indefinido,
                                null, null);


                            ultimoPeso = ultimoPesoOcupadoPorApp;

                        }







                        //uiHistorial.Text = uiHistorial.Text + String.Format("Insertar Bitácora Peso:{0}{1}", peso.ToString(), Environment.NewLine);
                        //var result = Business.BasculasBusiness.InsertBitacora(basculaConfiguracion.BasculaId, puntoVentaContext.sucursalId,
                        //puntoVentaContext.usuarioId, peso, (int)Business.Enumerados.tipoBasculaBitacora.Indefinido,
                        //    null, null);

                        //uiHistorial.Text = uiHistorial.Text + String.Format("Bitácora ID {0}{1}", result.Id.ToString(), Environment.NewLine);





                    }


                }
                catch (Exception ex)
                {
                    uiMemo.Text =String.Format("[{0}:{1}:{2}:{3}]",basculaConfiguracion.PortName,basculaConfiguracion.WriteBufferSize,basculaConfiguracion.ReadBufferSize,basculaConfiguracion.BaudRate) + ex.Message + "-"+"-"+(ex.InnerException == null ?"": ex.InnerException.Message) + ex.StackTrace;

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
