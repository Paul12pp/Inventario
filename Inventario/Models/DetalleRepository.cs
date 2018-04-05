using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models
{
    public class DetalleRepository:IDetalleRepository
    {
        private readonly AppDbContext _appDbContext;

        public DetalleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Detalle> GetAllDetalles()
        {
            return _appDbContext.Detalles;
        }

        public Detalle GetDetalleById(int detalleId)
        {
            return _appDbContext.Detalles.FirstOrDefault(p => p.DetalleId == detalleId);
        }

        public void AddDetalle(Detalle detalle)
        {
            _appDbContext.Detalles.Add(detalle);
            _appDbContext.SaveChanges();
        }
    }
}
