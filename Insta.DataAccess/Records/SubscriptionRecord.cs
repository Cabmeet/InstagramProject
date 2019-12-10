using System;
using System.Collections.Generic;
using System.Text;

namespace Insta.DataAccess.Records
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore.Metadata.Internal;

   public sealed class SubscriptionRecord
    {
       
        [Key,ForeignKey("SubscriberUser")]
        public int SubscriberUserId { get; set; }
        public SubscriptionRecord SubscriberUser { get; set; }

        [Key,ForeignKey("SubscribedToUser")]
        public int SubscribedToUserId { get; set; }
        public SubscriptionRecord SubscribedToUser { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

       

    }
}
