namespace Insta.DataAccess.Context
{
    using Insta.DataAccess.Records;

    using Microsoft.EntityFrameworkCore;

    public class Context : DbContext
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
            optionsBuilder.UseSqlServer("");
        }
    }
}