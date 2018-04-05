using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models
{
    public class ProveedorRepository:IProveedorRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProveedorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Proveedor> GetAllProveedores()
        {
            return _appDbContext.Proveedores;
        }

        public Proveedor GetProveedorById(int proveedorId)
        {
            return _appDbContext.Proveedores.FirstOrDefault(p => p.ProveedorId == proveedorId);
        }

        public void AddProveedor(Proveedor proveedor)
        {
            _appDbContext.Proveedores.Add(proveedor);
            _appDbContext.SaveChanges();
        }
    }
}
