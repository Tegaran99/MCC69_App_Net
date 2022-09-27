using System;
using API.Models;
using API.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    interface iCountry
    {
        List<Countries> Get();
        Countries GetDetail(int id);
        int Create(Countries country);
        int Edit(int id, Countries country);
        int Delete(int id);
    }
}
