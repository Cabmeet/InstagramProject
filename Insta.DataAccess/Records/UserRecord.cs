namespace Insta.DataAccess.Records
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Users")]
    public sealed class UserRecord
    {
        public List<CommentRecord> Comments { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string EncryptedPassword { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public List<LikeRecord> Likes { get; set; }

        public List<PostRecord> Posts { get; set; }

        public ProfileRecord Profile { get; set; }

        public List<SubscriptionRecord> Subscribers { get; set; }

        public List<SubscriptionRecord> Subscriptions { get; set; }

        [Key]
        public Guid UserId { get; set; }
    }
}