namespace ProMediMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVideoText : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "VideoText", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Settings", "VideoText");
        }
    }
}
