namespace Insta.DataAccess.Records
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Subscriptions")]
    public sealed class SubscriptionRecord
    {
        public DateTimeOffset CreatedAt { get; set; }

        public UserRecord SubscribedToUser { get; set; }

         [ForeignKey("SubscribedToUser")]
        public int SubscribedToUserId { get; set; }

        public UserRecord SubscriberUser { get; set; }

        [ForeignKey("SubscriberUser")]
        public int SubscriberUserId { get; set; }
    }
}