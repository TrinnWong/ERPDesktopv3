using ERP.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Console.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

               

                bool RedActiva = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

                if (RedActiva)
                {


                    System.Uri Url = new System.Uri("https://www.google.com/");

                    System.Net.WebRequest WebRequest;
                    WebRequest = System.Net.WebRequest.Create(Url);
                    System.Net.WebResponse objetoResp;

                    try
                    {
                        objetoResp = WebRequest.GetResponse();
                        objetoResp.Close();

                        SincronizacionBusiness oSincorinizar = new SincronizacionBusiness();

                        oSincorinizar.ExportANube();


                    }
                    catch (Exception ex)
                    {
                        ERP.Business.SisBitacoraBusiness.Insert(1,
                                           "ERP.Console.Task",
                                           "Program",
                                           ex);

                    }
                    WebRequest = null;

                }
                else
                {


                }
            }
            catch (Exception ex)
            {

                ERP.Business.SisBitacoraBusiness.Insert(1,
                                          "ERP.Console.Task",
                                          "Program",
                                          ex);
            }
           

           

            Environment.Exit(0);
        }
    }
}
