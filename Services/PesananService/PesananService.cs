using Furniture_Project.Models;
using Furniture_Project.Repositories.AkunRepository;
using Furniture_Project.Repositories.BarangRepository;
using Furniture_Project.Repositories.PesananRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture_Project.Services.PesananService
{
    public class PesananService : IPesananService
    {
        private readonly IPesananRepository _pesanRepo;
        private readonly IAkunRepository _akunRepo;
        private readonly IBarangRepository _brgRepo;

        public PesananService(IPesananRepository pesanRepo, IAkunRepository akunRepo, IBarangRepository brgRepo)
        {
            _pesanRepo = pesanRepo;
            _akunRepo = akunRepo;
            _brgRepo = brgRepo;
        }

        public List<Pemesanan> AmbilSemuaPesanan()
        {
            return _pesanRepo.AmbilSemuaPesananAsync().Result;
        }

        public bool BuatPesanan(string Username, int id, int jumlah)
        {
            var ambilData = _brgRepo.AmbilBarangByIdAsync(id).Result;

            var pesanan = new Pemesanan()
            {
                Barang = _brgRepo.AmbilBarangByIdAsync(id).Result,
                Total_pesan = jumlah * ambilData.Harga,
                Jumlah_Pesan = jumlah,
                Tanggal_Pesan = DateTime.Now,
                User = _akunRepo.CariUserAsync(Username).Result
            };

            return _pesanRepo.BuatPesananAsync(pesanan).Result;
        }

        public Pemesanan AmbilPesananById(int Id)
        {
            return _pesanRepo.AmbilPesananByIdAsync(Id).Result;
        }

        public bool HapusPesanan(int Id)
        {
            var psn = _pesanRepo.CariPesananAsync(Id).Result;

            return _pesanRepo.HapusPesananAsync(psn).Result;
        }
    }
}
