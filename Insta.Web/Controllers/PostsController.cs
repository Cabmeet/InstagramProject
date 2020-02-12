using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Insta.Azure;
using Insta.BusinessLogic.Entities;
using Insta.BusinessLogic.Repositories;
using Insta.Web.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insta.Web.Controllers
{
    [Authorize]
    public class PostsController : UserController
    {
        private const int PageSize = 12;

        private readonly PostsRepository postsRepository;

        private readonly LikesRepository likesRepository;

        private readonly IAzureBlobStorageService azureBlobStorageService;

        public PostsController(
            PostsRepository postsRepository,
            IAzureBlobStorageService azureBlobStorageService,
            LikesRepository likesRepository)
        {
            this.postsRepository = postsRepository;
            this.azureBlobStorageService = azureBlobStorageService;
            this.likesRepository = likesRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(int postId, string text)
        {
            await this.postsRepository.AddComment(
                new CommentEntity
                {
                    Text = text,
                    PostId = postId,
                    UserId = this.UserId
                });

            return this.RedirectToAction(
                "View",
                new
                {
                    postid = postId
                });
        }

        [HttpPost]
        public async Task<JsonResult> Like(int postId)
        {
            var likesCount = await this.likesRepository.AddLike(this.UserId, postId);

            return new JsonResult(new
            {
                likesCount
            });
        }

        [HttpGet]
        public async Task<IActionResult> View(int postId)
        {
            var post = await this.postsRepository.GetPost(postId);

            this.ViewBag.CanEdit = post.UserId == this.UserId;

            return this.View(post);
        }

        [HttpGet]
        public async Task<IActionResult> Feed(int page)
        {
            var posts = await this.postsRepository.GetFeed(this.UserId, this.NormalizePage(page), PageSize);

            return this.View(posts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostCreateModel createModel, IFormFile[] images)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(
                    "Error",
                    new ErrorViewModel
                    {
                        RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
                    });
            }

            var postId = await this.postsRepository.AddPost(
                             new PostEntity
                             {
                                 Description = createModel.Content,
                                 Location = createModel.Location,
                                 UserId = this.UserId
                             });

            if (!string.IsNullOrEmpty(createModel.Tags))
            {
                var tagsArray = createModel.Tags.Split(",")
                    .Select(
                        x => x.ToLower()
                            .Trim())
                    .Where(x => !string.IsNullOrEmpty(x))
                    .ToArray();

                await this.postsRepository.AddTags(postId, tagsArray);
            }

            var postImages = await this.UploadPhotos(images);
            foreach (var image in postImages)
            {
                image.EntityId = postId;
            }

            await this.postsRepository.AddPhotos(postImages);

            return this.RedirectToAction("MyPage", "Profile");
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int postId)
        {
            await this.postsRepository.Delete(postId, this.UserId);

            return new JsonResult(new
            {
                Url = this.Url.Action("MyPage", "Profile")
            });
        }

        private async Task<PhotoEntity[]> UploadPhotos(IFormFile[] images)
        {
            var postImages = new List<PhotoEntity>();

            if (images != null && images.Length != 0)
            {
                for (var index = 0; index < images.Length; index++)
                {
                    using (var resizedImages = this.Resize(images[index]))
                    {
                        var imageData = await this.azureBlobStorageService.Upload(
                                            $"images/{this.UserId}",
                                            $"{Guid.NewGuid()}_{images[index].FileName}",
                                            resizedImages);

                        postImages.Add(
                            new PhotoEntity
                            {
                                CloudUrl = imageData.Uri.AbsoluteUri,
                                Order = index
                            });
                    }
                }
            }

            return postImages.ToArray();
        }
    }
}