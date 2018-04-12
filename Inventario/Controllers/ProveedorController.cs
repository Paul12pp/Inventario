using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Models;
using Inventario.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Controllers
{
    [Authorize]
    public class ProveedorController : Controller
    {
        private readonly IProveedorRepository _proveedorRepository;

        private readonly AppDbContext _appDbContext;

        public ProveedorController(AppDbContext appDbContext, IProveedorRepository proveedorRepository)
        {
            _appDbContext = appDbContext;
            _proveedorRepository = proveedorRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Proveedor overview";
            return View();
        }

        private bool ProveedorExists(int id)
        {

            return _appDbContext.Proveedores.Any(e => e.ProveedorId == id);

        }

        /// <summary>
        /// Metodo get
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                _proveedorRepository.AddProveedor(proveedor);
                return RedirectToAction("ProveedorComplete");

            }
            return View(proveedor);
        }

        public IActionResult ProveedorComplete()
        {
            return View();
        }

        /// <summary>
        /// metodo get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedores = await _appDbContext.Proveedores.SingleOrDefaultAsync(m => m.ProveedorId == id);
            if (proveedores == null)
            {
                return NotFound();
            }
            return View(proveedores);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("ProveedorId,Name,LastName,IdentificationCard,PhoneNumber,Address,Email")] Proveedor proveedor)
        {
            if (id != proveedor.ProveedorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _appDbContext.Update(proveedor);
                    await _appDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProveedorExists(proveedor.ProveedorId))
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
            return View(proveedor);
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
            if (id == null)
            {
                return NotFound();
            }

            var proveedores = await _appDbContext.Proveedores
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ProveedorId == id);
            if (proveedores == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(proveedores);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proveedores = await _appDbContext.Proveedores
                .SingleOrDefaultAsync(m => m.ProveedorId == id);
            if (proveedores == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _appDbContext.Proveedores.Remove(proveedores);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction("List");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        public IActionResult List()
        {
            ViewBag.Title = "Proveedores overview";

            var proveedores = _proveedorRepository.GetAllProveedores().OrderBy(c => c.Name);

            var proveedorViewModel = new ProveedorViewModel()
            {
                Proveedores = proveedores.ToList(),
                Title = "Lista de proveedores"
            };
            return View(proveedorViewModel);
        }

        // GET: api/authors
        [HttpGet]
        [ActionName("ObtenerProveedor")]
        public JsonResult Get()
        {
            return Json(_proveedorRepository.GetAllProveedores());
        }
    }
}