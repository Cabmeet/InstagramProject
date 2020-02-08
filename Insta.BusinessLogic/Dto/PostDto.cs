using System;
using System.Collections.Generic;
using System.Text;

namespace Insta.BusinessLogic.Dto
{
   public class PostDto
    {
        public DateTimeOffset CreatedAt { get; set; }
        public string Text { get; set; }
        public string Geolocation { get; set; }
        public string[] Tags { get; set; }
        public PhotoDto [] Photos { get; set; }
        public int Likes { get; set; }
        public string UserName { get; set; }
    }
}
