using ConexionBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class RecBusiness:BusinessObject
    {
        public string InsertarRecConfiguracion(cat_rec_configuracion_rangos entity)
        {
            string error = "";
            decimal? rangoIni = 0;
            decimal? rangoFin = 0;
            short id = 0;
            try
            {
                rangoFin = entity.RangoFinal;
                id = entity.Id;
                //if(
                //    oContext.cat_rec_configuracion_rangos
                //    .Where(w=> w.RangoInicial<= rangoFin && w.RangoFinal >= rangoFin && w.Id!= id).Count() > 0
                //    )
                //{
                //    error = "Los valores son incorrectos, verifique la información";
                //    return error;
                //}

                int id2 = entity.Id;
               
                if(entity.Id == 0)
                {
                    id = oContext.cat_rec_configuracion_rangos.Count() > 0 ?
                   oContext.cat_rec_configuracion_rangos.Max(m => m.Id) : (short)1;

                    if (id > 0)
                    {
                        id++;
                    }

                    rangoIni = oContext.cat_rec_configuracion_rangos.Count() > 0 ? oContext.cat_rec_configuracion_rangos.Max(m => m.RangoFinal):0;
                    if((rangoIni??0) > 0)
                    {
                        rangoIni = rangoIni + (decimal)0.01;
                    }
                   

                    entity.Id = id;
                    entity.RangoInicial = rangoIni??0;
                    entity.CreadoEl = oContext.p_GetDateTimeServer().FirstOrDefault().Value;

                    oContext.cat_rec_configuracion_rangos.Add(entity);
                    oContext.SaveChanges();
                }
                else
                {
                    id = entity.Id;

                    cat_rec_configuracion_rangos entityUpd = oContext.cat_rec_configuracion_rangos
                        .Where(w => w.Id == id).FirstOrDefault();

                    rangoIni = oContext.cat_rec_configuracion_rangos.Where(w => w.Id < id).Count() > 0 ? oContext.cat_rec_configuracion_rangos.Where(w=> w.Id < id).Max(m => m.RangoFinal):0;
                   

                    if ((rangoIni ?? 0) > 0)
                    {
                        rangoIni = rangoIni + (decimal)0.01;
                    }

                    entityUpd.RangoInicial = rangoIni??0;
                    entityUpd.RangoFinal = entity.RangoFinal;
                    entityUpd.PorcDeclarar = entity.PorcDeclarar;
                    oContext.SaveChanges();

                    List<cat_rec_configuracion_rangos> lstUpd = oContext.cat_rec_configuracion_rangos
                        .Where(w => w.Id >= id).ToList();

                    foreach (cat_rec_configuracion_rangos itemUpd in lstUpd.Where(w=> w.Id > id).ToList())
                    {
                        int idfor = itemUpd.Id;

                        rangoIni = lstUpd.Where(w => w.Id == (idfor - 1)).FirstOrDefault().RangoFinal;
                        cat_rec_configuracion_rangos entityUpd2 = oContext.cat_rec_configuracion_rangos
                            .Where(w => w.Id == idfor).FirstOrDefault();

                        if(rangoIni > 0)
                        {
                            entityUpd2.RangoInicial = (rangoIni ??0)+(decimal)0.01;
                        }

                        oContext.SaveChanges();
                    }

                    
                }
               

                
            }
            catch (Exception ex)
            {

                error = ex.Message;
            }

            return error;
        }
    }
}
