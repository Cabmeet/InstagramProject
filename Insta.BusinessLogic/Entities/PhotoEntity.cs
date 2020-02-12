using System;

namespace Insta.BusinessLogic.Entities
{
    public class PhotoEntity
    {
        public int Id { get; set; }

        public string CloudUrl { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public int EntityId { get; set; }

        public int Height { get; set; }

        public int Order { get; set; }

        public int Width { get; set; }
    }
}
