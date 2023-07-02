using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.BL;
using WebApplication2.BL.Helper;
using WebApplication2.DBL;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmplyoeeRep Employee;
        private IDepartmentRep dep;
        private ICountryRep Country;
        private ICityRep City;
        private IDistrictRep District;



        public EmployeeController(IEmplyoeeRep Employee , IDepartmentRep dep, ICountryRep Country, ICityRep City, IDistrictRep District)
        {
            this.Employee = Employee;
            this.dep = dep;
            this.Country = Country;
            this.City = City;
            this.District = District;

        }

        public IActionResult Index()
        {
            var Data = Employee.Get();
            return View(Data);

        }
        public IActionResult Create()
        {
            var Data = dep.Get();
                ViewBag.DepartmentList = new SelectList(Data, "id", "DepartmentName");

            var CountryData = Country.Get();
            ViewBag.CountryList = new SelectList(CountryData, "id", "CountryName");

            return View();
        }


        [HttpPost]
        public IActionResult Create(EmployeeVM Emp)
        {
            if (ModelState.IsValid)
            {
                Employee.add(Emp);
                return RedirectToAction("Index", "Employee");
            }
            var Data = dep.Get();
            ViewBag.DepartmentList = new SelectList(Data, "id", "DepartmentName", Emp.Departmentid);
            return View(Emp);

        }
        public IActionResult Edit(int id)
        {
           
            var Data = Employee.getById(id);
            var Data2 = dep.Get();
            var Data3 = District.Get();

            ViewBag.DepartmentList = new SelectList(Data2, "id", "DepartmentName",Data.Departmentid);
            ViewBag.DistrictList = new SelectList(Data3, "id", "DistrictName", Data.DistrictId);

            return View(Data);

           
        }
        [HttpPost]
        public IActionResult Edit(EmployeeVM Emp)
        {

            if (ModelState.IsValid)
            {
                Employee.Edit(Emp);
                return RedirectToAction("Index", "Employee");
            }
            var Data2 = dep.Get();
            ViewBag.DepartmentList = new SelectList(Data2, "id", "DepartmentName", Emp.Departmentid);

            return View(Emp);
        }
        public IActionResult delete(int id)
        {
            var Data = Employee.getById(id);

            return View(Data);
        }
       [ActionName("delete")]
        [HttpPost]
        public IActionResult deletePost(int id)
        {
            Employee.Delete(id);
           return RedirectToAction("Index", "Employee");
          
        }
        //-------AJAX-----------
        [HttpPost]
        public JsonResult GetCityByCountryId(int countryid)
        {
            var Data = City.Get().Where(a => a.CountryId == countryid);

            return Json(Data);
        }
        [HttpPost]

        public JsonResult GetDistrictByCityId(int cityid)
        {
            var Data = District.Get().Where(a => a.CityId == cityid);

            return Json(Data);
        }


    }
}