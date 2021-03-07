using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReleaseManagment.Models
{
    [Bind(Exclude = "Employee_Id,Role")]
    
    public class EmployeeDetails
    {
        [ScaffoldColumn(false)]
        [Key]
        public string Employee_Id{ get; set; }

        [DisplayName("EmployeeName")]
        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(100, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password{ get; set; }

        [ScaffoldColumn(false)]
        public string Role { get; set; }

        ICollection<Module> modules { get; set; }
        ICollection<Projects> projects { get; set; }
    }
}