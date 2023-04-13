namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Barcode : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BarcodeFeeds",
                c => new
                    {
                        BarcodeFeedId = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false, maxLength: 100),
                        IsProcessed = c.Boolean(nullable: false),
                        IsValid = c.Boolean(nullable: false),
                        RowCount = c.Int(nullable: false),
                        ProcessedBy = c.String(nullable: false, maxLength: 20),
                        ProcessedDate = c.DateTime(nullable: false),
                        ExceptionReason = c.String(maxLength: 200),
                        ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.BarcodeFeedId)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Barcodes",
                c => new
                    {
                        BarcodeId = c.Long(nullable: false, identity: true),
                        BarcodeFeedId = c.Int(nullable: false),
                        LineNumber = c.Int(nullable: false),
                        BarcodeNumber = c.String(maxLength: 7),
                        PolicyNumber = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.BarcodeId)
                .ForeignKey("dbo.BarcodeFeeds", t => t.BarcodeFeedId, cascadeDelete: true)
                .Index(t => t.BarcodeFeedId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Barcodes", "BarcodeFeedId", "dbo.BarcodeFeeds");
            DropForeignKey("dbo.BarcodeFeeds", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Barcodes", new[] { "BarcodeFeedId" });
            DropIndex("dbo.BarcodeFeeds", new[] { "ProjectId" });
            DropTable("dbo.Barcodes");
            DropTable("dbo.BarcodeFeeds");
        }
    }
}
