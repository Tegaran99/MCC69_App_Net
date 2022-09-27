using System;
using API.Models;
using API.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.Repositories.Interface
{
    interface iEmployee
    {
        List<Employees> Get();
        Employees GetDetail(int id);
        int Create(Employees employee);
        int Edit(int id, Employees employee);
        int Delete(int id);
    }
}
