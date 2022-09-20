using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class ProductoModel
    {
        [Key]
        public int productoId { get; set; }
        [Required]
        public string clave { get; set; }
        [Required]
        public string descripcion { get; set; }
        
        public bool activo { get; set; }
    }
}
