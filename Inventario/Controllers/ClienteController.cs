using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Models;
using Inventario.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        private readonly AppDbContext _appDbContext;

        public ClienteController(AppDbContext context, IClienteRepository clienteRepository)
        {
            _appDbContext = context;
            _clienteRepository = clienteRepository;
        }

        /*
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
            
        }*/

        public IActionResult Index()
        {
            return View();
        }

        private bool ClienteExists(int id)

        {

            return _appDbContext.Clientes.Any(e => e.ClienteId== id);

        }

        [HttpPost]
        public IActionResult Index(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteRepository.AddCliente(cliente);
                return RedirectToAction("ClienteComplete");

            }
            return View(cliente);
        }

        public IActionResult ClienteComplete()
        {
            return View();
        }

        public IActionResult List()
        {
            ViewBag.Title = "Cliente overview";

            var clientes = _clienteRepository.GetAllClientes().OrderBy(c => c.Name);

            var clienteViewModel = new ClienteViewModel()
            {
                Clientes = clientes.ToList(),
                Title = "Lista de clientes"
            };
            return View(clienteViewModel);
        }

        //GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _appDbContext.Clientes.SingleOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Name,LastName,IdentificationCard,PhoneNumber,Address,Email")] Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _appDbContext.Update(cliente);
                    await _appDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.ClienteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("List");
            }
            return View(cliente);
        }
        //Delete get
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _appDbContext.Clientes
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ClienteId == id);
            if (clientes == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(clientes);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientes = await _appDbContext.Clientes
                .SingleOrDefaultAsync(m => m.ClienteId == id);
            if (clientes == null)
            {
                return RedirectToAction("Index");
            }

            try
            {
                _appDbContext.Clientes.Remove(clientes);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction("List");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }
    }
}