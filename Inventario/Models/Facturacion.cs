using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models
{
    public class Facturacion
    {
        public List<Producto> Productos{ get; set; }
        public List<Cliente>Clientes { get; set; }
        public List<Factura> Facturas{ get; set; }

    }
}
