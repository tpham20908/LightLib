namespace LightLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckoutToAssetAddedAndDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assets", "Checkout_Id", c => c.Int());
            AddColumn("dbo.Checkouts", "DateCheckedOut", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Assets", "Checkout_Id");
            AddForeignKey("dbo.Assets", "Checkout_Id", "dbo.Checkouts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assets", "Checkout_Id", "dbo.Checkouts");
            DropIndex("dbo.Assets", new[] { "Checkout_Id" });
            DropColumn("dbo.Checkouts", "DateCheckedOut");
            DropColumn("dbo.Assets", "Checkout_Id");
        }
    }
}
