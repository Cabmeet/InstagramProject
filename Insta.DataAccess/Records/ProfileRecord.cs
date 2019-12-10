using System;
using System.Collections.Generic;
using System.Text;

namespace Insta.DataAccess.Records
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

  public sealed class ProfileRecord
    {
        
        [Key, ForeignKey("User")]
        public int UserId { get; set; }
        public UserRecord User { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Gender { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }

        public List<SubscriptionRecord> Subscribers { get; set; }

    }
}
