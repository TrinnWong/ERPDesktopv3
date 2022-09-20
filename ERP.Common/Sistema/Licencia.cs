using ERP.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Sistema
{
    public class Licencia
    {
        public static bool ValidarLicencia()
        {
            SisCuentaBusiness oSisCuenta = new SisCuentaBusiness();
            if (!oSisCuenta.TieneArchivoConfiguracionCuenta())
            {
                frmCuentaConfigSistema oFormSisCuenta = new frmCuentaConfigSistema();


                var resultD = oFormSisCuenta.ShowDialog();
                if (resultD == DialogResult.OK)
                {
                    if (!oSisCuenta.ValidaLicencia(1, 1, ERP.Business.Enumerados.tipoProductoLicencia.LICENCIA_ERP_DESKTOP))
                    {
                        ERP.Utils.MessageBoxUtil.ShowError("No se cuenta con una licencia activa");
                        return false;
                    }
                    else
                    {

                        return oSisCuenta.CreateConnection(2);
                        
                    }
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return oSisCuenta.CreateConnection(2);
            }
            return false;
        }
       
    }
}
