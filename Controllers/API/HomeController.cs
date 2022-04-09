//using Furniture_Project.Helper;
//using Furniture_Project.Models;
//using Furniture_Project.Services.AkunService;
//using Furniture_Project.Services.BarangService;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Furniture_Project.Controllers.API
//{
//    [Route("api/[controller]")]
//    public class HomeController : Controller
//    {
//        private readonly IBarangService _brgServ;
//        private readonly IAkunService _akSer;

//        private BanyakBantuan _bantu = new();

//        private object _resp;
//        private object _objk;

//        private Barang _brg;
//        private string brg = "Barang";
//        private string user = "User";
//        private string roles = "Roles";

//        public HomeController(IBarangService brgServ, IAkunService akSer)
//        {
//            _brgServ = brgServ;
//            _akSer = akSer;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        [Route("barang")]
//        public IActionResult Barang()
//        {
//            _objk = _brgServ.AmbilSemuaBarang();

//            _resp = _bantu.ResponAPI(_bantu.CodeOk, _bantu.PesanGetSukses(brg), _objk);

//            return Ok(_resp);
//        }

//        [Route("barang")]
//        [HttpPost]
//        public IActionResult TambahBarang(Barang barang, IFormFile image)
//        {
//            if (ModelState.IsValid)
//            {
//                _brgServ.BuatBarang(barang, image);

//                _resp = _bantu.ResponAPI(_bantu.CodeOk, _bantu.PesanTambahSukses(brg), null);
//                return Ok(_resp);
//            }
//            _resp = _bantu.ResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(brg), null);
//            return Ok(_resp);
//        }

//        [Route("barang")]
//        [HttpPut]
//        public IActionResult UbahBarang(Barang parameter, IFormFile Image)
//        {
//            if (ModelState.IsValid)
//            {
//                _brg = _brgServ.AmbilBarangById(parameter.Id);
//                if (_brg != null)
//                {
//                    _brgServ.UbahBarang(parameter, Image);

//                    _brg = _brgServ.AmbilBarangById(parameter.Id);

//                    _resp = _bantu.ResponAPI(_bantu.CodeOk, _bantu.PesanUbahSukses(brg), _brg);
//                    return Ok(_resp);
//                }
//                _resp = _bantu.ResponAPI(_bantu.CodeInternalServerError, _bantu.PesanTidakDitemukan(brg), null);
//                return Ok(_resp);
//            }
//            _resp = _bantu.ResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(brg), null);
//            return Ok(_resp);
//        }

//        [Route("barang/{id}")]
//        [HttpDelete]
//        public IActionResult HapusBarang(int id)
//        {
//            try
//            {
//                _brg = _brgServ.AmbilBarangById(id);

//                if(_brg != null)
//                {
//                    _brgServ.HapusBarang(id);

//                    _resp = _bantu.ResponAPI(_bantu.CodeOk, _bantu.PesanHapusSukses(brg), _brg);
//                    return Ok(_resp);
//                }
//                _resp = _bantu.ResponAPI(_bantu.CodeInternalServerError, _bantu.PesanTidakDitemukan(brg), null);
//                return Ok(_resp);
//            }
//            catch
//            {
//                _resp = _bantu.ResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(brg), null);
//                return Ok(_resp);
//            }
//        }

//        [Route("barang/{id}")]
//        public IActionResult DetailBlog(int id)
//        {
//            _brg = _brgServ.AmbilBarangById(id);

//            if (_brg != null)
//            {
//                _resp = _bantu.ResponAPI(_bantu.CodeOk, _bantu.PesanGetSukses(brg), _brg);
//                return Ok(_resp);
//            }

//            _resp = _bantu.ResponAPI(_bantu.CodeBadRequest, _bantu.PesanTidakDitemukan(brg), null);
//            return Ok(_resp);
//        }

//        //// User
//        [Route("user")]
//        public IActionResult Pengguna()
//        {
//            _objk = _akSer.AmbilSemuaUser();

//            _resp = _bantu.ResponAPI(_bantu.CodeOk, _bantu.PesanGetSukses(user), _objk);
//            return Ok(_resp);
//        }


//        //// Roles
//        [Route("roles")]
//        public IActionResult Roles()
//        {
//            _objk = _akSer.AmbilSemuaRoles();

//            _resp = _bantu.ResponAPI(_bantu.CodeOk, _bantu.PesanGetSukses(roles), _objk);
//            return Ok(_resp);
//        }
//    }
//}
