namespace LightLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAssetTypeId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assets", "Type_Id", "dbo.AssetTypes");
            DropIndex("dbo.Assets", new[] { "Type_Id" });
            RenameColumn(table: "dbo.Assets", name: "Type_Id", newName: "AssetTypeId");
            AlterColumn("dbo.Assets", "AssetTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Assets", "AssetTypeId");
            AddForeignKey("dbo.Assets", "AssetTypeId", "dbo.AssetTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assets", "AssetTypeId", "dbo.AssetTypes");
            DropIndex("dbo.Assets", new[] { "AssetTypeId" });
            AlterColumn("dbo.Assets", "AssetTypeId", c => c.Int());
            RenameColumn(table: "dbo.Assets", name: "AssetTypeId", newName: "Type_Id");
            CreateIndex("dbo.Assets", "Type_Id");
            AddForeignKey("dbo.Assets", "Type_Id", "dbo.AssetTypes", "Id");
        }
    }
}
