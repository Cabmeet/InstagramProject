using System;
using System.Collections.Generic;
using System.Text;

namespace Insta.DataAccess.Records
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public sealed class LikeRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int LikeId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserRecord User { get; set; }

        [ForeignKey("Entity")]
        public int EntityId { get; set; }
        public EntityRecord Entity { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
