namespace ProMediMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVideoUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "VideoUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Settings", "VideoUrl");
        }
    }
}
