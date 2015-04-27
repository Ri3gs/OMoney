namespace OMoney.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialtwo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Plans", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Accounts", new[] { "UserId" });
            DropIndex("dbo.Plans", new[] { "UserId" });
            AlterColumn("dbo.Accounts", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Accounts", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Plans", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Categories", "Planned", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Categories", "Spent", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.CatItems", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Accounts", "UserId");
            CreateIndex("dbo.Plans", "UserId");
            AddForeignKey("dbo.Accounts", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Plans", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plans", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Accounts", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Plans", new[] { "UserId" });
            DropIndex("dbo.Accounts", new[] { "UserId" });
            AlterColumn("dbo.CatItems", "Name", c => c.String());
            AlterColumn("dbo.Categories", "Spent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Categories", "Planned", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Plans", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Accounts", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Accounts", "Name", c => c.String());
            CreateIndex("dbo.Plans", "UserId");
            CreateIndex("dbo.Accounts", "UserId");
            AddForeignKey("dbo.Plans", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Accounts", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
