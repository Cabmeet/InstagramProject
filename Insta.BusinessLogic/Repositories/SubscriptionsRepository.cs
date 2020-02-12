using System;
using System.Linq;
using System.Threading.Tasks;

using Insta.BusinessLogic.Converters;
using Insta.BusinessLogic.Entities;
using Insta.DataAccess.Context;
using Insta.DataAccess.Records;

using Microsoft.EntityFrameworkCore;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;

namespace Insta.BusinessLogic.Repositories
{
    public class SubscriptionsRepository
    {
        public async Task AddSubscription(Guid userId, Guid subscribedToUserId)
        {
            using (var context = new InstaContext())
            {
                var subscriber = new SubscriptionRecord
                {
                    SubscribedToUserId = subscribedToUserId,
                    SubscriberUserId = userId
                };
                context.SubscriptionRecords.Add(subscriber);

                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteSubscription(Guid userId, Guid subscribedToUserId)
        {
            using (var context = new InstaContext())
            {
                var subscriber = await context.SubscriptionRecords.FirstOrDefaultAsync(
                                     n => n.SubscribedToUserId == subscribedToUserId && n.SubscriberUserId == userId);

                if (subscriber != null)
                {
                    context.SubscriptionRecords.Remove(subscriber);

                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<UserEntity[]> GetSubscriptions(Guid userId)
        {
            using (var context = new InstaContext())
            {
                var following = await context.SubscriptionRecords.AsNoTracking()
                                    .Where(x => x.SubscriberUserId == userId)
                                    .Include(x => x.SubscribedToUser)
                                    .ThenInclude(x => x.Profile)
                                    .ToArrayAsync();

                var users = following.Select(x => x.SubscribedToUser.ToEntity()).ToArray();
                users.ForEach(x => x.CanSubscribe = false);

                return users;
            }
        }

        public async Task<UserEntity[]> GetFollowers(Guid userId)
        {
            using (var context = new InstaContext())
            {
                var following = await context.SubscriptionRecords.AsNoTracking()
                                    .Where(x => x.SubscribedToUserId == userId)
                                    .Include(x => x.SubscriberUser)
                                    .ThenInclude(x => x.Profile)
                                    .ToArrayAsync();

                var users = following.Select(x => x.SubscriberUser.ToEntity()).ToArray();
                users.ForEach(x => x.CanSubscribe = false);

                return users;
            }
        }

        public async Task<SocialStats> GetSocialStats(Guid userId)
        {
            using (var context = new InstaContext())
            {
                var following = await context.SubscriptionRecords.AsNoTracking()
                                    .CountAsync(x => x.SubscriberUserId == userId);

                var followers = await context.SubscriptionRecords.AsNoTracking()
                                    .CountAsync(x => x.SubscribedToUserId == userId);

                return new SocialStats
                {
                    Followers = followers,
                    Following = following
                };
            }
        }

        public async Task<bool> IsFollowing(Guid userId, Guid otherUserId)
        {
            using (var context = new InstaContext())
            {
                return await context.SubscriptionRecords.AnyAsync(x => x.SubscriberUserId == userId &&
                                                                       x.SubscribedToUserId == otherUserId);
            }
        }
    }
}
