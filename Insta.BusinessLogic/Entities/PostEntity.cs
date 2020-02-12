using System;

namespace Insta.BusinessLogic.Entities
{
    public sealed class PostEntity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string[] Tags { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string UserName { get; set; }

        public Guid UserId { get; set; }

        public int Likes { get; set; }

        public PhotoEntity[] Photos { get; set; }

        public CommentEntity[] Comments { get; set; }
    }
}
