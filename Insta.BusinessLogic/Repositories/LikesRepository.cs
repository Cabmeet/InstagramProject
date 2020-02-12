using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Insta.DataAccess.Context;
using Insta.DataAccess.Records;

using Microsoft.EntityFrameworkCore;

namespace Insta.BusinessLogic.Repositories
{
    public sealed class LikesRepository
    {
        private static readonly SemaphoreSlim LikeSemaphore = new SemaphoreSlim(1);

        public async Task<int> AddLike(Guid userId, int postId)
        {
            await LikeSemaphore.WaitAsync();

            try
            {
                using (var context = new InstaContext())
                {
                    var like = context.LikeRecords.FirstOrDefault(x => x.UserId == userId &&
                                                                    x.EntityId == postId);
                    if (like != null)
                    {
                        context.LikeRecords.Remove(like);
                    }
                    else
                    {
                        context.LikeRecords.Add(
                            new LikeRecord
                            {
                                EntityId = postId,
                                UserId = userId,
                                CreatedAt = DateTimeOffset.Now
                            });
                    }

                    await context.SaveChangesAsync();

                    return await context.LikeRecords.CountAsync(x => x.EntityId == postId);
                }
            }
            finally
            {
                LikeSemaphore.Release(1);
            }
        }
    }
}
