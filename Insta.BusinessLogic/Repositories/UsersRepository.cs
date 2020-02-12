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
    public sealed class UsersRepository
    {
        public async Task CreateUser(Guid userId, string userName, string email, string imageCloudUrl)
        {
            Guard.ArgumentNotNullOrEmpty(userName, nameof(userName));
            Guard.ArgumentNotNullOrEmpty(email, nameof(email));

            using (var context = new InstaContext())
            {
                await context.UserRecords.AddAsync(
                     new UserRecord
                     {
                         UserId = userId,
                         Email = email,
                         CreatedAt = DateTimeOffset.Now,
                         EncryptedPassword = string.Empty,
                         IsEmailConfirmed = true,
                         Profile = new ProfileRecord
                         {
                             UserName = userName,
                             IsVisible = true,
                             ImageCloudUrl = imageCloudUrl
                         }
                     });

                await context.SaveChangesAsync();
            }
        }

        public async Task<UserEntity[]> FindUsers(Guid userId, string text, int page, int take)
        {
            Guard.ArgumentNotNull(text, nameof(text));

            using (var context = new InstaContext())
            {
                var users = await context.UserRecords
                    .AsNoTracking()
                    .Include(x => x.Profile)
                    .Where(
                        n => n.UserId != userId &&
                             n.Profile.IsVisible &&
                             (n.Profile.UserName.Contains(text) ||
                             n.Profile.FirstName.Contains(text) ||
                             n.Profile.LastName.Contains(text)))
                    .OrderBy(x => x.Profile.UserName)
                    .Skip(page * take)
                    .Take(take)
                    .ToArrayAsync();

                var subscriptions = await context.SubscriptionRecords
                     .AsNoTracking()
                     .Where(x => x.SubscriberUserId == userId)
                     .Select(x => x.SubscribedToUserId)
                     .ToArrayAsync();

                var userEntities = users.Select(x => x.ToEntity()).ToArray();

                foreach (var user in userEntities)
                {
                    var userEntity = subscriptions.FirstOrDefault(x => x == user.Id);
                    if (userEntity != Guid.Empty)
                    {
                        user.CanSubscribe = false;
                    }
                }

                return userEntities;
            }
        }

        public async Task<UserEntity> GetUser(Guid userId)
        {
            using (var context = new InstaContext())
            {
                var user = await context.UserRecords.AsNoTracking()
                                .Include(x => x.Profile)
                                .FirstOrDefaultAsync(n => n.UserId == userId);

                return user.ToEntity();
            }
        }

        public async Task UpdateUser(UserEntity userEditModel)
        {
            Guard.ArgumentNotNull(userEditModel, nameof(userEditModel));

            using (var context = new InstaContext())
            {
                var user = await context.UserRecords
                               .Include(x => x.Profile)
                               .FirstAsync(n => n.UserId == userEditModel.Id);

                user.Profile.Age = userEditModel.Age;
                user.Profile.Description = userEditModel.Description;
                user.Profile.FirstName = userEditModel.FirstName;
                user.Profile.LastName = userEditModel.LastName;
                user.Profile.Gender = (int)userEditModel.Gender;
                user.Profile.IsVisible = userEditModel.IsVisible;

                if (!string.IsNullOrEmpty(userEditModel.ProfileImageCloudUrl))
                {
                    user.Profile.ImageCloudUrl = userEditModel.ProfileImageCloudUrl;
                }

                await context.SaveChangesAsync();
            }
        }
    }
}