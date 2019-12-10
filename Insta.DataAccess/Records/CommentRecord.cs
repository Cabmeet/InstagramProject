using System;
using System.Collections.Generic;
using System.Text;

namespace Insta.DataAccess.Records
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore.Metadata.Conventions;

   public sealed class CommentRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] 
        public int CommentId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserRecord User { get; set; }
        
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public PostRecord Post { get; set; }

        [ForeignKey("ParentComment")]
        public int? ParentCommentId { get; set; }
        public CommentRecord ParentComment { get; set; }

        [Required]
        public string Text { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public List<CommentRecord> Comments { get; set; }


    }
}
