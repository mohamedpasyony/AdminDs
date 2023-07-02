using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.BL
{
   public interface ICountryRep
    {
        IQueryable<CountryVM> Get();
        CountryVM getById(int id);
    }
}
