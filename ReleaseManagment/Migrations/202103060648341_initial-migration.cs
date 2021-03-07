namespace ReleaseManagment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Modules", name: "Assign_Dev_Id", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Modules", name: "Assign_Tester_Id", newName: "Assign_Dev_Id");
            RenameColumn(table: "dbo.Projects", name: "Manager_Id", newName: "__mig_tmp__1");
            RenameColumn(table: "dbo.Projects", name: "TeamLead_Id", newName: "Manager_Id");
            RenameColumn(table: "dbo.Modules", name: "__mig_tmp__0", newName: "Assign_Tester_Id");
            RenameColumn(table: "dbo.Projects", name: "__mig_tmp__1", newName: "TeamLead_Id");
            RenameIndex(table: "dbo.Modules", name: "IX_Assign_Tester_Id", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.Modules", name: "IX_Assign_Dev_Id", newName: "IX_Assign_Tester_Id");
            RenameIndex(table: "dbo.Projects", name: "IX_TeamLead_Id", newName: "__mig_tmp__1");
            RenameIndex(table: "dbo.Projects", name: "IX_Manager_Id", newName: "IX_TeamLead_Id");
            RenameIndex(table: "dbo.Modules", name: "__mig_tmp__0", newName: "IX_Assign_Dev_Id");
            RenameIndex(table: "dbo.Projects", name: "__mig_tmp__1", newName: "IX_Manager_Id");
            AlterColumn("dbo.EmployeeDetails", "UserName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.EmployeeDetails", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeDetails", "Password", c => c.String());
            AlterColumn("dbo.EmployeeDetails", "UserName", c => c.String());
            RenameIndex(table: "dbo.Projects", name: "IX_Manager_Id", newName: "__mig_tmp__1");
            RenameIndex(table: "dbo.Modules", name: "IX_Assign_Dev_Id", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.Projects", name: "IX_TeamLead_Id", newName: "IX_Manager_Id");
            RenameIndex(table: "dbo.Projects", name: "__mig_tmp__1", newName: "IX_TeamLead_Id");
            RenameIndex(table: "dbo.Modules", name: "IX_Assign_Tester_Id", newName: "IX_Assign_Dev_Id");
            RenameIndex(table: "dbo.Modules", name: "__mig_tmp__0", newName: "IX_Assign_Tester_Id");
            RenameColumn(table: "dbo.Projects", name: "TeamLead_Id", newName: "__mig_tmp__1");
            RenameColumn(table: "dbo.Modules", name: "Assign_Tester_Id", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.Projects", name: "Manager_Id", newName: "TeamLead_Id");
            RenameColumn(table: "dbo.Projects", name: "__mig_tmp__1", newName: "Manager_Id");
            RenameColumn(table: "dbo.Modules", name: "Assign_Dev_Id", newName: "Assign_Tester_Id");
            RenameColumn(table: "dbo.Modules", name: "__mig_tmp__0", newName: "Assign_Dev_Id");
        }
    }
}
