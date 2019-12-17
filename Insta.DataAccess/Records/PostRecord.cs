namespace Insta.DataAccess.Records
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Posts")]
    public sealed class PostRecord
    {
        public List<CommentRecord> Comments { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DescriptionRecord Description { get; set; }

        public string Geolocation { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PostId { get; set; }

        public List<TagRecord> Tags { get; set; }

        public UserRecord User { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}