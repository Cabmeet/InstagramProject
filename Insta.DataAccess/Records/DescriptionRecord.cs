using System;
using System.Collections.Generic;
using System.Text;

namespace Insta.DataAccess.Records
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public sealed class DescriptionRecord
    {
        
        [Key, ForeignKey("Description")]
        public int DescriptionId { get; set; }
        public DescriptionRecord Description { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public PostRecord Post { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
