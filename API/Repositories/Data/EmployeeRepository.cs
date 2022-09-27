using API.Context;
using API.Models;
using API.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
    public class EmployeeRepository : iEmployee
    {
        MyContext myContext;
        public EmployeeRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public object Employee { get; internal set; }

        public int Create(Employees employee)
        {
            myContext.Employee.Add(employee);
            int result = myContext.SaveChanges();
            return result;
        }

        public int Delete(int id)
        {
            var data = myContext.Employee.Find(id);
            if (data == null)
            {
                return -1;
            }

            myContext.Employee.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Edit(int id, Employees employee)
        {
            var data = myContext.Employee.Find(id);
            if (data == null)
            {
                return -1;
            }
            data.FirstName = employee.FirstName;

            var result = myContext.SaveChanges();
            return result;
        }

        public List<Employees> Get()
        {
            var data = myContext.Employee.ToList();
            return data;
        }

        public Employees GetDetail(int id)
        {
            var department = myContext.Employee.FirstOrDefault(option => option.Id.Equals(id));
            return department;
        }
    }
}
