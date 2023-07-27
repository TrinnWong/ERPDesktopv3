using ConexionBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business
{
    public class PreferenciaBusiness : BusinessObject
    {
        public static sis_preferencias_empresa ObtenPreferenciaPorEmpresa(int empresaId,string preferencia)
        {
            ERPProdEntities oContext = new ERPProdEntities();

            return oContext.sis_preferencias_empresa.Where(w => w.sis_preferencias.Preferencia == preferencia)
                .FirstOrDefault();
        }

        public static bool AplicaPreferencia(int empresaId, int sucursalId,
          string nombrePreferencia, int usuarioId
          )
        {
            bool result = false;
            try
            {
                ERPProdEntities oContext = new ERPProdEntities();

                if (oContext.sis_preferencias_sucursales.Where(w => w.sis_preferencias.Preferencia == nombrePreferencia)
                    .Count() > 0)
                {
                    if (
                    oContext.sis_preferencias_sucursales.Where(w => w.SucursalId == sucursalId &&
                    w.sis_preferencias.Preferencia == nombrePreferencia).Count() > 0
                    )
                    {
                        
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (oContext.sis_preferencias_empresa.Where(w => w.sis_preferencias.Preferencia == nombrePreferencia
                     && w.EmpresaId == empresaId).Count() > 0)
                    {
                      
                        return true;
                    }
                }

            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                    "ERP",
                                    "InventarioBusiness.Guardar",
                                    ex);
            }

            return result;
        }

        public static bool AplicaPreferencia(int empresaId,int sucursalId,
            string nombrePreferencia,int usuarioId,
            ref string valor)
        {
            bool result = false;
            valor = "";
            try
            {
                ERPProdEntities oContext = new ERPProdEntities();

                if (oContext.sis_preferencias_sucursales.Where(w => w.sis_preferencias.Preferencia == nombrePreferencia)
                    .Count() > 0)
                {
                    if (
                    oContext.sis_preferencias_sucursales.Where(w => w.SucursalId == sucursalId &&
                    w.sis_preferencias.Preferencia == nombrePreferencia).Count() > 0
                    )
                    {
                        valor = oContext.sis_preferencias_sucursales.Where(w => w.SucursalId == sucursalId &&
                    w.sis_preferencias.Preferencia == nombrePreferencia).FirstOrDefault().Valor;

                        valor = valor == null ? "" : valor;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else {
                    if(oContext.sis_preferencias_empresa.Where(w=> w.sis_preferencias.Preferencia == nombrePreferencia
                    && w.EmpresaId == empresaId).Count() > 0)
                    {
                        valor = oContext.sis_preferencias_empresa.Where(w => w.sis_preferencias.Preferencia == nombrePreferencia
                    && w.EmpresaId == empresaId).FirstOrDefault().Valor;
                        return true;
                    }
                }                

            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                    "ERP",
                                    "InventarioBusiness.Guardar",
                                    ex);
            }

            return result;
        }
    }
}
