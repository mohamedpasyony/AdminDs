using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.DBL
{
    public class Country
    {
        public int id { get; set; }
        public string CountryName { get; set; }
        public virtual ICollection<City> City { get; set; }

    }
}
