namespace Insta.DataAccess.Records
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public sealed class LikeRecord
    {
        public DateTimeOffset CreatedAt { get; set; }

        public EntityRecord Entity { get; set; }

        [ForeignKey("Entity")]
        public int EntityId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int LikeId { get; set; }

        public UserRecord User { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}