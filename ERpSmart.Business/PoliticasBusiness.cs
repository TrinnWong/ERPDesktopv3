using ConexionBD;
using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business
{
    public class PoliticasBusiness : BusinessObject
    {
       public ResultAPIModel Insert(cat_politicas entity)
        {
            ResultAPIModel result = new ResultAPIModel();

            try
            {
                entity.Activo = true;
                entity.PoliticaId = (oContext.cat_politicas.Max(m => ((int?)m.PoliticaId)) ?? 0) + 1;
                entity.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;
                oContext.cat_politicas.Add(entity);
                oContext.SaveChanges();
            }
            catch (Exception ex)
            {

                result.error = ex.Message;
            }

            return result;
        }

        public ResultAPIModel Update(cat_politicas entity)
        {
            ResultAPIModel result = new ResultAPIModel();

            try
            {
                int id = entity.PoliticaId;

                cat_politicas entityttyUpd = new cat_politicas();

                entityttyUpd = oContext.cat_politicas.Where(w => w.PoliticaId == id)
                    .FirstOrDefault();

                entityttyUpd.Activo = entity.Activo;
                entityttyUpd.Descripcion = entity.Descripcion;
                entityttyUpd.Politica = entity.Politica;

                oContext.SaveChanges();

            }
            catch (Exception ex)
            {

                result.error = ex.Message;
            }

            return result;
        }

        public List<cat_politicas> GetList()
        {
            return oContext.cat_politicas.ToList();
        }
    }
}
