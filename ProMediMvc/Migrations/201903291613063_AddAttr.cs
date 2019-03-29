namespace ProMediMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttr : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Blogs", name: "Decs", newName: "Description");
            RenameColumn(table: "dbo.Blogs", name: "DoctorId", newName: "Doctor");
            RenameColumn(table: "dbo.Blogs", name: "BlogCatId", newName: "Category");
            RenameColumn(table: "dbo.Blogs", name: "BlogTagId", newName: "Tag");
            RenameColumn(table: "dbo.Doctors", name: "DepartmentId", newName: "Department");
            RenameColumn(table: "dbo.Departments", name: "Desc", newName: "Description");
            RenameIndex(table: "dbo.Blogs", name: "IX_DoctorId", newName: "IX_Doctor");
            RenameIndex(table: "dbo.Blogs", name: "IX_BlogCatId", newName: "IX_Category");
            RenameIndex(table: "dbo.Blogs", name: "IX_BlogTagId", newName: "IX_Tag");
            RenameIndex(table: "dbo.Doctors", name: "IX_DepartmentId", newName: "IX_Department");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Doctors", name: "IX_Department", newName: "IX_DepartmentId");
            RenameIndex(table: "dbo.Blogs", name: "IX_Tag", newName: "IX_BlogTagId");
            RenameIndex(table: "dbo.Blogs", name: "IX_Category", newName: "IX_BlogCatId");
            RenameIndex(table: "dbo.Blogs", name: "IX_Doctor", newName: "IX_DoctorId");
            RenameColumn(table: "dbo.Departments", name: "Description", newName: "Desc");
            RenameColumn(table: "dbo.Doctors", name: "Department", newName: "DepartmentId");
            RenameColumn(table: "dbo.Blogs", name: "Tag", newName: "BlogTagId");
            RenameColumn(table: "dbo.Blogs", name: "Category", newName: "BlogCatId");
            RenameColumn(table: "dbo.Blogs", name: "Doctor", newName: "DoctorId");
            RenameColumn(table: "dbo.Blogs", name: "Description", newName: "Decs");
        }
    }
}
