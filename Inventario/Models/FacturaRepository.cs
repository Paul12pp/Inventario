using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models
{
    public class FacturaRepository:IFacturaRepository
    {
        private readonly AppDbContext _appDbContext;

        public FacturaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Factura> GetAllFacturas()
        {
            return _appDbContext.Facturas;
        }

        public Factura GetFacturaById(int facturaId)
        {
            return _appDbContext.Facturas.FirstOrDefault(p => p.FacturaId == facturaId);
        }

        public void AddFactura(Factura factura)
        {
            _appDbContext.Facturas.Add(factura);
            _appDbContext.SaveChanges();
        }

        public Producto GetProductoById(int productoId)
        {
            return _appDbContext.Productos.FirstOrDefault(p => p.ProductoId == productoId);
        }


    }
}
