using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture_Project.Models
{
    public class Pemesanan
    {
        [Key]
        public int Id_Pesanan { get; set; }
        public DateTime Tanggal_Pesan { get; set; }
        [Required]
        public int Jumlah_Pesan { get; set; }
        public double Total_pesan { get; set; }
        public Barang Barang { get; set; }
        public User User { get; set; }
    }

    public class PesananDashboard
    {
        public List<Barang> barang { get; set; }
        public List<Pemesanan> pemesanan { get; set; }
        public List<User> user { get; set; }

        public PesananDashboard()
        {
            barang = new List<Barang>();
            pemesanan = new List<Pemesanan>();
            user = new List<User>();
        }
    }
}
