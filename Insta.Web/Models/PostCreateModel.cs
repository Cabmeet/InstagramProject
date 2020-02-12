using System.ComponentModel.DataAnnotations;

namespace Insta.Web.Models
{
    public class PostCreateModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Content { get; set; }

        public string Location { get; set; }

        public string Tags { get; set; }
    }
}
