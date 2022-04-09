using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture_Project.Models
{
    public class User
    {
        [Key]
        [Required]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Inputan Hanya Huruf")]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "kalimatnya max 12 minimal 4")]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [DisplayName("Role")]
        public Roles Roles { get; set; }
    }

    public class penggunaDashboard
    {
        public List<User> user { get; set; }
        public List<Roles> roles { get; set; }

        public penggunaDashboard()
        {
            user = new List<User>();
            roles = new List<Roles>();
        }
    }
}
