using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class ProductoAgrupadoBusiness:BusinessObject
    {
        public string guardarEnc(ref int productoAgrupadoId,int productoBaseId,string especificaciones,bool liquidacion)
        {
            string error = "";
            try
            {
                int id = productoAgrupadoId;
                #region validaciones
                if (
                    oContext.cat_productos_agrupados
                    .Where(
                        w => w.ProductoAgrupadoId != id &&
                        w.ProductoId == productoBaseId
                    ).Count() > 0
                    )
                {
                    error = "El producto base ya se usa como agrupador en otro registro";
                }

                if (error.Length > 0)
                {
                    return error;
                }
                #endregion

                ObjectParameter pProductoAgrupadoId = new ObjectParameter("pProductoAgrupadoId", productoAgrupadoId);

                oContext.p_cat_productos_agrupados_ins_upd(pProductoAgrupadoId, productoBaseId, especificaciones,liquidacion);

                productoAgrupadoId = int.Parse(pProductoAgrupadoId.Value.ToString());


            }
            catch (Exception ex)
            {
                error = ex.Message;
                
            }

            return error;
        }

        public string guardarDet(int productoAgrupadoId, int productoId)
        {
            string error = "";
            try
            {
                #region validaciones
                if (
                    oContext.cat_productos_agrupados_detalle
                    .Where(
                        w => w.ProductoAgrupadoId == productoAgrupadoId &&
                        w.ProductoId == productoId
                        ).Count() > 0
                  )
                {
                    error = "Ya existe un registro con la misma llave";
                }

                if (error.Length > 0)
                {
                    return error;
                }
                #endregion

                oContext.p_cat_productos_agrupados_detalle_ins(productoAgrupadoId, productoId);
            }
            catch (Exception ex)
            {

                error = ex.Message;
            }

            return error;
        }

        public string guardarMasivo(List<int> lst, int idEnc)
        {
            string error = "";

            try
            {
                foreach (int item in lst)
                {
                    error = guardarDet(idEnc, item);

                    if (error.Length > 0)
                    {
                        return error;
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
