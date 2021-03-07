using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ReleaseManagment.Models
{
    public class ReleaseManagementContext:DbContext
    {
        public ReleaseManagementContext():base("ConString")
        {

        }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
    }
}