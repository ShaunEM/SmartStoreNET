namespace SmartStore.Data.Migrations
{
    using SmartStore.Core.Data;
    using System;
    using System.Data.Entity.Migrations;
    using System.Web.Hosting;

    public partial class IsSystemProductIndex : DbMigration
    {
        public override void Up()
        {
            if(HostingEnvironment.IsHosted && DataSettings.Current.IsMySqlServer)
            {
                
            }
            else 
            {
                DropIndex("dbo.Product", "IX_Product_Deleted_and_Published");
                //RenameIndex(table: "dbo.Product", name: "Product_SystemName_IsSystemProduct", newName: "IX_Product_SystemName_IsSystemProduct");
            }
            DropIndex("dbo.Product", "Product_SystemName_IsSystemProduct");
            CreateIndex("dbo.Product", new[] { "SystemName", "IsSystemProduct" }, name: "IX_Product_SystemName_IsSystemProduct");
            CreateIndex("dbo.Product", new[] { "Published", "Deleted", "IsSystemProduct" }, name: "IX_Product_Published_Deleted_IsSystemProduct");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Product", "IX_Product_SystemName_IsSystemProduct");
            CreateIndex("dbo.Product", new[] { "SystemName", "IsSystemProduct" }, name: "Product_SystemName_IsSystemProduct");
            DropIndex("dbo.Product", "IX_Product_Published_Deleted_IsSystemProduct");
            if (HostingEnvironment.IsHosted && DataSettings.Current.IsMySqlServer)
            {

            }
            else
            {
                CreateIndex("dbo.Product", new[] { "Published", "Deleted" }, name: "IX_Product_Deleted_and_Published");
            }
        }
    }
}
