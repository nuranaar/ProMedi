namespace ProMediMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdmin1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "Fullname", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Admins", "Password", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Admins", "Email", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "Fullname", c => c.String(nullable: false));
        }
    }
}
