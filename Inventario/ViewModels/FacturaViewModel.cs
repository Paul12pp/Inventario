﻿using Inventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.ViewModels
{
    public class FacturaViewModel
    {
        
        public List<Factura> Facturas { get; set; }
        public string Title { get; set; }
       // public List<Cliente> Clientes { get; set; }

        public IEnumerable<Detalle> Detalles { get; set; }
        public IEnumerable<Cliente> Clientes { get; set; }
        public IEnumerable<Producto> Productos { get; set; }


        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }

    }
}
