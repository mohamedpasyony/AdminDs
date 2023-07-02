using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.BL
{
  public  interface ICityRep
    {
        IQueryable<CityVM> Get();
        CityVM getById(int id);
    }
}
