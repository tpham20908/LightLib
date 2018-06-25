namespace LightLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Checkouts", "LibraryUser_Id", "dbo.LibraryUsers");
            DropIndex("dbo.Checkouts", new[] { "LibraryUser_Id" });
            DropColumn("dbo.Checkouts", "LibraryUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Checkouts", "LibraryUser_Id", c => c.Int());
            CreateIndex("dbo.Checkouts", "LibraryUser_Id");
            AddForeignKey("dbo.Checkouts", "LibraryUser_Id", "dbo.LibraryUsers", "Id");
        }
    }
}
