using ConexionBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business
{
    public class SucursalBusiness : BusinessObject
    {
        public static List<cat_sucursales> ObtenSucursalesPorUsuario(int empresaId,
            int usuarioId)
        {
            try
            {
                ERPProdEntities oContext = new ERPProdEntities();

                if(usuarioId == 1)
                {
                    return oContext.cat_sucursales
                    .Where(w=>w.Empresa == empresaId).ToList();
                }
                else
                {
                    return oContext.cat_sucursales
                    .Where(w => w.cat_usuarios_sucursales.Where(s1 => s1.UsuarioId == usuarioId).Count() > 0 &&
                    w.Empresa == empresaId).ToList();
                }

                
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                   "ERP",
                                   "InventarioBusiness.Guardar",
                                   ex);
            }

            return null;
        }
    }
}
