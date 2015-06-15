namespace OMoney.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Purchases : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CatItems", newName: "PurchaseItems");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.PurchaseItems", newName: "CatItems");
        }
    }
}
