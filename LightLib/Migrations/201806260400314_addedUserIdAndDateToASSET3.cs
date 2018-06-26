namespace LightLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUserIdAndDateToASSET3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assets", "User", c => c.String());
            DropColumn("dbo.Assets", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Assets", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Assets", "User");
        }
    }
}
