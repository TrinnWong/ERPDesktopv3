using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Producto
{
    public class ProductoMinMaxListModel
    {
        public ProductoMinMaxListModel()
        {
            lstProductos = new List<ProductoMinMaxModel>();
            error = new ResultAPIModel();
        }
        public List<ProductoMinMaxModel> lstProductos { get; set; }

        public ResultAPIModel error { get; set; }
    }
}
