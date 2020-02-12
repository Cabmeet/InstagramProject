using System;

namespace Insta.BusinessLogic.Entities
{
    public sealed class CommentEntity
    {
        public DateTimeOffset CreatedAt { get; set; }

        public string Text { get; set; }

        public string UserName { get; set; }

        public int PostId { get; set; }

        public Guid UserId { get; set; }

        public string UserProfileCloudUrl { get; set; }
    }
}
