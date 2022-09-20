using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBD.Utilerias
{
    public class Resultado
    {
        public Resultado()
        {
            ok = true;
        }
        public bool ok { get; set; }

        public string mensaje { get; set; }
    }
}
