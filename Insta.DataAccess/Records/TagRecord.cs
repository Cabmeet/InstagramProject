

namespace Insta.DataAccess.Records
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Tags")]
    public sealed class TagRecord
    {
        
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public PostRecord Post { get; set; }

       
         [ForeignKey("UniqueTag")]
        public int UniqueTagId { get; set; }
        public UniqueTagRecord UniqueTag { get; set; }

    }
}
