namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedstatusfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PolicyFeeds", "Status", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PolicyFeeds", "Status");
        }
    }
}
