using Inventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.ViewModels
{
    public class ProveedorViewModel
    {
        public List<Proveedor> Proveedores { get; set; }
        public string Title { get; set; }
    }
}
