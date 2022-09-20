using ERP.Models.Cargo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Cliente
{
    public class CargoPendienteModel
    {
        public CargoPendienteModel()
        {
            cargoDetalle = new List<CargoDetalleModel>();
            ok = new ResultAPIModel();
        }

        public ResultAPIModel ok { get; set; }

        public List<CargoDetalleModel> cargoDetalle { get; set; }
    }
}
