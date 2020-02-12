using System;

namespace Insta.DataAccess.Records
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Profiles")]
    public sealed class ProfileRecord
    {
        public int Age { get; set; }

        public string Description { get; set; }

        public string FirstName { get; set; }

        public int Gender { get; set; }

        public bool IsVisible { get; set; }

        public string LastName { get; set; }

        public UserRecord User { get; set; }

        [Key, ForeignKey("User")]
        public Guid UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        public string ImageCloudUrl { get; set; }
    }
}