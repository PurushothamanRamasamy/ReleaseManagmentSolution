using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReleaseManagment.Models;
namespace ReleaseManagment.Controllers
{
    public class HomeController : Controller
    {
        ReleaseManagementContext db = new ReleaseManagementContext();
        // GET: Home
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(EmployeeDetails employeeLoginDetails)
        {
            EmployeeDetails employee = db.EmployeeDetails.FirstOrDefault(emp => emp.UserName == employeeLoginDetails.UserName && emp.Password == employeeLoginDetails.Password);
            if(employee!=null && employee.Role=="Developer")
            {
                return RedirectToAction("ViewDeveloperProjects", new { Emp_Id = employee.Employee_Id });
            }
             
            else
            {
                return View();
            }
        }

        public ActionResult ViewDeveloperProjects(string Emp_Id)
        {
            
            List<Developer> developers = new List<Developer>();
            List<Module> modules = db.Modules.Where(mod => mod.Assign_Dev_Id == Emp_Id).ToList<Module>();
            foreach (var item in modules)
            {
                Developer developer = new Developer();
                Projects project = db.Projects.FirstOrDefault(pro => pro.Project_Id == item.Project_Id);
                List< Bug> bugs = db.Bugs.Where(b => b.Module_Name == item.Module_Name).ToList();
                developer.Project_Id = item.Project_Id;
                developer.Module_Name = item.Module_Name;
                developer.Dev_status = item.Status_Dev;
                developer.Project_Name = project.Project_Name;
                developer.test_Status = item.Status_Tester;
                developer.Bugs_Id.AddRange(bugs.Select(bugid=>bugid.Module_Id).ToList());
                developer.Bug_Description.AddRange(bugs.Select(bugdes => bugdes.Bug_Description).ToList());
                developer.Bug_status.AddRange(bugs.Select(bugsts => bugsts.Bug_Status).ToList());

                developers.Add(developer);
                
            }
            return View(developers);
        }
    }
}