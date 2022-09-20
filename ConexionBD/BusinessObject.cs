using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class BusinessObject
    {
       public ERPProdEntities oContext;
        public CadenaConexion oStringConnection;

        public BusinessObject()
        {
            oContext = new ERPProdEntities();
            oStringConnection = new CadenaConexion();
        }

    }
}
