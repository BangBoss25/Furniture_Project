using Furniture_Project.Models;
using Furniture_Project.Repositories.BarangRepository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture_Project.Services.BarangService
{
    public class BarangService : IBarangService
    {
        private readonly IBarangRepository _repo;
        private readonly FileService _file;

        public BarangService(IBarangRepository r, FileService f)
        {
            _repo = r;
            _file = f;
        }

        public Barang AmbilBarangById(int Id)
        {
            return _repo.AmbilBarangByIdAsync(Id).Result;
        }

        public List<Barang> AmbilSemuaBarang()
        {
            return _repo.AmbilSemuaBarang().Result;
        }

        public bool BuatBarang(Barang data, IFormFile Image)
        {
            data.Image = _file.SaveFile(Image).Result;
            data.Terjual = 0;

            return _repo.BuatBarangAsync(data).Result;
        }

        public bool HapusBarang(int id)
        {
            var brg = _repo.CariBarangAsync(id).Result;

            return _repo.HapusBarangAsync(brg).Result;
        }

        public bool UbahBarang(Barang fromView, IFormFile Image)
        {
            var brg = _repo.CariBarangAsync(fromView.Id).Result;

            if (brg != null)
            {
                brg.NamaBarang = fromView.NamaBarang;
                brg.Stok = fromView.Stok;
                brg.Harga = fromView.Harga;
                brg.Deskripsi = fromView.Deskripsi;

                if (Image != null)
                    brg.Image = _file.SaveFile(Image).Result;
                else
                    brg.Image = brg.Image;

                return _repo.UbahBarangAsync(brg).Result;
            }
            return false;
        }
    }
}
