using System;
using System.Collections.Generic;
using System.Text;

namespace Insta.DataAccess.Records
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public sealed class EntityTypeRecord
    {
        [Key]
        public int EntityTypeId { get; set; }

        [Required]
        public string Name { get; set; }

        public List<EntityRecord> Entities { get; set; }

    }
}
