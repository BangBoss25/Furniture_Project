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

        //USER
        Task<List<User>> AmbilSemuaUserAsync();
        Task<User> AmbilUserByUsernameAsync(string username);

        //ROLES
        Task<List<Roles>> AmbilSemuaRolesAsync();
        Task<Roles> AmbilRolesByIdAsync(string id);
    }
}
