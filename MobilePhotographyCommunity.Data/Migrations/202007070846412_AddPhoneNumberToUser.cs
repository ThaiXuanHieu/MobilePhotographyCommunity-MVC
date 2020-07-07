namespace MobilePhotographyCommunity.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneNumberToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "PhoneNumber", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.FriendRelationship", "UserTwo", "dbo.User");
            DropForeignKey("dbo.FriendRelationship", "UserOne", "dbo.User");
            DropForeignKey("dbo.FriendRelationship", "StatusId", "dbo.FriendStatus");
            DropForeignKey("dbo.JoinChallenge", "ChallengeId", "dbo.Challenge");
            DropForeignKey("dbo.Post", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Like", "PostId", "dbo.Post");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.FriendRelationship", new[] { "StatusId" });
            DropIndex("dbo.FriendRelationship", new[] { "UserTwo" });
            DropIndex("dbo.FriendRelationship", new[] { "UserOne" });
            DropIndex("dbo.JoinChallenge", new[] { "ChallengeId" });
            DropIndex("dbo.Like", new[] { "PostId" });
            DropIndex("dbo.Comment", new[] { "PostId" });
            DropIndex("dbo.Post", new[] { "CategoryId" });
            DropTable("dbo.Role");
            DropTable("dbo.UserRole");
            DropTable("dbo.User");
            DropTable("dbo.FriendStatus");
            DropTable("dbo.FriendRelationship");
            DropTable("dbo.Device");
            DropTable("dbo.JoinChallenge");
            DropTable("dbo.Challenge");
            DropTable("dbo.Like");
            DropTable("dbo.Comment");
            DropTable("dbo.Post");
            DropTable("dbo.Category");
        }
    }
}
