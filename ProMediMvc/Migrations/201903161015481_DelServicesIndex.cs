namespace ProMediMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelServicesIndex : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProMedis", "Photo", c => c.String());
            DropTable("dbo.ServiceIndex1");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ServiceIndex1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(storeType: "ntext"),
                        Desc = c.String(storeType: "ntext"),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.ProMedis", "Photo");
        }
    }
}
