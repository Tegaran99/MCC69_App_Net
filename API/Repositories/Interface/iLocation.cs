using System;
using API.Models;
using API.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    interface iLocation
    {
        List<Locations> Get();
        Locations GetDetail(int id);
        int Create(Locations region);
        int Edit(int id, Locations region);
        int Delete(int id);
    }
}
