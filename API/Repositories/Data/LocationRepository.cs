using API.Context;
using API.Models;
using API.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
    public class LocationRepository : iLocation
    {
        MyContext myContext;
        public LocationRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Create(Locations location)
        {
            myContext.Location.Add(location);
            int result = myContext.SaveChanges();
            return result;
        }

        public int Delete(int id)
        {
            var data = myContext.Location.Find(id);
            if (data == null)
            {
                return -1;
            }

            myContext.Location.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Edit(int id, Locations location)
        {
            var data = myContext.Location.Find(id);
            if (data == null)
            {
                return -1;
            }
            data.StreetAddress = location.StreetAddress;

            var result = myContext.SaveChanges();
            return result;
        }

        public List<Locations> Get()
        {
            var data = myContext.Location.ToList();
            return data;
        }

        public Locations GetDetail(int id)
        {
            var location = myContext.Location.FirstOrDefault(option => option.Id.Equals(id));
            return location;
        }

       
    }
}
