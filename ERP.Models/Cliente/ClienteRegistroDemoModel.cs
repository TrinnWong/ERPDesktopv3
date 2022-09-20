using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Cliente
{
    public class ClienteRegistroDemoModel
    {
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        public string ApellidoPaterno { get; set; }

        [MaxLength(50)]
        public string ApellidoMaterno { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        public short Giro { get; set; }

        public string productos { get; set; }
    }
}
