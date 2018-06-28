namespace LightLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropCheckout : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assets", "Checkout_Id", "dbo.Checkouts");
            DropIndex("dbo.Assets", new[] { "Checkout_Id" });
            DropColumn("dbo.Assets", "Checkout_Id");
            DropTable("dbo.Checkouts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Checkouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCheckedOut = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Assets", "Checkout_Id", c => c.Int());
            CreateIndex("dbo.Assets", "Checkout_Id");
            AddForeignKey("dbo.Assets", "Checkout_Id", "dbo.Checkouts", "Id");
        }
    }
}
