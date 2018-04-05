using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models
{
    public interface IFacturaRepository
    {
        IEnumerable<Factura> GetAllFacturas();
        Factura GetFacturaById(int facturaId);
        void AddFactura(Factura factura);
        Producto GetProductoById(int productoId);


    }
}
