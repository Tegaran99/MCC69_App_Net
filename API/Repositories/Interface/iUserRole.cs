using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    interface iUserRole
    {
        List<UserRole> Get();
        UserRole GetDetail(int id);
        int Create(UserRole userRole);
        int Edit(int id, UserRole userRole);
        int Delete(int id);
    }
}
