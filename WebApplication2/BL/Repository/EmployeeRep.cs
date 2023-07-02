using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.BL.Helper;
using WebApplication2.DBL;
using WebApplication2.Models;

namespace WebApplication2.BL.Repository
{
    public class EmployeeRep:IEmplyoeeRep
    {
        private readonly DatabaseContainer DB1;
        private readonly IMapper mapper;
        public EmployeeRep(DatabaseContainer DB1, IMapper mapper)
        {
            this.DB1 = DB1;
            this.mapper = mapper;
        }



        public IQueryable<EmployeeVM> Get()
        {

            var Data = DB1.employees.Select(a => new EmployeeVM { id = a.id, Name = a.Name, Salary = a.Salary, Aderess = a.Aderess, Email = a.Email, HireDate = a.HireDate, IsActive = a.IsActive, Notes = a.Notes,DepartmentName=a.department.DepartmentName, Departmentid = a.Departmentid, DistrictId=a.DistrictId, DistrictName=a.District.DistrictName, PhotoName=a.PhotoName, DocName=a.DocName });
            return Data;
        }
        public void add(EmployeeVM Emp)
        {
            //old way mapping.
            //Department d = new Department();
            //d.DepartmentName = dep.DepartmentName;
            //d.DepartmentCode = dep.DepartmentCode;
           


            //using auto mapper.
            var Data = mapper.Map<employee>(Emp);
           Data.PhotoName=  UploadFileHelper.SaveFile(Emp.PhotoUrl, "Photos");
           Data.DocName= UploadFileHelper.SaveFile(Emp.DocUrl, "Docs");


            DB1.employees.Add(Data);
            DB1.SaveChanges();

        }



        public EmployeeVM getById(int id)
        {
            var Data = DB1.employees.Where(a => a.id == id).
                Select(a => new EmployeeVM { id = a.id, Name = a.Name, Salary = a.Salary, Aderess = a.Aderess, Email = a.Email, HireDate = a.HireDate, IsActive = a.IsActive, Notes = a.Notes, DepartmentName = a.department.DepartmentName, Departmentid = a.Departmentid, DistrictId = a.DistrictId, DistrictName = a.District.DistrictName, PhotoName = a.PhotoName, DocName = a.DocName }).FirstOrDefault();
            return Data;
        }

        public void Edit(EmployeeVM Emp)
        {
            //var oldData = DB1.departments.Find(Dep.id);
            //oldData.DepartmentName = Dep.DepartmentName;
            //oldData.DepartmentCode = Dep.DepartmentCode;
            var Data = mapper.Map<employee>(Emp);

            //replace old data with new Data depend on id
            DB1.Entry(Data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            DB1.SaveChanges();
        }

        public void Delete(int id)
        {
            var Data = DB1.employees.Find(id);
            DB1.employees.Remove(Data);
            UploadFileHelper.DeleteFile("Photos/", Data.PhotoName);
            UploadFileHelper.DeleteFile("Docs/", Data.DocName);

            DB1.SaveChanges();

        }

       
    }
}
