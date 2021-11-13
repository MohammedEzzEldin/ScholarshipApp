namespace ScholarShip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student_Application", "IsFinalPost", c => c.Boolean());
            AlterColumn("dbo.Student_Application", "IsAccepted", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student_Application", "IsAccepted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Student_Application", "IsFinalPost");
        }
    }
}
