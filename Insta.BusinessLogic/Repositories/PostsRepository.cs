using Insta.BusinessLogic.Dto;
using Insta.BusinessLogic.Encryption;
using Insta.BusinessLogic.Entities;
using Insta.DataAccess.Context;
using Insta.DataAccess.Records;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insta.BusinessLogic.Repositories
{
    public class PostsRepository
    {
        public void AddPost(int userId, PostRecord post)
        {

            using (var context = new InstaContext())
            {
                var user = context.UserRecords.FirstOrDefault(
                  n => n.UserId == userId);
                if (user != null)
                {
                    context.PostRecords.Add(post);
                    context.SaveChanges();
                    EntityRecord entityRecord = new EntityRecord();
                    entityRecord.EntityGuid = Guid.NewGuid();
                    entityRecord.EntityId = post.PostId;
                    entityRecord.EntityTypeId = (int)EntityType.Post;
                    context.EntityRecords.Add(entityRecord);
                    context.SaveChanges();

                }
            }
        }
        public void DeletePost(int postId)
        {
            using (var context = new InstaContext())
            {
                PostRecord post = context.PostRecords.FirstOrDefault(n => n.PostId == postId);
                if (post != null)
                {
                    context.PostRecords.Remove(post);

                    context.SaveChanges();
                    var entity = context.EntityRecords.First(n => n.EntityId == postId);
                    context.EntityRecords.Remove(entity);
                    context.SaveChanges();




                }


            }
        }
        public void UpdateGeolocation(int postId, string geolocation)
        {
            using (var context = new InstaContext())
            {
                PostRecord post = context.PostRecords.FirstOrDefault(n => n.PostId == postId);
                if (post != null)
                {
                    post.Geolocation = geolocation;
                    context.SaveChanges();
                }



            }

        }






        public void UpdateDescription(int postId, string text)
        {
            using (var context = new InstaContext())
            {
                DescriptionRecord description
                    = context.DescriptionRecords.FirstOrDefault(
                    n => n.PostId == postId);
                if (description != null)
                {
                    description.Text = text;
                    context.SaveChanges();

                }
                ;

            }

        }
        public void AddTag(int postId, string[] tags)
        {
            using (var context = new InstaContext())
            {
                PostRecord post = context.PostRecords.FirstOrDefault(n => n.PostId == postId);
                if (post != null)
                {
                    foreach (string t in tags)
                    {
                        UniqueTagRecord tag = context.UniqueTagRecords.FirstOrDefault(n => n.Text == t);
                        if (tag != null)
                        {
                            TagRecord tagRecord = new TagRecord();
                            tagRecord.PostId = postId;
                            tagRecord.UniqueTagId = tag.UniqueTagId;

                            post.Tags.Add(tagRecord);
                        }
                        else
                        {
                            UniqueTagRecord uniqueTagRecord = new UniqueTagRecord();
                            uniqueTagRecord.Text = t;
                            context.UniqueTagRecords.Add(uniqueTagRecord);
                            context.SaveChanges();
                            TagRecord tagRecord = new TagRecord();
                            tagRecord.PostId = postId;
                            tagRecord.UniqueTagId = uniqueTagRecord.UniqueTagId;
                            post.Tags.Add(tagRecord);


                        }

                        context.SaveChanges();
                    }

                }

            }
        }
        public void DeleteTags(int postId, string[] tags)
        {
            using (var context = new InstaContext())
            {

                PostRecord post = context.PostRecords.FirstOrDefault(n => n.PostId == postId);
                if (post != null)
                {

                    foreach (TagRecord tag in post.Tags)
                    {
                        if (tags.Contains(tag.UniqueTag.Text))
                        {
                            context.TagRecords.Remove(tag);
                            context.SaveChanges();
                        }

                    }
                }


            }

        }
        public void AddLike(int postId, int userId)
        {
            using (var context = new InstaContext())
            {
                var like = new LikeRecord();
                like.CreatedAt = DateTimeOffset.Now;
                like.EntityId = postId;
                like.UserId = userId;
                context.LikeRecords.Add(like);
                context.SaveChanges();




            }

        }


        public void DeleteLike(int postId, int userId)
        {
            using (var context = new InstaContext())
            {
                var like = context.LikeRecords.First(n => n.EntityId == postId && n.UserId == userId);
                context.LikeRecords.Remove(like);
                context.SaveChanges();

            }
        }
        public void AddPhoto(PhotoDto[] photoDtos)
        {
            using (var context = new InstaContext())
            {
                foreach (PhotoDto photo1 in photoDtos)
                {
                    var photo = new PhotoRecord();
                    photo.CloudUrl = photo1.CloudUrl;
                    photo.CreatedAt = photo1.CreatedAt;
                    photo.EntityId = photo1.EntityId;
                    photo.Order = photo1.Order;
                    photo.Height = photo1.Height;
                    photo.Width = photo1.Width;
                    context.PhotoRecords.Add(photo);

                }
                context.SaveChanges();
            }
        }
        public void DeletePhoto(int postId, int photoId)
        {
            using (var context = new InstaContext())
            {
                var photo = context.PhotoRecords.First(n => n.EntityId == postId && n.PhotoId == photoId);
                context.PhotoRecords.Remove(photo);
                context.SaveChanges();
            }
        }
        public void AddComment(CommentDto comment1)
        {
            using (var context = new InstaContext())
            {


                var comment = new CommentRecord();
                comment.CreatedAt = comment1.CreatedAt;
                comment.PostId = comment1.PostId;
                comment.UserId = comment1.UserId;
                comment.ParentCommentId = comment1.ParentCommentId;
                comment.Text = comment1.Text;
                context.CommentRecords.Add(comment);
                context.SaveChanges();

            }
        }



        public void UpdateComment(int postId, int commentId, string text)
        {
            using (var context = new InstaContext())
            {
                var comment = context.CommentRecords.First(n => n.PostId == postId && n.CommentId == commentId);
                comment.Text = text;
                context.SaveChanges();


            }
        }
        public List<PostDto> GetFeed(int userId)
        {

            using (var context = new InstaContext())
            {
                var subscriptions = context.SubscriptionRecords.Where(n => n.SubscriberUserId == userId)
                    .Include(n => n.SubscriberUser)
                    .AsNoTracking().ToArray();

                var subscrUserIds = subscriptions.Select(n => n.SubscribedToUserId);
                var posts = context.PostRecords.Where(n => subscrUserIds.Contains(n.UserId)).Include(n => n.Description)
                    .Include(n => n.Tags).
                    ThenInclude(n => n.UniqueTag).Include(n => n.User).ThenInclude(n => n.Profile)
                    .OrderByDescending(n => n.CreatedAt).Take(10);
                var subscrPost = new List<PostDto>();

                foreach (PostRecord post in posts)
                {
                   var postDto = new PostDto();
                    var entity = context.EntityRecords.First(n => n.EntityId == post.PostId);
                    var photos = entity.Photos.ToArray();
                    var likes = entity.Likes.ToArray();
                    postDto.CreatedAt = post.CreatedAt;
                    postDto.Geolocation = post.Geolocation;
                    postDto.Likes = likes.Length;
                    postDto.Tags = post.Tags.Select(n => n.UniqueTag.Text).ToArray();
                    postDto.Text = post.Description.Text;
                    postDto.Photos = photos.Select(n => new PhotoDto()
                    {
                        Order = n.Order,
                        CloudUrl = n.CloudUrl,
                        PhotoId = n.PhotoId,
                    }).ToArray();
                    postDto.UserName = post.User.Profile.UserName;
                    subscrPost.Add(postDto);
                    
                }
                    return subscrPost;
            }
        }

    }
}

