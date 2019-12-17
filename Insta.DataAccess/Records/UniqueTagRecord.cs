namespace Insta.DataAccess.Records
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UniqueTags")]
    public sealed class UniqueTagRecord
    {
        public List<TagRecord> Tags { get; set; }

        [Required]
        public string Text { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UniqueTagId { get; set; }
    }
}