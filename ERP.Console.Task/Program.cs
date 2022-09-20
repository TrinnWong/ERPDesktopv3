using ConexionBD.Models;
using ERP.Business;
using ERP.Business.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Console.Task
{
    public class Program
    {
        static BasculaLectura basculaControlador;
        static SisBitacoraBusiness oBitacora;
        static PuntoVentaContext puntoVentaContext;
        static void Main(string[] args)
        {
            Init();
        }

        private static void Init()
        {
            try
            {
                string path = System.IO.Directory.GetCurrentDirectory();
                string textConfig = System.IO.File.ReadAllText(path+@"\config.txt");
                
                if(textConfig.Length > 0)
                {
                    string[] textValues = textConfig.Split(',');
                    puntoVentaContext = new PuntoVentaContext();
                    puntoVentaContext.empresaId = Convert.ToInt32(textValues[0]);
                    puntoVentaContext.sucursalId = Convert.ToInt32(textValues[1]);
                    puntoVentaContext.usuarioId = 1;

                    basculaControlador = new BasculaLectura(puntoVentaContext);
                    oBitacora = new SisBitacoraBusiness();


                }



            }
            catch (Exception ex)
            {

                throw;
            }
        }

        
    }
}
