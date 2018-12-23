namespace SmartStore.GoogleMerchantCenter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
	using SmartStore.Data.Setup;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
			if (DbMigrationContext.Current.SuppressInitialCreate<GoogleProductObjectContext>())
				return;

                CreateTable(
                "dbo.GoogleProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Taxonomy = c.String(maxLength: 250),
                        Gender = c.String(maxLength: 250),
                        AgeGroup = c.String(maxLength: 250),
                        Color = c.String(maxLength: 250),
                        Size = c.String(maxLength: 250),
                        Material = c.String(maxLength: 250),
                        Pattern = c.String(maxLength: 250),
                        ItemGroupId = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.GoogleProduct");
        }
    }
}
