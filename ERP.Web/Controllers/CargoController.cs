using ConexionBD;
using DevExpress.Web.Mvc;
using ERP.Business;
using ERP.Models;
using ERP.Models.Cargo;
using ERP.Models.Usuario;
using ERP.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ERP.Web.Controllers
{
    [Authorize]
    public class CargoController : Controller
    {
       

        public CargoController()
        {
           
        }


        #region Add
        // GET: Cargo
        public ActionResult Add1()
        {
            CargoClienteRegistroModel registro = new CargoClienteRegistroModel();
            Session["CargoClienteRegistroModel"] = registro;

            return View();
        }

        [HttpPost]
        public ActionResult SetClientesCargo(string clientesParam,int productoId)
        {
            try
            {
                CargoClienteRegistroModel registro = (CargoClienteRegistroModel)Session["CargoClienteRegistroModel"];
                
                string[] clientes = clientesParam.Split(',');

                foreach (string item in clientes)
                {
                    int clienteId = 0;

                    int.TryParse(item, out clienteId);

                    if(clienteId > 0)
                    {
                        registro.clientes.Add(new ERP.Models.Cliente.ClienteModel() { clienteId = clienteId });
                    }
                    
                }

                if (registro.clientes.Count == 0)
                {
                    return Json(new { ok = false, error = "****ERROR***. SE REQUIERE SELECCIONAR POR LO MENOS UN CLIENTE" });
                }
                if (registro.cargo.detalle.Count == 0)
                {
                    return Json(new { ok = false, error = "****ERROR***. NO HAY FECHAS CONFIGURADAS" });
                }
                if (productoId == 0)
                {
                    return Json(new { ok = false, error = "****ERROR***. SE REQUIERE SELECCIONAR POR LO MENOS UN PRODUCTO" });
                }

                registro.productoId = productoId;

                Session["CargoClienteRegistroModel"] = registro;

                WebRequestUtil oWR = new WebRequestUtil();
                string url = ERP.Business.Enumerados.urlAPI_ERP + "Cargo/AddClienteCargo";
                string error = "";
                string paramJSON=JsonConvert.SerializeObject(registro);

                string resultAPI = oWR.Post(url, paramJSON, ref error);

                ResultAPIModel result = new ResultAPIModel();

                if (error.Length > 0)
                {
                    return Json(new { ok = false, error = "****ERROR***" + error });
                }
                else
                {
                    result = JsonConvert.DeserializeObject<ResultAPIModel>(resultAPI);

                    if (!result.ok)
                    {
                        return Json(new { ok = false, error = "****ERROR***" + result.error });
                    }
                }
                


                return Json(new { ok = true, error = ""});
            }
            catch (Exception ex)
            {

                return Json(new { ok = false, error = "****ERROR***"+ex.Message});
            }
        }

      
        [ValidateInput(false)]
        public ActionResult gvClienteCargoPartial()
        {
            //var model = new object[0];
            WebRequestUtil oWR = new WebRequestUtil();
            string error = "";
            UsuarioModel usuario = (UsuarioModel)Session["Usuario"];
            string result = oWR.Get(ERP.Business.Enumerados.urlAPI_ERP+ "Cliente/GetList?sucursalId="+usuario.lstSucursales.FirstOrDefault().sucursalId, "",ref error);

            JavaScriptSerializer j = new JavaScriptSerializer();
            ERP.Models.Cliente.ClienteListModel model = j.Deserialize<ERP.Models.Cliente.ClienteListModel>(result);

            return PartialView("_gvClienteCargoPartial", model.lstClientes);
        }

        [ValidateInput(false)]
        public ActionResult gvCargoDetalleEditPartial()
        {
            CargoClienteRegistroModel registro = (CargoClienteRegistroModel)Session["CargoClienteRegistroModel"];

            var model = registro.cargo.detalle;
            return PartialView("_gvCargoDetalleEditPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvCargoDetalleEditPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] ERP.Models.Cargo.CargoDetalleModel item)
        {
            List<CargoDetalleModel> model = new List<CargoDetalleModel>();
            if (ModelState.IsValid)
            {
                try
                {
                    CargoClienteRegistroModel registro = (CargoClienteRegistroModel)Session["CargoClienteRegistroModel"];

                    item.cargoDetalleId = registro.cargo.detalle.Count + 1;

                    registro.cargo.detalle.Add(item);

                    Session["CargoClienteRegistroModel"] = registro;
                    model = registro.cargo.detalle.ToList();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvCargoDetalleEditPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvCargoDetalleEditPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] ERP.Models.Cargo.CargoDetalleModel item)
        {
            List<CargoDetalleModel> model = new List<CargoDetalleModel>() ;
            if (ModelState.IsValid)
            {
                try
                {
                    CargoClienteRegistroModel registro = (CargoClienteRegistroModel)Session["CargoClienteRegistroModel"];

                    int id = item.cargoDetalleId ;

                    registro.cargo.detalle.Find(f=> f.cargoDetalleId == id).fechaCargo = item.fechaCargo;
                    registro.cargo.detalle.Find(f => f.cargoDetalleId == id).total = item.total;

                    Session["CargoClienteRegistroModel"] = registro;
                    model = registro.cargo.detalle.ToList();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvCargoDetalleEditPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvCargoDetalleEditPartialDelete(System.Int32 cargoDetalleId)
        {
            List<CargoDetalleModel> model = new List<CargoDetalleModel>();
            if (cargoDetalleId >= 0)
            {
                try
                {
                    CargoClienteRegistroModel registro = (CargoClienteRegistroModel)Session["CargoClienteRegistroModel"];

                    int id = cargoDetalleId;

                    CargoDetalleModel itemDel = registro.cargo.detalle.Where(w => w.cargoDetalleId == cargoDetalleId).FirstOrDefault();

                    registro.cargo.detalle.Remove(itemDel);
                   

                    Session["CargoClienteRegistroModel"] = registro;

                    model = registro.cargo.detalle.ToList();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvCargoDetalleEditPartial", model);
        }

        #endregion

        #region List

        [ValidateInput(false)]
        public ActionResult gvCargosPartial()
        {
            //var model = new object[0];
            WebRequestUtil oWR = new WebRequestUtil();
            string error = "";

            UsuarioModel usuario = (UsuarioModel)Session["Usuario"];

            string url = ERP.Business.Enumerados.urlAPI_ERP + "Cargo/GetList?sucursalId=" + usuario.lstSucursales.FirstOrDefault().sucursalId;

            string result = oWR.Get(url, "", ref error);

            JavaScriptSerializer j = new JavaScriptSerializer();
            List<ERP.Models.Cargo.CargoModel> model = j.Deserialize<List<ERP.Models.Cargo.CargoModel>>(result);

            return PartialView("_gvCargosPartial", model);
        }

        public ActionResult List()
        {
            return View();
        }
        #endregion

        #region Edit
        [HttpPost]
        public ActionResult Edit(CargoModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    WebRequestUtil oWR = new WebRequestUtil();
                   

                    string url = ERP.Business.Enumerados.urlAPI_ERP + "Cargo/Edit";

                    JavaScriptSerializer j = new JavaScriptSerializer();
                    string param = j.Serialize(model);
                    string error = "";

                    string resultAPIStr = oWR.Post(url, param, ref error);

                    if (error.Length > 0)
                    {
                        ModelState.AddModelError("", error);
                        return View(model);
                    }
                    else
                    {
                        ResultAPIModel resultApi = j.Deserialize<ResultAPIModel>(resultAPIStr);

                        if (!resultApi.ok)
                        {
                            ViewData["EditError"] = resultApi.error;
                            return View(model);
                        }
                        else
                        {
                            return RedirectToAction("List","Cargo");
                        }
                    }

                    return View(model);
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CargoModel model = new CargoModel();

            try
            {
               

                doc_cargos entity = new doc_cargos();
                WebRequestUtil oWR = new WebRequestUtil();

                string url = ERP.Business.Enumerados.urlAPI_ERP + "Cargo/Get";
                string error = "";
                string resultWS = "";

                //string paramJSON = "{\"id\":\"" + id + "\"}";

                string paramJSON = "?id=" + id.ToString();

                resultWS = oWR.Get(url + paramJSON);

                if (error.Length > 0)
                {
                    ModelState.AddModelError("", error);
                    return View(model);
                }
                else
                {
                    model = JsonConvert.DeserializeObject<CargoModel>(resultWS);

                   

                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }
           



            return View(model);
        }
        #endregion

        #region detalle WS

        [ValidateInput(false)]
        public ActionResult gvCargoDetallEditWSPartial(int? cargoId)
        {
            Session["CargoId"] = cargoId;
           
            List<ERP.Models.Cargo.CargoDetalleModel> model = GetDetList(cargoId);

           
            return PartialView("_gvCargoDetallEditWSPartial", model);
        }

        public List<CargoDetalleModel> GetDetList(int? cargoId)
        {
            ViewData["CargoId"] = cargoId;
            //var model = new object[0];
            WebRequestUtil oWR = new WebRequestUtil();
            string error = "";
            string url = ERP.Business.Enumerados.urlAPI_ERP + "Cargo/GetDetList?cargoId=" + cargoId.ToString();

            string result = oWR.Get(url, "", ref error);

            JavaScriptSerializer j = new JavaScriptSerializer();
            List<ERP.Models.Cargo.CargoDetalleModel> model = j.Deserialize<List<ERP.Models.Cargo.CargoDetalleModel>>(result);


            return model;
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvCargoDetallEditWSPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] ERP.Models.Cargo.CargoDetalleModel item,int cargoId)
        {
            List<CargoDetalleModel> model = new List<CargoDetalleModel>();
            if (ModelState.IsValid)
            {
                try
                {
                    WebRequestUtil oWR = new WebRequestUtil();
                    item.cargoId = cargoId;

                    string url = ERP.Business.Enumerados.urlAPI_ERP + "Cargo/AddDet";

                    JavaScriptSerializer j = new JavaScriptSerializer();
                    string param = j.Serialize(item);
                    string error = "";

                    string resultAPIStr = oWR.Post(url, param, ref error);

                    if (error.Length > 0)
                    {
                        ViewData["EditError"] = error;
                    }
                    else {
                        ResultAPIModel resultApi = j.Deserialize<ResultAPIModel>(resultAPIStr);

                        if(!resultApi.ok)
                        {
                            ViewData["EditError"] = resultApi.error;
                        }
                        else
                        {
                             model = GetDetList(item.cargoId);
                        }
                    }



                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return PartialView("_gvCargoDetallEditWSPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvCargoDetallEditWSPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] ERP.Models.Cargo.CargoDetalleModel item, int cargoId)
        {
            List<CargoDetalleModel> model = new List<CargoDetalleModel>();
            if (ModelState.IsValid)
            {
                try
                {
                    WebRequestUtil oWR = new WebRequestUtil();
                    item.cargoId = cargoId;

                    string url = ERP.Business.Enumerados.urlAPI_ERP + "Cargo/EditDet";

                    JavaScriptSerializer j = new JavaScriptSerializer();
                    string param = j.Serialize(item);
                    string error = "";

                    string resultAPIStr = oWR.Post(url, param, ref error);

                    if (error.Length > 0)
                    {
                        ViewData["EditError"] = error;
                    }
                    else
                    {
                        ResultAPIModel resultApi = j.Deserialize<ResultAPIModel>(resultAPIStr);

                        if (!resultApi.ok)
                        {
                            ViewData["EditError"] = resultApi.error;
                        }
                        
                    }



                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            model = GetDetList(item.cargoId);
            return PartialView("_gvCargoDetallEditWSPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvCargoDetallEditWSPartialDelete(System.Int32 cargoDetalleId)
        {
            List<CargoDetalleModel> model = new List<CargoDetalleModel>();
            if (cargoDetalleId >= 0)
            {
                try
                {
                    WebRequestUtil oWR = new WebRequestUtil();
                    

                    string url = ERP.Business.Enumerados.urlAPI_ERP + "Cargo/DelDet";

                    JavaScriptSerializer j = new JavaScriptSerializer();
                    string param = j.Serialize(cargoDetalleId);
                    string error = "";

                    string resultAPIStr = oWR.Post(url, param, ref error);

                    if (error.Length > 0)
                    {
                        ViewData["EditError"] = error;
                    }
                    else
                    {
                        ResultAPIModel resultApi = j.Deserialize<ResultAPIModel>(resultAPIStr);

                        if (!resultApi.ok)
                        {
                            ViewData["EditError"] = resultApi.error;
                        }
                        else
                        {
                            model = GetDetList(0);
                        }
                    }



                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvCargoDetallEditWSPartial", model);
        }

        #endregion
    }
}