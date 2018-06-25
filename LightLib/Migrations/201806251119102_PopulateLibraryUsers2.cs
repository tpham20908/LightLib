namespace LightLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateLibraryUsers2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO LibraryUsers(Name, Address) VALUES('Justine Trudeau', '2001 Mackay, Ottawa, ON')");
            Sql(@"INSERT INTO LibraryUsers(Name, Address) VALUES('Phillip Couillard', '5001 Montmorency, Quebec, QC')");
        }
        
        public override void Down()
        {
        }
    }
}
