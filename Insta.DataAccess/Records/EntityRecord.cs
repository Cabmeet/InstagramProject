using System;
using System.Collections.Generic;
using System.Text;

namespace Insta.DataAccess.Records
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public sealed class EntityRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int EntityId { get; set; }

        [ForeignKey("EntityType")]
        public int EntityTypeId { get; set; }
        public EntityTypeRecord EntityType { get; set; }

        public Guid EntityGuid { get; set; }

        public List<PhotoRecord> Photos { get; set; }

        public List<LikeRecord> Likes { get; set; }
    }
}

