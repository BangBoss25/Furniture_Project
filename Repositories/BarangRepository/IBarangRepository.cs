using Furniture_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture_Project.Repositories.BarangRepository
{
    public interface IBarangRepository
    {
        Task<List<Barang>> AmbilSemuaBarang();
        Task<Barang> AmbilBarangByIdAsync(int Id);
        Task<bool> BuatBarangAsync(Barang data);
        Task<bool> HapusBarangAsync(Barang data);
        Task<bool> UbahBarangAsync(Barang data);
        Task<Barang> CariBarangAsync(int Id);
    }
}
