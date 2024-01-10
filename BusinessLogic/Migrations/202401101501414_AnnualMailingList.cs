namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnnualMailingList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnnualMailingLists",
                c => new
                    {
                        AnnualMailingListId = c.Long(nullable: false, identity: true),
                        SystemCode = c.String(maxLength: 3),
                        PolicyNumber = c.String(maxLength: 10),
                        PostalCode = c.String(maxLength: 9),
                        CountryCode = c.String(maxLength: 1),
                        LanguageCode = c.String(maxLength: 1),
                        HolderName = c.String(maxLength: 32),
                        Address1 = c.String(maxLength: 32),
                        Address2 = c.String(maxLength: 32),
                        Address3 = c.String(maxLength: 32),
                        Address4 = c.String(maxLength: 32),
                        Address5 = c.String(maxLength: 32),
                        Address6 = c.String(maxLength: 32),
                        KeyName = c.String(maxLength: 32),
                        LineNumber = c.Int(nullable: false),
                        UserFlaggedDuplicate = c.Boolean(),
                        UserFlaggedDeficient = c.Boolean(),
                        UserFlaggedExclusion = c.Boolean(),
                        UserManualAdd = c.Boolean(),
                    })
                .PrimaryKey(t => t.AnnualMailingListId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AnnualMailingLists");
        }
    }
}
