using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReleaseManagment.Models
{
    public class Module
    {
        
        public string Project_Id { get; set; }
        [ForeignKey("Project_Id")]
        public Projects projects { get; set; }

        [Key]
        public string Module_Name { get; set; }

        
        public string Assign_Dev_Id { get; set; }
        [ForeignKey("Assign_Dev_Id")]
        public EmployeeDetails employeeDetails { get; set; }

        
        public string Assign_Tester_Id { get; set; }
        [ForeignKey("Assign_Tester_Id")]
        public EmployeeDetails EmployeeDetails{ get; set; }

        public bool Status_Dev { get; set; }

        public bool Status_Tester { get; set; }

        ICollection<Bug> bugs { get; set; }
}
}