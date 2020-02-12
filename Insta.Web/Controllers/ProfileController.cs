using System;
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
    public class ProfileController : UserController
    {
        private const int PageSize = 12;

        private readonly UsersRepository usersRepository;

        private readonly PostsRepository postsRepository;

        private readonly SubscriptionsRepository subscriptionsRepository;

        private readonly IAzureBlobStorageService azureBlobStorageService;

        public ProfileController(
            UsersRepository usersRepository,
            SubscriptionsRepository subscriptionsRepository,
            PostsRepository postsRepository,
            IAzureBlobStorageService azureBlobStorageService)
        {
            this.usersRepository = usersRepository;
            this.subscriptionsRepository = subscriptionsRepository;
            this.postsRepository = postsRepository;
            this.azureBlobStorageService = azureBlobStorageService;
        }

        [HttpGet]
        public async Task<IActionResult> Profile(Guid userId, int page)
        {
            if (userId == this.UserId)
            {
                return this.RedirectToAction("MyPage");
            }

            var posts = await this.postsRepository.GetPosts(userId, this.NormalizePage(page), PageSize);
            var socialStats = await this.subscriptionsRepository.GetSocialStats(this.UserId);
            var user = await this.usersRepository.GetUser(userId);
            user.CanSubscribe = !await this.subscriptionsRepository.IsFollowing(this.UserId, userId);

            var viewModels = new UserPageViewModel
            {
                User = user,
                Posts = posts,
                Followers = socialStats.Followers,
                Following = socialStats.Following
            };

            return this.View("UserPage", viewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var user = await this.usersRepository.GetUser(this.UserId);

            return this.View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEntity userEditModel, IFormFile profileImage)
        {
            if (userEditModel == null)
            {
                return this.GetErrorPage();
            }

            userEditModel.Id = this.UserId;
         
            userEditModel.ProfileImageCloudUrl = await this.UploadPhoto(profileImage);

            await this.usersRepository.UpdateUser(userEditModel);

            return this.RedirectToAction("MyPage");
        }

        [HttpGet]
        public async Task<IActionResult> MyPage(int page)
        {
            var posts = await this.postsRepository.GetPosts(this.UserId, this.NormalizePage(page), PageSize);
            var socialStats = await this.subscriptionsRepository.GetSocialStats(this.UserId);
            var user = await this.usersRepository.GetUser(this.UserId);

            var viewModels = new UserPageViewModel
                                 {
                                     User = user,
                                     Posts = posts,
                                     Followers = socialStats.Followers,
                                     Following = socialStats.Following,
                                     MyPosts = true
                                 };

            return this.View("UserPage", viewModels);
        }

        private async Task<string> UploadPhoto(IFormFile image)
        {
            if (image != null)
            {
                using (var resizedImages = this.Resize(image))
                {
                    var imageData = await this.azureBlobStorageService.Upload(
                                        $"images/{this.UserId}",
                                        $"{Guid.NewGuid()}_{image.FileName}",
                                        resizedImages);

                    return imageData.Uri.AbsoluteUri;
                }
            }

            return null;
        }
    }
}
