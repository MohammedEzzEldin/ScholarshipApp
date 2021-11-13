namespace ScholarShip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixSomeRelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Applications", "Student_Id", "dbo.Students");
            DropIndex("dbo.Applications", new[] { "Student_Id" });
            CreateTable(
                "dbo.Student_Application",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsAccepted = c.Boolean(nullable: false),
                        RegDate = c.DateTime(nullable: false),
                        Application_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applications", t => t.Application_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Application_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Student_Scholarship",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScholarShip_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ScholarShipTbls", t => t.ScholarShip_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.ScholarShip_Id)
                .Index(t => t.Student_Id);
            
            DropColumn("dbo.Applications", "IsAccepted");
            DropColumn("dbo.Applications", "RegDate");
            DropColumn("dbo.Applications", "Student_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applications", "Student_Id", c => c.Int());
            AddColumn("dbo.Applications", "RegDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Applications", "IsAccepted", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Student_Scholarship", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Student_Scholarship", "ScholarShip_Id", "dbo.ScholarShipTbls");
            DropForeignKey("dbo.Student_Application", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Student_Application", "Application_Id", "dbo.Applications");
            DropIndex("dbo.Student_Scholarship", new[] { "Student_Id" });
            DropIndex("dbo.Student_Scholarship", new[] { "ScholarShip_Id" });
            DropIndex("dbo.Student_Application", new[] { "Student_Id" });
            DropIndex("dbo.Student_Application", new[] { "Application_Id" });
            DropTable("dbo.Student_Scholarship");
            DropTable("dbo.Student_Application");
            CreateIndex("dbo.Applications", "Student_Id");
            AddForeignKey("dbo.Applications", "Student_Id", "dbo.Students", "Id");
        }
    }
}
