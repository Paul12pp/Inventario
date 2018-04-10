using Inventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.ViewModels
{
    public class DetalleViewModel
    {
        public List<Producto> Productos { get; set; }
        public string Title { get; set; }
        public List<Proveedor> Proveedores { get; set; }
        public List<Detalle> Detalles { get; set; }
        public List<Cliente> Clientes { get; set; }
        public Factura FacturaSelect { get; set; }
        public List<Factura> Facturas{ get; set; }


        public int DetalleId { get; set; }
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Importe { get; set; }

    }
}
