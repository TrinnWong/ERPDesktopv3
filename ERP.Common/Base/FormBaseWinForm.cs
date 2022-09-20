using ConexionBD;
using ConexionBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Common.Base
{
   
    public class FormBaseWinForm:Form
    {
        public ERPProdEntities oContext;
        public PuntoVentaContext puntoVentaContext;


        public void ValidarAcceso(int idusuario,int idSucursal,string idForm)
        {
            if (!ERP.Business.SeguridadBusiness.ValidarAcceso(idusuario, idSucursal, idForm).ok)
            {
                ERP.Utils.MessageBoxUtil.ShowError("No tiene permisos para usar este recurso");
                this.Close();
            }
        }
    }
}
