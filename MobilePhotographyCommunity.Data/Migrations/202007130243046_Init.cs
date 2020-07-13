namespace MobilePhotographyCommunity.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Category",
            //    c => new
            //        {
            //            CategoryId = c.Int(nullable: false, identity: true),
            //            CategoryName = c.String(maxLength: 50),
            //            MetaTitle = c.String(maxLength: 50),
            //            Description = c.String(),
            //            CreatedBy = c.Int(),
            //            CreatedTime = c.DateTime(),
            //            ModifiedBy = c.Int(),
            //            ModifiedTime = c.DateTime(),
            //        })
            //    .PrimaryKey(t => t.CategoryId);
            
            //CreateTable(
            //    "dbo.Post",
            //    c => new
            //        {
            //            PostId = c.Int(nullable: false, identity: true),
            //            CategoryId = c.Int(),
            //            Caption = c.String(),
            //            Image = c.String(),
            //            CreatedBy = c.Int(),
            //            CreatedTime = c.DateTime(),
            //            ModifiedBy = c.Int(),
            //            ModifiedTime = c.DateTime(),
            //        })
            //    .PrimaryKey(t => t.PostId)
            //    .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
            //    .Index(t => t.CategoryId);
            
            //CreateTable(
            //    "dbo.Comment",
            //    c => new
            //        {
            //            CommentId = c.Int(nullable: false, identity: true),
            //            PostId = c.Int(),
            //            Content = c.String(),
            //            CreatedBy = c.Int(),
            //            CreatedTime = c.DateTime(),
            //            ModifiedBy = c.Int(),
            //            ModifiedTime = c.DateTime(),
            //        })
            //    .PrimaryKey(t => t.CommentId)
            //    .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
            //    .Index(t => t.PostId);
            
            //CreateTable(
            //    "dbo.Like",
            //    c => new
            //        {
            //            LikeId = c.Int(nullable: false, identity: true),
            //            PostId = c.Int(),
            //            CreatedBy = c.Int(),
            //            CreatedTime = c.DateTime(),
            //            ModifiedBy = c.Int(),
            //            ModifiedTime = c.DateTime(),
            //        })
            //    .PrimaryKey(t => t.LikeId)
            //    .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
            //    .Index(t => t.PostId);
            
            //CreateTable(
            //    "dbo.Challenge",
            //    c => new
            //        {
            //            ChallengeId = c.Int(nullable: false, identity: true),
            //            ChallengeName = c.String(),
            //            MetaTitle = c.String(),
            //            Description = c.String(),
            //            StartDate = c.DateTime(),
            //            EndDate = c.DateTime(),
            //            CreatedBy = c.Int(),
            //            CreatedTime = c.DateTime(),
            //            ModifiedBy = c.Int(),
            //            ModifiedTime = c.DateTime(),
            //        })
            //    .PrimaryKey(t => t.ChallengeId);
            
            //CreateTable(
            //    "dbo.JoinChallenge",
            //    c => new
            //        {
            //            JoinChallengeId = c.Int(nullable: false, identity: true),
            //            ChallengeId = c.Int(),
            //            UserId = c.Int(),
            //            PostId = c.Int(),
            //            DeviceId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.JoinChallengeId)
            //    .ForeignKey("dbo.Challenge", t => t.ChallengeId, cascadeDelete: true)
            //    .Index(t => t.ChallengeId);
            
            //CreateTable(
            //    "dbo.Device",
            //    c => new
            //        {
            //            DeviceId = c.Int(nullable: false, identity: true),
            //            DeviceName = c.String(maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.DeviceId);
            
            //CreateTable(
            //    "dbo.FriendRelationship",
            //    c => new
            //        {
            //            FRId = c.Int(nullable: false, identity: true),
            //            UserOne = c.Int(),
            //            UserTwo = c.Int(),
            //            StatusId = c.Int(),
            //            ActionUser = c.Int(),
            //        })
            //    .PrimaryKey(t => t.FRId)
            //    .ForeignKey("dbo.StatusFriend", t => t.StatusId, cascadeDelete: true)
            //    .ForeignKey("dbo.User", t => t.UserOne, cascadeDelete: true)
            //    .ForeignKey("dbo.User", t => t.UserTwo)
            //    .Index(t => t.UserOne)
            //    .Index(t => t.UserTwo)
            //    .Index(t => t.StatusId);
            
            //CreateTable(
            //    "dbo.StatusFriend",
            //    c => new
            //        {
            //            StatusId = c.Int(nullable: false, identity: true),
            //            StatusName = c.String(maxLength: 50),
            //            GroupStatus = c.Int(),
            //            Description = c.String(),
            //        })
            //    .PrimaryKey(t => t.StatusId);
            
            //CreateTable(
            //    "dbo.User",
            //    c => new
            //        {
            //            UserId = c.Int(nullable: false, identity: true),
            //            UserName = c.String(maxLength: 50),
            //            PasswordHash = c.String(),
            //            FirstName = c.String(maxLength: 50),
            //            LastName = c.String(maxLength: 50),
            //            Gender = c.Boolean(),
            //            DateOfBirth = c.DateTime(),
            //            Avatar = c.String(),
            //            LastLogin = c.DateTime(),
            //            IsLocked = c.Boolean(),
            //            PhoneNumber = c.String(maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.UserId);
            
            //CreateTable(
            //    "dbo.UserRole",
            //    c => new
            //        {
            //            UserRoleId = c.Int(nullable: false, identity: true),
            //            UserId = c.Int(),
            //            RoleId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.UserRoleId)
            //    .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
            //    .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId)
            //    .Index(t => t.RoleId);
            
            //CreateTable(
            //    "dbo.Role",
            //    c => new
            //        {
            //            RoleId = c.Int(nullable: false, identity: true),
            //            RoleName = c.String(maxLength: 50),
            //            Description = c.String(maxLength: 100),
            //        })
            //    .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.FriendRelationship", "UserTwo", "dbo.User");
            DropForeignKey("dbo.FriendRelationship", "UserOne", "dbo.User");
            DropForeignKey("dbo.FriendRelationship", "StatusId", "dbo.StatusFriend");
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
            DropTable("dbo.StatusFriend");
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
