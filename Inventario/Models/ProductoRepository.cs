using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models
{
    public class ProductoRepository:IProductoRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Producto> GetAllProductos()
        {
            return _appDbContext.Productos;
        }

        public Producto GetProductoById(int productoId)
        {
            return _appDbContext.Productos.FirstOrDefault(p => p.ProductoId == productoId);
        }

        public void AddProducto(Producto producto)
        {
            _appDbContext.Productos.Add(producto);
            _appDbContext.SaveChanges();
        }
    }
}
