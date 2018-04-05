using Inventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.ViewModels
{
    public class HomeViewModel
    {
        public List<Cliente> Clientes { get; set; }
        public string Title { get; set; }
    }
}
