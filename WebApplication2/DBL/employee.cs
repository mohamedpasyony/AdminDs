using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.DBL
{
    public class employee
    {
        public int id { get; set; }

        [StringLength(20)]
        public String Name { get; set; }

        public float Salary { get; set; }
        public String Aderess { get; set; }
        public String Email { get; set; }
        public DateTime HireDate { get; set; }
        public String Notes { get; set; }

        public bool IsActive { get; set; }
        public int Departmentid { get; set; }

        [ForeignKey(" Departmentid")]
        public Department department { get; set; }

        public int DistrictId { get; set; }

        [ForeignKey(" DistrictId")]
        public District District { get; set; }
        public string PhotoName { get; set; }
        public string DocName { get; set; }



    }
}
