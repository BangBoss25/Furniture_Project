using Furniture_Project.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture_Project.Services.BarangService
{
    public interface IBarangService
    {
        List<Barang> AmbilSemuaBarang();
        Barang AmbilBarangById(int Id);
        bool BuatBarang(Barang data, IFormFile Image);
        bool HapusBarang(int id);
        bool UbahBarang(Barang fromView, IFormFile Image);
    }
}
