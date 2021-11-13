namespace ScholarShip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Email");
        }
    }
}
