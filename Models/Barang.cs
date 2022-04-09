using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture_Project.Models
{
    public class Barang
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-z A-Z]*$", ErrorMessage = "Hanya Input Huruf")]
        public string NamaBarang { get; set; }
        public string Image { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Harus Angka")]
        public int Stok { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Harus Angka")]
        public int Harga { get; set; }
        public int Terjual { get; set; }
        [Required]
        public string Deskripsi { get; set; }
    }
}
