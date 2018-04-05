using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models
{
    public class Cliente
    {
        
        public int ClienteId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Your name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Your Lastname is required")]
        [StringLength(100, ErrorMessage = "Your lastname is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Your Identification Card is required.")]
        [MaxLength(11)]
        [MinLength(11)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Your Identification Card is required. Whithout '-'")]
        public string IdentificationCard { get; set; }

        [Required(ErrorMessage = "Your PhoneNumber Address is required")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Your Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Your Email Address is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public List<Factura> Facturas { get; set; }
    }
}
