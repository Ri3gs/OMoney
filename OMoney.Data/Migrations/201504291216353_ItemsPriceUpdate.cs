namespace OMoney.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemsPriceUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CatItemsTotalPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.CatItems", "Price", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.CatItems", "Buyed", c => c.Boolean());
            AddColumn("dbo.CatItems", "BuyedTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CatItems", "BuyedTime");
            DropColumn("dbo.CatItems", "Buyed");
            DropColumn("dbo.CatItems", "Price");
            DropColumn("dbo.Categories", "CatItemsTotalPrice");
        }
    }
}
