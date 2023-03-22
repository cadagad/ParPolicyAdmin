namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PolicyAddedUserFlagging : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Policies", "UserFlaggedDuplicate", c => c.Boolean());
            AddColumn("dbo.Policies", "UserFlaggedDeficient", c => c.Boolean());
            AddColumn("dbo.Policies", "UserFlaggedExclusion", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Policies", "UserFlaggedExclusion");
            DropColumn("dbo.Policies", "UserFlaggedDeficient");
            DropColumn("dbo.Policies", "UserFlaggedDuplicate");
        }
    }
}
