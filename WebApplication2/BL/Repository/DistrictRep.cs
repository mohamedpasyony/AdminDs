using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.DBL;
using WebApplication2.Models;

namespace WebApplication2.BL.Repository
{
    public class DistrictRep:IDistrictRep
    {
        private readonly DatabaseContainer DB1;
        public DistrictRep(DatabaseContainer DB1)
        {
            this.DB1 = DB1;
        }



        public IQueryable<DistrictVM> Get()
        {

            var Data = DB1.District.Select(a => new DistrictVM { id = a.id, DistrictName = a.DistrictName, CityId = a.CityId });
            return Data;
        }


        public DistrictVM getById(int id)
        {
            var Data = DB1.District.Where(a => a.id == id).
                Select(a => new DistrictVM { id = a.id, DistrictName = a.DistrictName, CityId = a.CityId }).FirstOrDefault();
            return Data;
        }
    }
}
