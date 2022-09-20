using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Models.Pedidos
{
    public class PedidoConfiguracionViewModel
    {
        [DisplayName("Id")]
        [ReadOnly(true)]
        public int PedidoConfiguracionId { get; set; }

        [DisplayName("Sucursal")]
        public int SucursalId { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [DisplayName("Fecha Inicio")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        public System.DateTime Inicio { get; set; }

        [DisplayName("Fecha Cierre")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        public System.DateTime Cierre { get; set; }

        [DisplayName("Fecha Llegada")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        public Nullable<System.DateTime> FechaLlegada { get; set; }

        [DisplayName("Fecha Inicio Entrega")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        public Nullable<System.DateTime> FechaInicioEntrega { get; set; }

        [DisplayName("Fecha Fin Entrega")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        public Nullable<System.DateTime> FechaFinEntrega { get; set; }

        [DisplayName("Activo")]
        public bool Activo { get; set; }


        public System.DateTime CreadoEl { get; set; }
        public int CreadoPor { get; set; }
        public Nullable<System.DateTime> ModificadoEl { get; set; }
        public Nullable<int> ModificadoPor { get; set; }

       
    }
}
