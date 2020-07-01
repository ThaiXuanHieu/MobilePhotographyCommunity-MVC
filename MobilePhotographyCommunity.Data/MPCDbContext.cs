namespace MobilePhotographyCommunity.Data.DomainModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MPCDbContext : DbContext
    {
        public MPCDbContext()
            : base("name=MPCDbContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Challenge> Challenges { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<FriendRelationship> FriendRelationships { get; set; }
        public virtual DbSet<FriendStatu> FriendStatus { get; set; }
        public virtual DbSet<JoinChallenge> JoinChallenges { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Posts)
                .WithOptional(e => e.Category)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Challenge>()
                .HasMany(e => e.JoinChallenges)
                .WithOptional(e => e.Challenge)
                .WillCascadeOnDelete();

            modelBuilder.Entity<FriendStatu>()
                .HasMany(e => e.FriendRelationships)
                .WithOptional(e => e.FriendStatu)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Comments)
                .WithOptional(e => e.Post)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Likes)
                .WithOptional(e => e.Post)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserRoles)
                .WithOptional(e => e.Role)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .HasMany(e => e.FriendRelationships)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UserOne)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .HasMany(e => e.FriendRelationships1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.UserTwo);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRoles)
                .WithOptional(e => e.User)
                .WillCascadeOnDelete();
        }
    }
}
