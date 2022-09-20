using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class EmpleadossBusiness:BusinessObject
    {
        public List<rh_empleado_puestos> GetPuestos(int empleadoId)
        {
            oContext = new ERPProdEntities();
            return oContext.rh_empleado_puestos
                .Where(w => w.EmpleadoId == empleadoId)
                .ToList();
        }
    }
}
