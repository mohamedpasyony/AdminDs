using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.BL
{
   public interface IEmplyoeeRep
    {
        IQueryable<EmployeeVM> Get();
        void add(EmployeeVM Emp);
        EmployeeVM getById(int id);
        void Edit(EmployeeVM Emp);
        void Delete(int id);
    }
}
