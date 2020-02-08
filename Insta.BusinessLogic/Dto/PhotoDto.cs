using System;
using System.Collections.Generic;
using System.Text;

namespace Insta.BusinessLogic.Dto
{
  public  class PhotoDto
    {
        public string CloudUrl { get; set; }
        public DateTimeOffset CreatedAt {get; set;}
        public int EntityId { get; set; }
        public int PhotoId { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Order { get; set; }
    }
}
