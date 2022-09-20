using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD.Models
{
    public class PuntoVentaContext
    {
        public PuntoVentaContext()
        {
            conectarConBascula = false;
        }
        private string _nombreImpresoraCaja {get;set;}
        private string _nombreImpresoraComanda { get; set; }
        public int usuarioId { get; set; }
        public string usuario { get; set; }
        public int empresaId { get; set; }
        public int sucursalId { get; set; }
        public int cajaId { get; set; }
        public bool esSupervisor { get; set; }
        public int sesionId { get; set; }
        public bool solicitarComanda { get; set; }
        public string giroPuntoVenta { get; set; }
        public string nombreImpresoraCaja { get { return _nombreImpresoraCaja == null ? "" : _nombreImpresoraCaja; } set { _nombreImpresoraCaja = value; } }
        public string nombreImpresoraComanda { get { return _nombreImpresoraComanda == null ? "" : _nombreImpresoraComanda; } set { _nombreImpresoraComanda = value; } }
        public bool tieneRec { get; set; }
        public string nombreSucursal { get; set; }
        public bool conectarConBascula { get; set; }
        public bool usarTareaBascula { get; set; }

    }
}
