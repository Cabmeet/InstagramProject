namespace Insta.DataAccess.Records
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Subscriptions")]
    public sealed class SubscriptionRecord
    {
        public DateTimeOffset CreatedAt { get; set; }

        public UserRecord SubscribedToUser { get; set; }

         [ForeignKey("SubscribedToUser")]
        public Guid SubscribedToUserId { get; set; }

        public UserRecord SubscriberUser { get; set; }

        [ForeignKey("SubscriberUser")]
        public Guid SubscriberUserId { get; set; }
    }
}