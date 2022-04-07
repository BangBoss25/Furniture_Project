using Furniture_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture_Project.Services.PesananService
{
    public interface IPesananService
    {
        List<Pemesanan> AmbilSemuaPesanan();
        bool BuatPesanan(string Username, int id, int jumlah);
    }
}
