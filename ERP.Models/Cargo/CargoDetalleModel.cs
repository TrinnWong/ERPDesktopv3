using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Cargo
{
    public class CargoDetalleModel
    {
        public int cargoDetalleId { get; set; }
        public int cargoId { get; set; }
        [Required]
        public DateTime fechaCargo { get; set; }
        public DateTime? fechaPago { get; set; }
        public decimal subTotal { get; set; }
        public decimal impuestos { get; set; }
        public string concepto { get; set; }
        [Required]
        public decimal total { get; set; }
        public decimal descuento { get; set; }
        public decimal saldo { get; set; }
        public decimal saldoVencido { get; set; }
        public bool vencido { get; set; }
    }
}
