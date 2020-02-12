using System;
using System.Diagnostics;
using System.IO;
using System.Security.Claims;

using Insta.Web.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insta.Web.Controllers
{
    public class UserController : Controller
    {
        protected Guid UserId => Guid.Parse(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);

        protected int NormalizePage(int page)
        {
            return page > 0 ? page : 0;
        }

        protected IActionResult GetErrorPage()
        {
            return this.View(
                "Error",
                new ErrorViewModel
                    {
                        RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
                    });
        }

        protected Stream Resize(IFormFile file)
        {
            return file.OpenReadStream();
        }
    }
}
