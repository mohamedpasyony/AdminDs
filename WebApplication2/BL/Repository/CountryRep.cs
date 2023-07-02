using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.DBL;
using WebApplication2.Models;

namespace WebApplication2.BL.Repository
{
    public class CountryRep: ICountryRep
    {

        private readonly DatabaseContainer DB1;
        public CountryRep(DatabaseContainer DB1 )
        {
            this.DB1 = DB1;
        }



        public IQueryable<CountryVM> Get()
        {

            var Data = DB1.Country.Select(a => new CountryVM { id = a.id, CountryName=a.CountryName});
            return Data;
        }
      

        public CountryVM getById(int id)
        {
            var Data = DB1.Country.Where(a => a.id == id).
                Select(a => new CountryVM { id = a.id, CountryName = a.CountryName }).FirstOrDefault();
            return Data;
        }

    }
}
