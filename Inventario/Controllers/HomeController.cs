using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Models;
using Inventario.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly IClienteRepository _clienteRepository;

        public HomeController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Cliente overview";

            var clientes = _clienteRepository.GetAllClientes().OrderBy(c => c.Name);

            var homeViewModel = new HomeViewModel()
            {
                Clientes = clientes.ToList(),
                Title = "Welcome"
            };
            return View(homeViewModel);
        }
    }
}