using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace Inventario.Controllers
{
    [Authorize]
    public class FacturaController : Controller
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly AppDbContext _appDbContext;

        public FacturaController(AppDbContext appDbContext, IFacturaRepository facturaRepository)
        {
            _appDbContext = appDbContext;
            _facturaRepository = facturaRepository;
        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Create()
        {
            ViewBag.ClienteId = _appDbContext.Clientes.ToList();
            ViewBag.ProductoId = _appDbContext.Productos.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Factura factura)
        {
            if (ModelState.IsValid)
            {
                _facturaRepository.AddFactura(factura);
                //return RedirectToAction("FacturaComplete");

            }
            return Json(factura);
        }

        public IActionResult FacturaComplete()
        {
            return View();
        }

        [ActionName("ObtenerFactura")]
        public JsonResult ObtenerFactura()
        {
            var facturas =  _facturaRepository.GetAllFacturas();
            return Json(facturas);
        }

        public string TellMeDate()
        {
            return DateTime.Today.ToString();
        }
    }
}