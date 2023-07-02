using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.DBL
{
    public class District
    {
        public int id { get; set; }
        public string DistrictName { get; set; }
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }
        public virtual ICollection<employee> employee { get; set; }



    }
}
