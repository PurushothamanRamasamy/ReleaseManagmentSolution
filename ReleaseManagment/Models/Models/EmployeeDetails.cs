using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReleaseManagment.Models
{
    public class EmployeeDetails
    {
        [Key]
        public string Employee_Id{ get; set; }
        public string UserName { get; set; }
        public string Password{ get; set; }
        public string Role { get; set; }

        ICollection<Module> modules { get; set; }
        ICollection<Projects> projects { get; set; }
    }
}