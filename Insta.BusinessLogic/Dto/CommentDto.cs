using System;
using System.Collections.Generic;
using System.Text;

namespace Insta.BusinessLogic.Dto
{
   public void  class CommentDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int ParentCommentId { get; set; }
        public string Text { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
