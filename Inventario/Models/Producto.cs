using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The short short description is required")]
        [StringLength(100, ErrorMessage = "The short description is required")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "The long description is required")]
        [StringLength(400, ErrorMessage = "The long description is required")]
        public string LongDescription { get; set; }

        [Required(ErrorMessage = "The amoount is required")]
        [Range(1, 1000)]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "The price is requiered")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Proveedor Id is requiered")]
        public int ProveedorId { get; set; }

        public Proveedor Proveedor { get; set; }
        public List<Detalle> Detalles { get; set; }

    }
}

