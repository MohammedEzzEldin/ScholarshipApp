namespace ScholarShip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Applications", "ScholarShip_Id", "dbo.ScholarShipTbls");
            DropIndex("dbo.Applications", new[] { "ScholarShip_Id" });
            AddColumn("dbo.Applications", "ScholarShip_Id1", c => c.Int());
            CreateIndex("dbo.Applications", "ScholarShip_Id1");
            AddForeignKey("dbo.Applications", "ScholarShip_Id1", "dbo.ScholarShipTbls", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applications", "ScholarShip_Id1", "dbo.ScholarShipTbls");
            DropIndex("dbo.Applications", new[] { "ScholarShip_Id1" });
            DropColumn("dbo.Applications", "ScholarShip_Id1");
            CreateIndex("dbo.Applications", "ScholarShip_Id");
            AddForeignKey("dbo.Applications", "ScholarShip_Id", "dbo.ScholarShipTbls", "Id", cascadeDelete: true);
        }
    }
}
