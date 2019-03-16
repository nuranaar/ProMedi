namespace ProMediMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(storeType: "ntext"),
                        Text = c.String(storeType: "ntext"),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BlogCats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 150),
                        Photo = c.String(),
                        Decs = c.String(),
                        Date = c.DateTime(nullable: false),
                        Text = c.String(storeType: "ntext"),
                        Slug = c.String(),
                        DoctorId = c.Int(nullable: false),
                        BlogCatId = c.Int(nullable: false),
                        BlogTagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogCats", t => t.BlogCatId, cascadeDelete: true)
                .ForeignKey("dbo.BlogTags", t => t.BlogTagId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.BlogCatId)
                .Index(t => t.BlogTagId);
            
            CreateTable(
                "dbo.BlogTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tag = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Phone = c.String(),
                        Degree = c.String(),
                        Photo = c.String(),
                        Desc = c.String(),
                        Text = c.String(storeType: "ntext"),
                        Slug = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Departmnet = c.String(),
                        Text = c.String(storeType: "ntext"),
                        Text2 = c.String(storeType: "ntext"),
                        Slug = c.String(),
                        Photo = c.String(),
                        Desc = c.String(),
                        Icon = c.String(),
                        DepInfoId = c.Int(nullable: false),
                        DepartmentInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DepartmentInfoes", t => t.DepartmentInfo_Id)
                .Index(t => t.DepartmentInfo_Id);
            
            CreateTable(
                "dbo.DepartmentInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Specialities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Speciality = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.SpecExperts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpecoalityId = c.Int(nullable: false),
                        ExpertId = c.Int(nullable: false),
                        Speciality_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Experts", t => t.ExpertId, cascadeDelete: true)
                .ForeignKey("dbo.Specialities", t => t.Speciality_Id)
                .Index(t => t.ExpertId)
                .Index(t => t.Speciality_Id);
            
            CreateTable(
                "dbo.Experts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Facts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Value = c.String(),
                        Icon = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Faqs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(maxLength: 100),
                        Answer = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(),
                        Photo = c.String(),
                        Feedback = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProMedis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Icon = c.String(),
                        Title = c.String(),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Desc = c.String(),
                        Icon = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logo = c.String(maxLength: 250),
                        Phone = c.String(),
                        PhoneIcon = c.String(),
                        Email1 = c.String(maxLength: 250),
                        Email2 = c.String(maxLength: 250),
                        EmailIcon = c.String(),
                        Address = c.String(maxLength: 250),
                        LocationIcon = c.String(),
                        Facebook = c.String(),
                        Twitter = c.String(),
                        Instagram = c.String(),
                        LinkedIn = c.String(),
                        GooglePlus = c.String(),
                        Lat = c.String(maxLength: 50),
                        Lng = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecExperts", "Speciality_Id", "dbo.Specialities");
            DropForeignKey("dbo.SpecExperts", "ExpertId", "dbo.Experts");
            DropForeignKey("dbo.Specialities", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Doctors", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "DepartmentInfo_Id", "dbo.DepartmentInfoes");
            DropForeignKey("dbo.DepartmentInfoes", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Blogs", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Blogs", "BlogTagId", "dbo.BlogTags");
            DropForeignKey("dbo.Blogs", "BlogCatId", "dbo.BlogCats");
            DropIndex("dbo.SpecExperts", new[] { "Speciality_Id" });
            DropIndex("dbo.SpecExperts", new[] { "ExpertId" });
            DropIndex("dbo.Specialities", new[] { "DepartmentId" });
            DropIndex("dbo.DepartmentInfoes", new[] { "DoctorId" });
            DropIndex("dbo.Departments", new[] { "DepartmentInfo_Id" });
            DropIndex("dbo.Doctors", new[] { "DepartmentId" });
            DropIndex("dbo.Blogs", new[] { "BlogTagId" });
            DropIndex("dbo.Blogs", new[] { "BlogCatId" });
            DropIndex("dbo.Blogs", new[] { "DoctorId" });
            DropTable("dbo.Settings");
            DropTable("dbo.Services");
            DropTable("dbo.ServiceIndex1");
            DropTable("dbo.ProMedis");
            DropTable("dbo.Patients");
            DropTable("dbo.Faqs");
            DropTable("dbo.Facts");
            DropTable("dbo.Experts");
            DropTable("dbo.SpecExperts");
            DropTable("dbo.Specialities");
            DropTable("dbo.DepartmentInfoes");
            DropTable("dbo.Departments");
            DropTable("dbo.Doctors");
            DropTable("dbo.BlogTags");
            DropTable("dbo.Blogs");
            DropTable("dbo.BlogCats");
            DropTable("dbo.Abouts");
        }
    }
}
