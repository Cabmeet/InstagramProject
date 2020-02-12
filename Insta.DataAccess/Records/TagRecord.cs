using System.ComponentModel.DataAnnotations.Schema;

namespace Insta.DataAccess.Records
{
    [Table("Tags")]
    public sealed class TagRecord
    {
        public PostRecord Post { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }

        public UniqueTagRecord UniqueTag { get; set; }

        [ForeignKey("UniqueTag")]
        public int UniqueTagId { get; set; }
    }
}
