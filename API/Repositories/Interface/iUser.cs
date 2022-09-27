using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    interface iUser
    {
        List<User> Get();
        User GetDetail(int id);
        int Create(User user);
        int Edit(int id, User user);
        int Delete(int id);
    }
}
