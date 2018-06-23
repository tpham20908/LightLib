namespace LightLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecorrectCheckoutClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Checkouts", "AssetId", "dbo.Assets");
            DropForeignKey("dbo.Checkouts", "UserId", "dbo.Users");
            DropIndex("dbo.Checkouts", new[] { "AssetId" });
            DropIndex("dbo.Checkouts", new[] { "UserId" });
            DropColumn("dbo.Checkouts", "AssetId");
            DropColumn("dbo.Checkouts", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Checkouts", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Checkouts", "AssetId", c => c.Int(nullable: false));
            CreateIndex("dbo.Checkouts", "UserId");
            CreateIndex("dbo.Checkouts", "AssetId");
            AddForeignKey("dbo.Checkouts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Checkouts", "AssetId", "dbo.Assets", "Id", cascadeDelete: true);
        }
    }
}
