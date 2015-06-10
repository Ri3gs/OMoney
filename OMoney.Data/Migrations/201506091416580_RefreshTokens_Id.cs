namespace OMoney.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefreshTokens_Id : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.RefreshTokens");
            AlterColumn("dbo.RefreshTokens", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.RefreshTokens", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.RefreshTokens");
            AlterColumn("dbo.RefreshTokens", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.RefreshTokens", "Id");
        }
    }
}
