using Furniture_Project.Helper;
using Furniture_Project.Models;
using Furniture_Project.Services.BarangService;
using Furniture_Project.Services.PesananService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture_Project.Areas.User.Controllers
{
    [Authorize (Roles = "User")]
    [Area ("User")]
    public class HomeController : Controller
    {
        private readonly IBarangService _brgServ;
        private readonly IPesananService _psnServ;

        public HomeController(IBarangService brgSer, IPesananService psnServ)
        {
            _brgServ = brgSer;
            _psnServ = psnServ;
        }

        public IActionResult Index()
        {
            var brg = _brgServ.AmbilSemuaBarang();
            return View(brg);
        }

        [HttpPost]
        public IActionResult AddPesanan(int id, int Jumlah)
        {
            if (ModelState.IsValid)
            {
                _psnServ.BuatPesanan(User.GetUsername(), id, Jumlah);

                return RedirectToAction("Index");
            }

            return RedirectToAction("DetailBarang");
        }

        public IActionResult Detail(int Id)
        {
            Barang search = _brgServ.AmbilBarangById(Id);
            if (search != null)
            {
                return View(search);
            }
            return NotFound();
        }
    }
}
