using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.BL;
using WebApplication2.BL.Repository;
using WebApplication2.DBL;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DepartmentController : Controller
    {
        // loosly coubled
        private IDepartmentRep rep;

       public DepartmentController (IDepartmentRep rep)
        {
            this.rep = rep;
        
        }

        public IActionResult Index()
        {
            var Data = rep.Get();
            return View(Data);
                
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(DepartmentVM dep)
        {
            if (ModelState.IsValid)
            {
                rep.add(dep);
                return RedirectToAction("Index", "Department");
            }
            return View(dep);

        }
        public IActionResult Edit(int id)
        {
           var Data= rep.getById(id);
            return View(Data);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentVM Dep)
        {

            if (ModelState.IsValid)
            {
                rep.Edit(Dep);
                return RedirectToAction("Index", "Department");
            }
            return View(Dep);
        }
        public IActionResult delete(int id)
        {
            var Data = rep.getById(id);

            return View(Data);
        }


        [ActionName("delete")]
        [HttpPost]
        public IActionResult deletePost(int id)
        {
            rep.Delete(id);
            return RedirectToAction("Index", "Department");

        }


    }
  
}