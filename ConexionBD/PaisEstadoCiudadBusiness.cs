using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class PaisEstadoCiudadBusiness:BusinessObject
    {

        public List<cat_paises> GetPaisesAll()
        {

            return oContext.cat_paises.ToList();
        }

        public List<cat_estados> GetEstadosByPais(int paisId)
        {
            
                return oContext.cat_estados.Where(w => w.PaisId == paisId).ToList();
        }

        public List<cat_municipios> GetMunicipiosByEstado(int estadoId)
        {
            return oContext.cat_municipios.Where(w => w.EstadoId == estadoId).ToList();
        }


    }
}
