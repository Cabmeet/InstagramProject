namespace Insta.DataAccess.Records
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    public sealed class UserRecord
    {
        public DateTimeOffset CreatedAt { get; set; }

        [Required]
        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public ProfileRecord Profile { get; set; }

        [Required]
        public string EncryptedPassword { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserId { get; set; }

        public List<PostRecord> Posts { get; set; }

        public List<CommentRecord> Comments { get; set; }

        public List<LikeRecord> Likes { get; set; }

        public List<SubscriptionRecord> Subscriptions { get; set; }
    }
}