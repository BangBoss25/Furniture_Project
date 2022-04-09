using Furniture_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture_Project.Repositories.AkunRepository
{
    public interface IAkunRepository
    {
        Task<bool> DaftarUserAsync(User data);
        Task<User> CariUserAsync(string Username);
        Task<bool> HapusAkunAsync(User data);

        //USER
        Task<List<User>> AmbilSemuaUserAsync();
        Task<User> AmbilUserByUsernameAsync(string username);
        Task<bool> DaftarAdminAsync(User data);

        //ROLES
        Task<List<Roles>> AmbilSemuaRolesAsync();
        Task<Roles> AmbilRolesByIdAsync(string id);
    }
}
