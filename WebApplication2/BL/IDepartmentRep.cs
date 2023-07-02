using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.BL
{
   
       public interface IDepartmentRep
    {
        IQueryable<DepartmentVM> Get();
        void add(DepartmentVM dep);
        DepartmentVM getById(int id);
        void Edit(DepartmentVM Dep);
        void Delete(int id);
    }
}

