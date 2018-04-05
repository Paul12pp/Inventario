using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models
{
    public class Detalle
    {
        public int DetalleId { get; set; }

        [Required(ErrorMessage = "The Factura Id is required")]
        public int FacturaId { get; set; }

        [Required(ErrorMessage = "The Producto Id is required")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "The price Id is required")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "The amount is required")]
        public int Cantidad { get; set; }

        public decimal Importe { get; set; }
        
        public Factura Factura { get; set; }
        public Producto Producto { get; set; }
    }
}
