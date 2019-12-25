using System;
using System.Linq;

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
    public sealed class UsersRepository
    {
        public async Task<UserEntity> FindUser(string userName, string password)
        {
            Guard.ArgumentNotNullOrEmpty(userName, nameof(userName));
            Guard.ArgumentNotNullOrEmpty(password, nameof(password));

            using var context = new InstaContext();
            var encryptedPassword = StringEncryptor.Encrypt(password);

            var userData = await context
                .Set<UserRecord>()
                .Include(x => x.Profile)
                .Where(n => n.Profile.UserName == userName && n.EncryptedPassword == encryptedPassword)
                .Join(
                    context.Set<EntityRecord>(),
                    u => u.UserId,
                    e => e.EntityId,
                    (u, e) => new { User = u, Entity = e })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (userData == null)
            {
                return null;
            }

            return userData.User.TonEntity(userData.Entity);
        }

        public async Task<int> CreateUser(UserEntity user, string password)
        {
            Guard.ArgumentNotNull(user, nameof(user));
            Guard.ArgumentNotNullOrEmpty(password, nameof(password));

            var userRecord = user.ToRecord(password);
            using var scope = new TransactionScope(
                TransactionScopeOption.Required,
                new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted
                },
                TransactionScopeAsyncFlowOption.Enabled);

            using var context = new InstaContext();

            await context
                .Set<UserRecord>()
                .AddAsync(userRecord);

            await context.SaveChangesAsync();

            var userEntity = new EntityRecord
            {
                EntityGuid = Guid.NewGuid(),
                EntityId = userRecord.UserId,
                EntityTypeId = (int)EntityType.User
            };

            await context
                 .Set<EntityRecord>()
                 .AddAsync(userEntity);

            await context.SaveChangesAsync();
            scope.Complete();

            return userEntity.EntityId;
        }
    }
}
