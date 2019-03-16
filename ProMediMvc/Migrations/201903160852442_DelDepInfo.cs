namespace ProMediMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelDepInfo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DepartmentInfoes", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Departments", "DepartmentInfo_Id", "dbo.DepartmentInfoes");
            DropIndex("dbo.Departments", new[] { "DepartmentInfo_Id" });
            DropIndex("dbo.DepartmentInfoes", new[] { "DoctorId" });
            RenameColumn(table: "dbo.Departments", name: "Departmnet", newName: "Department");
            DropColumn("dbo.Departments", "DepInfoId");
            DropColumn("dbo.Departments", "DepartmentInfo_Id");
            DropTable("dbo.DepartmentInfoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DepartmentInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Departments", "DepartmentInfo_Id", c => c.Int());
            AddColumn("dbo.Departments", "DepInfoId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Departments", name: "Department", newName: "Departmnet");
            CreateIndex("dbo.DepartmentInfoes", "DoctorId");
            CreateIndex("dbo.Departments", "DepartmentInfo_Id");
            AddForeignKey("dbo.Departments", "DepartmentInfo_Id", "dbo.DepartmentInfoes", "Id");
            AddForeignKey("dbo.DepartmentInfoes", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
        }
    }
}
