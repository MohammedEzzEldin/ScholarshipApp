namespace ScholarShip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSomeTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsFinalPost = c.Boolean(nullable: false),
                        IsAccepted = c.Boolean(nullable: false),
                        RegDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ScholarShip_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ScholarShipTbls", t => t.ScholarShip_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.ScholarShip_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.ScholarShipTbls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Schol_Name = c.String(nullable: false),
                        Description = c.String(),
                        Requirements = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Field = c.String(),
                        University = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        City = c.String(),
                        IsFinalPost = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fname = c.String(nullable: false),
                        Lname = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        NationalID = c.String(nullable: false, maxLength: 14),
                        University = c.String(nullable: false),
                        Major = c.String(nullable: false),
                        GPA = c.Single(nullable: false),
                        Resume = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applications", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Applications", "ScholarShip_Id", "dbo.ScholarShipTbls");
            DropIndex("dbo.Applications", new[] { "Student_Id" });
            DropIndex("dbo.Applications", new[] { "ScholarShip_Id" });
            DropTable("dbo.Students");
            DropTable("dbo.ScholarShipTbls");
            DropTable("dbo.Applications");
        }
    }
}
