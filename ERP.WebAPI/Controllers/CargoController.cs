using ConexionBD;
using ERP.Business;
using ERP.Models;
using ERP.Models.Cargo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERP.WebAPI.Controllers
{
    public class CargoController : ApiController
    {
        CargoBusiness oCargo;

        public CargoController()
        {
            oCargo = new CargoBusiness();
        }
      

       

        // POST: api/Cargo
        [HttpPost]
        public ResultAPIModel AddMassive([FromBody]CargoParamModel value)
        {
            return oCargo.AddMassive(value);
        }

        [HttpPost]
        public ResultAPIModel AddClienteCargo([FromBody]CargoClienteRegistroModel value)
        {
            return oCargo.AddCargosClientes(value);
        }
       

     
        [HttpGet]
        public List<CargoModel> GetList(int sucursalId)
        {
            return oCargo.GetList(sucursalId);
        }

        [HttpGet]
        public CargoModel Get(int id)
        {
            return oCargo.Get(id);
        }

        #region enc
        [HttpPost]
        public ResultAPIModel Add(CargoModel cargo)
        {
            return oCargo.CargoAdd(cargo);
        }
        [HttpPost]
        public ResultAPIModel Edit(CargoModel cargo)
        {
            return oCargo.CargoEdit(cargo);
        }

        #endregion

        #region det
        [HttpPost]
        public ResultAPIModel AddDet(CargoDetalleModel cargo)
        {
            return oCargo.CargoDetAdd(cargo);
        }
        [HttpPost]
        public ResultAPIModel EditDet(CargoDetalleModel cargo)
        {
            return oCargo.CargoDetEdit(cargo);
        }
        [HttpPost]
        public ResultAPIModel DelDet(int id)
        {
            return oCargo.CargoDetDel(id);
        }
         [HttpGet]
        public List<CargoDetalleModel> GetDetList(int cargoId)
        {
            return oCargo.GetDetList(cargoId);
        }
        #endregion
    }
}
