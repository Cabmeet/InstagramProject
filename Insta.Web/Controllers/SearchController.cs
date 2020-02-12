using System.Threading.Tasks;

using Insta.BusinessLogic.Repositories;
using Insta.Web.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Insta.Web.Controllers
{
    [Authorize]
    public class SearchController : UserController
    {
        private const int PageSize = 20;

        private readonly UsersRepository usersRepository;

        private readonly PostsRepository postsRepository;

        public SearchController(PostsRepository postsRepository, UsersRepository usersRepository)
        {
            this.postsRepository = postsRepository;
            this.usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string text, int page)
        {
            var users = await this.usersRepository.FindUsers(this.UserId, text ?? string.Empty, this.NormalizePage(page), PageSize);
            var posts = await this.postsRepository.FindPostsByTags(this.UserId, text ?? string.Empty, this.NormalizePage(page), PageSize);

            return this.View(new FindResultsViewModel
            {
                Posts = posts.Entities,
                Users = users,
            });
        }
    }
}
