using ConexionBD;
using ERP.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.ServiceProcess;
using System.Text;

using System.Threading.Tasks;
using System.Timers;

namespace ERP.Service.Windows
{
    public partial class ServiceBascula : ServiceBase
    {
        BasculasBusiness oBascula;
        SerialPort portBascula;
        cat_basculas_configuracion configBascula;
        public ServiceBascula()
        {
            InitializeComponent();
            oBascula = new BasculasBusiness(0);
            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("ERPLogSource"))
            {
                System.Diagnostics.EventLog.CreateEventSource("ERPLogSource", "BasculaServiceLog");
            }
            eventLog1.Source = "ERPLogSource";
            // Write an informational entry to the event log.
            eventLog1.WriteEntry("Init Service ERP.");
            configBascula = null;
            try
            {
                configBascula = BasculasBusiness.GetConfiguracionPCLocal(1,0);

                if (configBascula != null)
                {
                    portBascula = new SerialPort(configBascula.PortName);
                    portBascula.BaudRate = configBascula.BaudRate;
                    portBascula.ReadBufferSize = configBascula.ReadBufferSize;
                    portBascula.WriteBufferSize = configBascula.WriteBufferSize;
                    portBascula.DataBits = 8;
                    portBascula.DiscardNull = true;
                    portBascula.ParityReplace = 63;
                    portBascula.Parity = Parity.None;

                }

                ERPProdEntities oContext2 = new ERPProdEntities();
                sis_bitacora_errores oBitacora = new sis_bitacora_errores();

                oBitacora.Clase = "ServiceBascula";
                oBitacora.CreadoEl = DateTime.Now;
                oBitacora.CreadoPor = 1;
                oBitacora.ExInnerException = "";
                oBitacora.ExMessage = "Inicialize" + DateTime.Now.ToLongDateString();
                oBitacora.ExStackTrace = "Inicialize" + DateTime.Now.ToLongDateString();
                oBitacora.Sistema = "ERP";

                oContext2.sis_bitacora_errores.Add(oBitacora);
                oContext2.SaveChanges();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("MESSAGE:"+
                    ex.Message+
                    ":StackTrace" + ex.StackTrace+
                    ":Inner Exception"+ (ex.InnerException != null ? ex.InnerException.Message : ""));

            }
           
        }

        protected override void OnStart(string[] args)
        {

            eventLog1.WriteEntry("In OnStart.");

            Timer aTimer = new System.Timers.Timer();
            aTimer.Interval = 2000;
            aTimer.Enabled = true;
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

        }

        private  void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                eventLog1.WriteEntry("intento de lectura de báscula");
                if (!oBascula.vaciando)
                {
                    string error = oBascula.LecturaRegistroBascula(ref portBascula);

                    if(error.Length > 0)
                    {
                        eventLog1.WriteEntry(error);
                    }
                }
               
            }
            catch (Exception ex)
            {
                ERPProdEntities oContext2 = new ERPProdEntities();
                sis_bitacora_errores oBitacora = new sis_bitacora_errores();

                oBitacora.Clase = "ServiceBascula";
                oBitacora.CreadoEl = DateTime.Now;
                oBitacora.CreadoPor = 1;
                oBitacora.ExInnerException = ex.InnerException == null ? ex.Message: ex.InnerException.Message;
                oBitacora.ExMessage =ex.Message;
                oBitacora.ExStackTrace = ex.StackTrace;
                oBitacora.Sistema = "ERP";

                oContext2.sis_bitacora_errores.Add(oBitacora);
                oContext2.SaveChanges();

            }
        }


        protected override void OnStop()
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }
    }
}
