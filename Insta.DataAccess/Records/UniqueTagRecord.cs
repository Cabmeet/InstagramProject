using System;
using System.Collections.Generic;
using System.Text;

namespace Insta.DataAccess.Records
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    public sealed class UniqueTagRecord

       
    {  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UniqueTagId { get; set; }

        [Required]
        public string Text { get; set; }

        public List<TagRecord> Tags { get; set; }

    }
}
