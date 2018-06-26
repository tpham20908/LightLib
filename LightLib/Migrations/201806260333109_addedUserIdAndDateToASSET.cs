namespace LightLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUserIdAndDateToASSET : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assets", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Assets", "RentDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assets", "RentDate");
            DropColumn("dbo.Assets", "UserId");
        }
    }
}
