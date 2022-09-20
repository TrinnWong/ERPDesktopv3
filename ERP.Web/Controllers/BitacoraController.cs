using ConexionBD;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Web.Controllers
{
    [Authorize]
    public class BitacoraController : Controller
    {
        // GET: Bitacora
        public ActionResult List()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult gvBitacoraError_Partial()
        {
            ERPProdEntities oContext = new ERPProdEntities();
            List<sis_bitacora_errores> model = oContext.sis_bitacora_errores.OrderByDescending(o => o.CreadoEl).ToList();
            return PartialView("_gvBitacoraError_Partial", model);
        }
    }
}



