namespace LightLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuthorOnAsset : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assets", "Author", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assets", "Author");
        }
    }
}
