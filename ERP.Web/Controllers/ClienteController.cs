using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ERP.Models.Cliente;
using ERP.Utils;
using ERP.Business;
using Newtonsoft.Json;
using ERP.Models;
using System.Web.Script.Serialization;
using ERP.Models.Usuario;

namespace ERP.Web.Controllers
{

    [System.Web.Mvc.Authorize]
    public class ClienteController : Controller
    {
        ConexionBD.ERPProdEntities oContext;
        WebRequestUtil oWR;

        public ClienteController()
        {
            oContext = new ConexionBD.ERPProdEntities();
            oWR = new WebRequestUtil();
        }

        public ActionResult List()
        {
            return View();
        }



        [ValidateInput(false)]
        public ActionResult gvClientePartial()
        {

            UsuarioModel usuario = (UsuarioModel)Session["Usuario"];           


            string url = Enumerados.urlAPI_ERP + "Cliente/GetList?sucursalId="+usuario.lstSucursales.FirstOrDefault().sucursalId;
            string error="";

            var model = oWR.Get(url, "", ref error);

            ClienteListModel result = JsonConvert.DeserializeObject<ClienteListModel>(model);

            return PartialView("_gvClientePartial", result.lstClientes);
        }

        #region add
        public ActionResult Add()
        {
            ClienteModel model = new ClienteModel();
            model.clienteId = 0;

            return View(model);
        }
        [System.Web.Mvc.HttpPost]
        public ActionResult Add(ClienteModel model)
        {
            if(ModelState.IsValid)
            {
                UsuarioModel usuario = (UsuarioModel)Session["Usuario"];

                model.sucursalId = usuario.lstSucursales.FirstOrDefault().sucursalId;

                string url = Enumerados.urlAPI_ERP + "Cliente/Add";
                string error = "";

                string paramJSON = JsonConvert.SerializeObject(model);

                string resultAPI = oWR.Post(url, paramJSON, ref error);

                JavaScriptSerializer j = new JavaScriptSerializer();

                ResultAPIModel resultApi2 = j.Deserialize<ResultAPIModel>(resultAPI);

                if (error.Length > 0 || resultApi2.error.Length>0)
                {
                    ModelState.AddModelError("", error + resultApi2.error);
                    return View(model);
                }
                else
                {
                    return RedirectToAction("List", "Cliente");
                }

               

            }
            else
            {
                return View(model);
            }


        }
        #endregion

        #region edit

        public ActionResult Edit(int id)
        {
            ClienteModel model = new ClienteModel();
            string url = Enumerados.urlAPI_ERP + "Cliente/Get";
            string error = "";
            string resultWS = "";

            //string paramJSON = "{\"id\":\"" + id + "\"}";

            string paramJSON = "?id="+id.ToString();

            resultWS = oWR.Get(url+paramJSON);


            if (error.Length > 0)
            {
                ModelState.AddModelError("", error);
                return View(model);
            }
            else
            {
                model = JsonConvert.DeserializeObject<ClienteModel>(resultWS);

                
            }

            ViewData["SucursalId"] = 0;
            return View(model);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(ClienteModel model)
        {
            if (ModelState.IsValid)
            {
                UsuarioModel usuario = (UsuarioModel)Session["Usuario"];

                model.sucursalId = usuario.lstSucursales.FirstOrDefault().sucursalId;

                string url = Enumerados.urlAPI_ERP + "Cliente/Edit";
                string error = "";

                string paramJSON = JsonConvert.SerializeObject(model);
                    /*"{\"clienteId\":\"" + model.clienteId.ToString() + "\"," +
                         "\"clave\":\"" + model.clave + "\"," +
                         "\"email\":\"" + model.email + "\"," +
                          "\"nombre\":\"" + model.nombre + "\"," +
                           "\"apellidoPaterno\":\"" + model.apellidoPaterno + "\"," +
                            "\"activo\":\"" + model.activo.ToString() + "\"," +
                                   "\"apellidoMaterno\":\"" + model.apellidoMaterno + "\"}";*/

                string resulAPI = oWR.Post(url, paramJSON, ref error);

                ResultAPIModel resulAPI2 = JsonConvert.DeserializeObject<ResultAPIModel>(resulAPI);


                if (error.Length > 0 || resulAPI2.error.Length > 0)
                {
                    resulAPI2.error = resulAPI2.error + error;
                    ModelState.AddModelError("", resulAPI2.error);
                    return View(model);
                }
                else
                {
                    return RedirectToAction("List", "Cliente");
                }



            }
            else
            {
                return View(model);
            }


        }

        #endregion
    }
}