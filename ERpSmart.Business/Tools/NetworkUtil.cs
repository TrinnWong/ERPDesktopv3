using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business.Tools
{
    public class NetworkUtil
    {
        public static bool ValidateInternet()
        {
            string estadoConexionaRed = "";
            bool RedActiva = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

            if (!RedActiva)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
       
}
}
