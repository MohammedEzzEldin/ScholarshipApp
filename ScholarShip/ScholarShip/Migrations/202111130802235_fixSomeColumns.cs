namespace ScholarShip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixSomeColumns : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Applications", "IsFinalPost");
            DropColumn("dbo.ScholarShipTbls", "IsFinalPost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ScholarShipTbls", "IsFinalPost", c => c.Boolean(nullable: false));
            AddColumn("dbo.Applications", "IsFinalPost", c => c.Boolean(nullable: false));
        }
    }
}
