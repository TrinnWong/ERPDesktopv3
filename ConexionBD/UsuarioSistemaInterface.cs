using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionBD.Utilerias;
using System.Data;

namespace ConexionBD
{
    public class UsuarioSistemaInterface
    {
        Business con;
        Resultado resultado;

        public UsuarioSistemaInterface()
        {
            con = new Business();
        }

    }
}
