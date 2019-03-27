namespace ProMediMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSpecExpert : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SpecExperts", "Speciality_Id", "dbo.Specialities");
            DropIndex("dbo.SpecExperts", new[] { "Speciality_Id" });
            RenameColumn(table: "dbo.SpecExperts", name: "Speciality_Id", newName: "SpecialityId");
            AlterColumn("dbo.SpecExperts", "SpecialityId", c => c.Int(nullable: false));
            CreateIndex("dbo.SpecExperts", "SpecialityId");
            AddForeignKey("dbo.SpecExperts", "SpecialityId", "dbo.Specialities", "Id", cascadeDelete: true);
            DropColumn("dbo.SpecExperts", "SpecoalityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SpecExperts", "SpecoalityId", c => c.Int(nullable: false));
            DropForeignKey("dbo.SpecExperts", "SpecialityId", "dbo.Specialities");
            DropIndex("dbo.SpecExperts", new[] { "SpecialityId" });
            AlterColumn("dbo.SpecExperts", "SpecialityId", c => c.Int());
            RenameColumn(table: "dbo.SpecExperts", name: "SpecialityId", newName: "Speciality_Id");
            CreateIndex("dbo.SpecExperts", "Speciality_Id");
            AddForeignKey("dbo.SpecExperts", "Speciality_Id", "dbo.Specialities", "Id");
        }
    }
}
