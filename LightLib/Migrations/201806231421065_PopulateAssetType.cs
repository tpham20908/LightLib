namespace LightLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAssetType : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[AssetTypes] ON
                INSERT INTO [dbo].[AssetTypes] ([Id], [Name]) VALUES (1, N'Book')
                INSERT INTO [dbo].[AssetTypes] ([Id], [Name]) VALUES (2, N'Magazine')
                INSERT INTO [dbo].[AssetTypes] ([Id], [Name]) VALUES (3, N'Movie')
                INSERT INTO [dbo].[AssetTypes] ([Id], [Name]) VALUES (4, N'Documentation')
                INSERT INTO [dbo].[AssetTypes] ([Id], [Name]) VALUES (5, N'Game')
                INSERT INTO [dbo].[AssetTypes] ([Id], [Name]) VALUES (6, N'Music')
                SET IDENTITY_INSERT [dbo].[AssetTypes] OFF
                ");
        }
        
        public override void Down()
        {
        }
    }
}
