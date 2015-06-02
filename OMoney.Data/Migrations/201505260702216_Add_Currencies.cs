namespace OMoney.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Currencies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 255),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Accounts", "CurrencyId", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "Currency_Id", c => c.Int());
            AddColumn("dbo.ShopItems", "Currency_Id", c => c.Int());
            CreateIndex("dbo.Accounts", "CurrencyId");
            CreateIndex("dbo.Categories", "Currency_Id");
            CreateIndex("dbo.ShopItems", "Currency_Id");
            AddForeignKey("dbo.Categories", "Currency_Id", "dbo.Currencies", "Id");
            AddForeignKey("dbo.ShopItems", "Currency_Id", "dbo.Currencies", "Id");
            AddForeignKey("dbo.Accounts", "CurrencyId", "dbo.Currencies", "Id");
            DropColumn("dbo.Accounts", "AccountCurrency");
            DropColumn("dbo.Categories", "Currency");
            DropColumn("dbo.ShopItems", "Currency");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShopItems", "Currency", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "Currency", c => c.Int(nullable: false));
            AddColumn("dbo.Accounts", "AccountCurrency", c => c.Int(nullable: false));
            DropForeignKey("dbo.Accounts", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.Currencies", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ShopItems", "Currency_Id", "dbo.Currencies");
            DropForeignKey("dbo.Categories", "Currency_Id", "dbo.Currencies");
            DropIndex("dbo.ShopItems", new[] { "Currency_Id" });
            DropIndex("dbo.Categories", new[] { "Currency_Id" });
            DropIndex("dbo.Currencies", new[] { "UserId" });
            DropIndex("dbo.Accounts", new[] { "CurrencyId" });
            DropColumn("dbo.ShopItems", "Currency_Id");
            DropColumn("dbo.Categories", "Currency_Id");
            DropColumn("dbo.Accounts", "CurrencyId");
            DropTable("dbo.Currencies");
        }
    }
}
