

namespace Insta.DataAccess.Records
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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
