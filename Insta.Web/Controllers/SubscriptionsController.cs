using System;
using System.Threading.Tasks;

using Insta.BusinessLogic.Repositories;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Insta.Web.Controllers
{
    [Authorize]
    public class SubscriptionsController : UserController
    {
        private readonly SubscriptionsRepository subscriptionsRepository;

        public SubscriptionsController(SubscriptionsRepository subscriptionsRepository)
        {
            this.subscriptionsRepository = subscriptionsRepository;
        }

        [HttpGet]
        [Route("[controller]/followers")]
        public async Task<IActionResult> MyFollowers()
        {
            var followers = await this.subscriptionsRepository.GetFollowers(this.UserId);

            return this.View(followers);
        }

        [HttpGet]
        [Route("[controller]/following")]
        public async Task<IActionResult> MySubscriptions()
        {
            var subscriptions = await this.subscriptionsRepository.GetSubscriptions(this.UserId);
           
            return this.View(subscriptions);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(Guid otherUserId, string action)
        {
            if (this.UserId == otherUserId)
            {
                return this.GetErrorPage();
            }

            switch (action.ToLower())
            {
                case "u":
                    await this.subscriptionsRepository.DeleteSubscription(this.UserId, otherUserId);
                    break;
                case "s":
                    await this.subscriptionsRepository.AddSubscription(this.UserId, otherUserId);
                    break;
                default:
                    return this.GetErrorPage();
            }

            return this.RedirectToAction("MySubscriptions");
        }
    }
}
