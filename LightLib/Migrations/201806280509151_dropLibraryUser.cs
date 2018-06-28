namespace LightLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropLibraryUser : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.LibraryUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LibraryUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
