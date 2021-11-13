namespace ScholarShip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Applications", "ScholarShip_Id", "dbo.ScholarShipTbls");
            DropIndex("dbo.Applications", new[] { "ScholarShip_Id" });
            AlterColumn("dbo.Applications", "ScholarShip_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Applications", "ScholarShip_Id");
            AddForeignKey("dbo.Applications", "ScholarShip_Id", "dbo.ScholarShipTbls", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applications", "ScholarShip_Id", "dbo.ScholarShipTbls");
            DropIndex("dbo.Applications", new[] { "ScholarShip_Id" });
            AlterColumn("dbo.Applications", "ScholarShip_Id", c => c.Int());
            CreateIndex("dbo.Applications", "ScholarShip_Id");
            AddForeignKey("dbo.Applications", "ScholarShip_Id", "dbo.ScholarShipTbls", "Id");
        }
    }
}
