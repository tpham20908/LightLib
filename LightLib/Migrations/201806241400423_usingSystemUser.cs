namespace LightLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usingSystemUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Checkouts", "AppUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Checkouts", "AppUser_Id");
            AddForeignKey("dbo.Checkouts", "AppUser_Id", "dbo.AspNetUsers", "Id");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Checkouts", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Checkouts", new[] { "AppUser_Id" });
            DropColumn("dbo.Checkouts", "AppUser_Id");
        }
    }
}
