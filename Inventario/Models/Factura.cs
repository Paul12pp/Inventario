using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models
{
    public class Factura
    {
        public int FacturaId { get; set; }

        [Required(ErrorMessage = "The Date time is requiered")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "The Cliente id is requiered")]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        public List<Detalle> Detalles { get; set; }
    }
}
