using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Cliente
{
    public class ClienteCambiarPassModel
    { 
        public int clienteId { get; set; }

        [Required]
        public string passAnterior { get; set; }
        [Required]
        public string passNuevo1 { get; set; }
        [Required]
        public string passNuevo2 { get; set; }
    }
}
