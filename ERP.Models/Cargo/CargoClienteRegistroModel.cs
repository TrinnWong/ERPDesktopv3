using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Cargo
{
    public class CargoClienteRegistroModel
    {
        public CargoClienteRegistroModel()
        {
            clientes = new List<Cliente.ClienteModel>();
            cargo = new CargoModel();
        }
        public List<Cliente.ClienteModel> clientes { get; set; }

        public int productoId { get; set; }

        public CargoModel cargo { get; set; }
    }
}
