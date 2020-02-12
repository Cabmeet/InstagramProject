using System;
using System.Collections.Generic;
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
    public class PostsRepository
    {
        public async Task AddComment(CommentEntity comment)
        {
            Guard.ArgumentNotNull(comment, nameof(comment));

            using (var context = new InstaContext())
            {
                context.CommentRecords.Add(new CommentRecord
                {
                    PostId = comment.PostId,
                    UserId = comment.UserId,
                    Text = comment.Text,
                    CreatedAt = DateTimeOffset.Now
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task AddPhotos(PhotoEntity[] photos)
        {
            Guard.ArgumentNotNull(photos, nameof(photos));

            using (var context = new InstaContext())
            {
                await context.PhotoRecords.AddRangeAsync(photos.Select(x => x.ToRecord()));

                await context.SaveChangesAsync();
            }
        }

        public async Task<int> AddPost(PostEntity post)
        {
            Guard.ArgumentNotNull(post, nameof(post));

            using (var context = new InstaContext())
            {
                var postRecord = new PostRecord
                {
                    Description = new DescriptionRecord
                    {
                        Text = post.Description
                    },
                    Geolocation = post.Location,
                    UserId = post.UserId,
                    CreatedAt = DateTimeOffset.Now,
                };

                await context.PostRecords.AddAsync(postRecord);

                await context.SaveChangesAsync();

                var entityRecord = new EntityRecord
                {
                    ExternalEntityId = postRecord.PostId,
                    EntityTypeId = (int)EntityType.Post
                };

                await context.EntityRecords.AddAsync(entityRecord);

                await context.SaveChangesAsync();

                return postRecord.PostId;
            }
        }

        public async Task AddTags(int postId, string[] tags)
        {
            Guard.ArgumentNotNull(tags, nameof(tags));

            using (var context = new InstaContext())
            {
                var post = await context.PostRecords
                               .Include(x => x.Tags)
                               .FirstOrDefaultAsync(n => n.PostId == postId);

                if (post != null)
                {
                    var existingTags = await context.UniqueTagRecords
                                           .Where(x => tags.Contains(x.Text))
                                           .ToArrayAsync();

                    post.Tags.AddRange(
                        existingTags
                            .Where(x => !post.Tags.Select(t => t.UniqueTagId).Contains(x.UniqueTagId))
                            .Select(
                                x => new TagRecord
                                {
                                    UniqueTagId = x.UniqueTagId
                                }));

                    var newTags = tags
                        .Where(x => !existingTags.Select(t => t.Text).Contains(x, StringComparer.OrdinalIgnoreCase))
                        .Select(
                            x => new UniqueTagRecord
                            {
                                Text = x
                            })
                        .ToArray();

                    await context.UniqueTagRecords.AddRangeAsync(newTags);
                    await context.SaveChangesAsync();

                    post.Tags.AddRange(newTags.Select(x =>
                        new TagRecord
                        {
                            UniqueTagId = x.UniqueTagId
                        }));

                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<Container<PostEntity>> GetFeed(Guid userId, int page, int take)
        {
            var sRepo = new SubscriptionsRepository();
            var mySubscriptions = await sRepo.GetSubscriptions(userId);

            using (var context = new InstaContext())
            {
                var userIds = mySubscriptions.Select(x => x.Id);

                var total = await context.PostRecords.AsNoTracking()
                                .CountAsync(n => userIds.Contains(n.UserId));

                var posts = await context.PostRecords.AsNoTracking()
                                .Where(n => userIds.Contains(n.UserId))
                                .Include(n => n.Description)
                                .Include(n => n.Tags)
                                .ThenInclude(n => n.UniqueTag)
                                .Include(n => n.User)
                                .ThenInclude(n => n.Profile)
                                .OrderByDescending(n => n.CreatedAt)
                                .Skip(page * take)
                                .Take(take)
                                .ToArrayAsync();

                var postEntities = new List<PostEntity>();

                foreach (var post in posts)
                {
                    postEntities.Add(await this.ToPostEntity(post));
                }

                return new Container<PostEntity>
                {
                    Entities = postEntities.ToArray(),
                    Page = page,
                    TotalEntities = total
                };
            }
        }

        public async Task<Container<PostEntity>> GetPosts(Guid userId, int page, int take)
        {
            using (var context = new InstaContext())
            {
                var totalPostsCount = await context.PostRecords
                                          .AsNoTracking()
                                          .CountAsync(x => x.UserId == userId);

                var posts = await context.PostRecords
                                .AsNoTracking()
                                .Where(x => x.UserId == userId)
                                .OrderByDescending(x => x.CreatedAt)
                                .Skip(page * take)
                                .Take(take)
                                .Include(x => x.Tags)
                                .ThenInclude(x => x.UniqueTag)
                                .Include(x => x.Description)
                                .Include(x => x.User)
                                .ThenInclude(x => x.Profile)
                                .ToArrayAsync();

                var postEntities = new List<PostEntity>();
                foreach (var post in posts)
                {
                    postEntities.Add(await this.ToPostEntity(post));
                }

                return new Container<PostEntity>
                {
                    Entities = postEntities.ToArray(),
                    Page = page,
                    TotalEntities = totalPostsCount
                };
            }
        }

        public async Task<Container<PostEntity>> FindPostsByTags(Guid userId, string tag, int page, int take)
        {
            Guard.ArgumentNotNullOrEmpty(tag, nameof(tag));

            using (var context = new InstaContext())
            {
                var allTags = context.TagRecords
                                          .AsNoTracking()
                                          .Where(x => x.UniqueTag.Text.Contains(tag) &&
                                                      x.Post.UserId != userId);

                var totalPostsCount = await allTags.CountAsync();

                var postIds = await allTags.OrderByDescending(x => x.Post.CreatedAt)
                    .Skip(page * take)
                    .Take(take)
                    .Select(x => x.PostId)
                    .ToArrayAsync();

                var posts = await context.PostRecords.AsNoTracking()
                      .Include(x => x.Tags)
                      .ThenInclude(x => x.UniqueTag)
                      .Include(x => x.Description)
                      .Include(x => x.User)
                      .ThenInclude(x => x.Profile)
                      .Include(x => x.Comments)
                      .ThenInclude(x => x.User)
                      .ThenInclude(x => x.Profile)
                      .Where(x => postIds.Contains(x.PostId))
                      .ToArrayAsync();

                var postEntities = new List<PostEntity>();
                foreach (var post in posts)
                {
                    var entity = await context.EntityRecords
                                     .Include(x => x.Photos)
                                     .Include(x => x.Likes)
                                     .FirstAsync(x => x.ExternalEntityId == post.PostId);
                    var photos = entity.Photos.Select(x => x.ToEntity()).ToArray();
                    var postEntity = post.ToEntity();
                    postEntity.Photos = photos;
                    postEntity.Likes = entity.Likes.Count;

                    postEntities.Add(postEntity);
                }

                return new Container<PostEntity>
                {
                    Entities = postEntities.ToArray(),
                    Page = page,
                    TotalEntities = totalPostsCount
                };
            }
        }

        public async Task<PostEntity> GetPost(int postId)
        {
            using (var context = new InstaContext())
            {
                var post = await context.PostRecords.AsNoTracking()
                               .Include(x => x.Tags)
                               .ThenInclude(x => x.UniqueTag)
                               .Include(x => x.Description)
                               .Include(x => x.User)
                               .ThenInclude(x => x.Profile)
                               .Include(x => x.Comments)
                               .ThenInclude(x => x.User)
                               .ThenInclude(x => x.Profile)
                               .FirstOrDefaultAsync(x => x.PostId == postId);

                var entity = await context.EntityRecords
                                 .Include(x => x.Photos)
                                 .Include(x => x.Likes)
                                 .FirstAsync(x => x.ExternalEntityId == post.PostId);

                var photos = entity.Photos.Select(x => x.ToEntity()).ToArray();
                var postEntity = post.ToEntity();

                var comments = post.Comments.Select(
                    x => new CommentEntity
                    {
                        CreatedAt = x.CreatedAt,
                        Text = x.Text,
                        UserName = x.User.Profile.UserName,
                        PostId = x.PostId,
                        UserProfileCloudUrl = x.User.Profile.ImageCloudUrl
                    }).ToArray();

                postEntity.Photos = photos;
                postEntity.Likes = entity.Likes.Count;
                postEntity.Comments = comments;

                return postEntity;
            }
        }

        public async Task Delete(int postId, Guid userId)
        {
            using (var context = new InstaContext())
            {
                var post = await context.PostRecords.FirstOrDefaultAsync(x => x.UserId == userId && x.PostId == postId);
                if (post == null)
                {
                    return;
                }

                context.PostRecords.Remove(post);

                await context.SaveChangesAsync();
            }
        }

        private async Task<PostEntity> ToPostEntity(PostRecord post)
        {
            using (var context = new InstaContext())
            {
                var entity = await context.EntityRecords
                                 .AsNoTracking()
                                 .Include(x => x.Photos)
                                 .Include(x => x.Likes)
                                 .FirstAsync(x => x.ExternalEntityId == post.PostId);

                var photos = entity.Photos
                    .Select(x => x.ToEntity())
                    .ToArray();

                var postEntity = post.ToEntity();
                postEntity.Photos = photos;
                postEntity.Likes = entity.Likes.Count;

                return postEntity;
            }
        }
    }
}
