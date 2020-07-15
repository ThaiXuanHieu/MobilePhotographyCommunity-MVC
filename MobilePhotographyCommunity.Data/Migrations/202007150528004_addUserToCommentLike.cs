namespace MobilePhotographyCommunity.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserToCommentLike : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "User_UserId", c => c.Int());
            AddColumn("dbo.Like", "User_UserId", c => c.Int());
            CreateIndex("dbo.Comment", "User_UserId");
            CreateIndex("dbo.Like", "User_UserId");
            AddForeignKey("dbo.Comment", "User_UserId", "dbo.User", "UserId");
            AddForeignKey("dbo.Like", "User_UserId", "dbo.User", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Like", "User_UserId", "dbo.User");
            DropForeignKey("dbo.Comment", "User_UserId", "dbo.User");
            DropIndex("dbo.Like", new[] { "User_UserId" });
            DropIndex("dbo.Comment", new[] { "User_UserId" });
            DropColumn("dbo.Like", "User_UserId");
            DropColumn("dbo.Comment", "User_UserId");
        }
    }
}
