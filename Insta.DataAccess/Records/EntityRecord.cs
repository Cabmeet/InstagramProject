namespace Insta.DataAccess.Records
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public sealed class EntityRecord
    {
        public Guid EntityGuid { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int EntityId { get; set; }

        public EntityTypeRecord EntityType { get; set; }

        [ForeignKey("EntityType")]
        public int EntityTypeId { get; set; }

        public List<LikeRecord> Likes { get; set; }

        public List<PhotoRecord> Photos { get; set; }
    }
}