﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
    [Authorize]
    public class DetalleController : Controller
    {
        private readonly IDetalleRepository _detalleRepository;
        private readonly AppDbContext _appDbContext;

        public DetalleController(AppDbContext appDbContext, IDetalleRepository detalleRepository)
        {
            _appDbContext = appDbContext;
            _detalleRepository = detalleRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Detalle detalle)
        {
            if (ModelState.IsValid)
            {
                _detalleRepository.AddDetalle(detalle);
            }
            return Json(detalle);
        }



    }
}