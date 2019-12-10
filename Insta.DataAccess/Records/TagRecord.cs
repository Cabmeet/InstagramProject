using System;
using System.Collections.Generic;
using System.Text;

namespace Insta.DataAccess.Records
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public sealed class TagRecord
    {
        
        [Key,ForeignKey("Post")]
        public int PostId { get; set; }
        public PostRecord Post { get; set; }

       
         [Key,ForeignKey("UniqueTag")]
        public int UniqueTagId { get; set; }
        public UniqueTagRecord UniqueTag { get; set; }

    }
}
