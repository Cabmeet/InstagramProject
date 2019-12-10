namespace Insta.DataAccess.Records
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public sealed class DescriptionRecord
    {
        public PostRecord Post { get; set; }

        [Key, ForeignKey("Post")]
        public int PostId { get; set; }

        [Required]
        public string Text { get; set; }
    }
}