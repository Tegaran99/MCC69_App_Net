using System;
using API.Models;
using API.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    interface iDepartment
    {
        List<Departments> Get();
        Departments GetDetail(int id);
        int Create(Departments department);
        int Edit(int id, Departments department);
        int Delete(int id);
    }
}
