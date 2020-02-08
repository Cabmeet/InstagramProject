using Insta.DataAccess.Context;
using Insta.DataAccess.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insta.BusinessLogic.Converters;
using Insta.BusinessLogic.Entities;

using Microsoft.Practices.EnterpriseLibrary.Common.Utility;

using System.Threading.Tasks;
using System.Transactions;

using Insta.BusinessLogic.Encryption;
using Insta.DataAccess.Context;
using Insta.DataAccess.Records;

using Microsoft.EntityFrameworkCore;

namespace Insta.BusinessLogic.Repositories
{
    public class SubscriptionsRepository

    {
        public SubscriptionRecord AddSubscription(int subscribedToUserId, int subscriberUserId)
        {
            using (var context = new InstaContext())
            {
                SubscriptionRecord subscriber = new SubscriptionRecord();
                subscriber.SubscribedToUserId = subscribedToUserId;
                subscriber.SubscriberUserId = subscriberUserId;
                context.SubscriptionRecords.Add(subscriber);
                context.SaveChanges();
                return subscriber;



            }
        }

        public void DeleteSubscription(int subscribedToUserId, int subscriberUserId)
        {
            using (var context = new InstaContext())
            {
                SubscriptionRecord subscriber = context.SubscriptionRecords.FirstOrDefault(
                   n => n.SubscribedToUserId == subscribedToUserId && n.SubscriberUserId == subscriberUserId);

                if (subscriber != null)
                {

                    context.SubscriptionRecords.Remove(subscriber);
                    context.SaveChanges();


                }
                
            }

        }
        public SubscriptionRecord [] GetSubscriberUser(int userId)
        {
            using (var context = new InstaContext())
            {
                var subscriptions = context.SubscriptionRecords.Where(n => n.SubscriberUserId == userId).ToArray();
                return subscriptions;
            }
        }
        public SubscriptionRecord[] GetSubscribedToUser(int userId)
        {
            using (var context = new InstaContext())
            {
                var subscriptions = context.SubscriptionRecords.Where(n => n.SubscribedToUserId == userId).ToArray();
                return subscriptions;
            }
        }
    }
}

