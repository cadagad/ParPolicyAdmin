namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Policies",
                c => new
                    {
                        PolicyId = c.Long(nullable: false, identity: true),
                        SystemCode = c.String(maxLength: 3),
                        PolicyNumber = c.String(maxLength: 10),
                        CertificateNumber = c.String(maxLength: 9),
                        HolderName = c.String(maxLength: 32),
                        Address1 = c.String(maxLength: 32),
                        Address2 = c.String(maxLength: 32),
                        Address3 = c.String(maxLength: 32),
                        Address4 = c.String(maxLength: 32),
                        Address5 = c.String(maxLength: 32),
                        Address6 = c.String(maxLength: 32),
                        Address7 = c.String(maxLength: 32),
                        PostalCode = c.String(maxLength: 9),
                        CountryCode = c.String(maxLength: 1),
                        ProvinceStateCode = c.String(maxLength: 2),
                        LanguageCode = c.String(maxLength: 1),
                        BirthDate = c.String(maxLength: 8),
                        ShareVotes = c.String(maxLength: 9),
                        KeyName = c.String(maxLength: 32),
                        PolicyFeedId = c.Int(nullable: false),
                        LineNumber = c.Int(nullable: false),
                        PossibleDuplicate = c.Boolean(),
                        ExactDuplicate = c.Boolean(),
                        PolicyHolderId = c.Int(),
                    })
                .PrimaryKey(t => t.PolicyId)
                .ForeignKey("dbo.PolicyFeeds", t => t.PolicyFeedId, cascadeDelete: true)
                .Index(t => t.PolicyFeedId);
            
            CreateTable(
                "dbo.PolicyFeeds",
                c => new
                    {
                        PolicyFeedId = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false, maxLength: 100),
                        IsProcessed = c.Boolean(nullable: false),
                        IsValid = c.Boolean(nullable: false),
                        RowCount = c.Int(),
                        ProcessedBy = c.String(maxLength: 20),
                        ProcessedDate = c.DateTime(),
                        UniqueRecordCount = c.Int(),
                        ExceptionReason = c.String(maxLength: 100),
                        ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.PolicyFeedId)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Type = c.String(nullable: false, maxLength: 20),
                        Year = c.Int(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsArchived = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 20),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Sources",
                c => new
                    {
                        SourceId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 10),
                        IsActive = c.Boolean(nullable: false),
                        Division = c.String(maxLength: 20),
                        Region = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.SourceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Policies", "PolicyFeedId", "dbo.PolicyFeeds");
            DropForeignKey("dbo.PolicyFeeds", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Projects", new[] { "Name" });
            DropIndex("dbo.PolicyFeeds", new[] { "ProjectId" });
            DropIndex("dbo.Policies", new[] { "PolicyFeedId" });
            DropTable("dbo.Sources");
            DropTable("dbo.Projects");
            DropTable("dbo.PolicyFeeds");
            DropTable("dbo.Policies");
        }
    }
}
