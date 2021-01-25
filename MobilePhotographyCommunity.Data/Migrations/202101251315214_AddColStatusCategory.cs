namespace MobilePhotographyCommunity.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColStatusCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "Status", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "Status");
        }
    }
}
