using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.DBL;
using WebApplication2.Models;

namespace WebApplication2.BL.Repository
{
    public class DepartmentRep : IDepartmentRep
    {

        private readonly DatabaseContainer DB1;
         private readonly IMapper mapper;
       public  DepartmentRep (DatabaseContainer DB1,IMapper mapper)
        {
            this.DB1 = DB1;
            this.mapper = mapper;
        }



        public IQueryable<DepartmentVM> Get()
        {
           
            var Data = DB1.departments.Select(a => new DepartmentVM { id = a.id, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode });
            return Data;
        }
        public void add(DepartmentVM dep)
        {
            //old way mapping.
            //Department d = new Department();
            //d.DepartmentName = dep.DepartmentName;
            //d.DepartmentCode = dep.DepartmentCode;


            //using auto mapper.
            var Data = mapper.Map<Department>(dep);
            DB1.departments.Add(Data);
            DB1.SaveChanges();

        }

      

        public DepartmentVM getById(int id)
        {
            var Data = DB1.departments.Where(a => a.id == id).
                Select(a => new DepartmentVM { id = a.id, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode }).FirstOrDefault();
            return Data;
        }

        public void Edit(DepartmentVM Dep)
        {
            //var oldData = DB1.departments.Find(Dep.id);
            //oldData.DepartmentName = Dep.DepartmentName;
            //oldData.DepartmentCode = Dep.DepartmentCode;
          var Data=  mapper.Map<Department>(Dep);

            //replace old data with new Data depend on id
            DB1.Entry(Data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            DB1.SaveChanges();
        }

        public void Delete(int id)
        {
          var Data=  DB1.departments.Find(id);
            DB1.departments.Remove(Data);
            DB1.SaveChanges();

        }
    }
}
