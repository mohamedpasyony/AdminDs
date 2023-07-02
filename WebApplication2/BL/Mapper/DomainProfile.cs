using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApplication2.DBL;
using WebApplication2.Models;

namespace WebApplication2.BL.Mapper
{
    public class DomainProfile:Profile
    {

        public DomainProfile()
        {
            CreateMap<Department, DepartmentVM>();
            CreateMap<DepartmentVM, Department>();

            CreateMap<employee, EmployeeVM>();
            CreateMap<EmployeeVM,employee>();


        }
    }
}
