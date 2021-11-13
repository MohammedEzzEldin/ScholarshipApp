namespace ScholarShip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Student_Application", "Application_Id", "dbo.Applications");
            DropForeignKey("dbo.Student_Application", "Student_Id", "dbo.Students");
            DropIndex("dbo.Student_Application", new[] { "Application_Id" });
            DropIndex("dbo.Student_Application", new[] { "Student_Id" });
            AddColumn("dbo.Students", "UserName", c => c.String(nullable: false));
            AddColumn("dbo.Student_Application", "Application_Id1", c => c.Int());
            AddColumn("dbo.Student_Application", "Student_Id1", c => c.Int());
            AlterColumn("dbo.Student_Application", "Application_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Student_Application", "Student_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Student_Application", "Application_Id1");
            CreateIndex("dbo.Student_Application", "Student_Id1");
            AddForeignKey("dbo.Student_Application", "Application_Id1", "dbo.Applications", "Id");
            AddForeignKey("dbo.Student_Application", "Student_Id1", "dbo.Students", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student_Application", "Student_Id1", "dbo.Students");
            DropForeignKey("dbo.Student_Application", "Application_Id1", "dbo.Applications");
            DropIndex("dbo.Student_Application", new[] { "Student_Id1" });
            DropIndex("dbo.Student_Application", new[] { "Application_Id1" });
            AlterColumn("dbo.Student_Application", "Student_Id", c => c.Int());
            AlterColumn("dbo.Student_Application", "Application_Id", c => c.Int());
            DropColumn("dbo.Student_Application", "Student_Id1");
            DropColumn("dbo.Student_Application", "Application_Id1");
            DropColumn("dbo.Students", "UserName");
            CreateIndex("dbo.Student_Application", "Student_Id");
            CreateIndex("dbo.Student_Application", "Application_Id");
            AddForeignKey("dbo.Student_Application", "Student_Id", "dbo.Students", "Id");
            AddForeignKey("dbo.Student_Application", "Application_Id", "dbo.Applications", "Id");
        }
    }
}
