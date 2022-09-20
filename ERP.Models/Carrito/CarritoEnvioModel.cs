using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Carrito
{
    public class CarritoEnvioModel
    {
        public int clienteDireccionId { get; set; }
        public int clienteId { get; set; }

        [Required(ErrorMessage = "El Email es requerido")]
        [MaxLength(50)]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Email Inválido")]
        public string emailContacto { get; set; }

        [Required(ErrorMessage = "La Calle y Número son requeridos")]
        [DisplayName("Calle y Número")]
        [MaxLength(250)]
        public string calleNumero { get; set; }

        [DisplayName("Número Exterior")]
        [MaxLength(10)]
        public string numero { get; set; }

        [DisplayName("Número Interior")]
        [MaxLength(10)]
        public string numeroInt { get; set; }

        public int sitioEntregaId { get; set; }

        [Required(ErrorMessage = "La colonia es requerida")]
        [DisplayName("Colonia")]
        [MaxLength(100)]
        public string colonia { get; set; }

        [Required(ErrorMessage = "La Ciudad es requerida")]
        [DisplayName("Ciudad")]
        [MaxLength(70)]
        public string ciudad { get; set; }

        [Required(ErrorMessage = "El Estado es requerido")]
        [DisplayName("Estado")]
        public int estadoId { get; set; }

        public string estado { get; set; }


        [Required(ErrorMessage = "El Código Postal es requerido")]
        [DisplayName("Código Postal")]
        [MinLength(5, ErrorMessage = "La longitud del CP debe de ser de 5 caracteres")]
        [MaxLength(5, ErrorMessage = "La longitud del CP debe de ser de 5 caracteres")]
        public string cp { get; set; }

        [Required(ErrorMessage = "El País es requerido")]
        [DisplayName("País")]

        public string pais { get; set; }


        [Required(ErrorMessage = "El Nombre de la persona que recibe es requerido")]
        [DisplayName("Nombre de la persona que recibe")]
        [MaxLength(250)]
        public string personaRecibe { get; set; }

        [Required(ErrorMessage = "El Teléfono es requerido")]
        [DisplayName("Teléfono de Contacto")]
        [MaxLength(20)]
        public string telefonoContacto { get; set; }
    }
}
