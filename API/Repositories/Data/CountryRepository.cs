using API.Context;
using API.Models;
using API.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
    public class CountryRepository : iCountry
    {
        MyContext myContext;
        public CountryRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Create(Countries country)
        {
            myContext.Country.Add(country);
            int result = myContext.SaveChanges();
            return result;
        }

        public int Delete(int id)
        {
            var data = myContext.Country.Find(id);
            if (data == null)
            {
                return -1;
            }

            myContext.Country.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Edit(int id, Countries country)
        {
            var data = myContext.Country.Find(id);
            if (data == null)
            {
                return -1;
            }
            data.CountryName = country.CountryName;

            var result = myContext.SaveChanges();
            return result;
        }

        public List<Countries> Get()
        {
            var data = myContext.Country.ToList();
            return data;
        }

        public Countries GetDetail(int id)
        {
            var country = myContext.Country.FirstOrDefault(option => option.Id.Equals(id));
            return country;
        }
    }
}
