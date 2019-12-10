namespace Insta.DataAccess.Records
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public sealed class ProfileRecord
    {
        public int Age { get; set; }

        public string Description { get; set; }

        [Required]
        public string FirstName { get; set; }

        public int Gender { get; set; }

        public bool IsVisible { get; set; }

        public string LastName { get; set; }

        public UserRecord User { get; set; }

        [Key, ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}