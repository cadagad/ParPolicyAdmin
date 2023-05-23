namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixissuewithBarcodeFeedmodel2nd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BarcodeFeeds", "ProcessedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BarcodeFeeds", "ProcessedDate", c => c.DateTime(nullable: false));
        }
    }
}
