using Inventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario
{
    public class ClienteRepository:IClienteRepository
    {
        private readonly AppDbContext _appDbContext;

        public ClienteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Cliente> GetAllClientes()
        {
            return _appDbContext.Clientes;
        }

        public Cliente GetClienteById(int clienteId)
        {
            return _appDbContext.Clientes.FirstOrDefault(c => c.ClienteId == clienteId);
        }

        public void AddCliente(Cliente cliente)
        {
            _appDbContext.Clientes.Add(cliente);
            _appDbContext.SaveChanges();
        }

    }
}
