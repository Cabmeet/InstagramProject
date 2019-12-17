namespace Insta.DataAccess.Records
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EntityTypes")]
    public sealed class EntityTypeRecord
    {
        public List<EntityRecord> Entities { get; set; }

        [Key]
        public int EntityTypeId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}