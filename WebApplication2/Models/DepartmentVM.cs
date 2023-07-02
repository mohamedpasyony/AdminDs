using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class DepartmentVM
    {
        public int id { get; set; }
        [Required(ErrorMessage ="*Enter DepartmentName")]
        [MinLength(2,ErrorMessage ="minimum length 2")]
        [MaxLength(5, ErrorMessage ="max length 5")]
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "*Enter DepartmentCode")]
        public string DepartmentCode { get; set; }
    }
}
