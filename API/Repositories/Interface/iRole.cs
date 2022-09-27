using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    interface iRole
    {
        List<Role> Get();
        Role GetDetail(int id);
        int Create(Role role);
        int Edit(int id, Role role);
        int Delete(int id);
    }
}
