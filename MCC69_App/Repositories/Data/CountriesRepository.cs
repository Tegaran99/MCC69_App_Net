using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLIENT.Repositories.Data
{
    public class CountriesRepository : GeneralRepository<Country>
    {
        public CountriesRepository(string request = "Country/") : base(request)
        {

        }
    }
}