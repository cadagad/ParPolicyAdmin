namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixissuewithBarcodeFeedmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BarcodeFeeds", "ProcessedBy", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BarcodeFeeds", "ProcessedBy", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
