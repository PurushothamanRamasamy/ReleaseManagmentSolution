using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReleaseManagment.Models
{
    public class Projects
    {
        [Key]
        public string Project_Id{ get; set; }
        public string Project_Name{ get; set; }

        
        public string Manager_Id{ get; set; }
        [ForeignKey("Manager_Id")]
        public EmployeeDetails employeeDetails { get; set; }

        public string TeamLead_Id { get; set; }
        [ForeignKey("TeamLead_Id")]
        public EmployeeDetails EmployeeDetails { get; set; }

        public DateTime Expected_Start_Date { get; set; }
        public DateTime Expected_End_Date { get; set; }

        public DateTime Actual_Start_Date { get; set; }
        public DateTime Actual_End_Date { get; set; }

        public string No_Of_Modules { get; set; }

        ICollection<Module> modules { get; set; }
        
        

    }
}