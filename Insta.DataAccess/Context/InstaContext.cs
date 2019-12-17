namespace Insta.DataAccess.Context
{
    using Insta.DataAccess.Records;

    using Microsoft.EntityFrameworkCore;

    public class InstaContext : DbContext
    {
        public DbSet<CommentRecord> CommentRecords { get; set; }

        public DbSet<DescriptionRecord> DescriptionRecords { get; set; }

        public DbSet<EntityRecord> EntityRecords { get; set; }

        public DbSet<EntityTypeRecord> EntityTypeRecords { get; set; }

        public DbSet<LikeRecord> LikeRecords { get; set; }

        public DbSet<PhotoRecord> PhotoRecords { get; set; }

        public DbSet<PostRecord> PostRecords { get; set; }

        public DbSet<ProfileRecord> ProfileRecords { get; set; }

        public DbSet<SubscriptionRecord> SubscriptionRecords { get; set; }

        public DbSet<TagRecord> TagRecords { get; set; }

        public DbSet<UniqueTagRecord> UniqueTagRecords { get; set; }

        public DbSet<UserRecord> UserRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-J5BAKQT\\SQLEXPRESS;Initial Catalog=InstaDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubscriptionRecord>().HasKey(x => new { x.SubscriberUserId, x.SubscribedToUserId });
            modelBuilder.Entity<TagRecord>().HasKey(u => new { u.PostId, u.UniqueTagId });
            modelBuilder
                .Entity<SubscriptionRecord>()
                .HasOne(x => x.SubscriberUser)
                .WithMany(x => x.Subscriptions)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<SubscriptionRecord>()
                .HasOne(x => x.SubscribedToUser)
                .WithMany(x => x.Subscribers)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder
                .Entity<CommentRecord>()
                .HasOne(x => x.User)
                .WithMany(x => x.Comments)
                .OnDelete(DeleteBehavior.NoAction);

        }

    }
}