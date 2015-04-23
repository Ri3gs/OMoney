namespace OMoney.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlansCategoriesShopingLists : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Month = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Planned = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Spent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        PlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plans", t => t.PlanId, cascadeDelete: true)
                .Index(t => t.PlanId);
            
            CreateTable(
                "dbo.CatItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ShopingLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        PlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plans", t => t.PlanId, cascadeDelete: true)
                .Index(t => t.PlanId);
            
            CreateTable(
                "dbo.ShopItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.Int(nullable: false),
                        ShopingListId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShopingLists", t => t.ShopingListId, cascadeDelete: true)
                .Index(t => t.ShopingListId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plans", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ShopingLists", "PlanId", "dbo.Plans");
            DropForeignKey("dbo.ShopItems", "ShopingListId", "dbo.ShopingLists");
            DropForeignKey("dbo.Categories", "PlanId", "dbo.Plans");
            DropForeignKey("dbo.CatItems", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ShopItems", new[] { "ShopingListId" });
            DropIndex("dbo.ShopingLists", new[] { "PlanId" });
            DropIndex("dbo.CatItems", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "PlanId" });
            DropIndex("dbo.Plans", new[] { "UserId" });
            DropTable("dbo.ShopItems");
            DropTable("dbo.ShopingLists");
            DropTable("dbo.CatItems");
            DropTable("dbo.Categories");
            DropTable("dbo.Plans");
        }
    }
}
