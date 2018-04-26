using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Models;
using Inventario.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Inventario.Controllers
{
    [Authorize]
    public class ProductoController : Controller
    {

        private readonly IProductoRepository _productoRepository;
        private readonly AppDbContext _appDbContext;

        public ProductoController(AppDbContext context, IProductoRepository productoRepository)
        {
            _appDbContext = context;
            _productoRepository = productoRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Producto overview";
            return View();
        }
        /// <summary>
        /// METODO GET
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewBag.ProveedorId = _appDbContext.Proveedores.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _productoRepository.AddProducto(producto);
                return RedirectToAction("ProductoComplete");

            }

            return View(producto);
        }

        public IActionResult ProductoComplete()
        {
            return View();
        }

        /// <summary>
        /// metodo get
        /// </summary>
        /// <returns></returns>
        public IActionResult List()
        {
            ViewBag.Title = "Proveedores overview";

            var productos = _productoRepository.GetAllProductos().OrderBy(c => c.Name);

            var productoViewModel = new ProductoViewModel()
            {
                Productos = productos.ToList(),
                Title = "Lista de productos"
            };
            return View(productoViewModel);
        }

        /// <summary>
        /// metodo get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="saveChangesError"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            ViewBag.ProveedorId = _appDbContext.Proveedores.ToList();

            if (id == null)
            {
                return NotFound();
            }

            var productos = await _appDbContext.Productos
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ProductoId == id);
            if (productos == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(productos);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productos = await _appDbContext.Productos.SingleOrDefaultAsync(m => m.ProductoId == id);
            if (productos == null)
            {
                return RedirectToAction("Index");
            }
            try
            {
                _appDbContext.Productos.Remove(productos);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction("List");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
            /*
            var productos = await _appDbContext.Productos
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ProveedorId == id);
            

            try
            {
                _appDbContext.Productos.Remove(productos);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex *//*)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }*/

        }

        /// <summary>
        /// metodo get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.ProveedorId = _appDbContext.Proveedores.ToList();

            if (id == null)
            {
                return NotFound();
            }

            var productos = await _appDbContext.Productos.SingleOrDefaultAsync(m => m.ProductoId == id);
            if (productos == null)
            {
                return NotFound();
            }
            return View(productos);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ProductoId,Name,ShortDescription,LongDescription,Cantidad,Price,ProveedorId")] Producto producto)
        {
            if (id != producto.ProductoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _appDbContext.Update(producto);
                    await _appDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.ProductoId))
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
            return View(producto);
        }
        private bool ProductoExists(int id)
        {

            return _appDbContext.Productos.Any(e => e.ProductoId == id);

        }

        // GET: api/authors
        [HttpGet]
        [ActionName("ObtenerProducto")]
        public JsonResult Get()
        {
            return Json(_productoRepository.GetAllProductos());
        }

    }
}