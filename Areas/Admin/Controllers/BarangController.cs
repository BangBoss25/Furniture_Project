using Furniture_Project.Models;
using Furniture_Project.Services.BarangService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture_Project.Areas.Admin.Controllers
{
    [Authorize (Roles = "Admin")]
    [Area ("Admin")]
    public class BarangController : Controller
    {
        private readonly IBarangService _service;
        private object search;

        public BarangController(IBarangService serv)
        {
            _service = serv;
        }

        public IActionResult Index()
        {
            search = _service.AmbilSemuaBarang();

            return View(search);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Barang brg, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                _service.BuatBarang(brg, Image);

                return RedirectToAction("Index");
            }

            return View(brg);
        }

        public IActionResult Update(int Id)
        {
            search = _service.AmbilBarangById(Id);

            if (search != null)
            {
                return View(search);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Update(Barang brg, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                search = _service.AmbilBarangById(brg.Id);

                if (search != null)
                {
                    _service.UbahBarang(brg, Image);

                    return RedirectToAction("Index");
                }
                return NotFound();
            }
            return View(brg);
        }

        public IActionResult Delete(int Id)
        {
            search = _service.AmbilBarangById(Id);

            if (search != null)
            {
                _service.HapusBarang(Id);

                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
