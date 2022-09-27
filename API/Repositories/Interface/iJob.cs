using System;
using API.Models;
using API.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.Repositories.Interface
{
    interface iJob
    {
        List<Jobs> Get();
        Jobs GetDetail(int id);
        int Create(Jobs job);
        int Edit(int id, Jobs job);
        int Delete(int id);
    }
}
