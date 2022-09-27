using API.Context;
using API.Models;
using API.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
    public class DepartmentRepository : iDepartment
    {
        MyContext myContext;
        public DepartmentRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Create(Departments department)
        {
            myContext.Department.Add(department);
            int result = myContext.SaveChanges();
            return result;
        }

        public int Delete(int id)
        {
            var data = myContext.Department.Find(id);
            if (data == null)
            {
                return -1;
            }

            myContext.Department.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Edit(int id, Departments department)
        {
            var data = myContext.Department.Find(id);
            if (data == null)
            {
                return -1;
            }
            data.DepartmentName = department.DepartmentName;

            var result = myContext.SaveChanges();
            return result;
        }

        public List<Departments> Get()
        {
            var data = myContext.Department.ToList();
            return data;
        }

        public Departments GetDetail(int id)
        {
            var department = myContext.Department.FirstOrDefault(option => option.Id.Equals(id));
            return department;
        }
    }
}
