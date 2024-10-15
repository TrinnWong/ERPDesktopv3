using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Sincronizacion
{
    public class SincronizaResultadoModel
    {
        string _detalle { get; set; }
        public string Tipo { get; set; }
        public string Entidad { get; set; }
        public bool Exitoso { get; set; }
        public string Detalle { get; set; }
    }
}
