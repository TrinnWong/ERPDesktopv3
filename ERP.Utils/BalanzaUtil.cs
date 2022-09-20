using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Utils
{
    public class BalanzaUtil
    {
        //Puerto conectado a la balanza
        private System.IO.Ports.SerialPort BasculaCom = new System.IO.Ports.SerialPort();
        
        public BalanzaUtil()
        {
            BasculaCom.PortName = "COM1";
            BasculaCom.BaudRate = 9600;
            BasculaCom.Parity = System.IO.Ports.Parity.Even;
            BasculaCom.StopBits = System.IO.Ports.StopBits.One;
            BasculaCom.DataBits = 8;
            
            //Abrir la comunicacion
            BasculaCom.Open();
        }

        //Delegado para asignar el valor recibido
        

        public string GetData()
        {
           return  BasculaCom.ReadExisting();
        }


    }
}
