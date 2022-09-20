using DevExpress.Web.Mvc;
using ERP.Business;
using ERP.Models;
using ERP.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ERP.Web.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Add()
        {
            ERP.Models.ProductoModel model = new ERP.Models.ProductoModel();

            model.productoId = 0;
            model.activo = true;

            return View(model);
        }

        public ActionResult Edit(int id)
        {

            WebRequestUtil oWR = new WebRequestUtil();
            string error = "";

            string url = Enumerados.urlAPI_ERP + "Producto/Get?productoId=" + id.ToString();

            string result = oWR.Get(url, "", ref error);

            JavaScriptSerializer j = new JavaScriptSerializer();
            ERP.Models.ProductoModel model = j.Deserialize<ERP.Models.ProductoModel>(result);

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ERP.Models.ProductoModel model)
        {
            if (ModelState.IsValid)
            {
                WebRequestUtil oWR = new WebRequestUtil();
                string url = Enumerados.urlAPI_ERP + "Producto/Edit";
                string error = "";

                string paramJSON = JsonConvert.SerializeObject(model);

                string resulAPI  = oWR.Post(url, paramJSON, ref error);
                ResultAPIModel resulAPI2 = JsonConvert.DeserializeObject<ResultAPIModel>(resulAPI);

                if (error.Length > 0 || resulAPI2.error.Length > 0)
                {
                    ModelState.AddModelError("", error + resulAPI2.error);
                    return View(model);
                }
                else
                {
                    return RedirectToAction("List", "Producto");
                }



            }
            else
            {
                return View(model);
            }

        }


        [HttpPost]
        public ActionResult Add(ERP.Models.ProductoModel model)
        {
            if (ModelState.IsValid)
            {
                WebRequestUtil oWR = new WebRequestUtil();
                string url = Enumerados.urlAPI_ERP + "Producto/Add";
                string error = "";

                string paramJSON = JsonConvert.SerializeObject(model);
                string resulAPI=oWR.Post(url, paramJSON, ref error);

                ResultAPIModel resulAPI2 = JsonConvert.DeserializeObject<ResultAPIModel>(resulAPI);


                if (error.Length > 0 || resulAPI2.error.Length> 0)
                {
                    ModelState.AddModelError("", error + resulAPI2.error);
                    return View(model);
                }
                else
                {
                    return RedirectToAction("List", "Producto");
                }



            }
            else
            {
                return View(model);
            }

        }

        [ValidateInput(false)]
        public ActionResult gvProductoPartial()
        {

            WebRequestUtil oWR = new WebRequestUtil();
            string error = "";

            string result = oWR.Get(Enumerados.urlAPI_ERP+ "Producto/GetList", "",ref error);

            JavaScriptSerializer j = new JavaScriptSerializer();
            List<ERP.Models.ProductoModel> model = j.Deserialize<List<ERP.Models.ProductoModel>>(result);


            return PartialView("_gvProductoPartial", model);
        }

       
    }
}