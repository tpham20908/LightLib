namespace LightLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKCheckoutAndLibraryUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Checkouts", "LibraryUser_Id", c => c.Int());
            CreateIndex("dbo.Checkouts", "LibraryUser_Id");
            AddForeignKey("dbo.Checkouts", "LibraryUser_Id", "dbo.LibraryUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Checkouts", "LibraryUser_Id", "dbo.LibraryUsers");
            DropIndex("dbo.Checkouts", new[] { "LibraryUser_Id" });
            DropColumn("dbo.Checkouts", "LibraryUser_Id");
        }
    }
}
