namespace OMoney.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllNotNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Planned", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Categories", "Spent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Categories", "CatItemsTotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CatItems", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CatItems", "Buyed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CatItems", "Buyed", c => c.Boolean());
            AlterColumn("dbo.CatItems", "Price", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Categories", "CatItemsTotalPrice", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Categories", "Spent", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Categories", "Planned", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
