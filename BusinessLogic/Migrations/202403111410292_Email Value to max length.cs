namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailValuetomaxlength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmailConfigs", "Value", c => c.String(maxLength: 3000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmailConfigs", "Value", c => c.String(maxLength: 500));
        }
    }
}
