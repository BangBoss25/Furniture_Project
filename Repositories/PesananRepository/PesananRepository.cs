﻿using Furniture_Project.Data;
using Furniture_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture_Project.Repositories.PesananRepository
{
    public class PesananRepository : IPesananRepository
    {
        private readonly AppDbContext _context;

        public PesananRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pemesanan>> AmbilSemuaPesananAsync()
        {
            return await _context.Tb_Pemesanan.ToListAsync();
        }

        public async Task<bool> BuatPesananAsync(Pemesanan data)
        {
            _context.Add(data);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
