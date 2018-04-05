using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            /*
            if (!context.Clientes.Any())
            {
                context.AddRange
                (
                    new Cliente { ClienteId = 1, Name = "Manuel", LastName = "Martinez", IdentificationCard = "40200656433", PhoneNumber = "8091234545", Address = "Calle el Sol", Email = "pp@h.com" },
                    new Cliente { ClienteId = 2, Name = "Julio", LastName = "Cruz", IdentificationCard = "40200656430", PhoneNumber = "8491234545", Address = "Calle las palmas", Email = "rp@h.com" },
                    new Cliente { ClienteId = 3, Name = "Juana", LastName = "Lora", IdentificationCard = "40200656422", PhoneNumber = "8291234545", Address = "Avenida miraflores", Email = "dp@h.com" },
                    new Cliente { ClienteId = 4, Name = "Manolo", LastName = "Calderon", IdentificationCard = "40200656123", PhoneNumber = "8091234505", Address = "Plaza el oasis", Email = "ep@h.com" }
                );
            }
            context.SaveChanges();
            */
            if (!context.Proveedores.Any())
            {
                context.AddRange
                (
                    new Proveedor { ProveedorId = 1, Name = "Julian", LastName = "Rojas", IdentificationCard = "40200656433", PhoneNumber = "8091234545", Address = "Calle el Sol", Email = "pp@h.com" },
                    new Proveedor { ProveedorId = 2, Name = "Janet", LastName = "Bautista", IdentificationCard = "40200656430", PhoneNumber = "8491234545", Address = "Calle las palmas", Email = "rp@h.com" },
                    new Proveedor { ProveedorId = 3, Name = "Benjamin", LastName = "Concepcion", IdentificationCard = "40200656422", PhoneNumber = "8291234545", Address = "Avenida miraflores", Email = "dp@h.com" },
                    new Proveedor { ProveedorId = 4, Name = "Hainoa", LastName = "Ozoria", IdentificationCard = "40200656123", PhoneNumber = "8091234505", Address = "Plaza el oasis", Email = "ep@h.com" }
                );
            }
            context.SaveChanges();

            if (!context.Productos.Any())
            {
                context.AddRange
                (
                    new Producto { ProductoId=1, Name = "Yuca", Price = 12.95M, ShortDescription = "Our famous apple pies!", LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies." },
                    new Producto { ProductoId=2,Name = "Platano", Price = 18.95M, ShortDescription = "You'll love it!", LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies." },
                    new Producto { ProductoId=3,Name = "Yautia", Price = 18.95M, ShortDescription = "Plain cheese cake. Plain pleasure.", LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies."},
                    new Producto { ProductoId=4,Name = "Sopa", Price = 15.95M, ShortDescription = "A summer classic!", LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies."}
                );
            }
            context.SaveChanges();
            
        }
    }
}
