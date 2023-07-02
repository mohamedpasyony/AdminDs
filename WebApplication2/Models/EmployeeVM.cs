using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace WebApplication2.Models
{
    public class EmployeeVM
    {
        public int id { get; set; }
        [Required(ErrorMessage ="*EnterName")]
        public String Name { get; set; }
        [Required(ErrorMessage = "*EnterSalary")]
        [Range(2000,10000,ErrorMessage ="Salary must be between(2000-10000 LE)")]
        public float Salary { get; set; }
        [Required(ErrorMessage = "*EnterAdress")]
        public String Aderess { get; set; }
        [Required]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$",ErrorMessage ="Enter Email Like: Example@gmail.com")]
        public String Email { get; set; }
        [Required(ErrorMessage = "*EnterHireDate")]
        public DateTime HireDate { get; set; }
        public String Notes { get; set; }
        [Required(ErrorMessage ="*")]
        public bool IsActive { get; set; }
        [Required(ErrorMessage ="*DepartmentName is required")]
        public int Departmentid { get; set; }
        [Required(ErrorMessage = "*DepartmentName is required")]
        public int DistrictId { get; set; }
        public String DistrictName { get; set; }
        public string DepartmentName{ get; set; }
        public string PhotoName{ get; set; }
        public string DocName { get; set; }
        [Required(ErrorMessage = "*Photo is required")]
        public IFormFile PhotoUrl { get; set; }
        [Required(ErrorMessage = "*CV is required")]
        public IFormFile DocUrl { get; set; }






    }
}
