namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmailConfig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailConfigs",
                c => new
                    {
                        EmailConfigId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Value = c.String(maxLength: 500),
                        Type = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.EmailConfigId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmailConfigs");
        }
    }
}
