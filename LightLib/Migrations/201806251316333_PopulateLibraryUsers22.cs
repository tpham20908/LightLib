namespace LightLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateLibraryUsers22 : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropTable("dbo.LibraryUsers");
        }
    }
}
