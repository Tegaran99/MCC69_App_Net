using System;
using API.Models;
using API.Context;
using API.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    public interface iRegion
    {
        List<Regions> Get();
        Regions GetDetail(int id);
        int Create(Regions region);
        int Edit(int id, Regions region);
        int Delete(int id);

    }
}
