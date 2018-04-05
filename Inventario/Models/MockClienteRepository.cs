using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models
{
    public class MockClienteRepository
    {
        public List<Cliente> _clientes;
        public MockClienteRepository()
        {
            if (_clientes == null)
            {
                IntializeClientes();
            }
        }

        private void IntializeClientes()
        {
            _clientes = new List<Cliente>
            {
                    new Cliente {ClienteId = 1, Name = "Juan", LastName = "Martinez",IdentificationCard="40200656433", PhoneNumber="8091234545", Address="Calle el Sol", Email="pp@h.com"},
                    new Cliente {ClienteId = 2, Name = "Pedro", LastName  = "Cruz",IdentificationCard="40200656430", PhoneNumber="8491234545",Address="Calle las palmas", Email="rp@h.com" },
                    new Cliente {ClienteId = 3, Name = "Maria", LastName  = "Lora", IdentificationCard="40200656422", PhoneNumber="8291234545",Address="Avenida miraflores", Email="dp@h.com" },
                    new Cliente {ClienteId = 4, Name = "Ramon", LastName  = "Calderon", IdentificationCard="40200656123", PhoneNumber="8091234505",Address="Plaza el oasis", Email="ep@h.com" }
            };
        }

        public IEnumerable<Cliente> GetAllClientes()
        {
            return _clientes;
        }

        public Cliente GetClienteById(int clienteId)
        {
            return _clientes.FirstOrDefault(c => c.ClienteId == clienteId);
        }
    }
}
