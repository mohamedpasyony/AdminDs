using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.DBL
{
    public class Department
    {
        public int id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public virtual ICollection<employee> Employees { get; set; }
    }
}
