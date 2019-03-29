namespace ProMediMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttr1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BlogCats", name: "Category", newName: "Name");
            RenameColumn(table: "dbo.Blogs", name: "Description", newName: "Decs");
            RenameColumn(table: "dbo.Blogs", name: "Doctor", newName: "DoctorId");
            RenameColumn(table: "dbo.Blogs", name: "Category", newName: "BlogCatId");
            RenameColumn(table: "dbo.Blogs", name: "Tag", newName: "BlogTagId");
            RenameColumn(table: "dbo.BlogTags", name: "Tag", newName: "Name");
            RenameColumn(table: "dbo.Doctors", name: "Department", newName: "DepartmentId");
            RenameColumn(table: "dbo.Departments", name: "Department", newName: "Name");
            RenameColumn(table: "dbo.Departments", name: "Description", newName: "Desc");
            RenameIndex(table: "dbo.Blogs", name: "IX_Doctor", newName: "IX_DoctorId");
            RenameIndex(table: "dbo.Blogs", name: "IX_Category", newName: "IX_BlogCatId");
            RenameIndex(table: "dbo.Blogs", name: "IX_Tag", newName: "IX_BlogTagId");
            RenameIndex(table: "dbo.Doctors", name: "IX_Department", newName: "IX_DepartmentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Doctors", name: "IX_DepartmentId", newName: "IX_Department");
            RenameIndex(table: "dbo.Blogs", name: "IX_BlogTagId", newName: "IX_Tag");
            RenameIndex(table: "dbo.Blogs", name: "IX_BlogCatId", newName: "IX_Category");
            RenameIndex(table: "dbo.Blogs", name: "IX_DoctorId", newName: "IX_Doctor");
            RenameColumn(table: "dbo.Departments", name: "Desc", newName: "Description");
            RenameColumn(table: "dbo.Departments", name: "Name", newName: "Department");
            RenameColumn(table: "dbo.Doctors", name: "DepartmentId", newName: "Department");
            RenameColumn(table: "dbo.BlogTags", name: "Name", newName: "Tag");
            RenameColumn(table: "dbo.Blogs", name: "BlogTagId", newName: "Tag");
            RenameColumn(table: "dbo.Blogs", name: "BlogCatId", newName: "Category");
            RenameColumn(table: "dbo.Blogs", name: "DoctorId", newName: "Doctor");
            RenameColumn(table: "dbo.Blogs", name: "Decs", newName: "Description");
            RenameColumn(table: "dbo.BlogCats", name: "Name", newName: "Category");
        }
    }
}
