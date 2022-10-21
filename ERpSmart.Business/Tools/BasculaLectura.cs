using ConexionBD;
using ConexionBD.Models;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business.Tools
{
    public class BasculaLectura
    {
        private PuntoVentaContext puntoVentaContext;

        int ceroCount = 0;
        decimal ultimoValor=0;
        private SerialPort portBascula;
        cat_basculas_configuracion configBascula;
        public BasculaLectura(PuntoVentaContext _puntoVentaContext)
        {
            puntoVentaContext = _puntoVentaContext;

            ConfigurarBascula();
        }

        public BasculaLectura(cat_basculas_configuracion _configBascula)
        {
            configBascula = _configBascula;

            ConfigurarBascula();
        }



        private void ConfigurarBascula()
        {
                if(configBascula == null)
                    configBascula = BasculasBusiness.GetConfiguracionPCLocal(puntoVentaContext.usuarioId,puntoVentaContext.sucursalId);

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
            
          
        }

        public bool isOpen()
        {
            
            return portBascula.IsOpen;
        }

        public void abrirBascula()
        {
            if (portBascula == null)
                return;
            if (!portBascula.IsOpen)
            {
                portBascula.Open();                  

            }
           
        }

        public void cerrarBasculaTarea()
        {
            ultimoValor = 0;
            ceroCount = 0;
            if (portBascula == null)
                return;
            if (portBascula.IsOpen)
            {
                portBascula.Close();

            }


        }

        public void cerrarBascula()
        {
            ultimoValor = 0;
            ceroCount = 0;
            if (portBascula == null)
                return;
            if (portBascula.IsOpen)
            {
                portBascula.Close();

            }


            ERPProdEntities oContext = new ERPProdEntities();

            doc_equipo_computo_bascula_registro registro = oContext.doc_equipo_computo_bascula_registro
                .Where(w => w.EquipoConputoId == this.configBascula.EquipoComputoId)
                .OrderByDescending(o => o.Id).FirstOrDefault();
            if(registro!= null)
            {
                if (registro.OcupadaPorApp == true)
                {
                    registro.OcupadaPorApp = false;
                    oContext.SaveChanges();
                }
            }
            

        }

        public decimal ObtenPeso()
        {
            decimal peso = 0;

            if (portBascula.IsOpen)
            {

                portBascula.Write("P");
                string value = portBascula.ReadExisting();

                value = value.Replace("Kg", "").Replace("+", "").Replace("KG", "").Replace("kg", "");

                decimal.TryParse(value, out peso);

                if (peso == 0 && ceroCount <= 1)
                {
                    ceroCount++;
                    peso = ultimoValor;
                }
                else
                {
                    ultimoValor = peso;
                    ceroCount = 0;
                    
                }

            }
            else {
                if (peso == 0 && ceroCount <= 1)
                {
                    ceroCount++;
                    peso = ultimoValor;
                }
            }

            if (configBascula.PesoDefault > 0)
            {
                peso = peso - (configBascula.PesoDefault ?? 0);

            }
            if (peso < 0)
                return 0;
            return peso;
        }

        public decimal ObtenPesoSinDefault()
        {
            decimal peso = 0;

            if (portBascula.IsOpen)
            {

                portBascula.Write("P");
                string value = portBascula.ReadExisting();

                value = value.Replace("Kg", "").Replace("+", "").Replace("KG", "").Replace("kg", "");

                decimal.TryParse(value, out peso);

                if (peso == 0 && ceroCount <= 1)
                {
                    ceroCount++;
                    peso = ultimoValor;
                }
                else
                {
                    ultimoValor = peso;
                    ceroCount = 0;

                }

            }
            else
            {
                if (peso == 0 && ceroCount <= 1)
                {
                    ceroCount++;
                    peso = ultimoValor;
                }
            }

            if (configBascula.PesoDefault > 0)
            {
                peso = peso;

            }
            return peso;
        }

        public decimal ObtenPesoBD(bool descontarTara = false)
        {
            decimal peso = 0;
            try
            {
                
                ERPProdEntities oContext = new ERPProdEntities();

                doc_equipo_computo_bascula_registro registro = oContext.doc_equipo_computo_bascula_registro
                    .Where(w => w.EquipoConputoId == this.configBascula.EquipoComputoId)
                    .OrderByDescending(o => o.Id).FirstOrDefault();

                peso = Convert.ToDecimal(registro.Peso);

                if ((registro.OcupadaPorApp??false) == false)
                {
                    registro.OcupadaPorApp = true;
                    oContext.SaveChanges();
                }
                
                
            }
            catch (Exception ex)
            {

                
            }

            return descontarTara ? peso- (configBascula.PesoDefault??0) : peso;
        }
    }
}
