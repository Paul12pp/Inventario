using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Inventario.Models;
using Inventario.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult  Details(int? id)
        {
            
            //var viewModel = new FacturaViewModel();
            /*
            viewModel.Facturas = _appDbContext.Facturas
                .Include(i => i.Cliente)
                .Include(i => i.Detalles.Select(c => c.FacturaId))
                .OrderBy(i => i.ClienteId);
            */
            var lista = _appDbContext.Facturas.Where(x => x.FacturaId == id).Include(x => x.Detalles).ToList();
            var pp = _appDbContext.Detalles.Where(x => x.FacturaId == id).Include(x => x.Factura).Include(z=>z.Producto).ToList();
            return View(pp);
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

        public IActionResult List()
        {
            ViewBag.Title = "Facturas overview";

            var facturas = _facturaRepository.GetAllFacturas().OrderByDescending(c=>c.FacturaId);
            var pp = _appDbContext.Facturas.OrderByDescending(x=>x.FacturaId).Include(x=>x.Cliente).ToList();
           
            /*
            var facturaViewModel = new FacturaViewModel()
            {
                Facturas = facturas.ToList(),
                Title = "Lista de facturas"
            };*/

            return View(pp);
        }

        


    }
}