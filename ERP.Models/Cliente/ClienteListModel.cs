using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Cliente
{
    public class ClienteListModel
    {
        public ClienteListModel()
        {
            lstClientes = new List<ClienteModel>();
        }
        public List<ClienteModel> lstClientes { get; set; }
    }
}
