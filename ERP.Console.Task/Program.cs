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


                System.Console.WriteLine("Linea 18");
                bool RedActiva = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

                if (RedActiva)
                {

                    System.Console.WriteLine("Linea 24");
                    System.Uri Url = new System.Uri("https://www.google.com/");

                    System.Net.WebRequest WebRequest;
                    WebRequest = System.Net.WebRequest.Create(Url);
                    System.Net.WebResponse objetoResp;

                    try
                    {
                        System.Console.WriteLine("Linea 33");
                        objetoResp = WebRequest.GetResponse();
                        objetoResp.Close();
                        System.Console.WriteLine("Linea 36");
                        SincronizacionBusiness oSincorinizar = new SincronizacionBusiness();
                        System.Console.WriteLine("Linea 38");
                        oSincorinizar.ExportANube();
                        
                       


                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("CATCH 45 ERROR:" + ex.Message+" "+  ex.StackTrace);
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
                System.Console.WriteLine("CATCH 65 Error:",ex.StackTrace);
               

                ERP.Business.SisBitacoraBusiness.Insert(1,
                                          "ERP.Console.Task",
                                          "Program",
                                          ex);
            }
           

           

            Environment.Exit(0);
        }
    }
}
