using Furniture_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture_Project.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Roles> Tb_Roles { get; set; }
        public DbSet<User> Tb_User { get; set; }
        public DbSet<Barang> Tb_Barang { get; set; }
        public DbSet<Pemesanan> Tb_Pemesanan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // isi tabel roles
            modelBuilder.Entity<Roles>().HasData(new Roles[]
            {
                new Roles
                {
                    Id = "1",
                    Name = "Admin"
                },
                new Roles
                {
                    Id = "2",
                    Name ="User"
                }
            });
        }
    }
}
