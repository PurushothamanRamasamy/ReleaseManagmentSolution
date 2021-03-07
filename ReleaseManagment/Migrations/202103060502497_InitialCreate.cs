namespace ReleaseManagment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bugs",
                c => new
                    {
                        Module_Id = c.String(nullable: false, maxLength: 128),
                        Module_Name = c.String(maxLength: 128),
                        Bug_Status = c.Boolean(nullable: false),
                        Bug_Description = c.String(),
                    })
                .PrimaryKey(t => t.Module_Id)
                .ForeignKey("dbo.Modules", t => t.Module_Name)
                .Index(t => t.Module_Name);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        Module_Name = c.String(nullable: false, maxLength: 128),
                        Project_Id = c.String(maxLength: 128),
                        Assign_Dev_Id = c.String(maxLength: 128),
                        Assign_Tester_Id = c.String(maxLength: 128),
                        Status_Dev = c.Boolean(nullable: false),
                        Status_Tester = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Module_Name)
                .ForeignKey("dbo.EmployeeDetails", t => t.Assign_Dev_Id)
                .ForeignKey("dbo.EmployeeDetails", t => t.Assign_Tester_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Project_Id)
                .Index(t => t.Assign_Dev_Id)
                .Index(t => t.Assign_Tester_Id);
            
            CreateTable(
                "dbo.EmployeeDetails",
                c => new
                    {
                        Employee_Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Employee_Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Project_Id = c.String(nullable: false, maxLength: 128),
                        Project_Name = c.String(),
                        Manager_Id = c.String(maxLength: 128),
                        TeamLead_Id = c.String(maxLength: 128),
                        Expected_Start_Date = c.DateTime(nullable: false),
                        Expected_End_Date = c.DateTime(nullable: false),
                        Actual_Start_Date = c.DateTime(nullable: false),
                        Actual_End_Date = c.DateTime(nullable: false),
                        No_Of_Modules = c.String(),
                    })
                .PrimaryKey(t => t.Project_Id)
                .ForeignKey("dbo.EmployeeDetails", t => t.Manager_Id)
                .ForeignKey("dbo.EmployeeDetails", t => t.TeamLead_Id)
                .Index(t => t.Manager_Id)
                .Index(t => t.TeamLead_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bugs", "Module_Name", "dbo.Modules");
            DropForeignKey("dbo.Modules", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Projects", "TeamLead_Id", "dbo.EmployeeDetails");
            DropForeignKey("dbo.Projects", "Manager_Id", "dbo.EmployeeDetails");
            DropForeignKey("dbo.Modules", "Assign_Tester_Id", "dbo.EmployeeDetails");
            DropForeignKey("dbo.Modules", "Assign_Dev_Id", "dbo.EmployeeDetails");
            DropIndex("dbo.Projects", new[] { "TeamLead_Id" });
            DropIndex("dbo.Projects", new[] { "Manager_Id" });
            DropIndex("dbo.Modules", new[] { "Assign_Tester_Id" });
            DropIndex("dbo.Modules", new[] { "Assign_Dev_Id" });
            DropIndex("dbo.Modules", new[] { "Project_Id" });
            DropIndex("dbo.Bugs", new[] { "Module_Name" });
            DropTable("dbo.Projects");
            DropTable("dbo.EmployeeDetails");
            DropTable("dbo.Modules");
            DropTable("dbo.Bugs");
        }
    }
}
