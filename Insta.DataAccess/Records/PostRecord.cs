using System;
using System.Collections.Generic;
using System.Text;

namespace Insta.DataAccess.Records
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    public sealed class PostRecord
    { 
        [Key]
        public int PostId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserRecord User { get; set; }

        public string Geolocation { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public List<CommentRecord> Comments { get; set; }

        public List<TagRecord> Tags { get; set; }


    }
}
