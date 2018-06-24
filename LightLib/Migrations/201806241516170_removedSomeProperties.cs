namespace LightLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedSomeProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Checkouts", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Checkouts", new[] { "AppUser_Id" });
            DropColumn("dbo.Checkouts", "AppUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Checkouts", "AppUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Checkouts", "AppUser_Id");
            AddForeignKey("dbo.Checkouts", "AppUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
