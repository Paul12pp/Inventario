using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models
{
    public interface IDetalleRepository
    {
        IEnumerable<Detalle> GetAllDetalles();
        Detalle GetDetalleById(int detalleId);
        void AddDetalle(Detalle detalle);

    }
}
