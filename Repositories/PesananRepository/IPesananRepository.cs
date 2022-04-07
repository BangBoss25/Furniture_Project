﻿using Furniture_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture_Project.Repositories.PesananRepository
{
    public interface IPesananRepository
    {
        Task<List<Pemesanan>> AmbilSemuaPesananAsync();
        Task<bool> BuatPesananAsync(Pemesanan data);
    }
}
