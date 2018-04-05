using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> GetAllClientes();
        Cliente GetClienteById(int clienteId);
        void AddCliente(Cliente cliente);
    }
}
