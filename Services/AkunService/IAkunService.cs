using Furniture_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture_Project.Services.AkunService
{
    public interface IAkunService
    {
        bool DaftarUser(User data);
        bool HapusAkun(string username);

        //USER
        List<User> AmbilSemuaUser();
        User AmbilUserByUsername(string username);
        bool DaftarAdmin(User data);

        //ROLES
        List<Roles> AmbilSemuaRoles();
        Roles AmbilRolesById(string id);
    }
}
