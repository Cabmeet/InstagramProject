using Microsoft.AspNetCore.Mvc;

namespace Insta.Web.Controllers
{
    public class HomeController : UserController
    {
        public IActionResult Privacy()
        {
            return this.View();
        }
    }
}
