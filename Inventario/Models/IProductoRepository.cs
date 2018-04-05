using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models
{
    public interface IProductoRepository
    {
        IEnumerable<Producto> GetAllProductos();

        Producto GetProductoById(int productoId);

        void AddProducto(Producto producto);
    }
}
