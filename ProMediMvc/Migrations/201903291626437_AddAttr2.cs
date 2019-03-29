namespace ProMediMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttr2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Specialities", name: "Speciality", newName: "Name");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Specialities", name: "Name", newName: "Speciality");
        }
    }
}
