namespace ProMediMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAdminsModel1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "Password", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "Password", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
