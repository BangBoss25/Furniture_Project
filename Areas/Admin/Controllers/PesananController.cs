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

namespace Furniture_Project.Areas.Admin.Controllers
{
    [Authorize (Roles = "Admin")]
    [Area ("Admin")]
    public class PesananController : Controller
    {
        private readonly IBarangService _brgServ;
        private readonly IPesananService _psnServ;
        private object search;

        public PesananController(IBarangService brgServ, IPesananService psnServ)
        {
            _brgServ = brgServ;
            _psnServ = psnServ;
        }

        public IActionResult Index()
        {
            var allData = new PesananDashboard();

            allData.barang = _brgServ.AmbilSemuaBarang();
            allData.pemesanan = _psnServ.AmbilSemuaPesanan();

            return View(allData);
        }
    }
}
