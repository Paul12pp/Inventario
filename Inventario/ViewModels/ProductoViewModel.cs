using Inventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.ViewModels
{
    public class ProductoViewModel
    {
        public List<Producto> Productos { get; set; }
        public string Title { get; set; }
        public List<Proveedor> Proveedores { get; set; }
    }
}
