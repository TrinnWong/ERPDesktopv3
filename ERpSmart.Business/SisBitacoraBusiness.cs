using ConexionBD;
using ERP.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ERP.Business.Enumerados;

namespace ERP.Business
{
    public class SisBitacoraBusiness : BusinessObject
    {
        public SisBitacoraBusiness()
        {
           
        }
        public SisBitacoraBusiness(ERPProdEntities _context)
        {
            oContext = _context;
        }
        public string sis_bitacora_ins(string clase, string metodo, string errorEx)
        {
            string error = "";

            MailBusiness oMail = new MailBusiness();
            try
            {
                ObjectParameter pIdError = new ObjectParameter("pIdError", 0);

                oContext.p_sis_bitacora_errores_ins(pIdError, sistemasTrinn.eCommerce.ToString(), clase, metodo, errorEx);

                oMail.Send("Error de sistema: " + sistemasTrinn.eCommerce.ToString() + ";clase: " + clase + ";método:" + metodo + ";error:" + errorEx, "danw217@gmail.com;dmoreno@trinn.com.mx;", "ERROR DE SISTEMAS TRINN", "danw77@hotmail.com", null);



            }
            catch (Exception ex)
            {
                
                error = ex.Message;

            }

            return error;
        }

        public static int Insert(int usuarioId,string sistema,string clase, Exception ex)
        {
            try
            {
                ERPProdEntities oContext2 = new ERPProdEntities();
                sis_bitacora_errores oBitacora = new sis_bitacora_errores();

                oBitacora.Clase = clase;
                oBitacora.CreadoEl = oContext2.p_GetDateTimeServer().FirstOrDefault().Value;
                oBitacora.CreadoPor = usuarioId;
                oBitacora.ExInnerException = ex.InnerException != null ?
                    ex.InnerException.Message.Length > 2000 ? ex.InnerException.Message.Substring(0, 1999) : ex.InnerException.Message : null;
                oBitacora.ExMessage = ex.Message.Length > 500 ? ex.Message.Substring(0, 499) : ex.Message;
                oBitacora.ExStackTrace = ex.StackTrace.Length > 2000 ? ex.StackTrace.Substring(0,2000) : ex.StackTrace;
                oBitacora.Sistema = sistema;

                oContext2.sis_bitacora_errores.Add(oBitacora);

                oContext2.SaveChanges();

                return oBitacora.IdError;
            }
            catch (Exception e)
            {
                return 0;
                
            }
        }

        public static sis_bitacora_general GuardaBitacoraGeneral(string accion,int susucursalId, object entity, int usuarioid)
        {
            sis_bitacora_general bitacora = new sis_bitacora_general();
            try
            {
                ERPProdEntities oContext = new ERPProdEntities();
                bitacora.BitacoraId = (oContext.sis_bitacora_general
                    .Max(m => (int?)m.BitacoraId) ?? 0) + 1;
                bitacora.Detalle = accion + "|"+EntitiesUtil.GetValuesModel(entity);
                bitacora.CreadoPor = usuarioid;
                bitacora.CreadoEl = DateTime.Now;

                oContext.sis_bitacora_general.Add(bitacora);
                oContext.SaveChanges();
            }
            catch (Exception)
            {

                return null;
            }

            return bitacora;
        }

        public static sis_bitacora_general GuardaBitacoraGeneral(int susucursalId,object entity, int usuarioid)
        {
            sis_bitacora_general bitacora = new sis_bitacora_general();
            try
            {
                ERPProdEntities oContext = new ERPProdEntities();
                bitacora.BitacoraId = (oContext.sis_bitacora_general
                    .Max(m=> (int?)m.BitacoraId) ?? 0) +1;
                bitacora.Detalle = EntitiesUtil.GetValuesModel(entity);
                bitacora.CreadoPor = usuarioid;
                bitacora.CreadoEl = DateTime.Now;

                oContext.sis_bitacora_general.Add(bitacora);
                oContext.SaveChanges();
            }
            catch (Exception )
            {

                return null;
            }

            return bitacora;
        }

        public  sis_bitacora_general GuardarBitacoraGeneral(string accion, int susucursalId, object entity, int usuarioid)
        {
            sis_bitacora_general bitacora = new sis_bitacora_general();
            try
            {
              
                bitacora.BitacoraId = (oContext.sis_bitacora_general
                    .Max(m => (int?)m.BitacoraId) ?? 0) + 1;
                bitacora.Detalle = accion + "|" + EntitiesUtil.GetValuesModel(entity);
                bitacora.CreadoPor = usuarioid;
                bitacora.CreadoEl = DateTime.Now;

                oContext.sis_bitacora_general.Add(bitacora);
                oContext.SaveChanges();
            }
            catch (Exception)
            {

                return null;
            }

            return bitacora;
        }

        public static sis_bitacora_general GuardarBitacoraGeneral(
            string accion, int susucursalId, 
            string detalle, int usuarioid)
        {
            ERPProdEntities oContext = new ERPProdEntities();

            sis_bitacora_general bitacora = new sis_bitacora_general();
            try
            {

                bitacora.BitacoraId = (oContext.sis_bitacora_general
                    .Max(m => (int?)m.BitacoraId) ?? 0) + 1;
                bitacora.Detalle = accion + "|" + detalle;
                bitacora.CreadoPor = usuarioid;
                bitacora.CreadoEl = DateTime.Now;

                oContext.sis_bitacora_general.Add(bitacora);
                oContext.SaveChanges();
            }
            catch (Exception)
            {

                return null;
            }

            return bitacora;
        }

    }
}
