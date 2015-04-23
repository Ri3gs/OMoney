namespace OMoney.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Account_changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Comments", c => c.String());
            AddColumn("dbo.Accounts", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Accounts", "UpdatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Accounts", "AccountType", c => c.Int(nullable: false));
            AddColumn("dbo.Accounts", "AccountCurrency", c => c.Int(nullable: false));
            AlterColumn("dbo.Accounts", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "Amount", c => c.Single(nullable: false));
            DropColumn("dbo.Accounts", "AccountCurrency");
            DropColumn("dbo.Accounts", "AccountType");
            DropColumn("dbo.Accounts", "UpdatedAt");
            DropColumn("dbo.Accounts", "CreatedAt");
            DropColumn("dbo.Accounts", "Comments");
        }
    }
}
