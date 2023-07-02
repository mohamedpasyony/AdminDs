using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.DBL;
using WebApplication2.Models;

namespace WebApplication2.BL.Repository
{
    public class CityRep:ICityRep
    {
        private readonly DatabaseContainer DB1;
        public CityRep(DatabaseContainer DB1)
        {
            this.DB1 = DB1;
        }



        public IQueryable<CityVM> Get()
        {

            var Data = DB1.City.Select(a => new CityVM { id=a.id ,CityName=a.CityName,CountryId=a.CountryId });
            return Data;
        }


        public CityVM getById(int id)
        {
            var Data = DB1.City.Where(a => a.id == id).
                Select(a => new CityVM { id = a.id, CityName = a.CityName, CountryId = a.CountryId }).FirstOrDefault();
            return Data;
        }

    }
}
