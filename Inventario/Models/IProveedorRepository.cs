using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models
{
    public interface IProveedorRepository
    {
        IEnumerable<Proveedor> GetAllProveedores();
        Proveedor GetProveedorById(int proveedorId);
        void AddProveedor(Proveedor proveedor);
    }
}
