using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Cliente
{
    public class ClienteModel:ResultAPIModel
    { 
        [Key]
        public int clienteId { get; set; }

        [Required]
        public string clave { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public string apellidoPaterno { get; set; }


        public string apellidoMaterno { get; set; }
        [EmailAddress]
        [Required]
        public string email { get; set; }

        public bool activo { get; set; }

        public int sucursalId { get; set; }

        public string sucursal { get; set; }

    }
}
