using ConexionBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class ComandasBusiness:BusinessObject
    {
        public List<cat_rest_comandas> GetBySucursal(int sucursalId)
        {
            oContext = new ERPProdEntities();
            return oContext.cat_rest_comandas
                .Where(w => w.SucursalId == sucursalId)
                .OrderByDescending(o=> o.Folio)
                .ToList();
        }

        public string Generar(int folioIni, int folioFin, PuntoVentaContext session)
        {
            string error = "";

            try
            {
                #region validar
                if(
                    oContext.cat_rest_comandas
                    .Where(w=> w.Folio >= folioIni && w.Folio <= folioFin 
                    && w.Disponible == true).Count() > 0
                    )
                {
                    error = "Existen folios aún disponibles con el mismo rango";
                    return error;

                }
                if(folioIni > folioFin)
                {
                    error = "El folio inicial no puede ser mayor al final";
                    return error;
                }

                oContext.p_cat_rest_comandas_gen(session.sucursalId,
                    folioIni, folioFin, session.usuarioId);
                #endregion
            }
            catch (Exception ex)
            {

                error = "Ocurrió un error al intentar guardar las comandas";
            }

            return error;
        }
    }
}
