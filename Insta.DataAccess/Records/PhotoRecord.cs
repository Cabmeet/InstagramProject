namespace Insta.DataAccess.Records
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore.Metadata.Internal;

  public sealed class PhotoRecord
    {
        [Required]
        public string CloudUrl { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        
        [ForeignKey("Entity")]
        public int EntityId { get; set; }
        public EntityRecord Entity { get; set; }


        public int Height { get; set; }

        public int Order { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PhotoId { get; set; }

        public int Width { get; set; }
    }
}