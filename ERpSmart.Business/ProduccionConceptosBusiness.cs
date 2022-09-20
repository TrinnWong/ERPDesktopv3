using ConexionBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Business
{
    public class ProduccionConceptosBusiness : BusinessObject
    {
        public doc_produccion_conceptos Guardar(doc_produccion_conceptos datos,
            int productoId,
            int usuarioId,
            int sucursalId,
            ref string error)
        {
            error = "";
            doc_produccion_conceptos resultNew = new doc_produccion_conceptos();
            try
            {
                
                #region vaidaciones
                if(datos.Fin < datos.Inicio)
                {
                    error = "La hora de finalización no puede ser menor a la inicial";
                    return null;
                }
                if (datos == null)
                {
                    error = "No hay información para guardar";
                    return null;
                }
                if (datos.ConceptoId == 0)
                {
                    error = "El concepto es requerido";
                    return null;
                }

                cat_productos_base_conceptos entityProductoBase = oContext.cat_productos_base_conceptos
                    .Where(w => w.ProductoId == productoId && w.ConceptoId == datos.ConceptoId).FirstOrDefault();

                if(entityProductoBase == null)
                {
                    error = "No fue posible encontrar la configuración del concepto";
                    return null;
                }
                if(entityProductoBase.RegistrarTiempo == true
                    && (datos.Inicio == null || datos.Fin == null)
                    )
                {
                    error ="La información de Inicio Y Finalización es requerida";
                    return null;
                }
                if(entityProductoBase.RegistrarVolumen == true && datos.Cantidad == 0)
                {
                    error = "El volumen es requerido";
                    return null;
                }
                #endregion

                resultNew.ProduccionConceptoId = (oContext.doc_produccion_conceptos
                   .Max(m => (int?)m.ProduccionConceptoId) ?? 0) + 1;
                resultNew.CreadoEl = DateTime.Now;
                resultNew.CreadoPor = usuarioId;
                resultNew.Cantidad = datos.Cantidad;
                resultNew.ConceptoId = datos.ConceptoId;
                resultNew.Fin = datos.Fin;
                resultNew.Inicio = datos.Inicio;
                resultNew.ProduccionId = datos.ProduccionId;
                
                oContext.doc_produccion_conceptos.Add(resultNew);
                oContext.SaveChanges();

                ERP.Business.SisBitacoraBusiness.GuardaBitacoraGeneral(sucursalId, "INSERT:" + ERP.Utils.EntitiesUtil.GetValuesModel(resultNew), usuarioId);

            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                                "ERP",
                                                "ERP.Business.ProduccionBusiness",
                                                ex);

                error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";

            }

            return resultNew;
        }

        public string Eliminar(int produccionConceptoId,int usuarioId,int sucursalId)
        {
            string error = "";
            try
            {
                doc_produccion_conceptos entityDel = oContext.doc_produccion_conceptos
                    .Where(w => w.ProduccionConceptoId == produccionConceptoId).FirstOrDefault();

                oContext.doc_produccion_conceptos.Remove(entityDel);
                oContext.SaveChanges();

                ERP.Business.SisBitacoraBusiness.GuardaBitacoraGeneral(sucursalId, "DELETE:" + ERP.Utils.EntitiesUtil.GetValuesModel(entityDel), usuarioId);
            }
            catch (Exception ex)
            {

                int err = ERP.Business.SisBitacoraBusiness.Insert(usuarioId,
                                                "ERP",
                                                "ERP.Business.ProduccionBusiness",
                                                ex);

                error = "Ocurrió un error inesperado, revise el registro de bitácora [" + err.ToString() + "]";
            }

            return error;
        }
    }
}
