using ERP.Models.Sucursal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Usuario
{
    public class UsuarioModel
    {
        public  UsuarioModel()
        {
            lstSucursales = new List<SucursalModel>();
        }
        
        public int  usuarioId { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public List<SucursalModel> lstSucursales { get; set; }
        

    }
}
