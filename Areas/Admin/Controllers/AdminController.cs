using Furniture_Project.Models;
using Furniture_Project.Services.AkunService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture_Project.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IAkunService _akunServ;

        public AdminController(IAkunService akunServ)
        {
            _akunServ = akunServ;
        }

        public IActionResult Index()
        {
            var all = new penggunaDashboard();

            all.user = _akunServ.AmbilSemuaUser();
            all.roles = _akunServ.AmbilSemuaRoles();

            return View(all);
        }
    }
}
